Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanSalesUM
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents RDJenisPenjualan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TBDivisi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RBEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Label4 As Label

    Private Sub InitializeComponent()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RDJenisPenjualan = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TBDivisi = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RBEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.TBDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.RDJenisPenjualan)
        Me.XtraScrollableControl1.Controls.Add(Me.DTPeriode)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DTPeriode, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RDJenisPenjualan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TBDivisi, 0)
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(93, 168)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(190, 84)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(131, 20)
        Me.TxtDivisi.TabIndex = 251
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(94, 84)
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtKodeDivisi.TabIndex = 253
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 252
        Me.Label4.Text = "Divisi :"
        '
        'DTPeriode
        '
        Me.DTPeriode.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DTPeriode.Location = New System.Drawing.Point(93, 58)
        Me.DTPeriode.Name = "DTPeriode"
        Me.DTPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditValueChangedDelay = 3
        Me.DTPeriode.Size = New System.Drawing.Size(228, 20)
        Me.DTPeriode.TabIndex = 255
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Periode :"
        '
        'RDJenisPenjualan
        '
        Me.RDJenisPenjualan.AutoSizeInLayoutControl = True
        Me.RDJenisPenjualan.EditValue = ""
        Me.RDJenisPenjualan.EnterMoveNextControl = True
        Me.RDJenisPenjualan.Location = New System.Drawing.Point(93, 118)
        Me.RDJenisPenjualan.Margin = New System.Windows.Forms.Padding(1)
        Me.RDJenisPenjualan.Name = "RDJenisPenjualan"
        Me.RDJenisPenjualan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("", "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Perwakilan", "Perwakilan"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Pusat", "Pusat")})
        Me.RDJenisPenjualan.Size = New System.Drawing.Size(228, 46)
        Me.RDJenisPenjualan.TabIndex = 249
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(51, 125)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl6.TabIndex = 250
        Me.LabelControl6.Text = "Jenis :"
        '
        'TBDivisi
        '
        Me.TBDivisi.Location = New System.Drawing.Point(84, 300)
        Me.TBDivisi.MainView = Me.GridView1
        Me.TBDivisi.Name = "TBDivisi"
        Me.TBDivisi.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RBEdit})
        Me.TBDivisi.Size = New System.Drawing.Size(217, 130)
        Me.TBDivisi.TabIndex = 143
        Me.TBDivisi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.TBDivisi.Visible = False
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.GridControl = Me.TBDivisi
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'RBEdit
        '
        Me.RBEdit.AutoHeight = False
        Me.RBEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RBEdit.Name = "RBEdit"
        Me.RBEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LaporanSalesUM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 672)
        Me.Name = "LaporanSalesUM"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDJenisPenjualan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBDivisi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim filterdivisi As String
        Dim filter As String = ""
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "A.DIVISI='" & r(0) & "' "
            End If
        Next
        If TxtKodeDivisi.Text <> "" Then
            filterdivisi = "and A.DIVISI = '" & TxtKodeDivisi.Text & "'"
        Else
            filterdivisi = ""
        End If
        Dim tempdate As DateTime = DTPeriode.DateTime
        Dim dateakhir As DateTime
        Dim dateawal As DateTime
        dateakhir = New DateTime(tempdate.Year, tempdate.Month, 1).AddMonths(1).AddDays(-1)
        dateawal = New DateTime(dateakhir.Year, dateakhir.Month, 1)

        Dim MyReport = New CetakanLaporanSaldoUM
        Report = MyReport
        MyReport.XrLabel2.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Dim filterjenis As String = ""
        If RDJenisPenjualan.SelectedIndex = 0 Then
            filterjenis = ""
        End If
        If RDJenisPenjualan.SelectedIndex = 1 Then
            filterjenis = "and left(replace(NO_DO,'* ',''),1) = 'P'"
        End If
        If RDJenisPenjualan.SelectedIndex = 2 Then
            filterjenis = "and left(replace(NO_DO,'* ',''),1) = 'J'"
        End If
        '        Report.DataSource = SelectCon.execute("select distinct A.DIVISI,C.NAMA NAMA_DIVISI,right(A.NO_DO,6) NO_DO,a.TGL,format(a.tgl,'yy') Tahun,D.NAMA CUSTOMER,isnull(E.AWAL,0) SALDO_AWAL,isnull(TOTAL,0) PENJUALAN,A.DPP + A.PPN PEMBAYARAN,isnull(F.PEMBATALAN,0) PEMBATALAN from DELIVERY_ORDER A with(nolock) left join (select ID_DO,DIVISI,KODE_APPROVE,KODE_CUSTOMER,sum(DPP+PPN)TOTAL from nota with(nolock)where batal = 0 and TGL between '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "' group by ID_DO,DIVISI,KODE_APPROVE,KODE_CUSTOMER) B  on A.ID_TRANSAKSI = B.ID_DO and B.DIVISI = A.DIVISI and A.KODE_APPROVE = B.KODE_APPROVE and A.KODE_CUSTOMER = B.KODE_CUSTOMER  left join DIVISI C With(Nolock) ON C.KODE = A.DIVISI left join CUSTOMER D WITH(NOLOCK) ON D.KODE_APPROVE = a.KODE_APPROVE and D.ID = A.KODE_CUSTOMER left join (
        'select A.ID_TRANSAKSI,A.KODE_APPROVE,A.KODE_CUSTOMER,sum(A.DPP+A.PPN) - isnull(TOTAL,0) AWAL  from DELIVERY_ORDER A with(nolock) left join (select ID_DO,DIVISI,KODE_APPROVE,KODE_CUSTOMER,sum(DPP+PPN)TOTAL from nota with(nolock)where batal = 0 and TGL < '" & Format(dateawal, "yyyy-MM-dd") & "' group by ID_DO,DIVISI,KODE_APPROVE,KODE_CUSTOMER) B  on A.ID_TRANSAKSI = B.ID_DO and B.DIVISI = A.DIVISI and A.KODE_APPROVE = B.KODE_APPROVE and A.KODE_CUSTOMER = B.KODE_CUSTOMER where JENIS_DO = 'ADA BARANG' and PEMBAYARAN = 'KONTAN' and A.BATAL = 0 and A.tgl < '" & Format(dateawal, "yyyy-MM-dd") & "' group by A.ID_TRANSAKSI,A.KODE_APPROVE,A.KODE_CUSTOMER,TOTAL) E ON E.ID_TRANSAKSI =A.ID_TRANSAKSI and E.KODE_APPROVE = A.KODE_APPROVE and E.KODE_CUSTOMER = A.KODE_CUSTOMER
        'left join 
        '(
        'select A.ID_TRANSAKSI,A.ID_DO_KONTAN,A.KODE_APPROVE,A.KODE_CUSTOMER,sum(A.JUMLAH_BELUM_DIBAYAR) PEMBATALAN  from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN A with(nolock)   where A.tgl between '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "' group by A.ID_TRANSAKSI,A.KODE_APPROVE,A.KODE_CUSTOMER,A.ID_DO_KONTAN) F on F.ID_DO_KONTAN = A.ID_TRANSAKSI
        'where JENIS_DO = 'ADA BARANG' and PEMBAYARAN = 'KONTAN' and A.BATAL = 0 and A.TGL between '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "' " & filterdivisi & " ")
        Report.DataSource = SelectCon.execute("select * from F_AR_SALDO_UM('" & TxtKodeDivisi.Text & "','" & Format(dateawal, "yyyy-MM-dd") & "','" & Format(dateakhir, "yyyy-MM-dd") & "') where (SALDO_AWAL <> 0 or PEMBAYARAN <> 0 or PENJUALAN <> 0 or PEMBATALAN <> 0) " & filterjenis & "  order by right(NO_DO,6) asc")
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private dtDivisi As New DataTable
    Private Sub loadDivisi()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 25, False)
        InitGrid.AddColumnGrid("Check", TypeCode.Boolean, 20)
        InitGrid.EndInit(TBDivisi, GridView1, dtDivisi)

        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisi, False)
    End Sub
    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Saldo UM"
        DTPeriode.DateTime = Now.Date
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        loadDivisi()
        '   DtTanggalAwal.DateTime = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        '  DtTanggalAkhir.DateTime = Now.Date
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub

    Private Sub TxtKodeDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeDivisi.EditValueChanged
        Using dtdivisi = SelectCon.execute("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtKodeDivisi.Text & "'")
            If dtdivisi.Rows.Count > 0 Then
                TxtDivisi.Text = dtdivisi.Rows(0).Item("NAMA")
            Else
                TxtDivisi.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeDivisi.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Divisi)
        TxtKodeDivisi.Text = kode
    End Sub
End Class
