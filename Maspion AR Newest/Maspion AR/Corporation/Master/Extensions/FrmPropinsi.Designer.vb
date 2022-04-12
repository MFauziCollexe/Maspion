<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProvinsi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProvinsi))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtKode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupInput = New DevExpress.XtraEditors.GroupControl()
        Me.BtnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.TBPropinsi = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TBDetailMenuPropinsi = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.TBMenuPropinsi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTambah = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupInput.SuspendLayout()
        CType(Me.TBPropinsi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDetailMenuPropinsi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBMenuPropinsi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
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
        'TxtKode
        '
        Me.TxtKode.Enabled = False
        Me.TxtKode.Location = New System.Drawing.Point(107, 23)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Properties.ReadOnly = True
        Me.TxtKode.Size = New System.Drawing.Size(100, 20)
        Me.TxtKode.TabIndex = 13
        Me.TxtKode.TabStop = False
        '
        'TxtNama
        '
        Me.TxtNama.EnterMoveNextControl = True
        Me.TxtNama.Location = New System.Drawing.Point(107, 46)
        Me.TxtNama.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(195, 20)
        Me.TxtNama.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 26)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl1.TabIndex = 98
        Me.LabelControl1.Text = "ID Propinsi"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(5, 49)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl2.TabIndex = 98
        Me.LabelControl2.Text = "Nama Propinsi"
        '
        'GroupInput
        '
        Me.GroupInput.Controls.Add(Me.BtnBatal)
        Me.GroupInput.Controls.Add(Me.BtnTutup)
        Me.GroupInput.Controls.Add(Me.BtnSimpan)
        Me.GroupInput.Controls.Add(Me.LabelControl1)
        Me.GroupInput.Controls.Add(Me.TxtKode)
        Me.GroupInput.Controls.Add(Me.TxtNama)
        Me.GroupInput.Controls.Add(Me.LabelControl2)
        Me.GroupInput.Controls.Add(Me.TBPropinsi)
        Me.GroupInput.Location = New System.Drawing.Point(331, 52)
        Me.GroupInput.Name = "GroupInput"
        Me.GroupInput.Size = New System.Drawing.Size(307, 393)
        Me.GroupInput.TabIndex = 100
        Me.GroupInput.Text = "Input Propinsi"
        Me.GroupInput.Visible = False
        '
        'BtnBatal
        '
        Me.BtnBatal.Image = CType(resources.GetObject("BtnBatal.Image"), System.Drawing.Image)
        Me.BtnBatal.Location = New System.Drawing.Point(168, 368)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(64, 20)
        Me.BtnBatal.TabIndex = 105
        Me.BtnBatal.Text = "Batal"
        '
        'BtnTutup
        '
        Me.BtnTutup.Image = CType(resources.GetObject("BtnTutup.Image"), System.Drawing.Image)
        Me.BtnTutup.Location = New System.Drawing.Point(98, 368)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(64, 20)
        Me.BtnTutup.TabIndex = 104
        Me.BtnTutup.Text = "Tutup"
        '
        'BtnSimpan
        '
        Me.BtnSimpan.BackgroundImage = Global.Maspion.PrintRibbonControllerResources.RibbonPrintPreview_ZoomIn
        Me.BtnSimpan.Image = CType(resources.GetObject("BtnSimpan.Image"), System.Drawing.Image)
        Me.BtnSimpan.Location = New System.Drawing.Point(238, 368)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(64, 20)
        Me.BtnSimpan.TabIndex = 103
        Me.BtnSimpan.Text = "Simpan"
        '
        'TBPropinsi
        '
        Me.TBPropinsi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TBPropinsi.Location = New System.Drawing.Point(5, 68)
        Me.TBPropinsi.MainView = Me.GridView3
        Me.TBPropinsi.Margin = New System.Windows.Forms.Padding(1)
        Me.TBPropinsi.Name = "TBPropinsi"
        Me.TBPropinsi.Size = New System.Drawing.Size(297, 296)
        Me.TBPropinsi.TabIndex = 102
        Me.TBPropinsi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.TBPropinsi
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView3.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'TBDetailMenuPropinsi
        '
        Me.TBDetailMenuPropinsi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBDetailMenuPropinsi.Location = New System.Drawing.Point(0, 0)
        Me.TBDetailMenuPropinsi.MainView = Me.GridView2
        Me.TBDetailMenuPropinsi.Margin = New System.Windows.Forms.Padding(1)
        Me.TBDetailMenuPropinsi.Name = "TBDetailMenuPropinsi"
        Me.TBDetailMenuPropinsi.Size = New System.Drawing.Size(307, 228)
        Me.TBDetailMenuPropinsi.TabIndex = 12
        Me.TBDetailMenuPropinsi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.TBDetailMenuPropinsi
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView2.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl13.Location = New System.Drawing.Point(553, 357)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl13.TabIndex = 98
        Me.LabelControl13.Text = "*"
        '
        'TBMenuPropinsi
        '
        Me.TBMenuPropinsi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBMenuPropinsi.Location = New System.Drawing.Point(0, 0)
        Me.TBMenuPropinsi.MainView = Me.GridView1
        Me.TBMenuPropinsi.Margin = New System.Windows.Forms.Padding(1)
        Me.TBMenuPropinsi.Name = "TBMenuPropinsi"
        Me.TBMenuPropinsi.Size = New System.Drawing.Size(307, 176)
        Me.TBMenuPropinsi.TabIndex = 101
        Me.TBMenuPropinsi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TBMenuPropinsi
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.SplitContainerControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(313, 443)
        Me.GroupControl2.TabIndex = 103
        Me.GroupControl2.Text = "Daftar Propinsi ::"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 22)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TBMenuPropinsi)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TBDetailMenuPropinsi)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.ScrollBarSmallChange = 3
        Me.SplitContainerControl1.Size = New System.Drawing.Size(307, 416)
        Me.SplitContainerControl1.SplitterPosition = 176
        Me.SplitContainerControl1.TabIndex = 100
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'BtnEdit
        '
        Me.BtnEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.Appearance.Options.UseFont = True
        Me.BtnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(434, 12)
        Me.BtnEdit.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(101, 34)
        Me.BtnEdit.TabIndex = 143
        Me.BtnEdit.Text = "Edit"
        '
        'BtnTambah
        '
        Me.BtnTambah.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTambah.Appearance.Options.UseFont = True
        Me.BtnTambah.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnTambah.Image = CType(resources.GetObject("BtnTambah.Image"), System.Drawing.Image)
        Me.BtnTambah.Location = New System.Drawing.Point(331, 12)
        Me.BtnTambah.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnTambah.Name = "BtnTambah"
        Me.BtnTambah.Size = New System.Drawing.Size(101, 34)
        Me.BtnTambah.TabIndex = 141
        Me.BtnTambah.Text = "Tambah"
        '
        'BtnHapus
        '
        Me.BtnHapus.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapus.Appearance.Options.UseFont = True
        Me.BtnHapus.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnHapus.Image = CType(resources.GetObject("BtnHapus.Image"), System.Drawing.Image)
        Me.BtnHapus.Location = New System.Drawing.Point(537, 12)
        Me.BtnHapus.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(101, 34)
        Me.BtnHapus.TabIndex = 142
        Me.BtnHapus.Text = "Hapus"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        '
        'FrmProvinsi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 450)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnTambah)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupInput)
        Me.Controls.Add(Me.LabelControl13)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProvinsi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propinsi"
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupInput.ResumeLayout(False)
        Me.GroupInput.PerformLayout()
        CType(Me.TBPropinsi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDetailMenuPropinsi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBMenuPropinsi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TxtKode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupInput As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TBDetailMenuPropinsi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TBMenuPropinsi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TBPropinsi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnTambah As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
End Class
