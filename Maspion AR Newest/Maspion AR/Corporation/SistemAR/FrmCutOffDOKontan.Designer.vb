<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCutOffDOKontan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCutOffDOKontan))
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GCDOKontan = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepoCalc2 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.TxtKeterangan = New DevExpress.XtraEditors.MemoEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.DTTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.TxtNoBukti = New DevExpress.XtraEditors.TextEdit()
        Me.TxtIDTransaksi = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GCDOKontan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoCalc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoBukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDTransaksi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Bar2.FloatLocation = New System.Drawing.Point(109, 286)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button4, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button6, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.LblTitle)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        '_Toolbar1_Button1
        '
        Me._Toolbar1_Button1.Caption = "F2 - Simpan"
        Me._Toolbar1_Button1.Id = 0
        Me._Toolbar1_Button1.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button1.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button1.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button1.Name = "_Toolbar1_Button1"
        '
        '_Toolbar1_Button2
        '
        Me._Toolbar1_Button2.Caption = "F3 - Bersih"
        Me._Toolbar1_Button2.Id = 1
        Me._Toolbar1_Button2.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button2.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button2.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button2.Name = "_Toolbar1_Button2"
        '
        '_Toolbar1_Button3
        '
        Me._Toolbar1_Button3.Caption = "F5 - Keluar"
        Me._Toolbar1_Button3.Id = 2
        Me._Toolbar1_Button3.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button3.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button3.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button3.Name = "_Toolbar1_Button3"
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.Caption = "F6 - Batal"
        Me._Toolbar1_Button4.Id = 3
        Me._Toolbar1_Button4.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button4.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button4.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        '
        '_Toolbar1_Button5
        '
        Me._Toolbar1_Button5.Caption = "F7 - Hapus"
        Me._Toolbar1_Button5.Id = 4
        Me._Toolbar1_Button5.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button5.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button5.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button5.Name = "_Toolbar1_Button5"
        '
        '_Toolbar1_Button6
        '
        Me._Toolbar1_Button6.Caption = "F8 - Cetak"
        Me._Toolbar1_Button6.Id = 5
        Me._Toolbar1_Button6.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button6.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button6.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button6.ImageOptions.LargeImage"), System.Drawing.Image)
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
        Me.BarDockControl1.Manager = Me.BarManagerMain
        Me.BarDockControl1.Size = New System.Drawing.Size(652, 24)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 261)
        Me.BarDockControl2.Manager = Me.BarManagerMain
        Me.BarDockControl2.Size = New System.Drawing.Size(652, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 24)
        Me.BarDockControl3.Manager = Me.BarManagerMain
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 237)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(652, 24)
        Me.BarDockControl4.Manager = Me.BarManagerMain
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 237)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GCDOKontan)
        Me.LayoutControl1.Controls.Add(Me.TxtKeterangan)
        Me.LayoutControl1.Controls.Add(Me.TxtNamaDivisi)
        Me.LayoutControl1.Controls.Add(Me.TxtKodeDivisi)
        Me.LayoutControl1.Controls.Add(Me.DTTanggal)
        Me.LayoutControl1.Controls.Add(Me.TxtNoBukti)
        Me.LayoutControl1.Controls.Add(Me.TxtIDTransaksi)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(652, 237)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GCDOKontan
        '
        Me.GCDOKontan.Location = New System.Drawing.Point(12, 100)
        Me.GCDOKontan.MainView = Me.GridView1
        Me.GCDOKontan.MenuManager = Me.BarManagerMain
        Me.GCDOKontan.Name = "GCDOKontan"
        Me.GCDOKontan.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepoCalc2})
        Me.GCDOKontan.Size = New System.Drawing.Size(628, 125)
        Me.GCDOKontan.TabIndex = 229
        Me.GCDOKontan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCDOKontan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepoCalc2
        '
        Me.RepoCalc2.AutoHeight = False
        Me.RepoCalc2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoCalc2.Name = "RepoCalc2"
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.Location = New System.Drawing.Point(380, 28)
        Me.TxtKeterangan.MenuManager = Me.BarManagerMain
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Size = New System.Drawing.Size(260, 68)
        Me.TxtKeterangan.StyleController = Me.LayoutControl1
        Me.TxtKeterangan.TabIndex = 228
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(147, 76)
        Me.TxtNamaDivisi.MenuManager = Me.BarManagerMain
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(115, 20)
        Me.TxtNamaDivisi.StyleController = Me.LayoutControl1
        Me.TxtNamaDivisi.TabIndex = 227
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(72, 76)
        Me.TxtKodeDivisi.MenuManager = Me.BarManagerMain
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(71, 20)
        Me.TxtKodeDivisi.StyleController = Me.LayoutControl1
        Me.TxtKodeDivisi.TabIndex = 226
        '
        'DTTanggal
        '
        Me.DTTanggal.EditValue = Nothing
        Me.DTTanggal.Location = New System.Drawing.Point(72, 52)
        Me.DTTanggal.MenuManager = Me.BarManagerMain
        Me.DTTanggal.Name = "DTTanggal"
        Me.DTTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTTanggal.Size = New System.Drawing.Size(190, 20)
        Me.DTTanggal.StyleController = Me.LayoutControl1
        Me.DTTanggal.TabIndex = 225
        '
        'TxtNoBukti
        '
        Me.TxtNoBukti.Location = New System.Drawing.Point(72, 28)
        Me.TxtNoBukti.MenuManager = Me.BarManagerMain
        Me.TxtNoBukti.Name = "TxtNoBukti"
        Me.TxtNoBukti.Properties.ReadOnly = True
        Me.TxtNoBukti.Size = New System.Drawing.Size(190, 20)
        Me.TxtNoBukti.StyleController = Me.LayoutControl1
        Me.TxtNoBukti.TabIndex = 224
        '
        'TxtIDTransaksi
        '
        Me.TxtIDTransaksi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIDTransaksi.EditValue = ""
        Me.TxtIDTransaksi.Enabled = False
        Me.TxtIDTransaksi.EnterMoveNextControl = True
        Me.TxtIDTransaksi.Location = New System.Drawing.Point(12, 12)
        Me.TxtIDTransaksi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDTransaksi.Name = "TxtIDTransaksi"
        Me.TxtIDTransaksi.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIDTransaksi.Properties.Appearance.Options.UseFont = True
        Me.TxtIDTransaksi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.TxtIDTransaksi.Properties.ReadOnly = True
        Me.TxtIDTransaksi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIDTransaksi.Size = New System.Drawing.Size(250, 12)
        Me.TxtIDTransaksi.StyleController = Me.LayoutControl1
        Me.TxtIDTransaksi.TabIndex = 223
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(652, 237)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtIDTransaksi
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(254, 16)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtNoBukti
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 16)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "No. Cut Off"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(57, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(254, 0)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(114, 88)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(114, 88)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(114, 88)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DTTanggal
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(254, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Tanggal"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(57, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtKodeDivisi
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Divisi"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(57, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtNamaDivisi
        Me.LayoutControlItem5.Location = New System.Drawing.Point(135, 64)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(119, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(119, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(119, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtKeterangan
        Me.LayoutControlItem6.Location = New System.Drawing.Point(368, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(264, 88)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(264, 88)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(264, 88)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Keterangan"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(57, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GCDOKontan
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 88)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(632, 129)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'FrmCutOffDOKontan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 261)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Name = "FrmCutOffDOKontan"
        Me.Text = "Cut Off DO Kontan"
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GCDOKontan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoCalc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoBukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDTransaksi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GCDOKontan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtKeterangan As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DTTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TxtNoBukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtIDTransaksi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepoCalc2 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
End Class
