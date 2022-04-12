Public Class FrmPromo
    Private Sub Generate()
        TxtKode.Text = ""
        'Dim urut As Integer
        'Using dtGenerate = SelectCon.execute("SELECT MAX(KODE) FROM GROUP_BARANG WHERE KODE LIKE '%GB%'")
        '    If dtGenerate.Rows.Count = 0 Or IsDBNull(dtGenerate.Rows(0).Item(0)) Then
        '        urut = 1
        '    Else
        '        urut = Mid(dtGenerate.Rows(0).Item(0), 3, 3) + 1
        '    End If
        '    TxtKode.Text = "GB" & Format(urut, "000")
        'End Using
    End Sub

    Private Sub BtnTambah_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambah.Click
        If GBInput.Visible Then
            GBInput.Enabled = False
            GBInput.Visible = False
            TxtNama.Text = ""
            TxtKode.Enabled = True
        Else
            Generate()
            GBInput.Enabled = True
            GBInput.Visible = True
            GBInput.Text = "Input Promo"
            TxtNama.Text = ""
            TxtKode.Enabled = True
            BtnTambah.Enabled = False
            BtnEdit.Enabled = False
            BtnHapus.Enabled = False
        End If
    End Sub

    Private Sub FrmPromo_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not GBInput.Visible Then
            Call BtnBatal_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmSatuan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TBSatuan.DataSource = SelectCon.execute("SELECT KODE,NAMA_PROMO FROM PROMO")
        GBInput.Enabled = False
        GBInput.Visible = False
    End Sub

    Private Sub BtnBatal_Click(sender As System.Object, e As System.EventArgs) Handles BtnBatal.Click
        GBInput.Enabled = False
        GBInput.Visible = False
        TxtNama.Text = ""
        BtnTambah.Enabled = True
        BtnEdit.Enabled = True
        BtnHapus.Enabled = True
    End Sub

    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If GBInput.Text = "Input Promo" Then
            For i = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, GridView1.Columns(0)) = TxtKode.Text Then
                    MsgBox("Promo sudah ada !!!")
                    Exit Sub
                End If
            Next

            If MessageBox.Show("Apakah anda yakin ingin menyimpan data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                con.begin_exec()
                If con.exec("INSERT INTO PROMO VALUES ('" & TxtKode.Text & "','" & TxtNama.Text & "','" & UserID & "',CURRENT_TIMESTAMP,NULL,NULL)") = False Then GoTo Keluar
                con.end_exec(True)

                MessageBox.Show("Data Baru telah disimpan..!!", _
                               "Penyimpanan Sukses", _
                               MessageBoxButtons.OK, _
                               MessageBoxIcon.Information)
                TBSatuan.DataSource = SelectCon.execute("SELECT KODE,NAMA_PROMO FROM PROMO")
                BtnBatal_Click(sender, e)
            End If
        ElseIf GBInput.Text = "Edit Promo" Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                con.begin_exec()
                If con.exec("UPDATE PROMO SET NAMA_PROMO='" & TxtNama.Text & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo Keluar
                con.end_exec(True)

                MessageBox.Show("Data telah dirubah..!!", _
                               "Penyimpanan Sukses", _
                               MessageBoxButtons.OK, _
                               MessageBoxIcon.Information)
                TBSatuan.DataSource = SelectCon.execute("SELECT KODE,NAMA_PROMO FROM PROMO")
                BtnBatal_Click(sender, e)
            End If
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
        If MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            con.begin_exec()
            If con.exec("DELETE FROM PROMO WHERE KODE='" & GridView1.GetFocusedRow(0) & "'") = False Then GoTo Keluar
            con.end_exec(True)

            MessageBox.Show("Data Berhasil Dihapus..!!", _
                           "Penghapusan Sukses", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Information)
            TBSatuan.DataSource = SelectCon.execute("SELECT KODE,NAMA_PROMO FROM PROMO")
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal terhapus..!!", _
                        "Penghapusan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        GBInput.Text = "Edit Promo"
        GBInput.Enabled = True
        GBInput.Visible = True
        If GridView1.RowCount > 0 Then
            TxtKode.Text = GridView1.GetFocusedRow(0)
            TxtNama.Text = GridView1.GetFocusedRow(1)
        End If
        TxtKode.Enabled = False
        BtnEdit.Enabled = False
        BtnTambah.Enabled = False
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GBInput.Text = "Edit Promo" Then
            GBInput.Enabled = False
            GBInput.Visible = False
            TxtKode.Enabled = False
            TxtKode.Text = ""
            TxtNama.Text = ""
        End If
    End Sub
End Class