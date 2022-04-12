Imports DevExpress.XtraCharts

Public Class LaporanPembelian
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TBDivisi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RDJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBDivisi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RDJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.TBDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudang)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TBDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 102)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(95, 100)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(109, 20)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(218, 100)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(109, 20)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 103)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 125)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi   :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(95, 282)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(232, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(95, 258)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 307
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(167, 258)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaGudang.TabIndex = 308
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 261)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 309
        Me.Label4.Text = "Gudang   :"
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(95, 125)
        Me.TBDivisi.MainView = Me.GridView1
        Me.TBDivisi.Name = "TBDivisi"
        Me.TBDivisi.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RBEdit})
        Me.TBDivisi.Size = New System.Drawing.Size(232, 130)
        Me.TBDivisi.TabIndex = 310
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
        'RDJenisLaporan
        '
        Me.RDJenisLaporan.AutoSizeInLayoutControl = True
        Me.RDJenisLaporan.EditValue = "Rekap"
        Me.RDJenisLaporan.EnterMoveNextControl = True
        Me.RDJenisLaporan.Location = New System.Drawing.Point(95, 71)
        Me.RDJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisLaporan.Name = "RDJenisLaporan"
        Me.RDJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap", "Rekap"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail", "Detail")})
        Me.RDJenisLaporan.Size = New System.Drawing.Size(232, 25)
        Me.RDJenisLaporan.TabIndex = 311
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 77)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl1.TabIndex = 312
        Me.LabelControl1.Text = "Jenis Laporan :"
        '
        'LaporanPembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanPembelian"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRLaporanPembelian
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

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT RIGHT(PEMBELIAN.NO_NOTA_PENJUALAN, 6) AS NO_NOTA, PEMBELIAN.ID_TRANSAKSI, PEMBELIAN.NO_REF, PEMBELIAN.TGL, PEMBELIAN.TGL_PENGAKUAN, PEMBELIAN.ID_PO, PEMBELIAN.NO_PO, PEMBELIAN.TGL_PO, PEMBELIAN.ID_NOTA_PENJUALAN, PEMBELIAN.NO_NOTA_PENJUALAN, PEMBELIAN.DIVISI, PEMBELIAN.JENIS_PPN,PEMBELIAN.BATAL, PEMBELIAN.KODE_SUPPLIER, PEMBELIAN.ALAMAT_KIRIM, PEMBELIAN.GUDANG, PEMBELIAN.KETERANGAN_CETAK, PEMBELIAN.SUBTOTAL,CASE WHEN PEMBELIAN.BATAL=1 THEN 0 ELSE PEMBELIAN.SUBTOTAL END AS SUBTOTAL_TANPA_BATAL, PEMBELIAN.DPP, PEMBELIAN.PPN, PEMBELIAN.PERIODE, PEMBELIAN.BAGIAN, PEMBELIAN.KODE_EKSPEDISI, PEMBELIAN.NO_TRUK, CLAIM.NO_CLAIM, CLAIM.ID_TRANSAKSI AS ID_CLAIM, IIF(CLAIM.SUBTOTAL IS NULL,0,IIF(CLAIM.BATAL=1,0,CLAIM.SUBTOTAL)) AS SUBTOTAL_CLAIM, IIF(CLAIM.DPP IS NULL,0,IIF(CLAIM.BATAL=1,0,CLAIM.DPP)) AS DPP_CLAIM, IIF(CLAIM.PPN IS NULL,0,IIF(CLAIM.BATAL=1,0,CLAIM.PPN)) AS PPN_CLAIM, DIVISI.NAMA AS NAMA_DIVISI, GUDANG.NAMA_GUDANG, NOTA.DPP AS DPP_NOTA, NOTA.PPN AS PPN_NOTA FROM PEMBELIAN LEFT OUTER JOIN NOTA ON PEMBELIAN.ID_NOTA_PENJUALAN = NOTA.ID_TRANSAKSI LEFT OUTER JOIN GUDANG ON PEMBELIAN.GUDANG = GUDANG.KODE LEFT OUTER JOIN DIVISI ON PEMBELIAN.DIVISI = DIVISI.KODE LEFT OUTER JOIN CLAIM ON PEMBELIAN.ID_TRANSAKSI = CLAIM.ID_NOTA WHERE CONVERT(DATE,PEMBELIAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,PEMBELIAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter & IIf(TxtKodeGudang.Text = "", "", " AND PEMBELIAN.GUDANG='" & TxtKodeGudang.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetail()
        Dim MyReport = New XRLaporanPembelianDetail
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        MyReport.LblTitle.Text = "LAPORAN DETAIL PEMBELIAN"

        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "PEMBELIAN.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT REPLACE(PEMBELIAN.NO_NOTA_PENJUALAN,DIVISI.NAMA,'') AS NO_NOTA, PEMBELIAN.BATAL, PEMBELIAN.NO_NOTA_PENJUALAN, PEMBELIAN.TGL, PEMBELIAN.TGL_PENGAKUAN, REPLACE(PEMBELIAN.NO_NOTA,DIVISI.NAMA,'') AS NO_DO, REPLACE(N.NO_DO,DIVISI.NAMA,'') NOMOR_DO, PEMBELIAN.DIVISI, N.KODE_CUSTOMER, CUSTOMER.NAMA AS NAMA_CUSTOMER, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_PEMBELIAN.ISI, DETAIL_PEMBELIAN.KOLI, DETAIL_PEMBELIAN.PCS AS QUANTITY, BARANG.SAT_SUPER1 SATUAN, DETAIL_PEMBELIAN.KONVERSI, DETAIL_PEMBELIAN.PCS, DETAIL_PEMBELIAN.HARGA, USERS.NAMA_USER, DETAIL_PEMBELIAN.DISC, DETAIL_PEMBELIAN.DISKON_SATUAN, '' KODE_CORP FROM BARANG INNER JOIN PEMBELIAN INNER JOIN DETAIL_PEMBELIAN ON PEMBELIAN.ID_TRANSAKSI = DETAIL_PEMBELIAN.ID_TRANSAKSI ON BARANG.ID = DETAIL_PEMBELIAN.ID_BARANG INNER JOIN USERS ON PEMBELIAN.CRUSER = USERS.ID_USER LEFT JOIN NOTA N ON PEMBELIAN.ID_NOTA_PENJUALAN=N.ID_TRANSAKSI LEFT OUTER JOIN CUSTOMER ON N.KODE_CUSTOMER = CUSTOMER.ID LEFT OUTER JOIN DIVISI ON PEMBELIAN.DIVISI = DIVISI.KODE LEFT JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG  WHERE PCS > 0 AND CONVERT(DATE,PEMBELIAN.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,PEMBELIAN.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter)
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN PEMBELIAN"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        loadDivisi()
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

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        If RDJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreview()
        ElseIf RDJenisLaporan.SelectedIndex = 1 Then
            ReportShowPreviewDetail()
        End If
    End Sub
End Class
