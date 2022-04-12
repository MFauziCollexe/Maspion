<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPostingPeriode
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
        Me.DtTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnProses = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaGudang = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeGudang = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtIDBarang = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtKodeBarang = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaBarang = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.CustomFormat = "MMMM yyyy"
        Me.DtTanggalAwal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalAwal.Location = New System.Drawing.Point(27, 47)
        Me.DtTanggalAwal.Margin = New System.Windows.Forms.Padding(1)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.ShowUpDown = True
        Me.DtTanggalAwal.Size = New System.Drawing.Size(213, 27)
        Me.DtTanggalAwal.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 19)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Periode Posting :"
        '
        'BtnProses
        '
        Me.BtnProses.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Appearance.Options.UseFont = True
        Me.BtnProses.Location = New System.Drawing.Point(27, 224)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(213, 31)
        Me.BtnProses.TabIndex = 111
        Me.BtnProses.Text = "Proses"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 76)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 265
        Me.Label5.Text = "Gudang"
        '
        'TxtNamaGudang
        '
        Me.TxtNamaGudang.Enabled = False
        Me.TxtNamaGudang.EnterMoveNextControl = True
        Me.TxtNamaGudang.Location = New System.Drawing.Point(133, 73)
        Me.TxtNamaGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaGudang.Name = "TxtNamaGudang"
        Me.TxtNamaGudang.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.TxtNamaGudang.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtNamaGudang.Properties.ReadOnly = True
        Me.TxtNamaGudang.Size = New System.Drawing.Size(179, 20)
        Me.TxtNamaGudang.TabIndex = 264
        '
        'TxtKodeGudang
        '
        Me.TxtKodeGudang.Location = New System.Drawing.Point(69, 73)
        Me.TxtKodeGudang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeGudang.Name = "TxtKodeGudang"
        Me.TxtKodeGudang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeGudang.Properties.ReadOnly = True
        Me.TxtKodeGudang.Size = New System.Drawing.Size(62, 20)
        Me.TxtKodeGudang.TabIndex = 263
        '
        'TxtIDBarang
        '
        Me.TxtIDBarang.EnterMoveNextControl = True
        Me.TxtIDBarang.Location = New System.Drawing.Point(314, 51)
        Me.TxtIDBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDBarang.Name = "TxtIDBarang"
        Me.TxtIDBarang.Properties.ReadOnly = True
        Me.TxtIDBarang.Size = New System.Drawing.Size(16, 20)
        Me.TxtIDBarang.TabIndex = 262
        Me.TxtIDBarang.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Barang"
        '
        'TxtKodeBarang
        '
        Me.TxtKodeBarang.Location = New System.Drawing.Point(69, 51)
        Me.TxtKodeBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeBarang.Name = "TxtKodeBarang"
        Me.TxtKodeBarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeBarang.Size = New System.Drawing.Size(62, 20)
        Me.TxtKodeBarang.TabIndex = 259
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.EnterMoveNextControl = True
        Me.TxtNamaBarang.Location = New System.Drawing.Point(133, 51)
        Me.TxtNamaBarang.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Properties.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(179, 20)
        Me.TxtNamaBarang.TabIndex = 260
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Divisi  "
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(69, 29)
        Me.TxtDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDivisi.Size = New System.Drawing.Size(62, 20)
        Me.TxtDivisi.TabIndex = 256
        '
        'TxtNamaDivisi
        '
        Me.TxtNamaDivisi.EnterMoveNextControl = True
        Me.TxtNamaDivisi.Location = New System.Drawing.Point(133, 29)
        Me.TxtNamaDivisi.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaDivisi.Name = "TxtNamaDivisi"
        Me.TxtNamaDivisi.Properties.ReadOnly = True
        Me.TxtNamaDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtNamaDivisi.TabIndex = 257
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.TxtNamaDivisi)
        Me.GroupControl1.Controls.Add(Me.TxtNamaGudang)
        Me.GroupControl1.Controls.Add(Me.TxtDivisi)
        Me.GroupControl1.Controls.Add(Me.TxtKodeGudang)
        Me.GroupControl1.Controls.Add(Me.TxtNamaBarang)
        Me.GroupControl1.Controls.Add(Me.TxtIDBarang)
        Me.GroupControl1.Controls.Add(Me.TxtKodeBarang)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Enabled = False
        Me.GroupControl1.Location = New System.Drawing.Point(27, 110)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(343, 108)
        Me.GroupControl1.TabIndex = 266
        Me.GroupControl1.Text = "Proses Tertentu"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(27, 78)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Proses Semua"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Proses Tertentu")})
        Me.RadioGroup1.Size = New System.Drawing.Size(343, 26)
        Me.RadioGroup1.TabIndex = 267
        '
        'FrmPostingPeriode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 290)
        Me.Controls.Add(Me.RadioGroup1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtTanggalAwal)
        Me.Name = "FrmPostingPeriode"
        Me.Text = "Posting Periode"
        CType(Me.TxtNamaGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeGudang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnProses As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaGudang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeGudang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtIDBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeBarang As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNamaDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class
