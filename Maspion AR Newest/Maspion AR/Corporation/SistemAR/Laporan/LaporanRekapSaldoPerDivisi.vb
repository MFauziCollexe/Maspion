Imports DevExpress.XtraEditors.Controls

Public Class LaporanRekapSaldoPerDivisi
    Inherits FrmLaporanBase
    Private Sub LaporanRekapSaldoPerDivisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
        Nama = "Laporan Rekap Saldo Per Divisi"
        DTPeriode.DateTime = Now.Date
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub ReportShowPreview()
        Dim filterdivisi As String
        If TxtKodeDivisi.Text <> "" Then
            filterdivisi = "where E.DIVISI  = '" & TxtKodeDivisi.Text & "'"
        Else
            filterdivisi = ""
        End If
        Dim tempdate As DateTime = DTPeriode.DateTime
        Dim dateakhir As DateTime
        Dim dateawal As DateTime
        dateakhir = New DateTime(tempdate.Year, tempdate.Month, 1).AddMonths(1).AddDays(-1)
        dateawal = New DateTime(dateakhir.Year, dateakhir.Month, 1)

        Dim MyReport = New CetakanRekapSaldoPerDivisi
        Report = MyReport
        MyReport.XrLabel2.Text = Format(DTPeriode.DateTime, "MMMM yyyy")
        Report.DataSource = SelectCon.execute("select * from F_AR_REKAP_SALDO_DIVISI('" & TxtKodeDivisi.Text & "','" & Format(dateawal, "yyyy-MM-dd") & "','" & Format(dateakhir, "yyyy-MM-dd") & "') where SALDO_AWAL + PEMBAYARAN - PENJUALAN - PEMBATALAN <> 0")
        Report.DataMember = Nothing
        Report.CreateDocument()
        DocumentViewer1.DocumentSource = Report
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

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        ReportShowPreview()
    End Sub
End Class