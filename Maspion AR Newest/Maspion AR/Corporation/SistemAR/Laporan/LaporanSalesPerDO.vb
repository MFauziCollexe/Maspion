Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanSalesPerDO
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtNoDO As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RGFilter As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents Label2 As Label

    Private Sub InitializeComponent()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKodeCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNoDO = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.RGFilter = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RGFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.RGFilter)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.DTPeriode)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNoDO)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNoDO, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DTPeriode, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RGFilter, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.LabelControl1, 0)
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(102, 197)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 119)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Customer :"
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(102, 119)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Properties.ReadOnly = True
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(90, 20)
        Me.TxtKodeCustomer.TabIndex = 245
        '
        'TxtNamaCustomer
        '
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(199, 119)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(131, 20)
        Me.TxtNamaCustomer.TabIndex = 246
        '
        'TxtNoDO
        '
        Me.TxtNoDO.Location = New System.Drawing.Point(102, 171)
        Me.TxtNoDO.Name = "TxtNoDO"
        Me.TxtNoDO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtNoDO.Properties.ReadOnly = True
        Me.TxtNoDO.Size = New System.Drawing.Size(228, 20)
        Me.TxtNoDO.TabIndex = 248
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 174)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "No. DO :"
        '
        'DTPeriode
        '
        Me.DTPeriode.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DTPeriode.Location = New System.Drawing.Point(102, 93)
        Me.DTPeriode.Name = "DTPeriode"
        Me.DTPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditValueChangedDelay = 3
        Me.DTPeriode.Size = New System.Drawing.Size(228, 20)
        Me.DTPeriode.TabIndex = 114
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Periode :"
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(102, 145)
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtKodeDivisi.TabIndex = 250
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 148)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 249
        Me.Label4.Text = "Divisi :"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(198, 145)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(131, 20)
        Me.TxtDivisi.TabIndex = 247
        '
        'RGFilter
        '
        Me.RGFilter.Location = New System.Drawing.Point(102, 70)
        Me.RGFilter.Name = "RGFilter"
        Me.RGFilter.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Periode", "Periode"), New DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All")})
        Me.RGFilter.Size = New System.Drawing.Size(140, 22)
        Me.RGFilter.TabIndex = 251
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 75)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl1.TabIndex = 252
        Me.LabelControl1.Text = "Filter Laporan :"
        '
        'LaporanSalesPerDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanSalesPerDO"
        Me.Text = "Laporan Sales Per DO"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoDO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RGFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        'If TxtKodeCustomer.Text = "" Then Exit Sub
        'If TxtNoDO.Text = "" Then Exit Sub
        Dim MyReport = New CetakanLaporanSalesPerDO
        If RGFilter.SelectedIndex = 0 Then
            MyReport.XrLabel46.Text = "Periode : " & Format(DTPeriode.DateTime, "MMMM yyyy")
        Else
            MyReport.XrLabel46.Text = ""
        End If
        'MyReport.XrLabel12.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        'MyReport.XrLabel73.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Dim filterdo As String
        If RGFilter.SelectedIndex = 1 Then
            If TxtNoDO.Text = "" Then Exit Sub
        End If
        If TxtNoDO.Text <> "" Then
            filterdo = " and A.ID_TRANSAKSI = '" & TxtNoDO.Text & "'"
        Else
            filterdo = ""
        End If
        Dim filtercustomer As String
        If TxtKodeCustomer.Text <> "" Then
            filtercustomer = "and A.KODE_APPROVE = '" & TxtKodeCustomer.Text & "'"
        Else
            filtercustomer = ""
        End If
        Dim filterdivisi As String
        If TxtKodeDivisi.Text <> "" Then
            filterdivisi = "and A.DIVISI = '" & TxtKodeDivisi.Text & "'"
        Else
            filterdivisi = ""
        End If
        Report = MyReport
        If RGFilter.SelectedIndex = 1 Then
            Report.DataSource = SelectCon.execute("select  A.NO_DO,a.KODE_APPROVE,d.NAMA customer,b.TGL_PENGAKUAN TGL,NULL TGL_PEMBAYARAN,right(B.NO_NOTA,6) NO_TRANSAKSI,b.DPP +B.PPN + (iif(isnull(e.jenis,'') = 'Debit',isnull(e.jumlah,0),isnull(e.jumlah,0) * -1)) AS NILAI_NOTA,0 as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PENJUALAN' JENIS,3 as URUT,count( B.NO_NOTA) over(partition by A.NO_DO) COUNT_DO from DELIVERY_ORDER A  join nota b with(nolock)on b.ID_DO = a.ID_TRANSAKSI left join CUSTOMER d on d.ID = a.KODE_CUSTOMER
left join DEBIT_KREDIT_NOTE e on e.ID_NOTA = b.ID_TRANSAKSI and e.JENIS_CNDN = 'DO Kontan'
  where PEMBAYARAN = 'KONTAN'  and b.batal = 0  " & filterdo & " " & filtercustomer & " " & filterdivisi & "
    union all
    select  A.NO_DO,a.KODE_APPROVE,d.NAMA customer,b.TGL_PENGAKUAN TGL,NULL TGL_PEMBAYARAN,right(B.NO_NOTA,6) NO_TRANSAKSI,b.DPP +B.PPN + (iif(isnull(e.jenis,'') = 'Debit',isnull(e.jumlah,0),isnull(e.jumlah,0) * -1)) AS NILAI_NOTA,0 as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PENJUALAN' JENIS,3 as URUT,count( B.NO_NOTA) over(partition by A.NO_DO) COUNT_DO from DELIVERY_ORDER A join BON_PESANAN bp on bp.ID_DO = a.ID_TRANSAKSI  join nota b with(nolock)on b.ID_DO = BP.ID_TRANSAKSI left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join DEBIT_KREDIT_NOTE e on e.ID_NOTA = b.ID_TRANSAKSI and e.JENIS_CNDN = 'DO Kontan' where PEMBAYARAN = 'KONTAN' and b.batal = 0  " & filterdo & " " & filtercustomer & " " & filterdivisi & "
    union all
    select A.NO_DO,a.KODE_APPROVE,d.NAMA customer,NULL TGL,A.TGL_PENGAKUAN TGL_PEMBAYARAN,NULL NO_TRANSAKSI,0 AS NILAI_NOTA,a.DPP+a.PPN as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PEMBAYARAN / KEKURANGAN DO' JENIS,1 as URUT,0 count_data from DELIVERY_ORDER A left join CUSTOMER d on d.ID = a.KODE_CUSTOMER where PEMBAYARAN = 'KONTAN'    " & filterdo & " " & filtercustomer & " " & filterdivisi & "
    union all
    select A.NO_DO,a.KODE_APPROVE,d.NAMA customer,NULL TGL,C.TGL TGL_PEMBAYARAN,NULL NO_TRANSAKSI,0 AS NILAI_NOTA,C.JUMLAH_BELUM_DIBAYAR as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PEMBATALAN / KOREKSI' JENIS,2 as URUT,0 count_data from DELIVERY_ORDER A left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN C ON C.ID_DO_KONTAN = A.ID_TRANSAKSI where PEMBAYARAN = 'KONTAN'     " & filterdo & " " & filtercustomer & " " & filterdivisi & "
    	union all
	 select A.NO_DO,a.KODE_APPROVE,d.NAMA customer,NULL TGL,C.TGL TGL_PEMBAYARAN,NULL NO_TRANSAKSI,0 AS NILAI_NOTA,C.JUMLAH_KURANG_BAYAR  as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PEMBATALAN / KOREKSI' JENIS,2 as URUT,0 count_data from DELIVERY_ORDER A left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN C ON C.ID_DO_KONTAN = A.ID_TRANSAKSI where PEMBAYARAN = 'KONTAN'     " & filterdo & " " & filtercustomer & " " & filterdivisi & "")
        Else
            Report.DataSource = SelectCon.execute("select  A.NO_DO,a.KODE_APPROVE,d.NAMA customer,b.TGL_PENGAKUAN TGL,NULL TGL_PEMBAYARAN,right(B.NO_NOTA,6) NO_TRANSAKSI,b.DPP +B.PPN + (iif(isnull(e.jenis,'') = 'Debit',isnull(e.jumlah,0),isnull(e.jumlah,0) * -1)) AS NILAI_NOTA,0 as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PENJUALAN' JENIS,3 as URUT,count( B.NO_NOTA) over(partition by A.NO_DO) COUNT_DO from DELIVERY_ORDER A  join nota b with(nolock)on b.ID_DO = a.ID_TRANSAKSI left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join DEBIT_KREDIT_NOTE e on e.ID_NOTA = b.ID_TRANSAKSI and e.JENIS_CNDN = 'DO Kontan'  where PEMBAYARAN = 'KONTAN' and b.batal = 0  and format(b.tgl_pengakuan,'MMMM yyyy') = '" & Format(DTPeriode.DateTime, "MMMM yyyy") & "' " & filterdo & " " & filtercustomer & " " & filterdivisi & "
union all
select  A.NO_DO,a.KODE_APPROVE,d.NAMA customer,b.TGL_PENGAKUAN TGL,NULL TGL_PEMBAYARAN,right(B.NO_NOTA,6) NO_TRANSAKSI,b.DPP +B.PPN + (iif(isnull(e.jenis,'') = 'Debit',isnull(e.jumlah,0),isnull(e.jumlah,0) * -1)) AS NILAI_NOTA,0 as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PENJUALAN' JENIS,3 as URUT,count( B.NO_NOTA) over(partition by A.NO_DO) COUNT_DO from DELIVERY_ORDER A join BON_PESANAN bp on bp.ID_DO = a.ID_TRANSAKSI  join nota b with(nolock)on b.ID_DO = BP.ID_TRANSAKSI left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join DEBIT_KREDIT_NOTE e on e.ID_NOTA = b.ID_TRANSAKSI and e.JENIS_CNDN = 'DO Kontan' where PEMBAYARAN = 'KONTAN' and b.batal = 0and format(b.tgl_pengakuan,'MMMM yyyy') = '" & Format(DTPeriode.DateTime, "MMMM yyyy") & "' " & filterdo & " " & filtercustomer & " " & filterdivisi & "
union all
select A.NO_DO,a.KODE_APPROVE,d.NAMA customer,NULL TGL,A.TGL_PENGAKUAN TGL_PEMBAYARAN,NULL NO_TRANSAKSI,0 AS NILAI_NOTA,a.DPP+a.PPN as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PEMBAYARAN / KEKURANGAN DO' JENIS,1 as URUT,0 count_data from DELIVERY_ORDER A left join CUSTOMER d on d.ID = a.KODE_CUSTOMER where PEMBAYARAN = 'KONTAN'   and format(a.tgl_pengakuan,'MMMM yyyy') = '" & Format(DTPeriode.DateTime, "MMMM yyyy") & "' " & filterdo & " " & filtercustomer & " " & filterdivisi & "
union all
select A.NO_DO,a.KODE_APPROVE,d.NAMA customer,NULL TGL,C.TGL TGL_PEMBAYARAN,NULL NO_TRANSAKSI,0 AS NILAI_NOTA,C.JUMLAH_BELUM_DIBAYAR as NILAI_PEMBAYARAN,0 as NILAI_NOTA_USD,'PEMBATALAN / KOREKSI' JENIS,2 as URUT,0 count_data from DELIVERY_ORDER A left join CUSTOMER d on d.ID = a.KODE_CUSTOMER left join AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN C ON C.ID_DO_KONTAN = A.ID_TRANSAKSI where PEMBAYARAN = 'KONTAN'   and format(a.tgl_pengakuan,'MMMM yyyy') = '" & Format(DTPeriode.DateTime, "MMMM yyyy") & "' " & filterdo & " " & filtercustomer & " " & filterdivisi & "")

        End If
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        RGFilter.SelectedIndex = 0
        Nama = "Laporan Sales Per DO"
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        '  DTPeriode.DateTime = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub

    Private Sub TxtKodeCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtKodeCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        TxtKodeCustomer.Text = kode
    End Sub

    Private Sub TxtNoDO_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoDO.EditValueChanged

    End Sub

    Private Sub TxtNoDO_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoDO.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.DO_KONTAN)
        TxtNoDO.Text = kode
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

    Private Sub RGFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RGFilter.SelectedIndexChanged
        If RGFilter.SelectedIndex = 1 Then
            DTPeriode.Enabled = False
        Else
            DTPeriode.Enabled = True
        End If
    End Sub
End Class
