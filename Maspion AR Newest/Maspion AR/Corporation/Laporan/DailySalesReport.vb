Imports DevExpress.XtraCharts

Public Class DailySalesReport
    Inherits FrmLaporanBase
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents GBPilihan As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RdPembayaran As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDJenisPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DtTanggalAwal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DtTanggalAkhir As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TBDivisi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbKodePromo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TBDivisi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.RdPembayaran = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.RDJenisPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.DtTanggalAwal = New DevExpress.XtraEditors.DateEdit()
        Me.DtTanggalAkhir = New DevExpress.XtraEditors.DateEdit()
        Me.GBPilihan = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbKodePromo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPilihan.SuspendLayout()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.Add(Me.GBPilihan)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GBPilihan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tanggal :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(160, 284)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(154, 20)
        Me.TxtNamaGudang.TabIndex = 247
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(8, 287)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 246
        Me.LabelControl2.Text = "Gudang"
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(97, 284)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(61, 20)
        Me.TxtKodeGudang.TabIndex = 245
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(97, 330)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(217, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(97, 20)
        Me.TBDivisi.MainView = Me.GridView1
        Me.TBDivisi.Name = "TBDivisi"
        Me.TBDivisi.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RBEdit})
        Me.TBDivisi.Size = New System.Drawing.Size(217, 130)
        Me.TBDivisi.TabIndex = 142
        Me.TBDivisi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.GridControl = Me.TBDivisi
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'RBEdit
        '
        Me.RBEdit.AutoHeight = False
        Me.RBEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RBEdit.Name = "RBEdit"
        Me.RBEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 20)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 141
        Me.LabelControl1.Text = "Divisi"
        '
        'RdPembayaran
        '
        Me.RdPembayaran.AutoSizeInLayoutControl = True
        Me.RdPembayaran.EditValue = "Semua"
        Me.RdPembayaran.EnterMoveNextControl = True
        Me.RdPembayaran.Location = New System.Drawing.Point(97, 257)
        Me.RdPembayaran.Margin = New System.Windows.Forms.Padding(1)
        Me.RdPembayaran.Name = "RdPembayaran"
        Me.RdPembayaran.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kontan", "Kontan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kredit", "Kredit")})
        Me.RdPembayaran.Size = New System.Drawing.Size(217, 25)
        Me.RdPembayaran.TabIndex = 118
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(8, 154)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 118
        Me.LabelControl3.Text = "Jenis Penjualan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(8, 202)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl6.TabIndex = 121
        Me.LabelControl6.Text = "Penjualan"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(8, 263)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl5.TabIndex = 119
        Me.LabelControl5.Text = "Jenis Pembayaran"
        '
        'RDJenisPenjualan
        '
        Me.RDJenisPenjualan.AutoSizeInLayoutControl = True
        Me.RDJenisPenjualan.EditValue = "Semua"
        Me.RDJenisPenjualan.EnterMoveNextControl = True
        Me.RDJenisPenjualan.Location = New System.Drawing.Point(97, 154)
        Me.RDJenisPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisPenjualan.Name = "RDJenisPenjualan"
        Me.RDJenisPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Perwakilan", "Perwakilan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Pusat", "Pusat")})
        Me.RDJenisPenjualan.Size = New System.Drawing.Size(217, 46)
        Me.RDJenisPenjualan.TabIndex = 120
        '
        'RDPenjualan
        '
        Me.RDPenjualan.AutoSizeInLayoutControl = True
        Me.RDPenjualan.EditValue = "Semua"
        Me.RDPenjualan.EnterMoveNextControl = True
        Me.RDPenjualan.Location = New System.Drawing.Point(97, 202)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Langganan", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Lain", "Lain - Lain")})
        Me.RDPenjualan.Size = New System.Drawing.Size(217, 53)
        Me.RDPenjualan.TabIndex = 117
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtTanggalAwal.Location = New System.Drawing.Point(93, 58)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAwal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAwal.Properties.EditValueChangedDelay = 3
        Me.DtTanggalAwal.Size = New System.Drawing.Size(105, 20)
        Me.DtTanggalAwal.TabIndex = 112
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(216, 59)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAkhir.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAkhir.Properties.EditValueChangedDelay = 3
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(105, 20)
        Me.DtTanggalAkhir.TabIndex = 113
        '
        'GBPilihan
        '
        Me.GBPilihan.Controls.Add(Me.Label6)
        Me.GBPilihan.Controls.Add(Me.CmbKodePromo)
        Me.GBPilihan.Controls.Add(Me.TxtNamaGudang)
        Me.GBPilihan.Controls.Add(Me.LabelControl2)
        Me.GBPilihan.Controls.Add(Me.TxtKodeGudang)
        Me.GBPilihan.Controls.Add(Me.BtnView)
        Me.GBPilihan.Controls.Add(Me.TBDivisi)
        Me.GBPilihan.Controls.Add(Me.LabelControl1)
        Me.GBPilihan.Controls.Add(Me.RdPembayaran)
        Me.GBPilihan.Controls.Add(Me.LabelControl3)
        Me.GBPilihan.Controls.Add(Me.LabelControl6)
        Me.GBPilihan.Controls.Add(Me.LabelControl5)
        Me.GBPilihan.Controls.Add(Me.RDJenisPenjualan)
        Me.GBPilihan.Controls.Add(Me.RDPenjualan)
        Me.GBPilihan.Location = New System.Drawing.Point(21, 96)
        Me.GBPilihan.Name = "GBPilihan"
        Me.GBPilihan.Size = New System.Drawing.Size(329, 369)
        Me.GBPilihan.TabIndex = 111
        Me.GBPilihan.TabStop = False
        Me.GBPilihan.Text = "FIlter Berdasarkan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 309)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Kode Promo"
        '
        'CmbKodePromo
        '
        Me.CmbKodePromo.Location = New System.Drawing.Point(97, 306)
        Me.CmbKodePromo.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbKodePromo.Name = "CmbKodePromo"
        Me.CmbKodePromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbKodePromo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbKodePromo.Size = New System.Drawing.Size(217, 20)
        Me.CmbKodePromo.TabIndex = 263
        '
        'DailySalesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "DailySalesReport"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPilihan.ResumeLayout(False)
        Me.GBPilihan.PerformLayout()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRDailySalesReport
        MyReport.lblTitle.Text = "DAILY SALES REPORT"
        Report = MyReport

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "NOTA.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Dim promo As String = ""
        If CmbKodePromo.SelectedItem IsNot "" Then
            promo = "AND DETAIL_NOTA.ID_BARANG IN (select ID_BARANG from LINK_BARANG_PROMO WHERE CONVERT(DATE,'" & DtTanggalAwal.DateTime & "',103) >= CONVERT(DATE,TGL_AWAL,103) AND CONVERT(DATE,'" & DtTanggalAkhir.DateTime & "',103) <= CONVERT(DATE,TGL_AKHIR,103) AND KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "')"
            MyReport.lblTitle.Text &= " " & CmbKodePromo.SelectedItem.ToString.Split("-")(1).Trim
        End If
        Report.DataSource = SelectCon.execute("SELECT * FROM ( SELECT DISTINCT NOTA.ID_TRANSAKSI, RIGHT(NOTA.NO_NOTA, 6) AS NO_NOTA, NOTA.NO_REF, NOTA.TGL, NOTA.TGL_PENGAKUAN, NOTA.ID_DO, RIGHT(NOTA.NO_DO, 6) AS NO_DO, NOTA.TGL_DO, NOTA.DIVISI, NOTA.JENIS_PPN, NOTA.KODE_CUSTOMER, NOTA.KODE_APPROVE, NOTA.CABANG, NOTA.ALAMAT_KIRIM, NOTA.GUDANG, NOTA.SJ_TANPA_HARGA, NOTA.KETERANGAN_CETAK, NOTA.KETERANGAN_INTERNAL, NOTA.SUBTOTAL, NOTA.DPP, NOTA.PPN, NOTA.PERIODE, NOTA.CRUSER, NOTA.CRTIME, NOTA.MDUSER, NOTA.MDTIME, NOTA.BATAL, NOTA.BAGIAN, NOTA.ID_STUFFING, NOTA.KODE_EKSPEDISI, NOTA.NO_TRUK, IIF(ISNULL(NOTA.PRINT_PKP,0)=1,CUSTOMER.NAMA_PKP,CUSTOMER.NAMA) AS NAMA, DIVISI.NAMA AS NAMA_DIVISI, DELIVERY_ORDER.NO_DO AS NO_DO1, DELIVERY_ORDER.PEMBAYARAN, NOTA.DISC_QTY, NOTA.DISC_QTY_NOMINAL, NOTA.DISC_REG, NOTA.DISC_REG_NOMINAL, NOTA.DISC_1, NOTA.DISC_1_NOMINAL, NOTA.DISC_2, NOTA.DISC_2_NOMINAL, NOTA.DISC_3, NOTA.CASH_DISC, NOTA.DISC_3_NOMINAL, NOTA.CASH_DISC_NOMINAL, NOTA.DISC_QTY1, NOTA.DISC_QTY_NOMINAL1, GUDANG.NAMA_GUDANG FROM NOTA JOIN DETAIL_NOTA ON NOTA.ID_TRANSAKSI=DETAIL_NOTA.ID_TRANSAKSI LEFT OUTER JOIN GUDANG ON NOTA.GUDANG = GUDANG.KODE LEFT OUTER JOIN DELIVERY_ORDER ON NOTA.ID_DO = DELIVERY_ORDER.ID_TRANSAKSI LEFT OUTER JOIN DIVISI ON NOTA.DIVISI = DIVISI.KODE LEFT OUTER JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID WHERE CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.DateTime & "',103) AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.DateTime & "',103) " &
    filter &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
    IIf(TxtKodeGudang.Text = "", "", " AND NOTA.GUDANG='" & TxtKodeGudang.Text & "' ") & promo & " ) A  ORDER BY NAMA_DIVISI,TGL_PENGAKUAN,NAMA_GUDANG,CAST(RIGHT(NO_NOTA, 6) AS INT) ")

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

    Private dtDivisi As New DataTable
    Private Sub loadDivisi()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 25, False)
        InitGrid.AddColumnGrid("Check", TypeCode.Boolean, 20)
        InitGrid.EndInit(TBDivisi, GridView1, dtDivisi)

        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisi, False)
    End Sub
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Daily Sales Report"
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        DtTanggalAwal.DateTime = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        DtTanggalAkhir.DateTime = Now.Date
        loadDivisi()

        CmbKodePromo.Properties.Items.Add("")
        Using dt = SelectCon.execute("SELECT KODE + ' - ' + NAMA_PROMO FROM PROMO")
            For Each R In dt.Rows
                CmbKodePromo.Properties.Items.Add(R(0))
            Next
        End Using
        CmbKodePromo.SelectedItem = ""
    End Sub

    Private Sub RDJenisPembayaran_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPenjualan.SelectedIndexChanged, RdPembayaran.SelectedIndexChanged, RDPenjualan.SelectedIndexChanged, DtTanggalAkhir.EditValueChanged, DtTanggalAwal.EditValueChanged
        'ReportShowPreview()
    End Sub

    Private Sub DtTanggalAkhir_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DtTanggalAkhir.EditValueChanging
        'DtTanggalAkhir.DateTime = e.NewValue
    End Sub

    Private Sub DtTanggalAwal_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DtTanggalAwal.EditValueChanging
        'DtTanggalAwal.DateTime = e.NewValue
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
End Class
