Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanKartuPiutang
    Inherits FrmLaporanBase
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKodeCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNamaCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Controls.Add(Me.DTPeriode)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DTPeriode, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCustomer, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Periode :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(93, 130)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
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
        Me.DTPeriode.TabIndex = 112
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Customer :"
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(93, 91)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Properties.ReadOnly = True
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(90, 20)
        Me.TxtKodeCustomer.TabIndex = 245
        '
        'TxtNamaCustomer
        '
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(190, 91)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(131, 20)
        Me.TxtNamaCustomer.TabIndex = 246
        '
        'LaporanKartuPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanKartuPiutang"
        Me.Text = "Laporan Kartu Piutang"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        If TxtKodeCustomer.Text = "" Then Exit Sub
        Dim MyReport = New CetakanKartuPiutang
        MyReport.XrLabel12.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        MyReport.XrLabel73.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Report = MyReport
        Report.DataSource = SelectCon.execute("select iif(A.jenis = 'Penjualan',right(A.KETERANGAN,6) + ' ' + isnull(right(DSR.NO_PERWAKILAN,6),'') ,a.keterangan)KETERANGAN,A.KODE_CUSTOMER,A.DIVISI,A.tgl,A.debet,a.kredit,a.Jenis,a.COUNT_NOTA,isnull(C.SALDOAWAL,'0')SALDOAWAL,B.NAMA CUSTOMER,B.ALAMAT_KANTOR,b.LIMIT_PIUTANG,(select iif(right(collector,1) = ',',stuff(collector,len(collector),1,''),collector)collector from (
select (SELECT us.NAMA_USER + ',' 
    FROM users US where us.ID_USER = a.COLLECTOR
    FOR XML PATH('')) as collector from AR_PENYERAHAN_NOTA a left join AR_PENYERAHAN_NOTA_DETAIL b on a.ID_TRANSAKSI = b.ID_TRANSAKSI where b.ID_NOTA = '' ) A) Kolektor from (select 'Saldo Awal' Keterangan, a.KODE_CUSTOMER,'' DIVISI,'' tgl,sum((A.DPP +A.PPN) ) as debet,0 as kredit,sum((A.DPP +A.PPN) ) as SALDOAWAL,null Jenis from nota a with(nolock) where A.TGL_PENGAKUAN < '" & Format(DTPeriode.DateTime, "yyyy/MM/dd") & "' group by a.KODE_CUSTOMER union
select 'Saldo Awal' Keterangan, a.ID,'' DIVISI,'' tgl,0 as debet,0 as kredit,0 as SALDOAWAL,null Jenis from CUSTOMER a with(nolock) where  a.ID ='" & TxtKodeCustomer.Text & "' and iD not in (select a.KODE_CUSTOMER from nota a with(nolock) where A.TGL_PENGAKUAN < '" & Format(DTPeriode.DateTime, "yyyy/MM/dd") & "' and  a.kode_customer ='" & TxtKodeCustomer.Text & "' ))C left join (select a.NO_NOTA KETERANGAN,A.ID_TRANSAKSI,a.KODE_CUSTOMER, B.NAMA DIVISI,format(tgl,'dd-MM') tgl,dpp+ppn as debet,NULL as kredit,'1' as Jenis,count(a.NO_NOTA) over(partition by A.KODE_CUSTOMER,B.NAMA) COUNT_NOTA from NOTA A with(nolock) join DIVISI b with(nolock) on a.DIVISI = b.KODE where A.TGL_PENGAKUAN >= '" & Format(DTPeriode.DateTime, "yyyy/MM/dd") & "' and A.TGL_PENGAKUAN < '" & Format(DateAdd(DateInterval.Month, 1, DTPeriode.DateTime), "yyy/MM/dd") & "'
union all
select 'Pembayaran ' + b.NAMA KETERANGAN,A.ID_TRANSAKSI,a.KODE_CUSTOMER, B.NAMA DIVISI,format(c.TGL_PAYMENT,'dd-MM') + ' ' + format(c.TGL_PAYMENT,'dd-MM') tgl,null as debet,dpp+ppn as kredit,'2' as Jenis,count(a.NO_NOTA) over(partition by A.KODE_CUSTOMER,B.NAMA) COUNT_NOTA from  MONITORING_PAYMENT c with(nolock) join NOTA A with(nolock)  on c.ID_TRANSAKSI = a.ID_TRANSAKSI join DIVISI b with(nolock) on a.DIVISI = b.KODE  where   C.TGL_PAYMENT >= '" & Format(DTPeriode.DateTime, "yyyy/MM/dd") & "' and C.TGL_PAYMENT < '" & Format(DateAdd(DateInterval.Month, 1, DTPeriode.DateTime), "yyy/MM/dd") & "'
union all
select 'Discount ' + b.NAMA KETERANGAN,A.ID_TRANSAKSI,a.KODE_CUSTOMER, B.NAMA DIVISI,format( A.TGL_PENGAKUAN,'dd-MM') + ' ' + format( A.TGL_PENGAKUAN,'dd-MM') tgl,null as debet, a.CASH_DISC_NOMINAL + a.DISC_1_NOMINAL + a.DISC_2_NOMINAL + a.DISC_3_NOMINAL + a.DISC_QTY_NOMINAL + a.DISC_REG_NOMINAL as kredit,'2' as Jenis,count(a.NO_NOTA) over(partition by A.KODE_CUSTOMER,B.NAMA) COUNT_NOTA from NOTA A with(nolock) join DIVISI b with(nolock) on a.DIVISI = b.KODE join MONITORING_PAYMENT c with(nolock) on c.ID_TRANSAKSI = a.ID_TRANSAKSI where A.TGL_PENGAKUAN >= '" & Format(DTPeriode.DateTime, "yyyy/MM/dd") & "' and A.TGL_PENGAKUAN < '" & Format(DateAdd(DateInterval.Month, 1, DTPeriode.DateTime), "yyy/MM/dd") & "')A on c.kode_customer = a.kode_customer left join (select isnull(DLC.LIMIT,isnull(CS.LIMIT_PIUTANG,0)) LIMIT_PIUTANG,cs.KODE_APPROVE,cs.ID,cs.NAMA,cs.ALAMAT_KANTOR from CUSTOMER CS with(nolock)  left join LINK_CORPORATION_CUSTOMER LC with(nolock)  on LC.ID_CUSTOMER = CS.ID left join CORPORATION CR with(nolock)  on CR.KODE = LC.KODE_CORPORATION left join (select sum(LIMIT) LIMIT,KODE from DETAIL_CORPORATION_LIMITPIUTANG with(nolock)  group by KODE) DLC on DLC.KODE = cr.KODE) b on C.KODE_CUSTOMER=b.ID left join AR_DSR_DETAIL DSR WITH(NOLOCK) ON DSR.ID_NOTA = A.ID_TRANSAKSI where B.ID ='" & TxtKodeCustomer.Text & "'")
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Kartu Piutang"
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        DTPeriode.DateTime = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
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
End Class
