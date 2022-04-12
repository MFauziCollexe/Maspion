<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPromo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPromo))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TBSatuan = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTambah = New DevExpress.XtraEditors.SimpleButton()
        Me.GBInput = New System.Windows.Forms.GroupBox()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKode = New DevExpress.XtraEditors.TextEdit()
        Me.BtnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TBSatuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBInput.SuspendLayout()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TBSatuan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 327)
        Me.GroupBox2.TabIndex = 139
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Daftar Promo :"
        '
        'TBSatuan
        '
        Me.TBSatuan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBSatuan.Location = New System.Drawing.Point(6, 19)
        Me.TBSatuan.MainView = Me.GridView1
        Me.TBSatuan.Name = "TBSatuan"
        Me.TBSatuan.Size = New System.Drawing.Size(269, 302)
        Me.TBSatuan.TabIndex = 9
        Me.TBSatuan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TBSatuan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BtnHapus
        '
        Me.BtnHapus.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapus.Appearance.Options.UseFont = True
        Me.BtnHapus.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnHapus.Image = CType(resources.GetObject("BtnHapus.Image"), System.Drawing.Image)
        Me.BtnHapus.Location = New System.Drawing.Point(486, 19)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(101, 34)
        Me.BtnHapus.TabIndex = 5
        Me.BtnHapus.Text = "Hapus"
        '
        'BtnTambah
        '
        Me.BtnTambah.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTambah.Appearance.Options.UseFont = True
        Me.BtnTambah.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnTambah.Image = CType(resources.GetObject("BtnTambah.Image"), System.Drawing.Image)
        Me.BtnTambah.Location = New System.Drawing.Point(299, 19)
        Me.BtnTambah.Name = "BtnTambah"
        Me.BtnTambah.Size = New System.Drawing.Size(101, 34)
        Me.BtnTambah.TabIndex = 0
        Me.BtnTambah.Text = "Tambah"
        '
        'GBInput
        '
        Me.GBInput.Controls.Add(Me.TxtNama)
        Me.GBInput.Controls.Add(Me.TxtKode)
        Me.GBInput.Controls.Add(Me.BtnBatal)
        Me.GBInput.Controls.Add(Me.BtnOK)
        Me.GBInput.Location = New System.Drawing.Point(299, 59)
        Me.GBInput.Name = "GBInput"
        Me.GBInput.Size = New System.Drawing.Size(288, 102)
        Me.GBInput.TabIndex = 1
        Me.GBInput.TabStop = False
        Me.GBInput.Text = "Input Group Item"
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(6, 44)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNama.Properties.Appearance.Options.UseFont = True
        Me.TxtNama.Size = New System.Drawing.Size(276, 22)
        Me.TxtNama.TabIndex = 5
        '
        'TxtKode
        '
        Me.TxtKode.Enabled = False
        Me.TxtKode.Location = New System.Drawing.Point(6, 19)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKode.Properties.Appearance.Options.UseFont = True
        Me.TxtKode.Size = New System.Drawing.Size(149, 22)
        Me.TxtKode.TabIndex = 2
        '
        'BtnBatal
        '
        Me.BtnBatal.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBatal.Appearance.Options.UseFont = True
        Me.BtnBatal.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnBatal.Image = CType(resources.GetObject("BtnBatal.Image"), System.Drawing.Image)
        Me.BtnBatal.Location = New System.Drawing.Point(186, 72)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(52, 24)
        Me.BtnBatal.TabIndex = 4
        Me.BtnBatal.Text = "Batal"
        '
        'BtnOK
        '
        Me.BtnOK.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.Appearance.Options.UseFont = True
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(240, 72)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(42, 24)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK"
        '
        'BtnEdit
        '
        Me.BtnEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.Appearance.Options.UseFont = True
        Me.BtnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(402, 19)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(82, 34)
        Me.BtnEdit.TabIndex = 140
        Me.BtnEdit.Text = "Edit"
        '
        'FrmPromo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 351)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.GBInput)
        Me.Controls.Add(Me.BtnTambah)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPromo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promo"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.TBSatuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBInput.ResumeLayout(False)
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TBSatuan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnTambah As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GBInput As System.Windows.Forms.GroupBox
    Friend WithEvents TxtKode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
End Class
