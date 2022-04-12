Imports DevExpress.XtraCharts

Public Class LaporanLPBH
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RdJenisLaporan As DevExpress.XtraEditors.RadioGroup
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.RdJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.RdJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudang)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 104)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tanggal :"
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.CustomFormat = ""
        Me.DtTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAwal.Location = New System.Drawing.Point(86, 102)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(109, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(209, 102)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(109, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 105)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(86, 124)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 240
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(158, 124)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisi.TabIndex = 241
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 127)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi   :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(86, 170)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(232, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 149)
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
        Me.TxtNamaGudang.Location = New System.Drawing.Point(158, 146)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaGudang.TabIndex = 257
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(86, 146)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 256
        '
        'RdJenisLaporan
        '
        Me.RdJenisLaporan.AutoSizeInLayoutControl = True
        Me.RdJenisLaporan.EditValue = "Semua"
        Me.RdJenisLaporan.EnterMoveNextControl = True
        Me.RdJenisLaporan.Location = New System.Drawing.Point(86, 75)
        Me.RdJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RdJenisLaporan.Name = "RdJenisLaporan"
        Me.RdJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Rekap"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail", "Detail")})
        Me.RdJenisLaporan.Size = New System.Drawing.Size(232, 25)
        Me.RdJenisLaporan.TabIndex = 264
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 81)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "Laporan :"
        '
        'LaporanLPBH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanLPBH"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRLaporanPenerimaanBarangLangganan
        MyReport.LblTitle.Text = "LAPORAN PENGELUARAN BARANG HARIAN"

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT JN.GROUP_CUSTOMER,C.NAMA, B.NO_NOTA, D.NAMA AS NAMA_DIVISI, A.NO_RETUR AS NO_NOTA_RETUR, A.SUBTOTAL, A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1 AS DISCOUNT, A.TGL_PENGAKUAN, A.BATAL FROM (RETUR_PEMBELIAN AS A INNER JOIN DETAIL_RETUR_PEMBELIAN AA ON A.ID_TRANSAKSI=AA.ID_TRANSAKSI) LEFT OUTER JOIN TTB AS B ON AA.ID_TTB = B.ID_TRANSAKSI LEFT JOIN CUSTOMER JN ON JN.ID=B.KODE_CUSTOMER CROSS JOIN PERUSAHAAN E LEFT OUTER JOIN CUSTOMER AS C ON E.CUST_PEMBELIAN = C.ID LEFT OUTER JOIN DIVISI AS D ON A.DIVISI = D.KODE WHERE CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", "", "AND A.DIVISI='" & TxtDivisi.Text & "'") & IIf(TxtKodeGudang.Text = "", "", " AND A.GUDANG='" & TxtKodeGudang.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetail()
        Dim MyReport = New XRLaporanDetailLPBH
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT RETUR_PEMBELIAN.BATAL, DETAIL_RETUR_PEMBELIAN.NO_TTB, RETUR_PEMBELIAN.TGL, RETUR_PEMBELIAN.TGL_PENGAKUAN, RETUR_PEMBELIAN.NO_RETUR, RETUR_PEMBELIAN.DIVISI, TTB.KODE_CUSTOMER, TTB.KODE_APPROVE, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_RETUR_PEMBELIAN.ISI, DETAIL_RETUR_PEMBELIAN.KOLI, DETAIL_RETUR_PEMBELIAN.PCS AS QUANTITY, BARANG.SAT_SUPER1 SATUAN, DETAIL_RETUR_PEMBELIAN.KONVERSI, DETAIL_RETUR_PEMBELIAN.PCS, DETAIL_RETUR_PEMBELIAN.HARGA, USERS.NAMA_USER, DETAIL_RETUR_PEMBELIAN.DISC, DETAIL_RETUR_PEMBELIAN.DISKON_SATUAN, RETUR_PEMBELIAN.KETERANGAN_CETAK FROM PERUSAHAAN CROSS JOIN BARANG INNER JOIN RETUR_PEMBELIAN INNER JOIN DETAIL_RETUR_PEMBELIAN ON RETUR_PEMBELIAN.ID_TRANSAKSI = DETAIL_RETUR_PEMBELIAN.ID_TRANSAKSI ON BARANG.ID = DETAIL_RETUR_PEMBELIAN.ID_BARANG INNER JOIN USERS ON RETUR_PEMBELIAN.CRUSER = USERS.ID_USER  LEFT OUTER JOIN DIVISI ON RETUR_PEMBELIAN.DIVISI = DIVISI.KODE LEFT JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG LEFT JOIN TTB ON DETAIL_RETUR_PEMBELIAN.ID_TTB=TTB.ID_TRANSAKSI LEFT OUTER JOIN CUSTOMER ON ISNULL(TTB.KODE_CUSTOMER, PERUSAHAAN.CUST_PEMBELIAN) = CUSTOMER.ID WHERE CONVERT(DATE,RETUR_PEMBELIAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,RETUR_PEMBELIAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", "", "AND RETUR_PEMBELIAN.DIVISI='" & TxtDivisi.Text & "'") & IIf(TxtKodeGudang.Text = "", "", " AND RETUR_PEMBELIAN.GUDANG='" & TxtKodeGudang.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN LPBH"
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
        If RdJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreview()
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
End Class
