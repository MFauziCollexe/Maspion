
Public Class FrmHargaPromo
    Protected dt As New DataTable
    Protected dtCustomer As New DataTable
    Protected DPP As Decimal
    Protected _Status_Edit As Boolean = False
    Protected Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtDivisi.Enabled = False
                RDJenis.Enabled = False
            Else
                TxtDivisi.Enabled = True
                RDJenis.Enabled = True
            End If
        End Set
        Get
            Return _Status_Edit
        End Get
    End Property


#Region "Shared Sub"
    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub
    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM HARGA_PROMO WHERE NO_TRANSAKSI Like 'HP/" & Format(TglTransaksi.DateTime, "yyMM") & "%' AND YEAR(TGL_AWAL)=" & Format(TglAwal.EditValue, "yyyy") & " ORDER BY NO_TRANSAKSI DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "HP/" & Format(TglTransaksi.DateTime, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'HP','') AS BIGINT)),0) AS ID FROM HARGA_PROMO")
            TxtIDTransaksi.Text = "HP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub
    Protected Sub Simpan()
        If Empty({TxtDivisi, TglTransaksi, TglAwal}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)("Kode Barang")) > 0 Then
                If GridView1.GetDataRow(i)("Harga Promo") = 0 Then
                    MsgBox("Ada Harga Promo Masih Nol !!!", MsgBoxStyle.Information, "Peringatan")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Harga Promo")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglAwal, TglAkhir, TxtDivisi, RDJenisPriceList, ToSyntax("NULL"), ToSyntax("NULL"), txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, ConcatCustomer()}, "HARGA_PROMO") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[ID Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan Besar", "Satuan Besar2", "Isi", "Satuan Kecil", "Satuan Kecil2", "Harga Lama", "Harga Promo", ToObject(RDJenis.EditValue), "No."}, "DETAIL_HARGA_PROMO") = False Then Exit Sub
            Try
                If SQLServer.InsertDetail(dtCustomer.Select("[ID Customer]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), "ID Customer", "Kode Customer"}, "DETAIL_HARGA_PROMO_CUSTOMER") = False Then Exit Sub
            Catch ex As Exception
            End Try
            'For Each dr As DataRow In dt.Select("[Kode Barang]<>''").CopyToDataTable.Rows
            '    If SQLServer.UpdateHeader(IIf(RDJenis.EditValue = "Langganan", "HARGA_DIST", "HARGA_SUPER"), {dr("Harga Baru")}, "BARANG", "ID='" & dr("ID Barang") & "'") = False Then Exit Sub
            'Next
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT A.[NO_TRANSAKSI] ,A.[TGL] ,A.[TGL_AWAL] ,A.[TGL_AKHIR] ,A.[DIVISI] ,A.[JENIS_PRICE] ,A.[KETERANGAN_CETAK] ,A.[KETERANGAN_INTERNAL],B.[JENIS] FROM HARGA_PROMO A INNER JOIN DETAIL_HARGA_PROMO B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglAwal, TglAkhir, TxtDivisi, RDJenisPriceList, txtKeterangan, txtKeteranganInternal, RDJenis})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.SATUAN1,A.ISI,A.SATUANK,A.SATUANK1,A.HARGA_LAMA,A.HARGA_BARU FROM DETAIL_HARGA_PROMO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, True)
            LoadData.GetData("SELECT B.ID,B.KODE_APPROVE,A.NAMA FROM CUSTOMER A INNER JOIN DETAIL_HARGA_PROMO_CUSTOMER B ON A.ID=B.ID WHERE B.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetDataDetail(dtCustomer, True)
        End If
        Log.Load(Me, TxtIDTransaksi.Text)
        Urutan()
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TxtDivisi, TglTransaksi, TglAwal}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)("Kode Barang")) > 0 Then
                If GridView1.GetDataRow(i)("Harga Promo") = 0 Then
                    MsgBox("Ada Harga Promo Masih Nol !!!", MsgBoxStyle.Information, "Peringatan")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Harga Promo")
                    Exit Sub
                End If
            End If
        Next

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_TRANSAKSI] ,[TGL] ,[TGL_AWAL] ,[TGL_AKHIR] ,[DIVISI] ,[JENIS_PRICE] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME], [CUSTOMER]", {TxtNoTransaksi, TglTransaksi, TglAwal, TglAkhir, TxtDivisi, RDJenisPriceList, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ConcatCustomer()}, "HARGA_PROMO", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_HARGA_PROMO", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_HARGA_PROMO_CUSTOMER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[ID Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan Besar", "Satuan Besar2", "Isi", "Satuan Kecil", "Satuan Kecil2", "Harga Lama", "Harga Promo", ToObject(RDJenis.EditValue), "No."}, "DETAIL_HARGA_PROMO") = False Then Exit Sub
            Try
                If SQLServer.InsertDetail(dtCustomer.Select("[ID Customer]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), "ID Customer", "Kode Customer"}, "DETAIL_HARGA_PROMO_CUSTOMER") = False Then Exit Sub
            Catch ex As Exception
            End Try

            'For Each dr As DataRow In dt.Select("[Kode Barang]<>''").CopyToDataTable.Rows
            '    If SQLServer.UpdateHeader(IIf(RDJenis.EditValue = "Langganan", "HARGA_DIST", "HARGA_SUPER"), {dr("Harga Baru")}, "BARANG", "ID='" & dr("ID Barang") & "'") = False Then Exit Sub
            'Next
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub

        If TglAwal.DateTime <= Now.Date Then
            MsgBox("Tanggal Price List sudah aktif !")
            Exit Sub
        End If

        For Each dr As DataRow In dt.Rows
            If SelectCon.execute("SELECT ID_BARANG FROM ( SELECT DISTINCT ID_BARANG FROM DETAIL_TRANSFER_GUDANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PENERIMAAN_TRANSFER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_RETUR_PENJUALAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_BON_PESANAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SALDO_AWAL_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PEMBELIAN UNION ALL SELECT DISTINCT ID_BARANG FROM SALDO_STOK_BACKUP_CUTOFF UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TITIP_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_STUFFING UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_CLAIM UNION ALL SELECT DISTINCT ID_BARANG FROM ADJUSMENT_BULANAN UNION ALL SELECT DISTINCT ID_BARANG FROM SALDO_STOK UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_RETUR_PEMBELIAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TRANSFER_BARANG_RETUR UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_NOTA UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SURAT_JALAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SJ_TITIP_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_DELIVERY_ORDER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TTB UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PURCHASE_ORDER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_ADJUSMENT_STOK UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_REFUND) Z WHERE ID_BARANG='" & dr("ID Barang") & "'").Rows.Count > 0 Then
                MsgBox("Barang ini sudah pernah dipakai pada transaksi !")
                Exit Sub
            End If
        Next

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_HARGA_PROMO", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("HARGA_PROMO", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "HARGA_PROMO", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        GridView1.ShowPrintPreview()
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub
#End Region

    Private Function ConcatCustomer() As String
        Dim Temp As String = ""
        For Each col As DataRow In dtCustomer.Rows
            Temp = Temp & "(" & col("Kode Customer") & ") " & col("Nama Customer") & "; "
        Next
        Return Temp
    End Function

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
        TglAwal.DateTime = Format(Now.Date, "dd/MM/yyyy")

        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 60, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan Besar", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Satuan Besar2", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Satuan Kecil", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Satuan Kecil2", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Harga Lama", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Harga Promo", TypeCode.Decimal, 50, True, DevExpress.Utils.FormatType.Numeric, "n2", , ReCalc)
        InitGrid.EndInit(TBDetailPrice, GridView1, dt)
        AddRow(dt)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Customer", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Customer", TypeCode.String, 60, True, , , , RBEditCust)
        InitGrid.AddColumnGrid("Nama Customer", TypeCode.String, 150, False)
        InitGrid.EndInit(TBCustomer, GridView2, dtCustomer)
        AddRow(dtCustomer)
    End Sub

    Private Sub TxtDivisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDetailPrice.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call ReBEdit_ButtonClick(sender, New System.EventArgs)
            End Select
        ElseIf GridView1.FocusedColumn.FieldName = "Harga Promo" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Kode Barang").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            End If
        End If
        EnableDisableCtl()
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReBEdit_ButtonClick(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If
            If RDJenis.SelectedIndex = -1 Then
                MsgBox("Kolom Jenis Masih Kosong !!")
                RDJenis.Focus()
                Exit Sub
            End If
            Dim satuan As String
            If RDJenis.SelectedIndex = 0 Then : satuan = "A.SAT_DIST1, A.SAT_DIST2, A.QTY_DIST, B.HARGA_BARU AS HARGA_DIST"
            Else : satuan = "A.SAT_SUPER1 AS SAT_DIST1, A.SAT_SUPER2 AS SAT_DIST2,1 AS QTY_DIST, B.HARGA_BARU AS HARGA_DIST" : End If
            Dim filt As String
            If RDJenis.SelectedIndex = 0 Then : filt = " AND B.JENIS='Langganan' "
            Else : filt = " AND B.JENIS='Supermarket' " : End If
            If RDJenisPriceList.SelectedIndex = 0 Then filt = filt & " AND B.ID='UMUM' "

            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID, A.KODE, A.NAMA, " & satuan & ", A.SAT_SUPER1, A.SAT_SUPER2 FROM BARANG A LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG LEFT JOIN VI_PRICE_LIST B ON A.ID=B.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') AND A.STATUS_AKTIF=1 " & filt & " AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY TGL_PRICE DESC")
                If dt_cari.Rows.Count = 1 Then
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
                    col("Satuan Besar") = dt_cari.Rows(0).Item("SAT_DIST1")
                    col("Satuan Besar2") = dt_cari.Rows(0).Item("SAT_DIST2")
                    col("Isi") = dt_cari.Rows(0).Item("QTY_DIST")
                    col("Satuan Kecil") = dt_cari.Rows(0).Item("SAT_SUPER1")
                    col("Satuan Kecil2") = dt_cari.Rows(0).Item("SAT_SUPER2")
                    col("Harga Lama") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("Harga Promo") = dt_cari.Rows(0).Item("HARGA_DIST")
                    GridView1.FocusedColumn = GridView1.Columns("Harga Promo")
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Barang_Divisi, GridView1.EditingValue,
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
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID, A.KODE, A.NAMA, " & satuan & ", A.SAT_SUPER1, A.SAT_SUPER2 FROM BARANG A LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG LEFT JOIN VI_PRICE_LIST B ON A.ID=B.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') AND A.STATUS_AKTIF=1 " & filt & "AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY TGL_PRICE DESC")
                If dt_cari.Rows.Count = 1 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Satuan Besar") = dt_cari.Rows(0).Item("SAT_DIST1")
                    col("Satuan Besar2") = dt_cari.Rows(0).Item("SAT_DIST2")
                    col("Isi") = dt_cari.Rows(0).Item("QTY_DIST")
                    col("Satuan Kecil") = dt_cari.Rows(0).Item("SAT_SUPER1")
                    col("Satuan Kecil2") = dt_cari.Rows(0).Item("SAT_SUPER2")
                    col("Harga Lama") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("Harga Promo") = dt_cari.Rows(0).Item("HARGA_DIST")
                    GridView1.FocusedColumn = GridView1.Columns("Harga Promo")
                Else
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = ""
                    col("Kode Barang") = ""
                    col("Nama Barang") = ""
                    col("Satuan Besar") = ""
                    col("Satuan Besar2") = ""
                    col("Isi") = 0
                    col("Satuan Kecil") = ""
                    col("Satuan Kecil2") = ""
                    col("Harga Lama") = 0
                    col("Harga Promo") = 0
                End If
            End Using
        End If
        EnableDisableCtl()
    End Sub

    Private Sub EnableDisableCtl()
        If dt.Select("[ID Barang] <> ''").Length > 0 Then
            TxtDivisi.Enabled = False
            RDJenis.Enabled = False
        Else
            TxtDivisi.Enabled = True
            RDJenis.Enabled = True
        End If
    End Sub

    Private Sub RDJenisPriceList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPriceList.SelectedIndexChanged
        If RDJenisPriceList.SelectedIndex = 0 Then
            TBCustomer.Enabled = False
        ElseIf RDJenisPriceList.SelectedIndex = 1 Then
            TBCustomer.Enabled = True
        End If
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub RDJenis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenis.SelectedIndexChanged
        If RDJenis.SelectedIndex > -1 Then
            TBDetailPrice.Enabled = True
        End If
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub GridView2_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView2.FocusedColumnChanged
        On Error Resume Next
        If Len(GridView2.GetFocusedRow("Nama Customer").ToString.Trim) > 0 Then
            GridView2.Columns("Kode Customer").OptionsColumn.AllowEdit = False
        Else
            GridView2.Columns("Kode Customer").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView2_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView2.FocusedRowChanged
        On Error Resume Next
        If Len(GridView2.GetFocusedRow("Nama Customer").ToString.Trim) > 0 Then
            GridView2.Columns("Kode Customer").OptionsColumn.AllowEdit = False
        Else
            GridView2.Columns("Kode Customer").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub TBCustomer_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBCustomer.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        If GridView2.FocusedColumn.FieldName = "Kode Customer" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call RBEditCust_ButtonClick(sender, New EventArgs)
            End Select
        End If
    End Sub

    Private Sub GridView2_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyUp
        If e.KeyCode = 46 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
            If GridView2.RowCount = 0 Then
                AddRow(dtCustomer)
                GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
            End If
        End If
    End Sub

    Private Sub RBEditCust_ButtonClick(sender As Object, e As EventArgs) Handles RBEditCust.ButtonClick
        If RDJenis.SelectedIndex = -1 Then
            MsgBox("Kolom Jenis Masih Kosong !!")
            RDJenis.Focus()
            Exit Sub
        End If
        Dim bagian As EBagian = IIf(RDJenis.SelectedIndex = 0, EBagian.Langganan_Perwakilan, EBagian.Supermarket_Perwakilan)
        Dim filter As String = Nothing
        Select Case bagian
            Case EBagian.Langganan_Perwakilan, EBagian.Langganan_Pusat
                filter = " AND A.GROUP_CUSTOMER='Distributor' "
            Case EBagian.Supermarket_Perwakilan, EBagian.Supermarket_Pusat
                filter = " AND A.GROUP_CUSTOMER='Supermarket' "
            Case EBagian.Lain_Perwakilan, EBagian.Lain_Pusat
                filter = " AND A.GROUP_CUSTOMER='Lain - lain' "
            Case Else
                filter = ""
        End Select

        Dim col As DataRow = GridView2.GetFocusedDataRow()
        'CEK DATA ADA / TIDAK 
        Using dt_cari = SelectCon.execute("SELECT ID,KODE_APPROVE,NAMA FROM CUSTOMER A WHERE A.KODE_APPROVE='" & col("Kode Customer") & "' " & filter)
            If dt_cari.Rows.Count > 0 Then
                If dtCustomer.Select("[ID Customer]='" & dt_cari.Rows(0).Item("ID") & "'").Length > 1 Then
                    MsgBox("Customer Sudah Ada !!")
                    col("ID C") = ""
                    GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
                    Exit Sub
                End If
                col("ID Customer") = dt_cari.Rows(0).Item("ID")
                col("Kode Customer") = dt_cari.Rows(0).Item("KODE_APPROVE")
                col("Nama Customer") = dt_cari.Rows(0).Item("NAMA")
                GridView2.EditingValue = dt_cari.Rows(0).Item("KODE_APPROVE")
                AddRow(dtCustomer)
                GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
                Exit Sub
            Else
                GoTo CariData
            End If
        End Using

CariData:
        Dim kode As String = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, GridView2.EditingValue, , , , , , , , , , bagian)
        If kode = "" Then
            col("ID Customer") = kode
            GridView2.EditingValue = kode
        Else
            If dtCustomer.Select("[ID Customer]='" & kode & "'").Length > 0 Then
                MsgBox("Customer Sudah Ada !!")
                col("ID Customer") = ""
                GridView2.EditingValue = ""
                GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
                Exit Sub
            Else
                col("ID Customer") = kode
                GridView2.EditingValue = kode
            End If
        End If
        Using dt_cari = SelectCon.execute("SELECT ID,KODE_APPROVE,NAMA FROM CUSTOMER A WHERE A.ID='" & kode & "' " & filter)
            If dt_cari.Rows.Count > 0 Then
                col("ID Customer") = dt_cari.Rows(0).Item("ID")
                col("Kode Customer") = dt_cari.Rows(0).Item("KODE_APPROVE")
                col("Nama Customer") = dt_cari.Rows(0).Item("NAMA")
                GridView2.EditingValue = dt_cari.Rows(0).Item("KODE_APPROVE")
                AddRow(dtCustomer)
                GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
            Else
                col("ID Customer") = ""
                col("Kode Customer") = ""
                col("Nama Customer") = ""
                GridView2.EditingValue = ""
                GridView2.FocusedColumn = GridView2.Columns("Kode Customer")
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button7_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button7.ItemClick
        Dim frm As New InputHargaPromo
        With frm
            .TglTransaksi.DateTime = Now
            .TglAwal.DateTime = Now
            .TxtDivisi.Text = Me.TxtDivisi.Text
            .RDJenisPriceList.SelectedIndex = Me.RDJenisPriceList.SelectedIndex
            .RDJenis.SelectedIndex = Me.RDJenis.SelectedIndex
            .txtKeterangan.Text = Me.txtKeterangan.Text
            .txtKeteranganInternal.Text = Me.txtKeteranganInternal.Text
            .MdiParent = Me.MdiParent
            .Show()
            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.SATUAN1,A.ISI,A.SATUANK,A.SATUANK1,A.HARGA_LAMA,A.HARGA_BARU FROM DETAIL_HARGA_PROMO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(frm.dt, True)
            LoadData.GetData("SELECT B.ID,B.KODE_APPROVE,A.NAMA FROM CUSTOMER A INNER JOIN DETAIL_HARGA_PROMO_CUSTOMER B ON A.ID=B.ID WHERE B.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetDataDetail(frm.dtCustomer, True)
        End With
    End Sub
End Class

Public Class InputHargaPromo
    Inherits FrmHargaPromo

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Harga Promo"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditHargaPromo
    Inherits FrmHargaPromo

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Harga Promo"
        TxtDivisi.Enabled = False
        Status_Edit = True
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
    End Sub


End Class