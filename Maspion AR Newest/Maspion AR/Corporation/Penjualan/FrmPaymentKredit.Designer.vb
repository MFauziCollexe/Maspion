<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaymentKredit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaymentKredit))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me._Toolbar1_Button3 = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me._Toolbar1_Button2 = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._Toolbar1_Button6 = New System.Windows.Forms.ToolStripButton()
        Me.LblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.TBMonitoring = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.TglPeriode = New System.Windows.Forms.DateTimePicker()
        Me.RDStatus = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Toolbar1.SuspendLayout()
        CType(Me.TBMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.RDStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        '
        '_Toolbar1_Button3
        '
        Me._Toolbar1_Button3.AutoSize = False
        Me._Toolbar1_Button3.ImageIndex = 2
        Me._Toolbar1_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button3.Name = "_Toolbar1_Button3"
        Me._Toolbar1_Button3.Size = New System.Drawing.Size(91, 22)
        Me._Toolbar1_Button3.Text = "F6 - Keluar"
        Me._Toolbar1_Button3.ToolTipText = "F4 - Keluar"
        '
        '_Toolbar1_Button1
        '
        Me._Toolbar1_Button1.AutoSize = False
        Me._Toolbar1_Button1.ImageIndex = 0
        Me._Toolbar1_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button1.Name = "_Toolbar1_Button1"
        Me._Toolbar1_Button1.Size = New System.Drawing.Size(90, 22)
        Me._Toolbar1_Button1.Text = "F2 - Proses"
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button2, Me._Toolbar1_Button4, Me._Toolbar1_Button3, Me.ToolStripSeparator1, Me._Toolbar1_Button6})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(815, 25)
        Me.Toolbar1.TabIndex = 52
        '
        '_Toolbar1_Button2
        '
        Me._Toolbar1_Button2.AutoSize = False
        Me._Toolbar1_Button2.ImageIndex = 1
        Me._Toolbar1_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button2.Name = "_Toolbar1_Button2"
        Me._Toolbar1_Button2.Size = New System.Drawing.Size(110, 22)
        Me._Toolbar1_Button2.Text = "F3 - Bersih"
        Me._Toolbar1_Button2.ToolTipText = "F3 - Batal"
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.Image = Global.Maspion.PrintRibbonControllerResources.RibbonPrintPreview_ClosePreview
        Me._Toolbar1_Button4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        Me._Toolbar1_Button4.Size = New System.Drawing.Size(134, 22)
        Me._Toolbar1_Button4.Text = "F5 - Hapus Payment"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        '_Toolbar1_Button6
        '
        Me._Toolbar1_Button6.Image = Global.Maspion.PrintRibbonControllerResources.RibbonPrintPreview_PrintDirect
        Me._Toolbar1_Button6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Toolbar1_Button6.Name = "_Toolbar1_Button6"
        Me._Toolbar1_Button6.Size = New System.Drawing.Size(80, 22)
        Me._Toolbar1_Button6.Text = "F8 - Cetak"
        '
        'LblTitle
        '
        Me.LblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LblTitle.Location = New System.Drawing.Point(12, 9)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(213, 25)
        Me.LblTitle.TabIndex = 170
        Me.LblTitle.Text = "Monitoring Payment"
        '
        'TBMonitoring
        '
        Me.TBMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBMonitoring.Location = New System.Drawing.Point(3, 17)
        Me.TBMonitoring.MainView = Me.GridView1
        Me.TBMonitoring.Name = "TBMonitoring"
        Me.TBMonitoring.Size = New System.Drawing.Size(803, 398)
        Me.TBMonitoring.TabIndex = 11
        Me.TBMonitoring.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.GridControl = Me.TBMonitoring
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.TglPeriode)
        Me.XtraScrollableControl1.Controls.Add(Me.RDStatus)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl14)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupBox1)
        Me.XtraScrollableControl1.Controls.Add(Me.LblTitle)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 25)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(815, 461)
        Me.XtraScrollableControl1.TabIndex = 0
        '
        'TglPeriode
        '
        Me.TglPeriode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TglPeriode.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglPeriode.CustomFormat = "MMMM yyyy"
        Me.TglPeriode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglPeriode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglPeriode.Location = New System.Drawing.Point(676, 12)
        Me.TglPeriode.Margin = New System.Windows.Forms.Padding(1)
        Me.TglPeriode.Name = "TglPeriode"
        Me.TglPeriode.ShowUpDown = True
        Me.TglPeriode.Size = New System.Drawing.Size(136, 22)
        Me.TglPeriode.TabIndex = 215
        '
        'RDStatus
        '
        Me.RDStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RDStatus.EditValue = "Belum Lunas"
        Me.RDStatus.EnterMoveNextControl = True
        Me.RDStatus.Location = New System.Drawing.Point(412, 12)
        Me.RDStatus.Margin = New System.Windows.Forms.Padding(1)
        Me.RDStatus.Name = "RDStatus"
        Me.RDStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RDStatus.Properties.Appearance.Options.UseBackColor = True
        Me.RDStatus.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Belum Lunas", "Belum Lunas"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Sudah Lunas", "Sudah Lunas"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Semua", "Semua")})
        Me.RDStatus.Size = New System.Drawing.Size(262, 22)
        Me.RDStatus.TabIndex = 214
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Location = New System.Drawing.Point(376, 17)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl14.TabIndex = 213
        Me.LabelControl14.Text = "Filter :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TBMonitoring)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(809, 418)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'FrmMonitoringPayment
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 486)
        Me.Controls.Add(Me.XtraScrollableControl1)
        Me.Controls.Add(Me.Toolbar1)
        Me.KeyPreview = True
        Me.Name = "FrmMonitoringPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Order"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.TBMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.RDStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents _Toolbar1_Button3 As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button1 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TBMonitoring As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents _Toolbar1_Button6 As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RDStatus As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TglPeriode As System.Windows.Forms.DateTimePicker
    Friend WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripButton
End Class
