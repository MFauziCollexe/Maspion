<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.TxtID = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.Label3 = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.TglPeriode = New System.Windows.Forms.DateTimePicker()
        Me.BtnMasuk = New DevExpress.XtraEditors.SimpleButton()
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPassword = New DevExpress.XtraEditors.ButtonEdit()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.TxtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtID
        '
        Me.TxtID.EditValue = ""
        Me.TxtID.Location = New System.Drawing.Point(103, 12)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtID.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.TxtID.Properties.Appearance.Options.UseFont = True
        Me.TxtID.Properties.Appearance.Options.UseForeColor = True
        Me.TxtID.Size = New System.Drawing.Size(162, 22)
        Me.TxtID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Appearance.Options.UseBackColor = True
        Me.Label1.Appearance.Options.UseFont = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Location = New System.Drawing.Point(23, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "User ID"
        '
        'Label2
        '
        Me.Label2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Appearance.Options.UseBackColor = True
        Me.Label2.Appearance.Options.UseFont = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Location = New System.Drawing.Point(23, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Appearance.Options.UseBackColor = True
        Me.Label3.Appearance.Options.UseFont = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Location = New System.Drawing.Point(23, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Periode"
        '
        'Label4
        '
        Me.Label4.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Appearance.Options.UseBackColor = True
        Me.Label4.Appearance.Options.UseFont = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Location = New System.Drawing.Point(23, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Username"
        '
        'TxtUsername
        '
        Me.TxtUsername.EditValue = ""
        Me.TxtUsername.Location = New System.Drawing.Point(103, 37)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsername.Properties.Appearance.Options.UseFont = True
        Me.TxtUsername.Size = New System.Drawing.Size(162, 22)
        Me.TxtUsername.TabIndex = 1
        '
        'TglPeriode
        '
        Me.TglPeriode.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglPeriode.CustomFormat = "MMMM yyyy"
        Me.TglPeriode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglPeriode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglPeriode.Location = New System.Drawing.Point(103, 87)
        Me.TglPeriode.Name = "TglPeriode"
        Me.TglPeriode.ShowUpDown = True
        Me.TglPeriode.Size = New System.Drawing.Size(162, 22)
        Me.TglPeriode.TabIndex = 3
        '
        'BtnMasuk
        '
        Me.BtnMasuk.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMasuk.Appearance.Options.UseFont = True
        Me.BtnMasuk.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnMasuk.Location = New System.Drawing.Point(101, 118)
        Me.BtnMasuk.Name = "BtnMasuk"
        Me.BtnMasuk.Size = New System.Drawing.Size(79, 30)
        Me.BtnMasuk.TabIndex = 4
        Me.BtnMasuk.Text = "Masuk"
        '
        'Button1
        '
        Me.Button1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Appearance.Options.UseFont = True
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(186, 118)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 30)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Batal"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(16, 127)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel1.TabIndex = 61
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Pindah Server"
        '
        'LblVersion
        '
        Me.LblVersion.Location = New System.Drawing.Point(3, 151)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(31, 13)
        Me.LblVersion.TabIndex = 62
        Me.LblVersion.Text = "Label5"
        '
        'TxtPassword
        '
        Me.TxtPassword.EditValue = ""
        Me.TxtPassword.Location = New System.Drawing.Point(103, 62)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Properties.Appearance.Options.UseFont = True
        Me.TxtPassword.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, False, False, EditorButtonImageOptions1)})
        Me.TxtPassword.Properties.UseSystemPasswordChar = True
        Me.TxtPassword.Size = New System.Drawing.Size(162, 22)
        Me.TxtPassword.TabIndex = 2
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "VS2010"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 168)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnMasuk)
        Me.Controls.Add(Me.TglPeriode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtID)
        Me.Controls.Add(Me.TxtPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: USER LOGIN ::"
        CType(Me.TxtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtID As DevExpress.XtraEditors.TextEdit
    Public WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Public WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Public WithEvents Label3 As DevExpress.XtraEditors.LabelControl
    Public WithEvents Label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TglPeriode As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnMasuk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPassword As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
