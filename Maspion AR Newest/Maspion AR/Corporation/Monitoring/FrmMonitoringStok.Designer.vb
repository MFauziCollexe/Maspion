<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonitoringStok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonitoringStok))
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me._Toolbar1_Button9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCari = New DevExpress.XtraEditors.TextEdit()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.TBMonStok = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.colGudang = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colKode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colNama = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colGrup = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDivisi = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColKoliStokReal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colStokReal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColKoliDOOuts = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDOOuts = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColKoliMarketing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColStokMarketing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSatuan = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.colKoliStuffing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPcsStuffing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Toolbar1.SuspendLayout()
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        CType(Me.TBMonStok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Toolbar1_Button9, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(833, 25)
        Me.Toolbar1.TabIndex = 14
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
        '_Toolbar1_Button9
        '
        Me._Toolbar1_Button9.AutoSize = False
        Me._Toolbar1_Button9.ImageIndex = 7
        Me._Toolbar1_Button9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Toolbar1_Button9.Name = "_Toolbar1_Button9"
        Me._Toolbar1_Button9.Size = New System.Drawing.Size(80, 22)
        Me._Toolbar1_Button9.Text = "F5 - Keluar"
        Me._Toolbar1_Button9.ToolTipText = "F5 - Keluar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Maspion.PrintRibbonControllerResources.RibbonPrintPreview_PrintDirect
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripButton1.Text = "F6 - Cetak"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.Maspion.My.Resources.Resources.ReturPembelian
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripButton2.Text = "Refresh"
        '
        'txtCari
        '
        Me.txtCari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCari.Location = New System.Drawing.Point(96, 43)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(725, 20)
        Me.txtCari.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.txtCari, "Masukkan Kata Kunci Untuk Mencari Data")
        '
        'Frame1
        '
        Me.Frame1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame1.BackColor = System.Drawing.Color.Transparent
        Me.Frame1.Controls.Add(Me.TBMonStok)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(4, 69)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(830, 332)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Data"
        '
        'TBMonStok
        '
        Me.TBMonStok.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBMonStok.Location = New System.Drawing.Point(6, 13)
        Me.TBMonStok.MainView = Me.BandedGridView1
        Me.TBMonStok.Name = "TBMonStok"
        Me.TBMonStok.Size = New System.Drawing.Size(819, 316)
        Me.TBMonStok.TabIndex = 15
        Me.TBMonStok.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView1})
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand6, Me.gridBand8, Me.gridBand9, Me.gridBand7, Me.gridBand4, Me.gridBand1, Me.gridBand2, Me.gridBand3})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colGudang, Me.colKode, Me.colNama, Me.colGrup, Me.colDivisi, Me.ColKoliStokReal, Me.colStokReal, Me.colKoliStuffing, Me.colPcsStuffing, Me.ColKoliDOOuts, Me.colDOOuts, Me.ColKoliMarketing, Me.ColStokMarketing, Me.colSatuan})
        Me.BandedGridView1.GridControl = Me.TBMonStok
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsBehavior.Editable = False
        Me.BandedGridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'colGudang
        '
        Me.colGudang.Caption = "Gudang"
        Me.colGudang.FieldName = "NAMA_GUDANG"
        Me.colGudang.Name = "colGudang"
        Me.colGudang.Visible = True
        Me.colGudang.Width = 93
        '
        'colKode
        '
        Me.colKode.Caption = "Kode"
        Me.colKode.FieldName = "KODE"
        Me.colKode.Name = "colKode"
        Me.colKode.Visible = True
        Me.colKode.Width = 38
        '
        'colNama
        '
        Me.colNama.Caption = "Nama"
        Me.colNama.FieldName = "NAMA"
        Me.colNama.Name = "colNama"
        Me.colNama.Visible = True
        Me.colNama.Width = 137
        '
        'colGrup
        '
        Me.colGrup.Caption = "Group Barang"
        Me.colGrup.FieldName = "GRUP"
        Me.colGrup.Name = "colGrup"
        Me.colGrup.Visible = True
        Me.colGrup.Width = 86
        '
        'colDivisi
        '
        Me.colDivisi.Caption = "Divisi"
        Me.colDivisi.FieldName = "DIVISI"
        Me.colDivisi.Name = "colDivisi"
        Me.colDivisi.Visible = True
        Me.colDivisi.Width = 57
        '
        'ColKoliStokReal
        '
        Me.ColKoliStokReal.Caption = "Koli Stok"
        Me.ColKoliStokReal.CustomizationCaption = "Koli"
        Me.ColKoliStokReal.FieldName = "KOLI"
        Me.ColKoliStokReal.Name = "ColKoliStokReal"
        Me.ColKoliStokReal.Visible = True
        '
        'colStokReal
        '
        Me.colStokReal.Caption = "Pcs"
        Me.colStokReal.FieldName = "STOK_PCS"
        Me.colStokReal.Name = "colStokReal"
        Me.colStokReal.Visible = True
        Me.colStokReal.Width = 41
        '
        'ColKoliDOOuts
        '
        Me.ColKoliDOOuts.Caption = "Koli Outs"
        Me.ColKoliDOOuts.FieldName = "KOLI_DO_OUTS"
        Me.ColKoliDOOuts.Name = "ColKoliDOOuts"
        Me.ColKoliDOOuts.Visible = True
        '
        'colDOOuts
        '
        Me.colDOOuts.Caption = "Pcs"
        Me.colDOOuts.FieldName = "DO_OUTS"
        Me.colDOOuts.Name = "colDOOuts"
        Me.colDOOuts.Visible = True
        Me.colDOOuts.Width = 44
        '
        'ColKoliMarketing
        '
        Me.ColKoliMarketing.Caption = "Koli Marketing"
        Me.ColKoliMarketing.FieldName = "KOLI_STOK_MARKETING"
        Me.ColKoliMarketing.Name = "ColKoliMarketing"
        Me.ColKoliMarketing.Visible = True
        '
        'ColStokMarketing
        '
        Me.ColStokMarketing.Caption = "Pcs"
        Me.ColStokMarketing.FieldName = "STOK_MARKETING"
        Me.ColStokMarketing.Name = "ColStokMarketing"
        Me.ColStokMarketing.Visible = True
        '
        'colSatuan
        '
        Me.colSatuan.Caption = "Satuan"
        Me.colSatuan.FieldName = "SAT_SUPER1"
        Me.colSatuan.Name = "colSatuan"
        Me.colSatuan.Visible = True
        Me.colSatuan.Width = 35
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 46)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl2.TabIndex = 99
        Me.LabelControl2.Text = "Pencarian Data :"
        '
        'colKoliStuffing
        '
        Me.colKoliStuffing.Caption = "Koli"
        Me.colKoliStuffing.FieldName = "KOLI_STUFFING"
        Me.colKoliStuffing.Name = "colKoliStuffing"
        Me.colKoliStuffing.Visible = True
        '
        'colPcsStuffing
        '
        Me.colPcsStuffing.Caption = "Pcs"
        Me.colPcsStuffing.FieldName = "PCS_STUFFING"
        Me.colPcsStuffing.Name = "colPcsStuffing"
        Me.colPcsStuffing.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Gudang"
        Me.gridBand6.Columns.Add(Me.colGudang)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 0
        Me.gridBand6.Width = 93
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Barang"
        Me.gridBand8.Columns.Add(Me.colKode)
        Me.gridBand8.Columns.Add(Me.colNama)
        Me.gridBand8.Columns.Add(Me.colGrup)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 1
        Me.gridBand8.Width = 261
        '
        'gridBand9
        '
        Me.gridBand9.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand9.Caption = "Divisi"
        Me.gridBand9.Columns.Add(Me.colDivisi)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 2
        Me.gridBand9.Width = 57
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "Stok"
        Me.gridBand7.Columns.Add(Me.ColKoliStokReal)
        Me.gridBand7.Columns.Add(Me.colStokReal)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 3
        Me.gridBand7.Width = 116
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "Stuffing"
        Me.gridBand4.Columns.Add(Me.colKoliStuffing)
        Me.gridBand4.Columns.Add(Me.colPcsStuffing)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 150
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "DO Outstanding"
        Me.gridBand1.Columns.Add(Me.ColKoliDOOuts)
        Me.gridBand1.Columns.Add(Me.colDOOuts)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 5
        Me.gridBand1.Width = 119
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Stok Marketing"
        Me.gridBand2.Columns.Add(Me.ColKoliMarketing)
        Me.gridBand2.Columns.Add(Me.ColStokMarketing)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 6
        Me.gridBand2.Width = 150
        '
        'gridBand3
        '
        Me.gridBand3.Columns.Add(Me.colSatuan)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 7
        Me.gridBand3.Width = 35
        '
        'FrmMonitoringStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 403)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.txtCari)
        Me.KeyPreview = True
        Me.Name = "FrmMonitoringStok"
        Me.Text = "Monitoring Stok"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        CType(Me.TBMonStok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents _Toolbar1_Button9 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBMonStok As DevExpress.XtraGrid.GridControl
    Friend WithEvents txtCari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colGudang As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colKode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colNama As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colGrup As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDivisi As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colStokReal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDOOuts As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSatuan As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColStokMarketing As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Public WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents ColKoliStokReal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColKoliDOOuts As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColKoliMarketing As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colKoliStuffing As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPcsStuffing As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
