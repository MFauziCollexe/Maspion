
Public MustInherit Class FrmStuffing
    Protected dt As New DataTable
    Protected Status_Edit As Boolean
    Private _Bagian As EBagian
    Property Bagian As EBagian
        Set(value As EBagian)
            _Bagian = value
            LblTitle.Caption = "Stuffing " & EnumDescription(value)
        End Set
        Get
            Return _Bagian
        End Get
    End Property

#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Stuffing, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        TxtDivisi.Enabled = True
        dt.Clear()
        AddRow(dt)
        Generate()
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT TOP 1 NO_STUFFING FROM STUFFING WHERE NO_STUFFING Like 'ST/" & TxtNamaDivisi.Text & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_STUFFING DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "ST/" & TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'ST','') AS BIGINT)),0) AS ID FROM STUFFING")
            TxtIDTransaksi.Text = "ST" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan()
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan, TxtKodeGudang}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian)}, "STUFFING") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan", "Koli Stuffing", "Qty Stuffing", "Pcs Stuffing", "Konv", "Isi", "No."}, "DETAIL_STUFFING") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        LoadData.GetData("SELECT [NO_STUFFING] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] FROM STUFFING WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS,A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.ISI FROM (STUFFING Z INNER JOIN DETAIL_STUFFING A ON Z.ID_TRANSAKSI=A.ID_TRANSAKSI) INNER JOIN V_D_DB_PERW_T_STUFF B ON Z.ID_DO=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        Log.Load(Me, TxtIDTransaksi.Text)
        Urutan()
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtKodeGudang}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        Using dtcek As DataTable = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE ID_STUFFING='" & TxtIDTransaksi.Text & "' AND BATAL=0")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Transaksi Sudah Dalam Proses Nota/SJ," & vbCrLf & _
                       "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                       "Hapus Nota/SJ Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End Using

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_STUFFING] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "STUFFING", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_STUFFING", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan", "Koli Stuffing", "Qty Stuffing", "Pcs Stuffing", "Konv", "Isi", "No."}, "DETAIL_STUFFING") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("STUFFING", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_STUFFING", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "STUFFING", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Koli DO", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty DO", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs DO", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli Stuffing", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty Stuffing", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs Stuffing", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
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

    Private Sub TxtNoDO_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoDO.ButtonClick
        TxtIDDO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_DO_BON_Perwakilan, , , , , , , , Bagian)
    End Sub

    Private Sub TxtIDNota_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDDO.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT [NO_DO],[TGL] ,[DIVISI] ,[KODE_CUSTOMER] ,[CABANG] ,[ALAMAT_KIRIM], [KETERANGAN_CETAK], KETERANGAN_INTERNAL, GUDANG FROM (SELECT ID_TRANSAKSI,NO_DO ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[KODE_CUSTOMER] ,[CABANG] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK], KETERANGAN_INTERNAL, GUDANG FROM DELIVERY_ORDER WHERE JENIS_DO='Ada Barang'  UNION ALL SELECT ID_TRANSAKSI,NO_BON AS NO_DO,[TGL],[TGL_PENGAKUAN],[DIVISI],[KODE_CUSTOMER] ,[CABANG] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK], KETERANGAN_INTERNAL, GUDANG FROM BON_PESANAN) AS A WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
            LoadData.SetData({TxtNoDO, TglDO, TxtDivisi, TxtIDCustomer, TxtKodeCabang, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal,TxtKodeGudang})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QTY,A.PCS-A.PCS_T AS PCS,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,A.ISI FROM V_D_DB_PERW_T_STUFF A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDO.Text & "' AND A.ST=0")
            LoadData.SetDataDetail(dt, False)
            Urutan()
            CekSemuaStokBarang()
        End If
        On Error Resume Next
        LblGudangDO.Text = "Gudang DO : " & SelectCon.execute("SELECT NAMA_GUDANG FROM DELIVERY_ORDER DO JOIN GUDANG G ON DO.GUDANG=G.KODE WHERE DO.ID_TRANSAKSI='" & TxtIDDO.Text & "'")(0)(0)
    End Sub

    Private Sub TxtNoDO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDO.KeyPress
        If CharKeypress(TxtIDDO, e) Then TxtIDDO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_DO_BON_Perwakilan)
    End Sub

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    ''' <summary>
    ''' Cari Cabang
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli Stuffing" Then
            If Val(col("Koli Stuffing")) > col("Koli DO") Then
                MsgBox("Koli Stuffing Tidak Boleh Melebihi Koli DO !!")
                col("Koli Stuffing") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Stuffing" Then
            If Val(col("Qty Stuffing")) > col("Qty DO") Then
                MsgBox("Qty Stuffing Tidak Boleh Melebihi Qty DO !!")
                col("Qty Stuffing") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Stuffing" Then
            If Val(col("Pcs Stuffing")) > col("Pcs DO") Then
                MsgBox("Pcs Stuffing Tidak Boleh Melebihi Pcs DO !!")
                col("Pcs Stuffing") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli Stuffing" Then
            col("Pcs Stuffing") = Math.Round(CDbl(col("Isi")) * CDbl(col("Koli Stuffing")) * CDbl(col("Konv")))
            col("Qty Stuffing") = Math.Truncate((CDbl(col("Pcs Stuffing")) / CDbl(col("Konv"))))

            'col("Qty Stuffing") = CDbl(col("Isi")) * CDbl(col("Koli Stuffing"))
            'col("Pcs Stuffing") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli Stuffing")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Stuffing" Then
            col("Koli Stuffing") = Math.Truncate((CDbl(col("Qty Stuffing")) / CDbl(col("Isi"))))
            col("Pcs Stuffing") = Math.Truncate(CDbl(col("Qty Stuffing")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Stuffing" Then
            col("Qty Stuffing") = Math.Truncate((CDbl(col("Pcs Stuffing")) / CDbl(col("Konv"))))
            col("Koli Stuffing") = Math.Truncate((CDbl(col("Qty Stuffing")) / CDbl(col("Isi"))))
        End If
    End Sub

    Private Sub ReCalc_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles ReCalc.EditValueChanging
        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            If GridView1.FocusedColumn.FieldName = "Koli Stuffing" Or GridView1.FocusedColumn.FieldName = "Qty Stuffing" Or GridView1.FocusedColumn.FieldName = "Pcs Stuffing" Then
                Dim col As DataRow = GridView1.GetFocusedDataRow
                Dim stok = CekStok(col("ID Barang"), TxtKodeGudang.Text)
                Dim newVal = 0
                If GridView1.FocusedColumn.FieldName = "Koli Stuffing" Then
                    newVal = e.NewValue * CDbl(col("Isi")) * CDbl(col("Konv"))
                ElseIf GridView1.FocusedColumn.FieldName = "Qty Stuffing" Then
                    newVal = e.NewValue * CDbl(col("Konv"))
                ElseIf GridView1.FocusedColumn.FieldName = "Pcs Stuffing" Then
                    newVal = e.NewValue
                End If
                If stok < newVal Then
                    e.Cancel = True
                    e.NewValue = 0
                    col("Koli Stuffing") = 0
                    col("Qty Stuffing") = 0
                    col("Pcs Stuffing") = 0
                    GridView1.CloseEditor()
                    MsgBox("Stok Untuk Barang `" & col("Nama Barang") & "` Tidak Mencukupi !" & vbCrLf & _
                           "Sisa Stok : " & stok.ToString() & " Pieces", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub CekSemuaStokBarang()
        For Each col As DataRow In dt.Rows
            Dim stok = CekStok(col("ID Barang"), TxtKodeGudang.Text)
            If stok < col("Pcs Stuffing") Then
                col("Koli Stuffing") = 0
                col("Qty Stuffing") = 0
                col("Pcs Stuffing") = 0
                GridView1.CloseEditor()
                MsgBox("Stok Untuk Barang `" & col("Nama Barang") & "` Tidak Mencukupi !" & vbCrLf & _
                       "Sisa Stok : " & stok.ToString() & " Pieces", MsgBoxStyle.Information)
            End If
        Next
    End Sub

    Private Function CekStok(Kode As String, Gudang As String) As Integer
        If Gudang = "" Then
            MsgBox("Gudang Masih Kosong !", MsgBoxStyle.Information)
            AlertEmpty(TxtKodeGudang)
            Return 0
        Else
            Using dt = SelectCon.execute("SELECT STOK_PCS FROM V_STOK_BERJALAN WHERE GUDANG='" & Gudang & "' AND ID_BARANG='" & Kode & "'")
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item(0)
                End If
            End Using
        End If
        Return 0
    End Function
End Class


