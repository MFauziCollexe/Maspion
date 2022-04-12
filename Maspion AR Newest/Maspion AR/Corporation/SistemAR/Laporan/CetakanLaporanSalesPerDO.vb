Imports DevExpress.XtraReports.UI

Public Class CetakanLaporanSalesPerDO
    Private Sub XrLabel25_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel25.PrintOnPage
        If XrLabel25.Text = "0,00" Then XrLabel25.Text = ""
    End Sub

    Private Sub XrTableCell11_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell11.PrintOnPage
        If XrTableCell11.Text = "0,00" Then XrTableCell11.Text = ""
    End Sub

    Private Sub XrTableCell13_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell13.PrintOnPage
        If XrTableCell13.Text = "0,00" Then XrTableCell13.Text = ""
    End Sub
End Class