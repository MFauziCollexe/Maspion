Imports System.ComponentModel

Public MustInherit Class FrmDeliveryOrder
    Protected dt As New DataTable
    Protected DPP As Double
    Private _Status_Edit As Boolean
    Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtNoPO.Enabled = False
                RDPembayaran.Enabled = False
            Else
                TxtNoPO.Enabled = True
                RDPembayaran.Enabled = True
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
            If value = EBagian.Lain_Perwakilan Or value = EBagian.Langganan_Perwakilan Or value = EBagian.Supermarket_Perwakilan Or value = EBagian.Lain_Pusat Then
                TxtIDPO.Visible = False
                TxtNoPO.Visible = False
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Else
                TxtIDPO.Visible = True
                TxtNoPO.Visible = True
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem44.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            GridView1.Columns("Koli PO").Visible = False
            GridView1.Columns("Kuantum PO").Visible = False
            GridView1.Columns("Pcs PO").Visible = False
            GridView1.Columns("Kode Barang").OptionsColumn.AllowFocus = True
        End Set
        Get
            Return EnBagian
        End Get
    End Property

#Region "Shared Sub"
    Protected Jenis As EJenis

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        If RDPembayaran.SelectedIndex = 0 Then
            ShowDevexpressReport(ReportPreview.KeyReport.DO_Kontan, TxtIDTransaksi.Text)
        ElseIf RDPembayaran.SelectedIndex = 1 Then
            ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Order, TxtIDTransaksi.Text)
        End If
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub
    '=============================Untuk Input=============================
    Protected Sub Batal()
        Clean(Me)
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtDiskonReguler.Value = 15
        RDPembayaran.SelectedIndex = -1
        RDJenisPPN.SelectedIndex = 0
        TxtHari.Text = 0
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Dim Filter As String = TxtNamaDivisi.Text
        Filter = Filter & IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(P)", "(" & InisialPerusahaan & ")")
        Filter = Filter & IIf(EnumDescription(Bagian).Contains("Supermarket"), "(SUPER)", "")
        Dim Pusat As String = IIf(EnumDescription(Bagian).Contains("Perwakilan"), "", " AND PEMBAYARAN='" & RDPembayaran.EditValue & "'")
        Dim Super As String = IIf(EnumDescription(Bagian).Contains("Supermarket"), " AND BAGIAN LIKE '%Supermarket%' ", " AND BAGIAN LIKE '%Langganan%' ")
        Using dtGenerate = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE NO_DO LIKE '" & Filter & "%' AND YEAR(TGL_PENGAKUAN)='" & Format(TglPengakuan.EditValue, "yyyy") & "'" & Pusat & Super & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_DO DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = Filter & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'DO','') AS BIGINT)),0) AS ID FROM DELIVERY_ORDER")
            TxtIDTransaksi.Text = "DO" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan(sender As Object, e As System.EventArgs)
        If Empty({TxtKodeApprove, TxtDivisi, TglTransaksi, TglPengakuan, TxtIdSalesman}) Then Exit Sub
        If Bagian.ToString.Contains("Perwakilan") Then
            If Empty(TxtKodeGudang) Then Exit Sub
        End If
        GridView1.CloseEditor()

        If RDPembayaran.SelectedIndex = 1 Then
            If TxtHari.Value <= 0 Then
                MsgBox("Hari untuk Penjualan Kredit masih nol !!!", MsgBoxStyle.Information, "Peringatan")
                Exit Sub
            End If
        End If

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Pieces") = 0 Then
                    MsgBox("Ada Pieces yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl pengakuan yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        'Cek Limit Piutang
        'If RDPembayaran.SelectedIndex = 1 Then
        '    Using dtcekKuota As DataTable = SelectCon.execute("SELECT SISA FROM V_KUOTA_PIUTANG WHERE ID_CUSTOMER='" & TxtKode.Text & "'")
        '        If dtcekKuota.Rows.Count > 0 Then
        '            If CDbl(TxtTotal.Text) > CDbl(dtcekKuota.Rows(0).Item(0)) Then
        '                MsgBox("Total Nominal Melebihi Limit Piutang !!!" & vbCrLf & "Anda Tidak Dapat Melanjutkan Transaksi !!!", MsgBoxStyle.Information)
        '                Exit Sub
        '            End If
        '        End If
        '    End Using
        'End If

        If QuestionInput() = False Then Exit Sub

        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TglPricelist, TxtIDPO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), EnumDescription(Jenis), RdPKP, TxtKodeGudang, ChkBebasPPN, TxtIdSalesman}, "DELIVERY_ORDER") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_DELIVERY_ORDER") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

    '==========================Untuk Edit===============================
    Protected Sub GetData(sender As Object, e As System.EventArgs)
        If TxtIDTransaksi.Text <> "" Then
            TxtDivisi.Enabled = False
            TxtKodeApprove.Enabled = False
            RDPembayaran.Enabled = False

            LoadData.GetData("SELECT [NO_DO] ,[TGL] ,[TGL_PENGAKUAN] ,[TGL_PRICE] ,[ID_PO] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[PEMBAYARAN] ,[TERMS] ,[JATUH_TEMPO] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[PRINT_PKP] ,[GUDANG], [BEBAS_PPN], [SALES] FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TglPricelist, TxtIDPO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, RdPKP, TxtKodeGudang, ChkBebasPPN, TxtIdSalesman})

            Dim Str_MyQuery As String = Nothing
            If TxtIDPO.Text <> "" Then
                Str_MyQuery = "SELECT DISTINCT B.URUTAN,B.ID_BARANG,BB.KODE,BB.NAMA,B.SATUAN,B.ISI,(AA.KOLI-AA.KOLI_T)+B.KOLI,(AA.QUANTITY-AA.QUANTITY_T)+B.QUANTITY,(AA.PCS-AA.PCS_T)+B.PCS,B.KOLI,B.QUANTITY,B.PCS,B.KONVERSI,B.HARGA,B.DISC,B.DISKON_SATUAN,ROUND(B.QUANTITY * (B.HARGA - B.DISKON_SATUAN),2) AS SUBTOTAL FROM (DELIVERY_ORDER A INNER JOIN DETAIL_DELIVERY_ORDER B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI) LEFT JOIN V_D_PO_T_DO AA ON A.ID_PO=AA.ID_TRANSAKSI AND B.ID_BARANG=AA.ID_BARANG LEFT JOIN BARANG BB ON B.ID_BARANG=BB.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN"
                LoadData.GetData(Str_MyQuery)
                LoadData.SetDataDetail(dt, False)
            Else
                Str_MyQuery = "SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,0,0,0,A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL FROM DETAIL_DELIVERY_ORDER A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN"
                LoadData.GetData(Str_MyQuery)
                LoadData.SetDataDetail(dt, True)
            End If
        End If
        Urutan()
        HitungTanpaDiskon()
        Log.Load(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub SimpanEdit(sender As Object, e As System.EventArgs)
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtIdSalesman}) Then Exit Sub
        If Bagian.ToString.Contains("Perwakilan") Then
            If Empty(TxtKodeGudang) Then Exit Sub
        End If
        GridView1.CloseEditor()

        If RDPembayaran.SelectedIndex = 1 Then
            If TxtHari.Value <= 0 Then
                MsgBox("Hari untuk Penjualan Kredit masih nol !!!", MsgBoxStyle.Information, "Peringatan")
                Exit Sub
            End If
        End If

        Using dtcek As DataTable = SelectCon.execute("SELECT STATUS_LUNAS AS BAYAR FROM VI_PAY_KONTAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) = True Then
                    MsgBox("Transaksi Sudah Dalam Proses Payment," & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Payment DO Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_STUFFING FROM STUFFING WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Stuffing, No. Stuffing : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Stuffing Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        ElseIf Bagian = EBagian.Lain_Pusat Or Bagian = EBagian.Langganan_Pusat Or Bagian = EBagian.Supermarket_Pusat Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Nota / SJ, No. Nota/SJ : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Nota / SJ Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        End If


        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Pieces") = 0 Then
                    MsgBox("Ada Pieces yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl pengakuan yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        'Cek Limit Piutang
        'If RDPembayaran.SelectedIndex = 1 Then
        '    Using dtcekKuota As DataTable = SelectCon.execute("SELECT SISA FROM V_KUOTA_PIUTANG WHERE ID_CUSTOMER='" & TxtKode.Text & "'")
        '        If dtcekKuota.Rows.Count > 0 Then
        '            If CDbl(TxtTotal.Text) > CDbl(dtcekKuota.Rows(0).Item(0)) Then
        '                MsgBox("Total Nominal Melebihi Limit Piutang !!!" & vbCrLf & "Anda Tidak Dapat Melanjutkan Transaksi !!!", MsgBoxStyle.Information)
        '                Exit Sub
        '            End If
        '        End If
        '    End Using
        'End If

        If QuestionEdit() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_DO] ,[TGL] ,[TGL_PENGAKUAN] ,[TGL_PRICE] ,[ID_PO] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[PEMBAYARAN] ,[TERMS] ,[JATUH_TEMPO] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME], [PRINT_PKP], [GUDANG], [BEBAS_PPN], [SALES]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TglPricelist, TxtIDPO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), RdPKP, TxtKodeGudang, ChkBebasPPN, TxtIdSalesman}, "DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_DELIVERY_ORDER") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus(sender As Object, e As System.EventArgs)
        Using dtcek As DataTable = SelectCon.execute("SELECT STATUS_LUNAS AS BAYAR FROM VI_PAY_KONTAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) = True Then
                    MsgBox("Transaksi Sudah Dalam Proses Payment," & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Payment DO Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_STUFFING FROM STUFFING WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Stuffing, No. Stuffing : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Stuffing Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        ElseIf Bagian = EBagian.Lain_Pusat Or Bagian = EBagian.Langganan_Pusat Or Bagian = EBagian.Supermarket_Pusat Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Nota / SJ, No. Nota/SJ : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Nota / SJ Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        End If

        If QuestionHapus() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi(sender As Object, e As System.EventArgs)
        Using dtcek As DataTable = SelectCon.execute("SELECT STATUS_LUNAS AS BAYAR FROM VI_PAY_KONTAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) = True Then
                    MsgBox("Transaksi Sudah Dalam Proses Payment," & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Payment DO Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        End Using

        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_STUFFING FROM STUFFING WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Stuffing, No. Stuffing : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Stuffing Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        ElseIf Bagian = EBagian.Lain_Pusat Or Bagian = EBagian.Langganan_Pusat Or Bagian = EBagian.Supermarket_Pusat Then
            Using dtcek As DataTable = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
                If dtcek.Rows.Count > 0 Then
                    MsgBox("Transaksi Sudah Dalam Proses Nota / SJ, No. Nota/SJ : " & dtcek.Rows(0)(0) & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Nota / SJ Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End Using
        End If

        If QuestionBatal() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub
#End Region

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
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
        TglJatuhTempo.DateTime = Format(Now.Date, "dd/MM/yyyy")

        'GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli PO", TypeCode.Decimal, 30, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Kuantum PO", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Pcs PO", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 30, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 50, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    ''' <summary>
    ''' Divisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtDivisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
        AllowGrid()
        'If Not Status_Edit Then
        'Dim Filter As String = TxtNamaDivisi.Text
        'Filter = Filter & IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(P)", "(" & InisialPerusahaan & ")")
        'Filter = Filter & IIf(EnumDescription(Bagian).Contains("Supermarket"), "(SUPER)", "")
        'TxtNoTransaksi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'TxtNoTransaksi.Properties.Mask.EditMask = Filter & "000000"
        'TxtNoTransaksi.Properties.Mask.UseMaskAsDisplayFormat = True
        'If TxtNoTransaksi.EditValue = "" Then TxtNoTransaksi.EditValue = 0
        'End If
    End Sub
    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
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
                            If dt.Rows.Count <= 14 Then
                                AddRow(dt)
                                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                            End If
                            Hitung()
                        End If
                    End If
                End If
                'Case Asc("A") To Asc("Z"), Asc("a") To Asc("z"), Asc("0") To Asc("9"), Asc(","), Asc("."), System.Windows.Forms.Keys.Back
                'e.Handled = False
                'Call REBEdit_Click(sender, e)
        End Select
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            If GridView1.FocusedColumn.FieldName = "Koli" Or GridView1.FocusedColumn.FieldName = "Kuantum" Or GridView1.FocusedColumn.FieldName = "Pieces" Then
                Dim col As DataRow = GridView1.GetDataRow(e.RowHandle)
                Dim stok = CekStok(col("ID Barang"), TxtKodeGudang.Text)
                Dim stuffing = CekStokStuffing(col("ID Barang"), TxtKodeGudang.Text)
                If (stok - stuffing) < col("Pieces") Then
                    GridView1.CloseEditor()
                    MsgBox("Stok Untuk Barang Ini Tidak Mencukupi, Segera Lakukan Order Ke Pabrik !" & vbCrLf & _
                           "Sisa Stok : " & stok.ToString() & " Pieces" & vbCrLf & _
                           "Stuffing : " & stuffing.ToString() & " Pieces", MsgBoxStyle.Information)
                End If
            End If
        End If
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
    End Sub
    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            If TxtIDPO.Text = "" Then
                GridView1.DeleteRow(GridView1.FocusedRowHandle)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                If GridView1.RowCount = 0 Then
                    AddRow(dt)
                    GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                End If
                Hitung()
                Urutan()
            End If
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.Columns("Kuantum PO").Visible Then
            If Val(col("Kuantum")) > col("Kuantum PO") Then
                MsgBox("Kuantum Tidak Boleh Melebihi Kuantum PO !!")
                col("Kuantum") = Microsoft.VisualBasic.Left(col("Kuantum"), Len(col("Kuantum")) - 1)
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Kuantum"), Microsoft.VisualBasic.Left(col("Kuantum"), Len(col("Kuantum")) - 1))
            End If
        End If

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

    Private Sub ReCalc_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles ReCalc.EditValueChanging
        If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
            If GridView1.FocusedColumn.FieldName = "Koli" Or GridView1.FocusedColumn.FieldName = "Kuantum" Or GridView1.FocusedColumn.FieldName = "Pieces" Then
                Dim col As DataRow = GridView1.GetFocusedDataRow
                Dim stok = CekStok(col("ID Barang"), TxtKodeGudang.Text)
                Dim newVal = 0
                If GridView1.FocusedColumn.FieldName = "Koli" Then
                    newVal = e.NewValue * CDbl(col("Isi")) * CDbl(col("Konv"))
                ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
                    newVal = e.NewValue * CDbl(col("Konv"))
                ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
                    newVal = e.NewValue
                End If
                If stok < newVal Then
                    e.Cancel = True
                    e.NewValue = 0
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    GridView1.CloseEditor()
                    MsgBox("Stok Untuk Barang Ini Tidak Mencukupi, Segera Lakukan Order Ke Pabrik !" & vbCrLf & _
                           "Sisa Stok : " & stok.ToString() & " Pieces", MsgBoxStyle.Information)
                End If
            End If
        End If
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

    Private Function CekStokStuffing(Kode As String, Gudang As String) As Integer
        If Gudang = "" Then
            MsgBox("Gudang Masih Kosong !", MsgBoxStyle.Information)
            AlertEmpty(TxtKodeGudang)
            Return 0
        Else
            Using dt = SelectCon.execute("SELECT PCS-PCS_T PCS FROM STUFFING A JOIN V_D_STUFF_T_NOTA B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI WHERE ST=0 AND GUDANG='" & Gudang & "' AND ID_BARANG='" & Kode & "'")
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item(0)
                End If
            End Using
        End If
        Return 0
    End Function

    Private Sub RDPembayaran_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDPembayaran.SelectedIndexChanged
        If RDPembayaran.SelectedIndex = 1 Then
            SetData("SELECT HARI FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtHari})
            TxtCashDiskon.Enabled = True
            TxtCashDiskon.Value = 0
            TxtCashDiskonNominal.Enabled = True
        Else
            TxtHari.Text = 0
            TxtCashDiskon.Enabled = True
            TxtCashDiskon.Value = 5
            TxtCashDiskonNominal.Enabled = True
        End If
        If Status_Edit = False Then
            Generate()
        End If
        AllowGrid()
    End Sub

    Private Sub TxtHari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtHari.EditValueChanged, TglPengakuan.EditValueChanged
        On Error Resume Next
        TglJatuhTempo.DateTime = TglPengakuan.DateTime.AddDays(TxtHari.Text)
        If Not Status_Edit Then
            Generate()
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
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST*A.QTY_KOLI AS ISI ") & " ," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.QTY_DIST", "1") & " AS KONV,C.TGL_AWAL TGL_PRICE FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG " & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR " & IIf(EnumDescription(Bagian).Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
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
                    TglPricelist.DateTime = dt_cari.Rows(0).Item("TGL_PRICE")
                    CekPromo()
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Barang_Divisi, GridView1.EditingValue, _
                              FrmPencarian.TypeButton.Barang, , , TxtDivisi.Text, Format(TglPengakuan.DateTime, "yyyy-MM-dd"))
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
                End If
            End If
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST*A.QTY_KOLI AS ISI ") & " ," & IIf(EnumDescription(Bagian).Contains("Langganan"), "A.QTY_DIST", "1") & " AS KONV,C.TGL_AWAL TGL_PRICE FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG " & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR " & IIf(EnumDescription(Bagian).Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE A.ID='" & col("ID Barang") & "' " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
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
                    TglPricelist.DateTime = dt_cari.Rows(0).Item("TGL_PRICE")
                    CekPromo()
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

    Private Sub RDJenisPPN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPPN.SelectedIndexChanged
        Hitung()
        If RDJenisPPN.SelectedIndex = 0 Then
            ChkBebasPPN.Checked = False
            ChkBebasPPN.Enabled = False
        Else
            ChkBebasPPN.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Cari PO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoPO_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoPO.ButtonClick
        TxtIDPO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Purchase_Order, , , " ", , , , , Bagian)
    End Sub
    Private Sub TxtIDPO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDPO.KeyPress
        If CharKeypress(TxtIDPO, e) Then TxtIDPO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Purchase_Order, , , " ", , , , , Bagian)
    End Sub
    Private Sub TxtIDPO_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDPO.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT [NO_PO] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[PEMBAYARAN] ,[TERMS] ,[JATUH_TEMPO] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN], [KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL], [BEBAS_PPN] FROM PURCHASE_ORDER WHERE ID_TRANSAKSI='" & TxtIDPO.Text & "'")
            LoadData.SetData({TxtNoPO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, RDPembayaran, TxtHari, TglJatuhTempo, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, txtKeterangan, txtKeteranganInternal, ChkBebasPPN})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL FROM V_D_PO_T_DO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDPO.Text & "' AND A.ST=0 ORDER BY URUTAN")
            LoadData.SetDataDetail(dt, False)
            If TxtIDPO.Text <> "" Then _
                SetData("SELECT TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetDataRow(0)("ID Barang") & "' AND HARGA_BARU=" & GridView1.GetDataRow(0)("Harga Satuan") & "", {TglPricelist})
            Urutan()
            HitungTanpaDiskon()
        Else
            Using MYLoadData As New _LoadData
                MYLoadData.GetData("SELECT [NO_PO] FROM PURCHASE_ORDER WHERE ID_TRANSAKSI='" & TxtIDPO.Text & "'")
                MYLoadData.SetData({TxtNoPO})
            End Using
        End If
        If TxtIDPO.Text <> "" Then
            GridView1.Columns("Pcs PO").Visible = True
            GridView1.Columns("Kuantum PO").Visible = True
            GridView1.Columns("Koli PO").Visible = True
            GridView1.Columns("Kode Barang").OptionsColumn.AllowFocus = False
        Else
            GridView1.Columns("Koli PO").Visible = False
            GridView1.Columns("Kuantum PO").Visible = False
            GridView1.Columns("Pcs PO").Visible = False
            GridView1.Columns("Kode Barang").OptionsColumn.AllowFocus = True
        End If
        If Not Status_Edit Then
            Generate()
        End If
    End Sub

    Private Sub TBDO_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBDO.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub
    '------------------------------------------------
    'Rubah Harga
    Private Sub BtnRubahHarga_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnRubahHarga.ItemClick
        Using LoadDataToGrid As New _LoadDataToGrid
            'If SelectCon.execute("SELECT TOP 1 ID FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='" & IIf(EnumDescription(Bagian).Contains("Supermarket"), "Supermarket", "Langganan") & "' AND ID='" & TxtIDCustomer.Text & "'").Rows.Count > 0 Then
            '    LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='" & IIf(EnumDescription(Bagian).Contains("Supermarket"), "Supermarket", "Langganan") & "' AND ID='" & TxtIDCustomer.Text & "' ORDER BY TGL_PRICE DESC")
            'Else
            LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_AWAL TGL_PRICE FROM VI_PRICE_LIST_PROMO WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='" & IIf(EnumDescription(Bagian).Contains("Supermarket"), "Supermarket", "Langganan") & "' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') ORDER BY TGL_AWAL DESC")
            'End If
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
DiskonQty1:             TxtDiskonQty1Nominal.Value = Math.Round(CDbl(dt.Compute("Sum(Kuantum)", "")) * CDbl(TxtDiskonQty1.Value))
                        GoTo DiskonReguler
                    Case TxtDiskonQty1Nominal.Name
                        TxtDiskonQty1.Value = Math.Round(CDbl(TxtDiskonQty1Nominal.Value) / CDbl(dt.Compute("Sum(Kuantum)", "")))
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
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Name
                    Case ChkBebasPPN.Name
                        Hitung()
                End Select
            End If
        End If
    End Sub

    Private Sub AllowGrid()
        If TxtIDPO.Text = "" Then
            If Status_Edit = False Then
                If TxtDivisi.Text = "" Then
                    TxtNoPO.Enabled = True
                    TxtKodeApprove.Enabled = False
                Else
                    TxtNoPO.Enabled = False
                    TxtKodeApprove.Enabled = True
                End If
            End If

            If TxtKodeApprove.Text = "" Then
                TxtDivisi.Enabled = True
                TxtKodeCabang.Enabled = False
            Else
                TxtDivisi.Enabled = False
                TxtKodeCabang.Enabled = True
            End If

            'TxtDivisi.Enabled = True
            'If Bagian = EBagian.Pembelian_Langganan Then
            '    Bagian = EBagian.Langganan_Pusat
            'ElseIf Bagian = EBagian.Pembelian_Supermarket Then
            '    Bagian = EBagian.Supermarket_Pusat
            'End If
        Else
            TxtDivisi.Enabled = False
            'If Bagian = EBagian.Langganan_Pusat Then
            '    Bagian = EBagian.Pembelian_Langganan
            'ElseIf Bagian = EBagian.Supermarket_Pusat Then
            '    Bagian = EBagian.Pembelian_Supermarket
            'End If
        End If

        If TglPengakuan.Text = "" Or TxtDivisi.Text = "" Or TxtKodeApprove.Text = "" Or RDPembayaran.SelectedIndex = -1 Then
            TBDO.Enabled = False
        Else
            TBDO.Enabled = True
        End If
    End Sub
#End Region

    Private Function CekCustomerSBU(id As String, divisi As String) As Boolean
        If CekCustomerKontan(id) Then Return True
        If SelectCon.execute("SELECT * FROM (SELECT DC.LIMIT, KODE_DIVISI, C.ID FROM CORPORATION CR JOIN LINK_CORPORATION_CUSTOMER COR ON CR.KODE=COR.KODE_CORPORATION JOIN CUSTOMER C ON COR.ID_CUSTOMER=C.ID JOIN DETAIL_CORPORATION_LIMITPIUTANG DC ON COR.KODE_CORPORATION=DC.KODE JOIN LINK_SBU_DIVISI D ON DC.KODE_SBU=D.KODE_SBU WHERE CR.STATUS_AKTIF=1 AND C.GROUP_CUSTOMER<>'Supermarket' AND C.SYARAT_PEMBAYARAN_KREDIT=1 UNION SELECT LIMIT, KODE_DIVISI, DC.ID FROM CUSTOMER C JOIN DETAIL_CUSTOMER_LIMITPIUTANG DC ON C.ID=DC.ID JOIN LINK_SBU_DIVISI D ON DC.KODE_SBU=D.KODE_SBU WHERE C.GROUP_CUSTOMER<>'Supermarket' AND C.SYARAT_PEMBAYARAN_KREDIT=1) A WHERE LIMIT > 0 AND ID='" & id & "' AND KODE_DIVISI='" & divisi & "'").Rows.Count > 0 Then
            Return True
        End If
        MsgBox("Customer Ini Tidak Mempunyai Akses Ke Divisi Ini !!", MsgBoxStyle.Information)
        Return False
    End Function

    Private Function CekCustomerKontan(id As String) As Boolean
        If SelectCon.execute("SELECT SYARAT_PEMBAYARAN_KONTAN FROM CUSTOMER WHERE ID='" & id & "'").Rows.Item(0).Item(0) Then
            Return True
        End If
        Return False
    End Function

    'Customer
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , Bagian, TxtDivisi.Text)
        If Bagian <> EBagian.Supermarket_Perwakilan And Bagian <> EBagian.Supermarket_Pusat And Bagian <> EBagian.Pembelian_Supermarket And Bagian <> EBagian.Pembelian_Langganan Then
            If CekCustomerSBU(kode, TxtDivisi.Text) Then
                TxtIDCustomer.Text = kode
            End If
        Else
            TxtIDCustomer.Text = kode
        End If
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then
            Dim kode = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , Bagian, TxtDivisi.Text)
            If Bagian <> EBagian.Supermarket_Perwakilan And Bagian <> EBagian.Supermarket_Pusat And Bagian <> EBagian.Pembelian_Supermarket And Bagian <> EBagian.Pembelian_Langganan Then
                If CekCustomerSBU(kode, TxtDivisi.Text) Then
                    TxtIDCustomer.Text = kode
                End If
            Else
                TxtIDCustomer.Text = kode
            End If
        End If
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        dt.Clear()
        AddRow(dt)
        RDPembayaran.SelectedIndex = -1
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT,NO_NPWP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                TxtAlamatKantor.Text = dtCustomer.Rows(0).Item("ALAMAT_KANTOR")
                TxtAlamatKirim.Text = dtCustomer.Rows(0).Item("LOKASI_PENGIRIMAN")
                'If Status_Edit = False Then
                If dtCustomer.Rows(0).Item("SYARAT_PEMBAYARAN_KREDIT") Then
                    If Not Status_Edit Then RDPembayaran.Enabled = True
                    LblKetPembayaran.Visible = False
                    LBkredit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Else
                    RDPembayaran.Enabled = False
                    RDPembayaran.SelectedIndex = 0
                    LblKetPembayaran.Visible = True
                    LBkredit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                End If
                'End If
                If dtCustomer.Rows(0).Item("NO_NPWP") <> "" Then
                    RdPKP.Enabled = True
                Else
                    RdPKP.Enabled = False
                End If
            Else
                TxtNama.Text = ""
                TxtAlamatKantor.Text = ""
                TxtAlamatKirim.Text = ""
                TxtKodeApprove.Text = ""
            End If
        End Using
        AllowGrid()
    End Sub

    Private Sub TxtDiskonQty1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TxtDiskonQty1.MouseUp, TxtDiskonRegulerNominal.MouseUp, TxtDiskonReguler.MouseUp, TxtDiskonQty2Nominal.MouseUp, TxtDiskonQty2.MouseUp, TxtDiskonQty1Nominal.MouseUp, TxtDiskon3Nominal.MouseUp, TxtDiskon3.MouseUp, TxtDiskon2Nominal.MouseUp, TxtDiskon2.MouseUp, TxtDiskon1Nominal.MouseUp, TxtDiskon1.MouseUp, TxtCashDiskonNominal.MouseUp, TxtCashDiskon.MouseUp
        DirectCast(sender, DevExpress.XtraEditors.CalcEdit).SelectAll()
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

    Private Sub TxtIdSalesman_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtIdSalesman.ButtonClick
        TxtIdSalesman.Text = Search(FrmPencarian.KeyPencarian.Karyawan, , , , , "Salesman")
    End Sub

    Private Sub TxtIdSalesman_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIdSalesman.EditValueChanged
        SetData("SELECT NAMA_USER FROM USERS WHERE ID_USER ='" & TxtIdSalesman.Text & "'", {TxtNamaSalesman})
    End Sub

    Private Sub TxtIdSalesman_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdSalesman.KeyPress
        If CharKeypress(TxtIdSalesman, e) Then TxtIdSalesman.Text = Search(FrmPencarian.KeyPencarian.Karyawan, , , , , "Salesman")
    End Sub

    
End Class

