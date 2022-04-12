<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuDetail))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TBMenuDetailMenu = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.TBMenu = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BtnEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLihat = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCetak = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarButtonBaru = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticSplit1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonFirst = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonNext = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonLast = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticSpilt1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonKeluar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonCetakDaftar = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCetakBeberapa = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TBMenuDetailMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        CType(Me.TBMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TBMenuDetailMenu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 131)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Bahan"
        '
        'TBMenuDetailMenu
        '
        Me.TBMenuDetailMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBMenuDetailMenu.Location = New System.Drawing.Point(0, 13)
        Me.TBMenuDetailMenu.MainView = Me.GridView2
        Me.TBMenuDetailMenu.Name = "TBMenuDetailMenu"
        Me.TBMenuDetailMenu.Size = New System.Drawing.Size(1002, 118)
        Me.TBMenuDetailMenu.TabIndex = 0
        Me.TBMenuDetailMenu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.Empty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridView2.Appearance.Empty.Options.UseBackColor = True
        Me.GridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro
        Me.GridView2.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightBlue
        Me.GridView2.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView2.GridControl = Me.TBMenuDetailMenu
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Transparent
        Me.Frame1.Controls.Add(Me.TBMenu)
        Me.Frame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(1002, 252)
        Me.Frame1.TabIndex = 22
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Daftar Bahan Keluar :"
        '
        'TBMenu
        '
        Me.TBMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBMenu.Location = New System.Drawing.Point(0, 13)
        Me.TBMenu.MainView = Me.GridView1
        Me.TBMenu.Name = "TBMenu"
        Me.TBMenu.Size = New System.Drawing.Size(1002, 239)
        Me.TBMenu.TabIndex = 0
        Me.TBMenu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Empty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridView1.Appearance.Empty.Options.UseBackColor = True
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightBlue
        Me.GridView1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.TBMenu
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Frame1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1006, 396)
        Me.SplitContainerControl1.SplitterPosition = 256
        Me.SplitContainerControl1.TabIndex = 24
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ToolTipController1
        '
        Me.ToolTipController1.Appearance.Options.UseTextOptions = True
        Me.ToolTipController1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.ToolTipController1.AutoPopDelay = 9000
        Me.ToolTipController1.InitialDelay = 15
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.Caption Or DevExpress.XtraBars.BarLinkUserDefines.PaintStyle), DevExpress.XtraBars.BarLinkUserDefines), Me.BtnEdit, "Edit", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BtnLihat), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BtnCetak, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'BtnEdit
        '
        Me.BtnEdit.Caption = "Edit"
        Me.BtnEdit.Glyph = CType(resources.GetObject("BtnEdit.Glyph"), System.Drawing.Image)
        Me.BtnEdit.Id = 0
        Me.BtnEdit.LargeGlyph = CType(resources.GetObject("BtnEdit.LargeGlyph"), System.Drawing.Image)
        Me.BtnEdit.Name = "BtnEdit"
        '
        'BtnLihat
        '
        Me.BtnLihat.Caption = "Lihat"
        Me.BtnLihat.Glyph = CType(resources.GetObject("BtnLihat.Glyph"), System.Drawing.Image)
        Me.BtnLihat.Id = 1
        Me.BtnLihat.LargeGlyph = CType(resources.GetObject("BtnLihat.LargeGlyph"), System.Drawing.Image)
        Me.BtnLihat.Name = "BtnLihat"
        '
        'BtnCetak
        '
        Me.BtnCetak.Caption = "Cetak"
        Me.BtnCetak.Glyph = CType(resources.GetObject("BtnCetak.Glyph"), System.Drawing.Image)
        Me.BtnCetak.Id = 2
        Me.BtnCetak.LargeGlyph = CType(resources.GetObject("BtnCetak.LargeGlyph"), System.Drawing.Image)
        Me.BtnCetak.Name = "BtnCetak"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BtnEdit, Me.BtnLihat, Me.BtnCetak, Me.BarButtonBaru, Me.BarButtonEdit, Me.BarButtonFirst, Me.BarButtonPrevious, Me.BarButtonNext, Me.BarButtonLast, Me.BarButtonKeluar, Me.BarButtonCetakDaftar, Me.BarStaticSplit1, Me.BarStaticSpilt1, Me.BtnCetakBeberapa})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 15
        '
        'Bar1
        '
        Me.Bar1.BarName = "Menu"
        Me.Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.FloatLocation = New System.Drawing.Point(444, 331)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonBaru), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticSplit1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonFirst), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonPrevious), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonNext), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonLast), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticSpilt1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonKeluar), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonCetakDaftar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BtnCetakBeberapa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Menu"
        '
        'BarButtonBaru
        '
        Me.BarButtonBaru.Caption = "F2 - Baru"
        Me.BarButtonBaru.Glyph = CType(resources.GetObject("BarButtonBaru.Glyph"), System.Drawing.Image)
        Me.BarButtonBaru.Id = 3
        Me.BarButtonBaru.LargeGlyph = CType(resources.GetObject("BarButtonBaru.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonBaru.Name = "BarButtonBaru"
        Me.BarButtonBaru.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonEdit
        '
        Me.BarButtonEdit.Caption = "F3 - Edit"
        Me.BarButtonEdit.Glyph = CType(resources.GetObject("BarButtonEdit.Glyph"), System.Drawing.Image)
        Me.BarButtonEdit.Id = 4
        Me.BarButtonEdit.LargeGlyph = CType(resources.GetObject("BarButtonEdit.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonEdit.Name = "BarButtonEdit"
        Me.BarButtonEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticSplit1
        '
        Me.BarStaticSplit1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.BarStaticSplit1.Caption = "|"
        Me.BarStaticSplit1.Id = 11
        Me.BarStaticSplit1.Name = "BarStaticSplit1"
        Me.BarStaticSplit1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.BarStaticSplit1.Width = 75
        '
        'BarButtonFirst
        '
        Me.BarButtonFirst.Caption = "First"
        Me.BarButtonFirst.Glyph = CType(resources.GetObject("BarButtonFirst.Glyph"), System.Drawing.Image)
        Me.BarButtonFirst.Id = 5
        Me.BarButtonFirst.LargeGlyph = CType(resources.GetObject("BarButtonFirst.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonFirst.Name = "BarButtonFirst"
        Me.BarButtonFirst.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonPrevious
        '
        Me.BarButtonPrevious.Caption = "Previous"
        Me.BarButtonPrevious.Glyph = CType(resources.GetObject("BarButtonPrevious.Glyph"), System.Drawing.Image)
        Me.BarButtonPrevious.Id = 6
        Me.BarButtonPrevious.LargeGlyph = CType(resources.GetObject("BarButtonPrevious.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonPrevious.Name = "BarButtonPrevious"
        Me.BarButtonPrevious.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonNext
        '
        Me.BarButtonNext.Caption = "Next"
        Me.BarButtonNext.Glyph = CType(resources.GetObject("BarButtonNext.Glyph"), System.Drawing.Image)
        Me.BarButtonNext.Id = 7
        Me.BarButtonNext.LargeGlyph = CType(resources.GetObject("BarButtonNext.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonNext.Name = "BarButtonNext"
        Me.BarButtonNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonLast
        '
        Me.BarButtonLast.Caption = "Last"
        Me.BarButtonLast.Glyph = CType(resources.GetObject("BarButtonLast.Glyph"), System.Drawing.Image)
        Me.BarButtonLast.Id = 8
        Me.BarButtonLast.LargeGlyph = CType(resources.GetObject("BarButtonLast.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonLast.Name = "BarButtonLast"
        Me.BarButtonLast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticSpilt1
        '
        Me.BarStaticSpilt1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.BarStaticSpilt1.Caption = "|"
        Me.BarStaticSpilt1.Id = 13
        Me.BarStaticSpilt1.Name = "BarStaticSpilt1"
        Me.BarStaticSpilt1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.BarStaticSpilt1.Width = 75
        '
        'BarButtonKeluar
        '
        Me.BarButtonKeluar.Caption = "F5 - Keluar"
        Me.BarButtonKeluar.Glyph = CType(resources.GetObject("BarButtonKeluar.Glyph"), System.Drawing.Image)
        Me.BarButtonKeluar.Id = 9
        Me.BarButtonKeluar.LargeGlyph = CType(resources.GetObject("BarButtonKeluar.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonKeluar.Name = "BarButtonKeluar"
        Me.BarButtonKeluar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonCetakDaftar
        '
        Me.BarButtonCetakDaftar.Caption = "F6 - Cetak Daftar"
        Me.BarButtonCetakDaftar.Glyph = CType(resources.GetObject("BarButtonCetakDaftar.Glyph"), System.Drawing.Image)
        Me.BarButtonCetakDaftar.Id = 10
        Me.BarButtonCetakDaftar.LargeGlyph = CType(resources.GetObject("BarButtonCetakDaftar.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonCetakDaftar.Name = "BarButtonCetakDaftar"
        '
        'BtnCetakBeberapa
        '
        Me.BtnCetakBeberapa.Caption = "F7 - Cetak Beberapa"
        Me.BtnCetakBeberapa.Glyph = CType(resources.GetObject("BtnCetakBeberapa.Glyph"), System.Drawing.Image)
        Me.BtnCetakBeberapa.Id = 14
        Me.BtnCetakBeberapa.LargeGlyph = CType(resources.GetObject("BtnCetakBeberapa.LargeGlyph"), System.Drawing.Image)
        Me.BtnCetakBeberapa.Name = "BtnCetakBeberapa"
        Me.BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1006, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 420)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1006, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 396)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1006, 24)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 396)
        '
        'FrmMenuDetail
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 420)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "FrmMenuDetail"
        Me.Text = "Menu"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TBMenuDetailMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        CType(Me.TBMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBMenuDetailMenu As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBMenu As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BtnEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLihat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCetak As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonBaru As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticSplit1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarButtonFirst As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonPrevious As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonNext As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonLast As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticSpilt1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarButtonKeluar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonCetakDaftar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BtnCetakBeberapa As DevExpress.XtraBars.BarButtonItem
End Class
