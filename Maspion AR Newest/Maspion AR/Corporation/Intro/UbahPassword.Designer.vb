<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UbahPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UbahPassword))
        Me.keluar = New System.Windows.Forms.ToolStripButton()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.simpan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtVerify = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPassword2 = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNamaUser = New DevExpress.XtraEditors.TextEdit()
        Me.TxtID = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtVerify.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'keluar
        '
        Me.keluar.AutoSize = False
        Me.keluar.Image = CType(resources.GetObject("keluar.Image"), System.Drawing.Image)
        Me.keluar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.keluar.Name = "keluar"
        Me.keluar.Size = New System.Drawing.Size(91, 22)
        Me.keluar.Text = "F4 - Keluar"
        Me.keluar.ToolTipText = "F3 - Batal"
        '
        'Toolbar1
        '
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.simpan, Me.ToolStripButton2, Me.keluar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(474, 25)
        Me.Toolbar1.TabIndex = 13
        '
        'simpan
        '
        Me.simpan.Image = CType(resources.GetObject("simpan.Image"), System.Drawing.Image)
        Me.simpan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.simpan.Name = "simpan"
        Me.simpan.Size = New System.Drawing.Size(87, 22)
        Me.simpan.Text = "F2 -Simpan"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripButton2.Text = "F3 - Batal"
        Me.ToolStripButton2.ToolTipText = "F3 - Batal"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtVerify)
        Me.GroupBox1.Controls.Add(Me.TxtPassword2)
        Me.GroupBox1.Controls.Add(Me.TxtPassword)
        Me.GroupBox1.Controls.Add(Me.TxtNamaUser)
        Me.GroupBox1.Controls.Add(Me.TxtID)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 320)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubah Password"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(268, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(168, 17)
        Me.Label5.TabIndex = 76
        '
        'TxtVerify
        '
        Me.TxtVerify.Location = New System.Drawing.Point(104, 133)
        Me.TxtVerify.Name = "TxtVerify"
        Me.TxtVerify.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtVerify.Size = New System.Drawing.Size(158, 20)
        Me.TxtVerify.TabIndex = 75
        Me.TxtVerify.ToolTipTitle = "Inputkan ID Customer yang ingin di cari"
        '
        'TxtPassword2
        '
        Me.TxtPassword2.Location = New System.Drawing.Point(104, 107)
        Me.TxtPassword2.Name = "TxtPassword2"
        Me.TxtPassword2.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword2.Size = New System.Drawing.Size(158, 20)
        Me.TxtPassword2.TabIndex = 74
        Me.TxtPassword2.ToolTipTitle = "Inputkan ID Customer yang ingin di cari"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(104, 81)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(158, 20)
        Me.TxtPassword.TabIndex = 73
        Me.TxtPassword.ToolTipTitle = "Inputkan ID Customer yang ingin di cari"
        '
        'TxtNamaUser
        '
        Me.TxtNamaUser.Location = New System.Drawing.Point(104, 55)
        Me.TxtNamaUser.Name = "TxtNamaUser"
        Me.TxtNamaUser.Properties.ReadOnly = True
        Me.TxtNamaUser.Size = New System.Drawing.Size(158, 20)
        Me.TxtNamaUser.TabIndex = 72
        Me.TxtNamaUser.ToolTipTitle = "Inputkan ID Customer yang ingin di cari"
        '
        'TxtID
        '
        Me.TxtID.Enabled = False
        Me.TxtID.Location = New System.Drawing.Point(104, 29)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(104, 20)
        Me.TxtID.TabIndex = 71
        Me.TxtID.ToolTipTitle = "Inputkan ID Customer yang ingin di cari"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Verify Password"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Password Baru"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Password Lama"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Nama User"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(64, 20)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "ID User"
        '
        'UbahPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 380)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "UbahPassword"
        Me.Text = "Ubah Password"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TxtVerify.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassword2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents keluar As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents simpan As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtVerify As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPassword2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNamaUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtID As DevExpress.XtraEditors.TextEdit
    Public WithEvents Label5 As System.Windows.Forms.Label
End Class
