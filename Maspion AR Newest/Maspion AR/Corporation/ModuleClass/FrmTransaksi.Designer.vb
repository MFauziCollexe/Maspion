<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransaksi))
        Me.BarManagerMain = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me._Toolbar1_Button1 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button2 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button3 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button4 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button5 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button6 = New DevExpress.XtraBars.BarButtonItem()
        Me.LblTitle = New DevExpress.XtraBars.BarStaticItem()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManagerMain
        '
        Me.BarManagerMain.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl1)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl2)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl3)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl4)
        Me.BarManagerMain.Form = Me
        Me.BarManagerMain.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button2, Me._Toolbar1_Button3, Me._Toolbar1_Button4, Me._Toolbar1_Button5, Me._Toolbar1_Button6, Me.LblTitle})
        Me.BarManagerMain.MainMenu = Me.Bar2
        Me.BarManagerMain.MaxItemId = 7
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button4, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button6, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.LblTitle)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        '_Toolbar1_Button1
        '
        Me._Toolbar1_Button1.Caption = "F2 - Simpan"
        Me._Toolbar1_Button1.Glyph = CType(resources.GetObject("_Toolbar1_Button1.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button1.Id = 0
        Me._Toolbar1_Button1.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button1.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button1.Name = "_Toolbar1_Button1"
        '
        '_Toolbar1_Button2
        '
        Me._Toolbar1_Button2.Caption = "F3 - Bersih"
        Me._Toolbar1_Button2.Glyph = CType(resources.GetObject("_Toolbar1_Button2.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button2.Id = 1
        Me._Toolbar1_Button2.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button2.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button2.Name = "_Toolbar1_Button2"
        '
        '_Toolbar1_Button3
        '
        Me._Toolbar1_Button3.Caption = "F5 - Keluar"
        Me._Toolbar1_Button3.Glyph = CType(resources.GetObject("_Toolbar1_Button3.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button3.Id = 2
        Me._Toolbar1_Button3.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button3.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button3.Name = "_Toolbar1_Button3"
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.Caption = "F6 - Batal"
        Me._Toolbar1_Button4.Glyph = CType(resources.GetObject("_Toolbar1_Button4.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button4.Id = 3
        Me._Toolbar1_Button4.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button4.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        '
        '_Toolbar1_Button5
        '
        Me._Toolbar1_Button5.Caption = "F7 - Hapus"
        Me._Toolbar1_Button5.Glyph = CType(resources.GetObject("_Toolbar1_Button5.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button5.Id = 4
        Me._Toolbar1_Button5.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button5.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button5.Name = "_Toolbar1_Button5"
        '
        '_Toolbar1_Button6
        '
        Me._Toolbar1_Button6.Caption = "F8 - Cetak"
        Me._Toolbar1_Button6.Glyph = CType(resources.GetObject("_Toolbar1_Button6.Glyph"), System.Drawing.Image)
        Me._Toolbar1_Button6.Id = 5
        Me._Toolbar1_Button6.LargeGlyph = CType(resources.GetObject("_Toolbar1_Button6.LargeGlyph"), System.Drawing.Image)
        Me._Toolbar1_Button6.Name = "_Toolbar1_Button6"
        '
        'LblTitle
        '
        Me.LblTitle.Id = 6
        Me.LblTitle.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ItemAppearance.Normal.Options.UseFont = True
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(816, 24)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 325)
        Me.BarDockControl2.Size = New System.Drawing.Size(816, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 24)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 301)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(816, 24)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 301)
        '
        'FrmTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 325)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.KeyPreview = True
        Me.Name = "FrmTransaksi"
        Me.Text = "FrmTransaksi"
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManagerMain As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents _Toolbar1_Button1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LblTitle As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
End Class
