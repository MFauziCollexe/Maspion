Imports DevExpress.XtraCharts

Public Class LaporanReturPenjualan
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LblIDBarang As System.Windows.Forms.Label
    Friend WithEvents TxtNamaBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeBarang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TBDivisi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RdJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblIDCustomer As System.Windows.Forms.Label
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbKodePromo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtKodeCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNamaBarang = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtKodeBarang = New DevExpress.XtraEditors.ButtonEdit()
        Me.LblIDBarang = New System.Windows.Forms.Label()
        Me.TBDivisi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RdJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LblIDCustomer = New System.Windows.Forms.Label()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbKodePromo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label6)
        Me.XtraScrollableControl1.Controls.Add(Me.CmbKodePromo)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.RDPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.LblIDCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.RdJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.TBDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.LblIDBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LblIDBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TBDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LblIDCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.CmbKodePromo, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label6, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 94)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(117, 91)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(230, 91)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 94)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 116)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi  "
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(117, 359)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(212, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 316)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Customer"
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(117, 313)
        Me.TxtKodeCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeCustomer.TabIndex = 250
        '
        'TxtNamaCustomer
        '
        Me.TxtNamaCustomer.EnterMoveNextControl = True
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(189, 313)
        Me.TxtNamaCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaCustomer.TabIndex = 252
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.EnterMoveNextControl = True
        Me.TxtNamaBarang.Location = New System.Drawing.Point(189, 335)
        Me.TxtNamaBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Properties.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(140, 20)
        Me.TxtNamaBarang.TabIndex = 256
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 338)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "Barang"
        '
        'TxtKodeBarang
        '
        Me.TxtKodeBarang.Location = New System.Drawing.Point(117, 335)
        Me.TxtKodeBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeBarang.Name = "TxtKodeBarang"
        Me.TxtKodeBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeBarang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeBarang.TabIndex = 254
        '
        'LblIDBarang
        '
        Me.LblIDBarang.AutoSize = True
        Me.LblIDBarang.Location = New System.Drawing.Point(333, 316)
        Me.LblIDBarang.Name = "LblIDBarang"
        Me.LblIDBarang.Size = New System.Drawing.Size(0, 13)
        Me.LblIDBarang.TabIndex = 257
        Me.LblIDBarang.Visible = False
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(117, 115)
        Me.TBDivisi.MainView = Me.GridView1
        Me.TBDivisi.Margin = New System.Windows.Forms.Padding(1)
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
        'RdJenisLaporan
        '
        Me.RdJenisLaporan.AutoSizeInLayoutControl = True
        Me.RdJenisLaporan.EditValue = "Semua"
        Me.RdJenisLaporan.EnterMoveNextControl = True
        Me.RdJenisLaporan.Location = New System.Drawing.Point(117, 64)
        Me.RdJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RdJenisLaporan.Name = "RdJenisLaporan"
        Me.RdJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Bruto"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Netto"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap", "Rekap")})
        Me.RdJenisLaporan.Size = New System.Drawing.Size(212, 25)
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
        'LblIDCustomer
        '
        Me.LblIDCustomer.AutoSize = True
        Me.LblIDCustomer.Location = New System.Drawing.Point(333, 294)
        Me.LblIDCustomer.Name = "LblIDCustomer"
        Me.LblIDCustomer.Size = New System.Drawing.Size(0, 13)
        Me.LblIDCustomer.TabIndex = 265
        Me.LblIDCustomer.Visible = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(22, 236)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl6.TabIndex = 267
        Me.LabelControl6.Text = "Jenis Transaksi"
        '
        'RDPenjualan
        '
        Me.RDPenjualan.AutoSizeInLayoutControl = True
        Me.RDPenjualan.EditValue = ""
        Me.RDPenjualan.EnterMoveNextControl = True
        Me.RDPenjualan.Location = New System.Drawing.Point(117, 236)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Distributor", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Lain - lain", "Lain - Lain")})
        Me.RDPenjualan.Size = New System.Drawing.Size(212, 53)
        Me.RDPenjualan.TabIndex = 266
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 294)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 269
        Me.Label6.Text = "Kode Promo"
        '
        'CmbKodePromo
        '
        Me.CmbKodePromo.Location = New System.Drawing.Point(117, 291)
        Me.CmbKodePromo.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbKodePromo.Name = "CmbKodePromo"
        Me.CmbKodePromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbKodePromo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CmbKodePromo.Size = New System.Drawing.Size(212, 20)
        Me.CmbKodePromo.TabIndex = 268
        '
        'LaporanReturPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 563)
        Me.Name = "LaporanReturPenjualan"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbKodePromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreviewRekapBruto()
        Dim MyReport = New XRLaporanPenjualan
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = "LAPORAN RETUR PENJUALAN BRUTO " & IIf(CmbKodePromo.SelectedItem = "All - Semua", "", CmbKodePromo.SelectedItem.ToString.Split("-")(1).Trim)
        MyReport.LblNoNota.Text = "No. Retur"
        MyReport.LblNoDO.Text = "No. Nota"

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "RETUR_PENJUALAN.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " JOIN LINK_BARANG_PROMO PR ON BARANG.ID=PR.ID_BARANG AND RETUR_PENJUALAN.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(RETUR_PENJUALAN.NO_NOTA_RETUR,DIVISI.NAMA,'') AS NO_NOTA, RETUR_PENJUALAN.BATAL, RETUR_PENJUALAN.NO_TTB, RETUR_PENJUALAN.TGL, RETUR_PENJUALAN.TGL_PENGAKUAN, REPLACE(RETUR_PENJUALAN.NO_NOTA,DIVISI.NAMA,'') AS NO_DO, RETUR_PENJUALAN.NO_NOTA, RETUR_PENJUALAN.DIVISI, RETUR_PENJUALAN.KODE_CUSTOMER, RETUR_PENJUALAN.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_RETUR_PENJUALAN.ISI, DETAIL_RETUR_PENJUALAN.KOLI, DETAIL_RETUR_PENJUALAN.PCS AS QUANTITY, BARANG.SAT_SUPER1 SATUAN, DETAIL_RETUR_PENJUALAN.KONVERSI, DETAIL_RETUR_PENJUALAN.PCS, DETAIL_RETUR_PENJUALAN.HARGA, USERS.NAMA_USER, DETAIL_RETUR_PENJUALAN.DISC, DETAIL_RETUR_PENJUALAN.DISKON_SATUAN, CORP.KODE_CORPORATION AS KODE_CORP FROM BARANG INNER JOIN RETUR_PENJUALAN INNER JOIN DETAIL_RETUR_PENJUALAN ON RETUR_PENJUALAN.ID_TRANSAKSI = DETAIL_RETUR_PENJUALAN.ID_TRANSAKSI ON BARANG.ID = DETAIL_RETUR_PENJUALAN.ID_BARANG INNER JOIN USERS ON RETUR_PENJUALAN.CRUSER = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON RETUR_PENJUALAN.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON RETUR_PENJUALAN.DIVISI = DIVISI.KODE LEFT JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG LEFT JOIN LINK_CORPORATION_CUSTOMER CORP ON CUSTOMER.ID=CORP.ID_CUSTOMER " & JOIN_PROMO & " WHERE PCS > 0 AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(LblIDCustomer.Text = "", "", " AND RETUR_PENJUALAN.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND CUSTOMER.GROUP_CUSTOMER ='" & RDPenjualan.EditValue & "' ") &
    IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_RETUR_PENJUALAN.ID_BARANG='" & LblIDBarang.Text & "'"))
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewRekapNetto()
        Dim MyReport = New XRLaporanPenjualan
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = "LAPORAN RETUR PENJUALAN NETTO " & IIf(CmbKodePromo.SelectedItem = "All - Semua", "", CmbKodePromo.SelectedItem.ToString.Split("-")(1).Trim)
        MyReport.LblNoNota.Text = "No. Retur"
        MyReport.LblNoDO.Text = "No. Nota"

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "RETUR_PENJUALAN.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " JOIN LINK_BARANG_PROMO PR ON BARANG.ID=PR.ID_BARANG AND RETUR_PENJUALAN.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(RETUR_PENJUALAN.NO_NOTA_RETUR,DIVISI.NAMA,'') AS NO_NOTA, RETUR_PENJUALAN.BATAL, RETUR_PENJUALAN.NO_TTB, RETUR_PENJUALAN.TGL, RETUR_PENJUALAN.TGL_PENGAKUAN, RETUR_PENJUALAN.NO_TTB AS NO_DO, RETUR_PENJUALAN.ID_TTB, RETUR_PENJUALAN.DIVISI, RETUR_PENJUALAN.KODE_CUSTOMER, RETUR_PENJUALAN.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_RETUR_PENJUALAN.ISI, DETAIL_RETUR_PENJUALAN.KOLI, DETAIL_RETUR_PENJUALAN.PCS AS QUANTITY, BARANG.SAT_SUPER1 AS SATUAN, DETAIL_RETUR_PENJUALAN.KONVERSI, DETAIL_RETUR_PENJUALAN.PCS, (((((((DETAIL_RETUR_PENJUALAN.HARGA-DETAIL_RETUR_PENJUALAN.DISKON_SATUAN)-RETUR_PENJUALAN.DISC_QTY)*(100-RETUR_PENJUALAN.DISC_REG)/100)*(100-RETUR_PENJUALAN.DISC_1)/100)*(100-RETUR_PENJUALAN.DISC_2)/100)*(100-RETUR_PENJUALAN.DISC_3)/100)*(100-RETUR_PENJUALAN.CASH_DISC)/100)*(100-(DISC_QTY_NOMINAL1/(SUBTOTAL-DISC_QTY_NOMINAL-DISC_REG_NOMINAL-DISC_1_NOMINAL-DISC_2_NOMINAL-DISC_3_NOMINAL-CASH_DISC_NOMINAL)*100))/100 AS HARGA, USERS.NAMA_USER, DETAIL_RETUR_PENJUALAN.DISC, DETAIL_RETUR_PENJUALAN.DISKON_SATUAN, CORP.KODE_CORPORATION AS KODE_CORP FROM BARANG INNER JOIN RETUR_PENJUALAN INNER JOIN DETAIL_RETUR_PENJUALAN ON RETUR_PENJUALAN.ID_TRANSAKSI = DETAIL_RETUR_PENJUALAN.ID_TRANSAKSI ON BARANG.ID = DETAIL_RETUR_PENJUALAN.ID_BARANG INNER JOIN USERS ON RETUR_PENJUALAN.CRUSER = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON RETUR_PENJUALAN.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON RETUR_PENJUALAN.DIVISI = DIVISI.KODE LEFT JOIN LINK_CORPORATION_CUSTOMER CORP ON CUSTOMER.ID=CORP.ID_CUSTOMER " & JOIN_PROMO & " WHERE PCS>0 AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(LblIDCustomer.Text = "", "", " AND RETUR_PENJUALAN.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND CUSTOMER.GROUP_CUSTOMER ='" & RDPenjualan.EditValue & "' ") &
    IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_RETUR_PENJUALAN.ID_BARANG='" & LblIDBarang.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    '   Private Sub ReportShowPreviewRekap()
    '       Dim MyReport = New XRLaporanRekapReturPenjualan
    '       MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

    '       Dim filter As String = " AND ("
    '       For Each r As DataRow In dtDivisi.Rows
    '           If r(2) Then
    '               If filter <> " AND (" Then
    '                   filter = filter & " OR "
    '               End If
    '               filter = filter & "RETUR_PENJUALAN.DIVISI='" & r(0) & "' "
    '           End If
    '       Next
    '       filter = filter & ") "
    '       If filter = " AND () " Then filter = ""

    '       Dim JOIN_PROMO = " JOIN DETAIL_RETUR_PENJUALAN ON RETUR_PENJUALAN.ID_TRANSAKSI=DETAIL_RETUR_PENJUALAN.ID_TRANSAKSI JOIN BARANG ON BARANG.ID=DETAIL_RETUR_PENJUALAN.ID_BARANG JOIN LINK_BARANG_PROMO LP ON BARANG.ID=LP.ID_BARANG AND RETUR_PENJUALAN.TGL BETWEEN LP.TGL_AWAL AND LP.TGL_AKHIR "

    '       Report = MyReport
    '       Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(RETUR_PENJUALAN.NO_NOTA_RETUR,DIVISI.NAMA,'') AS NO_NOTA, RETUR_PENJUALAN.BATAL, RETUR_PENJUALAN.NO_TTB, RETUR_PENJUALAN.TGL, RETUR_PENJUALAN.TGL_PENGAKUAN, REPLACE(RETUR_PENJUALAN.NO_NOTA,DIVISI.NAMA,'') AS NO_DO, RETUR_PENJUALAN.NO_NOTA, RETUR_PENJUALAN.DIVISI, RETUR_PENJUALAN.KODE_CUSTOMER, RETUR_PENJUALAN.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER, RETUR_PENJUALAN.SUBTOTAL, RETUR_PENJUALAN.DPP, RETUR_PENJUALAN.PPN, RETUR_PENJUALAN.KETERANGAN_CETAK FROM RETUR_PENJUALAN " & IIf(CmbKodePromo.SelectedItem = "All - Semua", "", JOIN_PROMO) & " INNER JOIN USERS ON RETUR_PENJUALAN.CRUSER = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON RETUR_PENJUALAN.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON RETUR_PENJUALAN.DIVISI = DIVISI.KODE WHERE CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    'IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND CUSTOMER.GROUP_CUSTOMER ='" & RDPenjualan.EditValue & "' ") &
    '   IIf(LblIDCustomer.Text = "", "", " AND RETUR_PENJUALAN.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    '   IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " AND LP.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'"))
    '       Report.DataMember = Nothing
    '       Report.CreateDocument()
    '       DocumentViewer1.DocumentSource = Report
    '   End Sub

    Private Sub ReportShowPreviewRekap()
        Dim MyReport = New XRLaporanRekapReturPenjualan
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "RETUR_PENJUALAN.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Dim JOIN_PROMO As String = IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " JOIN LINK_BARANG_PROMO PR ON BARANG.ID=PR.ID_BARANG AND RETUR_PENJUALAN.TGL_PENGAKUAN BETWEEN PR.TGL_AWAL AND PR.TGL_AKHIR")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT NO_NOTA, BATAL, NO_TTB, TGL, TGL_PENGAKUAN, DIVISI, KODE_CUSTOMER, KODE_APPROVE, NAMA_CUSTOMER, NAMA_DIVISI, NAMA_USER, SUM(QUANTITY*HARGA_BRUTO) SUBTOTAL, SUM(QUANTITY*HARGA) DPP, IIF(PPN > 0, SUM(QUANTITY*HARGA)*0.1, 0) PPN, KETERANGAN_CETAK FROM
(
SELECT DISTINCT REPLACE(RETUR_PENJUALAN.NO_NOTA_RETUR,DIVISI.NAMA,'') AS NO_NOTA, RETUR_PENJUALAN.BATAL, RETUR_PENJUALAN.NO_TTB, RETUR_PENJUALAN.TGL, RETUR_PENJUALAN.TGL_PENGAKUAN, RETUR_PENJUALAN.NO_TTB AS NO_DO, RETUR_PENJUALAN.ID_TTB, RETUR_PENJUALAN.DIVISI, RETUR_PENJUALAN.KODE_CUSTOMER, RETUR_PENJUALAN.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, DETAIL_RETUR_PENJUALAN.ISI, DETAIL_RETUR_PENJUALAN.KOLI, DETAIL_RETUR_PENJUALAN.PCS AS QUANTITY, BARANG.SAT_SUPER1 AS SATUAN, DETAIL_RETUR_PENJUALAN.KONVERSI, DETAIL_RETUR_PENJUALAN.PCS, (((((((DETAIL_RETUR_PENJUALAN.HARGA-DETAIL_RETUR_PENJUALAN.DISKON_SATUAN)-RETUR_PENJUALAN.DISC_QTY)*(100-RETUR_PENJUALAN.DISC_REG)/100)*(100-RETUR_PENJUALAN.DISC_1)/100)*(100-RETUR_PENJUALAN.DISC_2)/100)*(100-RETUR_PENJUALAN.DISC_3)/100)*(100-RETUR_PENJUALAN.CASH_DISC)/100)*(100-(DISC_QTY_NOMINAL1/(SUBTOTAL-DISC_QTY_NOMINAL-DISC_REG_NOMINAL-DISC_1_NOMINAL-DISC_2_NOMINAL-DISC_3_NOMINAL-CASH_DISC_NOMINAL)*100))/100 AS HARGA, DETAIL_RETUR_PENJUALAN.HARGA-DETAIL_RETUR_PENJUALAN.DISKON_SATUAN AS HARGA_BRUTO,USERS.NAMA_USER, DETAIL_RETUR_PENJUALAN.DISC, DETAIL_RETUR_PENJUALAN.DISKON_SATUAN, CORP.KODE_CORPORATION AS KODE_CORP, RETUR_PENJUALAN.KETERANGAN_CETAK, RETUR_PENJUALAN.PPN FROM BARANG INNER JOIN RETUR_PENJUALAN INNER JOIN DETAIL_RETUR_PENJUALAN ON RETUR_PENJUALAN.ID_TRANSAKSI = DETAIL_RETUR_PENJUALAN.ID_TRANSAKSI ON BARANG.ID = DETAIL_RETUR_PENJUALAN.ID_BARANG INNER JOIN USERS ON RETUR_PENJUALAN.CRUSER = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON RETUR_PENJUALAN.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON RETUR_PENJUALAN.DIVISI = DIVISI.KODE LEFT JOIN LINK_CORPORATION_CUSTOMER CORP ON CUSTOMER.ID=CORP.ID_CUSTOMER " & JOIN_PROMO & " WHERE PCS>0 AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,RETUR_PENJUALAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter &
    IIf(LblIDCustomer.Text = "", "", " AND RETUR_PENJUALAN.KODE_CUSTOMER='" & LblIDCustomer.Text & "'") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND CUSTOMER.GROUP_CUSTOMER ='" & RDPenjualan.EditValue & "' ") &
    IIf(CmbKodePromo.SelectedItem = "All - Semua", "", " AND PR.KODE_PROMO='" & CmbKodePromo.SelectedItem.ToString.Split("-")(0).Trim & "'") &
    IIf(LblIDBarang.Text = "", "", " AND DETAIL_RETUR_PENJUALAN.ID_BARANG='" & LblIDBarang.Text & "'") &
    ") G GROUP BY NO_NOTA, BATAL, NO_TTB, TGL, TGL_PENGAKUAN, DIVISI, KODE_CUSTOMER, KODE_APPROVE, NAMA_CUSTOMER, NAMA_DIVISI, NAMA_USER, KETERANGAN_CETAK, PPN")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN RETUR PENJUALAN"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        loadDivisi()
        CmbKodePromo.Properties.Items.Add("All - Semua")
        Using dt = SelectCon.execute("SELECT KODE + ' - ' + NAMA_PROMO FROM PROMO")
            For Each R In dt.Rows
                CmbKodePromo.Properties.Items.Add(R(0))
            Next
        End Using
        CmbKodePromo.SelectedItem = "All - Semua"
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
            ReportShowPreviewRekap()
        End If
    End Sub

    Private Sub RdJenisLaporan_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RdJenisLaporan.SelectedIndexChanged
        If RdJenisLaporan.SelectedIndex = 2 Then
            TxtKodeBarang.Text = ""
            TxtKodeBarang.Enabled = False
            TxtNamaBarang.Text = ""
            TxtNamaBarang.Enabled = False
        Else
            TxtKodeBarang.Enabled = True
            TxtNamaBarang.Enabled = True
        End If
    End Sub
End Class
