
Public MustInherit Class FrmSupplier
    Protected Sub InputSupplier_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Protected dt As New DataTable
    Protected Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambahProvinsi.Click
        FrmProvinsi.ShowDialog()
        Using dtload = SelectCon.execute("SELECT NAMA FROM PROVINSI ORDER BY NAMA")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    cmbProvinsi.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
    End Sub

    Protected Sub FrmSupplier_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Nama Bank", TypeCode.String)
        InitGrid.AddColumnGrid("Pemilik", TypeCode.String)
        InitGrid.AddColumnGrid("No. Account", TypeCode.String)
        InitGrid.AddColumnGrid("Keterangan", TypeCode.String)
        InitGrid.EndInit(TBDetailAccountBank, GridView1, dt)
        Using dtload = SelectCon.execute("SELECT NAMA FROM PROVINSI ORDER BY NAMA")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    cmbProvinsi.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
        AddRow(dt)
    End Sub

    Protected Sub GridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            End If
        End If
    End Sub

    Protected Sub TBDetailAccountBank_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDetailAccountBank.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            EnterNewRow(GridView1, dt, "Keterangan", "Nama Bank", , "Nama Bank")
        End If
    End Sub

    Protected Sub cmbProvinsi_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProvinsi.SelectedIndexChanged
        cmbKota.Properties.Items.Clear()
        Try
            Using dtload = SelectCon.execute("SELECT A.KOTA FROM DETAIL_PROVINSI A INNER JOIN PROVINSI B ON A.KODE=B.KODE WHERE B.NAMA='" & cmbProvinsi.SelectedItem.ToString & "'")
                If dtload.Rows.Count > 0 Then
                    For i = 0 To dtload.Rows.Count - 1
                        cmbKota.Properties.Items.Add(dtload.Rows(i).Item(0))
                    Next
                End If
                cmbKota.SelectedIndex = -1
            End Using
        Catch
        End Try
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dt.Dispose()
        Me.Dispose()
    End Sub
End Class

Public Class InputSupplier
    Inherits FrmSupplier

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(Now, "yy")
        Using dtGenerate = SelectCon.execute("SELECT ID FROM SUPPLIER WHERE ID Like 'S" & date1 & Format(Now, "MM") & "%' ORDER BY ID DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Mid(dtGenerate.Rows(0).Item(0), 6, 3) + 1
            End If
            TxtKode.Text = "S" & date1 & Format(Now, "MM") & Format(urut, "000")
        End Using
    End Sub

    Private Sub Batal()
        Clean(Me.FindForm)
        dt.Clear()
        AddRow(dt)
        TxtNama.Focus()
        Call Generate()
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Empty(TxtAlamatKantor) Then Exit Sub

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        Generate()
        con.begin_exec()

        SQl = "INSERT INTO SUPPLIER VALUES ('" & TxtKode.Text & "','" & Replace(TxtNama.Text, "'", "`") & "','" & Replace(TxtAlamatKantor.Text, "'", "`") & "','" & Replace(cmbProvinsi.SelectedItem, "'", "`") & "','" & Replace(cmbKota.SelectedItem, "'", "`") & "','" & txtKodePos.Text & "','" & TxtTelp.Text & "','" & TxtNoFax.Text & "','" & TxtEmail.Text & "','" & TxtAlamatweb.Text & "','" & TxtContactPerson.Text & "','" & TxtNPWP.Text & "','" & UserID & "',CURRENT_TIMESTAMP,null,null,1)"

        If con.exec(SQl) Then
            GridView1.CloseEditor()
            For Each col As DataRow In dt.Rows
                If Len(col(0).ToString.Trim) > 0 Then
                    If con.exec("INSERT INTO DETAIL_SUPPLIER VALUES ('" & TxtKode.Text & "','" & col(0) & "','" & col(1) & "','" & col(2) & "','" & col(3) & "')") = False Then GoTo keluar
                End If
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

    Private Sub InputSupplier_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Supplier"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        Call Generate()
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditSupplier
    Inherits FrmSupplier

    Private Sub GetData() Handles TxtKode.TextChanged
        'Load Data Header
        LoadData.GetData("SELECT NAMA,ALAMAT_KANTOR,PROVINSI,KOTA,POS,TELP,FAX,EMAIL,WEBSITE,NPWP,CONTACT_PERSON,STATUS_AKTIF FROM SUPPLIER WHERE ID='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtAlamatKantor, cmbProvinsi, cmbKota, txtKodePos, TxtTelp, TxtNoFax, TxtEmail, TxtAlamatweb, TxtNPWP, TxtContactPerson, CekStatusAktif})
        'Load Data Detail
        LoadData.GetData("SELECT NAMA_BANK AS [NAMA BANK],PEMILIK AS PEMILIK,NOMOR_ACCOUNT AS [NOMOR ACCOUNT],KETERANGAN AS KETERANGAN FROM DETAIL_SUPPLIER WHERE ID='" & TxtKode.Text & "'")
        LoadData.SetDataDetail(dt, True)
    End Sub

    Private Sub EditSupplier_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Supplier"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE SUPPLIER SET  NAMA='" & Replace(TxtNama.Text, "'", "`") & "',ALAMAT_KANTOR='" & Replace(TxtAlamatKantor.Text, "'", "`") & "',PROVINSI='" & Replace(cmbProvinsi.SelectedItem, "'", "`") & "',KOTA='" & Replace(cmbKota.SelectedItem, "'", "`") & "',POS='" & txtKodePos.Text & "',TELP='" & TxtTelp.Text & "',FAX='" & TxtNoFax.Text & "',EMAIL='" & TxtEmail.Text & "',WEBSITE='" & TxtAlamatweb.Text & "',CONTACT_PERSON='" & TxtContactPerson.Text & "',NPWP='" & TxtNPWP.Text & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE ID='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_SUPPLIER WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            GridView1.CloseEditor()
             For Each col As DataRow In dt.Rows
                If Len(col(0).ToString.Trim) > 0 Then
                    If con.exec("INSERT INTO DETAIL_SUPPLIER VALUES ('" & TxtKode.Text & "','" & col(0) & "','" & col(1) & "','" & col(2) & "','" & col(3) & "')") = False Then GoTo keluar
                End If
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

        SQl = "DELETE FROM SUPPLIER WHERE ID='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_SUPPLIER WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
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