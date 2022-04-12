Imports DevExpress.XtraCharts

Public Class LaporanNotaSJ
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RDJenisPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RDJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtIDCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeApprove As DevExpress.XtraEditors.ButtonEdit
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
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.RDJenisPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.RDJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtIDCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeApprove = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtIDCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNama)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeApprove)
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeApprove, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNama, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtIDCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl4, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 91)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(105, 88)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(99, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(218, 88)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(130, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(105, 110)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 240
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(177, 110)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(171, 20)
        Me.TxtNamaDivisi.TabIndex = 241
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi  "
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(105, 286)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(243, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 132)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 246
        Me.LabelControl3.Text = "Jenis Penjualan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(10, 187)
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
        Me.RDJenisPenjualan.Location = New System.Drawing.Point(105, 187)
        Me.RDJenisPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisPenjualan.Name = "RDJenisPenjualan"
        Me.RDJenisPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Perwakilan", "Perwakilan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Pusat", "Pusat")})
        Me.RDJenisPenjualan.Size = New System.Drawing.Size(243, 46)
        Me.RDJenisPenjualan.TabIndex = 248
        '
        'RDPenjualan
        '
        Me.RDPenjualan.AutoSizeInLayoutControl = True
        Me.RDPenjualan.EditValue = ""
        Me.RDPenjualan.EnterMoveNextControl = True
        Me.RDPenjualan.Location = New System.Drawing.Point(105, 132)
        Me.RDPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDPenjualan.Name = "RDPenjualan"
        Me.RDPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Langganan", "Langganan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Supermarket", "Supermarket"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Lain", "Lain - Lain")})
        Me.RDPenjualan.Size = New System.Drawing.Size(243, 53)
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
        Me.RDJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap", "Rekap"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail", "Detail")})
        Me.RDJenisLaporan.Size = New System.Drawing.Size(243, 25)
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 238)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 258
        Me.Label5.Text = "Gudang"
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(177, 235)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(171, 20)
        Me.TxtNamaGudang.TabIndex = 257
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(105, 235)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 256
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 260)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 262
        Me.LabelControl4.Text = "Customer"
        '
        'TxtIDCustomer
        '
        Me.TxtIDCustomer.Enabled = False
        Me.TxtIDCustomer.EnterMoveNextControl = True
        Me.TxtIDCustomer.Location = New System.Drawing.Point(350, 257)
        Me.TxtIDCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDCustomer.Name = "TxtIDCustomer"
        Me.TxtIDCustomer.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtIDCustomer.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtIDCustomer.Properties.ReadOnly = True
        Me.TxtIDCustomer.Size = New System.Drawing.Size(15, 20)
        Me.TxtIDCustomer.TabIndex = 261
        Me.TxtIDCustomer.Visible = False
        '
        'TxtNama
        '
        Me.TxtNama.Enabled = False
        Me.TxtNama.EnterMoveNextControl = True
        Me.TxtNama.Location = New System.Drawing.Point(177, 257)
        Me.TxtNama.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNama.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNama.Properties.ReadOnly = True
        Me.TxtNama.Size = New System.Drawing.Size(171, 20)
        Me.TxtNama.TabIndex = 260
        '
        'TxtKodeApprove
        '
        Me.TxtKodeApprove.EditValue = ""
        Me.TxtKodeApprove.Location = New System.Drawing.Point(105, 257)
        Me.TxtKodeApprove.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeApprove.Name = "TxtKodeApprove"
        Me.TxtKodeApprove.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtKodeApprove.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtKodeApprove.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeApprove.Properties.ReadOnly = True
        Me.TxtKodeApprove.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeApprove.TabIndex = 259
        '
        'LaporanNotaSJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanNotaSJ"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreviewRekap()
        Dim MyReport = New XRLaporanNotaSJ
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.XrTableCell12.Text = "No. Nota/SJ"
        MyReport.LblTitle.Text = "LAPORAN NOTA / SURAT JALAN"
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT BATAL,NOTA.NO_NOTA AS NO_DO, NOTA.ID_TRANSAKSI, NOTA.TGL_PENGAKUAN, NOTA.DIVISI, NOTA.KODE_CUSTOMER, NOTA.KODE_APPROVE, CUSTOMER.NAMA, NOTA.SUBTOTAL SUBTOTAL_DETAIL, CASE WHEN BATAL = 1 THEN 0 ELSE NOTA.SUBTOTAL END SUBTOTAL, NOTA.DISC_QTY, NOTA.DISC_QTY_NOMINAL, NOTA.DISC_REG, NOTA.DISC_1, NOTA.DISC_2, NOTA.DISC_3, NOTA.CASH_DISC, NOTA.DISC_QTY1, NOTA.DISC_QTY_NOMINAL1,NOTA.DPP, NOTA.PPN, NOTA.BAGIAN, DIVISI.NAMA AS NAMA_DIVISI, USERS.NAMA_USER FROM NOTA LEFT OUTER JOIN DIVISI ON NOTA.DIVISI = DIVISI.KODE LEFT OUTER JOIN USERS ON NOTA.CRUSER = USERS.ID_USER LEFT OUTER JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID WHERE CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND NOTA.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
     IIf(TxtKodeGudang.Text = "", "", " AND NOTA.GUDANG = '" & TxtKodeGudang.Text & "' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND NOTA.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(TxtIDCustomer.Text = "", "", " AND NOTA.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetail()
        Dim MyReport = New XRLaporanDetailDO
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = "LAPORAN DETAIL NOTA / SURAT JALAN"
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDJenisPenjualan.EditValue.ToString.ToUpper
        MyReport.LblTitle.Text = MyReport.LblTitle.Text & " " & RDPenjualan.EditValue.ToString.ToUpper

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT D.NAMA AS CUSTOMER,C.NAMA AS BARANG,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS ELSE 0 END) AS PCS_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Perwakilan%' THEN B.PCS*((B.HARGA-B.DISKON_SATUAN)/B.KONVERSI) ELSE 0 END) AS BRUTO_PRW,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS ELSE 0 END) AS PCS_PST,SUM(CASE WHEN A.BAGIAN LIKE '%Pusat%' THEN B.PCS*((B.HARGA-B.DISKON_SATUAN)/B.KONVERSI) ELSE 0 END) AS BRUTO_PST FROM NOTA A INNER JOIN DETAIL_NOTA B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN BARANG C ON B.ID_BARANG=C.ID LEFT JOIN CUSTOMER D ON A.KODE_CUSTOMER=D.ID WHERE A.BATAL=0 AND CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", " ", " AND A.DIVISI='" & TxtDivisi.Text & "' ") &
    IIf(RDJenisPenjualan.SelectedIndex = -1 Or RDJenisPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDJenisPenjualan.EditValue & "%' ") &
    IIf(TxtKodeGudang.Text = "", "", " AND A.GUDANG = '" & TxtKodeGudang.Text & "' ") &
    IIf(RDPenjualan.SelectedIndex = -1 Or RDPenjualan.SelectedIndex = 0, "", " AND A.BAGIAN LIKE '%" & RDPenjualan.EditValue & "%' ") &
    IIf(TxtIDCustomer.Text = "", "", " AND A.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ") & " GROUP BY D.NAMA,C.NAMA ")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN NOTA / SJ"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
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
        If RDJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreviewRekap()
        Else
            ReportShowPreviewDetail()
        End If
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
End Class
