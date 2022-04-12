
Public MustInherit Class FrmNotaPembelian
    Protected dt As New DataTable
    Protected DPP As Double
    Private _Status_Edit As Boolean
    Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtNoPO.Enabled = False
            Else
                TxtNoPO.Enabled = True
            End If
        End Set
        Get
            Return _Status_Edit
        End Get
    End Property

    Private EnBagian As EBagian
    Property Bagian As EBagian
        Set(value As EBagian)
            EnBagian = value
            LblTitle.Caption = "Nota " & EnumDescription(value)
        End Set
        Get
            Return EnBagian
        End Get
    End Property

#Region "Shared Sub"

    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
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
            Dim urut As Short
            Dim MyFormat As String = IIf(EnumDescription(Bagian).Contains("Supermarket"), "(SUPER)", "")
            Using dtGenerate = SelectCon.execute("SELECT NO_NOTA FROM PEMBELIAN WHERE NO_NOTA LIKE '" & TxtNamaDivisi.Text & MyFormat & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_NOTA DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = TxtNamaDivisi.Text & MyFormat & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PB','') AS BIGINT)),0) AS ID FROM PEMBELIAN")
                TxtIDTransaksi.Text = "PB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End If
    End Sub

    Protected Sub Simpan()
        If Empty({TglTransaksi, TglPengakuan, TxtIDPO, TxtKodeGudang}) Then Exit Sub
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
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDPO, TxtNoPO, TglPO, TxtIDNotaPenjualan, TxtNoNotaPenjualan, TxtDivisi, RDJenisPPN, TxtIDSupplier, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), TxtKodeEkspedisi, TxtNoTruk, ChkBebasPPN}, "PEMBELIAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Koli Terima", "Qty Terima", "Pcs Terima", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_PEMBELIAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pcs Nota", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT [NO_NOTA] ,[NO_REF] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_PO] ,[NO_PO] ,[TGL_PO] ,[ID_NOTA_PENJUALAN] ,[NO_NOTA_PENJUALAN] ,[DIVISI] ,[JENIS_PPN] ,[KODE_SUPPLIER] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[KODE_EKSPEDISI] ,[NO_TRUK] ,[BEBAS_PPN] FROM PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
                MyLoadData.SetData({TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDPO, TxtNoPO, TglPO, TxtIDNotaPenjualan, TxtNoNotaPenjualan, TxtDivisi, RDJenisPPN, TxtIDSupplier, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, TxtKodeEkspedisi, TxtNoTruk, ChkBebasPPN})

                MyLoadData.GetData("SELECT B.URUTAN,B.ID_BARANG,D.KODE,D.NAMA,B.SATUAN,(C.KOLI-C.KOLI_T)+B.KOLI,(C.QUANTITY-C.QUANTITY_T)+B.QUANTITY,(C.PCS-C.PCS_T)+B.PCS,B.KOLI_TERIMA,B.QUANTITY_TERIMA,B.PCS_TERIMA,B.KOLI-B.KOLI_TERIMA,B.QUANTITY-B.QUANTITY_TERIMA,B.PCS-B.PCS_TERIMA,B.HARGA,B.DISC,B.DISKON_SATUAN,(B.PCS * ((B.HARGA-B.DISKON_SATUAN)/B.KONVERSI)),B.KONVERSI,B.ISI FROM PEMBELIAN A INNER JOIN DETAIL_PEMBELIAN B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI INNER JOIN V_D_NOTA_T_PEMBELIAN C ON A.ID_NOTA_PENJUALAN=C.ID_NOTA AND A.ID_PO=C.ID_PO AND B.ID_BARANG=C.ID_BARANG LEFT JOIN BARANG D ON B.ID_BARANG=D.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
                MyLoadData.SetDataDetail(dt, False)
                Log.Load(Me, TxtIDTransaksi.Text)
                Urutan()
                HitungTanpaDiskon()
            End Using
        End If
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TglTransaksi, TglPengakuan, TxtIDPO, TxtKodeGudang}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_NOTA] ,[NO_REF] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_PO] ,[NO_PO] ,[TGL_PO] ,[ID_NOTA_PENJUALAN] ,[NO_NOTA_PENJUALAN] ,[DIVISI] ,[JENIS_PPN] ,[KODE_SUPPLIER] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[KODE_EKSPEDISI] ,[NO_TRUK] ,[MDUSER] ,[MDTIME] ,[BEBAS_PPN]", {TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDPO, TxtNoPO, TglPO, TxtIDNotaPenjualan, TxtNoNotaPenjualan, TxtDivisi, RDJenisPPN, TxtIDSupplier, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, TxtKodeEkspedisi, TxtNoTruk, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ChkBebasPPN}, "PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Koli Terima", "Qty Terima", "Pcs Terima", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_PEMBELIAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pcs Nota", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
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
            If SQLServer.Delete("DETAIL_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'If SQLServer.Delete("LOG_PIUTANG", "ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
            'If SQLServer.Delete("LOG_PIUTANG", "ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Koli Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Nota", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli Terima", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty Terima", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs Terima", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Koli Claim", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Claim", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Claim", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
        GridView1.FocusedColumn = GridView1.Columns(0)
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
        'TxtNoRef.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'TxtNoRef.Properties.Mask.EditMask = TxtNamaDivisi.Text & "000000"
        'TxtNoRef.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub
    Private Sub TxtKodeEkspedisi_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeEkspedisi.EditValueChanged
        SetData("SELECT NAMA FROM EKSPEDISI WHERE KODE='" & TxtKodeEkspedisi.Text & "'", {TxtNamaEkspedisi})
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

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
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

    Private Sub TxtIDSupplier_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDSupplier.EditValueChanged
        SetData("SELECT NAMA FROM SBU WHERE KODE='" & TxtIDSupplier.Text & "'", {TxtNamaSupplier})
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli Terima" Then
            If Val(col("Koli Terima")) > col("Koli Nota") Then
                MsgBox("Koli Terima Tidak Boleh Melebihi Koli Nota !!")
                col("Koli Terima") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Terima" Then
            If Val(col("Qty Terima")) > col("Qty Nota") Then
                MsgBox("Qty Terima Tidak Boleh Melebihi Qty Nota !!")
                col("Qty Terima") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Terima" Then
            If Val(col("Pcs Terima")) > col("Pcs Nota") Then
                MsgBox("Pcs Terima Tidak Boleh Melebihi Pcs Nota !!")
                col("Pcs Terima") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli Terima" Then
            col("Qty Terima") = CDbl(col("Isi")) * CDbl(col("Koli Terima"))
            col("Pcs Terima") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli Terima")) * CDbl(col("Konv")))

            col("Koli Claim") = col("Koli Nota") - col("Koli Terima")
            col("Qty Claim") = col("Qty Nota") - col("Qty Terima")
            col("Pcs Claim") = col("Pcs Nota") - col("Pcs Terima")
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Terima" Then
            col("Koli Terima") = Math.Truncate((CDbl(col("Qty Terima")) / CDbl(col("Isi"))))
            col("Pcs Terima") = Math.Truncate(CDbl(col("Qty Terima")) * CDbl(col("Konv")))

            col("Qty Claim") = col("Qty Nota") - col("Qty Terima")
            col("Koli Claim") = col("Koli Nota") - col("Koli Terima")
            col("Pcs Claim") = col("Pcs Nota") - col("Pcs Terima")
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Terima" Then
            col("Qty Terima") = Math.Truncate((CDbl(col("Pcs Terima")) / CDbl(col("Konv"))))
            col("Koli Terima") = Math.Truncate((CDbl(col("Qty Terima")) / CDbl(col("Isi"))))

            col("Pcs Claim") = col("Pcs Nota") - col("Pcs Terima")
            col("Qty Claim") = col("Qty Nota") - col("Qty Terima")
            col("Koli Claim") = col("Koli Nota") - col("Koli Terima")
            Hitung()
        End If
    End Sub

#Region "Declare"
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
            Subtotal = 0
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Subtotal = col("Pcs Nota") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
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
            Subtotal = 0
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Subtotal = col("Pcs Nota") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
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
DiskonQty1:             TxtDiskonQty1Nominal.Value = CDbl(dt.Compute("Sum([Qty Nota])", "")) * CDbl(TxtDiskonQty1.Value)
                        GoTo DiskonReguler
                    Case TxtDiskonQty1Nominal.Name
                        TxtDiskonQty1.Value = CDbl(TxtDiskonQty1Nominal.Value) / CDbl(dt.Compute("Sum([Qty Nota])", ""))
                        GoTo DiskonReguler
                    Case TxtDiskonReguler.Name
DiskonReguler:          TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonRegulerNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonReguler.Value) / 100)
                        GoTo Diskon1
                    Case TxtDiskonRegulerNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonReguler.Value = CDbl(TxtDiskonRegulerNominal.Value) / (Total - TempTotalDiskon) * 100
                        GoTo Diskon1
                    Case TxtDiskon1.Name
Diskon1:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon1.Value) / 100)
                        GoTo Diskon2
                    Case TxtDiskon1Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1.Value = CDbl(TxtDiskon1Nominal.Value) / (Total - TempTotalDiskon) * 100
                        GoTo Diskon2
                    Case TxtDiskon2.Name
Diskon2:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon2.Value) / 100)
                        GoTo Diskon3
                    Case TxtDiskon2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2.Value = CDbl(TxtDiskon2Nominal.Value) / (Total - TempTotalDiskon) * 100
                        GoTo Diskon3
                    Case TxtDiskon3.Name
Diskon3:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon3.Value) / 100)
                        GoTo CashDiskon
                    Case TxtDiskon3Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3.Value = CDbl(TxtDiskon3Nominal.Value) / (Total - TempTotalDiskon) * 100
                        GoTo CashDiskon
                    Case TxtCashDiskon.Name
CashDiskon:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskonNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtCashDiskon.Value) / 100)
                        GoTo DiskonQty2
                    Case TxtCashDiskonNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskon.Value = CDbl(TxtCashDiskonNominal.Value) / (Total - TempTotalDiskon) * 100
                        GoTo DiskonQty2
                    Case TxtDiskonQty2.Name
DiskonQty2:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonQty2.Value) / 100)
                    Case TxtDiskonQty2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2.Value = CDbl(TxtDiskonQty2Nominal.Value) / (Total - TempTotalDiskon) * 100
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
#End Region

    '' ''' <summary>
    '' ''' Cari Nomor DO
    '' ''' </summary>
    '' ''' <param name="sender"></param>
    '' ''' <param name="e"></param>
    '' ''' <remarks></remarks>
    'Private Sub TxtNoPO_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    TxtIDPO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian, , , , , , , , Bagian)
    'End Sub
    'Private Sub TxtNoPO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoPO.KeyPress
    '    If CharKeypress(TxtIDPO, e) Then TxtIDPO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian, , , , , , , , Bagian)
    'End Sub
    'Private Sub TxtNoPO_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDPO.EditValueChanged
    '    If Status_Edit = False Then
    '        Using MyLoadData As New _LoadData
    '            MyLoadData.GetData("SELECT C.NO_PO,C.TGL_PENGAKUAN,A.ID_TRANSAKSI,A.NO_NOTA,A.DIVISI,A.JENIS_PPN,C.KODE_SUPPLIER,A.ALAMAT_KIRIM,A.KODE_EKSPEDISI,A.NO_TRUK,A.SUBTOTAL,A.DISC_QTY,A.DISC_QTY_NOMINAL,A.DISC_REG,A.DISC_REG_NOMINAL,A.DISC_1,A.DISC_1_NOMINAL,A.DISC_2,A.DISC_2_NOMINAL,A.DISC_3,A.DISC_3_NOMINAL,A.CASH_DISC,A.CASH_DISC_NOMINAL,A.DISC_QTY1,A.DISC_QTY_NOMINAL1,A.PPN FROM NOTA A INNER JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI INNER JOIN PURCHASE_ORDER C ON B.ID_PO=C.ID_TRANSAKSI WHERE C.ID_TRANSAKSI='" & TxtIDPO.Text & "'")
    '            MyLoadData.SetData({TxtNoPO, TglPO, TxtIDNotaPenjualan, TxtNoNotaPenjualan, TxtDivisi, RDJenisPPN, TxtIDSupplier, TxtAlamatKirim, TxtKodeEkspedisi, TxtNoTruk, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN})

    '            MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,0,0,0,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM V_D_NOTA_T_PEMBELIAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_PO='" & TxtIDPO.Text & "' AND A.ST=0")
    '            MyLoadData.SetDataDetail(dt, False)
    '            Urutan()
    '            Hitung()
    '        End Using
    '        Generate()
    '    End If
    'End Sub

    Private Sub TxtNoNotaPenjualan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoNotaPenjualan.ButtonClick
        TxtIDNotaPenjualan.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian, , , , , , , , Bagian)
    End Sub
    Private Sub TxtNoNotaPenjualan_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoNotaPenjualan.KeyPress
        If CharKeypress(TxtIDNotaPenjualan, e) Then TxtIDNotaPenjualan.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian, , , , , , , , Bagian)
    End Sub

    Private Sub TxtIDNotaPenjualan_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDNotaPenjualan.EditValueChanged
        If Status_Edit = False Then
            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT C.NO_PO,C.TGL_PENGAKUAN,C.ID_TRANSAKSI,A.NO_NOTA,A.DIVISI,A.JENIS_PPN,C.KODE_SUPPLIER,A.ALAMAT_KIRIM,A.KODE_EKSPEDISI,A.NO_TRUK,A.SUBTOTAL,A.DISC_QTY,A.DISC_QTY_NOMINAL,A.DISC_REG,A.DISC_REG_NOMINAL,A.DISC_1,A.DISC_1_NOMINAL,A.DISC_2,A.DISC_2_NOMINAL,A.DISC_3,A.DISC_3_NOMINAL,A.CASH_DISC,A.CASH_DISC_NOMINAL,A.DISC_QTY1,A.DISC_QTY_NOMINAL1,A.PPN,A.KETERANGAN_CETAK,A.KETERANGAN_INTERNAL,A.NO_REF, A.BEBAS_PPN FROM NOTA A INNER JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI INNER JOIN PURCHASE_ORDER C ON B.ID_PO=C.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & TxtIDNotaPenjualan.Text & "'")
                MyLoadData.SetData({TxtNoPO, TglPO, TxtIDPO, TxtNoNotaPenjualan, TxtDivisi, RDJenisPPN, TxtIDSupplier, TxtAlamatKirim, TxtKodeEkspedisi, TxtNoTruk, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, txtKeterangan, txtKeteranganInternal, TxtNoRef, ChkBebasPPN})
                If TxtNoRef.Text <> "" Then TxtNoRef.Enabled = False
                MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,0,0,0,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM V_D_NOTA_T_PEMBELIAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_NOTA='" & TxtIDNotaPenjualan.Text & "' AND A.ST=0")
                MyLoadData.SetDataDetail(dt, False)
                Urutan()
                Hitung()
            End Using
            Generate()
            On Error Resume Next
            GridView1.FocusedRowHandle = 0
        End If
    End Sub

End Class


