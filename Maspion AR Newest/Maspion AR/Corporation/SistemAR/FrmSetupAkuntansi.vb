Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class FrmSetupAkuntansi

    Private Sub InputGudang_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F4
                _Toolbar1_Button3.PerformClick()
        End Select
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub TxtKode_Click(sender As ButtonEdit, e As System.EventArgs)
        sender.Text = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
    End Sub
    Private Sub TxtKode_EditValueChanged(sender As ButtonEdit, e As System.EventArgs)
        On Error Resume Next
        Dim NamaTxt = Replace(sender.Name, "Kode", "Nama")
        Dim info As System.Reflection.FieldInfo =
            Me.GetType().GetField("_" & NamaTxt,
                System.Reflection.BindingFlags.NonPublic Or
                System.Reflection.BindingFlags.Instance Or
                System.Reflection.BindingFlags.Public Or
                System.Reflection.BindingFlags.IgnoreCase)
        Dim TxtNama = CType(info.GetValue(Me), Control)

        SetData("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & sender.Text & "'", {TxtNama})
    End Sub

    Private Sub BindHandler(ByRef TxtKode() As ButtonEdit)
        For Each Txt In TxtKode
            AddHandler Txt.Click, AddressOf TxtKode_Click
            AddHandler Txt.EditValueChanged, AddressOf TxtKode_EditValueChanged
        Next
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As Object, e As EventArgs) Handles _Toolbar1_Button1.Click
        If QuestionInput() = False Then Exit Sub

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_PERWAKILAN", TxtKodePiutangPerw}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CASH_PERWAKILAN", TxtKodeCashPerw}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_PERWAKILAN", TxtKodeCadanganPerw}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"UCF_PERWAKILAN", TxtKodeUCFPerw}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_PERWAKILAN", TxtKodePersediaanPerw}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"DIVISI_UCF_SUPERMARKET", TxtKodeDivisiSupermarket}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PIUTANG_PUSKON", TxtKodePiutangPusKon}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CASH_PUSKON", TxtKodeCashPusKon}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_PUSKON", TxtKodeCadanganPusKon}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"UCF_PUSKON", TxtKodeUCFPusKon}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_PUSKON", TxtKodePersediaanPusKon}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PIUTANG_PUSKRE", TxtKodePiutangPusKre}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CASH_PUSKRE", TxtKodeCashPusKre}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_PUSKRE", TxtKodeCadanganPusKre}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"UCF_PUSKRE", TxtKodeUCFPusKre}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_PUSKRE", TxtKodePersediaanPusKre}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PERWAKILAN", TxtKodePerwakilan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"DISC_TAMBAH_SP", TxtKodeTambahDisSPPT}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"DISC_TAMBAH_DST", TxtKodeTambahDisDSTPT}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PERSEDIAAN_PWPB", TxtKodePersediaanPWPB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_PWPB", TxtKodeCadanganDiskonPWPB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_PUPB", TxtKodePersediaanPUPB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_PUPB", TxtKodeCadanganDiskonPUPB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"KLAIM_EKSPEDISI", TxtKodeKlaimEkspedisiPUPB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PERSEDIAAN_RETUR_JUAL", TxtKodePersediaanReturJual}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_DAGANG_RJ", TxtKodePiutangDagangRetur}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_RETUR_JUAL", TxtKodeCadanganDiskonReturJual}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            '            returbeli
            If SQLServer.InsertHeader({"PIUTANG_RETUR_BELI_UCF", TxtKodePiutangReturBeliUCF}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_RETUR_BELI_PW", TxtKodePersediaanReturBeliPerwakilan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"CADANGAN_RETUR_BELI", TxtKodeCadanganDiskonRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PIUTANG_RETUR_BELI_PUSAT", TxtKodePiutangReturBeliKantorPusat}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"HUTANG_RETUR_BELI_PW", TxtKodeHutangReturBeliPerwakilan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"PERSEDIAAN_RETUR_BELI_PUSAT", TxtKodePersediaanReturBeliKantorPusat}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"HUTANG_RETUR_BELI_UCF", TxtKodeHutangReturBeliUCF}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            'pelunasan retur beli
            If SQLServer.InsertHeader({"HUTANG_PUSAT_PRB", TxtKodeHutangPSPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"HUTANG_UCF_PRB", TxtKodeHutangUCFPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PERSEDIAAN_PUSAT_PRB", TxtKodePersediaanPusatPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_RETUR_PUSAT_PRB", TxtKodePiutangReturPSPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_UCF_PRB", TxtKodePiutangUCFPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"SELISIH_HARGA_PUSAT_PRB", TxtKodeSelisihHargaPSPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"SELISIH_HARGA_PW_PRB", TxtKodeSelisihHargaPWPRB}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"HNDI_PW_KONTAN", TxtKodeHNDIPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"HNDI_UCF_PW_KONTAN", TxtKodeHNDIUCFPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_DAGANG_UT_PW_KONTAN_D", TxtKodePiutangDagangUTPWKontanDebet}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_DAGANG_UT_PW_KONTAN_K", TxtKodePiutangDagangUTPWKontanKredit}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_GIRO_PW_KONTAN", TxtKodePiutangGiroPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PNDI_PW_KONTAN", TxtKodePNDIPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PNDI_UCF_PW_KONTAN", TxtKodePNDIUCFPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PNDI_UCF_SBU_KONTAN", TxtKodePNDIUCFSBUKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"UM_PW_KONTAN", TxtKodeUMPWKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"KAS_MASUK_KONTAN", TxtKodeKasMasukKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"BANK_MASUK_KONTAN", TxtKodeBankMasukKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub

            If SQLServer.InsertHeader({"BANK_MASUK_SBU_KONTAN", TxtKodeBankMasukSBUDOKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"KAS_MASUK_SBU_KONTAN", TxtKodeKasMasukSBUDOKontan}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            If SQLServer.InsertHeader({"PIUTANG_GIRO_SBU_KONTAN", TxtKodePiutangGiroSBU}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub


            'SAVE DETAIL
            For Each dr As DataRow In dtDivisiUntukJurnalUCF.Rows
                If SQLServer.InsertHeader({"DIVISI_UCF_" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            For Each dr As DataRow In dtDivisiUCFPT.Rows
                If SQLServer.InsertHeader({"UCF_PT_" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            For Each dr As DataRow In dtDivisiuntukjurnalpembelianpw.Rows
                If SQLServer.InsertHeader({"DIVISI_PEMBELIAN_PERWAKILAN_" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            For Each dr As DataRow In dtDivisiuntukjurnalpusatpw.Rows
                If SQLServer.InsertHeader({"DIVISI_PEMBELIAN_PUSAT_PERWAKILAN_" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next

            For Each dr As DataRow In dtDivisiUntukJurnalUCFRPB.Rows
                If SQLServer.InsertHeader({"DIVISI_UCF_PELUNASAN_RETUR" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            For Each dr As DataRow In dtDivisiUntukJurnalUCFKONTAN.Rows
                If SQLServer.InsertHeader({"DIVISI_UCF_KONTAN" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            For Each dr As DataRow In dtdivisiuntukjurnalSBUpengembalian.Rows
                If SQLServer.InsertHeader({"PENGEMBALIAN_PT_" & dr.Item("Kode"), ToObject(dr.Item("Kode Acc"))}, "AR_SETUP_AKUNTANSI") = False Then Exit Sub
            Next
            SQLServer.EndTransaction()
        End Using

    End Sub

    Private dtDivisiUntukJurnalUCF As New DataTable
    Private dtDivisiuntukjurnalpembelianpw As New DataTable
    Private dtDivisiuntukjurnalpusatpw As New DataTable
    Private dtDivisiUntukJurnalUCFRPB As New DataTable
    Private dtDivisiUntukJurnalUCFKONTAN As New DataTable
    Private dtdivisiuntukjurnalSBUpengembalian As New DataTable
    Private Sub loadDivisiUntukJurnalUCF()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBDivisiUntukJurnalUCF, GridView1, dtDivisiUntukJurnalUCF)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'DIVISI_UCF_', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'DIVISI_UCF_%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiUntukJurnalUCF, False)
        GridView1.FocusedRowHandle = 0
    End Sub

    Private Sub loadDivisiUntukJurnalUCFPelunasanRetur()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RepoBtnCari4)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(GCPelunasanReturUCF, GridView5, dtDivisiUntukJurnalUCFRPB)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'DIVISI_UCF_PELUNASAN_RETUR', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'DIVISI_UCF_PELUNASAN_RETUR%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiUntukJurnalUCFRPB, False)
        GridView5.FocusedRowHandle = 0
    End Sub
    Private Sub loadDivisiUntukJurnalUCFKontan()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit6)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBDetailSBUKontan, GridView11, dtDivisiUntukJurnalUCFKONTAN)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'DIVISI_UCF_KONTAN', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'DIVISI_UCF_KONTAN%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiUntukJurnalUCFKONTAN, False)
        GridView11.FocusedRowHandle = 0
    End Sub
    Private Sub loadDivisiUntukJurnalPembelianPW()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit3)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBDivisiJurnalNotaPembelianPW, GridView3, dtDivisiuntukjurnalpembelianpw)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'DIVISI_PEMBELIAN_PERWAKILAN_', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'DIVISI_PEMBELIAN_PERWAKILAN_%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiuntukjurnalpembelianpw, False)
        GridView3.FocusedRowHandle = 0
    End Sub
    Private Sub loadDivisiUntukJurnalPusatPW()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit4)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBHutangDagangAfiliasiDivisi, GridView4, dtDivisiuntukjurnalpusatpw)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'DIVISI_PEMBELIAN_PUSAT_PERWAKILAN_', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'DIVISI_PEMBELIAN_PUSAT_PERWAKILAN_%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiuntukjurnalpusatpw, False)
        GridView4.FocusedRowHandle = 0
    End Sub
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging, GridView8.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub RBEdit_Click(sender As Object, e As EventArgs) Handles RBEdit.Click, RBEdit.KeyUp
        Dim dr = GridView1.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView1.CloseEditor()
        GridView1.BestFitColumns()
    End Sub

    Private Sub RBEdit3_Click(sender As Object, e As EventArgs) Handles RBEdit3.Click, RBEdit3.KeyUp
        Dim dr = GridView3.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView3.CloseEditor()
        GridView3.BestFitColumns()
    End Sub

    Private Sub RBEdit4_Click(sender As Object, e As EventArgs) Handles RBEdit4.Click, RBEdit4.KeyUp
        Dim dr = GridView4.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView4.CloseEditor()
        GridView4.BestFitColumns()
    End Sub


    Private dtDivisiUCFPT As New DataTable
    Private Sub loadDivisiDiskonTambahPT()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit2)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBDivisiUCFPT, GridView2, dtDivisiUCFPT)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'UCF_PT_', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'UCF_PT_%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisiUCFPT, False)
        GridView2.FocusedRowHandle = 0
    End Sub

    Private Sub loadDivisiPengembalianSBU()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Kode Acc", TypeCode.String, 25,,,,, RBEdit2)
        InitGrid.AddColumnGrid("Nama Acc", TypeCode.String, 50, False)
        InitGrid.EndInit(TBDivisiUCFPT, GridView2, dtDivisiUCFPT)

        LoadData.GetData("SELECT DISTINCT D.KODE, D.NAMA, ISNULL(C.KODE_PERKIRAAN, '') KODE_ACC, ISNULL(C.NAMA_PERKIRAAN, '') NAMA_ACC 
        FROM DIVISI D LEFT JOIN (SELECT REPLACE(NAMA, 'PENGEMBALIAN_PT_', '') KODE, ST.KODE_PERKIRAAN, ACC.NAMA_PERKIRAAN 
			        FROM AR_SETUP_AKUNTANSI ST LEFT JOIN AR_KODE_PERKIRAAN ACC ON ST.KODE_PERKIRAAN=ACC.KODE_PERKIRAAN 
			        WHERE NAMA LIKE 'PENGEMBALIAN_PT_%') C ON D.KODE=C.KODE
        WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtdivisiuntukjurnalSBUpengembalian, False)
        GridView12.FocusedRowHandle = 0
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging, GridView7.CellValueChanging
        SetDataTable(sender, e)
    End Sub
    Private Sub RBEdit2_Click(sender As Object, e As EventArgs) Handles RBEdit2.Click, RBEdit2.KeyUp
        Dim dr = GridView2.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView2.CloseEditor()
        GridView2.BestFitColumns()
    End Sub

    Private Sub FrmSetupAkuntansi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        BindHandler({TxtKodePiutangPerw, TxtKodeCashPerw, TxtKodeCadanganPerw, TxtKodeUCFPerw, TxtKodePersediaanPerw,
                    TxtKodePiutangPusKon, TxtKodeCashPusKon, TxtKodeCadanganPusKon, TxtKodeUCFPusKon, TxtKodePersediaanPusKon,
                    TxtKodePiutangPusKre, TxtKodeCashPusKre, TxtKodeCadanganPusKre, TxtKodeUCFPusKre, TxtKodePersediaanPusKre,
                    TxtKodePerwakilan, TxtKodeTambahDisSPPT, TxtKodeTambahDisDSTPT, TxtKodeDivisiSupermarket, TxtKodePersediaanPUPB, TxtKodePersediaanPWPB, TxtKodeKlaimEkspedisiPUPB, TxtKodeCadanganDiskonPUPB, TxtKodeCadanganDiskonPWPB, TxtKodePersediaanReturJual, TxtKodePiutangDagangRetur, TxtKodeCadanganDiskonReturJual, TxtKodePiutangReturBeliKantorPusat, TxtKodePersediaanReturBeliPerwakilan, TxtKodeCadanganDiskonRB, TxtKodePiutangReturBeliUCF, TxtKodeHutangReturBeliPerwakilan, TxtKodePersediaanReturBeliKantorPusat, TxtKodeHutangReturBeliUCF, TxtKodeHutangPSPRB, TxtKodeHutangUCFPRB, TxtKodePersediaanPusatPRB, TxtKodePiutangReturPSPRB, TxtKodePiutangUCFPRB, TxtKodeSelisihHargaPSPRB, TxtKodeSelisihHargaPWPRB, TxtKodeHNDIPWKontan, TxtKodeHNDIUCFPWKontan, TxtKodePiutangDagangUTPWKontanDebet, TxtKodePiutangDagangUTPWKontanKredit, TxtKodePiutangGiroPWKontan, TxtKodePNDIPWKontan, TxtKodePNDIUCFPWKontan, TxtKodePNDIUCFSBUKontan, TxtKodeUMPWKontan, TxtKodeBankMasukKontan, TxtKodeKasMasukKontan, TxtKodeBankMasukSBUDOKontan, TxtKodeKasMasukSBUDOKontan, TxtKodePiutangGiroSBU})
        loadDivisiUntukJurnalUCF()
        loadDivisiDiskonTambahPT()
        loadDivisiUntukJurnalPembelianPW()
        loadDivisiUntukJurnalPusatPW()
        loadDivisiUntukJurnalUCFPelunasanRetur()
        loadDivisiUntukJurnalUCFKontan()
        loadDivisiPengembalianSBU()

        Using dt As DataTable = SelectCon.execute("SELECT * FROM AR_SETUP_AKUNTANSI")
            If dt.Rows.Count > 0 Then
                TxtKodePiutangPerw.Text = dt.Select("NAMA='PIUTANG_PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCashPerw.Text = dt.Select("NAMA='CASH_PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganPerw.Text = dt.Select("NAMA='CADANGAN_PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeUCFPerw.Text = dt.Select("NAMA='UCF_PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanPerw.Text = dt.Select("NAMA='PERSEDIAAN_PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeDivisiSupermarket.Text = dt.Select("NAMA='DIVISI_UCF_SUPERMARKET'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePiutangPusKon.Text = dt.Select("NAMA='PIUTANG_PUSKON'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCashPusKon.Text = dt.Select("NAMA='CASH_PUSKON'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganPusKon.Text = dt.Select("NAMA='CADANGAN_PUSKON'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeUCFPusKon.Text = dt.Select("NAMA='UCF_PUSKON'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanPusKon.Text = dt.Select("NAMA='PERSEDIAAN_PUSKON'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePiutangPusKre.Text = dt.Select("NAMA='PIUTANG_PUSKRE'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCashPusKre.Text = dt.Select("NAMA='CASH_PUSKRE'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganPusKre.Text = dt.Select("NAMA='CADANGAN_PUSKRE'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeUCFPusKre.Text = dt.Select("NAMA='UCF_PUSKRE'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanPusKre.Text = dt.Select("NAMA='PERSEDIAAN_PUSKRE'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePerwakilan.Text = dt.Select("NAMA='PERWAKILAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeTambahDisSPPT.Text = dt.Select("NAMA='DISC_TAMBAH_SP'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeTambahDisDSTPT.Text = dt.Select("NAMA='DISC_TAMBAH_DST'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePersediaanPWPB.Text = dt.Select("NAMA='PERSEDIAAN_PWPB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanPUPB.Text = dt.Select("NAMA='PERSEDIAAN_PUPB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganDiskonPWPB.Text = dt.Select("NAMA='CADANGAN_PWPB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganDiskonPUPB.Text = dt.Select("NAMA='CADANGAN_PUPB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeKlaimEkspedisiPUPB.Text = dt.Select("NAMA='KLAIM_EKSPEDISI'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePersediaanReturJual.Text = dt.Select("NAMA='PERSEDIAAN_RETUR_JUAL'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangDagangRetur.Text = dt.Select("NAMA='PIUTANG_DAGANG_RJ'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganDiskonReturJual.Text = dt.Select("NAMA='CADANGAN_RETUR_JUAL'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePiutangReturBeliUCF.Text = dt.Select("NAMA='PIUTANG_RETUR_BELI_UCF'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanReturBeliPerwakilan.Text = dt.Select("NAMA='PERSEDIAAN_RETUR_BELI_PW'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeCadanganDiskonRB.Text = dt.Select("NAMA='CADANGAN_RETUR_BELI'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePiutangReturBeliKantorPusat.Text = dt.Select("NAMA='PIUTANG_RETUR_BELI_PUSAT'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeHutangReturBeliPerwakilan.Text = dt.Select("NAMA='HUTANG_RETUR_BELI_PW'").CopyToDataTable().Rows(0).Item(1)

                TxtKodePersediaanReturBeliKantorPusat.Text = dt.Select("NAMA='PERSEDIAAN_RETUR_BELI_PUSAT'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeHutangReturBeliUCF.Text = dt.Select("NAMA='HUTANG_RETUR_BELI_UCF'").CopyToDataTable().Rows(0).Item(1)

                TxtKodeHutangPSPRB.Text = dt.Select("NAMA='HUTANG_PUSAT_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeHutangUCFPRB.Text = dt.Select("NAMA='HUTANG_UCF_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePersediaanPusatPRB.Text = dt.Select("NAMA='PERSEDIAAN_PUSAT_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangReturPSPRB.Text = dt.Select("NAMA='PIUTANG_RETUR_PUSAT_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangUCFPRB.Text = dt.Select("NAMA='PIUTANG_UCF_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeSelisihHargaPSPRB.Text = dt.Select("NAMA='SELISIH_HARGA_PUSAT_PRB'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeSelisihHargaPWPRB.Text = dt.Select("NAMA='SELISIH_HARGA_PW_PRB'").CopyToDataTable().Rows(0).Item(1)


                TxtKodeHNDIPWKontan.Text = dt.Select("NAMA='HNDI_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeHNDIUCFPWKontan.Text = dt.Select("NAMA='HNDI_UCF_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangDagangUTPWKontanDebet.Text = dt.Select("NAMA='PIUTANG_DAGANG_UT_PW_KONTAN_D'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangDagangUTPWKontanKredit.Text = dt.Select("NAMA='PIUTANG_DAGANG_UT_PW_KONTAN_K'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangGiroPWKontan.Text = dt.Select("NAMA='PIUTANG_GIRO_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePNDIPWKontan.Text = dt.Select("NAMA='PNDI_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePNDIUCFPWKontan.Text = dt.Select("NAMA='PNDI_UCF_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePNDIUCFSBUKontan.Text = dt.Select("NAMA='PNDI_UCF_SBU_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeUMPWKontan.Text = dt.Select("NAMA='UM_PW_KONTAN'").CopyToDataTable().Rows(0).Item(1)

                TxtKodeKasMasukKontan.Text = dt.Select("NAMA='KAS_MASUK_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeBankMasukKontan.Text = dt.Select("NAMA='BANK_MASUK_KONTAN'").CopyToDataTable().Rows(0).Item(1)

                TxtKodeBankMasukSBUDOKontan.Text = dt.Select("NAMA='BANK_MASUK_SBU_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodeKasMasukSBUDOKontan.Text = dt.Select("NAMA='KAS_MASUK_SBU_KONTAN'").CopyToDataTable().Rows(0).Item(1)
                TxtKodePiutangGiroSBU.Text = dt.Select("NAMA='PIUTANG_GIRO_SBU_KONTAN'").CopyToDataTable().Rows(0).Item(1)
            End If
        End Using
    End Sub

    Private Sub GridView3_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanging, GridView10.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub GridView4_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView4.CellValueChanging, GridView9.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub RepoBtnCari4_Click(sender As Object, e As EventArgs) Handles RepoBtnCari4.Click, RepoBtnCari4.KeyUp
        Dim dr = GridView5.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
            Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
                If dt.Rows.Count > 0 Then
                    dr.Item(3) = dt.Rows(0).Item(0)
                Else
                    dr.Item(3) = ""
                End If
            End Using
            GridView5.CloseEditor()
            GridView5.BestFitColumns()

    End Sub

    Private Sub GridView5_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub GridView11_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView11.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub RBEdit6_Click(sender As Object, e As EventArgs) Handles RBEdit6.Click, RBEdit6.KeyUp
        Dim dr = GridView11.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView11.CloseEditor()
        GridView11.BestFitColumns()
    End Sub

    Private Sub TxtKodePiutangGiroSBU_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodePiutangGiroSBU.EditValueChanged

    End Sub

    Private Sub RBEdit_Click(sender As Object, e As KeyEventArgs) Handles RBEdit.KeyUp, RBEdit.Click

    End Sub

    Private Sub GridView12_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView12.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub RBEdit8_Click(sender As Object, e As EventArgs) Handles RBEdit8.Click, RBEdit8.KeyUp
        Dim dr = GridView12.GetFocusedDataRow
        dr.Item(2) = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        Using dt = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & dr.Item(2) & "'")
            If dt.Rows.Count > 0 Then
                dr.Item(3) = dt.Rows(0).Item(0)
            Else
                dr.Item(3) = ""
            End If
        End Using
        GridView12.CloseEditor()
        GridView12.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView2.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridView3.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridView4.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        GridView5.ShowRibbonPrintPreview()
    End Sub
End Class
