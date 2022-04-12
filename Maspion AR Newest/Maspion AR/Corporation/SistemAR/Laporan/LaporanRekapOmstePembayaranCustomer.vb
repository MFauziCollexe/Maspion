Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Controls

Public Class LaporanRekapOmstePembayaranCustomer
    Inherits FrmLaporanBase
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNamaCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtKodeApprove As DevExpress.XtraEditors.TextEdit
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
        Me.TxtKodeApprove = New DevExpress.XtraEditors.TextEdit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeApprove)
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
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeApprove, 0)
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
        Me.TxtDivisi.Location = New System.Drawing.Point(153, 84)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(215, 20)
        Me.TxtDivisi.TabIndex = 251
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(93, 84)
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(54, 20)
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
        Me.DTPeriode.Size = New System.Drawing.Size(275, 20)
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
        Me.TxtNamaCustomer.Location = New System.Drawing.Point(256, 110)
        Me.TxtNamaCustomer.Name = "TxtNamaCustomer"
        Me.TxtNamaCustomer.Properties.ReadOnly = True
        Me.TxtNamaCustomer.Size = New System.Drawing.Size(112, 20)
        Me.TxtNamaCustomer.TabIndex = 256
        '
        'TxtKodeCustomer
        '
        Me.TxtKodeCustomer.Location = New System.Drawing.Point(94, 110)
        Me.TxtKodeCustomer.Name = "TxtKodeCustomer"
        Me.TxtKodeCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeCustomer.Properties.ReadOnly = True
        Me.TxtKodeCustomer.Size = New System.Drawing.Size(53, 20)
        Me.TxtKodeCustomer.TabIndex = 258
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Customer :"
        '
        'TxtKodeApprove
        '
        Me.TxtKodeApprove.Location = New System.Drawing.Point(153, 110)
        Me.TxtKodeApprove.Name = "TxtKodeApprove"
        Me.TxtKodeApprove.Properties.ReadOnly = True
        Me.TxtKodeApprove.Size = New System.Drawing.Size(97, 20)
        Me.TxtKodeApprove.TabIndex = 259
        '
        'LaporanRekapOmstePembayaranCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 580)
        Me.Name = "LaporanRekapOmstePembayaranCustomer"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNamaCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeApprove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
            filtercustomer = "and A.KODE_CUSTOMER = '" & TxtKodeCustomer.Text & "' and A.KODE_APPROVE = '" & TxtKodeApprove.Text & "'"
        Else
            filtercustomer = ""
        End If
        Dim tempdate As DateTime = DTPeriode.DateTime
        Dim dateakhir As DateTime
        Dim dateawal As DateTime
        dateakhir = New DateTime(tempdate.Year, tempdate.Month, 1).AddMonths(1).AddDays(-1)
        dateawal = New DateTime(dateakhir.Year, dateakhir.Month, 1)

        Dim MyReport = New CetakanRekapOmsetPembayaranCustomer
        Report = MyReport
        MyReport.XrLabel2.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Report.DataSource = SelectCon.execute("select A.KODE_APPROVE,B.NAMA CUSTOMER,B.ALAMAT_KANTOR,A.DIVISI,C.NAMA NAMA_DIVISI,sum(D.TOTAL) over (partition by A.KODE_APPROVE) NILAI,format(D.TGL,'MM') BLN from DELIVERY_ORDER A left join AR_PEMBAYARAN_KONTAN D with(nolock) on a.ID_TRANSAKSI = D.ID_DO_KONTAN join customer B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID join DIVISI c on c.KODE = a.DIVISI where  PEMBAYARAN = 'Kontan' and A.BATAL = 0 and D.TGL BETWEEN '" & Format(dateawal, "yyyy-MM-dd") & "' and '" & Format(dateakhir, "yyyy-MM-dd") & "' " & filterdivisi & " " & filtercustomer & " ")

        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
    End Sub

    Private Sub LaporanBahan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeComponent()
        Nama = "Laporan Rekap Omset Pembayaran Customer"
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

    Private Sub TxtKodeCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeCustomer.EditValueChanged
        Using dtdivisi = SelectCon.execute("SELECT NAMA,KODE_APPROVE FROM CUSTOMER WHERE ID='" & TxtKodeCustomer.Text & "'")
            If dtdivisi.Rows.Count > 0 Then
                TxtNamaCustomer.Text = dtdivisi.Rows(0)(0)
                TxtKodeApprove.Text = dtdivisi.Rows(0)(1)
            Else
                TxtNamaCustomer.Text = ""
                TxtKodeApprove.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        TxtKodeCustomer.Text = kode
    End Sub
End Class
