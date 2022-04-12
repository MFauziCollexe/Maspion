Imports DevExpress.XtraCharts

Public Class LaporanSummaryFinishGoods
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RdRangeMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtMonthlyAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtMonthlyAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DtMonthly As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RdMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DtYearly As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RdYearly As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RdDivisi As System.Windows.Forms.RadioButton
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaDivisiYearly As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDivisiYearly As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaDivisiMonthly As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDivisiMonthly As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaDivisiRangeMonthly As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDivisiRangeMonthly As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtMonthlyAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DtMonthlyAwal = New System.Windows.Forms.DateTimePicker()
        Me.RdRangeMonthly = New System.Windows.Forms.RadioButton()
        Me.RdMonthly = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DtMonthly = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RdYearly = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DtYearly = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RdDivisi = New System.Windows.Forms.RadioButton()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaDivisiMonthly = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisiMonthly = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNamaDivisiRangeMonthly = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisiRangeMonthly = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNamaDivisiYearly = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisiYearly = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TxtNamaDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisiRangeMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisiRangeMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisiYearly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisiYearly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox4)
        Me.XtraScrollableControl1.Controls.Add(Me.RdDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox3)
        Me.XtraScrollableControl1.Controls.Add(Me.RdYearly)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox2)
        Me.XtraScrollableControl1.Controls.Add(Me.RdMonthly)
        Me.XtraScrollableControl1.Controls.Add(Me.RdRangeMonthly)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox1)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(390, 473)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdRangeMonthly, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdMonthly, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdYearly, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox4, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Bulan :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(62, 18)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisi.TabIndex = 240
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(134, 18)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisi.TabIndex = 241
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Divisi   :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(23, 419)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(367, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtNamaDivisiRangeMonthly)
        Me.GroupBox1.Controls.Add(Me.TxtDivisiRangeMonthly)
        Me.GroupBox1.Controls.Add(Me.DtMonthlyAkhir)
        Me.GroupBox1.Controls.Add(Me.DtMonthlyAwal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 71)
        Me.GroupBox1.TabIndex = 262
        Me.GroupBox1.TabStop = False
        '
        'DtMonthlyAkhir
        '
        Me.DtMonthlyAkhir.CustomFormat = "MMMM yyyy"
        Me.DtMonthlyAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtMonthlyAkhir.Location = New System.Drawing.Point(203, 17)
        Me.DtMonthlyAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthlyAkhir.Name = "DtMonthlyAkhir"
        Me.DtMonthlyAkhir.ShowUpDown = True
        Me.DtMonthlyAkhir.Size = New System.Drawing.Size(131, 20)
        Me.DtMonthlyAkhir.TabIndex = 110
        '
        'DtMonthlyAwal
        '
        Me.DtMonthlyAwal.CustomFormat = "MMMM yyyy"
        Me.DtMonthlyAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtMonthlyAwal.Location = New System.Drawing.Point(57, 17)
        Me.DtMonthlyAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthlyAwal.Name = "DtMonthlyAwal"
        Me.DtMonthlyAwal.ShowUpDown = True
        Me.DtMonthlyAwal.Size = New System.Drawing.Size(131, 20)
        Me.DtMonthlyAwal.TabIndex = 110
        '
        'RdRangeMonthly
        '
        Me.RdRangeMonthly.AutoSize = True
        Me.RdRangeMonthly.Location = New System.Drawing.Point(23, 162)
        Me.RdRangeMonthly.Name = "RdRangeMonthly"
        Me.RdRangeMonthly.Size = New System.Drawing.Size(97, 17)
        Me.RdRangeMonthly.TabIndex = 263
        Me.RdRangeMonthly.TabStop = True
        Me.RdRangeMonthly.Text = "Range Monthly"
        Me.RdRangeMonthly.UseVisualStyleBackColor = True
        '
        'RdMonthly
        '
        Me.RdMonthly.AutoSize = True
        Me.RdMonthly.Location = New System.Drawing.Point(23, 63)
        Me.RdMonthly.Name = "RdMonthly"
        Me.RdMonthly.Size = New System.Drawing.Size(62, 17)
        Me.RdMonthly.TabIndex = 264
        Me.RdMonthly.TabStop = True
        Me.RdMonthly.Text = "Monthly"
        Me.RdMonthly.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtNamaDivisiMonthly)
        Me.GroupBox2.Controls.Add(Me.TxtDivisiMonthly)
        Me.GroupBox2.Controls.Add(Me.DtMonthly)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(347, 70)
        Me.GroupBox2.TabIndex = 265
        Me.GroupBox2.TabStop = False
        '
        'DtMonthly
        '
        Me.DtMonthly.CustomFormat = "MMMM yyyy"
        Me.DtMonthly.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtMonthly.Location = New System.Drawing.Point(57, 17)
        Me.DtMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthly.Name = "DtMonthly"
        Me.DtMonthly.ShowUpDown = True
        Me.DtMonthly.Size = New System.Drawing.Size(131, 20)
        Me.DtMonthly.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Bulan :"
        '
        'RdYearly
        '
        Me.RdYearly.AutoSize = True
        Me.RdYearly.Location = New System.Drawing.Point(23, 255)
        Me.RdYearly.Name = "RdYearly"
        Me.RdYearly.Size = New System.Drawing.Size(54, 17)
        Me.RdYearly.TabIndex = 266
        Me.RdYearly.TabStop = True
        Me.RdYearly.Text = "Yearly"
        Me.RdYearly.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TxtNamaDivisiYearly)
        Me.GroupBox3.Controls.Add(Me.TxtDivisiYearly)
        Me.GroupBox3.Controls.Add(Me.DtYearly)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(41, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(347, 68)
        Me.GroupBox3.TabIndex = 267
        Me.GroupBox3.TabStop = False
        '
        'DtYearly
        '
        Me.DtYearly.CustomFormat = "yyyy"
        Me.DtYearly.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtYearly.Location = New System.Drawing.Point(57, 17)
        Me.DtYearly.Margin = New System.Windows.Forms.Padding(1)
        Me.DtYearly.Name = "DtYearly"
        Me.DtYearly.ShowUpDown = True
        Me.DtYearly.Size = New System.Drawing.Size(71, 20)
        Me.DtYearly.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Tahun :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.TxtNamaDivisi)
        Me.GroupBox4.Controls.Add(Me.TxtDivisi)
        Me.GroupBox4.Location = New System.Drawing.Point(41, 361)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(347, 52)
        Me.GroupBox4.TabIndex = 269
        Me.GroupBox4.TabStop = False
        '
        'RdDivisi
        '
        Me.RdDivisi.AutoSize = True
        Me.RdDivisi.Location = New System.Drawing.Point(23, 345)
        Me.RdDivisi.Name = "RdDivisi"
        Me.RdDivisi.Size = New System.Drawing.Size(95, 17)
        Me.RdDivisi.TabIndex = 268
        Me.RdDivisi.TabStop = True
        Me.RdDivisi.Text = "Division Based"
        Me.RdDivisi.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 41)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Divisi   :"
        '
        'TxtNamaDivisiMonthly
        '
        Me.TxtNamaDivisiMonthly.EnterMoveNextControl = True
        Me.TxtNamaDivisiMonthly.Location = New System.Drawing.Point(129, 39)
        Me.TxtNamaDivisiMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisiMonthly.Name = "TxtNamaDivisiMonthly"
        Me.TxtNamaDivisiMonthly.Properties.ReadOnly = True
        Me.TxtNamaDivisiMonthly.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisiMonthly.TabIndex = 244
        '
        'TxtDivisiMonthly
        '
        Me.TxtDivisiMonthly.Location = New System.Drawing.Point(57, 39)
        Me.TxtDivisiMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisiMonthly.Name = "TxtDivisiMonthly"
        Me.TxtDivisiMonthly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisiMonthly.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisiMonthly.TabIndex = 243
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 248
        Me.Label7.Text = "Divisi   :"
        '
        'TxtNamaDivisiRangeMonthly
        '
        Me.TxtNamaDivisiRangeMonthly.EnterMoveNextControl = True
        Me.TxtNamaDivisiRangeMonthly.Location = New System.Drawing.Point(129, 39)
        Me.TxtNamaDivisiRangeMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisiRangeMonthly.Name = "TxtNamaDivisiRangeMonthly"
        Me.TxtNamaDivisiRangeMonthly.Properties.ReadOnly = True
        Me.TxtNamaDivisiRangeMonthly.Size = New System.Drawing.Size(205, 20)
        Me.TxtNamaDivisiRangeMonthly.TabIndex = 247
        '
        'TxtDivisiRangeMonthly
        '
        Me.TxtDivisiRangeMonthly.Location = New System.Drawing.Point(57, 39)
        Me.TxtDivisiRangeMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisiRangeMonthly.Name = "TxtDivisiRangeMonthly"
        Me.TxtDivisiRangeMonthly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisiRangeMonthly.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisiRangeMonthly.TabIndex = 246
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 41)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Divisi   :"
        '
        'TxtNamaDivisiYearly
        '
        Me.TxtNamaDivisiYearly.EnterMoveNextControl = True
        Me.TxtNamaDivisiYearly.Location = New System.Drawing.Point(129, 39)
        Me.TxtNamaDivisiYearly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisiYearly.Name = "TxtNamaDivisiYearly"
        Me.TxtNamaDivisiYearly.Properties.ReadOnly = True
        Me.TxtNamaDivisiYearly.Size = New System.Drawing.Size(160, 20)
        Me.TxtNamaDivisiYearly.TabIndex = 247
        '
        'TxtDivisiYearly
        '
        Me.TxtDivisiYearly.Location = New System.Drawing.Point(57, 39)
        Me.TxtDivisiYearly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisiYearly.Name = "TxtDivisiYearly"
        Me.TxtDivisiYearly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisiYearly.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisiYearly.TabIndex = 246
        '
        'LaporanSummaryFinishGoods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanSummaryFinishGoods"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TxtNamaDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisiRangeMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisiRangeMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisiYearly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisiYearly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        SplashScreenManager1.ShowWaitForm()
        If RdMonthly.Checked Then
            Dim MyReport = New XRSummaryBulanan
            MyReport.LblTangal.Text = "Periode " & Format(DtMonthly.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT A.*,GD.NAMA_GUDANG,D.NAMA FROM F_MONTHLY_SUMMARY(" & DtMonthly.Value.Month & "," & DtMonthly.Value.Year & "," & DtMonthly.Value.Month & "," & DtMonthly.Value.Year & ") A LEFT JOIN GUDANG GD ON A.GUDANG=GD.KODE LEFT JOIN DIVISI D ON A.DIVISI=D.KODE " & IIf(TxtDivisiMonthly.Text = "", "", " WHERE A.DIVISI='" & TxtDivisiMonthly.Text & "'"))

        ElseIf RdRangeMonthly.Checked Then
            Dim MyReport = New XRSummaryBulanan
            MyReport.LblTangal.Text = "Periode " & Format(DtMonthlyAwal.Value, "MMMM yyyy") & " s/d " & Format(DtMonthlyAkhir.Value, "MMMM yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT A.*,GD.NAMA_GUDANG,D.NAMA FROM F_MONTHLY_SUMMARY(" & DtMonthlyAwal.Value.Month & "," & DtMonthlyAwal.Value.Year & "," & DtMonthlyAkhir.Value.Month & "," & DtMonthlyAkhir.Value.Year & ") A LEFT JOIN GUDANG GD ON A.GUDANG=GD.KODE LEFT JOIN DIVISI D ON A.DIVISI=D.KODE " & IIf(TxtDivisiRangeMonthly.Text = "", "", " WHERE A.DIVISI='" & TxtDivisiRangeMonthly.Text & "'"))

        ElseIf RdYearly.Checked Then
            Dim MyReport = New XRSummaryTahunan
            MyReport.LblTangal.Text = "Periode " & Format(DtYearly.Value, "yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT A.*,GD.NAMA_GUDANG FROM F_MONTHLY_SUMMARY_TAHUN(" & DtYearly.Value.Year & ",'" & TxtDivisiYearly.Text & "') A LEFT JOIN GUDANG GD ON A.GUDANG=GD.KODE")

        ElseIf RdDivisi.Checked Then
            Dim MyReport = New XRSummaryDivisi
            MyReport.LblTangal.Text = "Periode " & Format(DtYearly.Value, "yyyy")
            Report = MyReport
            Report.DataSource = SelectCon.execute("SELECT A.*,GD.NAMA_GUDANG,D.NAMA FROM F_SUMMARY_DIVISI() A LEFT JOIN GUDANG GD ON A.GUDANG=GD.KODE LEFT JOIN DIVISI D ON A.DIVISI=D.KODE WHERE A.DIVISI LIKE '%" & TxtDivisi.Text & "%'")

        End If

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN SUMMARY FINISH GOODS"
        DtMonthly.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        DtMonthlyAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        DtMonthlyAkhir.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        DtYearly.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

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


    Private Sub TxtDivisiMonthly_Click(sender As Object, e As System.EventArgs) Handles TxtDivisiMonthly.Click
        TxtDivisiMonthly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisiMonthly_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisiMonthly.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisiMonthly.Text & "'", {TxtNamaDivisiMonthly})
    End Sub
    Private Sub TxtDivisiMonthly_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisiMonthly.KeyPress
        If CharKeypress(TxtDivisiMonthly, e) Then TxtDivisiMonthly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub


    Private Sub TxtDivisiRangeMonthly_Click(sender As Object, e As System.EventArgs) Handles TxtDivisiRangeMonthly.Click
        TxtDivisiRangeMonthly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisiRangeMonthly_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisiRangeMonthly.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisiRangeMonthly.Text & "'", {TxtNamaDivisiRangeMonthly})
    End Sub
    Private Sub TxtDivisiRangeMonthly_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisiRangeMonthly.KeyPress
        If CharKeypress(TxtDivisiRangeMonthly, e) Then TxtDivisiRangeMonthly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub


    Private Sub TxtDivisiYearly_Click(sender As Object, e As System.EventArgs) Handles TxtDivisiYearly.Click
        TxtDivisiYearly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisiYearly_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisiYearly.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisiYearly.Text & "'", {TxtNamaDivisiYearly})
    End Sub
    Private Sub TxtDivisiYearly_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisiYearly.KeyPress
        If CharKeypress(TxtDivisiYearly, e) Then TxtDivisiYearly.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub
End Class
