Imports DevExpress.XtraCharts

Public Class LaporanPriceList
    Inherits FrmLaporanBase
    Friend WithEvents GBPilihan As System.Windows.Forms.GroupBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DtTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DtTglTerakhir As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit

    Private Sub InitializeComponent()
        Me.GBPilihan = New System.Windows.Forms.GroupBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.DtTglTerakhir = New DevExpress.XtraEditors.DateEdit()
        Me.DtTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.XtraScrollableControl1.SuspendLayout()
        Me.GBPilihan.SuspendLayout()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTglTerakhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTglTerakhir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.GBPilihan)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GBPilihan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        '
        'GBPilihan
        '
        Me.GBPilihan.Controls.Add(Me.RadioGroup1)
        Me.GBPilihan.Controls.Add(Me.LabelControl4)
        Me.GBPilihan.Controls.Add(Me.RDPenjualan)
        Me.GBPilihan.Controls.Add(Me.DtTglTerakhir)
        Me.GBPilihan.Controls.Add(Me.DtTanggal)
        Me.GBPilihan.Controls.Add(Me.LabelControl1)
        Me.GBPilihan.Controls.Add(Me.TxtNamaDivisi)
        Me.GBPilihan.Controls.Add(Me.TxtDivisi)
        Me.GBPilihan.Location = New System.Drawing.Point(22, 64)
        Me.GBPilihan.Name = "GBPilihan"
        Me.GBPilihan.Size = New System.Drawing.Size(343, 156)
        Me.GBPilihan.TabIndex = 111
        Me.GBPilihan.TabStop = False
        Me.GBPilihan.Text = "FIlter Berdasarkan"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 91)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 246
        Me.LabelControl4.Text = "Price List"
        '
        'RDPenjualan
        '
        Me.RDPenjualan.AutoSizeInLayoutControl = True
        Me.RDPenjualan.EditValue = ""
        Me.RDPenjualan.EnterMoveNextControl = True
        Me.RDPenjualan.Location = New System.Drawing.Point(103, 91)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Langganan", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket")})
        Me.RDPenjualan.Size = New System.Drawing.Size(212, 53)
        Me.RDPenjualan.TabIndex = 245
        '
        'DtTglTerakhir
        '
        Me.DtTglTerakhir.EditValue = Nothing
        Me.DtTglTerakhir.Location = New System.Drawing.Point(146, 69)
        Me.DtTglTerakhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTglTerakhir.Name = "DtTglTerakhir"
        Me.DtTglTerakhir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTglTerakhir.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTglTerakhir.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.DtTglTerakhir.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.DtTglTerakhir.Size = New System.Drawing.Size(164, 20)
        Me.DtTglTerakhir.TabIndex = 144
        '
        'DtTanggal
        '
        Me.DtTanggal.EditValue = Nothing
        Me.DtTanggal.Location = New System.Drawing.Point(146, 47)
        Me.DtTanggal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggal.Name = "DtTanggal"
        Me.DtTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggal.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.DtTanggal.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.DtTanggal.Size = New System.Drawing.Size(164, 20)
        Me.DtTanggal.TabIndex = 142
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 26)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 141
        Me.LabelControl1.Text = "Divisi"
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.Enabled = False
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(220, 23)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaDivisi.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtNamaDivisi.TabIndex = 140
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(146, 23)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtDivisi.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(72, 20)
        Me.TxtDivisi.TabIndex = 139
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(22, 226)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(343, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(16, 47)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Tanggal Input"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Per Tanggal Terakhir")})
        Me.RadioGroup1.Size = New System.Drawing.Size(131, 42)
        Me.RadioGroup1.TabIndex = 245
        '
        'LaporanPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanPriceList"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.GBPilihan.ResumeLayout(False)
        Me.GBPilihan.PerformLayout()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTglTerakhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTglTerakhir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRPriceListvb

        Report = MyReport
        If RadioGroup1.SelectedIndex = 0 Then
            Report.DataSource = SelectCon.execute("SELECT B.KODE,B.NAMA,A.ID_BARANG,A.JENIS,HARGA_BARU,CASE A.JENIS WHEN 'Langganan' THEN B.SAT_DIST1 WHEN 'Supermarket' THEN B.SAT_SUPER1 END AS SATUAN,QTY_KOLI,D.NAMA,A.TGL_PRICE FROM VI_PRICE_LIST A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN LINK_BARANG_DIVISI C ON B.ID=C.ID_BARANG LEFT JOIN DIVISI D ON C.KODE_DIVISI=D.KODE WHERE B.STATUS_AKTIF=1 " & IIf(TxtDivisi.Text = "", "", " AND D.KODE='" & TxtDivisi.Text & "' ") & IIf(DtTanggal.Text = "", "", " AND CONVERT(DATE,A.TGL_PRICE,103) = CONVERT(DATE,'" & DtTanggal.DateTime & "',103) ") & IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.JENIS LIKE '%" & RDPenjualan.EditValue & "%' "))
        Else
            Report.DataSource = SelectCon.execute("SELECT URUTAN,B.KODE,B.NAMA,A.ID_BARANG,A.JENIS,HARGA_BARU,CASE A.JENIS WHEN 'Langganan' THEN B.SAT_DIST1 WHEN 'Supermarket' THEN B.SAT_SUPER1 END AS SATUAN,QTY_KOLI,D.NAMA,A.TGL_PRICE FROM (SELECT ID_BARANG,TGL_PRICE,JENIS,HARGA_BARU,ROW_NUMBER() OVER(PARTITION BY ID_BARANG ORDER BY TGL_PRICE DESC) AS URUTAN FROM VI_PRICE_LIST WHERE CONVERT(DATE,TGL_PRICE,103) <= CONVERT(DATE,'" & DtTglTerakhir.DateTime & "',103)) A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN LINK_BARANG_DIVISI C ON B.ID=C.ID_BARANG LEFT JOIN DIVISI D ON C.KODE_DIVISI=D.KODE WHERE A.URUTAN=1 AND B.STATUS_AKTIF=1 " & IIf(TxtDivisi.Text = "", "", " AND D.KODE='" & TxtDivisi.Text & "' ") & IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.JENIS LIKE '%" & RDPenjualan.EditValue & "%' ") & " ORDER BY TGL_PRICE")
        End If

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report

        'ChartControl1.DataSource = Report.DataSource
        'ChartControl1.SeriesDataMember = "DIVISI1"
        'ChartControl1.SeriesTemplate.ArgumentDataMember = "TGL_PENGAKUAN"
        'ChartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() {"SUBTOTAL"})
        'ChartControl1.SeriesTemplate.View = New SideBySideBarSeriesView
        'ChartControl1.SeriesNameTemplate.BeginText = "DIVISI : "
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Price List"
        DtTanggal.DateTime = Now
        DtTglTerakhir.DateTime = Now
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        RadioGroup1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub TxtDivisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged
        If RadioGroup1.SelectedIndex = 0 Then
            DtTanggal.Enabled = True
            DtTglTerakhir.Enabled = False
        Else
            DtTanggal.Enabled = False
            DtTglTerakhir.Enabled = True
        End If
    End Sub
End Class
