Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanRekapOmsetPembayaranCorporate
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPeriode2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label

    Private Sub InitializeComponent()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNamaCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPeriode2 = New DevExpress.XtraEditors.DateEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.DTPeriode2)
        Me.XtraScrollableControl1.Controls.Add(Me.Label2)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtNamaCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeCustomer)
        Me.XtraScrollableControl1.Controls.Add(Me.Label1)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label1, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtNamaCustomer, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label2, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DTPeriode2, 0)
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(93, 147)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(275, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(215, 84)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(153, 20)
        Me.TxtDivisi.TabIndex = 251
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(93, 84)
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(116, 20)
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
        Me.DTPeriode.Size = New System.Drawing.Size(115, 20)
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
        'TxtNamaCustomer
        '
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(215, 110)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(153, 20)
        Me.TxtNamaCustomer.TabIndex = 256
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(94, 110)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Properties.ReadOnly = True
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(114, 20)
        Me.TxtKodeCustomer.TabIndex = 258
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Corporate :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "s/d"
        '
        'DTPeriode2
        '
        Me.DTPeriode2.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DTPeriode2.Location = New System.Drawing.Point(238, 58)
        Me.DTPeriode2.Name = "DTPeriode2"
        Me.DTPeriode2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode2.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode2.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode2.Properties.EditValueChangedDelay = 3
        Me.DTPeriode2.Size = New System.Drawing.Size(130, 20)
        Me.DTPeriode2.TabIndex = 260
        '
        'LaporanRekapOmsetPembayaranCorporate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanRekapOmsetPembayaranCorporate"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim filterdivisi As String
        Dim filtercustomer As String
        If TxtKodeDivisi.Text <> "" Then
            filterdivisi = "and A.DIVISI = '" & TxtKodeDivisi.Text & "'"
        Else
            filterdivisi = ""
        End If
        If TxtKodeCustomer.Text <> "" Then
            filtercustomer = "and E.KODE = '" & TxtKodeCustomer.Text & "' "
        Else
            filtercustomer = ""
        End If
        Dim tempdate As DateTime = DTPeriode.DateTime
        Dim tempdate2 As DateTime = DTPeriode2.DateTime
        Dim dateakhir As DateTime
        Dim dateawal As DateTime
        dateakhir = New DateTime(tempdate2.Year, tempdate2.Month, 1).AddMonths(1).AddDays(-1)
        dateawal = New DateTime(tempdate.Year, tempdate.Month, 1)

        Dim MyReport = New CetakanRekapOmsetPembayaranCorporate
        Report = MyReport
        MyReport.XrLabel2.Text = "Periode " & Format(DTPeriode.DateTime, "MMMM yyyy") & " s/d " & Format(DTPeriode2.DateTime, "MMMM yyyy")

        Report.DataSource = SelectCon.execute("select A.KODE_APPROVE,A.DIVISI,A.NAMA_DIVISI,sum(NILAI)NILAI,BLN,BLN1,KODE_CORP,NAMA_CORP from(select A.KODE_APPROVE,format(F.TGL,'MM') BLN1,A.DIVISI,C.NAMA NAMA_DIVISI,sum(F.TOTAL) over (partition by A.KODE_APPROVE,A.DIVISI)  NILAI,format(F.TGL,'MMM') BLN,E.KODE KODE_CORP,E.NAMA NAMA_CORP from DELIVERY_ORDER A join customer B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID join DIVISI c on c.KODE = a.DIVISI  join LINK_CORPORATION_CUSTOMER d with(Nolock) on d.ID_CUSTOMER = b.ID  join CORPORATION e with(Nolock) on e.KODE = d.KODE_CORPORATION left join AR_PEMBAYARAN_KONTAN F with(nolock) on a.ID_TRANSAKSI = F.ID_DO_KONTAN  where  PEMBAYARAN = 'Kontan' and A.BATAL = 0 and F.TGL BETWEEN '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "' " & filterdivisi & " " & filtercustomer & ")A group by A.KODE_APPROVE,A.DIVISI,A.NAMA_DIVISI,BLN,BLN1,KODE_CORP,NAMA_CORP order by BLN1")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Rekap Omset Pembayaran Corporate"
        DTPeriode.DateTime = Now.Date
        DTPeriode2.DateTime = Now.Date
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
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

    Private Sub TxtKodeCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeCustomer.EditValueChanged
        Using dtdivisi = SelectCon.execute("SELECT NAMA FROM CORPORATION WHERE KODE='" & TxtKodeCustomer.Text & "'")
            If dtdivisi.Rows.Count > 0 Then
                TxtNamaCustomer.Text = dtdivisi.Rows(0)(0)
            Else
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Corporate)
        TxtKodeCustomer.Text = kode
    End Sub
End Class
