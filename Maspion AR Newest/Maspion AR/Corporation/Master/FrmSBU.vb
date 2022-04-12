Public MustInherit Class FrmSBU
    Protected dt As New DataTable

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dt.Dispose()
        Me.Dispose()
    End Sub

    Private Sub FrmSBU_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F4
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button4.PerformClick()
        End Select
    End Sub

    Private Sub FrmSBU_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Divisi", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama Divisi", TypeCode.String, 100, False)
        InitGrid.AddColumnGrid("Ceklist", TypeCode.Boolean, 40)
        InitGrid.EndInit(TBLinkDivisi, GridView1, dt)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Try
            If IsNumeric(e.Value) Then
                GridView1.GetFocusedDataRow(GridView1.FocusedColumn.FieldName) = Val(e.Value)
            Else
                GridView1.GetFocusedDataRow(GridView1.FocusedColumn.FieldName) = e.Value
            End If
        Catch
        End Try
    End Sub
End Class

Public Class InputSBU
    Inherits FrmSBU

    Private Sub Batal()
        Clean(Me.FindForm)
        TxtKode.Focus()
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "INSERT INTO SBU (KODE,NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,INISIAL,KETERANGAN,STATUS_AKTIF,CRUSER,CRTIME) VALUES ('" & TxtKode.Text & "','" & Replace(TxtNama.Text, "'", "`") & "','" & Replace(TxtAlamat.Text, "'", "`") & "','" & Replace(TxtTelp.Text, "'", "`") & "','" & Replace(TxtPenanggungJawab.Text, "'", "`") & "','" & Replace(txtInisial.Text, "'", "`") & "','" & Replace(TxtKeterangan.Text, "'", "`") & "',1,'" & UserID & "',CURRENT_TIMESTAMP)"

        If con.exec(SQl) Then
            GridView1.CloseEditor()
            For Each col As DataRow In dt.Select("Ceklist=1")
                If con.exec("INSERT INTO LINK_SBU_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
            Next
            con.end_exec(True)
            MessageBox.Show("Data Baru telah disimpan..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Batal()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub InputSBU_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Sentral Bisnis Unit"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal

        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub
End Class

Public Class EditSBU
    Inherits FrmSBU

    Private Sub EditSBU_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Sentral Bisnis Unit"
        TxtKode.Enabled = False
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "SBU", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        LoadData.GetData("SELECT NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,INISIAL,KETERANGAN,STATUS_AKTIF FROM SBU WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtAlamat, TxtTelp, TxtPenanggungJawab, txtInisial, TxtKeterangan, CekStatusAktif})

        LoadData.GetData("SELECT KODE,NAMA,CAST(IIF(B.KODE_DIVISI IS NULL,0,1) AS BIT) FROM DIVISI A LEFT JOIN LINK_SBU_DIVISI B ON A.KODE=B.KODE_DIVISI AND B.KODE_SBU='" & TxtKode.Text & "' ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE SBU SET NAMA='" & Replace(TxtNama.Text, "'", "`") & "',ALAMAT='" & Replace(TxtAlamat.Text, "'", "`") & "',TELP='" & Replace(TxtTelp.Text, "'", "`") & "',PENANGGUNG_JAWAB='" & Replace(TxtPenanggungJawab.Text, "'", "`") & "',INISIAL='" & Replace(txtInisial.Text, "'", "`") & "',KETERANGAN='" & Replace(TxtKeterangan.Text, "'", "`") & "',STATUS_AKTIF='" & CekStatusAktif.EditValue & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_SBU_DIVISI WHERE KODE_SBU='" & TxtKode.Text & "'") = False Then GoTo keluar
            GridView1.CloseEditor()
            For Each col As DataRow In dt.Select("Ceklist=1")
                If con.exec("INSERT INTO LINK_SBU_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
            Next
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dirubah..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Dispose()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.Click
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()
        SQl = "DELETE FROM SBU WHERE KODE='" & TxtKode.Text & "'"
        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_SBU_DIVISI WHERE KODE_SBU='" & TxtKode.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dihapus..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Dispose()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub
End Class