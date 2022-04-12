Imports DevExpress.XtraCharts

Public Class LaporanJurnalAR
    Inherits FrmLaporanBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtTanggalAwal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DtTanggalAkhir As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents RGJenisLaporan As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxEdit2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DtTanggalAwal = New DevExpress.XtraEditors.DateEdit()
        Me.DtTanggalAkhir = New DevExpress.XtraEditors.DateEdit()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RGJenisLaporan = New DevExpress.XtraEditors.RadioGroup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxEdit2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.DtTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RGJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.Label5)
        Me.XtraScrollableControl1.Controls.Add(Me.ComboBoxEdit2)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.RGJenisLaporan)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.ComboBoxEdit1)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAkhir)
        Me.XtraScrollableControl1.Controls.Add(Me.DtTanggalAwal)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAwal, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DtTanggalAkhir, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.ComboBoxEdit1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.RGJenisLaporan, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.ComboBoxEdit2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label5, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 104)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tanggal :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 105)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "-"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(96, 198)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'DtTanggalAwal
        '
        Me.DtTanggalAwal.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtTanggalAwal.Location = New System.Drawing.Point(96, 101)
        Me.DtTanggalAwal.Name = "DtTanggalAwal"
        Me.DtTanggalAwal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAwal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAwal.Properties.EditValueChangedDelay = 3
        Me.DtTanggalAwal.Size = New System.Drawing.Size(105, 20)
        Me.DtTanggalAwal.TabIndex = 112
        '
        'DtTanggalAkhir
        '
        Me.DtTanggalAkhir.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtTanggalAkhir.Location = New System.Drawing.Point(219, 102)
        Me.DtTanggalAkhir.Name = "DtTanggalAkhir"
        Me.DtTanggalAkhir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAkhir.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalAkhir.Properties.EditValueChangedDelay = 3
        Me.DtTanggalAkhir.Size = New System.Drawing.Size(105, 20)
        Me.DtTanggalAkhir.TabIndex = 113
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(96, 136)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Items.AddRange(New Object() {"Semua", "Perwakilan", "UCF", "Pabrik / Pusat"})
        Me.ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(228, 20)
        Me.ComboBoxEdit1.TabIndex = 245
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 139)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 246
        Me.Label3.Text = "Jenis Jurnal :"
        '
        'RGJenisLaporan
        '
        Me.RGJenisLaporan.Location = New System.Drawing.Point(96, 71)
        Me.RGJenisLaporan.Name = "RGJenisLaporan"
        Me.RGJenisLaporan.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Detail", "Detail"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Rekap", "Rekap")})
        Me.RGJenisLaporan.Size = New System.Drawing.Size(228, 24)
        Me.RGJenisLaporan.TabIndex = 247
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 76)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 248
        Me.Label4.Text = "Jenis Laporan :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 165)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Transaksi :"
        '
        'ComboBoxEdit2
        '
        Me.ComboBoxEdit2.Location = New System.Drawing.Point(96, 162)
        Me.ComboBoxEdit2.Name = "ComboBoxEdit2"
        Me.ComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit2.Properties.Items.AddRange(New Object() {"Pembelian", "Penjualan", "Retur Pembelian", "Pelunasan Retur Pembelian", "Retur Penjualan", "DO Kontan"})
        Me.ComboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit2.Size = New System.Drawing.Size(228, 20)
        Me.ComboBoxEdit2.TabIndex = 249
        '
        'LaporanJurnalAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanJurnalAR"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.DtTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RGJenisLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview2()
        Dim filtertransaksi As String = ""
        Dim filterorderby As String = ""
        Dim filtertransaksiurutan As String = ""
        Dim filtercountpage As String = ""

        'MyReport.XrLabel2.Text = "Periode : " & Format(DtTanggalAwal.DateTime, "dd/MM/yyyy") & " s/d " & Format(DtTanggalAkhir.DateTime, "dd/MM/yyyy")
        ' MyReport.lblTitle.Text = "DAILY SALES REPORT"
        Dim filterjurnal As String = ""
        If ComboBoxEdit1.SelectedIndex <> 0 Then
            If ComboBoxEdit1.SelectedIndex = 3 Then
                filterjurnal = "and A.JENIS_JURNAL <> 'Perwakilan' and A.JENIS_JURNAL <> 'UCF'"
            ElseIf ComboBoxEdit1.SelectedIndex = 1 Then
                filterjurnal = "and A.JENIS_JURNAL = 'Perwakilan'"
            ElseIf ComboBoxEdit1.SelectedIndex = 2 Then
                filterjurnal = "and A.JENIS_JURNAL = 'UCF'"
            End If
        End If
        If ComboBoxEdit2.SelectedIndex = 0 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select ID_TRANSAKSI from AR_DSR_PEMBELIAN with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select ID_TRANSAKSI from AR_DSR_PEMBELIAN with(nolock) where ID_TRANSAKSI = A.LINK_TRANSAKSI and TGL_PENGAKUAN = A.TGL)"
            filterorderby = "order by  a.ID_JURNAL asc,a.urutan asc"
            filtercountpage = "(rowNum / 35)"
        End If
        If ComboBoxEdit2.SelectedIndex = 1 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select ID_TRANSAKSI from AR_DSR with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select ID_TRANSAKSI from AR_DSR with(nolock) where ID_TRANSAKSI = A.LINK_TRANSAKSI and TGL_PENGAKUAN = A.TGL)"
            filterorderby = "order by  a.DEBET desc"
            filtercountpage = "(rowNum / 35)"
        End If
        If ComboBoxEdit2.SelectedIndex = 2 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select ID_TRANSAKSI from AR_LAP_RETUR_PEMBELIAN with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select ID_TRANSAKSI from AR_LAP_RETUR_PEMBELIAN with(nolock) where ID_TRANSAKSI = A.LINK_TRANSAKSI and TGL_PENGAKUAN = A.TGL)"
            filtercountpage = "(rowNum / 55)"
        End If
        If ComboBoxEdit2.SelectedIndex = 3 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select NO_PELUNASAN_RETUR from AR_PELUNASAN_RETUR with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select NO_PELUNASAN_RETUR from AR_PELUNASAN_RETUR with(nolock) where NO_PELUNASAN_RETUR = A.LINK_TRANSAKSI and TGL = A.TGL)"
            filtercountpage = "(rowNum / 40)"
        End If
        If ComboBoxEdit2.SelectedIndex = 4 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select ID_TRANSAKSI from AR_LAP_RETUR_PENJUALAN with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select ID_TRANSAKSI from AR_LAP_RETUR_PENJUALAN with(nolock) where ID_TRANSAKSI = A.LINK_TRANSAKSI and TGL_PENGAKUAN = A.TGL)"
            filtercountpage = "(rowNum / 33)"
        End If
        If ComboBoxEdit2.SelectedIndex = 5 Then
            filtertransaksi = "and a.LINK_TRANSAKSI IN (select NO_PEMBAYARAN from AR_PEMBAYARAN_KONTAN with(nolock))"
            filtertransaksiurutan = "where US.ID_DSR IN (select NO_PEMBAYARAN from AR_PEMBAYARAN_KONTAN with(nolock) where NO_PEMBAYARAN = A.LINK_TRANSAKSI and TGL_PENGAKUAN = A.TGL)"
            filtercountpage = "(rowNum / 40)"
        End If
        If RGJenisLaporan.SelectedIndex = 0 Then
            Dim MyReport = New CetakanLaporanJurnalAR

            Dim lpr2 As New CetakanSubLaporanRekapJurnalAR
            '    Dim conselect As New SelectSQLServer
            lpr2.DataSource = SelectCon.execute("select JENIS_JURNAL+cast(TGL_PENGAKUAN as varchar) PARAM_SR,* from (select a.JENIS_JURNAL,a.KODE_PERKIRAAN,a.NAMA_PERKIRAAN,a.TGL_PENGAKUAN,sum(a.DEBET) DEBET,sum(a.KREDIT) KREDIT from (select case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat' when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat' when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	   
union	
    select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI where a.no_pelunasan_retur = link_transaksi)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,b.KODE_PERKIRAAN,D.NAMA_PERKIRAAN,B.DEBET DEBET, B.KREDIT  from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL join AR_KODE_PERKIRAAN d on d.KODE_PERKIRAAN = b.KODE_PERKIRAAN  where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'  " & filterjurnal & "  " & filtertransaksi & ")A  group by a.JENIS_JURNAL,a.KODE_PERKIRAAN,a.NAMA_PERKIRAAN,a.TGL_PENGAKUAN)A  order by A.KODE_PERKIRAAN asc")
            lpr2.DataMember = Nothing
            MyReport.XrSubreport1.ReportSource = lpr2
            Report = MyReport
        Else
            Dim MyReport = New CetakanLaporanRekapJurnalAR
            Report = MyReport
        End If

        If RGJenisLaporan.SelectedIndex = 0 Then
            If ComboBoxEdit2.SelectedIndex = 4 Then
                Report.DataSource = SelectCon.execute("select  JENIS_JURNAL+cast(TGL_PENGAKUAN as varchar) PARAM_SR,
JENIS_JURNAL,pt,TGL_PENGAKUAN,TGL_VALUTA,KODE_PERKIRAAN,KETERANGAN,DEBET,KREDIT,urutandsr,urutanjurnal,urutansort,PROMO,pageNum,DEBET_PER_PAGE,KREDIT_PER_PAGE,sum(prev_value) 
over (partition by jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_debet,sum(prev_value_kredit) over (partition by 
jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_kredit,status_next from (select *,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(debet_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(kredit_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value_kredit,iif( lead(isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),1,0) over (order by isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),pageNum) <> isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),'next','curr') status_next from (select *,sum(debet) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) DEBET_PER_PAGE,sum(KREDIT) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) KREDIT_PER_PAGE from (select distinct top 2147483647 *, cast(" & filtercountpage & " as bigint) + 1 as pageNum from (select *, Row_Number() OVER (partition by A.JENIS_JURNAL,A.TGL_PENGAKUAN ORDER BY A.JENIS_JURNAL,A.UrutanSorting ASC,urutanlpbl asc,debet asc,a.kode_perkiraan asc)     as rowNum  from (select distinct top 2147483647 a.JENIS_JURNAL,A.PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,A.KODE_PERKIRAAN,A.KETERANGAN,A.DEBET,sum (A.KREDIT) over(partition by a.kode_perkiraan,a.keterangan,a.jenis_jurnal,urutanjurnal) KREDIT,A.URUTANDSR,A.URUTANJURNAL,A.urutansort,a.PROMO,a.urutanSorting,urutanlpbl from (select  * from (select  top 2147483647  case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat' when A.JENIS_JURNAL IN (select distinct KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select distinct  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
	union
	select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI  where a.no_pelunasan_retur = link_transaksi
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,b.KODE_PERKIRAAN,B.KETERANGAN,B.DEBET,B.KREDIT,case when b.KETERANGAN like 'PENJ%' then (select 'NO. '+ cast(URUTAN_DSR as varchar) as URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else '' end as urutandsr,(select distinct URUTAN_LAP from AR_LAP_RETUR_PENJUALAN where ID_TRANSAKSI = a.LINK_TRANSAKSI and AR_LAP_RETUR_PENJUALAN.TGL_PENGAKUAN = a.TGL_PENGAKUAN) urutanlpbl,LEFT((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US " & filtertransaksiurutan & " 
    FOR XML PATH('')), LEN((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US   " & filtertransaksiurutan & " 
    FOR XML PATH(''))) - 1) urutanjurnal,case when b.KETERANGAN like 'PENJ%' then (select URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else 999999 end as urutansort,isnull((select distinct iif(isnull(promo_bmb_umkm,0) = 1,'*','') promo from AR_DSR_DETAIL DSD with(nolock)  join ar_dsr DS with(nolock) on DS.id_transaksi = DSD.id_transaksi where DS.ID_TRANSAKSI in (select  AA.link_transaksi from AR_JURNAL AA join AR_JURNAL_DETAIL BB ON AA.ID_JURNAL = BB.ID_JURNAL where AA.JENIS_JURNAL = A.JENIS_JURNAL and BB.KODE_PERKIRAAN = b.KODE_PERKIRAAN and BB.KETERANGAN = b.KETERANGAN and AA.TGL_PENGAKUAN = DS.TGL_PENGAKUAN) and PROMO_BMB_UMKM = 1),'') PROMO,1 as urutanSorting from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'   " & filterjurnal & " " & filtertransaksi & ") A
	 ) A   )A ) A ) A  )A )A ")
            ElseIf ComboBoxEdit2.SelectedIndex = 2 Then
                Report.DataSource = SelectCon.execute("select  JENIS_JURNAL+cast(TGL_PENGAKUAN as varchar) PARAM_SR,
JENIS_JURNAL,pt,TGL_PENGAKUAN,TGL_VALUTA,KODE_PERKIRAAN,KETERANGAN,DEBET,KREDIT,urutandsr,urutanjurnal,urutansort,PROMO,pageNum,DEBET_PER_PAGE,KREDIT_PER_PAGE,sum(prev_value) 
over (partition by jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_debet,sum(prev_value_kredit) over (partition by 
jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_kredit,status_next from (select *,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(debet_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(kredit_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value_kredit,iif( lead(isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),1,0) over (order by isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),pageNum) <> isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),'next','curr') status_next from (select *,sum(debet) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) DEBET_PER_PAGE,sum(KREDIT) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) KREDIT_PER_PAGE from (select distinct top 2147483647 *, cast(" & filtercountpage & " as bigint) + 1 as pageNum from (select *, Row_Number() OVER (partition by A.JENIS_JURNAL,A.TGL_PENGAKUAN ORDER BY A.JENIS_JURNAL,A.UrutanSorting ASC,a.urutanlpbl asc,kredit asc,kode_perkiraan asc)     as rowNum  from (select distinct top 2147483647 a.JENIS_JURNAL,A.PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,A.KODE_PERKIRAAN,A.KETERANGAN,A.DEBET,A.KREDIT KREDIT,A.URUTANDSR,A.URUTANJURNAL,A.urutansort,a.PROMO,a.urutanSorting,urutanlpbl from (select  * from (select  top 2147483647  case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat' when A.JENIS_JURNAL IN (select distinct KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select distinct  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
	union
	select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI  where a.no_pelunasan_retur = link_transaksi
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,b.KODE_PERKIRAAN,B.KETERANGAN,B.DEBET,B.KREDIT,case when b.KETERANGAN like 'PENJ%' then (select 'NO. '+ cast(URUTAN_DSR as varchar) as URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else '' end as urutandsr,(select distinct URUTAN_LAP from AR_LAP_RETUR_PEMBELIAN where ID_TRANSAKSI = a.LINK_TRANSAKSI and AR_LAP_RETUR_PEMBELIAN.TGL_PENGAKUAN = a.TGL_PENGAKUAN) urutanlpbl,LEFT((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US " & filtertransaksiurutan & " 
    FOR XML PATH('')), LEN((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US   " & filtertransaksiurutan & " 
    FOR XML PATH(''))) - 1) urutanjurnal,case when b.KETERANGAN like 'PENJ%' then (select URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else 999999 end as urutansort,isnull((select distinct iif(isnull(promo_bmb_umkm,0) = 1,'*','') promo from AR_DSR_DETAIL DSD with(nolock)  join ar_dsr DS with(nolock) on DS.id_transaksi = DSD.id_transaksi where DS.ID_TRANSAKSI in (select  AA.link_transaksi from AR_JURNAL AA join AR_JURNAL_DETAIL BB ON AA.ID_JURNAL = BB.ID_JURNAL where AA.JENIS_JURNAL = A.JENIS_JURNAL and BB.KODE_PERKIRAAN = b.KODE_PERKIRAAN and BB.KETERANGAN = b.KETERANGAN and AA.TGL_PENGAKUAN = DS.TGL_PENGAKUAN) and PROMO_BMB_UMKM = 1),'') PROMO,1 as urutanSorting from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'   " & filterjurnal & " " & filtertransaksi & " ) A
	 ) A   )A ) A  ) A  )A )A ")
            ElseIf ComboBoxEdit2.SelectedIndex = 0 Then
                Report.DataSource = SelectCon.execute("select  JENIS_JURNAL+cast(TGL_PENGAKUAN as varchar) PARAM_SR,
JENIS_JURNAL,pt,TGL_PENGAKUAN,TGL_VALUTA,KODE_PERKIRAAN,KETERANGAN,DEBET,KREDIT,urutandsr,urutanjurnal,urutansort,PROMO,pageNum,DEBET_PER_PAGE,KREDIT_PER_PAGE,sum(prev_value) 
over (partition by jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_debet,sum(prev_value_kredit) over (partition by 
jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_kredit,status_next from (select *,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(debet_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(kredit_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value_kredit,iif( lead(isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),1,0) over (order by isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),pageNum) <> isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),'next','curr') status_next from (select *,sum(debet) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) DEBET_PER_PAGE,sum(KREDIT) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) KREDIT_PER_PAGE from (select distinct top 2147483647 *, cast(" & filtercountpage & " as bigint) + 1 as pageNum from (select *, Row_Number() OVER (partition by A.JENIS_JURNAL,A.TGL_PENGAKUAN ORDER BY A.JENIS_JURNAL,A.UrutanSorting ASC,a.link_transaksi asc,kredit asc,kode_perkiraan asc)     as rowNum  from (select distinct top 2147483647 a.JENIS_JURNAL,A.PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,A.KODE_PERKIRAAN,A.KETERANGAN,A.DEBET,A.KREDIT KREDIT,A.URUTANDSR,A.URUTANJURNAL,A.urutansort,a.PROMO,a.urutanSorting,link_transaksi from (select  * from (select  top 2147483647  case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat' when A.JENIS_JURNAL IN (select distinct KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select distinct  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
	union
	select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI  where a.no_pelunasan_retur = link_transaksi
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,b.KODE_PERKIRAAN,B.KETERANGAN,B.DEBET,B.KREDIT,case when b.KETERANGAN like 'PENJ%' then (select 'NO. '+ cast(URUTAN_DSR as varchar) as URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else '' end as urutandsr,link_transaksi,LEFT((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US " & filtertransaksiurutan & " 
    FOR XML PATH('')), LEN((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US   " & filtertransaksiurutan & " 
    FOR XML PATH(''))) - 1) urutanjurnal,case when b.KETERANGAN like 'PENJ%' then (select URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else 999999 end as urutansort,isnull((select distinct iif(isnull(promo_bmb_umkm,0) = 1,'*','') promo from AR_DSR_DETAIL DSD with(nolock)  join ar_dsr DS with(nolock) on DS.id_transaksi = DSD.id_transaksi where DS.ID_TRANSAKSI in (select  AA.link_transaksi from AR_JURNAL AA join AR_JURNAL_DETAIL BB ON AA.ID_JURNAL = BB.ID_JURNAL where AA.JENIS_JURNAL = A.JENIS_JURNAL and BB.KODE_PERKIRAAN = b.KODE_PERKIRAAN and BB.KETERANGAN = b.KETERANGAN and AA.TGL_PENGAKUAN = DS.TGL_PENGAKUAN) and PROMO_BMB_UMKM = 1),'') PROMO,1 as urutanSorting from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'   " & filterjurnal & " " & filtertransaksi & " ) A
	 ) A   )A ) A  ) A  )A )A ")
            Else
                Report.DataSource = SelectCon.execute("select   JENIS_JURNAL+cast(TGL_PENGAKUAN as varchar) PARAM_SR,
JENIS_JURNAL,pt,TGL_PENGAKUAN,TGL_VALUTA,KODE_PERKIRAAN,KETERANGAN,DEBET,KREDIT,urutandsr,urutanjurnal,urutansort,PROMO,pageNum,DEBET_PER_PAGE,KREDIT_PER_PAGE,sum(prev_value) 
over (partition by jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_debet,sum(prev_value_kredit) over (partition by 
jenis_jurnal +cast(TGL_PENGAKUAN as varchar) ORDER BY jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum ROWS UNBOUNDED PRECEDING) prev_value_kredit,status_next from (select  *,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(debet_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum)))prev_value,iif(pageNum = 1,0,iif(lag(pageNum) over 
(order by jenis_jurnal +cast(TGL_PENGAKUAN as varchar),pageNum) = pageNum,0,lag(kredit_per_page,1,0) over (order by jenis_jurnal +cast(TGL_PENGAKUAN as 
varchar),pageNum)))prev_value_kredit,iif( lead(isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),1,0) over (order by isnull(jenis_jurnal 
+cast(TGL_PENGAKUAN as varchar),'-'),pageNum) <> isnull(jenis_jurnal +cast(TGL_PENGAKUAN as varchar),'-'),'next','curr') status_next from (select top 2147483647*,sum(debet) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) DEBET_PER_PAGE,sum(KREDIT) over (partition by JENIS_JURNAL +cast(TGL_PENGAKUAN as varchar),pageNUM) KREDIT_PER_PAGE from (select *, cast((rowNum / 26) as bigint) + 1 as pageNum from (select *, Row_Number() OVER (partition by A.JENIS_JURNAL,A.TGL_PENGAKUAN ORDER BY A.JENIS_JURNAL,A.UrutanSorting ASC,a.urutandb asc,a.id_jurnal asc,a.kode_perkiraan asc)     as rowNum  from (select distinct top 2147483647 a.JENIS_JURNAL,A.PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,A.KODE_PERKIRAAN,A.KETERANGAN,A.DEBET,sum (A.KREDIT) over(partition by a.kode_perkiraan,a.keterangan,a.jenis_jurnal,urutanjurnal) KREDIT,A.URUTANDSR,A.URUTANJURNAL,A.urutansort,a.PROMO,a.urutanSorting,a.urutandb,a.id_jurnal from (select  * from (select  top 2147483647 case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat' when A.JENIS_JURNAL IN (select distinct KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select distinct  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
	union
	select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI  where a.no_pelunasan_retur = link_transaksi
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,b.KODE_PERKIRAAN,B.KETERANGAN,B.DEBET,B.KREDIT,case when b.KETERANGAN like 'PENJ%' then (select 'NO. '+ cast(URUTAN_DSR as varchar) as URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else '' end as urutandsr,LEFT((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US  " & filtertransaksiurutan & " 
    FOR XML PATH('')), LEN((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US  " & filtertransaksiurutan & " 
    FOR XML PATH(''))) - 1) urutanjurnal,case when b.KETERANGAN like 'PENJ%' then (select URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else 999999 end as urutansort,isnull((select distinct iif(isnull(promo_bmb_umkm,0) = 1,'*','') promo from AR_DSR_DETAIL DSD with(nolock)  join ar_dsr DS with(nolock) on DS.id_transaksi = DSD.id_transaksi where DS.ID_TRANSAKSI in (select  AA.link_transaksi from AR_JURNAL AA join AR_JURNAL_DETAIL BB ON AA.ID_JURNAL = BB.ID_JURNAL where AA.JENIS_JURNAL = A.JENIS_JURNAL and BB.KODE_PERKIRAAN = b.KODE_PERKIRAAN and BB.KETERANGAN = b.KETERANGAN and AA.TGL_PENGAKUAN = DS.TGL_PENGAKUAN) and PROMO_BMB_UMKM = 1),'') PROMO,1 as urutanSorting,b.urutan urutandb,a.id_jurnal from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "' and debet <>0 " & filterjurnal & " " & filtertransaksi & " order by urutandb asc,a.id_jurnal asc) A
	union all
	select distinct a.JENIS_JURNAL,pt,TGL_PENGAKUAN,TGL_VALUTA,KODE_PERKIRAAN,KETERANGAN,A.DEBET,sum(A.KREDIT) over (partition by A.keterangan,A.kode_perkiraan, A.JENIS_JURNAL,urutanjurnal) KREDIT,urutandsr,urutanjurnal,urutansort,promo,urutanSorting,a.urutandb,iif(a.keterangan like 'LAP. PENJUALAN%','',a.id_jurnal) id_jurnal from (select top 2147483647 case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat'  when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat' when A.JENIS_JURNAL IN (select distinct KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select distinct  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
	union
	select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI  where a.no_pelunasan_retur = link_transaksi
        union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
	)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,A.TGL_VALUTA,b.KODE_PERKIRAAN,B.KETERANGAN,B.DEBET,B.KREDIT,case when b.KETERANGAN like 'PENJ%' then (select 'NO. '+ cast(URUTAN_DSR as varchar) as URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else '' end as urutandsr,LEFT((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US  " & filtertransaksiurutan & " 
    FOR XML PATH('')), LEN((SELECT distinct cast(US.URUTAN_PROSES_JURNAL as varchar) + ',' 
    FROM AR_PROSES_JURNAL US  " & filtertransaksiurutan & " 
    FOR XML PATH(''))) - 1) urutanjurnal,case when b.KETERANGAN like 'PENJ%' then (select URUTAN_DSR from AR_DSR where ID_TRANSAKSI = a.LINK_TRANSAKSI) else 999999 end as urutansort,isnull((select distinct iif(isnull(promo_bmb_umkm,0) = 1,'*','') promo from AR_DSR_DETAIL DSD with(nolock)  join ar_dsr DS with(nolock) on DS.id_transaksi = DSD.id_transaksi where DS.ID_TRANSAKSI in (select  AA.link_transaksi from AR_JURNAL AA join AR_JURNAL_DETAIL BB ON AA.ID_JURNAL = BB.ID_JURNAL where AA.JENIS_JURNAL = A.JENIS_JURNAL and BB.KODE_PERKIRAAN = b.KODE_PERKIRAAN and BB.KETERANGAN = b.KETERANGAN and AA.TGL_PENGAKUAN = DS.TGL_PENGAKUAN) and PROMO_BMB_UMKM = 1),'') PROMO,2 as urutanSorting,iif(b.keterangan like 'LAP. PENJUALAN MASPION%',5,b.urutan) urutandb,a.ID_JURNAL from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "' and kredit <>0  " & filterjurnal & " " & filtertransaksi & " order by urutandb asc,a.id_jurnal asc) A  ) A )A ) A  ) A )A   )A ")

            End If

        Else
            Report.DataSource = SelectCon.execute("select a.JENIS_JURNAL,a.KODE_PERKIRAAN,a.NAMA_PERKIRAAN,a.TGL_PENGAKUAN,sum(a.DEBET) DEBET,sum(a.KREDIT) KREDIT from (select case when A.JENIS_JURNAL = 'Perwakilan' then 'PERWAKILAN MASPION JAKARTA' when A.JENIS_JURNAL = 'UCF' then 'U.C.F (UNIT CENTRAL FUND)'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and (select top 1 BAGIAN from NOTA join AR_DSR_DETAIL on nota.ID_TRANSAKSI = AR_DSR_DETAIL.ID_NOTA where AR_DSR_DETAIL.ID_TRANSAKSI = a.LINK_TRANSAKSI) like 'Supermarket%' then 'Kantor Pusat' when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select ID_TRANSAKSI FROM AR_LAP_RETUR_PEMBELIAN) then 'Kantor Pusat' when A.JENIS_JURNAL = '03' and a.LINK_TRANSAKSI in (select NO_PELUNASAN_RETUR FROM AR_PELUNASAN_RETUR) and A.KETERANGAN_INTERNAL = 'Jurnal Transaksi' then 'Kantor Pusat'  when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL = '03' then (select  C.NAMA from LINK_PT_SBU a join LINK_SBU_DIVISI B ON A.KODE_SBU = B.KODE_SBU join SBU C ON C.KODE = A.KODE_SBU where KODE_PT = '03' and B.KODE_DIVISI = (select distinct AR.DIVISI from AR_DSR AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_DSR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PEMBELIAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct AR.DIVISI from AR_LAP_RETUR_PENJUALAN AR where ID_TRANSAKSI = LINK_TRANSAKSI
	union
	select distinct DO.DIVISI from AR_PEMBAYARAN_KONTAN AR join DELIVERY_ORDER DO ON Do.ID_TRANSAKSI = ar.ID_DO_KONTAN where NO_PEMBAYARAN = LINK_TRANSAKSI
    union
    select distinct do.DIVISI from AR_PEMBAYARAN_KONTAN ar join delivery_order DO on DO.ID_TRANSAKSI = ar.ID_DO_KONTAN where ar.NO_PEMBAYARAN = link_transaksi	
    union	
    select distinct ar.divisi from ar_pelunasan_retur a join retur_pusat ar on a.id_retur_pusat = ar.ID_TRANSAKSI where a.no_pelunasan_retur = link_transaksi)) when A.JENIS_JURNAL IN (select KODE FROM PT WITH(NOLOCK)) and A.JENIS_JURNAL <> '03' then c.nama end as JENIS_JURNAL,c.nama PT,A.TGL_PENGAKUAN,b.KODE_PERKIRAAN,D.NAMA_PERKIRAAN,B.DEBET DEBET, B.KREDIT  from ar_jurnal a join ar_jurnal_detail b on a.ID_JURNAL = b.ID_JURNAL left join PT C ON C.KODE  = A.JENIS_JURNAL join AR_KODE_PERKIRAAN d on d.KODE_PERKIRAAN = b.KODE_PERKIRAAN  where A.TGL_PENGAKUAN BETWEEN '" & Format(DtTanggalAwal.DateTime, "yyyy-MM-dd") & "' and '" & Format(DtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'  " & filterjurnal & "  " & filtertransaksi & ")A group by a.JENIS_JURNAL,a.KODE_PERKIRAAN,a.NAMA_PERKIRAAN,a.TGL_PENGAKUAN  ")
        End If
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Jurnal Detail"
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        DtTanggalAwal.DateTime = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
        RGJenisLaporan.SelectedIndex = 0
        ComboBoxEdit1.SelectedIndex = 0
        ComboBoxEdit2.SelectedIndex = 0
        DtTanggalAkhir.DateTime = Now.Date
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        ReportShowPreview2()
    End Sub
    Sub reporttest()
        'If TxtKodeCustomer.Text = "" Then Exit Sub
        'If TxtNoDO.Text = "" Then Exit Sub
        Dim MyReport = New CetakanLaporanSalesPerDO
        'If RGFilter.SelectedIndex = 0 Then
        '    MyReport.XrLabel46.Text = "Periode : " & Format(DtTanggalAwal.DateTime, "MMMM yyyy")
        'Else
        '    MyReport.XrLabel46.Text = ""
        'End If
        'MyReport.XrLabel12.Text = Format(dttanggalawal.DateTime, "MMMM yyyy")
        'MyReport.XrLabel73.Text = Format(dttanggalawal.DateTime, "MMMM yyyy")
        Dim filterdo As String = ""
        'If RGFilter.SelectedIndex = 1 Then
        '    If TxtNoDO.Text = "" Then Exit Sub
        'End If
        'If TxtNoDO.Text <> "" Then
        '    filterdo = " and A.ID_TRANSAKSI = '" & TxtNoDO.Text & "'"
        'Else
        '    filterdo = ""
        'End If
        Dim filtercustomer As String = ""
        'If TxtKodeCustomer.Text <> "" Then
        '    filtercustomer = "and A.KODE_APPROVE = '" & TxtKodeCustomer.Text & "'"
        'Else
        '    filtercustomer = ""
        'End If
        Dim filterdivisi As String = ""
        'If TxtKodeDivisi.Text <> "" Then
        '    filterdivisi = "and A.DIVISI = '" & TxtKodeDivisi.Text & "'"
        'Else
        '    filterdivisi = ""
        'End If
        Report = MyReport

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

            Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub
End Class
