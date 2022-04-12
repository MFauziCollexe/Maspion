Public Class FrmPostingPeriode 

    Private Sub BtnProses_Click(sender As System.Object, e As System.EventArgs) Handles BtnProses.Click
        SplashScreenManager1.ShowWaitForm()
        SelectCon.execute("PROC_POSTING_STOK " & Format(DtTanggalAwal.Value, "MM") & "," & Format(DtTanggalAwal.Value, "yyyy") & "," & IIf(TxtDivisi.Text = "", "DEFAULT", "'" & TxtDivisi.Text & "'") & "," & IIf(TxtIDBarang.Text = "", "DEFAULT", "'" & TxtIDBarang.Text & "'") & "," & IIf(TxtKodeGudang.Text = "", "DEFAULT", "'" & TxtKodeGudang.Text & "'"))
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FrmPostingPeriode_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
    End Sub

    Private Sub TxtDivisi_Click(sender As Object, e As System.EventArgs) Handles TxtDivisi.Click
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub txtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub TxtIDBarang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDBarang.EditValueChanged
        SetData("SELECT KODE,NAMA FROM BARANG WHERE ID='" & TxtIDBarang.Text & "'", {TxtKodeBarang, TxtNamaBarang})
    End Sub

    Private Sub TxtKodeBarang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeBarang.ButtonClick
        TxtIDBarang.Text = Search(FrmPencarian.KeyPencarian.Barang_Divisi, , , , , "%%")
    End Sub

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged
        If RadioGroup1.SelectedIndex = 0 Then
            GroupControl1.Enabled = False
            TxtIDBarang.Text = ""
            TxtKodeGudang.Text = ""
            TxtDivisi.Text = ""
        ElseIf RadioGroup1.SelectedIndex = 1 Then
            GroupControl1.Enabled = True
        End If
    End Sub
End Class