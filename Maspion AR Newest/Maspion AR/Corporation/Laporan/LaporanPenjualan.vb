Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanPenjualan
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDJenisPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LblIDCustomer As System.Windows.Forms.Label
    Friend WithEvents LblIDBarang As System.Windows.Forms.Label
    Friend WithEvents TxtNamaBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeBarang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TBDivisi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RdPembayaran As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbKodePromo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RdJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbGroupBarang As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtIDDO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNoDO As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtNamaCorp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtKodeCorp As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.RDJenisPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtKodeCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.LblIDCustomer = New System.Windows.Forms.Label()
        Me.TxtNamaBarang = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtKodeBarang = New DevExpress.XtraEditors.ButtonEdit()
        Me.LblIDBarang = New System.Windows.Forms.Label()
        Me.TBDivisi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RdPembayaran = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbKodePromo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RdJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbGroupBarang = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNoDO = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtIDDO = New DevExpress.XtraEditors.TextEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtNamaCorp = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtKodeCorp = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbGroupBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDDO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCorp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeCorp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label9)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCorp)
        Me.XtraScrollableControl1.Controls.Add(Me.Label10)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCorp)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtIDDO)
        Me.XtraScrollableControl1.Controls.Add(Me.Label8)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNoDO)
        Me.XtraScrollableControl1.Controls.Add(Me.Label7)
        Me.XtraScrollableControl1.Controls.Add(Me.CmbGroupBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.RdJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.Label6)
        Me.XtraScrollableControl1.Controls.Add(Me.CmbKodePromo)
        Me.XtraScrollableControl1.Controls.Add(Me.RdPembayaran)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl5)
        Me.XtraScrollableControl1.Controls.Add(Me.TBDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.LblIDBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.LblIDCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.RDPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(390, 467)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LblIDCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LblIDBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TBDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdPembayaran, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.CmbKodePromo, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.CmbGroupBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label7, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNoDO, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label8, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtIDDO, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCorp, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label10, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCorp, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label9, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 117)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(117, 114)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(230, 114)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 139)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi  "
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(117, 523)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(212, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 261)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 246
        Me.LabelControl3.Text = "Jenis Penjualan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(25, 316)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl6.TabIndex = 249
        Me.LabelControl6.Text = "Penjualan"
        '
        'RDJenisPenjualan
        '
        Me.RDJenisPenjualan.AutoSizeInLayoutControl = True
        Me.RDJenisPenjualan.EditValue = ""
        Me.RDJenisPenjualan.EnterMoveNextControl = True
        Me.RDJenisPenjualan.Location = New System.Drawing.Point(117, 316)
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
        Me.RDPenjualan.Location = New System.Drawing.Point(117, 261)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Langganan", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Lain", "Lain - Lain")})
        Me.RDPenjualan.Size = New System.Drawing.Size(212, 53)
        Me.RDPenjualan.TabIndex = 244
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 394)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Customer"
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(117, 391)
        Me.TxtKodeCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeCustomer.TabIndex = 250
        '
        'TxtNamaCustomer
        '
        Me.TxtNamaCustomer.EnterMoveNextControl = True
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(189, 391)
        Me.TxtNamaCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaCustomer.TabIndex = 252
        '
        'LblIDCustomer
        '
        Me.LblIDCustomer.AutoSize = True
        Me.LblIDCustomer.Location = New System.Drawing.Point(333, 367)
        Me.LblIDCustomer.Name = "LblIDCustomer"
        Me.LblIDCustomer.Size = New System.Drawing.Size(0, 13)
        Me.LblIDCustomer.TabIndex = 253
        Me.LblIDCustomer.Visible = False
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.EnterMoveNextControl = True
        Me.TxtNamaBarang.Location = New System.Drawing.Point(189, 435)
        Me.TxtNamaBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Properties.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaBarang.TabIndex = 256
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 438)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "Barang"
        '
        'TxtKodeBarang
        '
        Me.TxtKodeBarang.Location = New System.Drawing.Point(117, 435)
        Me.TxtKodeBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeBarang.Name = "TxtKodeBarang"
        Me.TxtKodeBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeBarang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeBarang.TabIndex = 254
        '
        'LblIDBarang
        '
        Me.LblIDBarang.AutoSize = True
        Me.LblIDBarang.Location = New System.Drawing.Point(333, 389)
        Me.LblIDBarang.Name = "LblIDBarang"
        Me.LblIDBarang.Size = New System.Drawing.Size(0, 13)
        Me.LblIDBarang.TabIndex = 257
        Me.LblIDBarang.Visible = False
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(117, 138)
        Me.TBDivisi.MainView = Me.GridView1
        Me.TBDivisi.Name = "TBDivisi"
        Me.TBDivisi.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RBEdit})
        Me.TBDivisi.Size = New System.Drawing.Size(212, 119)
        Me.TBDivisi.TabIndex = 258
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
        'RdPembayaran
        '
        Me.RdPembayaran.AutoSizeInLayoutControl = True
        Me.RdPembayaran.EditValue = "Semua"
        Me.RdPembayaran.EnterMoveNextControl = True
        Me.RdPembayaran.Location = New System.Drawing.Point(117, 364)
        Me.RdPembayaran.Margin = New System.Windows.Forms.Padding(1)
        Me.RdPembayaran.Name = "RdPembayaran"
        Me.RdPembayaran.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kontan", "Kontan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Kredit", "Kredit")})
        Me.RdPembayaran.Size = New System.Drawing.Size(212, 25)
        Me.RdPembayaran.TabIndex = 259
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(22, 367)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl5.TabIndex = 260
        Me.LabelControl5.Text = "Jenis Pembayaran"
        '
        'CmbKodePromo
        '
        Me.CmbKodePromo.Location = New System.Drawing.Point(117, 479)
        Me.CmbKodePromo.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbKodePromo.Name = "CmbKodePromo"
        Me.CmbKodePromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbKodePromo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbKodePromo.Size = New System.Drawing.Size(212, 20)
        Me.CmbKodePromo.TabIndex = 261
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 482)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Kode Promo"
        '
        'RdJenisLaporan
        '
        Me.RdJenisLaporan.AutoSizeInLayoutControl = True
        Me.RdJenisLaporan.EditValue = "Semua"
        Me.RdJenisLaporan.EnterMoveNextControl = True
        Me.RdJenisLaporan.Location = New System.Drawing.Point(117, 64)
        Me.RdJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RdJenisLaporan.Name = "RdJenisLaporan"
        Me.RdJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Bruto"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Netto"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Rekap"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Selisih"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Eksport")})
        Me.RdJenisLaporan.Size = New System.Drawing.Size(212, 48)
        Me.RdJenisLaporan.TabIndex = 263
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 67)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 264
        Me.LabelControl1.Text = "Jenis Laporan"
        '
        'CmbGroupBarang
        '
        Me.CmbGroupBarang.Location = New System.Drawing.Point(117, 457)
        Me.CmbGroupBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbGroupBarang.Name = "CmbGroupBarang"
        Me.CmbGroupBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbGroupBarang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbGroupBarang.Size = New System.Drawing.Size(212, 20)
        Me.CmbGroupBarang.TabIndex = 265
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 460)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Group Barang"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 504)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 268
        Me.Label8.Text = "No. DO"
        '
        'TxtNoDO
        '
        Me.TxtNoDO.Location = New System.Drawing.Point(117, 501)
        Me.TxtNoDO.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNoDO.Name = "TxtNoDO"
        Me.TxtNoDO.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtNoDO.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNoDO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtNoDO.Properties.ReadOnly = True
        Me.TxtNoDO.Size = New System.Drawing.Size(212, 20)
        Me.TxtNoDO.TabIndex = 267
        '
        'TxtIDDO
        '
        Me.TxtIDDO.EnterMoveNextControl = True
        Me.TxtIDDO.Location = New System.Drawing.Point(331, 501)
        Me.TxtIDDO.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDDO.Name = "TxtIDDO"
        Me.TxtIDDO.Properties.ReadOnly = True
        Me.TxtIDDO.Size = New System.Drawing.Size(30, 20)
        Me.TxtIDDO.TabIndex = 269
        Me.TxtIDDO.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(333, 411)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 273
        Me.Label9.Visible = False
        '
        'TxtNamaCorp
        '
        Me.TxtNamaCorp.EnterMoveNextControl = True
        Me.TxtNamaCorp.Location = New System.Drawing.Point(189, 413)
        Me.TxtNamaCorp.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaCorp.Name = "TxtNamaCorp"
        Me.TxtNamaCorp.Properties.ReadOnly = True
        Me.TxtNamaCorp.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaCorp.TabIndex = 272
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 416)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Corporate"
        '
        'TxtKodeCorp
        '
        Me.TxtKodeCorp.Location = New System.Drawing.Point(117, 413)
        Me.TxtKodeCorp.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeCorp.Name = "TxtKodeCorp"
        Me.TxtKodeCorp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCorp.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeCorp.TabIndex = 270
        '
        'LaporanPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 563)
        Me.Name = "LaporanPenjualan"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdPembayaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbGroupBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDDO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCorp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeCorp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreviewRekapBruto()
        Dim MyReport = New XRLaporanPenjualanNew
        If CmbKodePromo.SelectedItem <> "All" Then
            MyReport.LblTitle.Text = MyReport.LblTitle.Text & CmbKodePromo.SelectedItem.ToString.Split("-")(1)
        End If

        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

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

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG AND NOTA.TGL_PENGAKUAN BETWEEN LINK_BARANG_PROMO.TGL_AWAL AND LINK_BARANG_PROMO.TGL_AKHIR")

        Dim COND_TANPA_PRW = IIf(LblIDCustomer.Text = "", " AND LEN(DO.ID_PO) < 1 ", "")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(NOTA.NO_NOTA,DIVISI.NAMA,'') AS NO_NOTA, 
            NOTA.BATAL, 
            NOTA.NO_REF, 
            NOTA.TGL, 
            NOTA.TGL_PENGAKUAN, 
            REPLACE(NOTA.NO_DO,DIVISI.NAMA,'') AS NO_DO, 
            NOTA.ID_DO, 
            CONVERT(VARCHAR,DO.TGL_PENGAKUAN,1) TGL_DO, 
            NOTA.DIVISI, 
            NOTA.KODE_CUSTOMER, 
            NOTA.KODE_APPROVE, 
            CUSTOMER.NAMA AS NAMA_CUSTOMER, 
            DIVISI.NAMA AS NAMA_DIVISI, 
            BARANG.KODE, 
            BARANG.NAMA AS NAMA_BARANG, 
            DETAIL_NOTA.ISI, 
            DETAIL_NOTA.KOLI, 
            DETAIL_NOTA.QUANTITY, 
            DETAIL_NOTA.SATUAN, 
            DETAIL_NOTA.KONVERSI, 
            DETAIL_NOTA.PCS, 
            DETAIL_NOTA.HARGA, 
            USERS.NAMA_USER, 
            DETAIL_NOTA.DISC, 
            DETAIL_NOTA.DISKON_SATUAN, 
            CORP.KODE_CORPORATION AS KODE_CORP 
        FROM BARANG INNER JOIN NOTA INNER JOIN DETAIL_NOTA ON NOTA.ID_TRANSAKSI = DETAIL_NOTA.ID_TRANSAKSI ON BARANG.ID = DETAIL_NOTA.ID_BARANG 
            INNER JOIN (
                SELECT ID_TRANSAKSI, ID_PO, TGL_PENGAKUAN, SALES, PEMBAYARAN from DELIVERY_ORDER
                UNION ALL
                SELECT BON.ID_TRANSAKSI, DO.ID_PO, BON.TGL_PENGAKUAN, DO.SALES, DO.PEMBAYARAN  
                FROM DELIVERY_ORDER DO JOIN BON_PESANAN BON ON DO.ID_TRANSAKSI=BON.ID_DO
            ) DO ON NOTA.ID_DO=DO.ID_TRANSAKSI 
            INNER JOIN USERS ON DO.SALES = USERS.ID_USER 
            LEFT OUTER JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID 
            LEFT OUTER JOIN DIVISI ON NOTA.DIVISI = DIVISI.KODE " & JOIN_PROMO & " 
            LEFT JOIN LINK_CORPORATION_CUSTOMER CORP ON CUSTOMER.ID=CORP.ID_CUSTOMER 
        WHERE NOTA.BATAL=0 AND PCS>0 " & COND_TANPA_PRW & " AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(LblIDCustomer.Text = "", "", " AND NOTA.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(TxtKodeCorp.Text = "", "", " AND NOTA.KODE_CUSTOMER IN (SELECT ID_CUSTOMER FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKodeCorp.Text & "')") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_NOTA.ID_BARANG='" & LblIDBarang.Text & "'") &
    IIf(RdPembayaran.SelectedIndex = 0 Or RdPembayaran.SelectedIndex = -1, "", " AND DO.PEMBAYARAN='" & RdPembayaran.EditValue & "' ") &
    IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
    IIf(CmbKodePromo.SelectedItem = "All", "", " AND LINK_BARANG_PROMO.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split(" - ")(0) & "'") &
     IIf(TxtIDDO.Text = "", "", " AND NOTA.ID_DO='" & TxtIDDO.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewRekapNetto()
        Dim MyReport = New XRLaporanPenjualanNew
        If CmbKodePromo.SelectedItem <> "All" Then
            MyReport.LblTitle.Text = MyReport.LblTitle.Text & CmbKodePromo.SelectedItem.ToString.Split("-")(1)
        End If
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

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

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG AND NOTA.TGL_PENGAKUAN BETWEEN LINK_BARANG_PROMO.TGL_AWAL AND LINK_BARANG_PROMO.TGL_AKHIR")

        Dim COND_TANPA_PRW = IIf(LblIDCustomer.Text = "", " AND LEN(DO.ID_PO) < 1 ", "")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(NOTA.NO_NOTA,DIVISI.NAMA,'') AS NO_NOTA, NOTA.BATAL, NOTA.NO_REF, NOTA.TGL, NOTA.TGL_PENGAKUAN, REPLACE(NOTA.NO_DO,DIVISI.NAMA,'') AS NO_DO, NOTA.ID_DO, CONVERT(VARCHAR,DO.TGL_PENGAKUAN,1) TGL_DO, NOTA.DIVISI, NOTA.KODE_CUSTOMER, NOTA.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_NOTA.ISI, DETAIL_NOTA.KOLI, DETAIL_NOTA.QUANTITY, DETAIL_NOTA.SATUAN, DETAIL_NOTA.KONVERSI, DETAIL_NOTA.PCS, (((((((DETAIL_NOTA.HARGA-DETAIL_NOTA.DISKON_SATUAN)-NOTA.DISC_QTY)*(100-NOTA.DISC_REG)/100)*(100-NOTA.DISC_1)/100)*(100-NOTA.DISC_2)/100)*(100-NOTA.DISC_3)/100)*(100-NOTA.CASH_DISC)/100)*(100-NOTA.DISC_QTY1)/100 AS HARGA, USERS.NAMA_USER, DETAIL_NOTA.DISC, DETAIL_NOTA.DISKON_SATUAN, CORP.KODE_CORPORATION AS KODE_CORP 
        FROM BARANG INNER JOIN NOTA INNER JOIN DETAIL_NOTA ON NOTA.ID_TRANSAKSI = DETAIL_NOTA.ID_TRANSAKSI ON BARANG.ID = DETAIL_NOTA.ID_BARANG INNER JOIN ( SELECT ID_TRANSAKSI, ID_PO, TGL_PENGAKUAN, SALES, PEMBAYARAN from DELIVERY_ORDER
            UNION ALL
            SELECT BON.ID_TRANSAKSI, DO.ID_PO, BON.TGL_PENGAKUAN, DO.SALES, DO.PEMBAYARAN  
            FROM DELIVERY_ORDER DO JOIN BON_PESANAN BON ON DO.ID_TRANSAKSI=BON.ID_DO
            ) DO ON NOTA.ID_DO=DO.ID_TRANSAKSI INNER JOIN USERS ON DO.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON NOTA.DIVISI = DIVISI.KODE " & JOIN_PROMO & " LEFT JOIN LINK_CORPORATION_CUSTOMER CORP ON CUSTOMER.ID=CORP.ID_CUSTOMER WHERE NOTA.BATAL=0 AND PCS>0 " & COND_TANPA_PRW & " AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(LblIDCustomer.Text = "", "", " AND NOTA.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(TxtKodeCorp.Text = "", "", " AND NOTA.KODE_CUSTOMER IN (SELECT ID_CUSTOMER FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKodeCorp.Text & "')") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_NOTA.ID_BARANG='" & LblIDBarang.Text & "'") &
    IIf(RdPembayaran.SelectedIndex = 0 Or RdPembayaran.SelectedIndex = -1, "", " AND DO.PEMBAYARAN='" & RdPembayaran.EditValue & "' ") &
        IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
        IIf(CmbKodePromo.SelectedItem = "All", "", " AND LINK_BARANG_PROMO.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split(" - ")(0) & "'") &
    IIf(TxtIDDO.Text = "", "", " AND NOTA.ID_DO='" & TxtIDDO.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportRekap()
        Dim MyReport = New XRLaporanRekapPenjualan
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "A.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO D ON DN.ID_BARANG=D.ID_BARANG AND N.TGL_PENGAKUAN BETWEEN D.TGL_AWAL AND D.TGL_AKHIR ")

        Dim COND_TANPA_PRW = IIf(LblIDCustomer.Text = "", " AND LEN(DO.ID_PO) < 1 ", "")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT B.NAMA NAMA_CUSTOMER, SUM(AA.PCS) PCS, SUM(AA.REG_DISC) REG_DISC, SUM(AA.ADD_DISC) ADD_DISC, SUM(AA.CASH_DISC) CASH_DISC, SUM(AA.SUBTOTAL) BRUTO, SUM(AA.SUBTOTAL-AA.REG_DISC-AA.ADD_DISC-AA.CASH_DISC) NETTO, C.NAMA NAMA_DIVISI FROM NOTA A JOIN (SELECT N.ID_TRANSAKSI, SUM(PCS) PCS, SUM(DN.PCS*(DN.HARGA-DN.DISKON_SATUAN)) SUBTOTAL, SUM(DN.PCS*(DN.HARGA-DN.DISKON_SATUAN))/N.SUBTOTAL*N.DISC_REG_NOMINAL REG_DISC, SUM(DN.PCS*(DN.HARGA-DN.DISKON_SATUAN))/N.SUBTOTAL*(N.DISC_1_NOMINAL+N.DISC_2_NOMINAL+N.DISC_3_NOMINAL) ADD_DISC, SUM(DN.PCS*(DN.HARGA-DN.DISKON_SATUAN))/N.SUBTOTAL*N.CASH_DISC_NOMINAL CASH_DISC FROM NOTA N JOIN DETAIL_NOTA DN ON N.ID_TRANSAKSI=DN.ID_TRANSAKSI JOIN (
                SELECT ID_TRANSAKSI, ID_PO, TGL_PENGAKUAN, SALES, PEMBAYARAN from DELIVERY_ORDER
                UNION ALL
                SELECT BON.ID_TRANSAKSI, DO.ID_PO, BON.TGL_PENGAKUAN, DO.SALES, DO.PEMBAYARAN  
                FROM DELIVERY_ORDER DO JOIN BON_PESANAN BON ON DO.ID_TRANSAKSI=BON.ID_DO
            ) DO ON N.ID_DO=DO.ID_TRANSAKSI " & JOIN_PROMO & " WHERE PCS>0 " & COND_TANPA_PRW & " " & IIf(RdPembayaran.SelectedIndex = 0 Or RdPembayaran.SelectedIndex = -1, "", " AND DO.PEMBAYARAN='" & RdPembayaran.EditValue & "' ") & IIf(LblIDBarang.Text = "", "", " AND DN.ID_BARANG='" & LblIDBarang.Text & "'") & IIf(CmbKodePromo.SelectedItem = "All", "", " AND D.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split(" - ")(0) & "'") & " GROUP BY N.ID_TRANSAKSI, N.SUBTOTAL, N.DISC_REG_NOMINAL, N.DISC_1_NOMINAL, N.DISC_2_NOMINAL, N.DISC_3_NOMINAL, N.CASH_DISC_NOMINAL) AA ON A.ID_TRANSAKSI=AA.ID_TRANSAKSI JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN DIVISI C ON A.DIVISI=C.KODE WHERE A.BATAL=0 AND PCS>0 AND CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(LblIDCustomer.Text = "", "", " AND A.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(TxtKodeCorp.Text = "", "", " AND A.KODE_CUSTOMER IN (SELECT ID_CUSTOMER FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKodeCorp.Text & "')") &
    IIf(TxtIDDO.Text = "", "", " AND A.ID_DO='" & TxtIDDO.Text & "'") & " GROUP BY B.NAMA, C.NAMA")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewSelisih()
        Dim MyReport = New XRLaporanSelisihPenjualan
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

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

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All", "", " JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG AND NOTA.TGL_PENGAKUAN BETWEEN LINK_BARANG_PROMO.TGL_AWAL AND LINK_BARANG_PROMO.TGL_AKHIR")

        Dim COND_TANPA_PRW = IIf(LblIDCustomer.Text = "", " AND LEN(DO.ID_PO) < 1 ", "")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT  DISTINCT REPLACE(NOTA.NO_NOTA,DIVISI.NAMA,'') AS NO_NOTA, NOTA.BATAL, NOTA.NO_REF, NOTA.TGL, NOTA.TGL_PENGAKUAN, REPLACE(NOTA.NO_DO,DIVISI.NAMA,'') AS NO_DO, NOTA.ID_DO, NOTA.DIVISI, NOTA.KODE_CUSTOMER, NOTA.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_NOTA.ISI, DETAIL_NOTA.KOLI, DETAIL_NOTA.QUANTITY, DETAIL_NOTA.SATUAN, DETAIL_NOTA.KONVERSI, DETAIL_NOTA.PCS, DETAIL_NOTA.HARGA, USERS.NAMA_USER, DETAIL_NOTA.DISC, DETAIL_NOTA.DISKON_SATUAN, PL.HARGA_BARU FROM BARANG INNER JOIN NOTA INNER JOIN DETAIL_NOTA ON NOTA.ID_TRANSAKSI = DETAIL_NOTA.ID_TRANSAKSI ON BARANG.ID = DETAIL_NOTA.ID_BARANG INNER JOIN (
            SELECT ID_TRANSAKSI, ID_PO, TGL_PENGAKUAN, SALES, PEMBAYARAN from DELIVERY_ORDER
            UNION ALL
            SELECT BON.ID_TRANSAKSI, DO.ID_PO, BON.TGL_PENGAKUAN, DO.SALES, DO.PEMBAYARAN  
            FROM DELIVERY_ORDER DO JOIN BON_PESANAN BON ON DO.ID_TRANSAKSI=BON.ID_DO
            ) DO ON NOTA.ID_DO=DO.ID_TRANSAKSI INNER JOIN USERS ON DO.SALES = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON NOTA.DIVISI = DIVISI.KODE " & JOIN_PROMO & " LEFT JOIN (SELECT PL.* FROM VI_PRICE_LIST_UMUM PL JOIN (SELECT ID_BARANG, MAX(TGL_PRICE) TGL FROM VI_PRICE_LIST_UMUM GROUP BY ID_BARANG ) LS ON PL.ID_BARANG=LS.ID_BARANG AND PL.TGL_PRICE=LS.TGL) PL ON BARANG.ID=PL.ID_BARANG WHERE NOTA.BATAL=0 AND PCS>0 " & COND_TANPA_PRW & " AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(LblIDCustomer.Text = "", "", " AND NOTA.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(TxtKodeCorp.Text = "", "", " AND NOTA.KODE_CUSTOMER IN (SELECT ID_CUSTOMER FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKodeCorp.Text & "')") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_NOTA.ID_BARANG='" & LblIDBarang.Text & "'") &
    IIf(RdPembayaran.SelectedIndex = 0 Or RdPembayaran.SelectedIndex = -1, "", " AND DO.PEMBAYARAN='" & RdPembayaran.EditValue & "' ") &
    IIf(CmbGroupBarang.SelectedItem = "All", "", " AND BARANG.GROUP_BARANG='" & CmbGroupBarang.SelectedItem.ToString.Split(" - ")(0) & "'") &
    IIf(CmbKodePromo.SelectedItem = "All", "", " AND LINK_BARANG_PROMO.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split(" - ")(0) & "'") &
     IIf(TxtIDDO.Text = "", "", " AND NOTA.ID_DO='" & TxtIDDO.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewEksport()
        Dim MyReport = New XRLaporanPenjualanEksport

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

        Dim cond As String = " AND NOTA.BATAL=0
            AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) 
            AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
            IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
            IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
            IIf(LblIDCustomer.Text = "", "", " AND NOTA.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
            IIf(TxtKodeCorp.Text = "", "", " AND NOTA.KODE_CUSTOMER IN (SELECT ID_CUSTOMER FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKodeCorp.Text & "')") &
            IIf(RdPembayaran.SelectedIndex = 0 Or RdPembayaran.SelectedIndex = -1, "", " AND DELIVERY_ORDER.PEMBAYARAN='" & RdPembayaran.EditValue & "' ") &
             IIf(TxtIDDO.Text = "", "", " AND NOTA.ID_DO='" & TxtIDDO.Text & "'")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT *, RTRIM(SUBSTRING(TEMP_PO, 0,
					                    IIF(CHARINDEX(CHAR(13)+CHAR(10), TEMP_PO) = 0, 
						                    IIF(CHARINDEX(' ', TEMP_PO) = 0, 
							                    LEN(TEMP_PO)+1, 
							                    CHARINDEX(' ', TEMP_PO)), 
						                    CHARINDEX(CHAR(13)+CHAR(10), TEMP_PO)))) NO_PO,
							  RTRIM(SUBSTRING(TEMP_SUPP, 0,
					                    IIF(CHARINDEX(CHAR(13)+CHAR(10), TEMP_SUPP) = 0, 
						                    IIF(CHARINDEX(' ', TEMP_SUPP) = 0, 
							                    LEN(TEMP_SUPP)+1, 
							                    CHARINDEX(' ', TEMP_SUPP)), 
						                    CHARINDEX(CHAR(13)+CHAR(10), TEMP_SUPP)))) NO_SUPP
                    FROM (
                    SELECT	IIF(CUSTOMER.GROUP_CUSTOMER = 'Distributor', 'Distributor',
			                    IIF(CHARINDEX('*', CUSTOMER.NAMA) > 0, 'Supermarket', 'Supermarket Kecil')) KELOMPOK,
		                    NOTA.ID_TRANSAKSI, NOTA.NO_NOTA, NOTA.TGL_PENGAKUAN, CUSTOMER.KODE_APPROVE, CUSTOMER.NAMA, 
		                    DELIVERY_ORDER.PEMBAYARAN, DELIVERY_ORDER.TERMS, DELIVERY_ORDER.DIVISI KODE_DIVISI, DIVISI.NAMA AS NAMA_DIVISI,
		                    NOTA.SUBTOTAL AS BRUTO, NOTA.DISC_REG_NOMINAL, NOTA.DISC_1_NOMINAL+NOTA.DISC_2_NOMINAL+NOTA.DISC_3_NOMINAL AS ADD_DISC,
		                    NOTA.DPP, CORPORATION.KODE, CORPORATION.NAMA NAMA_CORP, PT.KODE KODE_PT, PT.NAMA NAMA_PT,
		                    LTRIM(REPLACE(REPLACE(
				                    SUBSTRING(NOTA.KETERANGAN_CETAK, 
					                    IIF(CHARINDEX('NO PO', NOTA.KETERANGAN_CETAK) = 0, 
						                    LEN(NOTA.KETERANGAN_CETAK)+1, 
						                    CHARINDEX('NO PO', NOTA.KETERANGAN_CETAK) + 5), 
					                    LEN(NOTA.KETERANGAN_CETAK))
				                    , ':', ''), ';', ' ')) TEMP_PO,
                            LTRIM(REPLACE(REPLACE(
				                    SUBSTRING(NOTA.KETERANGAN_CETAK, 
					                    IIF(CHARINDEX('NO SUPP', NOTA.KETERANGAN_CETAK) = 0, 
						                    LEN(NOTA.KETERANGAN_CETAK)+1, 
						                    CHARINDEX('NO SUPP', NOTA.KETERANGAN_CETAK) + 7), 
					                    LEN(NOTA.KETERANGAN_CETAK))
				                    , ':', ''), ';', ' ')) TEMP_SUPP
                    FROM NOTA LEFT JOIN DELIVERY_ORDER ON NOTA.ID_DO=DELIVERY_ORDER.ID_TRANSAKSI
                    LEFT JOIN CUSTOMER ON DELIVERY_ORDER.KODE_CUSTOMER=CUSTOMER.ID 
                    LEFT JOIN LINK_CORPORATION_CUSTOMER LC ON CUSTOMER.ID=LC.ID_CUSTOMER
                    LEFT JOIN CORPORATION ON CORPORATION.KODE=LC.KODE_CORPORATION
                    LEFT JOIN DIVISI ON DELIVERY_ORDER.DIVISI=DIVISI.KODE 
					LEFT JOIN LINK_SBU_DIVISI ON DIVISI.KODE=LINK_SBU_DIVISI.KODE_DIVISI
					LEFT JOIN LINK_PT_SBU ON LINK_SBU_DIVISI.KODE_SBU=LINK_PT_SBU.KODE_SBU
					LEFT JOIN PT ON LINK_PT_SBU.KODE_PT=PT.KODE
					WHERE LEN(DELIVERY_ORDER.ID_PO) = 0
                    " & cond & " ) Z")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN PENJUALAN"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        loadDivisi()
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

    'Customer
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        LblIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan)
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeCustomer.KeyPress
        If CharKeypress(TxtKodeCustomer, e) Then LblIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan)
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles LblIDCustomer.TextChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & LblIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeCustomer.Text = ""
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeBarang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeBarang.ButtonClick
        LblIDBarang.Text = Search(FrmPencarian.KeyPencarian.Barang_Divisi, , , , , "%%")
    End Sub

    Private Sub TxtKodeBarang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeBarang.KeyPress
        If CharKeypress(TxtKodeBarang, e) Then LblIDBarang.Text = Search(FrmPencarian.KeyPencarian.Barang_Divisi, , , , , "%%")
    End Sub

    Private Sub LblIDBarang_TextChanged(sender As Object, e As System.EventArgs) Handles LblIDBarang.TextChanged
        Using dtBarang = SelectCon.execute("SELECT KODE,NAMA FROM BARANG WHERE ID='" & LblIDBarang.Text & "'")
            If dtBarang.Rows.Count > 0 Then
                TxtKodeBarang.Text = dtBarang.Rows(0).Item("KODE")
                TxtNamaBarang.Text = dtBarang.Rows(0).Item("NAMA")
            Else
                TxtKodeBarang.Text = ""
                TxtNamaBarang.Text = ""
            End If
        End Using
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        If RdJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreviewRekapBruto()
        ElseIf RdJenisLaporan.SelectedIndex = 1 Then
            ReportShowPreviewRekapNetto()
        ElseIf RdJenisLaporan.SelectedIndex = 2 Then
            ReportRekap()
        ElseIf RdJenisLaporan.SelectedIndex = 3 Then
            ReportShowPreviewSelisih()
        ElseIf RdJenisLaporan.SelectedIndex = 4 Then
            ReportShowPreviewEksport()
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

    Private Sub RdJenisLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RdJenisLaporan.SelectedIndexChanged
        If RdJenisLaporan.SelectedIndex = 4 Then
            TxtKodeBarang.Text = ""
            TxtKodeBarang.Enabled = False
            CmbGroupBarang.Enabled = False
            CmbKodePromo.Enabled = False
        Else
            TxtKodeBarang.Enabled = True
            CmbGroupBarang.Enabled = True
            CmbKodePromo.Enabled = True
        End If
    End Sub

    Private Sub TxtKodeCorp_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeCorp.ButtonClick
        TxtKodeCorp.Text = Search(FrmPencarian.KeyPencarian.Corporate)
    End Sub
    Private Sub TxtKodeCorp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeCorp.KeyPress
        If CharKeypress(TxtKodeCorp, e) Then TxtKodeCorp.Text = Search(FrmPencarian.KeyPencarian.Corporate)
    End Sub
    Private Sub TxtKodeCorp_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeCorp.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE,NAMA FROM CORPORATION WHERE KODE='" & TxtKodeCorp.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeCorp.Text = dtCustomer.Rows(0).Item("KODE")
                TxtNamaCorp.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeCorp.Text = ""
                TxtNamaCorp.Text = ""
            End If
        End Using
    End Sub
End Class
