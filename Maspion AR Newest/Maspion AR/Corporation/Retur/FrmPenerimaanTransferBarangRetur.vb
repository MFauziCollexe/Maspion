
Public MustInherit Class FrmPenerimaanTransferBarangRetur
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

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

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
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID TTB", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 60, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Kd. Packing", TypeCode.String, 80)
        InitGrid.AddColumnGrid("Koli Transfer", TypeCode.Single, 40, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Kuantum Transfer", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Transfer", TypeCode.Single, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli", TypeCode.Single, 30, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Single, 50, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Single, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Single, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("No. TTB")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("No. TTB")
            End If
            Urutan()
        End If
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})

        Dim oldval As Integer = Microsoft.VisualBasic.Right(TxtNoTransaksi.Text, 6)
        Dim MyFormat As String = "(" & InisialPerusahaan & ")"
        TxtNoTransaksi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        TxtNoTransaksi.Properties.Mask.EditMask = TxtNamaDivisi.Text & MyFormat & "000000"
        TxtNoTransaksi.Properties.Mask.UseMaskAsDisplayFormat = True
        TxtNoTransaksi.EditValue = oldval
    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudangSumber.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudangSumber.Text & "'", {TxtNamaGudangSumber})
    End Sub

    Private Sub TxtKodeGudangTujuan_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudangTujuan.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudangTujuan.Text & "'", {TxtGudangTujuan})
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            If Val(col("Koli")) > col("Koli Transfer") Then
                MsgBox("Koli Tidak Boleh Melebihi Koli Transfer !!")
                col("Koli") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            If Val(col("Kuantum")) > col("Kuantum Transfer") Then
                MsgBox("Kuantum Tidak Boleh Melebihi Kuantum Transfer !!")
                col("Kuantum") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            If Val(col("Pieces")) > col("Pcs Transfer") Then
                MsgBox("Pcs Tidak Boleh Melebihi Pcs Transfer !!")
                col("Pieces") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Kuantum") = CDbl(col("Isi")) * CDbl(col("Koli"))
            col("Pieces") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Truncate(CDbl(col("Kuantum")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
        End If
    End Sub

#Region "Method"
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub
#End Region

    Private Sub TxtNoTransfer_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoTransfer.ButtonClick
        TxtIDTransfer.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Transfer_Barang_Retur)
    End Sub

   Private Sub TxtNoTransfer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoTransfer.KeyPress
        If CharKeypress(TxtNoTransfer, e) Then TxtIDTransfer.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Transfer_Barang_Retur)
    End Sub

    Private Sub TxtIDTransfer_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDTransfer.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT NO_TRANSAKSI,DIVISI,GUDANG_SUMBER,GUDANG_TUJUAN FROM TRANSFER_BARANG_RETUR WHERE ID_TRANSAKSI='" & TxtIDTransfer.Text & "'")
            LoadData.SetData({TxtNoTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan})

            LoadData.GetData("SELECT URUTAN,ID_TTB,NO_TTB,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KODE_PACKING,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,A.HARGA FROM V_D_TRANSFER_T_TERIMA_RETUR A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransfer.Text & "' AND ST=0 ORDER BY URUTAN")
            LoadData.SetDataDetail(dt, False)
            Urutan()
        End If
    End Sub

   
End Class


Public Class InputPenerimaanTransferBarangRetur
    Inherits FrmPenerimaanTransferBarangRetur
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Penerimaan Transfer Barang Retur"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM PENERIMAAN_TRANSFER_BARANG_RETUR WHERE NO_TRANSAKSI Like '" & TxtNamaDivisi.Text & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_TRANSAKSI DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        'Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM PENERIMAAN_TRANSFER_BARANG_RETUR WHERE NO_TRANSAKSI = '" & TxtNoTransaksi.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_TRANSAKSI DESC")
        '    If dtGenerate.Rows.Count > 0 Then
        '        MsgBox("Nomor Transaksi " & TxtNoTransaksi.Text & " Sudah pernah dipakai !")
        '        Return False
        '    End If
        'End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'TBR','') AS INT)),0) AS ID FROM PENERIMAAN_TRANSFER_BARANG_RETUR")
            TxtIDTransaksi.Text = "TBR" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtKodeGudangSumber}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTransfer, TxtNoTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "PENERIMAAN_TRANSFER_BARANG_RETUR") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID TTB", "No. TTB", "ID Barang", "Isi", "Kd. Packing", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "No."}, "DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudangTujuan.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditPenerimaanTransferBarangRetur
    Inherits FrmPenerimaanTransferBarangRetur

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Penerimaan Transfer Barang Retur"
        Status_Edit = True
        HakForm("", "Retur", "Penerimaan Transfer Barang Retur", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        TxtNoTransaksi.Properties.ReadOnly = True
        TxtNoTransfer.Enabled = False
        TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_TRANSAKSI ,[TGL] ,[TGL_PENGAKUAN] ,ID_TRANSFER,NO_TRANSFER,[DIVISI] ,[GUDANG_SUMBER] ,[GUDANG_TUJUAN] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] FROM PENERIMAAN_TRANSFER_BARANG_RETUR WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTransfer, TxtNoTransfer, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal})

        LoadData.GetData("SELECT A.URUTAN,A.ID_TTB,A.NO_TTB,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI,A.KODE_PACKING,ISNULL((B.KOLI-B.KOLI_T),0)+A.KOLI,ISNULL((B.QUANTITY-B.QUANTITY_T),0)+A.QUANTITY,ISNULL((B.PCS-B.PCS_T),0)+A.PCS, A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA FROM (PENERIMAAN_TRANSFER_BARANG_RETUR AA INNER JOIN DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_TRANSFER_T_TERIMA_RETUR B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        ReBEdit.Buttons.Item(0).Enabled = False
        Urutan()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeGudangSumber}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_TRANSAKSI] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG_SUMBER] ,[GUDANG_TUJUAN] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudangSumber, TxtKodeGudangTujuan, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "PENERIMAAN_TRANSFER_BARANG_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID TTB", "No. TTB", "ID Barang", "Isi", "Kd. Packing", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "No."}, "DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudangTujuan.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("PENERIMAAN_TRANSFER_BARANG_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "PENERIMAAN_TRANSFER_BARANG_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class