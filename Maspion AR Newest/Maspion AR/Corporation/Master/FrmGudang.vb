Public MustInherit Class FrmGudang
    Protected dt As New DataTable

    Private Sub InputGudang_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dt.Dispose()
        Me.Close()
    End Sub

    Private Sub FrmGudang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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

Public Class InputGudang
    Inherits FrmGudang

    Private Sub Batal()
        Clean(Me)
        Generate()
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Generate()
        Dim urut As Integer
        Using dt = SelectCon.execute("SELECT KODE FROM GUDANG WHERE KODE LIKE '%GD%' ORDER BY KODE DESC")
            If dt.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Mid(dt.Rows(0).Item(0), 3, 3) + 1
            End If
        End Using
        TxtKode.Text = "GD" & Format(urut, "000")
    End Sub

    Private Sub InputGudang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Name = "InputGudang"
        Text = "Input Gudang"
        Generate()
        _Toolbar1_Button4.Visible = False
        CekStatusAktif.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal

        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Empty(TxtAlamat) Then Exit Sub
        If Empty(TxtPenanggungJawab) Then Exit Sub

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "INSERT INTO GUDANG VALUES ('" & TxtKode.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtTelp.Text & "','" & TxtPenanggungJawab.Text & "','" & UserID & "','" & Format(Now, "MM/dd/yyyy HH:mm:ss") & "',null,null,1)"

        If con.exec(SQl) Then
            GridView1.CloseEditor()
            For Each col As DataRow In dt.Select("Ceklist=1")
                If con.exec("INSERT INTO LINK_GUDANG_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
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
        MsgBox(SQl)
        MessageBox.Show("Data gagal tersimpan..!!", _
                        "Penyimpanan Sukses", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub
End Class

Public Class EditGudang
    Inherits FrmGudang

    Private Sub GetData()
        LoadData.GetData("SELECT NAMA_GUDANG,ALAMAT,TELP,PENANGGUNG_JAWAB,STATUS_AKTIF FROM GUDANG WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtAlamat, TxtTelp, TxtPenanggungJawab, CekStatusAktif})

        LoadData.GetData("SELECT KODE,NAMA,CAST(IIF(B.KODE_DIVISI IS NULL,0,1) AS BIT) FROM DIVISI A LEFT JOIN LINK_GUDANG_DIVISI B ON A.KODE=B.KODE_DIVISI AND B.KODE_GUDANG='" & TxtKode.Text & "' ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub EditGudang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Name = "EditGudang"
        Text = "Edit Gudang"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtKode.EditValueChanged, AddressOf GetData
        HakForm("", "Master", "Gudang", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE GUDANG SET NAMA_GUDANG='" & Replace(TxtNama.Text, "'", "`") & "',ALAMAT='" & Replace(TxtAlamat.Text, "'", "`") & "',PENANGGUNG_JAWAB='" & Replace(TxtPenanggungJawab.Text, "'", "`") & "',TELP='" & TxtTelp.Text & "',MDUSER='" & UserID & "',MDTIME='" & Format(Now, "MM/dd/yyyy HH:mm:ss") & "',STATUS_AKTIF='" & CekStatusAktif.CheckState & "' WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_GUDANG_DIVISI WHERE KODE_GUDANG='" & TxtKode.Text & "'") = False Then GoTo keluar
            GridView1.CloseEditor()
            For Each col As DataRow In dt.Select("Ceklist=1")
                If con.exec("INSERT INTO LINK_GUDANG_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
            Next
            con.end_exec(True)
            MessageBox.Show("Data sudah dirubah..!!", _
                            "Rubah Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Close()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MsgBox(SQl)
        MessageBox.Show("Data gagal terubah..!!", _
                        "Penyimpanan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub _Toolbar1_Button4_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button4.Click
        If _Toolbar1_Button4.Visible = False Then Exit Sub
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "DELETE FROM GUDANG WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQL) Then
            If con.exec("DELETE FROM LINK_GUDANG_DIVISI WHERE KODE_GUDANG='" & TxtKode.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data sudah terhapus..!!", _
                            "Hapus Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Close()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MsgBox(SQl)
        MessageBox.Show("Data gagal terhapus..!!", _
                        "Hapus Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub
End Class