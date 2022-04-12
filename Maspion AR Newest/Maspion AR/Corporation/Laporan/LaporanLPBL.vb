Imports DevExpress.XtraCharts

Public Class LaporanLPBL
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
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
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
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 72)
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
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(91, 92)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 240
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(163, 92)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisi.TabIndex = 241
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi   :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(91, 138)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(232, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 117)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 261
        Me.Label5.Text = "Gudang"
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
        Me.TxtNamaGudang.TabIndex = 260
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(91, 114)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 259
        '
        'LaporanLPBL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanLPBL"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRLaporanPenerimaanBarangLangganan
        'MyReport.LblTanggal.Text = "Tanggal " & Format(DtTanggalAwal.Value, "dd-MMM-yyyy") & " s/d " & Format(DtTanggalAkhir.Value, "dd-MMM-yyyy")

        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT C.GROUP_CUSTOMER,IIF(A.PRINT_PKP=1, C.NAMA_PKP, C.NAMA) NAMA, B.NO_NOTA, D.NAMA AS NAMA_DIVISI, A.NO_NOTA_RETUR, A.SUBTOTAL, A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1 AS DISCOUNT, A.TGL_PENGAKUAN, A.BATAL FROM RETUR_PENJUALAN AS A LEFT OUTER JOIN TTB AS B ON A.ID_TTB = B.ID_TRANSAKSI LEFT OUTER JOIN CUSTOMER AS C ON A.KODE_CUSTOMER = C.ID LEFT OUTER JOIN DIVISI AS D ON A.DIVISI = D.KODE WHERE CONVERT(DATE,A.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,A.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103) " & IIf(TxtDivisi.Text = "", "", "AND B.DIVISI='" & TxtDivisi.Text & "'") & IIf(TxtKodeGudang.Text = "", "", " AND B.GUDANG='" & TxtKodeGudang.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN LPBL"
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
