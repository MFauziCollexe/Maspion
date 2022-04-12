Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Configuration
Imports DevExpress.XtraReports.Design

Public Class CetakanLaporanJurnalAR
    Dim indexsebelumnya As Integer = -1
    Dim subtotalsebelumnyad As Double = 0
    Dim subtotalsebelumnyak As Double = 0
    Dim statusgf As Boolean = True

    Private Sub GroupFooter2_BeforePrint(sender As Object, e As PrintEventArgs) Handles GroupFooter2.BeforePrint
        Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(sender, DevExpress.XtraReports.UI.GroupFooterBand)

        If gf.Visible = True Then
            statusgf = True
        Else
            statusgf = False
        End If
    End Sub

    Private Sub XrLabel7_BeforePrint(sender As Object, e As PrintEventArgs)



        'If GroupFooter2.Visible = True Then
        '    PageFooter.Visible = False
        'Else
        '    PageFooter.Visible = True
        'End If
    End Sub

    Private Sub XrLabel7_PreviewClick(sender As Object, e As PreviewMouseEventArgs)

    End Sub

    Private Sub XrLabel7_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        indexsebelumnya = e.PageIndex

    End Sub

    Private Sub XrTableCell20_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell20.BeforePrint

        'If XrTableCell20.Text = "" Then
        '    XrTable4.Visible = False
        'Else
        '    XrTable4.Visible = True
        'End If
    End Sub

    Private Sub XrTableCell20_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell20.PrintOnPage
        If e.PageIndex > indexsebelumnya And indexsebelumnya <> -1 Then
            DebetH.Expression = subtotalsebelumnyad
            KreditH.Expression = subtotalsebelumnyak
        End If
        If XrTableCell20.Text = "0,00" Then XrTableCell20.Text = ""
    End Sub

    Private Sub PageFooter_BeforePrint(sender As Object, e As PrintEventArgs)
        Dim pf As DevExpress.XtraReports.UI.PageFooterBand = CType(sender, DevExpress.XtraReports.UI.PageFooterBand)

        'If statusgf = True Then
        '    XrTableCell20.Text = ""
        '    XrTableCell21.Text = ""
        '    XrTableCell16.Text = ""
        '    XrTable4.Borders = DevExpress.XtraPrinting.BorderSide.None
        'Else
        '    pf.Visible = True
        'End If
    End Sub

    Private Sub XrLabel10_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel10.BeforePrint
        If XrLabel10.Text <> "" Then
            DebetH.Expression = subtotalsebelumnyad
            KreditH.Expression = subtotalsebelumnyak
            XrTableCell20.Text = subtotalsebelumnyad
            XrTableCell21.Text = subtotalsebelumnyak
            '    Dim report As New CetakanLaporanJurnalAR()
            '    report.FindControl("xrtablecell20", True).DataBindings.Add(
            'New DataBinding(XrTableCell20, DebetH, "", ""))

        End If
    End Sub

    Private Sub XrTableCell10_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell10.PrintOnPage
        'If XrTableCell10.Text = XrLabel10.Text And XrTableCell11.Text = XrLabel12.Text Then
        '    XrLabel12.Visible = False
        '    XrLabel10.Visible = False
        '    XrLabel11.Visible = False
        'Else
        '    XrLabel12.Visible = True
        '    XrLabel10.Visible = True
        '    XrLabel11.Visible = True
        'End If
        If XrTableCell10.Text = "0,00" Then XrTableCell10.Text = ""
    End Sub

    Private Sub XrTableCell7_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell7.PrintOnPage
        CalculatedField3.Expression = e.PageIndex
        If XrTableCell7.Text = "0,00" Then XrTableCell7.Text = ""
    End Sub

    Private Sub XrPageInfo2_TextChanged(sender As Object, e As EventArgs) Handles XrPageInfo2.TextChanged
    End Sub

    Private Sub CalculatedField3_GetValue(sender As Object, e As GetValueEventArgs) Handles CalculatedField3.GetValue

    End Sub

    Private Sub GroupFooter2_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles GroupFooter2.PrintOnPage
        'Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(GroupFooter1, DevExpress.XtraReports.UI.GroupFooterBand)
        'If GroupFooter2.Visible = True Then
        '    gf.Visible = False
        'Else
        '    gf.Visible = True
        'End If
    End Sub

    Private Sub GroupFooter2_AfterPrint(sender As Object, e As EventArgs) Handles GroupFooter2.AfterPrint
        'Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(GroupFooter1, DevExpress.XtraReports.UI.GroupFooterBand)
        'If GroupFooter2.Visible = True Then
        '    gf.Visible = False
        'Else
        '    gf.Visible = True
        'End If
    End Sub

    Private Sub XrPageInfo1_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)

    End Sub

    Private Sub XrTableCell21_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell21.PrintOnPage
        If XrTableCell21.Text = "0,00" Then XrTableCell21.Text = ""
    End Sub

    Private Sub XrTableCell8_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell8.PrintOnPage
        If XrTableCell8.Text = "0,00" Then XrTableCell8.Text = ""
    End Sub

    Private Sub XrTableCell12_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell12.PrintOnPage

    End Sub

    Private Sub XrTableCell11_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrTableCell11.PrintOnPage
        If XrTableCell11.Text = "0,00" Then XrTableCell11.Text = ""
    End Sub

    Private Sub XrLabel10_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel10.PrintOnPage
        If XrLabel10.Text = "0,00" Then XrLabel10.Text = ""
    End Sub

    Private Sub XrLabel12_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel12.PrintOnPage
        If XrLabel12.Text = "0,00" Then XrLabel12.Text = ""
    End Sub

    Private Sub XrSubreport1_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrSubreport1.BeforePrint
        Dim aa = GetCurrentColumnValue("PARAM_SR")
        XrSubreport1.ReportSource.Parameters.Item(0).Value = GetCurrentColumnValue("PARAM_SR")
    End Sub
End Class