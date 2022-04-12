Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraCharts

Public Class FrmLaporanBase
    Protected Report As XtraReport
    Private frm As New ReportPreview

    Protected WriteOnly Property Nama
        Set(value)
            LblTitle.Text = value
            Me.Text = value
            Me.Name = value
        End Set
    End Property

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        frm.Report = Report

        frm.ShowDialog()
    End Sub

    Private Sub _Toolbar1_Button2_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button2.Click
        Me.Dispose()
        frm.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        ChartControl1.ShowRibbonPrintPreview()
    End Sub

    Private Sub SplitContainerControl1_SplitterMoved(sender As Object, e As System.EventArgs) Handles SplitContainerControl1.SplitterMoved
        DocumentViewer1.SetPageView(DevExpress.XtraPrinting.PageViewModes.PageWidth)
    End Sub

    Private Sub Laporan_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
        End Select
    End Sub
End Class