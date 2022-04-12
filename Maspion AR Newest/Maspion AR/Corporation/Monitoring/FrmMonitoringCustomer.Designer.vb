<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonitoringCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonitoringCustomer))
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCari = New DevExpress.XtraEditors.TextEdit()
        Me._Toolbar1_Button1 = New System.Windows.Forms.ToolStripButton()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me._Toolbar1_Button9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CUSTOMERBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.GBstatus = New System.Windows.Forms.GroupBox()
        Me.txtKodeApprove = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKode = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Nama = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.RDstatus = New DevExpress.XtraEditors.RadioGroup()
        Me.TxtKeterangan = New DevExpress.XtraEditors.MemoEdit()
        Me.TBMonitoringSPK = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txt = New DevExpress.XtraEditors.TextEdit()
        Me.Frame2.SuspendLayout()
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        CType(Me.CUSTOMERBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.GBstatus.SuspendLayout()
        CType(Me.txtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBMonitoringSPK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame2.BackColor = System.Drawing.Color.Transparent
        Me.Frame2.Controls.Add(Me.Label8)
        Me.Frame2.Controls.Add(Me.txtCari)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(5, 31)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(826, 54)
        Me.Frame2.TabIndex = 20
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Pencarian Berdasarkan :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(23, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Kata Kun&ci : "
        '
        'txtCari
        '
        Me.txtCari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCari.Location = New System.Drawing.Point(99, 26)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(682, 20)
        Me.txtCari.TabIndex = 0
        Me.txtCari.ToolTipTitle = "Inputkan yang ingin di cari"
        '
        '_Toolbar1_Button1
        '
        Me._Toolbar1_Button1.AutoSize = False
        Me._Toolbar1_Button1.Image = CType(resources.GetObject("_Toolbar1_Button1.Image"), System.Drawing.Image)
        Me._Toolbar1_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button1.Name = "_Toolbar1_Button1"
        Me._Toolbar1_Button1.Size = New System.Drawing.Size(90, 22)
        Me._Toolbar1_Button1.Text = "F2 - &Proses"
        Me._Toolbar1_Button1.ToolTipText = "F2 - Proses"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageList = Me.ImageList2
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button9})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(833, 25)
        Me.Toolbar1.TabIndex = 3
        '
        '_Toolbar1_Button9
        '
        Me._Toolbar1_Button9.AutoSize = False
        Me._Toolbar1_Button9.ImageIndex = 7
        Me._Toolbar1_Button9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button9.Name = "_Toolbar1_Button9"
        Me._Toolbar1_Button9.Size = New System.Drawing.Size(90, 22)
        Me._Toolbar1_Button9.Text = "F3 - &Keluar"
        Me._Toolbar1_Button9.ToolTipText = "F5 - Keluar"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        '
        'Frame1
        '
        Me.Frame1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame1.BackColor = System.Drawing.Color.Transparent
        Me.Frame1.Controls.Add(Me.GBstatus)
        Me.Frame1.Controls.Add(Me.TBMonitoringSPK)
        Me.Frame1.Controls.Add(Me.txt)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(4, 91)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(829, 336)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Data SPK : "
        '
        'GBstatus
        '
        Me.GBstatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GBstatus.BackColor = System.Drawing.Color.Transparent
        Me.GBstatus.Controls.Add(Me.txtKodeApprove)
        Me.GBstatus.Controls.Add(Me.Label2)
        Me.GBstatus.Controls.Add(Me.TxtKode)
        Me.GBstatus.Controls.Add(Me.Label6)
        Me.GBstatus.Controls.Add(Me.Nama)
        Me.GBstatus.Controls.Add(Me.Label1)
        Me.GBstatus.Controls.Add(Me.Button2)
        Me.GBstatus.Controls.Add(Me.Button1)
        Me.GBstatus.Controls.Add(Me.BtnClose)
        Me.GBstatus.Controls.Add(Me.RDstatus)
        Me.GBstatus.Controls.Add(Me.TxtKeterangan)
        Me.GBstatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBstatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GBstatus.Location = New System.Drawing.Point(201, 68)
        Me.GBstatus.Name = "GBstatus"
        Me.GBstatus.Padding = New System.Windows.Forms.Padding(0)
        Me.GBstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GBstatus.Size = New System.Drawing.Size(429, 211)
        Me.GBstatus.TabIndex = 21
        Me.GBstatus.TabStop = False
        Me.GBstatus.Visible = False
        '
        'txtKodeApprove
        '
        Me.txtKodeApprove.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKodeApprove.Enabled = False
        Me.txtKodeApprove.EnterMoveNextControl = True
        Me.txtKodeApprove.Location = New System.Drawing.Point(114, 35)
        Me.txtKodeApprove.Margin = New System.Windows.Forms.Padding(1)
        Me.txtKodeApprove.Name = "txtKodeApprove"
        Me.txtKodeApprove.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtKodeApprove.Properties.Appearance.Options.UseBackColor = True
        Me.txtKodeApprove.Properties.MaxLength = 8
        Me.txtKodeApprove.Size = New System.Drawing.Size(80, 20)
        Me.txtKodeApprove.TabIndex = 242
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(9, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(102, 14)
        Me.Label2.TabIndex = 241
        Me.Label2.Text = "Kode Customer "
        '
        'TxtKode
        '
        Me.TxtKode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtKode.Enabled = False
        Me.TxtKode.EnterMoveNextControl = True
        Me.TxtKode.Location = New System.Drawing.Point(114, 12)
        Me.TxtKode.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.TxtKode.Properties.Appearance.Options.UseBackColor = True
        Me.TxtKode.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtKode.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtKode.Size = New System.Drawing.Size(80, 20)
        Me.TxtKode.TabIndex = 240
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(4, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Keterangan :"
        '
        'Nama
        '
        Me.Nama.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nama.Enabled = False
        Me.Nama.Location = New System.Drawing.Point(196, 12)
        Me.Nama.Name = "Nama"
        Me.Nama.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Nama.Properties.Appearance.Options.UseBackColor = True
        Me.Nama.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Nama.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Nama.Properties.ReadOnly = True
        Me.Nama.Size = New System.Drawing.Size(199, 20)
        Me.Nama.TabIndex = 67
        Me.Nama.ToolTipTitle = "Inputkan yang ingin di cari"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(102, 14)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "ID / Nama Customer "
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(228, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "F9 - Tutup"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(94, 177)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "F8 - Simpan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(405, 8)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(22, 19)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "X"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'RDstatus
        '
        Me.RDstatus.Location = New System.Drawing.Point(6, 60)
        Me.RDstatus.Name = "RDstatus"
        Me.RDstatus.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "    -", False), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Di Setujui"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Di Tolak")})
        Me.RDstatus.Size = New System.Drawing.Size(416, 31)
        Me.RDstatus.TabIndex = 0
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.Location = New System.Drawing.Point(6, 112)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Size = New System.Drawing.Size(416, 57)
        Me.TxtKeterangan.TabIndex = 243
        '
        'TBMonitoringSPK
        '
        Me.TBMonitoringSPK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBMonitoringSPK.Location = New System.Drawing.Point(6, 16)
        Me.TBMonitoringSPK.MainView = Me.GridView1
        Me.TBMonitoringSPK.Name = "TBMonitoringSPK"
        Me.TBMonitoringSPK.Size = New System.Drawing.Size(819, 317)
        Me.TBMonitoringSPK.TabIndex = 1
        Me.TBMonitoringSPK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TBMonitoringSPK
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(756, 16)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(26, 20)
        Me.txt.TabIndex = 2
        '
        'FrmMonitoringCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 430)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Frame1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMonitoringCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitoring Customer"
        Me.Frame2.ResumeLayout(False)
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.CUSTOMERBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.GBstatus.ResumeLayout(False)
        CType(Me.txtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBMonitoringSPK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents _Toolbar1_Button1 As System.Windows.Forms.ToolStripButton
    Public WithEvents ImageList2 As System.Windows.Forms.ImageList
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents _Toolbar1_Button9 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents CUSTOMERBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBMonitoringSPK As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txt As DevExpress.XtraEditors.TextEdit
    Public WithEvents GBstatus As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Nama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RDstatus As DevExpress.XtraEditors.RadioGroup
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtKode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKodeApprove As DevExpress.XtraEditors.TextEdit
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtKeterangan As DevExpress.XtraEditors.MemoEdit
End Class
