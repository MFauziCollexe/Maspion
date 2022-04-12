Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Links
Imports DevExpress.XtraPrintingLinks
Imports System.Drawing.Printing

Public Class FrmMonitoringStok
    Private dt As DataTable

    Private Sub FrmMonitoringStok_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        dt = SelectCon.execute("SELECT DISTINCT B.ID,F.NAMA_GUDANG,B.KODE,B.NAMA,B.NAMA_ALIAS1,E.NAMA AS GRUP,D.NAMA AS DIVISI,FLOOR(A.STOK_PCS/(B.QTY_DIST*B.QTY_KOLI)) AS KOLI,ROUND(A.STOK_PCS, 0, 1) STOK_PCS,FLOOR(ISNULL(STF.Jumlah,0)/(B.QTY_DIST*B.QTY_KOLI)) KOLI_STUFFING,ISNULL(STF.Jumlah,0) PCS_STUFFING, FLOOR(ISNULL(DO.Jumlah,0)/(B.QTY_DIST*B.QTY_KOLI)) KOLI_DO_OUTS,ISNULL(DO.Jumlah,0) DO_OUTS,FLOOR((A.STOK_PCS-ISNULL(DO.Jumlah,0)-ISNULL(STF.Jumlah,0))/(B.QTY_DIST*B.QTY_KOLI)) KOLI_STOK_MARKETING,ROUND(A.STOK_PCS, 0, 1)-ISNULL(DO.Jumlah,0)-ISNULL(STF.Jumlah,0) STOK_MARKETING,A.SAT_SUPER1 FROM V_STOK_BERJALAN A LEFT JOIN (BARANG B INNER JOIN LINK_BARANG_DIVISI C ON B.ID=C.ID_BARANG LEFT JOIN DIVISI D ON C.KODE_DIVISI=D.KODE) ON A.ID_BARANG=B.ID LEFT JOIN (SELECT DO.GUDANG,DT.ID_BARANG,SUM(DT.PCS-DT.PCS_T) Jumlah, SUM(DT.PCS_T) Stuffing FROM DELIVERY_ORDER DO JOIN V_D_DB_PERW_T_STUFF DT ON DO.ID_TRANSAKSI=DT.ID_TRANSAKSI AND DO.BATAL=0 WHERE DO.GUDANG IS NOT NULL AND DO.ID_TRANSAKSI NOT IN (SELECT ID_TRANSAKSI FROM CLOSING_TRANSAKSI) GROUP BY DO.GUDANG,DT.ID_BARANG) DO ON DO.ID_BARANG=A.ID_BARANG AND A.GUDANG=DO.GUDANG LEFT JOIN (SELECT STF.GUDANG,STFT.ID_BARANG,SUM(STFT.PCS-STFT.PCS_T) Jumlah FROM STUFFING STF JOIN V_D_STUFF_T_NOTA STFT ON STF.ID_TRANSAKSI=STFT.ID_TRANSAKSI AND STF.BATAL=0 WHERE STF.GUDANG IS NOT NULL AND STF.ID_TRANSAKSI NOT IN (SELECT ID_TRANSAKSI FROM CLOSING_TRANSAKSI) GROUP BY STF.GUDANG,STFT.ID_BARANG) STF ON STF.ID_BARANG=A.ID_BARANG AND STF.GUDANG=DO.GUDANG LEFT JOIN GROUP_BARANG E ON B.GROUP_BARANG=E.KODE LEFT JOIN GUDANG F ON A.GUDANG=F.KODE LEFT JOIN LINK_USER_DIVISI G ON C.KODE_DIVISI=G.KODE_DIVISI LEFT JOIN LINK_USER_GUDANG H ON A.GUDANG=H.KODE_GUDANG WHERE G.ID_USER='" & UserID & "' AND H.ID_USER='" & UserID & "' ORDER BY KODE")
        TBMonStok.DataSource = dt
        TBMonStok.RefreshDataSource()
        TBMonStok.Refresh()
        BandedGridView1.BestFitColumns()
        Frame1.Text = "[ " & BandedGridView1.DataRowCount & " Data Stok ]"
    End Sub

    Private Sub MenuKaryawan_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button9.PerformClick()
            Case 65
                txtCari.Focus()
        End Select
    End Sub

    Private Sub _Toolbar1_Button9_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button9.Click
        Me.Dispose()
    End Sub

    Private Sub txtCari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCari.EditValueChanged
        'Dim dtcari As DataTable = dt.Clone
        'Dim rows() As DataRow = dt.Select(SmartSearch(txtCari.Text, " ISNULL(ID_BARANG,'')+ISNULL(KODE,'')+ISNULL(KODE_PABRIK,'')+ISNULL(NAMA,'')+ISNULL(NAMA_ALIAS1,'')+ISNULL(GRUP,'')+ISNULL(DIVISI,'') "))
        'dtcari = rows.CopyToDataTable

        'TBMonStok.DataSource = dtcari
        BandedGridView1.FindFilterText = txtCari.Text
        Frame1.Text = "[ " & BandedGridView1.DataRowCount & " Data Stok ]"
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        PreviewPrintableComponent(TBMonStok, TBMonStok.LookAndFeel)
        'BandedGridView1.ShowPrintPreview()
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        ' Create a link that will print a control.     
        Dim link As New PrintableComponentLink() With { _
           .PrintingSystemBase = New PrintingSystem(), _
           .Component = component, _
           .Landscape = True, _
           .PaperKind = PaperKind.A4, _
           .Margins = New Margins(20, 20, 20, 20) _
       }
        ' Subscribe to the CreateReportHeaderArea event used to generate the report header. 
        AddHandler link.CreateReportHeaderArea, AddressOf link_CreateReportHeaderArea
        ' Show the report. 
        link.ShowRibbonPreview(lookAndFeel)
    End Sub

    Private Sub link_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim reportHeader As String = "Stok Per Tanggal " & Format(Now, "dd/MM/yyyy HH:mm:ss")
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
    End Sub

    Private Sub FrmMonitoringStok_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'PreviewPrintableComponent(TBMonStok, Me.LookAndFeel)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        FrmMonitoringStok_Activated(Nothing, Nothing)
    End Sub
End Class
