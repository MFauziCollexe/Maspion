<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKoneksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKoneksi))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPilihServer = New DevExpress.XtraEditors.TextEdit()
        Me.BtnMasuk = New DevExpress.XtraEditors.SimpleButton()
        Me.RdLocation = New DevExpress.XtraEditors.RadioGroup()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDatabaseName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TxtPilihServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDatabaseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(83, 22)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Nama Server"
        '
        'TxtPilihServer
        '
        Me.TxtPilihServer.EditValue = "Localhost"
        Me.TxtPilihServer.Enabled = False
        Me.TxtPilihServer.Location = New System.Drawing.Point(102, 66)
        Me.TxtPilihServer.Name = "TxtPilihServer"
        Me.TxtPilihServer.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPilihServer.Properties.Appearance.Options.UseFont = True
        Me.TxtPilihServer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.TxtPilihServer.Size = New System.Drawing.Size(155, 22)
        Me.TxtPilihServer.TabIndex = 1
        '
        'BtnMasuk
        '
        Me.BtnMasuk.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMasuk.Appearance.Options.UseFont = True
        Me.BtnMasuk.Location = New System.Drawing.Point(181, 125)
        Me.BtnMasuk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnMasuk.Name = "BtnMasuk"
        Me.BtnMasuk.Size = New System.Drawing.Size(75, 25)
        Me.BtnMasuk.TabIndex = 3
        Me.BtnMasuk.Text = "OK"
        '
        'RdLocation
        '
        Me.RdLocation.Location = New System.Drawing.Point(99, 6)
        Me.RdLocation.Name = "RdLocation"
        Me.RdLocation.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RdLocation.Properties.Appearance.Options.UseBackColor = True
        Me.RdLocation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RdLocation.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Localhost"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Server")})
        Me.RdLocation.Size = New System.Drawing.Size(154, 52)
        Me.RdLocation.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(83, 22)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Pilih Lokasi :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(15, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Database"
        '
        'TxtDatabaseName
        '
        Me.TxtDatabaseName.EditValue = ""
        Me.TxtDatabaseName.Location = New System.Drawing.Point(102, 93)
        Me.TxtDatabaseName.Name = "TxtDatabaseName"
        Me.TxtDatabaseName.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDatabaseName.Properties.Appearance.Options.UseFont = True
        Me.TxtDatabaseName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.TxtDatabaseName.Size = New System.Drawing.Size(155, 22)
        Me.TxtDatabaseName.TabIndex = 2
        '
        'FrmKoneksi
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 162)
        Me.Controls.Add(Me.TxtDatabaseName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RdLocation)
        Me.Controls.Add(Me.BtnMasuk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPilihServer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKoneksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrasi Server"
        CType(Me.TxtPilihServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDatabaseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPilihServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnMasuk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RdLocation As DevExpress.XtraEditors.RadioGroup
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDatabaseName As DevExpress.XtraEditors.TextEdit
End Class
