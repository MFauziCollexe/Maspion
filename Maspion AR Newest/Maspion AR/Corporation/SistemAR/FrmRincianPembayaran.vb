
Public MustInherit Class FrmRincianPembayaran
    Protected dt As New DataTable
    Protected dt2 As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean

    Private Sub FrmRincianPembayaran_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            dt2.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    'Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
    '    ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, TxtIDTransaksi.Text)
    '    Log.Cetak(Me, TxtIDTransaksi.Text)
    'End Sub

    Private Sub FrmRincianPembayaran_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F6
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F7
                _Toolbar1_Button5.PerformClick()
            Case System.Windows.Forms.Keys.F8
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub FrmRincianPembayaran_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        'rincian1
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id DO", TypeCode.String, 50, False,,,,, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 50, False,,,,, False)
        InitGrid.AddColumnGrid("DO/Nota", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Tgl", TypeCode.DateTime, 40, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Debet", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Kredit", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBRincian1, GridView1, dt)

        'rincian2
        GridView2.OptionsView.ColumnAutoWidth = False
        InitGrid2.Clear()
        InitGrid2.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid2.AddColumnGrid("Id Nota", TypeCode.String, 50, False,,,,, False)
        InitGrid2.AddColumnGrid("BPU/BPK", TypeCode.String, 60, False)
        InitGrid2.AddColumnGrid("Tgl", TypeCode.DateTime, 40, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid2.AddColumnGrid("Debet", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid2.AddColumnGrid("Kredit", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid2.EndInit(TBRincian2, GridView2, dt2)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    'Customer
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        TxtIDCustomer.Text = kode
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then
            Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
            TxtIDCustomer.Text = kode
        End If
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged

        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WITH (NOLOCK) WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                'TxtAlamatKirim.Text = dtCustomer.Rows(0).Item("ALAMAT_KANTOR")
            Else
                TxtNama.Text = ""
                TxtKodeApprove.Text = ""
                'TxtAlamatKirim.Text = ""
            End If
        End Using




    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Sub Hitung()
        Dim totalD As Double = 0
        Dim totalK As Double = 0
        For Each dr As DataRow In dt.Rows
            totalD += dr("Debet")
            totalK += dr("kREDIT")
        Next
        txtSelisih1.Value = totalD - totalK

        Dim totalD2 As Double = 0
        Dim totalK2 As Double = 0
        For Each dr As DataRow In dt2.Rows
            totalD2 += dr("Debet")
            totalK2 += dr("kREDIT")
        Next
        txtSelisih2.Value = totalD2 - totalK2
    End Sub


End Class


Public Class InputRincianPembayaran
    Inherits FrmRincianPembayaran

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Rincian Pembayaran"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Sub GetDataDSR() Handles TxtIDCustomer.EditValueChanged
        Dim Filter = ""
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY A.ID_DO) [No.],A.ID_DO,A.NOTA,A.NO_TRANSAKSI,A.TGL,A.DEBET,A.KREDIT FROM (
SELECT A.TGL,A.KODE_CUSTOMER,A.KODE_APPROVE,A.ID_TRANSAKSI AS ID_DO,'' AS NOTA,A.NO_DO AS NO_TRANSAKSI,A.DPP+A.PPN AS DEBET,0 AS KREDIT 
FROM DELIVERY_ORDER A LEFT JOIN MONITORING_PAYMENT B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI WHERE B.TAGIHAN>=B.BAYAR AND A.JENIS_DO='Tanpa Barang'
UNION 
SELECT A.TGL,A.KODE_CUSTOMER,A.KODE_APPROVE,B.ID_DO,A.ID_TRANSAKSI AS NOTA,A.NO_NOTA AS NO_TRANSAKSI,0 AS DEBET, A.DPP+A.PPN AS KREDIT 
FROM NOTA A INNER JOIN BON_PESANAN B ON A.ID_DO=B.ID_TRANSAKSI ) A WHERE A.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ")
        LoadData.SetDataDetail(dt, False)

        LoadData.GetData("SELECT  ROW_NUMBER() OVER (ORDER BY A.INISIAL) [No.],A.ID_TRANSAKSI,A.BPU_BPK,A.TGL,A.DEBET,A.KREDIT FROM (
select 'A' AS INISIAL, A.KODE_CUSTOMER,A.KODE_APPROVE,A.ID_TRANSAKSI,A.NO_PENGEMBALIAN AS BPU_BPK,A.TGL,SUM(B.TOTAL)-SUM(B.NILAI) AS DEBET,0 AS KREDIT 
from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN A LEFT JOIN AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI
GROUP BY A.KODE_CUSTOMER,A.KODE_APPROVE,A.NO_PENGEMBALIAN,A.TGL,A.ID_TRANSAKSI
UNION ALL
select 'B' AS INISIAL, A.KODE_CUSTOMER,A.KODE_APPROVE,A.ID_TRANSAKSI,A.NO_KEKURANGAN AS BPU_BPK,A.TGL,0 AS DEBET,SUM(B.NILAI)-SUM(B.TOTAL) AS KREDIT
from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN A LEFT JOIN AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI
GROUP BY A.KODE_CUSTOMER,A.KODE_APPROVE,A.NO_KEKURANGAN,A.TGL,A.ID_TRANSAKSI
) A WHERE A.KODE_CUSTOMER='" & TxtIDCustomer.Text & "' ")
        LoadData.SetDataDetail(dt2, False)
        Hitung()
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)

        dt2.Clear()
        AddRow(dt2)
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_RINCIAN_PEMBAYARAN FROM AR_RINCIAN_PEMBAYARAN WHERE NO_RINCIAN_PEMBAYARAN Like 'RP/" & Format(TglPengakuan.EditValue, "yyMM") & "/%' ORDER BY NO_RINCIAN_PEMBAYARAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "RP/" & Format(TglPengakuan.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'RP','') AS INT)),0) AS ID FROM AR_RINCIAN_PEMBAYARAN")
            TxtIDTransaksi.Text = "RP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtKodeApprove, TglPengakuan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, txtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_RINCIAN_PEMBAYARAN") = False Then Exit Sub
            'Detail1
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id DO", "Id Nota", "DO/Nota", "TGL", "Debet", "Kredit", "No."}, "AR_RINCIAN_PEMBAYARAN_DETAIL1") = False Then Exit Sub
            'Detail2
            If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "BPU/BPK", "TGL", "Debet", "Kredit", "No."}, "AR_RINCIAN_PEMBAYARAN_DETAIL2") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditRincianPembayaran
    Inherits FrmRincianPembayaran

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Tanda Terima"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        Dim TempNoTransaksi As String = Nothing
        TempNoTransaksi = TxtIDTransaksi.Text

        LoadData.GetData("SELECT NO_RINCIAN_PEMBAYARAN, TGL, TGL_PENGAKUAN, ID_CUSTOMER, KETERANGAN FROM AR_RINCIAN_PEMBAYARAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, txtKeterangan})

        LoadData.GetData("SELECT A.URUTAN, A.ID_DO, A.ID_NOTA, A.NO_NOTA, A.TGL,A.DEBET, A.KREDIT FROM AR_RINCIAN_PEMBAYARAN_DETAIL1 A WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.BPU_BPK, A.TGL,A.DEBET, A.KREDIT FROM AR_RINCIAN_PEMBAYARAN_DETAIL2 A WHERE A.ID_TRANSAKSI='" & TempNoTransaksi & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt2, False)
        Hitung()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeApprove}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL, TGL_PENGAKUAN, ID_CUSTOMER, KETERANGAN ,[MDUSER] ,[MDTIME]", {TglTransaksi, TglPengakuan, TxtIDCustomer, txtKeterangan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_RINCIAN_PEMBAYARAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_RINCIAN_PEMBAYARAN_DETAIL1", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_RINCIAN_PEMBAYARAN_DETAIL2", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id DSR", "DSR", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No."}, "AR_TANDA_TERIMA_DETAIL") = False Then Exit Sub
            If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "BPU/BPK", "TGL", "Debet", "Kredit", "No."}, "AR_RINCIAN_PEMBAYARAN_DETAIL2") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'If SQLServer.Delete("AR_TANDA_TERIMA_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'If SQLServer.Delete("AR_TANDA_TERIMA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_RINCIAN_PEMBAYARAN_DETAIL1", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_RINCIAN_PEMBAYARAN_DETAIL2", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_RINCIAN_PEMBAYARAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_RINCIAN_PEMBAYARAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
