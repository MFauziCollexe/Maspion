Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class CetakanKartuRetur
    Private Sub XrTableCell17_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell17.BeforePrint

    End Sub

    Private Sub XrTableCell17_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell17.PrintOnPage
        If XrTableCell17.Text = "0,00" Then XrTableCell17.Text = Nothing
    End Sub
End Class