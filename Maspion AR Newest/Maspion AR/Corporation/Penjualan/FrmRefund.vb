
Public MustInherit Class FrmRefund
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean = False
    Protected Bagian As EBagian
    Protected UrutanRefund As Int64


#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, TxtIDNota.Text)
        Log.Cetak(Me, TxtIDNota.Text)
    End Sub


#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        RDJenisPPN.SelectedIndex = 0
        TxtDivisi.Enabled = True
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        If Status_Edit = False Then
            TxtNoTransaksi.Text = TxtNoNota.Text
            Using dtGenerate = SelectCon.execute("SELECT COUNT(*) AS URUT FROM REFUND WHERE ID_NOTA='" & TxtIDNota.Text & "'")
                UrutanRefund = CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'R','') AS BIGINT)),0) AS ID FROM REFUND")
                TxtIDTransaksi.Text = "R" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End If
    End Sub

    Protected Sub Simpan()
        If Empty({TglTransaksi, TglPengakuan, TxtIDNota}) Then Exit Sub
        GridView1.CloseEditor()

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoRef, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), UrutanRefund, ChkBebasPPN}, "REFUND") = False Then Exit Sub
            If SQLServer.UpdateHeader("[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN]", {TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN}, "NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan", "Isi", "Konv", "Koli Nota", "Qty Nota", "Pcs Nota", "Koli Refund", "Qty Refund", "Pcs Refund", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_REFUND") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDNota.Text), ToObject(TxtNoNota.Text), "ID Barang", "Isi", "Koli Jual", "Qty Jual", "Satuan", "Konv", "Pcs Jual", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pcs Refund", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT [NO_REFUND] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_REF] ,[ID_NOTA] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[BEBAS_PPN] FROM REFUND WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoRef, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, ChkBebasPPN})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI,A.QUANTITY,A.PCS,A.KOLI_REFUND,A.QUANTITY_REFUND,A.PCS_REFUND,A.KOLI-A.KOLI_REFUND,A.QUANTITY-A.QUANTITY_REFUND,A.PCS-A.PCS_REFUND,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND((A.QUANTITY-A.QUANTITY_REFUND) * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL,A.KONVERSI,A.ISI FROM DETAIL_REFUND A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN")
            LoadData.SetDataDetail(dt, False)
            Urutan()
            HitungTanpaDiskon()
            Log.Load(Me, TxtIDTransaksi.Text)
        End If
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi}) Then Exit Sub
        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_REFUND", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Header
            If SQLServer.UpdateHeader("[NO_REFUND] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_REF] ,[ID_NOTA] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME] ,[BEBAS_PPN]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoRef, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ChkBebasPPN}, "REFUND", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN]", {TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN}, "NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan", "Isi", "Konv", "Koli Nota", "Qty Nota", "Pcs Nota", "Koli Refund", "Qty Refund", "Pcs Refund", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_REFUND") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDNota.Text), ToObject(TxtNoNota.Text), "ID Barang", "Isi", "Koli Jual", "Qty Jual", "Satuan", "Konv", "Pcs Jual", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pcs Refund", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_REFUND", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("REFUND", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDNota.Text), ToObject(TxtNoNota.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "REFUND", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDNota.Text), ToObject(TxtNoNota.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using


        '        If MsgBox("Apakah anda ingin membatalkan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
        '            Exit Sub
        '        End If

        '        con.begin_exec()
        '        If con.exec("DELETE FROM SALDO_STOK WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        '        If con.exec("UPDATE REFUND SET BATAL=1 WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        '        If con.exec("DELETE FROM DETAIL_TRANSAKSI_DISKON WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        '        con.end_exec(True)
        '        MessageBox.Show("Data telah dibatalkan..!!", _
        '                        "Penyimpanan Sukses", _
        '                        MessageBoxButtons.OK, _
        '                        MessageBoxIcon.Information)
        '        Me.Dispose()
        '        Exit Sub
        'keluar:
        '        con.end_exec(False)
        '        MessageBox.Show("Data gagal tersimpan..!!", _
        '                "Penyimpanan Gagal", _
        '                MessageBoxButtons.OK, _
        '                MessageBoxIcon.Information)
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
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Koli Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli Refund", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty Refund", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs Refund", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Koli Jual", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Jual", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Jual", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
        GridView1.FocusedColumn = GridView1.Columns(0)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtNama, TxtAlamatKantor})
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub TxtKodeCabang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeCabang.EditValueChanged
        SetData("SELECT NAMA_CABANG FROM DETAIL_CUSTOMER_CABANG WHERE ID='" & TxtIDCustomer.Text & "' AND KODE_CABANG='" & TxtKodeCabang.Text & "'", {TxtNamaCabang})
    End Sub
    ''' <summary>
    ''' Gudang
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.Column.OptionsColumn.AllowFocus Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli Refund" Then
            If Val(col("Koli Refund")) > col("Koli Nota") Then
                MsgBox("Koli Refund Tidak Boleh Melebihi Koli Nota !!")
                col("Koli Refund") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Refund" Then
            If Val(col("Qty Refund")) > col("Qty Nota") Then
                MsgBox("Qty Refund Tidak Boleh Melebihi Qty Nota !!")
                col("Qty Refund") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Refund" Then
            If Val(col("Pcs Refund")) > col("Pcs Nota") Then
                MsgBox("Pcs Refund Tidak Boleh Melebihi Pcs Nota !!")
                col("Pcs Refund") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli Refund" Then
            col("Qty Refund") = CDbl(col("Isi")) * CDbl(col("Koli Refund"))
            col("Pcs Refund") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli Refund")) * CDbl(col("Konv")))

            col("Koli Jual") = col("Koli Nota") - col("Koli Refund")
            col("Qty Jual") = col("Qty Nota") - col("Qty Refund")
            col("Pcs Jual") = col("Pcs Nota") - col("Pcs Refund")
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Refund" Then
            col("Koli Refund") = Math.Truncate((CDbl(col("Qty Refund")) / CDbl(col("Isi"))))
            col("Pcs Refund") = Math.Truncate(CDbl(col("Qty Refund")) * CDbl(col("Konv")))

            col("Qty Jual") = col("Qty Nota") - col("Qty Refund")
            col("Koli Jual") = col("Koli Nota") - col("Koli Refund")
            col("Pcs Jual") = col("Pcs Nota") - col("Pcs Refund")
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Refund" Then
            col("Qty Refund") = Math.Truncate((CDbl(col("Pcs Refund")) / CDbl(col("Konv"))))
            col("Koli Refund") = Math.Truncate((CDbl(col("Qty Refund")) / CDbl(col("Isi"))))

            col("Pcs Jual") = col("Pcs Nota") - col("Pcs Refund")
            col("Qty Jual") = col("Qty Nota") - col("Qty Refund")
            col("Koli Jual") = col("Koli Nota") - col("Koli Refund")
            Hitung()
        End If
    End Sub
    ''' <summary>
    ''' Cari Nota
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoNota_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoNota.ButtonClick
        TxtIDNota.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Refund)
    End Sub
    Private Sub TxtNoNota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoNota.KeyPress
        If CharKeypress(TxtIDNota, e) Then TxtIDNota.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Refund)
    End Sub
    Private Sub TxtIDNota_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDNota.EditValueChanged
        If Status_Edit = False Then
            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT [NO_NOTA] ,[NO_REF] ,[TGL_PENGAKUAN] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[BEBAS_PPN] FROM NOTA WHERE ID_TRANSAKSI='" & TxtIDNota.Text & "'")
                MyLoadData.SetData({TxtNoNota, TxtNoRef, TglNota, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, ChkBebasPPN})

                MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,+A.KOLI,A.QUANTITY,A.PCS,0,0,0,A.KOLI,A.QUANTITY,A.PCS,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM  DETAIL_NOTA A  LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDNota.Text & "' ORDER BY A.URUTAN")
                MyLoadData.SetDataDetail(dt, False)
                Urutan()
                Hitung()
            End Using
        End If
        Generate()
    End Sub

    Private Sub TglTransaksi_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TglTransaksi.EditValueChanged, TglPengakuan.EditValueChanged
        If TglTransaksi.EditValue IsNot Nothing And TglPengakuan.EditValue IsNot Nothing Then
            If TglPengakuan.DateTime > TglTransaksi.DateTime Then
                MsgBox("Tanggal Pengakuan Tidak Boleh Lebih Dari Tanggal Transaksi !!")
                TglPengakuan.DateTime = TglTransaksi.DateTime
            End If
        End If
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub
    Protected Sub HitungTanpaDiskon()
        On Error Resume Next
        Dim TempTotalDiskon As Double = 0
        Dim Total As Double = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Rows
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            col("Pcs Jual") = col("Pcs Nota") - col("Pcs Refund")
            col("Qty Jual") = col("Qty Nota") - col("Qty Refund")
            col("Koli Jual") = col("Koli Nota") - col("Koli Refund")
            Subtotal = 0
            Subtotal = col("Pcs Jual") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = Math.Round(Total)
        Next

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
            CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value) + _
            CDbl(TxtDiskonQty2Nominal.Value)
        DPP = Math.Round(Total - CDbl(TempTotalDiskon))

        If RDJenisPPN.SelectedIndex = 1 Then
            DPP = DPP / 1.1
            If ChkBebasPPN.Checked Then
                TxtPPN.Value = 0
            Else
                TxtPPN.Value = DPP * 0.1
            End If
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
        TxtDPP.Value = DPP
        If TxtPPN.Text = "" Then TxtPPN.Text = 0
        TxtTotal.Text = CDbl(DPP) + CDbl(TxtPPN.Text)
    End Sub
    Protected Sub Hitung()
        On Error Resume Next
        Dim TempTotalDiskon As Double = 0
        Dim Total As Double = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Rows
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            col("Pcs Jual") = col("Pcs Nota") - col("Pcs Refund")
            col("Qty Jual") = col("Qty Nota") - col("Qty Refund")
            col("Koli Jual") = col("Koli Nota") - col("Koli Refund")
            Subtotal = 0
            Subtotal = col("Pcs Jual") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = Math.Round(Total)
        Next

        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                    Case Else
                        GoTo DiskonQty1
                End Select
            End If
        End If

        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name
DiskonQty1:             TxtDiskonQty1Nominal.Value = CDbl(dt.Compute("Sum([Qty Jual])", "")) * CDbl(TxtDiskonQty1.Value)
                        GoTo DiskonReguler
                    Case TxtDiskonQty1Nominal.Name
                        TxtDiskonQty1.Value = CDbl(TxtDiskonQty1Nominal.Value) / CDbl(dt.Compute("Sum([Qty Jual])", ""))
                        GoTo DiskonReguler
                    Case TxtDiskonReguler.Name
DiskonReguler:          TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonRegulerNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonReguler.Value) / 100)
                        GoTo Diskon1
                    Case TxtDiskonRegulerNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonReguler.Value = Math.Round(CDbl(TxtDiskonRegulerNominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon1
                    Case TxtDiskon1.Name
Diskon1:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon1.Value) / 100)
                        GoTo Diskon2
                    Case TxtDiskon1Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1.Value = Math.Round(CDbl(TxtDiskon1Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon2
                    Case TxtDiskon2.Name
Diskon2:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon2.Value) / 100)
                        GoTo Diskon3
                    Case TxtDiskon2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2.Value = Math.Round(CDbl(TxtDiskon2Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon3
                    Case TxtDiskon3.Name
Diskon3:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon3.Value) / 100)
                        GoTo CashDiskon
                    Case TxtDiskon3Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3.Value = Math.Round(CDbl(TxtDiskon3Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo CashDiskon
                    Case TxtCashDiskon.Name
CashDiskon:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskonNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtCashDiskon.Value) / 100)
                        GoTo DiskonQty2
                    Case TxtCashDiskonNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskon.Value = Math.Round(CDbl(TxtCashDiskonNominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo DiskonQty2
                    Case TxtDiskonQty2.Name
DiskonQty2:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonQty2.Value) / 100)
                    Case TxtDiskonQty2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2.Value = Math.Round(CDbl(TxtDiskonQty2Nominal.Value) / (Total - TempTotalDiskon) * 100)
                End Select
            End If
        End If

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Text) + CDbl(TxtDiskonRegulerNominal.Text) + CDbl(TxtDiskon1Nominal.Text) + _
            CDbl(TxtDiskon2Nominal.Text) + CDbl(TxtDiskon3Nominal.Text) + CDbl(TxtCashDiskonNominal.Text) + _
            CDbl(TxtDiskonQty2Nominal.Text)
        DPP = Math.Round(Total - TempTotalDiskon)

        If RDJenisPPN.SelectedIndex = 1 Then
            DPP = DPP / 1.1
            If ChkBebasPPN.Checked Then
                TxtPPN.Value = 0
            Else
                TxtPPN.Value = DPP * 0.1
            End If
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
        TxtDPP.Value = DPP
        If TxtPPN.Text = "" Then TxtPPN.Text = 0
        TxtTotal.Text = CDbl(DPP) + CDbl(TxtPPN.Text)
    End Sub
End Class


Public Class InputRefundSupermarketPerwakilan
    Inherits FrmRefund

    Private Sub InputNotaSJSupermarketPerwakilan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Refund Supermarket Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditRefundSupermarketPerwakilan
    Inherits FrmRefund

    Private Sub EditDeliveryOrderSupermarketPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Refund Supermarket Perwakilan"
        RDJenisPPN.Enabled = False
        TxtDivisi.Enabled = False
        Status_Edit = True

        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        HakForm("Penjualan Supermarket", "Perwakilan", "Refund", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class