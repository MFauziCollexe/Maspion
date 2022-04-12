
Imports DevExpress.XtraEditors.Controls

Public MustInherit Class FrmUangTitipan
    Protected dt As New DataTable
    Protected dt2 As New DataTable


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
    Dim locationnominaltunai As Point
    Dim locationgiro As Point
    Dim locationtransfer As Point
    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        TxtBiayaTransfer.Value = 0
        TxtUangTitipanPusat.Value = 0
        TxtUangTitipanPerwakilan.Value = 0
        TxtNilaiDebet.Value = 0
        TxtNilaiKredit.Value = 0
        locationgiro = LayoutControlItem34.Location
        locationtransfer = New Point(0, 250)
        locationketerangan = LayoutControlItem17.Location
        locationnominaltunai = LayoutControlItem35.Location
        LayoutControlItem9.Location = locationtransfer
        LayoutControlItem13.Location = locationgiro
        LayoutControlItem17.Location = locationketerangan
        LayoutControlItem44.Location = New Point(417, 179)
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView2.OptionsView.ColumnAutoWidth = False

        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id Retur", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. Retur", TypeCode.String, 80, True,,,, RepoCari, True)
        InitGrid.AddColumnGrid("Total Retur", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc)
        InitGrid.EndInit(TBDO, GridView1, dt)
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id CN / DN", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. CN / DN", TypeCode.String, 80, True,,,, RepoCari2, True)
        InitGrid.AddColumnGrid("Total CN / DN", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.EndInit(GridControl1, GridView2, dt2)
        AddRow(dt)
        AddRow(dt2)
        'GridView1.OptionsView.ColumnAutoWidth = False
        'InitGrid.Clear()
        'InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        'InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        'InitGrid.AddColumnGrid("No. Nota", TypeCode.String, 50, False)
        'InitGrid.AddColumnGrid("No. DO", TypeCode.String, 60, False)
        'InitGrid.AddColumnGrid("Total", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        'InitGrid.EndInit(TBDO, GridView1, dt)

        'With GridView1.Columns.Item("Total").SummaryItem
        '    .DisplayFormat = "{0:n2}"
        '    .FieldName = "Total"
        '    .SummaryType = DevExpress.Data.SummaryItemType.Sum
        'End With
    End Sub


    'CUSTOMER
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIdCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtIdCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeCustomer.Text = ""
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub CKTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles CKTransfer.CheckedChanged
        If CKTransfer.Checked = True Then
            LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem32.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem40.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem41.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem35.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem38.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            'EmptySpaceItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            CKTunai.Checked = False
            CKTunai.Enabled = False
            CKGiro.Enabled = False
            CKGiro.Checked = False
        Else
            LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem32.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'EmptySpaceItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem40.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem41.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtNamaBank.Text = ""
            TxtBankTransfer.Text = ""
            TxtNamaPengirim.Text = ""
            TxtTransferPerwakilan.Value = 0
            TxtTransferPusat.Value = 0
            CKTunai.Enabled = True
            CKGiro.Enabled = True
        End If
    End Sub
    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_UT FROM AR_UANG_TITIPAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_UT DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "UT/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'UT','') AS INT)),0) AS ID FROM AR_UANG_TITIPAN")
            TxtIDTransaksi.Text = "UT" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function
    Private Sub CKTunai_CheckedChanged(sender As Object, e As EventArgs) Handles CKTunai.CheckedChanged
        If CKTunai.Checked = True Then
            CKGiro.Enabled = True
            CKTransfer.Checked = False
            CKTransfer.Enabled = False
            TxtBankTransfer.Text = ""
            TxtNamaPengirim.Text = ""
            TxtBiayaTransfer.Value = 0
            LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem38.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            TxtTunaiPusat.Value = 0
            TxtTunaiPerwakilan.Value = 0
            LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem38.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem13.Location = locationgiro
            If CKGiro.Checked = True Then
                CKTransfer.Enabled = False
            ElseIf CKTunai.Checked = False Then
                CKGiro.Enabled = True
                CKTransfer.Enabled = True
            End If
        End If
    End Sub

    Private Sub CKGiro_CheckedChanged(sender As Object, e As EventArgs) Handles CKGiro.CheckedChanged
        If CKGiro.Checked = True Then
            CKTunai.Enabled = True
            CKTransfer.Checked = False
            CKTransfer.Enabled = False
            TxtBankTransfer.Text = ""
            TxtNamaPengirim.Text = ""
            TxtBiayaTransfer.Value = 0
            LayoutControlItem35.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            TxtGiroPerwakilan.Value = 0
            TxtGiroPusat.Value = 0
            LayoutControlItem9.Location = locationtransfer
            LayoutControlItem35.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            If CKTunai.Checked = True Then
                CKTransfer.Enabled = False
            ElseIf CKTunai.Checked = False Then
                CKTunai.Enabled = True
                CKTransfer.Enabled = True

            End If

        End If
    End Sub
    Dim locationketerangan As Point
    Private Sub CKCustom_CheckedChanged(sender As Object, e As EventArgs) Handles CKCustom.CheckedChanged
        If CKCustom.Checked = True Then
            CKTransfer.Checked = False
            CKTunai.Checked = False
            CKGiro.Checked = False
            CKRetur.Checked = False
            CKCNDN.Checked = False
            Dim pnt As New Point
            pnt.X = 0
            pnt.Y = 108
            'LayoutControlItem22.Location
            LayoutControlItem17.Location = pnt
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem33.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem42.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem44.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem36.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            EmptySpaceItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'EmptySpaceItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlItem17.Location = locationketerangan
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem33.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem42.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem44.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem36.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            EmptySpaceItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'EmptySpaceItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub

    Private Sub TxtKodeCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeCustomer.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from CUSTOMER where ID = '" & TxtIdCustomer.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaCustomer.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        TxtIdCustomer.Text = kode
        Using dtcust = SelectCon.execute("select KODE_APPROVE from customer where ID = '" & kode & "'")
            If dtcust.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtcust.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtSBU_EditValueChanged(sender As Object, e As EventArgs) Handles TxtSBU.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from SBU where KODE = '" & TxtSBU.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaSBU.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtSBU_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtSBU.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.SBU)
        TxtSBU.Text = kode
    End Sub

    Private Sub TxtBankTransfer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtBankTransfer.EditValueChanged
        Using dt = SelectCon.execute("select NAMA_BANK from AR_MASTER_BANK where ID_BANK = '" & TxtBankTransfer.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaBank.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtBankTransfer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtBankTransfer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Master_Bank)
        TxtBankTransfer.Text = kode
    End Sub


    Private Sub BtnKodeAkunDebet_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnKodeAkunDebet.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        BtnKodeAkunDebet.Text = kode
    End Sub

    Private Sub BtnKodeAkunKredit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnKodeAkunKredit.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        BtnKodeAkunKredit.Text = kode
    End Sub

    Private Sub TxtIDBatasan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDBatasan.EditValueChanged
        Using dt = SelectCon.execute("select KODE_BATASAN from AR_KODE_BATASAN where ID = '" & TxtIDBatasan.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtKodeBatasan.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtIDBatasan_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtIDBatasan.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Batasan)
        TxtIDBatasan.Text = kode
    End Sub
    Sub hitung()
        On Error Resume Next
        Dim totalretur As Double = 0
        Dim totalcn As Double = 0
        dt.AcceptChanges()
        dt2.AcceptChanges()
        totalretur = dt.Compute("sum([Total Retur])", "")
        totalcn = dt2.Compute("sum([Total CN / DN])", "")
        TxtUangTitipanPerwakilan.Value = TxtGiroPerwakilan.Value + TxtTunaiPerwakilan.Value + TxtTransferPerwakilan.Value + totalretur + totalcn
        TxtUangTitipanPusat.Value = TxtGiroPusat.Value + TxtTunaiPusat.Value + TxtTransferPusat.Value
    End Sub
    Private Sub TxtGiroPerwakilan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtGiroPerwakilan.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtGiroPusat_EditValueChanged(sender As Object, e As EventArgs) Handles TxtGiroPusat.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtTunaiPerwakilan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTunaiPerwakilan.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtTunaiPusat_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTunaiPusat.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtTransferPerwakilan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTransferPerwakilan.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtTransferPusat_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTransferPusat.EditValueChanged
        hitung()
    End Sub

    Private Sub CKRetur_CheckedChanged(sender As Object, e As EventArgs) Handles CKRetur.CheckedChanged
        If CKRetur.Checked = True Then
            LayoutControlItem43.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            If GridView1.RowCount = 0 Then
                AddRow(dt)

            End If
        Else
            LayoutControlItem43.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            dt.Clear()
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CKCNDN.CheckedChanged
        If CKCNDN.Checked = True Then
            LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            If GridView2.RowCount = 0 Then
                AddRow(dt2)
            End If
        Else
            LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            dt2.Clear()
        End If
    End Sub

    Private Sub RepoCari_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari.ButtonClick
        If TxtKodeCustomer.Text = "" Then
            Exit Sub
        End If
        paramreturcustomer = TxtKodeCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.Retur_Penjualan)
        GridView1.GetFocusedDataRow(1) = kode
        If kode <> "" Then
            Using dtget = SelectCon.execute("select DPP+PPN,ID_TRANSAKSI from retur_penjualan where NO_NOTA_RETUR = '" & kode & "'")
                If dtget.Rows.Count > 0 Then
                    GridView1.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView1.GetFocusedDataRow(0) = dtget.Rows(0)(1)

                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub RepoCari_EditValueChanged(sender As Object, e As EventArgs) Handles RepoCari.EditValueChanged

    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("No. Retur")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("No. Retur")
            End If
            hitung()
        End If
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles TBDO.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "No. Retur" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("No. Retur").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("No. Retur")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub RepoCari2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari2.ButtonClick
        If TxtKodeCustomer.Text = "" Then
            Exit Sub
        End If
        paramcndncustomer = TxtKodeCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.CN_DN)
        GridView1.GetFocusedDataRow(1) = kode
        If kode <> "" Then
            Using dtget = SelectCon.execute("select JUMLAH,ID_TRANSAKSI from DEBIT_KREDIT_NOTE where NO_TRANSAKSI = '" & kode & "' and JENIS = 'Kredit'")
                If dtget.Rows.Count > 0 Then

                    GridView2.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView2.GetFocusedDataRow(0) = dtget.Rows(0)(1)
                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub GridView2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView2.KeyUp
        If e.KeyCode = 46 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.FocusedColumn = GridView2.Columns(0)
            If GridView2.RowCount = 0 Then
                AddRow(dt)
                GridView2.FocusedColumn = GridView2.Columns(0)
            End If
            hitung()
        End If
    End Sub

    Private Sub GridControl1_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView2.FocusedColumn.FieldName = "No. CN / DN" Then
                    If GridView2.FocusedRowHandle = GridView2.RowCount - 1 Then
                        If Len(GridView2.GetFocusedRow("No. CN / DN").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView2.FocusedColumn = GridView2.Columns("No. CN / DN")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub TglTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles TglTransaksi.EditValueChanged

    End Sub

    Private Sub TBDO_Click(sender As Object, e As EventArgs) Handles TBDO.Click

    End Sub
End Class


Public Class InputUangTitipan
    Inherits FrmUangTitipan
    Private Sub TglTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles TglTransaksi.EditValueChanged
        'If TglTransaksi.EditValue IsNot Nothing Then
        '    Generate()
        'End If

    End Sub
    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Uang Titipan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
        TxtBiayaTransfer.Value = 0
        TxtUangTitipanPusat.Value = 0
        TxtUangTitipanPerwakilan.Value = 0
    End Sub


    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        If CKTransfer.Checked = False Then
            Using dtGenerate = SelectCon.execute("SELECT NO_UT FROM AR_UANG_TITIPAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " and isnull(STATUS_TRANSFER,0) = 0 ORDER BY NO_UT DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "UT/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
            End Using
        Else
            Using dtGenerate = SelectCon.execute("SELECT NO_UT FROM AR_UANG_TITIPAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " and isnull(STATUS_TRANSFER,0) = 1 ORDER BY NO_UT DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
            End Using
            TxtNoTransaksi.Text = "UT/KU/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End If
        If CKTransfer.Checked = True Then
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(REPLACE(ID_TRANSAKSI,'UTKU',''),'UT','') AS INT)),0) AS ID FROM AR_UANG_TITIPAN")
                TxtIDTransaksi.Text = "UTKU" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using

        Else
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(REPLACE(ID_TRANSAKSI,'UTKU',''),'UT','') AS INT)),0) AS ID FROM AR_UANG_TITIPAN")
                TxtIDTransaksi.Text = "UT" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using

        End If
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtKodeCustomer}) Then Exit Sub
        '    GridView1.CloseEditor()
        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIdCustomer, TxtUangTitipanPusat, TxtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, CKTunai, CKTransfer, CKGiro, TxtUangTitipanPerwakilan, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtSBU, CKCustom, TxtNilaiDebet, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiKredit, BtnKodeAkunKredit, TxtKeteranganKredit, TxtTunaiPerwakilan, TxtTunaiPusat, TxtTransferPerwakilan, TxtTransferPusat, TxtGiroPerwakilan, TxtGiroPusat, TxtKodeBatasan, CKRetur, CKCNDN}, "AR_UANG_TITIPAN") = False Then Exit Sub
            'Detail
            If dt.Rows.Count > 0 Or dt2.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(dt.Rows.Count - 1)("No. Retur") = "" Then
                        dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    End If
                End If
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows(dt2.Rows.Count - 1)("No. CN / DN") = "" Then
                        dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
                    End If
                End If

                dt.AcceptChanges()
                dt2.AcceptChanges()
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Retur", "No. Retur", "Total Retur"}, "AR_UANG_TITIPAN_DETAIL_RETUR") = False Then Exit Sub
                If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id CN / DN", "No. CN / DN", "Total CN / DN"}, "AR_UANG_TITIPAN_DETAIL_CNDN") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditUangTitipan
    Inherits FrmUangTitipan

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtBiayaTransfer.Value = 0
        TxtUangTitipanPusat.Value = 0
        TxtUangTitipanPerwakilan.Value = 0
        Text = "Edit Uang Titipan"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_UT,  TGL, ID_CUSTOMER, NOMINAL_PERWAKILAN,NOMINAL_PUSAT, KETERANGAN,STATUS_TUNAI,STATUS_TRANSFER,STATUS_GIRO,STATUS_CUSTOM,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER,SBU,DEBET_NILAI,DEBET_KODE_AKUN,DEBET_KETERANGAN,KREDIT_NILAI,KREDIT_KODE_AKUN,KREDIT_KETERANGAN,NOMINAL_TUNAI_PERWAKILAN,NOMINAL_TUNAI_PUSAT,NOMINAL_TRANSFER_PERWAKILAN,NOMINAL_TRANSFER_PUSAT,NOMINAL_GIRO_PERWAKILAN,NOMINAL_GIRO_PUSAT,KODE_BATASAN,STATUS_RETUR,STATUS_CNDN FROM AR_UANG_TITIPAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdCustomer, TxtUangTitipanPerwakilan, TxtUangTitipanPusat, TxtKeterangan, CKTunai, CKTransfer, CKGiro, CKCustom, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtSBU, TxtNilaiDebet, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiKredit, BtnKodeAkunKredit, TxtKeteranganKredit, TxtTunaiPerwakilan, TxtTunaiPusat, TxtTransferPerwakilan, TxtTransferPusat, TxtGiroPerwakilan, TxtGiroPusat, TxtKodeBatasan, CKRetur, CKCNDN})
        LoadData.GetData("select ID_RETUR,NO_RETUR,NOMINAL from AR_UANG_TITIPAN_DETAIL_RETUR where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt, False)
        LoadData.GetData("select ID_CNDN,NO_CNDN,NOMINAL from AR_UANG_TITIPAN_DETAIL_CNDN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt2, False)
        hitung()
        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeCustomer}) Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        If dt.Rows.Count > 0 Then
            If dt.Rows(dt.Rows.Count - 1)("No. Retur") = "" Then
                dt.Rows.RemoveAt(dt.Rows.Count - 1)
            End If
        End If
        If dt2.Rows.Count > 0 Then
            If dt2.Rows(dt2.Rows.Count - 1)("No. CN / DN") = "" Then
                dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
            End If
        End If
        dt.AcceptChanges()
        dt2.AcceptChanges()
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL,ID_CUSTOMER, NOMINAL_PERWAKILAN,NOMINAL_PUSAT, STATUS_TRANSFER,STATUS_TUNAI,STATUS_GIRO,STATUS_CUSTOM,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER,SBU,DEBET_NILAI,DEBET_KODE_AKUN,DEBET_KETERANGAN,KREDIT_NILAI,KREDIT_KODE_AKUN,KREDIT_KETERANGAN, KETERANGAN,NOMINAL_TUNAI_PERWAKILAN,NOMINAL_TUNAI_PUSAT,NOMINAL_TRANSFER_PERWAKILAN,NOMINAL_TRANSFER_PUSAT,NOMINAL_GIRO_PERWAKILAN,NOMINAL_GIRO_PUSAT,KODE_BATASAN,STATUS_RETUR,STATUS_CNDN ,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtIdCustomer, TxtUangTitipanPerwakilan, TxtUangTitipanPusat, CKTransfer, CKTunai, CKGiro, CKCustom, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtSBU, TxtNilaiDebet, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiKredit, BtnKodeAkunKredit, TxtKeteranganKredit, TxtKeterangan, TxtTunaiPerwakilan, TxtTunaiPusat, TxtTransferPerwakilan, TxtTransferPusat, TxtGiroPerwakilan, TxtGiroPusat, TxtKodeBatasan, CKRetur, CKCNDN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_UANG_TITIPAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_UANG_TITIPAN_DETAIL_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_UANG_TITIPAN_DETAIL_CNDN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If dt.Rows.Count > 0 Or dt2.Rows.Count > 0 Then
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Retur", "No. Retur", "Total Retur"}, "AR_UANG_TITIPAN_DETAIL_RETUR") = False Then Exit Sub
                If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id CN / DN", "No. CN / DN", "Total CN / DN"}, "AR_UANG_TITIPAN_DETAIL_CNDN") = False Then Exit Sub

            End If

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_UANG_TITIPAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_UANG_TITIPAN_DETAIL_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_UANG_TITIPAN_DETAIL_CNDN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_UANG_TITIPAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
