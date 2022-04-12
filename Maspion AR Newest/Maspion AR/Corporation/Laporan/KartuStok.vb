Imports DevExpress.XtraCharts

Public Class KartuStok
    Inherits FrmLaporanBase
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RDJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents TxtIDBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeBarang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.RDJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtKodeBarang = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaBarang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtIDBarang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeGudang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtIDBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaBarang)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtIDBarang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaGudang, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Periode :"
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.CustomFormat = "MMMM yyyy"
        Me.DtTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalAwal.Location = New System.Drawing.Point(90, 122)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.ShowUpDown = True
        Me.DtTanggalAwal.Size = New System.Drawing.Size(154, 21)
        Me.DtTanggalAwal.TabIndex = 108
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 149)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Divisi  "
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(90, 146)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(62, 20)
        Me.TxtDivisi.TabIndex = 243
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(154, 146)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtNamaDivisi.TabIndex = 244
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(90, 214)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(261, 23)
        Me.BtnView.TabIndex = 246
        Me.BtnView.Text = "View"
        '
        'RDJenisLaporan
        '
        Me.RDJenisLaporan.EditValue = "Kartu Stok"
        Me.RDJenisLaporan.Location = New System.Drawing.Point(90, 72)
        Me.RDJenisLaporan.Name = "RDJenisLaporan"
        Me.RDJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Kartu Stok", "Kartu Stok"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Saldo Stok", "Saldo Stok"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Slow Moving"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Dead Stock"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Not Used")})
        Me.RDJenisLaporan.Size = New System.Drawing.Size(261, 46)
        Me.RDJenisLaporan.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 70)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "Laporan :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 193)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Barang"
        '
        'TxtKodeBarang
        '
        Me.TxtKodeBarang.Location = New System.Drawing.Point(90, 190)
        Me.TxtKodeBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeBarang.Name = "TxtKodeBarang"
        Me.TxtKodeBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeBarang.Size = New System.Drawing.Size(62, 20)
        Me.TxtKodeBarang.TabIndex = 249
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.EnterMoveNextControl = True
        Me.TxtNamaBarang.Location = New System.Drawing.Point(154, 190)
        Me.TxtNamaBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Properties.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(197, 20)
        Me.TxtNamaBarang.TabIndex = 250
        '
        'TxtIDBarang
        '
        Me.TxtIDBarang.EnterMoveNextControl = True
        Me.TxtIDBarang.Location = New System.Drawing.Point(353, 190)
        Me.TxtIDBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDBarang.Name = "TxtIDBarang"
        Me.TxtIDBarang.Properties.ReadOnly = True
        Me.TxtIDBarang.Size = New System.Drawing.Size(16, 20)
        Me.TxtIDBarang.TabIndex = 252
        Me.TxtIDBarang.Visible = False
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(154, 168)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(197, 20)
        Me.TxtNamaGudang.TabIndex = 254
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(90, 168)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtKodeGudang.Properties.Appearance.Options.UseBackColor = True
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(62, 20)
        Me.TxtKodeGudang.TabIndex = 253
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 171)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "Gudang"
        '
        'KartuStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "KartuStok"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        OpenWaitForm()
        If RDJenisLaporan.SelectedIndex = 0 Then
            Dim MyReport = New XRKartuStok
            MyReport.LblPeriode.Text = "Periode " & Format(DtTanggalAwal.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("PROC_KARTU_STOK_LAMA " & Format(DtTanggalAwal.Value, "MM") & "," & Format(DtTanggalAwal.Value, "yyyy") & "," & IIf(TxtDivisi.Text = "", "DEFAULT", "'" & TxtDivisi.Text & "'") & "," & IIf(TxtIDBarang.Text = "", "DEFAULT", "'" & TxtIDBarang.Text & "'") & "," & IIf(TxtKodeGudang.Text = "", "DEFAULT", "'" & TxtKodeGudang.Text & "'"))

        ElseIf RDJenisLaporan.SelectedIndex = 1 Then
            Dim MyReport = New XRSaldoStok
            MyReport.LblTanggal.Text = Format(DtTanggalAwal.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("PROC_SALDO_STOK_LAMA " & Format(DtTanggalAwal.Value, "MM") & "," & Format(DtTanggalAwal.Value, "yyyy") & "," & IIf(TxtDivisi.Text = "", "DEFAULT", "'" & TxtDivisi.Text & "'") & "," & IIf(TxtIDBarang.Text = "", "DEFAULT", "'" & TxtIDBarang.Text & "'") & "," & IIf(TxtKodeGudang.Text = "", "DEFAULT", "'" & TxtKodeGudang.Text & "'"))

        ElseIf RDJenisLaporan.SelectedIndex = 2 Then
            Dim MyReport = New XRSlowMoving
            MyReport.LblTitle.Text = "SLOW MOVING (90 Hari) ""[NAMA_GUDANG]"" "
            MyReport.LblTanggal.Text = Format(DtTanggalAwal.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT F_SLOW_MOVING_1.*, DIVISI.NAMA AS NAMA_DIVISI, GUDANG.NAMA_GUDANG, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, BARANG.QTY_KOLI FROM GUDANG RIGHT JOIN dbo.F_SLOW_MOVING('" & Format(DtTanggalAwal.Value, "yyyy-MM-dd") & "', '" & TxtDivisi.Text & "', '" & TxtKodeGudang.Text & "', -90) AS F_SLOW_MOVING_1 ON GUDANG.KODE = F_SLOW_MOVING_1.GUDANG LEFT JOIN BARANG ON F_SLOW_MOVING_1.ID_BARANG = BARANG.ID LEFT JOIN DIVISI ON F_SLOW_MOVING_1.KODE_DIVISI = DIVISI.KODE")

        ElseIf RDJenisLaporan.SelectedIndex = 3 Then
            Dim MyReport = New XRSlowMoving
            MyReport.LblTitle.Text = "DEAD STOCK (180 Hari) ""[NAMA_GUDANG]"" "
            MyReport.LblTanggal.Text = Format(DtTanggalAwal.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT F_SLOW_MOVING_1.*, DIVISI.NAMA AS NAMA_DIVISI, GUDANG.NAMA_GUDANG, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, BARANG.QTY_KOLI FROM GUDANG RIGHT JOIN dbo.F_SLOW_MOVING('" & Format(DtTanggalAwal.Value, "yyyy-MM-dd") & "', '" & TxtDivisi.Text & "', '" & TxtKodeGudang.Text & "', -180) AS F_SLOW_MOVING_1 ON GUDANG.KODE = F_SLOW_MOVING_1.GUDANG LEFT JOIN BARANG ON F_SLOW_MOVING_1.ID_BARANG = BARANG.ID LEFT JOIN DIVISI ON F_SLOW_MOVING_1.KODE_DIVISI = DIVISI.KODE")

        ElseIf RDJenisLaporan.SelectedIndex = 4 Then
            Dim MyReport = New XRSlowMoving
            MyReport.LblTitle.Text = "PURCHASE BUT NOT USED (>180 Hari) ""[NAMA_GUDANG]"" "
            MyReport.LblTanggal.Text = Format(DtTanggalAwal.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT F_SLOW_MOVING_1.*, DIVISI.NAMA AS NAMA_DIVISI, GUDANG.NAMA_GUDANG, BARANG.KODE, BARANG.NAMA AS NAMA_BARANG, BARANG.QTY_KOLI FROM GUDANG RIGHT JOIN dbo.F_SLOW_MOVING('" & Format(DtTanggalAwal.Value, "yyyy-MM-dd") & "', '" & TxtDivisi.Text & "', '" & TxtKodeGudang.Text & "', -9999) AS F_SLOW_MOVING_1 ON GUDANG.KODE = F_SLOW_MOVING_1.GUDANG LEFT JOIN BARANG ON F_SLOW_MOVING_1.ID_BARANG = BARANG.ID LEFT JOIN DIVISI ON F_SLOW_MOVING_1.KODE_DIVISI = DIVISI.KODE")
        End If
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
        CloseWaitForm()
    End Sub

    Sub OpenWaitForm()
        Try
            SplashScreenManager1.ShowWaitForm()
        Catch ex As Exception

        End Try
    End Sub

    Sub CloseWaitForm()
        Try
            SplashScreenManager1.CloseWaitForm()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "KARTU STOK"
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub DtTanggalAwal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtTanggalAwal.ValueChanged
        DocumentViewer1.DocumentSource = Nothing
    End Sub

    Private Sub KartuStok_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
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

    Private Sub TxtIDBarang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDBarang.EditValueChanged
        SetData("SELECT KODE,NAMA FROM BARANG WHERE ID='" & TxtIDBarang.Text & "'", {TxtKodeBarang, TxtNamaBarang})
    End Sub

    Private Sub TxtKodeBarang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeBarang.ButtonClick
        TxtIDBarang.Text = Search(FrmPencarian.KeyPencarian.Barang_Divisi, , , , , "%" & TxtDivisi.Text & "%")
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

    Private Sub RDJenisLaporan_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisLaporan.SelectedIndexChanged
        If RDJenisLaporan.SelectedIndex >= 2 Then
            Label4.Enabled = False
            Label5.Enabled = False
            TxtKodeBarang.Enabled = False
            TxtKodeBarang.Text = ""
            TxtNamaBarang.Enabled = False
        Else
            Label4.Enabled = True
            Label5.Enabled = True
            TxtKodeBarang.Enabled = True
            TxtNamaBarang.Enabled = True
        End If
    End Sub
End Class
