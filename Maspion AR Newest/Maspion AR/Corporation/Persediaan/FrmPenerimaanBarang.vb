
Public MustInherit Class FrmPenerimaanTransfer
    Protected dt As New DataTable
    Protected Status_Edit As Boolean

#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        'If _Toolbar1_Button6.Visible = False Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.Surat_Jalan, TxtIDTransaksi.Text)
    End Sub

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        TxtDivisi.Enabled = True
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT TOP 1 NO_PENERIMAAN FROM PENERIMAAN_TRANSFER WHERE NO_PENERIMAAN Like 'PT/" & TxtNamaDivisi.Text & "%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_PENERIMAAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PT/" & TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PT','') AS BIGINT)),0) AS ID FROM PENERIMAAN_TRANSFER")
            TxtIDTransaksi.Text = "PT" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan()
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub
        If Empty(TglPengakuan) Then Exit Sub
        If Empty(TxtIDTransfer) Then Exit Sub

        If GridView1.RowCount = 0 Then
            MsgBox("Data Detail masih kosong!!!", vbCritical, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTransfer, TxtNoTransfer, TglTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("null"), ToSyntax("null"), 0}, "PENERIMAAN_TRANSFER") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[ID Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Terima", "Kuantum Terima", "Satuan", "Konv", "Pieces Terima", "Harga Satuan", "No."}, "DETAIL_PENERIMAAN_TRANSFER") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudangTujuan.Text), "ID Barang", "Kode Barang", "Pieces Terima", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        LoadData.GetData("SELECT [NO_PENERIMAAN] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TRANSFER] ,[NO_TRANSFER] ,[TGL_TRANSFER] ,[DIVISI] ,[GUDANG_SUMBER] ,[GUDANG_TUJUAN] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] FROM [PENERIMAAN_TRANSFER] WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTransfer, TxtNoTransfer, TglTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS,A.KONVERSI,A.KOLI,A.QUANTITY,A.PCS,A.HARGA FROM (PENERIMAAN_TRANSFER AA INNER JOIN DETAIL_PENERIMAAN_TRANSFER A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_TRANSFER_T_TERIMA B ON AA.ID_TRANSFER=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Protected Sub SimpanEdit()
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub
        If Empty(TglPengakuan) Then Exit Sub
        If Empty(TxtIDTransfer) Then Exit Sub

        If GridView1.RowCount = 0 Then
            MsgBox("Data Detail masih kosong!!!", vbCritical, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_PENERIMAAN] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TRANSFER] ,[NO_TRANSFER] ,[TGL_TRANSFER] ,[DIVISI] ,[GUDANG_SUMBER] ,[GUDANG_TUJUAN] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTransfer, TxtNoTransfer, TglTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "PENERIMAAN_TRANSFER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_PENERIMAAN_TRANSFER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[ID Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Terima", "Kuantum Terima", "Satuan", "Konv", "Pieces Terima", "Harga Satuan", "No."}, "DETAIL_PENERIMAAN_TRANSFER") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudangTujuan.Text), "ID Barang", "Kode Barang", "Pieces Terima", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
 If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_PENERIMAAN_TRANSFER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("PENERIMAAN_TRANSFER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "PENERIMAAN_TRANSFER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub
#End Region

#End Region

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Single, 30, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Single, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Konv", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli Terima", TypeCode.Single, 30, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum Terima", TypeCode.Single, 50, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces Terima", TypeCode.Single, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Single, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(sender, e)
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli Terima" Then
            If Val(col("Koli Terima")) > col("Koli") Then
                MsgBox("Koli Terima Tidak Boleh Melebihi Koli Transfer !!")
                col("Koli Terima") = 0
                GridView1.EditingValue = 0
                GridView1.CloseEditor()
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Terima" Then
            If Val(col("Kuantum Terima")) > col("Kuantum") Then
                MsgBox("Kuantum Terima Tidak Boleh Melebihi Qty Transfer !!")
                col("Kuantum Terima") = 0
                GridView1.EditingValue = 0
                GridView1.CloseEditor()
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces Terima" Then
            If Val(col("Pieces Terima")) > col("Pieces") Then
                MsgBox("Pieces Terima Tidak Boleh Melebihi Pcs Transfer !!")
                col("Pieces Terima") = 0
                GridView1.EditingValue = 0
                GridView1.CloseEditor()
                GridView1.RefreshEditor(True)
            End If
        End If
        If GridView1.FocusedColumn.FieldName = "Koli Terima" Then
            col("Pieces Terima") = Math.Round(CDbl(col("Isi")) * CDbl(col("Koli Terima")) * CDbl(col("Konv")))
            col("Kuantum Terima") = Math.Truncate((CDbl(col("Pieces Terima")) / CDbl(col("Konv"))))
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum Terima" Then
            col("Koli Terima") = Math.Truncate((CDbl(col("Kuantum Terima")) / CDbl(col("Isi"))))
            col("Pieces Terima") = Math.Round(CDbl(col("Kuantum Terima")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum Terima") = Math.Truncate((CDbl(col("Pieces Terima")) / CDbl(col("Konv"))))
            col("Koli Terima") = Math.Truncate((CDbl(col("Kuantum Terima")) / CDbl(col("Isi"))))
        End If
        GridView1.RefreshData()
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReCalc_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles ReCalc.EditValueChanging
        'Dim col As DataRow = GridView1.GetFocusedDataRow
        'If GridView1.FocusedColumn.FieldName = "Koli Terima" Then
        '    If Val(col("Koli Terima")) > col("Koli") Then
        '        MsgBox("Koli Terima Tidak Boleh Melebihi Koli Transfer !!")
        '        col("Koli Terima") = 0
        '        GridView1.EditingValue = 0
        '        GridView1.RefreshEditor(True)
        '    End If
        'ElseIf GridView1.FocusedColumn.FieldName = "Qty Terima" Then
        '    If Val(col("Kuantum Terima")) > col("Kuantum") Then
        '        MsgBox("Kuantum Terima Tidak Boleh Melebihi Qty Transfer !!")
        '        col("Kuantum Terima") = 0
        '        GridView1.EditingValue = 0
        '        GridView1.RefreshEditor(True)
        '    End If
        'ElseIf GridView1.FocusedColumn.FieldName = "Pieces Terima" Then
        '    If Val(col("Pieces Terima")) > col("Pieces") Then
        '        MsgBox("Pieces Terima Tidak Boleh Melebihi Pcs Transfer !!")
        '        col("Pieces Terima") = 0
        '        GridView1.EditingValue = 0
        '        GridView1.RefreshEditor(True)
        '    End If
        'End If
    End Sub

    Private Sub TxtIDTransfer_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtIDTransfer.ButtonClick
        TxtIDTransfer.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Transfer_Gudang)
    End Sub

    Private Sub TxtIDTransfer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDTransfer.EditValueChanged
        If Status_Edit = False Then
            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT [NO_TRANSFER] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG_SUMBER] ,[GUDANG_TUJUAN] FROM TRANSFER_GUDANG WHERE ID_TRANSAKSI='" & TxtIDTransfer.Text & "'")
                MyLoadData.SetData({TxtNoTransfer, TglTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan})

                MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.HARGA FROM V_D_TRANSFER_T_TERIMA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransfer.Text & "' AND A.ST=0")
                MyLoadData.SetDataDetail(dt, False)
                Urutan()
            End Using
        End If
    End Sub

    Private Sub TxtIDTransfer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDTransfer.KeyPress
        If CharKeypress(TxtIDTransfer, e) Then TxtIDTransfer.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Transfer_Gudang)
    End Sub

    Private Sub TxtKodeGudangTujuan_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudangTujuan.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudangTujuan.Text & "'", {TxtNamaGudangTujuan})
    End Sub
    Private Sub TxtKodeGudangSumber_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudangSumber.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudangSumber.Text & "'", {TxtNamaGudangSumber})
    End Sub

End Class



Public Class InputPenerimaanTransfer
    Inherits FrmPenerimaanTransfer

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Penerimaan Transfer"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Generate()

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditPenerimaanTransfer
    Inherits FrmPenerimaanTransfer

    Private Sub EditDeliveryOrderLainPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Penerimaan Transfer"
        TxtDivisi.Enabled = False
        Status_Edit = True

        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("", "Persediaan", "Penerimaan Transfer", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class