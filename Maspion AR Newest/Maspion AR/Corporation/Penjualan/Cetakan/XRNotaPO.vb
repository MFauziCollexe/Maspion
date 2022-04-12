Public Class XRNotaPO

    Private Sub XrLabel66_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabel66.PrintOnPage
        XrLabel66.Text = Module1.Terbilang((CDbl(GetCurrentColumnValue("DPP")) + CDbl(GetCurrentColumnValue("PPN"))))
    End Sub
End Class