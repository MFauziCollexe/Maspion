<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKodePerkiraan
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKodePerkiraan))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me._Toolbar1_Button1 = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button2 = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripButton()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CekStatusAktif = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.RdJenis = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtUrutan = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNamaParent = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeParent = New DevExpress.XtraEditors.ButtonEdit()
        Me.ChkKasBank = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSaldo = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.CmbGroup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Toolbar1.SuspendLayout()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CekStatusAktif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RdJenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUrutan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaParent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeParent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkKasBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Toolbar1
        '
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Toolbar1_Button1, Me._Toolbar1_Button2, Me._Toolbar1_Button3, Me.ToolStripSeparator1, Me._Toolbar1_Button4})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(456, 25)
        Me.Toolbar1.TabIndex = 5
        '
        '_Toolbar1_Button1
        '
        Me._Toolbar1_Button1.AutoSize = False
        Me._Toolbar1_Button1.ImageIndex = 0
        Me._Toolbar1_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button1.Name = "_Toolbar1_Button1"
        Me._Toolbar1_Button1.Size = New System.Drawing.Size(90, 22)
        Me._Toolbar1_Button1.Text = "F2 - Simpan"
        Me._Toolbar1_Button1.ToolTipText = "F2 - Simpan"
        '
        '_Toolbar1_Button2
        '
        Me._Toolbar1_Button2.AutoSize = False
        Me._Toolbar1_Button2.ImageIndex = 1
        Me._Toolbar1_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button2.Name = "_Toolbar1_Button2"
        Me._Toolbar1_Button2.Size = New System.Drawing.Size(84, 22)
        Me._Toolbar1_Button2.Text = "F3 - Bersih"
        Me._Toolbar1_Button2.ToolTipText = "F3 - Batal"
        '
        '_Toolbar1_Button3
        '
        Me._Toolbar1_Button3.AutoSize = False
        Me._Toolbar1_Button3.ImageIndex = 2
        Me._Toolbar1_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button3.Name = "_Toolbar1_Button3"
        Me._Toolbar1_Button3.Size = New System.Drawing.Size(84, 22)
        Me._Toolbar1_Button3.Text = "F4 - Keluar"
        Me._Toolbar1_Button3.ToolTipText = "F4 - Keluar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.Image = CType(resources.GetObject("_Toolbar1_Button4.Image"), System.Drawing.Image)
        Me._Toolbar1_Button4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        Me._Toolbar1_Button4.Size = New System.Drawing.Size(84, 22)
        Me._Toolbar1_Button4.Text = "F5 - Hapus"
        '
        'TxtNama
        '
        Me.TxtNama.EnterMoveNextControl = True
        Me.TxtNama.Location = New System.Drawing.Point(128, 85)
        Me.TxtNama.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(291, 20)
        Me.TxtNama.TabIndex = 1
        '
        'TxtKode
        '
        Me.TxtKode.EnterMoveNextControl = True
        Me.TxtKode.Location = New System.Drawing.Point(128, 63)
        Me.TxtKode.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Size = New System.Drawing.Size(204, 20)
        Me.TxtKode.TabIndex = 0
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl13.Appearance.Options.UseForeColor = True
        Me.LabelControl13.Location = New System.Drawing.Point(423, 88)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl13.TabIndex = 109
        Me.LabelControl13.Text = "*"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(336, 66)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl1.TabIndex = 110
        Me.LabelControl1.Text = "*"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 66)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl3.TabIndex = 111
        Me.LabelControl3.Text = "Kode Perkiraan"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(22, 88)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl4.TabIndex = 111
        Me.LabelControl4.Text = "Nama Perkiraan"
        '
        'CekStatusAktif
        '
        Me.CekStatusAktif.AutoSizeInLayoutControl = True
        Me.CekStatusAktif.Location = New System.Drawing.Point(242, 41)
        Me.CekStatusAktif.Margin = New System.Windows.Forms.Padding(1)
        Me.CekStatusAktif.Name = "CekStatusAktif"
        Me.CekStatusAktif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CekStatusAktif.Properties.Appearance.Options.UseFont = True
        Me.CekStatusAktif.Properties.Caption = "Status Aktif"
        Me.CekStatusAktif.Size = New System.Drawing.Size(90, 19)
        Me.CekStatusAktif.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl2.TabIndex = 113
        Me.LabelControl2.Text = "Group Perkiraan"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(22, 145)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl7.TabIndex = 115
        Me.LabelControl7.Text = "Urutan Level"
        '
        'RdJenis
        '
        Me.RdJenis.Location = New System.Drawing.Point(128, 109)
        Me.RdJenis.Name = "RdJenis"
        Me.RdJenis.Properties.Columns = 3
        Me.RdJenis.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Main", "Main Header"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Header", "Header"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail", "Detail")})
        Me.RdJenis.Size = New System.Drawing.Size(291, 29)
        Me.RdJenis.TabIndex = 116
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(22, 117)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl8.TabIndex = 117
        Me.LabelControl8.Text = "Jenis Akun"
        '
        'TxtUrutan
        '
        Me.TxtUrutan.Location = New System.Drawing.Point(128, 142)
        Me.TxtUrutan.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtUrutan.Name = "TxtUrutan"
        Me.TxtUrutan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtUrutan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtUrutan.Size = New System.Drawing.Size(100, 20)
        Me.TxtUrutan.TabIndex = 114
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(22, 167)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 120
        Me.LabelControl9.Text = "Parent"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Location = New System.Drawing.Point(425, 117)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl10.TabIndex = 119
        Me.LabelControl10.Text = "*"
        '
        'TxtNamaParent
        '
        Me.TxtNamaParent.EnterMoveNextControl = True
        Me.TxtNamaParent.Location = New System.Drawing.Point(232, 164)
        Me.TxtNamaParent.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtNamaParent.Name = "TxtNamaParent"
        Me.TxtNamaParent.Properties.MaxLength = 3
        Me.TxtNamaParent.Properties.ReadOnly = True
        Me.TxtNamaParent.Size = New System.Drawing.Size(187, 20)
        Me.TxtNamaParent.TabIndex = 121
        '
        'TxtKodeParent
        '
        Me.TxtKodeParent.Location = New System.Drawing.Point(128, 164)
        Me.TxtKodeParent.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtKodeParent.Name = "TxtKodeParent"
        Me.TxtKodeParent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeParent.Properties.MaxLength = 3
        Me.TxtKodeParent.Properties.ReadOnly = True
        Me.TxtKodeParent.Size = New System.Drawing.Size(100, 20)
        Me.TxtKodeParent.TabIndex = 118
        '
        'ChkKasBank
        '
        Me.ChkKasBank.AutoSizeInLayoutControl = True
        Me.ChkKasBank.Location = New System.Drawing.Point(128, 208)
        Me.ChkKasBank.Margin = New System.Windows.Forms.Padding(1)
        Me.ChkKasBank.Name = "ChkKasBank"
        Me.ChkKasBank.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkKasBank.Properties.Appearance.Options.UseFont = True
        Me.ChkKasBank.Properties.Caption = "Akun Kas / Bank"
        Me.ChkKasBank.Size = New System.Drawing.Size(134, 19)
        Me.ChkKasBank.TabIndex = 122
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(22, 189)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl11.TabIndex = 124
        Me.LabelControl11.Text = "Saldo Awal"
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Location = New System.Drawing.Point(128, 186)
        Me.TxtSaldo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.TxtSaldo.TabIndex = 123
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(232, 189)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl5.TabIndex = 126
        Me.LabelControl5.Text = "Pada Periode"
        '
        'TxtPeriode
        '
        Me.TxtPeriode.EditValue = Nothing
        Me.TxtPeriode.Location = New System.Drawing.Point(299, 186)
        Me.TxtPeriode.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPeriode.Name = "TxtPeriode"
        Me.TxtPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtPeriode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtPeriode.Properties.DisplayFormat.FormatString = ""
        Me.TxtPeriode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtPeriode.Properties.EditFormat.FormatString = ""
        Me.TxtPeriode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtPeriode.Properties.Mask.EditMask = ""
        Me.TxtPeriode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtPeriode.Size = New System.Drawing.Size(120, 20)
        Me.TxtPeriode.TabIndex = 125
        '
        'CmbGroup
        '
        Me.CmbGroup.Location = New System.Drawing.Point(128, 41)
        Me.CmbGroup.Margin = New System.Windows.Forms.Padding(1)
        Me.CmbGroup.Name = "CmbGroup"
        Me.CmbGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbGroup.Properties.Items.AddRange(New Object() {"1 - Aktiva", "2 - Pasiva", "3 - Ekuitas", "4 - Pendapatan", "5 - Biaya", "6 - Lain-lain"})
        Me.CmbGroup.Size = New System.Drawing.Size(100, 20)
        Me.CmbGroup.TabIndex = 112
        '
        'FrmKodePerkiraan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 259)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.TxtSaldo)
        Me.Controls.Add(Me.ChkKasBank)
        Me.Controls.Add(Me.TxtNamaParent)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.RdJenis)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.CekStatusAktif)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.TxtNama)
        Me.Controls.Add(Me.TxtKode)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.TxtUrutan)
        Me.Controls.Add(Me.TxtKodeParent)
        Me.Controls.Add(Me.TxtPeriode)
        Me.Controls.Add(Me.CmbGroup)
        Me.KeyPreview = True
        Me.Name = "FrmKodePerkiraan"
        Me.Text = "Kode Perkiraan"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CekStatusAktif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RdJenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUrutan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaParent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeParent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkKasBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents _Toolbar1_Button3 As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button1 As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button2 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CekStatusAktif As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RdJenis As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtUrutan As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNamaParent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeParent As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ChkKasBank As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSaldo As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CmbGroup As DevExpress.XtraEditors.ComboBoxEdit
End Class
