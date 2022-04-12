<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEditOTP
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditOTP))
        Me.TxtOTP = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnMasuk = New DevExpress.XtraEditors.SimpleButton()
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtKeterangan = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.TxtOTP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtOTP
        '
        Me.TxtOTP.EditValue = ""
        Me.TxtOTP.Location = New System.Drawing.Point(12, 34)
        Me.TxtOTP.Name = "TxtOTP"
        Me.TxtOTP.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOTP.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.TxtOTP.Properties.Appearance.Options.UseFont = True
        Me.TxtOTP.Properties.Appearance.Options.UseForeColor = True
        Me.TxtOTP.Size = New System.Drawing.Size(126, 22)
        Me.TxtOTP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Appearance.Options.UseBackColor = True
        Me.Label1.Appearance.Options.UseFont = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Kode OTP"
        '
        'Label4
        '
        Me.Label4.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Appearance.Options.UseBackColor = True
        Me.Label4.Appearance.Options.UseFont = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Location = New System.Drawing.Point(12, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Alasan Edit"
        '
        'BtnMasuk
        '
        Me.BtnMasuk.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMasuk.Appearance.Options.UseFont = True
        Me.BtnMasuk.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnMasuk.ImageOptions.Image = CType(resources.GetObject("BtnMasuk.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnMasuk.Location = New System.Drawing.Point(266, 165)
        Me.BtnMasuk.Name = "BtnMasuk"
        Me.BtnMasuk.Size = New System.Drawing.Size(79, 30)
        Me.BtnMasuk.TabIndex = 4
        Me.BtnMasuk.Text = "Simpan"
        '
        'Button1
        '
        Me.Button1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Appearance.Options.UseFont = True
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ImageOptions.Image = CType(resources.GetObject("Button1.ImageOptions.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(181, 165)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 30)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Batal"
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.EditValue = ""
        Me.TxtKeterangan.Location = New System.Drawing.Point(12, 84)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKeterangan.Properties.Appearance.Options.UseFont = True
        Me.TxtKeterangan.Size = New System.Drawing.Size(333, 75)
        Me.TxtKeterangan.TabIndex = 1
        '
        'FrmEditOTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 206)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnMasuk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtOTP)
        Me.Controls.Add(Me.TxtKeterangan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditOTP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: TRANSACTION SECURITY ::"
        Me.TopMost = True
        CType(Me.TxtOTP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtOTP As DevExpress.XtraEditors.TextEdit
    Public WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Public WithEvents Label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnMasuk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtKeterangan As DevExpress.XtraEditors.MemoEdit
End Class
