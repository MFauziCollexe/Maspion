Imports DevExpress.XtraCharts

Public Class LaporanSlowMovingNAgeing
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtMonthlyAwal As System.Windows.Forms.DateTimePicker
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaDivisiMonthly As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDivisiMonthly As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents RdSlowMoving As System.Windows.Forms.RadioButton
    Friend WithEvents RdStockAgeing As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaDivisiMonthly = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisiMonthly = New DevExpress.XtraEditors.ButtonEdit()
        Me.DtMonthlyAwal = New System.Windows.Forms.DateTimePicker()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        Me.RdStockAgeing = New System.Windows.Forms.RadioButton()
        Me.RdSlowMoving = New System.Windows.Forms.RadioButton()
        Me.XtraScrollableControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtNamaDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.RdSlowMoving)
        Me.XtraScrollableControl1.Controls.Add(Me.RdStockAgeing)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox1)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdStockAgeing, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RdSlowMoving, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Bulan :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(18, 168)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(347, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtNamaDivisiMonthly)
        Me.GroupBox1.Controls.Add(Me.TxtDivisiMonthly)
        Me.GroupBox1.Controls.Add(Me.DtMonthlyAwal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 70)
        Me.GroupBox1.TabIndex = 262
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 43)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 315
        Me.Label5.Text = "Divisi   :"
        '
        'TxtNamaDivisiMonthly
        '
        Me.TxtNamaDivisiMonthly.EnterMoveNextControl = True
        Me.TxtNamaDivisiMonthly.Location = New System.Drawing.Point(129, 40)
        Me.TxtNamaDivisiMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisiMonthly.Name = "TxtNamaDivisiMonthly"
        Me.TxtNamaDivisiMonthly.Properties.ReadOnly = True
        Me.TxtNamaDivisiMonthly.Size = New System.Drawing.Size(205, 20)
        Me.TxtNamaDivisiMonthly.TabIndex = 314
        '
        'TxtDivisiMonthly
        '
        Me.TxtDivisiMonthly.Location = New System.Drawing.Point(57, 40)
        Me.TxtDivisiMonthly.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisiMonthly.Name = "TxtDivisiMonthly"
        Me.TxtDivisiMonthly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisiMonthly.Size = New System.Drawing.Size(70, 20)
        Me.TxtDivisiMonthly.TabIndex = 313
        '
        'DtMonthlyAwal
        '
        Me.DtMonthlyAwal.CustomFormat = "MMMM yyyyy"
        Me.DtMonthlyAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtMonthlyAwal.Location = New System.Drawing.Point(57, 17)
        Me.DtMonthlyAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthlyAwal.Name = "DtMonthlyAwal"
        Me.DtMonthlyAwal.Size = New System.Drawing.Size(131, 21)
        Me.DtMonthlyAwal.TabIndex = 110
        '
        'RdStockAgeing
        '
        Me.RdStockAgeing.AutoSize = True
        Me.RdStockAgeing.Location = New System.Drawing.Point(18, 69)
        Me.RdStockAgeing.Name = "RdStockAgeing"
        Me.RdStockAgeing.Size = New System.Drawing.Size(87, 17)
        Me.RdStockAgeing.TabIndex = 263
        Me.RdStockAgeing.TabStop = True
        Me.RdStockAgeing.Text = "Stock Ageing"
        Me.RdStockAgeing.UseVisualStyleBackColor = True
        '
        'RdSlowMoving
        '
        Me.RdSlowMoving.AutoSize = True
        Me.RdSlowMoving.Location = New System.Drawing.Point(111, 69)
        Me.RdSlowMoving.Name = "RdSlowMoving"
        Me.RdSlowMoving.Size = New System.Drawing.Size(113, 17)
        Me.RdSlowMoving.TabIndex = 263
        Me.RdSlowMoving.TabStop = True
        Me.RdSlowMoving.Text = "Stock Slow Moving"
        Me.RdSlowMoving.UseVisualStyleBackColor = True
        '
        'LaporanSlowMovingNAgeing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanSlowMovingNAgeing"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtNamaDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisiMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRControlSummary
        MyReport.LblTangal.Text = "Periode " & Format(DtMonthlyAwal.Value, "MMMM yyyy")
        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT * FROM F_AGEING_STOK('" & Format(DtMonthlyAwal.Value, "yyyy-MM-dd") & "', " & IIf(TxtDivisiMonthly.Text = "", "DEFAULT", "'" & TxtDivisiMonthly.Text & "'") & ")")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN STOCK ANGEING & SLOW MOVING"
        DtMonthlyAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        SplashScreenManager1.ShowWaitForm()
        ReportShowPreview()
        SplashScreenManager1.CloseWaitForm()
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
End Class
