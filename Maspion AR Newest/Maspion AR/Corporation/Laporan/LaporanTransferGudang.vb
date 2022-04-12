Imports DevExpress.XtraCharts

Public Class LaporanTransferGudang
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudangTujuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudangTujuan As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNamaGudangTujuan = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudangTujuan = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudangTujuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudangTujuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudangTujuan)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudangTujuan)
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudangTujuan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudangTujuan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 76)
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
        Me.DtTanggalAwal.Location = New System.Drawing.Point(91, 70)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Size = New System.Drawing.Size(109, 20)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.CustomFormat = ""
        Me.DtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(214, 70)
        Me.DtTanggalAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(109, 20)
        Me.DtTanggalAkhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(91, 160)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(232, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 117)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "Gudang Sumber"
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(163, 114)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaGudang.TabIndex = 266
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(91, 114)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 265
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Divisi   :"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(91, 92)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 262
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(163, 92)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisi.TabIndex = 263
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 139)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 270
        Me.Label4.Text = "Gudang Tujuan"
        '
        'TxtNamaGudangTujuan
        '
        Me.TxtNamaGudangTujuan.Enabled = False
        Me.TxtNamaGudangTujuan.EnterMoveNextControl = True
        Me.TxtNamaGudangTujuan.Location = New System.Drawing.Point(163, 136)
        Me.TxtNamaGudangTujuan.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudangTujuan.Name = "TxtNamaGudangTujuan"
        Me.TxtNamaGudangTujuan.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudangTujuan.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudangTujuan.Properties.ReadOnly = True
        Me.TxtNamaGudangTujuan.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaGudangTujuan.TabIndex = 269
        '
        'TxtKodeGudangTujuan
        '
        Me.TxtKodeGudangTujuan.Location = New System.Drawing.Point(91, 136)
        Me.TxtKodeGudangTujuan.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudangTujuan.Name = "TxtKodeGudangTujuan"
        Me.TxtKodeGudangTujuan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudangTujuan.Properties.ReadOnly = True
        Me.TxtKodeGudangTujuan.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudangTujuan.TabIndex = 268
        '
        'LaporanTransferGudang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanTransferGudang"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudangTujuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudangTujuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRLaporanTransferGudang
        MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

        Report = MyReport
        'Report.DataSource = SelectCon.execute("SELECT V_D_TRANSFER_T_TERIMA.ID_TRANSAKSI, RIGHT(V_D_TRANSFER_T_TERIMA.NO_TRANSFER, 6) AS NO_TRANSFER, V_D_TRANSFER_T_TERIMA.TGL_PENGAKUAN, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, V_D_TRANSFER_T_TERIMA.ID_BARANG, V_D_TRANSFER_T_TERIMA.KOLI, V_D_TRANSFER_T_TERIMA.QUANTITY, V_D_TRANSFER_T_TERIMA.PCS, V_D_TRANSFER_T_TERIMA.SATUAN, V_D_TRANSFER_T_TERIMA.URUTAN, V_D_TRANSFER_T_TERIMA.HARGA, V_D_TRANSFER_T_TERIMA.ISI, V_D_TRANSFER_T_TERIMA.KONVERSI, V_D_TRANSFER_T_TERIMA.PCS_T, V_D_TRANSFER_T_TERIMA.QUANTITY_T, V_D_TRANSFER_T_TERIMA.KOLI_T, V_D_TRANSFER_T_TERIMA.ST, V_D_TRANSFER_T_TERIMA.STK, GUDANG.NAMA_GUDANG AS NAMA_GUDANG_SUMBER, GUDANG_1.NAMA_GUDANG AS NAMA_GUDANG_TUJUAN, BARANG.NAMA FROM V_D_TRANSFER_T_TERIMA INNER JOIN TRANSFER_GUDANG ON V_D_TRANSFER_T_TERIMA.ID_TRANSAKSI = TRANSFER_GUDANG.ID_TRANSAKSI INNER JOIN DIVISI ON TRANSFER_GUDANG.DIVISI = DIVISI.KODE INNER JOIN BARANG ON V_D_TRANSFER_T_TERIMA.ID_BARANG = BARANG.ID LEFT OUTER JOIN GUDANG AS GUDANG_1 ON TRANSFER_GUDANG.GUDANG_TUJUAN = GUDANG_1.KODE LEFT OUTER JOIN GUDANG ON TRANSFER_GUDANG.GUDANG_SUMBER = GUDANG.KODE WHERE CONVERT(DATE,V_D_TRANSFER_T_TERIMA.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,V_D_TRANSFER_T_TERIMA.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) ")

        Report.DataSource = SelectCon.execute("SELECT * FROM (SELECT V_D_TRANSFER_T_TERIMA.ID_TRANSAKSI, RIGHT(V_D_TRANSFER_T_TERIMA.NO_TRANSFER, 6) AS NO_TRANSFER, '' NO_TTB,V_D_TRANSFER_T_TERIMA.TGL_PENGAKUAN, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, V_D_TRANSFER_T_TERIMA.ID_BARANG, V_D_TRANSFER_T_TERIMA.KOLI, V_D_TRANSFER_T_TERIMA.QUANTITY, V_D_TRANSFER_T_TERIMA.PCS, V_D_TRANSFER_T_TERIMA.SATUAN, V_D_TRANSFER_T_TERIMA.URUTAN, V_D_TRANSFER_T_TERIMA.HARGA, V_D_TRANSFER_T_TERIMA.ISI, V_D_TRANSFER_T_TERIMA.KONVERSI, V_D_TRANSFER_T_TERIMA.PCS_T, V_D_TRANSFER_T_TERIMA.QUANTITY_T, V_D_TRANSFER_T_TERIMA.KOLI_T, V_D_TRANSFER_T_TERIMA.ST, V_D_TRANSFER_T_TERIMA.STK, GUDANG.NAMA_GUDANG AS NAMA_GUDANG_SUMBER, GUDANG_1.NAMA_GUDANG AS NAMA_GUDANG_TUJUAN, BARANG.NAMA, GUDANG_SUMBER, GUDANG_TUJUAN, TRANSFER_GUDANG.DIVISI FROM V_D_TRANSFER_T_TERIMA INNER JOIN TRANSFER_GUDANG ON V_D_TRANSFER_T_TERIMA.ID_TRANSAKSI = TRANSFER_GUDANG.ID_TRANSAKSI INNER JOIN DIVISI ON TRANSFER_GUDANG.DIVISI = DIVISI.KODE INNER JOIN BARANG ON V_D_TRANSFER_T_TERIMA.ID_BARANG = BARANG.ID LEFT OUTER JOIN GUDANG AS GUDANG_1 ON TRANSFER_GUDANG.GUDANG_TUJUAN = GUDANG_1.KODE LEFT OUTER JOIN GUDANG ON TRANSFER_GUDANG.GUDANG_SUMBER = GUDANG.KODE UNION ALL SELECT V_D_TRANSFER_T_TERIMA_RETUR.ID_TRANSAKSI, RIGHT(V_D_TRANSFER_T_TERIMA_RETUR.NO_TRANSAKSI, 6) AS NO_TRANSFER , V_D_TRANSFER_T_TERIMA_RETUR.NO_TTB, V_D_TRANSFER_T_TERIMA_RETUR.TGL_PENGAKUAN, DIVISI.NAMA AS NAMA_DIVISI, BARANG.KODE, V_D_TRANSFER_T_TERIMA_RETUR.ID_BARANG, V_D_TRANSFER_T_TERIMA_RETUR.KOLI, V_D_TRANSFER_T_TERIMA_RETUR.QUANTITY, V_D_TRANSFER_T_TERIMA_RETUR.PCS, V_D_TRANSFER_T_TERIMA_RETUR.SATUAN, V_D_TRANSFER_T_TERIMA_RETUR.URUTAN, V_D_TRANSFER_T_TERIMA_RETUR.HARGA, V_D_TRANSFER_T_TERIMA_RETUR.ISI, V_D_TRANSFER_T_TERIMA_RETUR.KONVERSI, V_D_TRANSFER_T_TERIMA_RETUR.PCS_T, V_D_TRANSFER_T_TERIMA_RETUR.QUANTITY_T, V_D_TRANSFER_T_TERIMA_RETUR.KOLI_T, V_D_TRANSFER_T_TERIMA_RETUR.ST, V_D_TRANSFER_T_TERIMA_RETUR.STK, GUDANG.NAMA_GUDANG AS NAMA_GUDANG_SUMBER, GUDANG_1.NAMA_GUDANG AS NAMA_GUDANG_TUJUAN, BARANG.NAMA,GUDANG_SUMBER, GUDANG_TUJUAN, TRANSFER_BARANG_RETUR.DIVISI FROM V_D_TRANSFER_T_TERIMA_RETUR INNER JOIN TRANSFER_BARANG_RETUR ON V_D_TRANSFER_T_TERIMA_RETUR.ID_TRANSAKSI = TRANSFER_BARANG_RETUR.ID_TRANSAKSI INNER JOIN DIVISI ON TRANSFER_BARANG_RETUR.DIVISI = DIVISI.KODE INNER JOIN BARANG ON V_D_TRANSFER_T_TERIMA_RETUR.ID_BARANG = BARANG.ID LEFT OUTER JOIN GUDANG AS GUDANG_1 ON TRANSFER_BARANG_RETUR.GUDANG_TUJUAN = GUDANG_1.KODE LEFT OUTER JOIN GUDANG ON TRANSFER_BARANG_RETUR.GUDANG_SUMBER = GUDANG.KODE) Z WHERE CONVERT(DATE,TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", "", "AND DIVISI='" & TxtDivisi.Text & "'") & IIf(TxtKodeGudang.Text = "", "", " AND GUDANG_SUMBER='" & TxtKodeGudang.Text & "' ") & IIf(TxtKodeGudang.Text = "", "", " AND GUDANG_TUJUAN='" & TxtKodeGudangTujuan.Text & "' "))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN TRANSFER GUDANG"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
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

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub TxtKodeGudangTujuan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudangTujuan.ButtonClick
        TxtKodeGudangTujuan.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudangTujuan_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudangTujuan.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudangTujuan.Text & "'", {TxtNamaGudangTujuan})
    End Sub
    Private Sub TxtKodeGudangTujuan_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudangTujuan.KeyPress
        If CharKeypress(TxtKodeGudangTujuan, e) Then TxtKodeGudangTujuan.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
End Class
