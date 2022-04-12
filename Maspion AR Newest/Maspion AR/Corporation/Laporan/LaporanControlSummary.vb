Imports DevExpress.XtraCharts

Public Class LaporanControlSummary
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtMonthlyAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtMonthlyAkhir As System.Windows.Forms.DateTimePicker
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtMonthlyAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DtMonthlyAwal = New System.Windows.Forms.DateTimePicker()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox1)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.GroupBox1, 0)
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
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(18, 155)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(347, 23)
        Me.BtnView.TabIndex = 243
        Me.BtnView.Text = "View"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtNamaGudang)
        Me.GroupBox1.Controls.Add(Me.TxtKodeGudang)
        Me.GroupBox1.Controls.Add(Me.DtMonthlyAkhir)
        Me.GroupBox1.Controls.Add(Me.DtMonthlyAwal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 76)
        Me.GroupBox1.TabIndex = 262
        Me.GroupBox1.TabStop = False
        '
        'DtMonthlyAkhir
        '
        Me.DtMonthlyAkhir.CustomFormat = ""
        Me.DtMonthlyAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtMonthlyAkhir.Location = New System.Drawing.Point(203, 17)
        Me.DtMonthlyAkhir.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthlyAkhir.Name = "DtMonthlyAkhir"
        Me.DtMonthlyAkhir.Size = New System.Drawing.Size(131, 20)
        Me.DtMonthlyAkhir.TabIndex = 110
        '
        'DtMonthlyAwal
        '
        Me.DtMonthlyAwal.CustomFormat = ""
        Me.DtMonthlyAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtMonthlyAwal.Location = New System.Drawing.Point(57, 17)
        Me.DtMonthlyAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtMonthlyAwal.Name = "DtMonthlyAwal"
        Me.DtMonthlyAwal.Size = New System.Drawing.Size(131, 20)
        Me.DtMonthlyAwal.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 312
        Me.Label4.Text = "Gudang :"
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(129, 39)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(205, 20)
        Me.TxtNamaGudang.TabIndex = 311
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(57, 39)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Size = New System.Drawing.Size(70, 20)
        Me.TxtKodeGudang.TabIndex = 310
        '
        'LaporanControlSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 485)
        Me.Name = "LaporanControlSummary"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim MyReport = New XRControlSummary
        MyReport.LblTangal.Text = "Periode " & Format(DtMonthlyAwal.Value, "MMMM yyyy") & " s/d " & Format(DtMonthlyAkhir.Value, "MMMM yyyy")
        Report = MyReport
        Report.DataSource = SelectCon.execute("SELECT A.*, B.NAMA, C.NAMA AS NAMA_DIVISI, D.NAMA_GUDANG FROM F_CONTROL_SUMMARY(CAST('" & Format(DtMonthlyAwal.Value, "MM/dd/yyyy") & "' AS DATE),CAST('" & Format(DtMonthlyAkhir.Value, "MM/dd/yyyy") & "' AS DATE)) A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN DIVISI C ON A.DIVISI=C.KODE LEFT JOIN GUDANG D ON A.GUDANG=D.KODE " & IIf(TxtKodeGudang.Text = "", "", " WHERE A.GUDANG='" & TxtKodeGudang.Text & "'"))

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "LAPORAN CONTROL SUMMARY"
        DtMonthlyAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        DtMonthlyAkhir.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
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
        SplashScreenManager1.ShowWaitForm()
        ReportShowPreview()
        SplashScreenManager1.CloseWaitForm()
    End Sub
End Class
