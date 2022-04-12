
Public MustInherit Class FrmNotaSJ
    Protected dt As New DataTable
    Protected DPP As Double
    Private Diskon3Asli As Double = 0

    Private _Status_Edit As Boolean
    Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtNoDO.Enabled = False
                TxtNoStuffing.Enabled = False
                TxtNoTransaksi.Properties.ReadOnly = True
                TxtNoTransaksi.Properties.Buttons(0).Visible = False
            Else
                TxtNoDO.Enabled = True
                TxtNoStuffing.Enabled = True
                If Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
                    TxtNoTransaksi.Properties.ReadOnly = True
                Else
                    TxtNoTransaksi.Properties.ReadOnly = False
                End If
                TxtNoTransaksi.Properties.Buttons(0).Visible = True
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
            TxtDiskon3.Properties.ReadOnly = False
            TxtDiskon3Nominal.Properties.ReadOnly = False
            TxtDiskon3Nominal.Enabled = True
            If value.ToString.Contains("Perwakilan") Then
                LyStuffing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LyStuffingAsterik.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LyKodeGudang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LyNamaGudang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LyTitipBarang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                TxtNoStuffing.Visible = True
                TxtNoDO.Enabled = False
                GridView1.Columns("Koli Stuffing").Caption = "Koli Stuffing"
                GridView1.Columns("Qty Stuffing").Caption = "Qty Stuffing"
                GridView1.Columns("Pcs Stuffing").Caption = "Pcs Stuffing"
            ElseIf value.ToString.Contains("Pusat") Then
                LyStuffing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LyStuffingAsterik.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LyKodeGudang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LyNamaGudang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LyTitipBarang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                TxtNoStuffing.Visible = False
                TxtNoDO.Enabled = True
                GridView1.Columns("Koli Stuffing").Caption = "Koli D.O."
                GridView1.Columns("Qty Stuffing").Caption = "Qty D.O."
                GridView1.Columns("Pcs Stuffing").Caption = "Pcs D.O."
                TxtNoTransaksi.Properties.Buttons(0).Visible = False
            End If
            If value.ToString.Contains("Supermarket") Then
                ChkSJTanpaHarga.Visible = True
                LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                ChkSJTanpaHarga.Visible = False
                LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            LblTitle.Caption = "Nota / SJ " & EnumDescription(value)
        End Set
        Get
            Return EnBagian
        End Get
    End Property

#Region "Shared Sub"

    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, TxtIDTransaksi.Text)
        If SelectCon.execute("SELECT SJ_TANPA_HARGA FROM NOTA WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")(0)(0) Then
            ShowDevexpressReport(ReportPreview.KeyReport.Surat_Jalan_Super, TxtIDTransaksi.Text)
        End If
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        RDJenisPPN.SelectedIndex = 0
        TxtDivisi.Enabled = True
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        dt.Clear()
        AddRow(dt)
        GenerateAuto()
    End Sub

    Protected Sub GenerateAuto()
        If Not Status_Edit Then
            If Bagian = EBagian.Langganan_Perwakilan Or Bagian = EBagian.Lain_Perwakilan Or Bagian = EBagian.Supermarket_Perwakilan Then
                Dim urut As Short
                Dim MyFormat As String = IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(" & InisialPerusahaan & ")", "")
                Using dtGenerate = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE NO_NOTA LIKE '" & TxtNamaDivisi.Text & MyFormat & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_NOTA DESC")
                    If dtGenerate.Rows.Count = 0 Then
                        urut = 1
                    Else
                        urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                    End If
                    TxtNoTransaksi.Text = TxtNamaDivisi.Text & MyFormat & Format(urut, "000000")
                End Using
            End If
        End If
    End Sub

    Protected Function Generate() As Boolean
        If Status_Edit = False Then
            'Dim urut As Short
            'Dim MyFormat As String = IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(" & InisialPerusahaan & ")", "")
            'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE NO_NOTA LIKE '" & TxtNamaDivisi.Text & MyFormat & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_NOTA DESC")
            '    If dtGenerate.Rows.Count = 0 Then
            '        urut = 1
            '    Else
            '        urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            '    End If
            '    TxtNoTransaksi.Text = TxtNamaDivisi.Text & MyFormat & Format(urut, "000000")
            'End Using

            Using dtGenerate = SelectCon.execute("SELECT NO_NOTA FROM NOTA WHERE NO_NOTA = '" & TxtNoTransaksi.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "'")
                If dtGenerate.Rows.Count > 0 Then
                    MsgBox("Nomor Transaksi " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
                    Return False
                End If
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'NOTA','') AS BIGINT)),0) AS ID FROM NOTA")
                TxtIDTransaksi.Text = "NOTA" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End If
        Return True
    End Function

    Protected Sub Simpan()
        If Empty({TglTransaksi, TglPengakuan, TxtIDDO}) Then Exit Sub
        If EnumDescription(Bagian).Contains("Perwakilan") Then
            If Empty({TxtIDStuffing, TxtKodeGudang}) Then Exit Sub
        End If
        GridView1.CloseEditor()

        If TxtNoTransaksi.Text.Contains("000000") Then
            MsgBox("Nomor Transaksi masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            AlertEmpty(TxtNoTransaksi)
            Exit Sub
        End If

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        'If TxtNoSJPB.Text <> "" Then
        '    Using dtGenerate = SelectCon.execute("SELECT NO_SJPB FROM NOTA WHERE NO_SJPB = '" & TxtNoSJPB.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy"))
        '        If dtGenerate.Rows.Count > 0 Then
        '            MsgBox("Nomor SJPB " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
        '            Exit Sub
        '        End If
        '    End Using
        'End If
        generateSJPB()

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl pengakuan yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If SelectCon.execute("SELECT PEMBAYARAN FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "' AND PEMBAYARAN='Kredit'").Rows.Count > 0 Then
            If TxtIDCustomer.Text <> SelectCon.execute("SELECT CUST_PEMBELIAN FROM PERUSAHAAN")(0)(0) Then
                If SelectCon.execute("SELECT LIMIT_PIUTANG FROM PERUSAHAAN")(0)(0) Then
                    Using dt = SelectCon.execute("SELECT LIMIT, PIUTANG, SISA FROM [F_LIMIT_PIUTANG]('" & TxtIDCustomer.Text & "', '" & TxtDivisi.Text & "')")
                        If (dt.Rows(0).Item("SISA")) < TxtTotal.Value Then
                            MsgBox("Limit Piutang Terlampaui !" & vbCrLf & _
                                   "Limit : Rp " & Format(dt.Rows(0).Item("LIMIT"), "n0") & vbCrLf & _
                                   "Piutang : Rp " & Format(dt.Rows(0).Item("PIUTANG"), "n0"), MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    End Using
                End If
            End If
        End If

        If QuestionInput() = False Then Exit Sub
        If Generate() = False Then Exit Sub
        'MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDStuffing, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, ChkSJTanpaHarga, ChkTitipBarang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), TxtKodeEkspedisi, TxtNoTruk, TxtPengemudi, TxtKepalaGudang, TxtController, RdPKP, TxtNoSJPB, ChkBebasPPN}, "NOTA") = False Then Exit Sub
            'Cek Kredit
            Using dtcek As DataTable = SelectCon.execute("SELECT PEMBAYARAN FROM DELIVERY_ORDER WITH(NOLOCK) WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                If dtcek.Rows.Count > 0 Then
                    If dtcek.Rows(0).Item(0).ToString = "Kredit" Then
                        If SQLServer.InsertHeader({TxtIDCustomer, TxtIDTransaksi, TxtNoTransaksi, ToSyntax("NULL"), TglPengakuan, TxtTotal, periode}, "LOG_PIUTANG", "[ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]") = False Then Exit Sub
                    End If
                End If
            End Using
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            If EnumDescription(Bagian).Contains("Perwakilan") Then
                If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pcs Nota"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            End If
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
                MyLoadData.GetData("SELECT [NO_NOTA] ,[NO_REF] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_STUFFING] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[SJ_TANPA_HARGA] ,[TITIP] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[KODE_EKSPEDISI] ,[NO_TRUK], [PENGEMUDI], [KEPALA_GUDANG], [CONTROLLER], [PRINT_PKP] ,[NO_SJPB] ,[BEBAS_PPN] FROM NOTA WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
                MyLoadData.SetData({TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDStuffing, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, ChkSJTanpaHarga, ChkTitipBarang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, TxtKodeEkspedisi, TxtNoTruk, TxtPengemudi, TxtKepalaGudang, TxtController, RdPKP, TxtNoSJPB, ChkBebasPPN})
                Diskon3Asli = TxtDiskon3Nominal.Value

                Dim Str_MyQuery As String = Nothing
                If EnumDescription(Bagian).Contains("Perwakilan") Then
                    Str_MyQuery = "SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS,A.KOLI,A.QUANTITY,A.PCS,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM (NOTA AA INNER JOIN DETAIL_NOTA A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_STUFF_T_NOTA B ON AA.ID_STUFFING=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN"
                ElseIf EnumDescription(Bagian).Contains("Pusat") Then
                    Str_MyQuery = "SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS,A.KOLI,A.QUANTITY,A.PCS,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM (NOTA AA INNER JOIN DETAIL_NOTA A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_DB_PUSAT_T_NOTA B ON AA.ID_DO=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN"
                End If
                MyLoadData.GetData(Str_MyQuery)
                MyLoadData.SetDataDetail(dt, False)
                Urutan()
                'Hitung()
                HitungTanpaDiskon()
                Log.Load(Me, TxtIDTransaksi.Text)
            End Using
            If ChkSJTanpaHarga.Checked Then ChkSJTanpaHarga.Enabled = False
        End If
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TglTransaksi, TglPengakuan, TxtIDDO}) Then Exit Sub
        If EnumDescription(Bagian).Contains("Perwakilan") Then
            If Empty(TxtIDStuffing) Then Exit Sub
        End If
        GridView1.CloseEditor()
        If TxtNoSJPB.Text <> "" Then
            Using dtGenerate = SelectCon.execute("SELECT NO_SJPB FROM NOTA WHERE NO_SJPB = '" & TxtNoSJPB.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND ID_TRANSAKSI<>'" & TxtIDTransaksi.Text & "'")
                If dtGenerate.Rows.Count > 0 Then
                    MsgBox("Nomor SJPB " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
                    Exit Sub
                End If
            End Using
        End If

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl pengakuan yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_NOTA] ,[NO_REF] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_STUFFING] ,[ID_DO] ,[NO_DO] ,[TGL_DO] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[CABANG] ,[ALAMAT_KIRIM] ,[GUDANG] ,[SJ_TANPA_HARGA] ,[TITIP] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[KODE_EKSPEDISI] ,[NO_TRUK] ,[MDUSER] ,[MDTIME] ,[PENGEMUDI], [KEPALA_GUDANG], [CONTROLLER] ,[PRINT_PKP] ,[NO_SJPB] ,[BEBAS_PPN]", {TxtNoTransaksi, TxtNoRef, TglTransaksi, TglPengakuan, TxtIDStuffing, TxtIDDO, TxtNoDO, TglDO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, ChkSJTanpaHarga, ChkTitipBarang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, TxtKodeEkspedisi, TxtNoTruk, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), TxtPengemudi, TxtKepalaGudang, TxtController, RdPKP, TxtNoSJPB, ChkBebasPPN}, "NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Cek Kredit
            Using dtcek As DataTable = SelectCon.execute("SELECT PEMBAYARAN FROM DELIVERY_ORDER WITH(NOLOCK) WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                If dtcek.Rows.Count > 0 Then
                    If dtcek.Rows(0).Item(0).ToString = "Kredit" Then
                        If SQLServer.Delete("LOG_PIUTANG", "ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
                        If SQLServer.InsertHeader({TxtIDCustomer, TxtIDTransaksi, TxtNoTransaksi, ToSyntax("NULL"), TglPengakuan, TxtTotal, periode}, "LOG_PIUTANG", "[ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]") = False Then Exit Sub
                    End If
                End If
            End Using
            'Detail
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli Nota", "Qty Nota", "Satuan", "Konv", "Pcs Nota", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_NOTA") = False Then Exit Sub
            If EnumDescription(Bagian).Contains("Perwakilan") Then
                If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
                If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pcs Nota"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            End If
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
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("LOG_PIUTANG", "ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("LOG_PIUTANG", "ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
        InitGrid.AddColumnGrid("Koli Stuffing", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Stuffing", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Stuffing", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli Nota", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty Nota", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs Nota", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
        GridView1.FocusedColumn = GridView1.Columns(0)
    End Sub

    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
        'TxtNoRef.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'TxtNoRef.Properties.Mask.EditMask = TxtNamaDivisi.Text & "000000"
        'TxtNoRef.Properties.Mask.UseMaskAsDisplayFormat = True
        Dim MyFormat As String = IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(" & InisialPerusahaan & ")", "")
        TxtNoTransaksi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        TxtNoTransaksi.Properties.Mask.EditMask = TxtNamaDivisi.Text & MyFormat & "000000"
        TxtNoTransaksi.Properties.Mask.UseMaskAsDisplayFormat = True
        If TxtNoTransaksi.EditValue = "" Then TxtNoTransaksi.EditValue = 0
        GenerateAuto()
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
    ''' <summary>
    ''' Cari No. Stuffing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoStuffing_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoStuffing.ButtonClick
        TxtIDStuffing.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Stuffing, , , , , , , , Bagian)
    End Sub
    Private Sub TxtNoStuffing_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoStuffing.KeyPress
        If CharKeypress(TxtIDStuffing, e) Then TxtIDStuffing.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Stuffing, , , , , , , , Bagian)
    End Sub
    Private Sub TxtIDStuffing_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDStuffing.EditValueChanged
        Application.DoEvents()
        SetData("SELECT A.ID_DO, A.NO_STUFFING, B.CABANG, B.ALAMAT_KIRIM, A.GUDANG, B.KETERANGAN_CETAK, B.KETERANGAN_INTERNAL FROM STUFFING A JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & TxtIDStuffing.Text & "'", {TxtIDDO, TxtNoStuffing, TxtKodeCabang, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal})
        TxtKodeGudang.Enabled = False
        If Status_Edit = False Then
            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT NO_DO,TGL_PENGAKUAN,DIVISI,JENIS_PPN,KODE_CUSTOMER,KODE_APPROVE,[DISC_QTY],[DISC_REG],[DISC_1],[DISC_2],[DISC_3],[CASH_DISC],[DISC_QTY1],[BEBAS_PPN], SUBTOTAL FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                MyLoadData.SetData({TxtNoDO, TglDO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtDiskonQty1, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon, TxtDiskonQty2, ChkBebasPPN, TxtSubTotal})
                Dim SUBTOTAL_DB = TxtSubTotal.Value

                MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM V_D_STUFF_T_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDStuffing.Text & "' AND A.ST=0 ORDER BY URUTAN")
                MyLoadData.SetDataDetail(dt, False)
                Urutan()
                Hitung()

                'CEK DATA PARSIAL
                If Math.Abs(TxtSubTotal.Value - SUBTOTAL_DB) < 1000 Then
                    MyLoadData.GetData("SELECT DISC_QTY_NOMINAL, DISC_REG_NOMINAL, DISC_1_NOMINAL, DISC_2_NOMINAL, DISC_3_NOMINAL, CASH_DISC_NOMINAL, DISC_QTY_NOMINAL1, DPP, PPN FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                    MyLoadData.SetData({TxtDiskonQty1Nominal, TxtDiskonRegulerNominal, TxtDiskon1Nominal, TxtDiskon2Nominal, TxtDiskon3Nominal, TxtCashDiskonNominal, TxtDiskonQty2Nominal, TxtDPP, TxtPPN})
                    DPP = TxtDPP.Value
                    TxtTotal.Text = DPP + CDbl(TxtPPN.Value)
                End If
            End Using
        End If
        On Error Resume Next
        GridView1.FocusedRowHandle = 0
    End Sub
    ''' <summary>
    ''' Cari Nomor DO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoDO_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoDO.ButtonClick
        TxtIDDO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_DO_BON_Pusat, , , , , , , , Bagian)
    End Sub
    Private Sub TxtNoDO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDO.KeyPress
        If CharKeypress(TxtIDDO, e) Then TxtIDDO.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_DO_BON_Pusat, , , , , , , , Bagian)
    End Sub
    Private Sub TxtIDDO_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDDO.EditValueChanged
        If Status_Edit = False Then
            If EnumDescription(Bagian).Contains("Pusat") Then
                Using MyLoadData As New _LoadData
                    MyLoadData.GetData("SELECT NO_DO,TGL_PENGAKUAN,DIVISI,JENIS_PPN,KODE_CUSTOMER,KODE_APPROVE,CABANG,ALAMAT_KIRIM,[DISC_QTY],[DISC_REG],[DISC_1],[DISC_2],[DISC_3],[CASH_DISC],[DISC_QTY1],KETERANGAN_CETAK,KETERANGAN_INTERNAL,BEBAS_PPN, SUBTOTAL FROM (SELECT ID_TRANSAKSI, NO_DO,TGL_PENGAKUAN,DIVISI,JENIS_PPN,KODE_CUSTOMER,KODE_APPROVE,CABANG,ALAMAT_KIRIM,[DISC_QTY],[DISC_REG],[DISC_1],[DISC_2],[DISC_3],[CASH_DISC],[DISC_QTY1],KETERANGAN_CETAK,KETERANGAN_INTERNAL,BEBAS_PPN, SUBTOTAL FROM DELIVERY_ORDER UNION ALL SELECT ID_TRANSAKSI, NO_DO,TGL_PENGAKUAN,DIVISI,JENIS_PPN,KODE_CUSTOMER,KODE_APPROVE,CABANG,ALAMAT_KIRIM,[DISC_QTY],[DISC_REG],[DISC_1],[DISC_2],[DISC_3],[CASH_DISC],[DISC_QTY1],KETERANGAN_CETAK,KETERANGAN_INTERNAL,BEBAS_PPN, SUBTOTAL FROM BON_PESANAN ) Z WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                    MyLoadData.SetData({TxtNoDO, TglDO, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtKodeCabang, TxtAlamatKirim, TxtDiskonQty1, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon, TxtDiskonQty2, txtKeterangan, txtKeteranganInternal, ChkBebasPPN, TxtSubTotal})
                    Diskon3Asli = TxtDiskon3Nominal.Value
                    Dim SUBTOTAL_DB = TxtSubTotal.Value

                    MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,0,0,0,A.HARGA,A.DISC,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)),A.KONVERSI,A.ISI FROM V_D_DB_PUSAT_T_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDO.Text & "' AND A.ST=0 ORDER BY URUTAN")
                    MyLoadData.SetDataDetail(dt, False)
                    Urutan()
                    Hitung()

                    'CEK DATA PARSIAL
                    If Math.Abs(TxtSubTotal.Value - SUBTOTAL_DB) < 1000 Then
                        MyLoadData.GetData("SELECT ID_TRANSAKSI, DISC_QTY_NOMINAL, DISC_REG_NOMINAL, DISC_1_NOMINAL, DISC_2_NOMINAL, DISC_3_NOMINAL, CASH_DISC_NOMINAL, DISC_QTY_NOMINAL1, DPP, PPN FROM (SELECT ID_TRANSAKSI, DISC_QTY_NOMINAL, DISC_REG_NOMINAL, DISC_1_NOMINAL, DISC_2_NOMINAL, DISC_3_NOMINAL, CASH_DISC_NOMINAL, DISC_QTY_NOMINAL1, DPP, PPN FROM DELIVERY_ORDER UNION ALL SELECT ID_TRANSAKSI, DISC_QTY_NOMINAL, DISC_REG_NOMINAL, DISC_1_NOMINAL, DISC_2_NOMINAL, DISC_3_NOMINAL, CASH_DISC_NOMINAL, DISC_QTY_NOMINAL1, DPP, PPN FROM BON_PESANAN ) Z WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                        MyLoadData.SetData({TxtDiskonQty1Nominal, TxtDiskonRegulerNominal, TxtDiskon1Nominal, TxtDiskon2Nominal, TxtDiskon3Nominal, TxtCashDiskonNominal, TxtDiskonQty2Nominal, TxtDPP, TxtPPN})
                        DPP = TxtDPP.Value
                        TxtTotal.Text = DPP + CDbl(TxtPPN.Value)
                    End If
                End Using
            End If

            Using MyLoadData As New _LoadData
                MyLoadData.GetData("SELECT PRINT_PKP FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDDO.Text & "'")
                MyLoadData.SetData({RdPKP})
            End Using
            On Error Resume Next
            GridView1.FocusedRowHandle = 0
        End If
    End Sub

    ''' <summary>
    ''' Cari Ekspedisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtKodeEkspedisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeEkspedisi.ButtonClick
        TxtKodeEkspedisi.Text = Search(FrmPencarian.KeyPencarian.Ekspedisi)
    End Sub
    Private Sub TxtKodeEkspedisi_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeEkspedisi.EditValueChanged
        SetData("SELECT NAMA FROM EKSPEDISI WHERE KODE='" & TxtKodeEkspedisi.Text & "'", {TxtNamaEkspedisi})
    End Sub
    Private Sub TxtKodeEkspedisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeEkspedisi.KeyPress
        If CharKeypress(TxtKodeEkspedisi, e) Then
            TxtKodeEkspedisi.Text = Search(FrmPencarian.KeyPencarian.Ekspedisi)
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

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        Dim capcol As String = IIf(EnumDescription(Bagian).Contains("Perwakilan"), "Stuffing", "D.O.")
        If GridView1.FocusedColumn.FieldName = "Koli Nota" Then
            If Val(col("Koli Nota")) > col("Koli Stuffing") Then
                If EnumDescription(Bagian).Contains("Pusat") Then
                    If MessageBox.Show("Koli Nota Melebihi Koli " & capcol & ", Apakah anda ingin melanjutkan ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        col("Koli Nota") = 0
                        GridView1.EditingValue = 0
                        GridView1.RefreshEditor(True)
                    End If
                Else
                    MsgBox("Koli Nota Tidak Boleh Melebihi Koli " & capcol & " !!")
                    col("Koli Nota") = 0
                    GridView1.EditingValue = 0
                    GridView1.RefreshEditor(True)
                End If
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Nota" Then
            If Val(col("Qty Nota")) > col("Qty Stuffing") Then
                If EnumDescription(Bagian).Contains("Pusat") Then
                    If MessageBox.Show("Qty Nota Melebihi Qty " & capcol & ", Apakah anda ingin melanjutkan ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        col("Qty Nota") = 0
                        GridView1.EditingValue = 0
                        GridView1.RefreshEditor(True)
                    End If
                Else
                    MsgBox("Qty Nota Tidak Boleh Melebihi Qty " & capcol & " !!")
                    col("Qty Nota") = 0
                    GridView1.EditingValue = 0
                    GridView1.RefreshEditor(True)
                End If
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Nota" Then
            If Val(col("Pcs Nota")) > col("Pcs Stuffing") Then
                If EnumDescription(Bagian).Contains("Pusat") Then
                    If MessageBox.Show("Pcs Nota Melebihi Pcs " & capcol & ", Apakah anda ingin melanjutkan ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        col("Pcs Nota") = 0
                        GridView1.EditingValue = 0
                        GridView1.RefreshEditor(True)
                    End If
                Else
                    MsgBox("Pcs Nota Tidak Boleh Melebihi Pcs " & capcol & " !!")
                    col("Pcs Nota") = 0
                    GridView1.EditingValue = 0
                    GridView1.RefreshEditor(True)
                End If
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli Nota" Then
            col("Pcs Nota") = Math.Round(CDbl(col("Isi")) * CDbl(col("Koli Nota")) * CDbl(col("Konv")))
            col("Qty Nota") = Math.Truncate((CDbl(col("Pcs Nota")) / CDbl(col("Konv"))))

            'col("Qty Nota") = CDbl(col("Isi")) * CDbl(col("Koli Nota"))
            'col("Pcs Nota") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli Nota")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Qty Nota" Then
            col("Koli Nota") = Math.Truncate((CDbl(col("Qty Nota")) / CDbl(col("Isi"))))
            col("Pcs Nota") = Math.Truncate(CDbl(col("Qty Nota")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs Nota" Then
            col("Qty Nota") = Math.Truncate((CDbl(col("Pcs Nota")) / CDbl(col("Konv"))))
            col("Koli Nota") = Math.Truncate((CDbl(col("Qty Nota")) / CDbl(col("Isi"))))
            Hitung()
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

    Private Sub TxtDiskon3Nominal_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TxtDiskon3Nominal.EditValueChanging
        'Dim selisih As Double = Diskon3Asli - CDbl(Replace(e.NewValue, ".", ","))
        'If selisih > 100 Or selisih < -100 Then
        '    MsgBox("Diskon yang diinputkan tidak boleh lebih dari 1 rupiah !")
        '    e.Cancel = True
        'End If
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
#End Region

    Private Sub TglPengakuan_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TglPengakuan.EditValueChanged
        GenerateAuto()
    End Sub

    Private Sub TxtNoTransaksi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoTransaksi.ButtonClick
        GenerateAuto()
    End Sub

    Sub generateSJPB()
        If ChkSJTanpaHarga.Checked Then
            Dim urut As Short
            Using dtGenerate = SelectCon.execute("SELECT MAX(CAST(NO_SJPB AS BIGINT)) NO_SJPB FROM NOTA WHERE YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND BAGIAN LIKE '%Supermarket%'")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoSJPB.Text = Format(urut, "000000")
            End Using
        Else
            TxtNoSJPB.Text = ""
        End If
    End Sub

    Private Sub ChkSJTanpaHarga_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSJTanpaHarga.CheckedChanged
        generateSJPB()
    End Sub
End Class


