
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public MustInherit Class FrmCreateDSR
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean

    Enum JenisEnum
        Perwakilan = 1
        Pusat = 2
        Supermarket = 3
    End Enum
    Private _Jenis As JenisEnum
    Public Property Jenis As JenisEnum
        Set(value As JenisEnum)
            _Jenis = value
            If value = JenisEnum.Pusat Then
                LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            If value = JenisEnum.Perwakilan Then
                LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            If value = JenisEnum.Supermarket Then
                LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            End If
        End Set
        Get
            Return _Jenis
        End Get
    End Property

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

    Protected Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_DSR FROM AR_DSR WHERE NO_DSR Like 'DSR-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_DSR DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "DSR-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'DSR','') AS INT)),0) AS ID FROM AR_DSR")
            TxtIDTransaksi.Text = "DSR" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

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

    Dim sumbruto As Double = 0
    Dim sumstddisc As Double = 0
    Dim sumadddisc As Double = 0
    Dim sumcashdisc As Double = 0
    Dim sumnetto As Double = 0
    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("DO", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
        InitGrid.AddColumnGrid("Bruto", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Std. Disc", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Add. Disc", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Cash Disc", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Netto", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Status_Promo", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2", DevExpress.Utils.DefaultBoolean.False,, False)
        InitGrid.AddColumnGrid("Batal", TypeCode.Double, 70, False, DevExpress.Utils.FormatType.Numeric, "n2", DevExpress.Utils.DefaultBoolean.False,, False)

        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
        End With
        With GridView1.Columns.Item("Std. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Std. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
        End With
        With GridView1.Columns.Item("Add. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Add. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom

        End With
        With GridView1.Columns.Item("Cash Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Cash Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
        End With
        With GridView1.Columns.Item("Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
        End With



    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
        GridView1.PostEditor()
        GridView1.UpdateTotalSummary()

    End Sub

    'DIVISI
    Private Sub TxtDivisi_Click(sender As Object, e As System.EventArgs) Handles TxtDivisi.Click
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub txtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    'GUDANG
    Private Sub TxtKodeGudang_Click(sender As Object, e As System.EventArgs) Handles TxtKodeGudang.Click
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang_All)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang_All)
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TglPengakuan_EditValueChanged(sender As Object, e As EventArgs) Handles TglPengakuan.EditValueChanged

    End Sub

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Bruto" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Bruto" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sumbruto = 0
                    Case CustomSummaryProcess.Calculate
                        Dim shouldSum As Boolean = CBool(GridView1.GetRowCellValue(e.RowHandle, "Batal"))
                        If shouldSum = False Then
                            sumbruto += CDbl(e.FieldValue)
                        End If
                    Case CustomSummaryProcess.Finalize
                        e.TotalValue = sumbruto
                End Select
            End If
        End If

        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Std. Disc" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Std. Disc" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sumstddisc = 0
                    Case CustomSummaryProcess.Calculate
                        Dim shouldSum As Boolean = CBool(GridView1.GetRowCellValue(e.RowHandle, "Batal"))
                        If shouldSum = False Then
                            sumstddisc += CDbl(e.FieldValue)
                        End If
                    Case CustomSummaryProcess.Finalize
                        e.TotalValue = sumstddisc
                End Select
            End If
        End If

        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Add. Disc" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Add. Disc" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sumadddisc = 0
                    Case CustomSummaryProcess.Calculate
                        Dim shouldSum As Boolean = CBool(GridView1.GetRowCellValue(e.RowHandle, "Batal"))
                        If shouldSum = False Then
                            sumadddisc += CDbl(e.FieldValue)
                        End If
                    Case CustomSummaryProcess.Finalize
                        e.TotalValue = sumadddisc
                End Select
            End If
        End If

        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Cash Disc" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Cash Disc" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sumcashdisc = 0
                    Case CustomSummaryProcess.Calculate
                        Dim shouldSum As Boolean = CBool(GridView1.GetRowCellValue(e.RowHandle, "Batal"))
                        If shouldSum = False Then
                            sumcashdisc += CDbl(e.FieldValue)
                        End If
                    Case CustomSummaryProcess.Finalize
                        e.TotalValue = sumcashdisc
                End Select
            End If
        End If

        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Netto" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Netto" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sumnetto = 0
                    Case CustomSummaryProcess.Calculate
                        Dim shouldSum As Boolean = CBool(GridView1.GetRowCellValue(e.RowHandle, "Batal"))
                        If shouldSum = False Then
                            sumnetto += CDbl(e.FieldValue)
                        End If
                    Case CustomSummaryProcess.Finalize
                        e.TotalValue = sumnetto
                End Select
            End If
        End If
    End Sub

    Private Sub GridView1_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        If e.RowHandle >= 0 Then
            Dim batal As String = ""
            batal = GridView1.GetRowCellValue(e.RowHandle, "Batal")
            If batal = 1 Then
                e.Appearance.BackColor = Color.IndianRed
            Else
                e.Appearance.BackColor = Color.Transparent
            End If
        End If
    End Sub
End Class


Public Class InputCreateDSR
    Inherits FrmCreateDSR
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub GetDataDSR() Handles TxtDivisi.EditValueChanged, TxtKodeGudang.EditValueChanged, TglPengakuan.EditValueChanged, RDPembayaran.EditValueChanged
        Dim Filter = ""
        If Jenis = JenisEnum.Perwakilan Then Filter = " AND NOTA.BAGIAN LIKE '%Perwakilan%' AND NOTA.GUDANG='" & TxtKodeGudang.Text & "' "
        If Jenis = JenisEnum.Pusat Then Filter = " AND NOTA.BAGIAN LIKE '%Pusat%' AND DO.PEMBAYARAN='" & RDPembayaran.EditValue & "' "
        If Jenis = JenisEnum.Pusat Then
            Using dturut = SelectCon.execute("select isnull(max(urutan_DSR),0)URUTAN from AR_DSR where jenis = 'Pusat' and divisi = '" & TxtDivisi.Text & "' and GUDANG = '" & TxtKodeGudang.Text & "' and format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglPengakuan.DateTime, "MMyy") & "'")
                If dturut.Rows.Count > 0 Then
                    TxtUrutan.Text = dturut.Rows(0)(0) + 1
                Else
                    TxtUrutan.Text = 1
                End If
            End Using
            LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(Nota, 6) AS INT)) 'No.',* FROM ( SELECT DISTINCT NOTA.ID_TRANSAKSI AS 'Id Nota', NOTA.NO_NOTA AS 'Nota','' as NO_PERWAKILAN,NOTA.NO_DO AS 'DO', NOTA.KODE_CUSTOMER 'Id Customer', CUSTOMER.NAMA AS 'Nama', NOTA.SUBTOTAL AS 'Bruto', NOTA.DISC_REG_NOMINAL AS 'Std. Disc', NOTA.DISC_QTY_NOMINAL+NOTA.DISC_QTY_NOMINAL1+NOTA.DISC_1_NOMINAL+NOTA.DISC_2_NOMINAL+NOTA.DISC_3_NOMINAL AS 'Add. Disc', NOTA.CASH_DISC_NOMINAL AS 'Cash Disc', NOTA.DPP+NOTA.PPN AS 'Netto',iif(DO.ID_TRANSAKSI IN (select A.ID_TRANSAKSI from DETAIL_DELIVERY_ORDER a join LINK_BARANG_PROMO b on a.ID_BARANG = b.ID_BARANG where DO.TGL_PENGAKUAN between TGL_AWAL and TGL_AKHIR  and KODE_PROMO = '00001' ),1,0)STATUS_PROMO,NOTA.BATAL FROM NOTA LEFT JOIN DELIVERY_ORDER DO ON NOTA.ID_DO=DO.ID_TRANSAKSI LEFT JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID WHERE CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) = CONVERT(DATE,'" & TglPengakuan.DateTime & "',103) AND NOTA.DIVISI='" & TxtDivisi.Text & "' and nota.id_transaksi not in (select ID_NOTA from AR_DSR_DETAIL WITH(NOLOCK)) " & Filter & ") A  ORDER BY CAST(RIGHT(Nota, 6) AS INT)")
            LoadData.SetDataDetail(dt, False)
        ElseIf Jenis = JenisEnum.Perwakilan Then
            Using dturut = SelectCon.execute("select isnull(max(urutan_DSR),0)URUTAN from AR_DSR where jenis = 'Perwakilan' and divisi = '" & TxtDivisi.Text & "' and GUDANG = '" & TxtKodeGudang.Text & "' and format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglPengakuan.DateTime, "MMyy") & "'")
                If dturut.Rows.Count > 0 Then
                    TxtUrutan.Text = dturut.Rows(0)(0) + 1
                Else
                    TxtUrutan.Text = 1
                End If
            End Using
            LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(Nota, 6) AS INT)) 'No.',* FROM ( SELECT DISTINCT NOTA.ID_TRANSAKSI AS 'Id Nota', NOTA.NO_NOTA AS 'Nota', NOTA.NO_NOTA as NO_PERWAKILAN,NOTA.NO_DO AS 'DO', NOTA.KODE_CUSTOMER 'Id Customer', CUSTOMER.NAMA AS 'Nama', NOTA.SUBTOTAL AS 'Bruto', NOTA.DISC_REG_NOMINAL AS 'Std. Disc', NOTA.DISC_QTY_NOMINAL+NOTA.DISC_QTY_NOMINAL1+NOTA.DISC_1_NOMINAL+NOTA.DISC_2_NOMINAL+NOTA.DISC_3_NOMINAL AS 'Add. Disc', NOTA.CASH_DISC_NOMINAL AS 'Cash Disc', NOTA.DPP+NOTA.PPN AS 'Netto',iif(DO.ID_TRANSAKSI IN (select A.ID_TRANSAKSI from DETAIL_DELIVERY_ORDER a join LINK_BARANG_PROMO b on a.ID_BARANG = b.ID_BARANG where DO.TGL_PENGAKUAN between TGL_AWAL and TGL_AKHIR  and KODE_PROMO = '00001'),1,0)STATUS_PROMO,NOTA.BATAL FROM NOTA LEFT JOIN DELIVERY_ORDER DO ON NOTA.ID_DO=DO.ID_TRANSAKSI LEFT JOIN CUSTOMER ON NOTA.KODE_CUSTOMER = CUSTOMER.ID WHERE  CONVERT(DATE,NOTA.TGL_PENGAKUAN,103) = CONVERT(DATE,'" & TglPengakuan.DateTime & "',103) AND NOTA.DIVISI='" & TxtDivisi.Text & "' and nota.id_transaksi not in (select ID_NOTA from AR_DSR_DETAIL WITH(NOLOCK)) " & Filter & ") A  ORDER BY CAST(RIGHT(Nota, 6) AS INT)")
            LoadData.SetDataDetail(dt, False)
        End If
        If dt.Rows.Count > 0 Then
            GridView1.PostEditor()
            GridView1.UpdateTotalSummary()
        End If

    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtDivisi, TxtUrutan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran, Jenis.ToString, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtUrutan}, "AR_DSR") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id Customer", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No.", "No. Perwakilan", "Status_Promo", "Batal"}, "AR_DSR_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditCreateDSR
    Inherits FrmCreateDSR

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_DSR, TGL, TGL_PENGAKUAN, DIVISI, GUDANG,URUTAN_DSR FROM AR_DSR WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,A.NO_PERWAKILAN, A.NO_DO, A.ID_CUSTOMER, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO,isnull(A.PROMO_BMB_UMKM,0),isnull(A.BATAL,0) FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        If dt.Rows.Count > 0 Then
            GridView1.PostEditor()
            GridView1.UpdateTotalSummary()
        End If


    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi, TxtUrutan}) Then Exit Sub

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_DSR] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG], [PEMBAYARAN],URUTAN_DSR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran, TxtUrutan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_DSR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_DSR_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id Customer", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No.", "No. Perwakilan", "Status_Promo", "Batal"}, "AR_DSR_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_DSR_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_DSR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_DSR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class


Public Class InputCreateDSRPrw
    Inherits InputCreateDSR

    Private Sub InputCreateDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        GridView1.Columns("No. Perwakilan").OptionsColumn.AllowFocus = False
        Jenis = JenisEnum.Perwakilan
        Text = "Input Daily Sales Report Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub
End Class

Public Class EditCreateDSRPrw
    Inherits EditCreateDSR

    Private Sub EditCreateDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Jenis = JenisEnum.Perwakilan
        Text = "Edit Daily Sales Report Perwakilan"
        Status_Edit = True
        GridView1.Columns("No. Perwakilan").OptionsColumn.AllowFocus = False
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
End Class


Public Class InputCreateDSRPus
    Inherits InputCreateDSR

    Private Sub InputCreateDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Jenis = JenisEnum.Pusat

        Text = "Input Daily Sales Report Pusat"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub
End Class

Public Class EditCreateDSRPus
    Inherits EditCreateDSR

    Private Sub EditCreateDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Jenis = JenisEnum.Pusat
        Text = "Edit Daily Sales Report Pusat"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
End Class