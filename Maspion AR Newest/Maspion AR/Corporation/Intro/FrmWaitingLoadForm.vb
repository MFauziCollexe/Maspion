Public Class FrmWaitingLoadForm

    Private Sub FrmWaitingLoadForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Application.DoEvents()
    End Sub
End Class