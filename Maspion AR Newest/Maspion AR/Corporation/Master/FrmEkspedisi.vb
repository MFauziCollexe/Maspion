Public MustInherit Class FrmEkspedisi

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
        Me.Dispose()
        Me.Close()
    End Sub

End Class

Public Class InputEkspedisi
    Inherits FrmEkspedisi

    Private Sub Batal()
        Clean(Me)
        Generate()
    End Sub

    Private Sub Generate()
        Dim urut As Integer
        Using dt = SelectCon.execute("SELECT KODE FROM EKSPEDISI WHERE KODE LIKE '%EKS%' ORDER BY KODE DESC")
            If dt.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Mid(dt.Rows(0).Item(0), 5, 3) + 1
            End If
        End Using
        TxtKode.Text = "EKS" & Format(urut, "000")
    End Sub

    Private Sub InputGudang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Name = "InputEkspedisi"
        Text = "Input Ekspedisi"
        Generate()
        _Toolbar1_Button4.Visible = False
        CekStatusAktif.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
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

        SQl = "INSERT INTO EKSPEDISI VALUES ('" & TxtKode.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtTelp.Text & "','" & TxtPenanggungJawab.Text & "','" & UserID & "','" & Format(Now, "MM/dd/yyyy HH:mm:ss") & "',null,null,1)"

        If con.exec(SQl) Then
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

Public Class EditEkspedisi
    Inherits FrmEkspedisi

    Private Sub GetData()
        LoadData.GetData("SELECT NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,STATUS_AKTIF FROM EKSPEDISI WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtAlamat, TxtTelp, TxtPenanggungJawab, CekStatusAktif})
    End Sub

    Private Sub EditGudang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Name = "EditEkspedisi"
        Text = "Edit Ekdpedisi"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtKode.EditValueChanged, AddressOf GetData
        HakForm("", "Master", "Ekspedisi", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE EKSPEDISI SET NAMA='" & Replace(TxtNama.Text, "'", "`") & "',ALAMAT='" & Replace(TxtAlamat.Text, "'", "`") & "',PENANGGUNG_JAWAB='" & Replace(TxtPenanggungJawab.Text, "'", "`") & "',TELP='" & TxtTelp.Text & "',MDUSER='" & UserID & "',MDTIME='" & Format(Now, "MM/dd/yyyy HH:mm:ss") & "',STATUS_AKTIF='" & CekStatusAktif.CheckState & "' WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
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

        SQl = "DELETE FROM EKSPEDISI WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
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