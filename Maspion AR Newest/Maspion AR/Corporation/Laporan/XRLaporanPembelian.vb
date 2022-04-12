Public Class XRLaporanPembelian

    Function LastBreak(sender As Object, field As String) As Boolean
        Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(sender, DevExpress.XtraReports.UI.GroupFooterBand)
        gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        Dim browser As DevExpress.Data.Browsing.DataBrowser = Me.fDataContext(Me.DataSource, Me.DataMember)
        Try
            Dim groupValue As Object = browser.FindItemProperty(field, True).GetValue(browser.Current)
            browser.Position += 1
            Try
                If browser.HasLastPosition Then
                    'e.Cancel = true;
                    'gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Return True
                End If
                Dim nextValue As Object = browser.FindItemProperty(field, True).GetValue(browser.Current)
                If groupValue.ToString() <> nextValue.ToString() Then
                    'gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Return True
                End If
            Finally
                browser.Position -= 1
            End Try
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Sub GroupFooter1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
        Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(sender, DevExpress.XtraReports.UI.GroupFooterBand)
        If GetNextColumnValue("NAMA_DIVISI") <> GetCurrentColumnValue("NAMA_DIVISI") Then
            'gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        Else
            gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            If LastBreak(sender, "NAMA_DIVISI") Then
                gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
            End If
        End If
    End Sub
End Class