
Public MustInherit Class FrmBonPesanan
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean
    Protected Bagian As EBagian

#Region "Shared Sub"
    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Titipan, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_BON FROM BON_PESANAN WHERE NO_BON Like '" & TxtNamaDivisi.Text & "(T)" & "(" & InisialPerusahaan & ")" & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_BON DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = TxtNamaDivisi.Text & "(T)" & "(" & InisialPerusahaan & ")" & Format(urut, "000000")
        End Using
        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'BON','') AS BIGINT)),0) AS ID FROM BON_PESANAN")
            TxtIDTransaksi.Text = "BON" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan()
        Dim i As Integer
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        If Bagian.ToString.Contains("Perwakilan") Then
            If Empty(TxtKodeGudang) Then Exit Sub
        End If

        'If CDbl(TxtSisa.Text) < 0 Then
        '    MsgBox("Nominal Nota Lebih Besar Dari Saldo Titipan !!!", vbCritical, "Peringatan")
        '    Exit Sub
        'End If

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To GridView1.RowCount - 1
            If Len(GridView1.GetRowCellValue(i, GridView1.Columns(2))) > 0 Then
                If GridView1.GetRowCellValue(i, GridView1.Columns("Kuantum")) = 0 Then
                    MsgBox("Ada Kuantum yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtDOTitipan, TglDOTitipan, TglPriceList, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), TxtKodeGudang, ChkBebasPPN}, "BON_PESANAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_BON_PESANAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

#Region "Edit"
    Protected Sub GetData()
        LoadData.GetData("SELECT [NO_BON] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[TGL_PRICE] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[GUDANG], [BEBAS_PPN] FROM BON_PESANAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtDOTitipan, TglDOTitipan, TglPriceList, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, TxtKodeGudang, ChkBebasPPN})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.ISI,A.KOLI,A.QUANTITY,A.SATUAN,A.KONVERSI,A.PCS,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL FROM DETAIL_BON_PESANAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN")
        LoadData.SetDataDetail(dt, True)
        TxtDOTitipan.Enabled = False
        HitungTanpaDiskon()
        SetData("SELECT (TITIP-BON)+" & Replace(CDbl(TxtTotal.Text), ",", ".") & " AS SALDO FROM V_TITIPAN_TERPENUHI_BON WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'", {TxtSaldo})
        TxtTotal_EditValueChanged(Nothing, Nothing)
        Log.Load(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub SimpanEdit()
        Dim i As Integer
        If Empty(TxtIDCustomer) Then Exit Sub
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub
        If Bagian.ToString.Contains("Perwakilan") Then
            If Empty(TxtKodeGudang) Then Exit Sub
        End If
        'If CDbl(TxtSisa.Text) < 0 Then
        '    MsgBox("Nominal Nota Lebih Besar Dari Saldo Titipan !!!", vbCritical, "Peringatan")
        '    Exit Sub
        'End If

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To GridView1.RowCount - 1
            If Len(GridView1.GetRowCellValue(i, GridView1.Columns(2))) > 0 Then
                If GridView1.GetRowCellValue(i, GridView1.Columns("Kuantum")) = 0 Then
                    MsgBox("Ada Kuantum yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If QuestionEdit() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_BON] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[TGL_PRICE] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME] ,[GUDANG] ,[BEBAS_PPN]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtDOTitipan, TglDOTitipan, TglPriceList, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), TxtKodeGudang, ChkBebasPPN}, "BON_PESANAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_BON_PESANAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_BON_PESANAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("BON_PESANAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_BON_PESANAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "BON_PESANAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 35, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 40, True, , , , REBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 15, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 25, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 50, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 75, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                TxtAlamatKantor.Text = dtCustomer.Rows(0).Item("ALAMAT_KANTOR")
            Else
                TxtKodeApprove.Text = ""
                TxtNama.Text = ""
                TxtAlamatKantor.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDO.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call REBEdit_Click(sender, e)
                ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Kode Barang").ToString.Trim) > 0 Then
                            AddRow(dt)
                            Urutan()
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                            Hitung()
                        End If
                    End If
                End If
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z"), Asc("0") To Asc("9"), Asc(","), Asc("."), System.Windows.Forms.Keys.Back
                e.Handled = False
                'Call REBEdit_Click(sender, e)
        End Select
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        On Error Resume Next
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("ID Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("ID Barang")
            End If
            Urutan()
            Hitung()
        End If
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub RDJenisPPN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPPN.SelectedIndexChanged
        Hitung()
        If RDJenisPPN.SelectedIndex = 0 Then
            ChkBebasPPN.Checked = False
            ChkBebasPPN.Enabled = False
        Else
            ChkBebasPPN.Enabled = True
        End If
    End Sub

    Private Sub TxtTotal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtTotal.EditValueChanged
        On Error Resume Next
        TxtNota.Text = CDbl(TxtTotal.Text)
        TxtSisa.Text = CDbl(TxtSaldo.Text) - CDbl(TxtNota.Text)
    End Sub

    Private Sub TxtSisa_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtSisa.EditValueChanged
        On Error Resume Next
        If CDbl(TxtSisa.Text) < 0 Then
            TxtSisa.ForeColor = Color.Red
            GroupBox2.BackColor = Color.Yellow
        Else
            TxtSisa.ForeColor = Color.Black
            GroupBox2.BackColor = Color.Silver
        End If
    End Sub

    Private Sub TxtDOTitipan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDOTitipan.ButtonClick
        TxtIDDO.Text = Search(FrmPencarian.KeyPencarian.DO_Titipan, , , , , EnumDescription(Bagian))
    End Sub

    Private Sub TxtIDDO_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDDO.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT [NO_DO] ,[TGL_PENGAKUAN] ,[TGL_PRICE] ,[DIVISI] ,'Include' ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[DISC_REG] ,[DISC_1] ,[DISC_2] ,[DISC_3] ,[CASH_DISC] FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
            LoadData.SetData({TxtDOTitipan, TglDOTitipan, TglPriceList, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon})
            SetData("SELECT TITIP-BON AS SALDO FROM V_TITIPAN_TERPENUHI_BON WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'", {TxtSaldo})
        End If
        If TxtIDDO.Text = "" Then
            TBDO.Enabled = False
        Else
            TBDO.Enabled = True
        End If
    End Sub

    Private Sub TxtDOTitipan_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDOTitipan.KeyPress
        If CharKeypress(TxtIDDO, e) Then TxtIDDO.Text = Search(FrmPencarian.KeyPencarian.DO_Titipan, , , , , EnumDescription(Bagian))
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Kuantum") = CDbl(col("Isi")) * CDbl(col("Koli"))
            col("Pieces") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Truncate(CDbl(col("Kuantum")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            Hitung()
        End If
    End Sub

    'ReBEdit
    Private Sub REBEdit_Click(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If
            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST AS ISI ") & " ,B.ISI AS KONV FROM BARANG A INNER JOIN V_SATUAN_TO_PCS B ON A.ID=B.ID AND B.SATUAN1=" & IIf(EnumDescription(Bagian).Contains("Langganan"), " A.SAT_DIST1", " A.SAT_SUPER1") & " LEFT JOIN VI_PRICE_LIST C ON A.ID=C.ID_BARANG " & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND C.TGL_PRICE <= CONVERT(DATE,'" & Format(TglPriceList.DateTime, "MM-dd-yyyy") & "')" & IIf(EnumDescription(Bagian).Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_PRICE DESC,C.ID")
                If dt_cari.Rows.Count > 0 Then
                    If dt.Select("[ID Barang]='" & col("Kode Barang") & "' OR [Kode Barang]='" & col("Kode Barang") & "'").Length > 1 Then
                        MsgBox("Barang Sudah Ada !!")
                        col("ID Barang") = ""
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    End If
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Barang_Divisi, GridView1.EditingValue, _
                              FrmPencarian.TypeButton.Barang, , , TxtDivisi.Text)
            If kode = "" Then
                col("ID Barang") = kode
                GridView1.EditingValue = kode
            Else
                If dt.Select("[ID Barang]='" & kode & "'").Length > 0 Then
                    MsgBox("Barang Sudah Ada !!")
                    col("ID Barang") = ""
                    GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                    Exit Sub
                Else
                    col("ID Barang") = kode
                    GridView1.EditingValue = kode
                End If
            End If
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST AS ISI ") & " ,B.ISI AS KONV FROM BARANG A INNER JOIN V_SATUAN_TO_PCS B ON A.ID=B.ID AND B.SATUAN1=" & IIf(EnumDescription(Bagian).Contains("Langganan"), " A.SAT_DIST1", " A.SAT_SUPER1") & " LEFT JOIN VI_PRICE_LIST C ON A.ID=C.ID_BARANG " & IIf(EnumDescription(Bagian).Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND C.TGL_PRICE <= CONVERT(DATE,'" & Format(TglPriceList.DateTime, "MM-dd-yyyy") & "')" & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE A.ID='" & col("ID Barang") & "' " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_PRICE DESC,C.ID")
                If dt_cari.Rows.Count > 0 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
                Else
                    col("Kode Barang") = ""
                    col("Nama Barang") = ""
                    col("Isi") = 0
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Satuan") = ""
                    col("Konv") = 0
                    col("Harga Satuan") = 0
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                End If
            End Using

            'ElseIf GridView1.FocusedColumn.FieldName = "Satuan" Then
            '    Dim col As DataRow = GridView1.GetFocusedDataRow()
            '    Dim satuan As String = Search(FrmPencarian.KeyPencarian.Satuan_Barang, , , , , _
            '                                  GridView1.GetFocusedRow("ID Barang"))
            '    If satuan = "" Then
            '        Exit Sub
            '    Else
            '        col("Satuan") = satuan
            '        Using dt_cari = SelectCon.execute("SELECT " & IIf(EnumDescription(Bagian).Contains("Langganan"), "HARGA_DIST AS HARGA ", "HARGA_SUPER AS HARGA ") & " FROM BARANG WHERE ID='" & col("ID Barang") & "'")
            '            If dt_cari.Rows.Count > 0 Then
            '                col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
            '            Else
            '                col("Harga Satuan") = 0
            '            End If
            '        End Using
            '        Hitung()
            '        SendKeys.Send("{Right}")
            '    End If
        End If
    End Sub

    Private Sub TxtDiskonQty1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskonQty1.EditValueChanged, TxtDiskonQty1Nominal.EditValueChanged, TxtDiskonReguler.EditValueChanged, TxtDiskonRegulerNominal.EditValueChanged, TxtDiskon1.EditValueChanged, TxtDiskon1Nominal.EditValueChanged, TxtDiskon2.EditValueChanged, TxtDiskon2Nominal.EditValueChanged, TxtDiskon3.EditValueChanged, TxtDiskon3Nominal.EditValueChanged, TxtCashDiskon.EditValueChanged, TxtCashDiskonNominal.EditValueChanged, TxtDiskonQty2.EditValueChanged, TxtDiskonQty2Nominal.EditValueChanged
        If ActiveControl IsNot Nothing Then
            Select Case ActiveControl.Parent.Name
                Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                    Hitung()
            End Select
        End If
    End Sub

    Private Sub TxtDivisi_EditValueChanged() Handles TxtDivisi.EditValueChanged
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub TxtKodeCabang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeCabang.ButtonClick
        TxtKodeCabang.Text = Search(FrmPencarian.KeyPencarian.Cabang_Customer, , , , , , , , TxtIDCustomer.Text)
    End Sub

    Private Sub TxtKodeCabang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeCabang.EditValueChanged
        SetData("SELECT NAMA_CABANG,ALAMAT_CABANG FROM DETAIL_CUSTOMER_CABANG WHERE ID='" & TxtIDCustomer.Text & "' AND KODE_CABANG='" & TxtKodeCabang.Text & "'", {TxtNamaCabang, TxtAlamatKirim})
    End Sub

    Private Sub TxtKodeCabang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeCabang.KeyPress
        If CharKeypress(TxtKodeCabang, e) Then
            TxtKodeCabang.Text = Search(FrmPencarian.KeyPencarian.Cabang_Customer, , , , , , , , TxtIDCustomer.Text)
        End If
    End Sub

#Region "Declare"
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub AllowEditColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EditColumn As String, ByVal CheckColumn As String)
        On Error Resume Next
        If Len(Gridview.GetFocusedRow(CheckColumn).ToString.Trim) > 0 Then
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = False
        Else
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = True
        End If
    End Sub

    Protected Sub HitungTanpaDiskon()
        On Error Resume Next
        Dim TempTotalDiskon As Double = 0
        Dim Total As Double = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Rows
            Subtotal = 0
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Subtotal = col("Pieces") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
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
            Subtotal = col("Pieces") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = Math.Round(Total)
        Next

        If ActiveControl IsNot Nothing Then
            Select Case ActiveControl.Parent.Name
                Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                Case Else
                    GoTo DiskonQty1
            End Select
        End If

        If ActiveControl IsNot Nothing Then
            Select Case ActiveControl.Parent.Name
                Case TxtDiskonQty1.Name
DiskonQty1:         TxtDiskonQty1Nominal.Value = Math.Round(CDbl(dt.Compute("Sum(Kuantum)", "")) * CDbl(TxtDiskonQty1.Value))
                    GoTo DiskonReguler
                Case TxtDiskonQty1Nominal.Name
                    TxtDiskonQty1.Value = Math.Round(CDbl(TxtDiskonQty1Nominal.Value) / CDbl(dt.Compute("Sum(Kuantum)", "")))
                    GoTo DiskonReguler
                Case TxtDiskonReguler.Name
DiskonReguler:      TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                    TxtDiskonRegulerNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonReguler.Value) / 100)
                    GoTo Diskon1
                Case TxtDiskonRegulerNominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                    TxtDiskonReguler.Value = Math.Round(CDbl(TxtDiskonRegulerNominal.Value) / (Total - TempTotalDiskon) * 100)
                    GoTo Diskon1
                Case TxtDiskon1.Name
Diskon1:            TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                    TxtDiskon1Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon1.Value) / 100)
                    GoTo Diskon2
                Case TxtDiskon1Nominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                    TxtDiskon1.Value = Math.Round(CDbl(TxtDiskon1Nominal.Value) / (Total - TempTotalDiskon) * 100)
                    GoTo Diskon2
                Case TxtDiskon2.Name
Diskon2:            TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                    TxtDiskon2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon2.Value) / 100)
                    GoTo Diskon3
                Case TxtDiskon2Nominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                    TxtDiskon2.Value = Math.Round(CDbl(TxtDiskon2Nominal.Value) / (Total - TempTotalDiskon) * 100)
                    GoTo Diskon3
                Case TxtDiskon3.Name
Diskon3:            TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value)
                    TxtDiskon3Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon3.Value) / 100)
                    GoTo CashDiskon
                Case TxtDiskon3Nominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value)
                    TxtDiskon3.Value = Math.Round(CDbl(TxtDiskon3Nominal.Value) / (Total - TempTotalDiskon) * 100)
                    GoTo CashDiskon
                Case TxtCashDiskon.Name
CashDiskon:         TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                    TxtCashDiskonNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtCashDiskon.Value) / 100)
                    GoTo DiskonQty2
                Case TxtCashDiskonNominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                    TxtCashDiskon.Value = Math.Round(CDbl(TxtCashDiskonNominal.Value) / (Total - TempTotalDiskon) * 100)
                    GoTo DiskonQty2
                Case TxtDiskonQty2.Name
DiskonQty2:         TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                    TxtDiskonQty2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonQty2.Value) / 100)
                Case TxtDiskonQty2Nominal.Name
                    TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                    CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                    TxtDiskonQty2.Value = Math.Round(CDbl(TxtDiskonQty2Nominal.Value) / (Total - TempTotalDiskon) * 100)
            End Select
        End If

        'If TxtDiskonQty1.Value = 0 Then
        '    TxtDiskonQty2.Enabled = True
        '    TxtDiskonQty2Nominal.Enabled = True
        'Else
        '    TxtDiskonQty2.Enabled = False
        '    TxtDiskonQty2Nominal.Enabled = False
        'End If

        'If TxtDiskonQty2.Value = 0 Then
        '    TxtDiskonQty1.Enabled = True
        '    TxtDiskonQty1Nominal.Enabled = True
        'Else
        '    TxtDiskonQty1.Enabled = False
        '    TxtDiskonQty1Nominal.Enabled = False
        'End If

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

    Private Sub ChkBebasPPN_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkBebasPPN.CheckedChanged
        If ActiveControl IsNot Nothing Then
            Select Case ActiveControl.Name
                Case ChkBebasPPN.Name
                    Hitung()
            End Select
        End If
    End Sub
#End Region

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub


    'Rubah Harga
    Private Sub BtnRubahHarga_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnRubahHarga.ItemClick
        Using LoadDataToGrid As New _LoadDataToGrid
            LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='" & IIf(EnumDescription(Bagian).Contains("Supermarket"), "Supermarket", "Langganan") & "' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') ORDER BY TGL_PRICE DESC")
            LoadDataToGrid.Init("Pilih", 25)
            LoadDataToGrid.Init("Harga", 50, DevExpress.Utils.FormatType.Numeric, "n", , False)
            LoadDataToGrid.Init("Tgl. Price", 50, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", , False)
            LoadDataToGrid.EndInit(TBHarga, GridViewHarga)
        End Using
        GridViewHarga.Columns(0).ColumnEdit = BtnPilihHarga
        GridViewHarga.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridViewHarga.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        TBDO.Enabled = False
        DockPanelHarga.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
    End Sub
    Private Sub TBHarga_DoubleClick(sender As Object, e As System.EventArgs) Handles TBHarga.DoubleClick, BtnPilihHarga.Click
        GridView1.GetFocusedDataRow()("Harga Satuan") = GridViewHarga.GetFocusedDataRow()(1)
        TglPricelist.DateTime = GridViewHarga.GetFocusedDataRow()(2)
        Hitung()
        GridView1.RefreshData()
        DockPanelHarga.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
        TBDO.Enabled = True
    End Sub
    Private Sub DockPanelHarga_ClosedPanel(sender As Object, e As DevExpress.XtraBars.Docking.DockPanelEventArgs) Handles DockPanelHarga.ClosedPanel
        TBDO.Enabled = True
    End Sub
    Private Sub TBDO_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBDO.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Using frm As New FrmDetailDOTitipan(TxtIDDO.Text)
            frm.ShowDialog()
        End Using
    End Sub
End Class