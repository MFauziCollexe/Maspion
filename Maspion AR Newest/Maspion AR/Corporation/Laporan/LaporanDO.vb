Imports DevExpress.XtraCharts

Public Class LaporanDO
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RdPembayaran As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDJenisPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDStatusOutstanding As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtKodeApprove As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtIDCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbKodePromo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbGroupBarang As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ChkTanpaClosing As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtIDDO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNoDO As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtKodeBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaBarang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.RdPembayaran = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.RDJenisPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.RDStatusOutstanding = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtKodeApprove = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtIDCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbKodePromo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbGroupBarang = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ChkTanpaClosing = New DevExpress.XtraEditors.CheckEdit()
        Me.TxtIDDO = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNoDO = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtKodeBarang = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNamaBarang = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDStatusOutstanding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbGroupBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkTanpaClosing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDDO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtIDDO)
        Me.XtraScrollableControl1.Controls.Add(Me.Label8)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNoDO)
        Me.XtraScrollableControl1.Controls.Add(Me.ChkTanpaClosing)
        Me.XtraScrollableControl1.Controls.Add(Me.Label7)
        Me.XtraScrollableControl1.Controls.Add(Me.CmbGroupBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label6)
        Me.XtraScrollableControl1.Controls.Add(Me.CmbKodePromo)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtIDCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNama)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeApprove)
        Me.XtraScrollableControl1.Controls.Add(Me.RDStatusOutstanding)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl2)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.RdPembayaran)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl5)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.RDPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdPembayaran, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDStatusOutstanding, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeApprove, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNama, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtIDCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.CmbKodePromo, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.CmbGroupBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label7, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.ChkTanpaClosing, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNoDO, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label8, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtIDDO, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeBarang, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 131)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tanggal"
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.CustomFormat = ""
        Me.DtTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAwal.Location = New System.Drawing.Point(105, 128)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(218, 128)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 131)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(105, 150)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 240
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(177, 150)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaDivisi.TabIndex = 241
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 153)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi  "
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(105, 489)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(212, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'RdPembayaran
        '
        Me.RdPembayaran.AutoSizeInLayoutControl = True
        Me.RdPembayaran.EditValue = ""
        Me.RdPembayaran.EnterMoveNextControl = True
        Me.RdPembayaran.Location = New System.Drawing.Point(105, 275)
        Me.RdPembayaran.Margin = New System.Windows.Forms.Padding(1)
        Me.RdPembayaran.Name = "RdPembayaran"
        Me.RdPembayaran.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kontan", "Kontan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kredit", "Kredit")})
        Me.RdPembayaran.Size = New System.Drawing.Size(212, 25)
        Me.RdPembayaran.TabIndex = 245
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 172)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 246
        Me.LabelControl3.Text = "Jenis Penjualan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(10, 227)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl6.TabIndex = 249
        Me.LabelControl6.Text = "Penjualan"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(10, 275)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl5.TabIndex = 247
        Me.LabelControl5.Text = "Jenis Pembayaran"
        '
        'RDJenisPenjualan
        '
        Me.RDJenisPenjualan.AutoSizeInLayoutControl = True
        Me.RDJenisPenjualan.EditValue = ""
        Me.RDJenisPenjualan.EnterMoveNextControl = True
        Me.RDJenisPenjualan.Location = New System.Drawing.Point(105, 227)
        Me.RDJenisPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisPenjualan.Name = "RDJenisPenjualan"
        Me.RDJenisPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Perwakilan", "Perwakilan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Pusat", "Pusat")})
        Me.RDJenisPenjualan.Size = New System.Drawing.Size(212, 46)
        Me.RDJenisPenjualan.TabIndex = 248
        '
        'RDPenjualan
        '
        Me.RDPenjualan.AutoSizeInLayoutControl = True
        Me.RDPenjualan.EditValue = ""
        Me.RDPenjualan.EnterMoveNextControl = True
        Me.RDPenjualan.Location = New System.Drawing.Point(105, 172)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Langganan", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Lain", "Lain - Lain")})
        Me.RDPenjualan.Size = New System.Drawing.Size(212, 53)
        Me.RDPenjualan.TabIndex = 244
        '
        'RDJenisLaporan
        '
        Me.RDJenisLaporan.AutoSizeInLayoutControl = True
        Me.RDJenisLaporan.EditValue = "Rekap"
        Me.RDJenisLaporan.EnterMoveNextControl = True
        Me.RDJenisLaporan.Location = New System.Drawing.Point(105, 61)
        Me.RDJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisLaporan.Name = "RDJenisLaporan"
        Me.RDJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail Bruto", "Detail Bruto"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail Netto", "Detail Netto"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap", "Rekap"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail Barang", "Detail Barang"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap D. Qty", "Rekap D. Qty")})
        Me.RDJenisLaporan.Size = New System.Drawing.Size(212, 65)
        Me.RDJenisLaporan.TabIndex = 250
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 64)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 251
        Me.LabelControl1.Text = "Jenis Laporan"
        '
        'RDStatusOutstanding
        '
        Me.RDStatusOutstanding.AutoSizeInLayoutControl = True
        Me.RDStatusOutstanding.EditValue = ""
        Me.RDStatusOutstanding.EnterMoveNextControl = True
        Me.RDStatusOutstanding.Location = New System.Drawing.Point(105, 302)
        Me.RDStatusOutstanding.Margin = New System.Windows.Forms.Padding(1)
        Me.RDStatusOutstanding.Name = "RDStatusOutstanding"
        Me.RDStatusOutstanding.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(0, Short), "Outstanding"), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(1, Short), "Terpenuhi")})
        Me.RDStatusOutstanding.Size = New System.Drawing.Size(212, 48)
        Me.RDStatusOutstanding.TabIndex = 252
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 302)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl2.TabIndex = 253
        Me.LabelControl2.Text = "Status Outstanding"
        '
        'TxtKodeApprove
        '
        Me.TxtKodeApprove.EditValue = ""
        Me.TxtKodeApprove.Location = New System.Drawing.Point(105, 352)
        Me.TxtKodeApprove.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeApprove.Name = "TxtKodeApprove"
        Me.TxtKodeApprove.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtKodeApprove.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtKodeApprove.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeApprove.Properties.ReadOnly = True
        Me.TxtKodeApprove.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeApprove.TabIndex = 254
        '
        'TxtNama
        '
        Me.TxtNama.Enabled = False
        Me.TxtNama.EnterMoveNextControl = True
        Me.TxtNama.Location = New System.Drawing.Point(177, 352)
        Me.TxtNama.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNama.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNama.Properties.ReadOnly = True
        Me.TxtNama.Size = New System.Drawing.Size(140, 20)
        Me.TxtNama.TabIndex = 255
        '
        'TxtIDCustomer
        '
        Me.TxtIDCustomer.Enabled = False
        Me.TxtIDCustomer.EnterMoveNextControl = True
        Me.TxtIDCustomer.Location = New System.Drawing.Point(319, 352)
        Me.TxtIDCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDCustomer.Name = "TxtIDCustomer"
        Me.TxtIDCustomer.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtIDCustomer.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtIDCustomer.Properties.ReadOnly = True
        Me.TxtIDCustomer.Size = New System.Drawing.Size(15, 20)
        Me.TxtIDCustomer.TabIndex = 256
        Me.TxtIDCustomer.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 355)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 257
        Me.LabelControl4.Text = "Customer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 399)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Kode Promo"
        '
        'CmbKodePromo
        '
        Me.CmbKodePromo.Location = New System.Drawing.Point(105, 396)
        Me.CmbKodePromo.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbKodePromo.Name = "CmbKodePromo"
        Me.CmbKodePromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbKodePromo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbKodePromo.Size = New System.Drawing.Size(212, 20)
        Me.CmbKodePromo.TabIndex = 263
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 377)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 268
        Me.Label7.Text = "Group Barang"
        '
        'CmbGroupBarang
        '
        Me.CmbGroupBarang.Location = New System.Drawing.Point(105, 374)
        Me.CmbGroupBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbGroupBarang.Name = "CmbGroupBarang"
        Me.CmbGroupBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbGroupBarang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbGroupBarang.Size = New System.Drawing.Size(212, 20)
        Me.CmbGroupBarang.TabIndex = 267
        '
        'ChkTanpaClosing
        '
        Me.ChkTanpaClosing.Location = New System.Drawing.Point(103, 464)
        Me.ChkTanpaClosing.Name = "ChkTanpaClosing"
        Me.ChkTanpaClosing.Properties.Caption = "Jangan Tampilkan Transaksi Closing"
        Me.ChkTanpaClosing.Size = New System.Drawing.Size(214, 19)
        Me.ChkTanpaClosing.TabIndex = 269
        '
        'TxtIDDO
        '
        Me.TxtIDDO.EnterMoveNextControl = True
        Me.TxtIDDO.Location = New System.Drawing.Point(319, 418)
        Me.TxtIDDO.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDDO.Name = "TxtIDDO"
        Me.TxtIDDO.Properties.ReadOnly = True
        Me.TxtIDDO.Size = New System.Drawing.Size(30, 20)
        Me.TxtIDDO.TabIndex = 272
        Me.TxtIDDO.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 421)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 271
        Me.Label8.Text = "No. DO"
        '
        'TxtNoDO
        '
        Me.TxtNoDO.Location = New System.Drawing.Point(105, 418)
        Me.TxtNoDO.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNoDO.Name = "TxtNoDO"
        Me.TxtNoDO.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtNoDO.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNoDO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtNoDO.Properties.ReadOnly = True
        Me.TxtNoDO.Size = New System.Drawing.Size(212, 20)
        Me.TxtNoDO.TabIndex = 270
        '
        'TxtKodeBarang
        '
        Me.TxtKodeBarang.EnterMoveNextControl = True
        Me.TxtKodeBarang.Location = New System.Drawing.Point(319, 440)
        Me.TxtKodeBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeBarang.Name = "TxtKodeBarang"
        Me.TxtKodeBarang.Properties.ReadOnly = True
        Me.TxtKodeBarang.Size = New System.Drawing.Size(30, 20)
        Me.TxtKodeBarang.TabIndex = 275
        Me.TxtKodeBarang.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 443)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 274
        Me.Label4.Text = "Barang"
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.Location = New System.Drawing.Point(105, 440)
        Me.TxtNamaBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtNamaBarang.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNamaBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtNamaBarang.Properties.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(212, 20)
        Me.TxtNamaBarang.TabIndex = 273
        '
        'LaporanDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanDO"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDStatusOutstanding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbGroupBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkTanpaClosing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDDO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Function TanpaClosing(ByVal nama As String) As String
        Dim A As String = " AND " & nama & ".ID_TRANSAKSI NOT IN (SELECT ID_TRANSAKSI FROM CLOSING_TRANSAKSI) "
        Return A
    End Function

    Private Sub ReportShowDetailBarang()
        Dim MyReport = New XRLaporanDetailBarangDO
        MyReport.TxtUser.Text = "Salesman"
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RdPembayaran.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDStatusOutstanding.Properties.Items(RDStatusOutstanding.SelectedIndex).Description.ToUpper

        Report = MyReport

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO PR ON BARANG.ID=PR.ID_BARANG AND DELIVERY_ORDER.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Dim MyQuery As String = ""
        If RDStatusOutstanding.SelectedIndex = 2 Then
            Report.DataSource = SelectCon.execute("SELECT IIF(URUT=1,NO_DO,'') NO_DO,ID_TRANSAKSI,TGL_PENGAKUAN,DIVISI,KODE_CUSTOMER,KODE_APPROVE,IIF(URUT=1,NAMA,'')NAMA,ID_BARANG,NAMA_BARANG,HARGA,KOLI,QUANTITY,PCS,IIF(URUT=1,SUBTOTAL,'') SUBTOTAL,DISC_QTY,DISC_REG,DISC_1,DISC_2,DISC_3,CASH_DISC,DISC_QTY1,IIF(URUT=1,(((((((SUBTOTAL-(SUM(QUANTITY) OVER (PARTITION BY ID_TRANSAKSI)*DISC_QTY))*(100-DISC_REG)/100)*(100-DISC_1)/100)*(100-DISC_2)/100)*(100-DISC_3)/100)*(100-CASH_DISC)/100)*(100-DISC_QTY1)/100),'') DPP,IIF(URUT=1,PPN,'') PPN,BAGIAN,JENIS_DO,NAMA_DIVISI,NAMA_USER,IIF(URUT=1,DISC_QTY_NOMINAL,'') DISC_QTY_NOMINAL,IIF(URUT=1,DISC_QTY_NOMINAL1,'') DISC_QTY_NOMINAL1,SATUAN,URUTAN, IIF(URUT = 1, SUM(QUANTITY) OVER (PARTITION BY ID_TRANSAKSI), 0) SUMQTY FROM (SELECT ROW_NUMBER() OVER(PARTITION BY DELIVERY_ORDER.ID_TRANSAKSI ORDER BY DELIVERY_ORDER.TGL_PENGAKUAN,URUTAN) URUT, DELIVERY_ORDER.NO_DO, DELIVERY_ORDER.ID_TRANSAKSI, DELIVERY_ORDER.TGL_PENGAKUAN, DELIVERY_ORDER.DIVISI, DELIVERY_ORDER.KODE_CUSTOMER, DELIVERY_ORDER.KODE_APPROVE, CUSTOMER.NAMA NAMA, DETAIL_DELIVERY_ORDER.ID_BARANG, BARANG.NAMA AS NAMA_BARANG, DETAIL_DELIVERY_ORDER.HARGA,DO.KOLI_T KOLI, DO.QUANTITY_T QUANTITY, DO.PCS_T PCS, SUM(DO.PCS_T*(DO.HARGA/DETAIL_DELIVERY_ORDER.KONVERSI)) OVER (PARTITION BY DO.ID_TRANSAKSI) SUBTOTAL, DELIVERY_ORDER.DISC_QTY, DELIVERY_ORDER.DISC_REG, DELIVERY_ORDER.DISC_1, DELIVERY_ORDER.DISC_2, DELIVERY_ORDER.DISC_3, DELIVERY_ORDER.CASH_DISC, ROUND(DELIVERY_ORDER.DISC_QTY1,2) DISC_QTY1, SUM(DO.PCS_T*(DO.HARGA/DETAIL_DELIVERY_ORDER.KONVERSI)) OVER (PARTITION BY DO.ID_TRANSAKSI) DPP, DELIVERY_ORDER.PPN, DELIVERY_ORDER.BAGIAN, DELIVERY_ORDER.JENIS_DO, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, DELIVERY_ORDER.DISC_QTY_NOMINAL, DELIVERY_ORDER.DISC_QTY_NOMINAL1, DETAIL_DELIVERY_ORDER.SATUAN, DETAIL_DELIVERY_ORDER.URUTAN FROM DELIVERY_ORDER INNER JOIN DETAIL_DELIVERY_ORDER ON DELIVERY_ORDER.ID_TRANSAKSI = DETAIL_DELIVERY_ORDER.ID_TRANSAKSI LEFT JOIN (SELECT DISTINCT ID_TRANSAKSI,ID_BARANG,KOLI_T,QUANTITY_T,PCS_T,ST,STK,HARGA FROM V_D_DB_PERW_T_STUFF UNION ALL SELECT DISTINCT ID_TRANSAKSI,ID_BARANG,KOLI_T,QUANTITY_T,PCS_T,ST,STK,HARGA FROM V_D_DB_PUSAT_T_NOTA) DO ON DETAIL_DELIVERY_ORDER.ID_TRANSAKSI=DO.ID_TRANSAKSI AND DETAIL_DELIVERY_ORDER.ID_BARANG=DO.ID_BARANG LEFT OUTER JOIN BARANG ON BARANG.ID = DETAIL_DELIVERY_ORDER.ID_BARANG LEFT OUTER JOIN DIVISI ON DELIVERY_ORDER.DIVISI = DIVISI.KODE LEFT OUTER JOIN USERS ON DELIVERY_ORDER.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER = CUSTOMER.ID " & JOIN_PROMO & " WHERE DELIVERY_ORDER.BATAL=0 AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND DELIVERY_ORDER.DIVISI='" & TxtDivisi.Text & "' ") &
         IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
         IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
         IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
         IIf(CmbKodePromo.SelectedItem = "All", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
         IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
         IIf(ChkTanpaClosing.Checked, TanpaClosing("DELIVERY_ORDER"), "") &
         IIf(TxtIDDO.Text = "", "", " AND DELIVERY_ORDER.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
         IIf(TxtKodeBarang.Text = "", "", " AND BARANG.ID='" & TxtKodeBarang.Text & "'") &
         IIf(TxtIDCustomer.Text = "", "", " AND DELIVERY_ORDER.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " ) Z")
        ElseIf RDStatusOutstanding.SelectedIndex = 1 Then
            Report.DataSource = SelectCon.execute("SELECT IIF(URUT=1,NO_DO,'') NO_DO,ID_TRANSAKSI,TGL_PENGAKUAN,DIVISI,KODE_CUSTOMER,KODE_APPROVE,IIF(URUT=1,NAMA,'')NAMA,ID_BARANG,NAMA_BARANG,HARGA,KOLI,QUANTITY,PCS,IIF(URUT=1,SUBTOTAL,'') SUBTOTAL,DISC_QTY,DISC_REG,DISC_1,DISC_2,DISC_3,CASH_DISC,DISC_QTY1,IIF(URUT=1,(((((((SUBTOTAL-(SUM(QUANTITY) OVER (PARTITION BY ID_TRANSAKSI)*DISC_QTY))*(100-DISC_REG)/100)*(100-DISC_1)/100)*(100-DISC_2)/100)*(100-DISC_3)/100)*(100-CASH_DISC)/100)*(100-DISC_QTY1)/100),'') DPP,IIF(URUT=1,PPN,'') PPN,BAGIAN,JENIS_DO,NAMA_DIVISI,NAMA_USER,IIF(URUT=1,DISC_QTY_NOMINAL,'') DISC_QTY_NOMINAL,IIF(URUT=1,DISC_QTY_NOMINAL1,'') DISC_QTY_NOMINAL1,SATUAN,URUTAN, IIF(URUT = 1, SUM(QUANTITY) OVER (PARTITION BY ID_TRANSAKSI), 0) SUMQTY FROM (SELECT ROW_NUMBER() OVER(PARTITION BY DELIVERY_ORDER.ID_TRANSAKSI ORDER BY DELIVERY_ORDER.TGL_PENGAKUAN,URUTAN) URUT, DELIVERY_ORDER.NO_DO, DELIVERY_ORDER.ID_TRANSAKSI, DELIVERY_ORDER.TGL_PENGAKUAN, DELIVERY_ORDER.DIVISI, DELIVERY_ORDER.KODE_CUSTOMER, DELIVERY_ORDER.KODE_APPROVE, CUSTOMER.NAMA NAMA, DETAIL_DELIVERY_ORDER.ID_BARANG, BARANG.NAMA AS NAMA_BARANG, DETAIL_DELIVERY_ORDER.HARGA, DETAIL_DELIVERY_ORDER.KOLI-DO.KOLI_T KOLI, DETAIL_DELIVERY_ORDER.QUANTITY-DO.QUANTITY_T QUANTITY, DETAIL_DELIVERY_ORDER.PCS-DO.PCS_T PCS, SUM((DETAIL_DELIVERY_ORDER.PCS-DO.PCS_T)*(DO.HARGA/IIF(DETAIL_DELIVERY_ORDER.KONVERSI = 0, 1, DETAIL_DELIVERY_ORDER.KONVERSI))) OVER (PARTITION BY DO.ID_TRANSAKSI) SUBTOTAL, DELIVERY_ORDER.DISC_QTY, DELIVERY_ORDER.DISC_REG, DELIVERY_ORDER.DISC_1, DELIVERY_ORDER.DISC_2, DELIVERY_ORDER.DISC_3, DELIVERY_ORDER.CASH_DISC, ROUND(DELIVERY_ORDER.DISC_QTY1,2) DISC_QTY1, SUM((DETAIL_DELIVERY_ORDER.PCS-DO.PCS_T)*(DO.HARGA/IIF(DETAIL_DELIVERY_ORDER.KONVERSI = 0, 1, DETAIL_DELIVERY_ORDER.KONVERSI))) OVER (PARTITION BY DO.ID_TRANSAKSI) DPP, DELIVERY_ORDER.PPN, DELIVERY_ORDER.BAGIAN, DELIVERY_ORDER.JENIS_DO, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, DELIVERY_ORDER.DISC_QTY_NOMINAL, DELIVERY_ORDER.DISC_QTY_NOMINAL1, DETAIL_DELIVERY_ORDER.SATUAN, DETAIL_DELIVERY_ORDER.URUTAN FROM DELIVERY_ORDER INNER JOIN DETAIL_DELIVERY_ORDER ON DELIVERY_ORDER.ID_TRANSAKSI = DETAIL_DELIVERY_ORDER.ID_TRANSAKSI LEFT JOIN (SELECT DISTINCT ID_TRANSAKSI,ID_BARANG,KOLI_T,QUANTITY_T,PCS_T,ST,STK,HARGA FROM F_D_DB_PERW_T_STUFF(CAST('" & Format(DtTanggalAkhir.Value, "MM/dd/yyyy") & "' AS DATE)) UNION ALL SELECT DISTINCT ID_TRANSAKSI,ID_BARANG,KOLI_T,QUANTITY_T,PCS_T,ST,STK,HARGA FROM F_D_DB_PUSAT_T_NOTA(CAST('" & Format(DtTanggalAkhir.Value, "MM/dd/yyyy") & "' AS DATE))) DO ON DETAIL_DELIVERY_ORDER.ID_TRANSAKSI=DO.ID_TRANSAKSI AND DETAIL_DELIVERY_ORDER.ID_BARANG=DO.ID_BARANG LEFT OUTER JOIN BARANG ON BARANG.ID = DETAIL_DELIVERY_ORDER.ID_BARANG LEFT OUTER JOIN DIVISI ON DELIVERY_ORDER.DIVISI = DIVISI.KODE LEFT OUTER JOIN USERS ON DELIVERY_ORDER.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER = CUSTOMER.ID " & JOIN_PROMO & " WHERE DELIVERY_ORDER.BATAL=0 AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND DELIVERY_ORDER.DIVISI='" & TxtDivisi.Text & "' ") &
        IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
        IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
        IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND DO.ST=" & RDStatusOutstanding.EditValue & " ") &
              IIf(CmbKodePromo.SelectedItem = "All", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
              IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
  IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
  IIf(ChkTanpaClosing.Checked, TanpaClosing("DELIVERY_ORDER"), "") &
  IIf(TxtIDDO.Text = "", "", " AND DELIVERY_ORDER.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
  IIf(TxtKodeBarang.Text = "", "", " AND BARANG.ID='" & TxtKodeBarang.Text & "'") &
        IIf(TxtIDCustomer.Text = "", "", " AND DELIVERY_ORDER.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " ) Z")
        Else
            Report.DataSource = SelectCon.execute("SELECT IIF(URUT=1,NO_DO,'') NO_DO,ID_TRANSAKSI,TGL_PENGAKUAN,DIVISI,KODE_CUSTOMER,KODE_APPROVE,IIF(URUT=1,NAMA,'')NAMA,ID_BARANG,NAMA_BARANG,HARGA,KOLI,QUANTITY,PCS,IIF(URUT=1,SUBTOTAL,'') SUBTOTAL,DISC_QTY,DISC_REG,DISC_1,DISC_2,DISC_3,CASH_DISC,DISC_QTY1,IIF(URUT=1,DPP,'') DPP,IIF(URUT=1,PPN,'') PPN,BAGIAN,JENIS_DO,NAMA_DIVISI,NAMA_USER,IIF(URUT=1,DISC_QTY_NOMINAL,'') DISC_QTY_NOMINAL,IIF(URUT=1,DISC_QTY_NOMINAL1,'') DISC_QTY_NOMINAL1,SATUAN,URUTAN, IIF(URUT = 1, SUM(QUANTITY) OVER (PARTITION BY ID_TRANSAKSI), 0) SUMQTY FROM (SELECT ROW_NUMBER() OVER(PARTITION BY DELIVERY_ORDER.ID_TRANSAKSI ORDER BY DELIVERY_ORDER.TGL_PENGAKUAN,URUTAN) URUT, DELIVERY_ORDER.NO_DO, DELIVERY_ORDER.ID_TRANSAKSI, DELIVERY_ORDER.TGL_PENGAKUAN, DELIVERY_ORDER.DIVISI, DELIVERY_ORDER.KODE_CUSTOMER, DELIVERY_ORDER.KODE_APPROVE, CUSTOMER.NAMA NAMA, DETAIL_DELIVERY_ORDER.ID_BARANG, BARANG.NAMA AS NAMA_BARANG, DETAIL_DELIVERY_ORDER.HARGA, DETAIL_DELIVERY_ORDER.KOLI KOLI, DETAIL_DELIVERY_ORDER.QUANTITY QUANTITY, DETAIL_DELIVERY_ORDER.PCS PCS, SUM(DETAIL_DELIVERY_ORDER.HARGA*DETAIL_DELIVERY_ORDER.QUANTITY) OVER (PARTITION BY DELIVERY_ORDER.ID_TRANSAKSI) SUBTOTAL, DELIVERY_ORDER.DISC_QTY, DELIVERY_ORDER.DISC_REG, DELIVERY_ORDER.DISC_1, DELIVERY_ORDER.DISC_2, DELIVERY_ORDER.DISC_3, DELIVERY_ORDER.CASH_DISC, ROUND(DELIVERY_ORDER.DISC_QTY1,2) DISC_QTY1, DELIVERY_ORDER.DPP, DELIVERY_ORDER.PPN, DELIVERY_ORDER.BAGIAN, DELIVERY_ORDER.JENIS_DO, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, DELIVERY_ORDER.DISC_QTY_NOMINAL, DELIVERY_ORDER.DISC_QTY_NOMINAL1, DETAIL_DELIVERY_ORDER.SATUAN, DETAIL_DELIVERY_ORDER.URUTAN FROM DELIVERY_ORDER INNER JOIN DETAIL_DELIVERY_ORDER ON DELIVERY_ORDER.ID_TRANSAKSI = DETAIL_DELIVERY_ORDER.ID_TRANSAKSI LEFT OUTER JOIN BARANG ON BARANG.ID = DETAIL_DELIVERY_ORDER.ID_BARANG LEFT OUTER JOIN DIVISI ON DELIVERY_ORDER.DIVISI = DIVISI.KODE LEFT OUTER JOIN USERS ON DELIVERY_ORDER.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER = CUSTOMER.ID " & JOIN_PROMO & " WHERE DELIVERY_ORDER.BATAL=0 AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND DELIVERY_ORDER.DIVISI='" & TxtDivisi.Text & "' ") &
        IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
        IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
        IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND DO.ST=" & RDStatusOutstanding.EditValue & " ") &
        IIf(CmbKodePromo.SelectedItem = "All", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
        IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
  IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
  IIf(ChkTanpaClosing.Checked, TanpaClosing("DELIVERY_ORDER"), "") &
  IIf(TxtIDDO.Text = "", "", " AND DELIVERY_ORDER.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
  IIf(TxtKodeBarang.Text = "", "", " AND BARANG.ID='" & TxtKodeBarang.Text & "'") &
        IIf(TxtIDCustomer.Text = "", "", " AND DELIVERY_ORDER.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " ) Z")
        End If

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewRekap()
        Dim MyReport = New XRLaporanDO
        MyReport.TxtUser.Text = "Salesman"
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RdPembayaran.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDStatusOutstanding.Properties.Items(RDStatusOutstanding.SelectedIndex).Description.ToUpper

        Dim JOIN_STK As String = IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " LEFT JOIN (SELECT DISTINCT ID_TRANSAKSI,STK FROM V_D_DB_PERW_T_STUFF UNION ALL SELECT DISTINCT ID_TRANSAKSI,STK FROM V_D_DB_PUSAT_T_NOTA) DO ON DELIVERY_ORDER.ID_TRANSAKSI=DO.ID_TRANSAKSI ")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DELIVERY_ORDER.BATAL,DELIVERY_ORDER.NO_DO, DELIVERY_ORDER.ID_TRANSAKSI, DELIVERY_ORDER.TGL_PENGAKUAN, DELIVERY_ORDER.DIVISI, DELIVERY_ORDER.KODE_CUSTOMER, DELIVERY_ORDER.KODE_APPROVE, CUSTOMER.NAMA NAMA, DELIVERY_ORDER.SUBTOTAL SUBTOTAL_DETAIL, CASE WHEN BATAL=1 THEN 0 ELSE DELIVERY_ORDER.SUBTOTAL END AS SUBTOTAL, DELIVERY_ORDER.DISC_QTY, DELIVERY_ORDER.DISC_REG, DELIVERY_ORDER.DISC_1, DELIVERY_ORDER.DISC_2, DELIVERY_ORDER.DISC_3, DELIVERY_ORDER.CASH_DISC, DELIVERY_ORDER.DISC_QTY1, DELIVERY_ORDER.DPP, DELIVERY_ORDER.PPN, DELIVERY_ORDER.BAGIAN, DELIVERY_ORDER.JENIS_DO, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, DELIVERY_ORDER.DISC_QTY_NOMINAL, DELIVERY_ORDER.DISC_QTY_NOMINAL1 FROM DELIVERY_ORDER LEFT OUTER JOIN DIVISI ON DELIVERY_ORDER.DIVISI = DIVISI.KODE " & JOIN_STK & " LEFT OUTER JOIN USERS ON DELIVERY_ORDER.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER = CUSTOMER.ID WHERE CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND DELIVERY_ORDER.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND DO.STK=" & RDStatusOutstanding.EditValue & " ") &
    IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
    IIf(ChkTanpaClosing.Checked, TanpaClosing("DELIVERY_ORDER"), "") &
    IIf(TxtIDDO.Text = "", "", " AND DELIVERY_ORDER.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
    IIf(TxtIDCustomer.Text = "", "", " AND DELIVERY_ORDER.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetailBruto()
        Dim MyReport = New XRLaporanDetailDO
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RdPembayaran.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDStatusOutstanding.Properties.Items(RDStatusOutstanding.SelectedIndex).Description.ToUpper

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO PR ON Z.ID_BARANG=PR.ID_BARANG AND A.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DIV.NAMA NAMA_DIVISI, D.NAMA AS CUSTOMER,C.NAMA AS BARANG,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS ELSE 0 END) AS PCS_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS*((B.HARGA-B.DISKON_SATUAN)/IIF(B.KONVERSI = 0, 1, B.KONVERSI)) ELSE 0 END) AS BRUTO_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS ELSE 0 END) AS PCS_PST,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS*((B.HARGA-B.DISKON_SATUAN)/IIF(B.KONVERSI = 0, 1, B.KONVERSI)) ELSE 0 END) AS BRUTO_PST FROM DELIVERY_ORDER A INNER JOIN DETAIL_DELIVERY_ORDER B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI INNER JOIN (SELECT ID_TRANSAKSI,ID_BARANG,ST FROM V_D_DB_PERW_T_STUFF UNION ALL SELECT ID_TRANSAKSI,ID_BARANG,ST FROM V_D_DB_PUSAT_T_NOTA) Z ON B.ID_TRANSAKSI=Z.ID_TRANSAKSI AND B.ID_BARANG=Z.ID_BARANG LEFT JOIN BARANG C ON B.ID_BARANG=C.ID LEFT JOIN CUSTOMER D ON A.KODE_CUSTOMER=D.ID " & JOIN_PROMO & " LEFT JOIN DIVISI DIV ON A.DIVISI=DIV.KODE WHERE A.BATAL=0 AND CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND A.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND Z.ST =" & RDStatusOutstanding.EditValue & " ") &
    IIf(CmbKodePromo.SelectedItem = "All", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "' ") &
    IIf(CmbGroupBarang.SelectedItem = "All", "", " AND C.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
    IIf(ChkTanpaClosing.Checked, TanpaClosing("A"), "") &
    IIf(TxtIDDO.Text = "", "", " AND A.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
    IIf(TxtKodeBarang.Text = "", "", " AND C.ID='" & TxtKodeBarang.Text & "'") &
    IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND A.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") & IIf(TxtIDCustomer.Text = "", "", " AND A.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " GROUP BY D.NAMA,C.NAMA,DIV.NAMA")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetailNetto()
        Dim MyReport = New XRLaporanDetailDO
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RdPembayaran.EditValue.ToString.ToUpper
        MyReport.TxtPerwakilanBruto.Text = "Netto"
        MyReport.TxtPusatBruto.Text = "Netto"
        MyReport.TxtTotalBruto.Text = "Total Netto"
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDStatusOutstanding.Properties.Items(RDStatusOutstanding.SelectedIndex).Description.ToUpper

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO PR ON Z.ID_BARANG=PR.ID_BARANG AND A.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DIV.NAMA NAMA_DIVISI, D.NAMA AS CUSTOMER,C.NAMA AS BARANG,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS ELSE 0 END) AS PCS_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS*((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)- (((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)- ((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)- (((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)- ((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)- (((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)*CASH_DISC/100)- ((((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)*CASH_DISC/100)*DISC_QTY1/100))/IIF(B.KONVERSI = 0, 1, B.KONVERSI)) ELSE 0 END) AS BRUTO_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS ELSE 0 END) AS PCS_PST,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS*((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)- (((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)- ((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)- (((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)- ((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)- (((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)*CASH_DISC/100)- ((((((((B.HARGA-B.DISKON_SATUAN)-DISC_QTY)*DISC_REG/100)*DISC_1/100)*DISC_2/100)*DISC_3/100)*CASH_DISC/100)*DISC_QTY1/100))/IIF(B.KONVERSI = 0, 1, B.KONVERSI)) ELSE 0 END) AS BRUTO_PST FROM DELIVERY_ORDER A INNER JOIN DETAIL_DELIVERY_ORDER B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI INNER JOIN (SELECT ID_TRANSAKSI,ID_BARANG,ST FROM V_D_DB_PERW_T_STUFF UNION ALL SELECT ID_TRANSAKSI,ID_BARANG,ST FROM V_D_DB_PUSAT_T_NOTA) Z ON B.ID_TRANSAKSI=Z.ID_TRANSAKSI AND B.ID_BARANG=Z.ID_BARANG LEFT JOIN BARANG C ON B.ID_BARANG=C.ID LEFT JOIN CUSTOMER D ON A.KODE_CUSTOMER=D.ID " & JOIN_PROMO & " LEFT JOIN DIVISI DIV ON A.DIVISI=DIV.KODE WHERE A.BATAL=0 AND CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND A.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") & vbCrLf &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") & vbCrLf &
    IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND Z.ST =" & RDStatusOutstanding.EditValue & " ") &
    IIf(CmbKodePromo.SelectedItem = "All", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "' ") &
    IIf(CmbGroupBarang.SelectedItem = "All", "", " AND C.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
    IIf(ChkTanpaClosing.Checked, TanpaClosing("A"), "") &
    IIf(TxtIDDO.Text = "", "", " AND A.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
    IIf(TxtKodeBarang.Text = "", "", " AND C.ID='" & TxtKodeBarang.Text & "'") &
    IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND A.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") & IIf(TxtIDCustomer.Text = "", "", " AND A.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " GROUP BY D.NAMA,C.NAMA,DIV.NAMA")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewRekapDiskonQty()
        Dim MyReport = New XRLaporanDODiskonQty
        MyReport.TxtUser.Text = "Salesman"
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RdPembayaran.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDStatusOutstanding.Properties.Items(RDStatusOutstanding.SelectedIndex).Description.ToUpper

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DELIVERY_ORDER.BATAL,DELIVERY_ORDER.NO_DO, DELIVERY_ORDER.ID_TRANSAKSI, DELIVERY_ORDER.TGL_PENGAKUAN, DELIVERY_ORDER.DIVISI, DELIVERY_ORDER.KODE_CUSTOMER, DELIVERY_ORDER.KODE_APPROVE, CUSTOMER.NAMA NAMA, DELIVERY_ORDER.SUBTOTAL SUBTOTAL_DETAIL, CASE WHEN BATAL=1 THEN 0 ELSE DELIVERY_ORDER.SUBTOTAL END AS SUBTOTAL, DELIVERY_ORDER.DISC_QTY, DELIVERY_ORDER.DISC_REG, DELIVERY_ORDER.DISC_1, DELIVERY_ORDER.DISC_2, DELIVERY_ORDER.DISC_3, DELIVERY_ORDER.CASH_DISC, DELIVERY_ORDER.DISC_QTY1, DELIVERY_ORDER.DPP, DELIVERY_ORDER.PPN, DELIVERY_ORDER.BAGIAN, DELIVERY_ORDER.JENIS_DO, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, DELIVERY_ORDER.DISC_QTY_NOMINAL, DELIVERY_ORDER.DISC_QTY_NOMINAL1, KETERANGAN_INTERNAL FROM DELIVERY_ORDER LEFT OUTER JOIN DIVISI ON DELIVERY_ORDER.DIVISI = DIVISI.KODE LEFT JOIN (SELECT DISTINCT ID_TRANSAKSI,STK FROM V_D_DB_PERW_T_STUFF UNION ALL SELECT DISTINCT ID_TRANSAKSI,STK FROM V_D_DB_PUSAT_T_NOTA) DO ON DELIVERY_ORDER.ID_TRANSAKSI=DO.ID_TRANSAKSI LEFT OUTER JOIN USERS ON DELIVERY_ORDER.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER = CUSTOMER.ID WHERE KETERANGAN_INTERNAL <> '' AND (DISC_QTY_NOMINAL+DISC_QTY_NOMINAL1) > 0 AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,DELIVERY_ORDER.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND DELIVERY_ORDER.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND DELIVERY_ORDER.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(RDStatusOutstanding.SelectedIndex = -1 Or RDStatusOutstanding.SelectedIndex = 0, "", " AND DO.STK=" & RDStatusOutstanding.EditValue & " ") &
    IIf(RdPembayaran.SelectedIndex = -1 Or RdPembayaran.SelectedIndex = 0, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue.ToString & "' ") &
    IIf(ChkTanpaClosing.Checked, TanpaClosing("DELIVERY_ORDER"), "") &
    IIf(TxtIDDO.Text = "", "", " AND DELIVERY_ORDER.ID_TRANSAKSI='" & TxtIDDO.Text & "'") &
    IIf(TxtIDCustomer.Text = "", "", " AND DELIVERY_ORDER.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN DELIVERY ORDER"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        CmbKodePromo.Properties.Items.Add("All")
        Using dt = SelectCon.execute("SELECT KODE + ' - ' + NAMA_PROMO FROM PROMO")
            For Each R In dt.Rows
                CmbKodePromo.Properties.Items.Add(R(0))
            Next
        End Using
        CmbKodePromo.SelectedItem = "All"

        CmbGroupBarang.Properties.Items.Add("All")
        Using dt = SelectCon.execute("SELECT KODE + ' - ' + NAMA FROM GROUP_BARANG")
            For Each R In dt.Rows
                CmbGroupBarang.Properties.Items.Add(R(0))
            Next
        End Using
        CmbGroupBarang.SelectedItem = "All"
    End Sub

    ''' <summary>
    ''' Cari Divisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtDivisi_Click(sender As Object, e As System.EventArgs) Handles TxtDivisi.Click
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub txtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        If RDJenisLaporan.SelectedIndex = 2 Then
            ReportShowPreviewRekap()
        ElseIf RDJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreviewDetailBruto()
        ElseIf RDJenisLaporan.SelectedIndex = 1 Then
            ReportShowPreviewDetailNetto()
        ElseIf RDJenisLaporan.SelectedIndex = 3 Then
            ReportShowDetailBarang()
        ElseIf RDJenisLaporan.SelectedIndex = 4 Then
            ReportShowPreviewRekapDiskonQty()
        End If
    End Sub

    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer, , , , , , , , , , , , TxtDivisi.Text)
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer, , , , , , , , , , , , TxtDivisi.Text)
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtNama.Text = ""
                TxtKodeApprove.Text = ""
            End If
        End Using
    End Sub

    Private Sub RDJenisLaporan_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RDJenisLaporan.SelectedIndexChanged
        If RDJenisLaporan.SelectedIndex = 2 Then
            CmbKodePromo.Enabled = False
            CmbGroupBarang.Enabled = False
        Else
            CmbKodePromo.Enabled = True
            CmbGroupBarang.Enabled = True
        End If
    End Sub

    Private Sub TxtIDDO_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDDO.EditValueChanged
        Using data = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
            If data.Rows.Count > 0 Then
                TxtNoDO.Text = data.Rows(0).Item("NO_DO")
            Else
                TxtNoDO.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtNoDO_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoDO.ButtonClick
        TxtIDDO.Text = Search(FrmPencarian.KeyPencarian.AllDO)
    End Sub

    Private Sub TxtNoDO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDO.KeyPress
        If CharKeypress(TxtIDDO, e) Then TxtIDDO.Text = Search(FrmPencarian.KeyPencarian.AllDO)
    End Sub

    Private Sub TxtKodeBarang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeBarang.EditValueChanged
        Using data = SelectCon.execute("SELECT NAMA FROM BARANG WHERE ID='" & TxtKodeBarang.Text & "'")
            If data.Rows.Count > 0 Then
                TxtNamaBarang.Text = data.Rows(0).Item("NAMA")
            Else
                TxtNamaBarang.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtNamaBarang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNamaBarang.ButtonClick
        TxtKodeBarang.Text = Search(FrmPencarian.KeyPencarian.BarangAll)
    End Sub

    Private Sub TxtNamaBarang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamaBarang.KeyPress
        If CharKeypress(TxtKodeBarang, e) Then TxtKodeBarang.Text = Search(FrmPencarian.KeyPencarian.BarangAll)
    End Sub
End Class
