Public Class FrmJabatan
    Private Sub BtnTambah_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambah.Click
        If GBInput.Visible Then
            GBInput.Enabled = False
            GBInput.Visible = False
            TxtNama.Text = ""
            BtnHapus.Location = New System.Drawing.Point(228, 61)
            BtnHapus.Enabled = True
        Else
            GBInput.Enabled = True
            GBInput.Visible = True
            TxtNama.Text = ""
            TxtNama.Focus()
            BtnHapus.Location = New System.Drawing.Point(228, 145)
            BtnHapus.Enabled = False
        End If
    End Sub

    Private Sub FrmSatuan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TBSatuan.DataSource = SelectCon.execute("SELECT * FROM JABATAN")
        GBInput.Enabled = False
        GBInput.Visible = False
        BtnHapus.Location = New System.Drawing.Point(228, 61)
        BtnHapus.Enabled = True
    End Sub

    Private Sub BtnBatal_Click(sender As System.Object, e As System.EventArgs) Handles BtnBatal.Click
        GBInput.Enabled = False
        GBInput.Visible = False
        TxtNama.Text = ""
        BtnHapus.Location = New System.Drawing.Point(228, 61)
        BtnHapus.Enabled = True
    End Sub

    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click
        If Empty(TxtNama) Then Exit Sub
        For i = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(i, GridView1.Columns(0)) = TxtNama.Text Then
                MsgBox("Satuan sudah ada !!!")
                Exit Sub
            End If
        Next

        If MessageBox.Show("Apakah anda yakin ingin menyimpan data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            con.begin_exec()
            If con.exec("INSERT INTO JABATAN VALUES ('" & TxtNama.Text & "')") = False Then GoTo Keluar
            con.end_exec(True)

            MessageBox.Show("Data Baru telah disimpan..!!", _
                           "Penyimpanan Sukses", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Information)
            TBSatuan.DataSource = SelectCon.execute("SELECT * FROM JABATAN")
            BtnBatal_Click(sender, e)
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                        "Penyimpanan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub BtnHapus_Click(sender As System.Object, e As System.EventArgs) Handles BtnHapus.Click
        If MessageBox.Show("Apakah anda yakin ingin menghapus data " & GridView1.GetFocusedRow(0) & " ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            con.begin_exec()
            If con.exec("DELETE FROM JABATAN WHERE NAMA='" & GridView1.GetFocusedRow(0) & "'") = False Then GoTo Keluar
            con.end_exec(True)

            MessageBox.Show("Data Berhasil Dihapus..!!", _
                           "Penghapusan Sukses", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Information)
            TBSatuan.DataSource = SelectCon.execute("SELECT * FROM JABATAN")
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal terhapus..!!", _
                        "Penghapusan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub
End Class