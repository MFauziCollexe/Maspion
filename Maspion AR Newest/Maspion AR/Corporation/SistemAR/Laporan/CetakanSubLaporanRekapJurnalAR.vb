Imports DevExpress.XtraReports.UI

Public Class CetakanSubLaporanRekapJurnalAR
    Private Sub XrTableCell10_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell10.PrintOnPage
        If XrTableCell10.Text = "0,00" Then XrTableCell10.Text = ""
    End Sub

    Private Sub XrTableCell11_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell11.PrintOnPage
        If XrTableCell11.Text = "0,00" Then XrTableCell11.Text = ""
    End Sub

    Private Sub XrTableCell7_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell7.PrintOnPage
        If XrTableCell7.Text = "0,00" Then XrTableCell7.Text = ""
    End Sub

    Private Sub XrTableCell8_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell8.PrintOnPage
        If XrTableCell8.Text = "0,00" Then XrTableCell8.Text = ""
    End Sub
End Class