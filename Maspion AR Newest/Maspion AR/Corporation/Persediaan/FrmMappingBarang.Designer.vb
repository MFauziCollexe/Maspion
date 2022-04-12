<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMappingBarang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMappingBarang))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BarManagerMain = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me._Toolbar1_Button1 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button2 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TBBarang = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TBMap = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBeditMap = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RBeditMapGudang = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBeditMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBeditMapGudang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManagerMain
        '
        Me.BarManagerMain.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl1)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl2)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl3)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl4)
        Me.BarManagerMain.Form = Me.SplitContainerControl1.Panel2
        Me.BarManagerMain.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button2, Me._Toolbar1_Button3})
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
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(922, 24)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 219)
        Me.BarDockControl2.Size = New System.Drawing.Size(922, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 24)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 195)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(922, 24)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 195)
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TxtNamaDivisi)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TxtDivisi)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LblTitle)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TBBarang)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.AutoScroll = True
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TBMap)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BarDockControl3)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BarDockControl4)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BarDockControl2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BarDockControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(922, 448)
        Me.SplitContainerControl1.SplitterPosition = 217
        Me.SplitContainerControl1.TabIndex = 289
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelControl5
        '
        Me.LabelControl5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl5.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl5.Location = New System.Drawing.Point(729, 17)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 141
        Me.LabelControl5.Text = "Divisi"
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNamaDivisi.Enabled = False
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(803, 14)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaDivisi.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(118, 20)
        Me.TxtNamaDivisi.TabIndex = 140
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDivisi.Location = New System.Drawing.Point(755, 14)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtDivisi.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(46, 20)
        Me.TxtDivisi.TabIndex = 139
        '
        'LblTitle
        '
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.LblTitle.Image = Global.Maspion.My.Resources.Resources.Background
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.LblTitle.Size = New System.Drawing.Size(922, 34)
        Me.LblTitle.TabIndex = 12
        Me.LblTitle.Text = "Mapping Barang"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBBarang
        '
        Me.TBBarang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBBarang.Location = New System.Drawing.Point(0, 37)
        Me.TBBarang.MainView = Me.GridView1
        Me.TBBarang.Name = "TBBarang"
        Me.TBBarang.Size = New System.Drawing.Size(922, 179)
        Me.TBBarang.TabIndex = 11
        Me.TBBarang.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.GridControl = Me.TBBarang
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView1.OptionsMenu.EnableColumnMenu = False
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TBMap
        '
        Me.TBMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBMap.Location = New System.Drawing.Point(0, 24)
        Me.TBMap.MainView = Me.GridView2
        Me.TBMap.Name = "TBMap"
        Me.TBMap.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RBeditMap, Me.RBeditMapGudang})
        Me.TBMap.Size = New System.Drawing.Size(922, 195)
        Me.TBMap.TabIndex = 12
        Me.TBMap.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.Row.Options.UseFont = True
        Me.GridView2.GridControl = Me.TBMap
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsCustomization.AllowColumnMoving = False
        Me.GridView2.OptionsCustomization.AllowFilter = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView2.OptionsMenu.EnableColumnMenu = False
        Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView2.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'RBeditMap
        '
        Me.RBeditMap.AutoHeight = False
        Me.RBeditMap.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus, "Hapus", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Tambah", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RBeditMap.Name = "RBeditMap"
        '
        'RBeditMapGudang
        '
        Me.RBeditMapGudang.AutoHeight = False
        Me.RBeditMapGudang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)})
        Me.RBeditMapGudang.Name = "RBeditMapGudang"
        Me.RBeditMapGudang.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Id = -1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl5.Size = New System.Drawing.Size(922, 22)
        '
        'FrmMappingBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 448)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.KeyPreview = True
        Me.Name = "FrmMappingBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping Barang"
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBBarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBeditMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBeditMapGudang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManagerMain As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents _Toolbar1_Button1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TBBarang As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TBMap As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBeditMap As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents RBeditMapGudang As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
