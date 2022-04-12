Imports DevExpress.XtraCharts

Public Class LaporanAdjusmentStok
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RdJenisLaporan As DevExpress.XtraEditors.RadioGroup
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
        Me.RdJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.RdJenisLaporan)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 125)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(77, 123)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(109, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(200, 123)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(109, 21)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 126)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 148)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi   :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(77, 305)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(232, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(77, 281)
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
        Me.TxtNamaGudang.Location = New System.Drawing.Point(149, 281)
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
        Me.Label4.Location = New System.Drawing.Point(18, 284)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 309
        Me.Label4.Text = "Gudang   :"
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(77, 148)
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
        'RdJenisLaporan
        '
        Me.RdJenisLaporan.AutoSizeInLayoutControl = True
        Me.RdJenisLaporan.EditValue = "Semua"
        Me.RdJenisLaporan.EnterMoveNextControl = True
        Me.RdJenisLaporan.Location = New System.Drawing.Point(77, 73)
        Me.RdJenisLaporan.Margin = New System.Windows.Forms.Padding(1)
        Me.RdJenisLaporan.Name = "RdJenisLaporan"
        Me.RdJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Adjusment"), New DevExpress.XtraEditors.Controls.RadioGroupItem("", "Selisih Barang"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Detail Adjusment")})
        Me.RdJenisLaporan.Size = New System.Drawing.Size(232, 48)
        Me.RdJenisLaporan.TabIndex = 311
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 79)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 312
        Me.Label5.Text = "Jenis :"
        '
        'LaporanAdjusmentStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanAdjusmentStok"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRLaporanAdjusment
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "ADJUSMENT_STOK.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT RIGHT(ADJUSMENT_STOK.NO_TRANSAKSI, 6) AS NO_NOTA, ADJUSMENT_STOK.SIFAT, ADJUSMENT_STOK.ID_TRANSAKSI, ADJUSMENT_STOK.TGL, ADJUSMENT_STOK.TGL_PENGAKUAN, ADJUSMENT_STOK.DIVISI, ADJUSMENT_STOK.BATAL, ADJUSMENT_STOK.GUDANG, ADJUSMENT_STOK.KETERANGAN_CETAK, ADJUSMENT_STOK.SUBTOTAL,CASE WHEN ADJUSMENT_STOK.BATAL=1 THEN 0 ELSE ADJUSMENT_STOK.SUBTOTAL END AS SUBTOTAL_TANPA_BATAL, ADJUSMENT_STOK.DPP, ADJUSMENT_STOK.PPN, ADJUSMENT_STOK.PERIODE, DIVISI.NAMA AS NAMA_DIVISI, GUDANG.NAMA_GUDANG FROM ADJUSMENT_STOK LEFT OUTER JOIN GUDANG ON ADJUSMENT_STOK.GUDANG = GUDANG.KODE LEFT OUTER JOIN DIVISI ON ADJUSMENT_STOK.DIVISI = DIVISI.KODE WHERE CONVERT(DATE,ADJUSMENT_STOK.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,ADJUSMENT_STOK.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter & IIf(TxtKodeGudang.Text = "", "", " AND ADJUSMENT_STOK.GUDANG='" & TxtKodeGudang.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowSelisihBarang()
        Dim MyReport = New XRDaftarSelisihStok
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

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DATA.ID_TRANSAKSI, DATA.NO_TRANSAKSI, DATA.TGL_PENGAKUAN, B.NAMA, BR.KODE, BR.NAMA, DATA.STOK+DATA.ADJ FISIK, DATA.STOK STOK, DATA.ADJ SELISIH, BR.QTY_KOLI, BR.SAT_KOLI1, BR.QTY_DIST, BR.SAT_DIST1, BR.SAT_SUPER1, DATA.HARGA, G.NAMA_GUDANG FROM	(SELECT A.ID_TRANSAKSI, A.NO_TRANSAKSI, A.TGL_PENGAKUAN, B.ID_BARANG, A.GUDANG, SUM(CASE WHEN A.SIFAT = 'Mengurangi' THEN -B.PCS ELSE B.PCS END) ADJ,		ISNULL((SELECT SUM(QUANTITY) STOK FROM SALDO_STOK SS WHERE SS.GUDANG=A.GUDANG AND SS.ID_BARANG=B.ID_BARANG 		AND SS.TGL_PENGAKUAN < A.TGL_PENGAKUAN GROUP BY ID_BARANG, GUDANG),0) STOK,		(SELECT TOP 1 HARGA_BARU FROM VI_PRICE_LIST_UMUM PL 		WHERE PL.TGL_PRICE<=A.TGL_PENGAKUAN AND PL.ID_BARANG=B.ID_BARANG AND PL.JENIS='Langganan' 		ORDER BY PL.TGL_PRICE DESC) HARGA	FROM ADJUSMENT_STOK A JOIN DETAIL_ADJUSMENT_STOK B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI	WHERE CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter & IIf(TxtKodeGudang.Text = "", "", " AND A.GUDANG='" & TxtKodeGudang.Text & "' ") & " AND A.BATAL=0	GROUP BY A.ID_TRANSAKSI, A.NO_TRANSAKSI, A.TGL_PENGAKUAN, B.ID_BARANG, A.GUDANG 	HAVING SUM(CASE WHEN A.SIFAT = 'Mengurangi' THEN -B.PCS ELSE B.PCS END) <> 0) DATA LEFT JOIN BARANG BR ON DATA.ID_BARANG=BR.ID LEFT JOIN LINK_BARANG_DIVISI A ON DATA.ID_BARANG=A.ID_BARANG LEFT JOIN DIVISI B ON A.KODE_DIVISI=B.KODE LEFT JOIN GUDANG G ON DATA.GUDANG=G.KODE")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub ReportShowPreviewDetail()
        Dim MyReport = New XRLaporanAdjusmentStokDetail
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")
        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "ADJUSMENT_STOK.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT DISTINCT ADJUSMENT_STOK.NO_TRANSAKSI AS NO_NOTA, ADJUSMENT_STOK.BATAL, ADJUSMENT_STOK.GUDANG KODE_GUDANG, G.NAMA_GUDANG, ADJUSMENT_STOK.TGL, ADJUSMENT_STOK.TGL_PENGAKUAN, ADJUSMENT_STOK.SIFAT JENIS, ADJUSMENT_STOK.DIVISI, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, DETAIL_ADJUSMENT_STOK.ISI, DETAIL_ADJUSMENT_STOK.KOLI, DETAIL_ADJUSMENT_STOK.PCS AS QUANTITY, BARANG.SAT_SUPER1 SATUAN, DETAIL_ADJUSMENT_STOK.KONVERSI, DETAIL_ADJUSMENT_STOK.PCS, DETAIL_ADJUSMENT_STOK.HARGA, USERS.NAMA_USER, 0 DISC, 0 DISKON_SATUAN FROM BARANG INNER JOIN ADJUSMENT_STOK INNER JOIN DETAIL_ADJUSMENT_STOK ON ADJUSMENT_STOK.ID_TRANSAKSI = DETAIL_ADJUSMENT_STOK.ID_TRANSAKSI ON BARANG.ID = DETAIL_ADJUSMENT_STOK.ID_BARANG INNER JOIN USERS ON ADJUSMENT_STOK.CRUSER = USERS.ID_USER LEFT OUTER JOIN DIVISI ON ADJUSMENT_STOK.DIVISI = DIVISI.KODE LEFT JOIN GUDANG G ON ADJUSMENT_STOK.GUDANG=G.KODE LEFT JOIN LINK_BARANG_PROMO ON BARANG.ID=LINK_BARANG_PROMO.ID_BARANG WHERE PCS > 0 AND CONVERT(DATE,ADJUSMENT_STOK.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,ADJUSMENT_STOK.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & filter & IIf(TxtKodeGudang.Text = "", "", " AND ADJUSMENT_STOK.GUDANG='" & TxtKodeGudang.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN ADJUSMENT STOK"
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
        If RdJenisLaporan.SelectedIndex = 0 Then
            ReportShowPreview()
        ElseIf RdJenisLaporan.SelectedIndex = 1 Then
            ReportShowSelisihBarang()
        ElseIf RdJenisLaporan.SelectedIndex = 2 Then
            ReportShowPreviewDetail()
        End If
    End Sub
End Class
