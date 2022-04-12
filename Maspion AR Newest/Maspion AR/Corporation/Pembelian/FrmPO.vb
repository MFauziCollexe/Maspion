
Public MustInherit Class FrmPO
    Protected dt As New DataTable
    Protected DPP As Double
    Property Bagian As EBagian
    Private _AmbilDO As Boolean = False
    Property AmbilDO As Boolean
        Set(value As Boolean)
            _AmbilDO = value
            If value Then
                GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
                GridView1.Columns("Koli").OptionsColumn.AllowEdit = False
                GridView1.Columns("Kuantum").OptionsColumn.AllowEdit = False
                GridView1.Columns("Pieces").OptionsColumn.AllowEdit = False
                GridView1.Columns("No. DO").Visible = True
                GridView1.Columns("No. DO").BestFit()
            Else
                GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
                GridView1.Columns("Koli").OptionsColumn.AllowEdit = True
                GridView1.Columns("Kuantum").OptionsColumn.AllowEdit = True
                GridView1.Columns("Pieces").OptionsColumn.AllowEdit = True
                GridView1.Columns("No. DO").Visible = False
            End If
        End Set
        Get
            Return _AmbilDO
        End Get
    End Property


#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.Purchase_Order, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub Batal()
        Clean(Me)
        TxtDiskonReguler.Value = 15
        RDPembayaran.SelectedIndex = 0
        TxtDivisi.Enabled = True
        dt.Clear()
        AddRow(dt)
        SetData("SELECT CUST_PEMBELIAN FROM PERUSAHAAN", {TxtIDCustomer})
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_PO FROM PURCHASE_ORDER WHERE NO_PO Like 'PO/" & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_PO DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PO/" & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PO','') AS BIGINT)),0) AS ID FROM PURCHASE_ORDER")
            TxtIDTransaksi.Text = "PO" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan(sender As Object, e As System.EventArgs)
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        If Empty(RDPembayaran, LayoutControlItem15) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Pieces") = 0 Then
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoPOManual, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtIDSupplier, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), ChkBebasPPN}, "PURCHASE_ORDER") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No.", "ID DO", "No. DO"}, "DETAIL_PURCHASE_ORDER") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            TxtDivisi.Enabled = False
            TxtKodeApprove.Enabled = False
            RDPembayaran.Enabled = False

            LoadData.GetData("SELECT [NO_PO] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_PO_MANUAL] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[KODE_SUPPLIER] ,[ALAMAT_KIRIM] ,[PEMBAYARAN] ,[TERMS] ,[JATUH_TEMPO] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[BEBAS_PPN] FROM PURCHASE_ORDER WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoPOManual, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtIDSupplier, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, ChkBebasPPN})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL,ISNULL(A.ID_DO,''),ISNULL(C.NO_DO,'') FROM DETAIL_PURCHASE_ORDER A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN DELIVERY_ORDER C ON A.ID_DO=C.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, True)
        End If
        Urutan()
        HitungTanpaDiskon()
        Log.Load(Me, TxtIDTransaksi.Text)
        If dt.Select("[ID DO]<>''").Length > 0 Then
            AmbilDO = True
            GridView1.DeleteRow(GridView1.RowCount - 1)
        End If
    End Sub

    Protected Sub SimpanEdit(sender As Object, e As System.EventArgs)
        Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) <> "" Then
                    MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Kuantum") = 0 Then
                    MsgBox("Ada Kuantum yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_PO] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_PO_MANUAL] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[KODE_SUPPLIER] ,[ALAMAT_KIRIM] ,[PEMBAYARAN] ,[TERMS] ,[JATUH_TEMPO] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME] ,[BEBAS_PPN]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoPOManual, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtIDSupplier, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ChkBebasPPN}, "PURCHASE_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_PURCHASE_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No.", "ID DO", "No. DO"}, "DETAIL_PURCHASE_ORDER") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus(sender As Object, e As System.EventArgs)
        Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) <> "" Then
                    MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("PURCHASE_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_PURCHASE_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi(sender As Object, e As System.EventArgs)
        Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) <> "" Then
                    MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "PURCHASE_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub
#End Region

    Private Sub FrmPO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub InputPO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub FrmPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 35, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 40, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 25, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 15, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 50, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 75, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("ID DO", TypeCode.String, 20, False, , , , , False)
        InitGrid.AddColumnGrid("No. DO", TypeCode.String, 40, False, , , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
        'SetData("SELECT CUST_PEMBELIAN FROM PERUSAHAAN", {TxtIDCustomer})
    End Sub

    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        RDPembayaran.SelectedIndex = -1
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                TxtAlamatKirim.Text = dtCustomer.Rows(0).Item("LOKASI_PENGIRIMAN")
            Else
                TxtNama.Text = ""
                TxtAlamatKirim.Text = ""
                TxtKodeApprove.Text = ""
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Cari Divisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtDivisi_Click(sender As Object, e As System.EventArgs) Handles TxtDivisi.Click
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
        SetData("SELECT DISTINCT A.KODE_SBU,B.NAMA FROM LINK_SBU_DIVISI A INNER JOIN SBU B ON A.KODE_SBU=B.KODE WHERE A.KODE_DIVISI='" & TxtDivisi.Text & "'", {TxtIDSupplier, TxtNamaSupplier})
        SetData("SELECT A.ID_CUSTOMER FROM SETUP_CUSTOMER_PEMBELIAN A JOIN PT B ON A.KODE_PT=B.KODE JOIN LINK_PT_SBU C ON B.KODE=C.KODE_PT JOIN LINK_SBU_DIVISI D ON C.KODE_SBU=D.KODE_SBU WHERE D.KODE_DIVISI='" & TxtDivisi.Text & "'", {TxtIDCustomer})
        If TxtIDCustomer.Text = "" Then
            MessageBox.Show("Customer Pembelian Untuk Divisi Ini Belum di Setting!" & vbCrLf &
                                        "Silahkan Hubungi Administrator !", "Informasi !", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Toolbar1_Button1.Enabled = False
        Else
            _Toolbar1_Button1.Enabled = True
        End If
    End Sub
    Private Sub txtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
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
                            If Not AmbilDO Then
                                AddRow(dt)
                            End If
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                            Hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Gridview1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()

        If dt.Select("[Kode Barang]<>''").Length > 0 Then
            TxtDivisi.Enabled = False
        Else
            If Not Text.Contains("Edit") Then
                TxtDivisi.Enabled = True
            End If
        End If
    End Sub
    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            End If
            Hitung()
            Urutan()
        End If
    End Sub
    Private Sub AllowEditColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EditColumn As String, ByVal CheckColumn As String)
        On Error Resume Next
        If Len(Gridview.GetFocusedRow(CheckColumn).ToString.Trim) > 0 Then
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = False
        Else
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = True
        End If
    End Sub
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TxtHari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtHari.EditValueChanged, TglPengakuan.EditValueChanged
        On Error Resume Next
        TglJatuhTempo.DateTime = TglPengakuan.DateTime.AddDays(TxtHari.Text)
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

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Pieces") = Math.Round(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Round(CDbl(col("Kuantum")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            Hitung()
        End If
    End Sub

    Function CurrentPromo() As String
        Dim dr = GridView1.GetFocusedDataRow
        Using p As DataTable = SelectCon.execute("SELECT B.NAMA_PROMO from LINK_BARANG_PROMO A JOIN PROMO B ON A.KODE_PROMO=B.KODE WHERE A.ID_BARANG='" & dr("ID Barang") & "' AND '" & Format(TglPengakuan.DateTime, "yyyy-MM-dd") & "' BETWEEN TGL_AWAL AND TGL_AKHIR")
            If p.Rows.Count > 0 Then
                Return p(0)(0)
            End If
        End Using
        Return "(Tanpa Promo)"
    End Function

    Sub CekPromo()
        If TryCast(TBDO.DataSource, DataTable).Rows.Count > 1 Then
            Dim curP = CurrentPromo()
            For Each dr As DataRow In TryCast(TBDO.DataSource, DataTable).Rows
                Using p As DataTable = SelectCon.execute("SELECT B.NAMA_PROMO from LINK_BARANG_PROMO A JOIN PROMO B ON A.KODE_PROMO=B.KODE WHERE A.ID_BARANG='" & dr("ID Barang") & "' AND '" & Format(TglPengakuan.DateTime, "yyyy-MM-dd") & "' BETWEEN TGL_AWAL AND TGL_AKHIR")
                    Dim promo = "(Tanpa Promo)"
                    If p.Rows.Count > 0 Then
                        promo = p(0)(0)
                    End If

                    If curP <> promo Then
                        MessageBox.Show("Barang yang telah diinputkan ada promo " & promo & vbCrLf &
                                        "Tidak dapat digabung dengan promo lain !", "Informasi !", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        GridView1.DeleteRow(GridView1.FocusedRowHandle)
                        Exit Sub
                    End If
                End Using
            Next
        End If
    End Sub

    Private Sub REBEdit_Click(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If

            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA,A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.QTY_DIST", "A.QTY_DIST") & " AS KONV FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR AND C.JENIS='Langganan' LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
                If dt_cari.Rows.Count = 1 Then
                    If dt.Select("[ID Barang]='" & col("Kode Barang") & "' OR [Kode Barang]='" & col("Kode Barang") & "'").Length > 1 Then
                        MsgBox("Barang Sudah Ada !!")
                        col("ID Barang") = ""
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    ElseIf IsDBNull(dt_cari.Rows(0).Item("HARGA")) Then
                        MsgBox("Harga untuk Item ini masih kosong !!")
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
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA,A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.QTY_DIST", "A.QTY_DIST") & " AS KONV FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR AND C.JENIS='Langganan' LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE (A.ID='" & col("ID Barang") & "') " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
                If dt_cari.Rows.Count > 0 Then
                    If IsDBNull(dt_cari.Rows(0).Item("HARGA")) Then
                        MsgBox("Harga untuk Item ini masih kosong !!")
                        col("ID Barang") = ""
                        GridView1.EditingValue = kode
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    End If
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

            CekPromo()
        End If
    End Sub

    Private Sub TxtDiskonQty1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskonQty1.EditValueChanged, TxtDiskonQty1Nominal.EditValueChanged, TxtDiskonReguler.EditValueChanged, TxtDiskonRegulerNominal.EditValueChanged, TxtDiskon1.EditValueChanged, TxtDiskon1Nominal.EditValueChanged, TxtDiskon2.EditValueChanged, TxtDiskon2Nominal.EditValueChanged, TxtDiskon3.EditValueChanged, TxtDiskon3Nominal.EditValueChanged, TxtCashDiskon.EditValueChanged, TxtCashDiskonNominal.EditValueChanged, TxtDiskonQty2.EditValueChanged, TxtDiskonQty2Nominal.EditValueChanged
        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                        Hitung()
                End Select
            End If
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
            TxtSubTotal.Value = Math.Round(Total)
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
            TxtSubTotal.Value = Math.Round(Total)
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
DiskonQty1:             TxtDiskonQty1Nominal.Value = CDbl(dt.Compute("Sum(Kuantum)", "")) * CDbl(TxtDiskonQty1.Value)
                        GoTo DiskonReguler
                    Case TxtDiskonQty1Nominal.Name
                        TxtDiskonQty1.Value = CDbl(TxtDiskonQty1Nominal.Value) / CDbl(dt.Compute("Sum(Kuantum)", ""))
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

        If TxtDiskonQty1.Value = 0 Then
            TxtDiskonQty2.Enabled = True
            TxtDiskonQty2Nominal.Enabled = True
        Else
            TxtDiskonQty2.Enabled = False
            TxtDiskonQty2Nominal.Enabled = False
        End If

        If TxtDiskonQty2.Value = 0 Then
            TxtDiskonQty1.Enabled = True
            TxtDiskonQty1Nominal.Enabled = True
        Else
            TxtDiskonQty1.Enabled = False
            TxtDiskonQty1Nominal.Enabled = False
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

    Private Sub ChkBebasPPN_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkBebasPPN.CheckedChanged
        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Name
                    Case ChkBebasPPN.Name
                        Hitung()
                End Select
            End If
        End If
    End Sub

    Private Sub TxtDiskonQty1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TxtDiskonQty1.MouseUp, TxtDiskonRegulerNominal.MouseUp, TxtDiskonReguler.MouseUp, TxtDiskonQty2Nominal.MouseUp, TxtDiskonQty2.MouseUp, TxtDiskonQty1Nominal.MouseUp, TxtDiskon3Nominal.MouseUp, TxtDiskon3.MouseUp, TxtDiskon2Nominal.MouseUp, TxtDiskon2.MouseUp, TxtDiskon1Nominal.MouseUp, TxtDiskon1.MouseUp, TxtCashDiskonNominal.MouseUp, TxtCashDiskon.MouseUp
        DirectCast(sender, DevExpress.XtraEditors.CalcEdit).SelectAll()
    End Sub

    '------------------------------------------------
    'Rubah Harga
    Private Sub BtnRubahHarga_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnRubahHarga.ItemClick
        Using LoadDataToGrid As New _LoadDataToGrid
            LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='Langganan' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') ORDER BY TGL_PRICE DESC")
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

    Private Sub BtnPilihDO_Click(sender As System.Object, e As System.EventArgs) Handles BtnPilihDO.Click
        Dim kode As String = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_DO_BON_Perwakilan_PO, , TxtDivisi.Text, , , , , , Bagian)
        If kode <> "" Then
            Try
                If dt.Rows(0).Item("ID Barang") = "" Then
                    dt.Clear()
                End If
                If dt.Select("[ID DO]='" & kode & "'").Length > 0 Then
                    MsgBox("Nomor DO sudah dipilih !!")
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            Dim Query As String = Nothing
            If EnumDescription(Bagian).Contains("Supermarket") Then
                Query = "SELECT A.URUTAN [No.],A.ID_BARANG [ID Barang],B.KODE [Kode Barang],B.NAMA [Nama Barang],B.SAT_DIST1 SATUAN,B.QTY_KOLI ISI,A.KOLI AS KOLI,A.QUANTITY/B.QTY_DIST [Kuantum],A.PCS [Pieces],B.QTY_DIST [Konv],B.HARGA_DIST [Harga Satuan],A.DISC [Disc %],A.DISKON_SATUAN [Disc Satuan],ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL,A.ID_TRANSAKSI [ID DO],C.NO_DO [No. DO] FROM V_D_DB_PERW_T_PO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN DELIVERY_ORDER C ON A.ID_TRANSAKSI=C.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & kode & "' ORDER BY A.URUTAN"
            Else
                Query = "SELECT A.URUTAN [No.],A.ID_BARANG [ID Barang],B.KODE [Kode Barang],B.NAMA [Nama Barang],A.SATUAN,A.ISI,A.KOLI,A.QUANTITY [Kuantum],A.PCS [Pieces],A.KONVERSI [Konv],A.HARGA [Harga Satuan],A.DISC [Disc %],A.DISKON_SATUAN [Disc Satuan],ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL,A.ID_TRANSAKSI [ID DO],C.NO_DO [No. DO] FROM V_D_DB_PERW_T_PO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN DELIVERY_ORDER C ON A.ID_TRANSAKSI=C.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & kode & "' ORDER BY A.URUTAN"
            End If

            Using Mydt As DataTable = SelectCon.execute(Query)
                If Mydt.Rows.Count > 0 Then
                    txtKeterangan.Text = txtKeterangan.Text & SelectCon.execute("SELECT A.NO_DO + ' - ' + B.NAMA FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & kode & "'")(0)(0) & vbCrLf
                    For Each dr As DataRow In Mydt.Rows
                        dt.ImportRow(dr)
                        AmbilDO = True
                    Next
                End If
            End Using
            Urutan()
            Hitung()
        End If
    End Sub
End Class

