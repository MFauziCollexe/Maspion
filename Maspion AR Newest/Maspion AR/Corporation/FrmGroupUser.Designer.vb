<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGroupUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGroupUser))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNama = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtKode = New DevExpress.XtraEditors.TextEdit()
        Me.TabCntrl = New DevExpress.XtraTab.XtraTabControl()
        Me.SistemAR = New DevExpress.XtraTab.XtraTabPage()
        Me.CekSistemAR = New DevExpress.XtraEditors.CheckEdit()
        Me.SCPenjualanLangganan = New DevExpress.XtraEditors.SplitContainerControl()
        Me.TBSistemAR = New DevExpress.XtraGrid.GridControl()
        Me.GVPenjualanLanggananPerwakilan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Sistem = New DevExpress.XtraTab.XtraTabPage()
        Me.TBSistem = New DevExpress.XtraGrid.GridControl()
        Me.GVSistem = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CekSistem = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManagerMain = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me._Toolbar1_Button1 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button2 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button3 = New DevExpress.XtraBars.BarButtonItem()
        Me._Toolbar1_Button5 = New DevExpress.XtraBars.BarButtonItem()
        Me.LblTitle = New DevExpress.XtraBars.BarStaticItem()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabCntrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCntrl.SuspendLayout()
        Me.SistemAR.SuspendLayout()
        CType(Me.CekSistemAR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCPenjualanLangganan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCPenjualanLangganan.SuspendLayout()
        CType(Me.TBSistemAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPenjualanLanggananPerwakilan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sistem.SuspendLayout()
        CType(Me.TBSistem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSistem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CekSistem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(14, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = "Nama Group User"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(134, 55)
        Me.txtNama.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtNama.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.txtNama.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.txtNama.Properties.MaxLength = 50
        Me.txtNama.Size = New System.Drawing.Size(283, 20)
        Me.txtNama.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(14, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(92, 16)
        Me.Label8.TabIndex = 167
        Me.Label8.Text = "Kode Group"
        '
        'txtKode
        '
        Me.txtKode.EnterMoveNextControl = True
        Me.txtKode.Location = New System.Drawing.Point(134, 33)
        Me.txtKode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtKode.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.txtKode.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.txtKode.Properties.MaxLength = 5
        Me.txtKode.Size = New System.Drawing.Size(75, 20)
        Me.txtKode.TabIndex = 0
        '
        'TabCntrl
        '
        Me.TabCntrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCntrl.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.TabCntrl.Location = New System.Drawing.Point(5, 79)
        Me.TabCntrl.Name = "TabCntrl"
        Me.TabCntrl.SelectedTabPage = Me.SistemAR
        Me.TabCntrl.Size = New System.Drawing.Size(989, 399)
        Me.TabCntrl.TabIndex = 170
        Me.TabCntrl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.SistemAR, Me.Sistem})
        '
        'SistemAR
        '
        Me.SistemAR.Controls.Add(Me.CekSistemAR)
        Me.SistemAR.Controls.Add(Me.SCPenjualanLangganan)
        Me.SistemAR.Name = "SistemAR"
        Me.SistemAR.Size = New System.Drawing.Size(983, 371)
        Me.SistemAR.Text = "Sistem AR"
        '
        'CekSistemAR
        '
        Me.CekSistemAR.AutoSizeInLayoutControl = True
        Me.CekSistemAR.Location = New System.Drawing.Point(3, 3)
        Me.CekSistemAR.Name = "CekSistemAR"
        Me.CekSistemAR.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CekSistemAR.Properties.Appearance.Options.UseFont = True
        Me.CekSistemAR.Properties.Caption = "Sistem AR"
        Me.CekSistemAR.Properties.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.CekSistemAR.Size = New System.Drawing.Size(181, 19)
        Me.CekSistemAR.TabIndex = 164
        '
        'SCPenjualanLangganan
        '
        Me.SCPenjualanLangganan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SCPenjualanLangganan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SCPenjualanLangganan.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SCPenjualanLangganan.Location = New System.Drawing.Point(0, 28)
        Me.SCPenjualanLangganan.Name = "SCPenjualanLangganan"
        Me.SCPenjualanLangganan.Panel1.Controls.Add(Me.CheckEdit1)
        Me.SCPenjualanLangganan.Panel1.Controls.Add(Me.TBSistemAR)
        Me.SCPenjualanLangganan.Panel1.Text = "Panel1"
        Me.SCPenjualanLangganan.Panel2.Text = "Panel2"
        Me.SCPenjualanLangganan.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        Me.SCPenjualanLangganan.Size = New System.Drawing.Size(984, 346)
        Me.SCPenjualanLangganan.SplitterPosition = 297
        Me.SCPenjualanLangganan.TabIndex = 167
        Me.SCPenjualanLangganan.Text = "SplitContainerControl2"
        '
        'TBSistemAR
        '
        Me.TBSistemAR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBSistemAR.Location = New System.Drawing.Point(2, 25)
        Me.TBSistemAR.MainView = Me.GVPenjualanLanggananPerwakilan
        Me.TBSistemAR.Name = "TBSistemAR"
        Me.TBSistemAR.Size = New System.Drawing.Size(977, 318)
        Me.TBSistemAR.TabIndex = 165
        Me.TBSistemAR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPenjualanLanggananPerwakilan})
        '
        'GVPenjualanLanggananPerwakilan
        '
        Me.GVPenjualanLanggananPerwakilan.GridControl = Me.TBSistemAR
        Me.GVPenjualanLanggananPerwakilan.Name = "GVPenjualanLanggananPerwakilan"
        Me.GVPenjualanLanggananPerwakilan.OptionsCustomization.AllowColumnMoving = False
        Me.GVPenjualanLanggananPerwakilan.OptionsCustomization.AllowFilter = False
        Me.GVPenjualanLanggananPerwakilan.OptionsCustomization.AllowGroup = False
        Me.GVPenjualanLanggananPerwakilan.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVPenjualanLanggananPerwakilan.OptionsMenu.EnableColumnMenu = False
        Me.GVPenjualanLanggananPerwakilan.OptionsNavigation.AutoFocusNewRow = True
        Me.GVPenjualanLanggananPerwakilan.OptionsNavigation.EnterMoveNextColumn = True
        Me.GVPenjualanLanggananPerwakilan.OptionsView.ShowFooter = True
        Me.GVPenjualanLanggananPerwakilan.OptionsView.ShowGroupPanel = False
        '
        'Sistem
        '
        Me.Sistem.Controls.Add(Me.TBSistem)
        Me.Sistem.Controls.Add(Me.CekSistem)
        Me.Sistem.Name = "Sistem"
        Me.Sistem.Size = New System.Drawing.Size(983, 371)
        Me.Sistem.Text = "Sistem"
        '
        'TBSistem
        '
        Me.TBSistem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBSistem.Location = New System.Drawing.Point(2, 31)
        Me.TBSistem.MainView = Me.GVSistem
        Me.TBSistem.Name = "TBSistem"
        Me.TBSistem.Size = New System.Drawing.Size(982, 338)
        Me.TBSistem.TabIndex = 176
        Me.TBSistem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSistem})
        '
        'GVSistem
        '
        Me.GVSistem.GridControl = Me.TBSistem
        Me.GVSistem.Name = "GVSistem"
        Me.GVSistem.OptionsCustomization.AllowColumnMoving = False
        Me.GVSistem.OptionsCustomization.AllowFilter = False
        Me.GVSistem.OptionsCustomization.AllowGroup = False
        Me.GVSistem.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSistem.OptionsMenu.EnableColumnMenu = False
        Me.GVSistem.OptionsNavigation.AutoFocusNewRow = True
        Me.GVSistem.OptionsNavigation.EnterMoveNextColumn = True
        Me.GVSistem.OptionsView.ShowFooter = True
        Me.GVSistem.OptionsView.ShowGroupPanel = False
        '
        'CekSistem
        '
        Me.CekSistem.AutoSizeInLayoutControl = True
        Me.CekSistem.Location = New System.Drawing.Point(5, 6)
        Me.CekSistem.Name = "CekSistem"
        Me.CekSistem.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CekSistem.Properties.Appearance.Options.UseFont = True
        Me.CekSistem.Properties.Caption = "Sistem"
        Me.CekSistem.Properties.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.CekSistem.Size = New System.Drawing.Size(157, 19)
        Me.CekSistem.TabIndex = 175
        '
        'BarManagerMain
        '
        Me.BarManagerMain.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl1)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl2)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl3)
        Me.BarManagerMain.DockControls.Add(Me.BarDockControl4)
        Me.BarManagerMain.Form = Me
        Me.BarManagerMain.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button2, Me._Toolbar1_Button3, Me._Toolbar1_Button5, Me.LblTitle})
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
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me._Toolbar1_Button5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.LblTitle)})
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
        '_Toolbar1_Button5
        '
        Me._Toolbar1_Button5.Caption = "F7 - Hapus"
        Me._Toolbar1_Button5.Id = 4
        Me._Toolbar1_Button5.ImageOptions.Image = CType(resources.GetObject("_Toolbar1_Button5.ImageOptions.Image"), System.Drawing.Image)
        Me._Toolbar1_Button5.ImageOptions.LargeImage = CType(resources.GetObject("_Toolbar1_Button5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me._Toolbar1_Button5.Name = "_Toolbar1_Button5"
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
        Me.BarDockControl1.Size = New System.Drawing.Size(996, 24)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 483)
        Me.BarDockControl2.Manager = Me.BarManagerMain
        Me.BarDockControl2.Size = New System.Drawing.Size(996, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 24)
        Me.BarDockControl3.Manager = Me.BarManagerMain
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 459)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(996, 24)
        Me.BarDockControl4.Manager = Me.BarManagerMain
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 459)
        '
        'CheckEdit1
        '
        Me.CheckEdit1.AutoSizeInLayoutControl = True
        Me.CheckEdit1.Location = New System.Drawing.Point(20, 3)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEdit1.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit1.Properties.Caption = "Pilih Semua"
        Me.CheckEdit1.Properties.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.CheckEdit1.Size = New System.Drawing.Size(181, 19)
        Me.CheckEdit1.TabIndex = 175
        '
        'FrmGroupUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(996, 483)
        Me.Controls.Add(Me.TabCntrl)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Name = "FrmGroupUser"
        Me.Text = "Group User"
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabCntrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCntrl.ResumeLayout(False)
        Me.SistemAR.ResumeLayout(False)
        CType(Me.CekSistemAR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCPenjualanLangganan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCPenjualanLangganan.ResumeLayout(False)
        CType(Me.TBSistemAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPenjualanLanggananPerwakilan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sistem.ResumeLayout(False)
        CType(Me.TBSistem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSistem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CekSistem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNama As DevExpress.XtraEditors.TextEdit
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtKode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabCntrl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents SistemAR As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Sistem As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BarManagerMain As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents _Toolbar1_Button1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _Toolbar1_Button5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LblTitle As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SCPenjualanLangganan As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TBSistemAR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPenjualanLanggananPerwakilan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CekSistemAR As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TBSistem As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSistem As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CekSistem As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
