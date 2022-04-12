Public MustInherit Class FrmKodePerkiraan

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Dispose()
    End Sub

    Private Sub FrmDivisi_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'PARENT
    Private Sub TxtKodeParent_Click(sender As Object, e As System.EventArgs) Handles TxtKodeParent.Click
        TxtKodeParent.Text = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
    End Sub
    Private Sub TxtKodeParent_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodeParent.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & TxtKodeParent.Text & "'", {TxtNamaParent})
    End Sub
End Class


Public Class InputKodePerkiraan
    Inherits FrmKodePerkiraan

    Private Sub Batal()
        Clean(Me.FindForm)
        TxtKode.Focus()
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty({TxtKode, TxtNama, RdJenis}) Then Exit Sub

        If QuestionInput() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.InsertHeader({TxtKode, TxtNama, ToSyntax(CmbGroup.SelectedIndex + 1), RdJenis, TxtUrutan, TxtKodeParent, CekStatusAktif, ChkKasBank, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL")}, "AR_KODE_PERKIRAAN") = False Then Exit Sub
                SQLServer.EndTransaction()
                Batal()
            End Using
        End If
    End Sub

    Private Sub InputDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kode Perkiraan"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditKodePerkiraan
    Inherits FrmKodePerkiraan

    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kode Perkiraan"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        'HakForm("", "Master", "Divisi", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        Dim tempGrup As New DevExpress.XtraEditors.TextEdit
        LoadData.GetData("SELECT KODE_PERKIRAAN, NAMA_PERKIRAAN, GRUP, JENIS, URUTAN, PARENT, STATUS_AKTIF, KAS_BANK FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & TxtKode.Text & "'")
        LoadData.SetData({TxtKode, TxtNama, tempGrup, RdJenis, TxtUrutan, TxtKodeParent, CekStatusAktif, ChkKasBank})
        CmbGroup.SelectedIndex = tempGrup.EditValue - 1
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty({TxtKode, TxtNama, RdJenis}) Then Exit Sub

        If QuestionEdit() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.UpdateHeader("KODE_PERKIRAAN, NAMA_PERKIRAAN, GRUP, JENIS, URUTAN, PARENT, STATUS_AKTIF, KAS_BANK, MDUSER, MDTIME", {TxtKode, TxtNama, ToSyntax(CmbGroup.SelectedIndex + 1), RdJenis, TxtUrutan, TxtKodeParent, CekStatusAktif, ChkKasBank, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "AR_KODE_PERKIRAAN", "KODE_PERKIRAAN='" & TxtKode.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.Click
        If QuestionHapus() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.Delete("AR_KODE_PERKIRAAN", "KODE_PERKIRAAN='" & TxtKode.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub
End Class