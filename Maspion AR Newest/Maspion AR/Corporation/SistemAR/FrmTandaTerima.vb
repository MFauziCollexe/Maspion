
Public MustInherit Class FrmTandaTerima
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    'Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
    '    ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, TxtIDTransaksi.Text)
    '    Log.Cetak(Me, TxtIDTransaksi.Text)
    'End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("DO", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Id DSR", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("DSR", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Bruto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Std. Disc", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Add. Disc", TypeCode.Single, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Cash Disc", TypeCode.Single, 30, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Netto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)
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
        dt.Clear()
        AddRow(dt)
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                TxtAlamatKirim.Text = dtCustomer.Rows(0).Item("ALAMAT_KANTOR")
            Else
                TxtNama.Text = ""
                TxtKodeApprove.Text = ""
                TxtAlamatKirim.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Sub Hitung()
        Dim total As Double = 0
        For Each dr As DataRow In dt.Rows
            total += dr("Netto")
        Next
        TxtSubTotal.Value = total
    End Sub

    Private Sub TxtKodeApprove_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeApprove.EditValueChanged

    End Sub
End Class


Public Class InputTandaTerima
    Inherits FrmTandaTerima

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Tanda Terima"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Sub GetDataDSR() Handles TxtIDCustomer.EditValueChanged
        Dim Filter = ""
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(Nota, 6) AS INT)) 'No.',* FROM ( SELECT DISTINCT ID_NOTA AS 'Id Nota', NO_NOTA AS 'Nota',NO_DO AS 'DO', ID_TRANSAKSI AS 'Id DSR', NO_DSR AS 'DSR', BRUTO AS 'Bruto', STD_DISC AS 'Std. Disc', ADD_DISC AS 'Add. Disc', CASH_DISC AS 'Cash Disc', NETTO AS 'Netto' FROM V_AR_D_DSR_T_TT WHERE ID_CUSTOMER='" & TxtIDCustomer.EditValue & "' AND ST=0) A  ORDER BY CAST(RIGHT(Nota, 6) AS INT)")
        LoadData.SetDataDetail(dt, False)
        Hitung()
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_TT FROM AR_TANDA_TERIMA WHERE NO_TT Like 'TT/" & Format(TglPengakuan.EditValue, "yyMM") & "/%' ORDER BY NO_TT DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "TT/" & Format(TglPengakuan.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'TT','') AS INT)),0) AS ID FROM AR_TANDA_TERIMA")
            TxtIDTransaksi.Text = "TT" & CInt(dtGenerate.Rows(0).Item(0)) + 1
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, TxtSubTotal, txtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_TANDA_TERIMA") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id DSR", "DSR", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No."}, "AR_TANDA_TERIMA_DETAIL") = False Then Exit Sub

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditTandaTerima
    Inherits FrmTandaTerima

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Tanda Terima"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_TT, TGL, TGL_PENGAKUAN, ID_CUSTOMER, KETERANGAN FROM AR_TANDA_TERIMA WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, txtKeterangan})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.NO_DO, A.ID_DSR, A.NO_DSR, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_TANDA_TERIMA_DETAIL A WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
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
            If SQLServer.UpdateHeader("TGL, TGL_PENGAKUAN, ID_CUSTOMER, TOTAL, KETERANGAN ,[MDUSER] ,[MDTIME]", {TglTransaksi, TglPengakuan, TxtIDCustomer, TxtSubTotal, txtKeterangan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_TANDA_TERIMA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_TANDA_TERIMA_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id DSR", "DSR", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No."}, "AR_TANDA_TERIMA_DETAIL") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_TANDA_TERIMA_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_TANDA_TERIMA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_TANDA_TERIMA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
