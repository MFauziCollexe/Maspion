Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class CetakanBuktiPengembalianCustomer_Menyamping
    Private Sub XrLabel18_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel18.PrintOnPage
        XrLabel18.Text = Terbilang(Math.Round(CDbl(XrTableCell14.Text), 2))
    End Sub

    Private Sub XrTableCell14_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell14.BeforePrint

    End Sub

    Private Sub XrTableCell14_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell14.PrintOnPage
        XrLabel18.Text = Terbilang(Math.Round(CDbl(XrTableCell14.Text), 2))
    End Sub
End Class