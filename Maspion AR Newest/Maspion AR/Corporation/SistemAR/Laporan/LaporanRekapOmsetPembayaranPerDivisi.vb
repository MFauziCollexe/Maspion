Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanRekapOmsetPembayaranPerDivisi
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label

    Private Sub InitializeComponent()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
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
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(92, 120)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 244
        Me.BtnView.Text = "View"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(189, 84)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(131, 20)
        Me.TxtDivisi.TabIndex = 251
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(93, 84)
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
        'LaporanRekapOmsetPembayaranPerDivisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanRekapOmsetPembayaranPerDivisi"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ReportShowPreview()
        Dim filterdivisi As String
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

        Dim MyReport = New CetakanRekapOmsetPembayaranPerDivisi
        Report = MyReport
        MyReport.XrLabel2.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Report.DataSource = SelectCon.execute("select distinct A.DIVISI,C.NAMA NAMA_DIVISI,left(A.KODE_APPROVE,3) KODE_INISIAL,A.KODE_APPROVE,D.NAMA CUSTOMER,format((B.tgl),'MMM') BLN,sum(B.TOTAL) over (partition by A.KODE_APPROVE,A.DIVISI) TOTAL  from delivery_order a left join AR_PEMBAYARAN_KONTAN b with(nolock) on a.ID_TRANSAKSI = b.ID_DO_KONTAN join DIVISI C with(nolock) ON C.KODE = A.DIVISI left join customer d with(nolock) on d.kode_approve = a.kode_approve and a.kode_customer = d.ID where  A.PEMBAYARAN = 'KONTAN' and B.tgl between '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "'" & filterdivisi & " ")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Rekap Omset Pembayaran Per Divisi"
        DTPeriode.DateTime = Now.Date
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
End Class
