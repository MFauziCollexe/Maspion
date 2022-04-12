Imports System.IO

Public Class FrmReleaseInfo

    Private Sub FrmReleaseInfo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label4.Text = "Proses Update Berhasil Dengan Sempurna. Software Anda Telah Diperbarui ke Versi " & My.Application.Info.Version.ToString
        If File.Exists(My.Application.Info.DirectoryPath & "\Release.txt") Then
            MemoEdit1.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Release.txt")
            Try : File.Delete(My.Application.Info.DirectoryPath & "\Release.txt") : Catch : End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class