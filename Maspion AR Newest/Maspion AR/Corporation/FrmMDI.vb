Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon

Public Class FrmMDI

#Region "HakAkses"
    Private Sub AksesItem(ByVal GroupMenu As String, ByVal Menu As String, ByVal ItemName As String)
        Dim Akses(3) As Boolean
        Dim dr As DataRow = dtHakAkses.Select("GROUP_HEADER='" & GroupMenu & "' AND HEADER='" & Menu & "' AND ITEM='" & ItemName & "' ")(0)
        Akses(0) = IIf(IsDBNull(dr("HAK_GH")), True, dr("HAK_GH"))
        Akses(1) = dr("HAK_H")
        Akses(2) = dr("LIHAT")
        Dim AksesItem As DevExpress.XtraBars.BarItemVisibility
        If Akses(2) Then AksesItem = BarItemVisibility.Always Else AksesItem = BarItemVisibility.Never

        Select Case GroupMenu
            Case ""
                Select Case Menu
                    Case "Master" : PageMaster.Visible = Akses(1)
                        Select Case ItemName
                            Case "Barang" : BtnBarang.Visibility = AksesItem
                            Case "Corporation" : BtnCorporation.Visibility = AksesItem
                            Case "Customer" : BtnCustomer.Visibility = AksesItem
                            Case "Divisi" : BtnDivisi.Visibility = AksesItem
                            Case "Ekspedisi" : BtnEkspedisi.Visibility = AksesItem
                            Case "Gudang" : BtnGudang.Visibility = AksesItem
                            Case "Karyawan" : BtnKaryawan.Visibility = AksesItem
                            Case "Price List" : BtnPriceList.Visibility = AksesItem
                            Case "SBU" : BtnSBU.Visibility = AksesItem
                            Case "PT" : BtnPT.Visibility = AksesItem
                        End Select
                    Case "Penitipan Barang" : PagePenitipanBarang.Visible = Akses(1)
                        Select Case ItemName
                            Case "Surat Jalan Penitipan Barang" : BtnSJPenitipanBarang.Visibility = AksesItem
                            Case "Titip Barang" : BtnPenitipanBarang.Visibility = AksesItem
                        End Select
                    Case "Retur" : PageRetur.Visible = Akses(1)
                        Select Case ItemName
                            Case "Transfer Barang Retur" : BtnTransferBarangRetur.Visibility = AksesItem
                            Case "Penerimaan Transfer Barang Retur" : BtnPenerimaanTransferBarangRetur.Visibility = AksesItem
                            Case "Nota Retur Penjualan" : BtnReturPenjualan.Visibility = AksesItem
                            Case "Retur Pembelian" : BtnReturPembelian.Visibility = AksesItem
                            Case "Retur Pembellian Tanpa TTB" : BtnReturPembelianTanpaTTB.Visibility = AksesItem
                            Case "Tanda Terima Barang" : BtnTTB.Visibility = AksesItem
                        End Select
                    Case "Persediaan" : PagePersediaan.Visible = Akses(1)
                        Select Case ItemName
                            Case "Mapping Barang" : BtnMappingBarang.Visibility = AksesItem
                            Case "Penerimaan Transfer" : BtnPenerimaanTransfer.Visibility = AksesItem
                            Case "Transfer Barang" : BtnTransferBarang.Visibility = AksesItem
                            Case "Saldo Awal Barang" : BtnSaldoAwalBarang.Visibility = AksesItem
                            Case "Adjusment Stok" : BtnAdjusmentStok.Visibility = AksesItem
                            Case "Posting Periode" : BtnPostingPeriode.Visibility = AksesItem
                        End Select
                    Case "Monitoring" : PageMonitoring.Visible = Akses(1)
                        Select Case ItemName
                            Case "Monitoring  Customer" : BtnMonitoringCustomer.Visibility = AksesItem
                            Case "Monitoring  Stok" : BtnMonitoringStok.Visibility = AksesItem
                        End Select
                    Case "Kredit Debit Note" : PageDebitKreditNote.Visible = Akses(1)
                        Select Case ItemName
                            Case "Debit Note" : BtnDebitNote.Visibility = AksesItem
                            Case "Kredit Note" : BtnKreditNote.Visibility = AksesItem
                        End Select
                    Case "Laporan" : PageLaporan.Visible = Akses(1)
                        Select Case ItemName
                            Case "Daily Sales Report" : BtnDailySalesReport.Visibility = AksesItem
                            Case "Kartu Stok" : BtnKartuStok.Visibility = AksesItem
                            Case "Laporan Delivery Order" : BtnLaporanDO.Visibility = AksesItem
                            Case "Laporan Nota / SJ" : BtnLaporanNotaSJ.Visibility = AksesItem
                            Case "Laporan Pembelian" : BtnLaporanPembelian.Visibility = AksesItem
                            Case "Laporan Price List" : BtnLaporanPriceList.Visibility = AksesItem
                            Case "Laporan Penjualan" : BtnLaporanPenjualan.Visibility = AksesItem
                            Case "Laporan Penerimaan Barang Langganan" : BtnLPBL.Visibility = AksesItem
                            Case "Laporan LPBH" : BtnLPBH.Visibility = AksesItem
                            Case "Laporan Transfer Gudang" : BtnLaporantransferGudang.Visibility = AksesItem
                            Case "Laporan Summary Finish Goods" : BtnSummaryFinishGoods.Visibility = AksesItem
                            Case "Laporan Control Summary" : BtnControlSummary.Visibility = AksesItem
                            Case "Laporan Adjusment Stok" : BtnLaporanAdjusmentStok.Visibility = AksesItem
                            Case "Laporan Retur Penjualan" : BtnLaporanReturPenjualan.Visibility = AksesItem
                        End Select
                    Case "Sistem" : PageSistem.Visible = Akses(1)
                        Select Case ItemName
                            Case "Perusahaan" : BtnPerusahaan.Visibility = AksesItem
                            Case "Group User" : BtnGroupUser.Visibility = AksesItem
                        End Select



                End Select
            Case "Sistem AR" : RibbonPageCategoryAR.Visible = Akses(0)
                Select Case Menu
                    Case "Sistem AR"
                        Select Case ItemName
                        Case "Kode Perkiraan" : BtnKodePerkiraan.Visibility = AksesItem
                        Case "Setup Akuntansi" : BtnSetupAkuntansi.Visibility = AksesItem
                        Case "Master Bank" : BtnMasterBank.Visibility = AksesItem
                        Case "Kode Batasan" : BtnKodeBatasan.Visibility = AksesItem
                        Case "Daily Sales Report Perwakilan" : BtnCreateDSRPrw.Visibility = AksesItem
                        Case "Validasi DSR Perwakilan" : BtnValidasiPrw.Visibility = AksesItem
                        Case "Proses Jurnal Perwakilan" : BtnProsesJurnalPrw.Visibility = AksesItem
                        Case "Daily Sales Report Pusat" : BtnCreateDSRPus.Visibility = AksesItem
                        Case "Validasi DSR Pusat" : BtnValidasiPus.Visibility = AksesItem
                        Case "Proses Jurnal Pusat" : BtnProsesJurnalPus.Visibility = AksesItem
                        Case "Pembayaran Kontan" : BtnPembayaranKontan.Visibility = AksesItem
                        Case "Debit Note" : BtnDN.Visibility = AksesItem
                        Case "Kredit Note" : BtnCN.Visibility = AksesItem
                        Case "Bukti Pengembalian Uang DO Kontan" : BtnPengembalianDOKontan.Visibility = AksesItem
                        Case "Validasi Bukti Pengembalian Uang DO Kontan" : BtnValidasiPengembalian.Visibility = AksesItem
                        Case "Bukti Kekurangan Uang DO Kontan" : BtnKekuranganDO.Visibility = AksesItem
                        Case "Validasi Bukti Kekurangan Uang DO Kontan" : BtnValidasiKekurangan.Visibility = AksesItem
                        Case "Cut Off DO Kontan" : BtnCutOffDOKontan.Visibility = AksesItem
                        Case "Debit Note Kontan" : BtnDebitNoteKontan.Visibility = AksesItem
                        Case "Kredit Note Kontan" : BtnKreditNoteKontan.Visibility = AksesItem

                        Case "Kas Masuk" : BtnKasMasuk.Visibility = AksesItem
                        Case "Kas Keluar" : BtnKasKeluar.Visibility = AksesItem
                        Case "Bank Masuk" : BtnBankMasuk.Visibility = AksesItem
                        Case "Bank Keluar" : BtnBankKeluar.Visibility = AksesItem
                        Case "Jurnal" : BtnJurnal.Visibility = AksesItem
                        Case "Kartu Piutang" : BtnKartuPiutang.Visibility = AksesItem
                        Case "Laporan Sales Per DO" : BtnLaporanSalesPerDO.Visibility = AksesItem
                        Case "Kartu Retur Penjualan" : BtnKartuRetur.Visibility = AksesItem
                        Case "Laporan Saldo UM" : BtnLaporanSaldoUM.Visibility = AksesItem
                        Case "Rekap Saldo Per Divisi" : BtnRekapSaldoDivisi.Visibility = AksesItem

                            Case "Laporan Jurnal Detail" : BtnLaporanJurnalDetail.Visibility = AksesItem
                            Case "Laporan Pembelian" : BtnCreateLapPembelian.Visibility = AksesItem
                        Case "Validasi Laporan Pembelian" : BtnValidasiLapPembelian.Visibility = AksesItem
                        Case "Proses Jurnal Pembelian" : BtnProsesJurnalPB.Visibility = AksesItem
                        Case "Laporan Retur Penjualan" : BtnCreateLapRJ.Visibility = AksesItem
                        Case "Validasi Laporan Retur Penjualan" : BtnValidasiLapRJ.Visibility = AksesItem
                        Case "Proses Jurnal Retur Penjualan" : BtnProsesJurnalRJ.Visibility = AksesItem
                        Case "Laporan Retur Pembelian" : BtnCreateLapRB.Visibility = AksesItem
                        Case "Validasi Laporan Retur Pembelian" : BtnValidasiLapRB.Visibility = AksesItem
                        Case "Proses Jurnal Retur Pembelian" : BtnProsesJurnalRB.Visibility = AksesItem
                        Case "Retur Pusat" : BtnReturPusat.Visibility = AksesItem
                        Case "Pelunasan Retur" : BtnPelunasanRetur.Visibility = AksesItem
                    End Select
                End Select
        End Select
    End Sub
#End Region

    Private Sub FrmMDI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Benar mau menutup aplikasi ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub FrmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrmIntro.MdiParent = Me
        FrmIntro.Show()
        Dim reg As Object = CreateObject("WScript.Shell")
        Dim s As String
        s = reg.RegRead("HKEY_CURRENT_USER\Control Panel\International\sCountry")
        LblKeyboard.Caption = "Format Keyboard : " & s & " || "
        LblVersion.Caption = "Version " & My.Application.Info.Version.ToString & " || Server : " & Split(TxtServer, ";")(0) & " || Database : " & Split(TxtServer, ";")(1)
        For Each r As DataRow In dtHakAkses.Rows
            AksesItem(r("GROUP_HEADER"), r("HEADER"), r("ITEM"))
        Next

        Me.SuspendLayout()
        For Each pp As RibbonPage In RibbonControl.Pages
            For Each gp As RibbonPageGroup In pp.Groups
                Dim st As Boolean = False
                For Each i As DevExpress.XtraBars.BarItemLink In gp.ItemLinks
                    If i.Item.Visibility = BarItemVisibility.Always Then st = True : Exit For
                Next
                If st = False Then gp.Visible = False
            Next
        Next
        For Each pc As RibbonPageCategory In RibbonControl.PageCategories
            For Each ppp As RibbonPage In pc.Pages
                For Each gp As RibbonPageGroup In ppp.Groups
                    Dim st As Boolean = False
                    For Each i As DevExpress.XtraBars.BarItemLink In gp.ItemLinks
                        If i.Item.Visibility = BarItemVisibility.Always Then st = True : Exit For
                    Next
                    If st = False Then gp.Visible = False
                Next
            Next
        Next
        Me.ResumeLayout(False)

        RibbonPageCategoryPembelian.Visible = False
        RibbonPageCategoryPenjualanLangganan.Visible = False
        RibbonPageCategoryPenjualanSupermarket.Visible = False
        RibbonPageCategoryPenjualanLain.Visible = False
        PageMaster.Visible = False
    End Sub

    Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal v As IntPtr, ByVal s As Integer, ByVal l As Integer) As Integer
    Public Sub CloseObj(ByVal e As Form)
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess.Handle, -1, -1)
                Dim smart As Process() = Process.GetProcessesByName(e.ProductName)
                Dim start As Process
                For Each start In smart
                    SetProcessWorkingSetSize(start.Handle, -1, -1)
                Next start
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FrmMDI_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        CloseObj(Me)
    End Sub

    Private Sub FrmMDI_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate
        'CloseObj(ActiveMdiChild)
    End Sub

    Private Sub FrmMDI_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If WindowState = FormWindowState.Normal Then
            If Width < 800 Then
                Width = 800
            End If
            If Height < 600 Then
                Height = 600
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Caption = "Jam : " & Format(Now, "hh:mm:ss") & " || "
        LblTanggal.Caption = "Tanggal : " & Format(Now, "dddd, dd/MM/yyyy")
        LblUser.Caption = "Nama User : " & UserName & " ||  Periode : " & periode & "  || "
    End Sub

    Private Sub BtnUbahPassword_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnUbahPassword.ItemClick
        UbahPassword.MdiParent = Me
        UbahPassword.Show()
        UbahPassword.Focus()
    End Sub

    Private Sub BtnSwitchPeriode_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnSwitchPeriode.ItemClick
        Dispose()
        FrmSwitchPeriode.TxtID.Text = UserID
        FrmSwitchPeriode.TxtUsername.Text = UserName
        FrmSwitchPeriode.TxtPassword.Text = passwd
        FrmSwitchPeriode.Show()
        FrmSwitchPeriode.TglPeriode.Focus()
    End Sub

    Private Sub BtnLogOut_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnLogOut.ItemClick
        Dispose()
        FrmLogin.Show()
    End Sub

    Private Sub BtnExit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnExit.ItemClick
        tutup_db()
        End
    End Sub

    Private Sub BtnKaryawan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnKaryawan.ItemClick
        MenuKaryawan.MdiParent = Me
        MenuKaryawan.Show()
        MenuKaryawan.Focus()
    End Sub

    Private Sub BtnSupplier_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSupplier.ItemClick
        'MenuSupplier.MdiParent = Me
        'MenuSupplier.Show()
        'MenuSupplier.Focus()
    End Sub

    Private Sub BtnCustomer_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCustomer.ItemClick
        MenuCustomer.MdiParent = Me
        MenuCustomer.Show()
        MenuCustomer.Focus()
    End Sub

    Private Sub BtnDivisi_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDivisi.ItemClick
        MenuDivisi.MdiParent = Me
        MenuDivisi.Show()
        MenuDivisi.Focus()
    End Sub

    Private Sub BtnSBU_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSBU.ItemClick
        MenuSBU.MdiParent = Me
        MenuSBU.Show()
        MenuSBU.Focus()
    End Sub

    Private Sub BtnGudang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnGudang.ItemClick
        MenuGudang.MdiParent = Me
        MenuGudang.Show()
        MenuGudang.Focus()
    End Sub

    'Private Sub BtnPurchaseOrderLangganan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPurchaseOrderLangganan.ItemClick
    '    MenuPOLangganan.MdiParent = Me
    '    MenuPOLangganan.Show()
    '    MenuPOLangganan.Focus()
    'End Sub

    'Private Sub BtnPembelianLangganan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPembelianLangganan.ItemClick
    '    MenuNotaPembelianLangganan.MdiParent = Me
    '    MenuNotaPembelianLangganan.Show()
    '    MenuNotaPembelianLangganan.Focus()
    'End Sub

    'Private Sub BtnClaimPembelian_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnClaimPembelianLangganan.ItemClick
    '    MenuNotaClaimLangganan.MdiParent = Me
    '    MenuNotaClaimLangganan.Show()
    '    MenuNotaClaimLangganan.Focus()
    'End Sub

    'Private Sub BtnReturPembelian_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnReturPembelian.ItemClick
    '    MenuNotaReturPembelian.MdiParent = Me
    '    MenuNotaReturPembelian.Show()
    '    MenuNotaReturPembelian.Focus()
    'End Sub

    Private Sub BtnBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnBarang.ItemClick
        MenuBarang.MdiParent = Me
        MenuBarang.Show()
        MenuBarang.Focus()
    End Sub

    'Private Sub BtnPjLanggananPusatBarangDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPusatBarangDO.ItemClick
    '    MenuDeliveryOrderLanggananPusat.MdiParent = Me
    '    MenuDeliveryOrderLanggananPusat.Show()
    '    MenuDeliveryOrderLanggananPusat.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPusatTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPusatTBarangTitipan.ItemClick
    '    MenuDOTitipanLanggananPusat.MdiParent = Me
    '    MenuDOTitipanLanggananPusat.Show()
    '    MenuDOTitipanLanggananPusat.Focus()
    'End Sub

    Private Sub BtnMonitoringCustomer_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMonitoringCustomer.ItemClick
        FrmMonitoringCustomer.MdiParent = Me
        FrmMonitoringCustomer.Show()
        FrmMonitoringCustomer.Focus()
    End Sub

    'Private Sub BtnPjLanggananPerwakilanBarangDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPerwakilanBarangDO.ItemClick
    '    MenuDeliveryOrderLanggananPerwakilan.MdiParent = Me
    '    MenuDeliveryOrderLanggananPerwakilan.Show()
    '    MenuDeliveryOrderLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPusatTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPusatTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananLanggananPusat.MdiParent = Me
    '    MenuBonPesananLanggananPusat.Show()
    '    MenuBonPesananLanggananPusat.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPusatMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPusatMonPay.ItemClick
    '    MonitoringPaymentLanggananPusat.MdiParent = Me
    '    MonitoringPaymentLanggananPusat.Show()
    '    MonitoringPaymentLanggananPusat.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPusatNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPusatNota.ItemClick
    '    MenuNotaSJLanggananPusat.MdiParent = Me
    '    MenuNotaSJLanggananPusat.Show()
    '    MenuNotaSJLanggananPusat.Focus()
    'End Sub

    'Private Sub BarButtonItem4_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSuratJalanTanpaHarga.ItemClick
    '    MenuSJLanggananPerwakilan.MdiParent = Me
    '    MenuSJLanggananPerwakilan.Show()
    '    MenuSJLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPerwTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPerwTBarangTitipan.ItemClick
    '    MenuDOTitipanLanggananPerwakilan.MdiParent = Me
    '    MenuDOTitipanLanggananPerwakilan.Show()
    '    MenuDOTitipanLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPerwTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPerwTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananLanggananPerwakilan.MdiParent = Me
    '    MenuBonPesananLanggananPerwakilan.Show()
    '    MenuBonPesananLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPerwMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPerwMonPay.ItemClick
    '    MonitoringPaymentLanggananPerwakilan.MdiParent = Me
    '    MonitoringPaymentLanggananPerwakilan.Show()
    '    MonitoringPaymentLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananStuffing_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananStuffing.ItemClick
    '    MenuStuffingLanggananPerwakilan.MdiParent = Me
    '    MenuStuffingLanggananPerwakilan.Show()
    '    MenuStuffingLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLanggananPerwNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLanggananPerwNota.ItemClick
    '    MenuNotaSJLanggananPerwakilan.MdiParent = Me
    '    MenuNotaSJLanggananPerwakilan.Show()
    '    MenuNotaSJLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPriceList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPriceList.ItemClick
    '    MenuPriceList.MdiParent = Me
    '    MenuPriceList.Show()
    '    MenuPriceList.Focus()
    'End Sub

    'Private Sub BtnTTB_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnTTB.ItemClick
    '    MenuTTB.MdiParent = Me
    '    MenuTTB.Show()
    '    MenuTTB.Focus()
    'End Sub

    'Private Sub BtnRetur_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnReturPenjualan.ItemClick
    '    MenuNotaReturPenjualan.MdiParent = Me
    '    MenuNotaReturPenjualan.Show()
    '    MenuNotaReturPenjualan.Focus()
    'End Sub

    Private Sub BtnCorporation_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCorporation.ItemClick
        MenuCorporation.MdiParent = Me
        MenuCorporation.Show()
        MenuCorporation.Focus()
    End Sub

    Private Sub BtnEkspedisi_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEkspedisi.ItemClick
        MenuEkspedisi.MdiParent = Me
        MenuEkspedisi.Show()
        MenuEkspedisi.Focus()
    End Sub

    'Private Sub BtnPjSupermarketPerwakilanDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwakilanDO.ItemClick
    '    MenuDeliveryOrderSupermarketPerwakilan.MdiParent = Me
    '    MenuDeliveryOrderSupermarketPerwakilan.Show()
    '    MenuDeliveryOrderSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPerwTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwTBarangTitipan.ItemClick
    '    MenuDOTitipanSupermarketPerwakilan.MdiParent = Me
    '    MenuDOTitipanSupermarketPerwakilan.Show()
    '    MenuDOTitipanSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPerwTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananSupermarketPerwakilan.MdiParent = Me
    '    MenuBonPesananSupermarketPerwakilan.Show()
    '    MenuBonPesananSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPerwMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwMonPay.ItemClick
    '    MonitoringPaymentSupermarketPerwakilan.MdiParent = Me
    '    MonitoringPaymentSupermarketPerwakilan.Show()
    '    MonitoringPaymentSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketStuffing_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketStuffing.ItemClick
    '    MenuStuffingSupermarketPerwakilan.MdiParent = Me
    '    MenuStuffingSupermarketPerwakilan.Show()
    '    MenuStuffingSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPerwNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwNota.ItemClick
    '    MenuNotaSJSupermarketPerwakilan.MdiParent = Me
    '    MenuNotaSJSupermarketPerwakilan.Show()
    '    MenuNotaSJSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPerwRefund_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPerwRefund.ItemClick
    '    MenuRefundSupermarketPerwakilan.MdiParent = Me
    '    MenuRefundSupermarketPerwakilan.Show()
    '    MenuRefundSupermarketPerwakilan.Focus()
    'End Sub

    Private Sub BtnMonitoringStok_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMonitoringStok.ItemClick
        FrmMonitoringStok.MdiParent = Me
        FrmMonitoringStok.Show()
        FrmMonitoringStok.Focus()
    End Sub

    'Private Sub BtnPjSupermarketPusatBarangDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPusatBarangDO.ItemClick
    '    MenuDeliveryOrderSupermarketPusat.MdiParent = Me
    '    MenuDeliveryOrderSupermarketPusat.Show()
    '    MenuDeliveryOrderSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPusatTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPusatTBarangTitipan.ItemClick
    '    MenuDOTitipanSupermarketPusat.MdiParent = Me
    '    MenuDOTitipanSupermarketPusat.Show()
    '    MenuDOTitipanSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPusatTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPusatTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananSupermarketPusat.MdiParent = Me
    '    MenuBonPesananSupermarketPusat.Show()
    '    MenuBonPesananSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPusatMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPusatMonPay.ItemClick
    '    MonitoringPaymentSupermarketPusat.MdiParent = Me
    '    MonitoringPaymentSupermarketPusat.Show()
    '    MonitoringPaymentSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPjSupermarketPusatNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjSupermarketPusatNota.ItemClick
    '    MenuNotaSJSupermarketPusat.MdiParent = Me
    '    MenuNotaSJSupermarketPusat.Show()
    '    MenuNotaSJSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPjLainPerwakilanBarangDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPerwakilanBarangDO.ItemClick
    '    MenuDeliveryOrderLainPerwakilan.MdiParent = Me
    '    MenuDeliveryOrderLainPerwakilan.Show()
    '    MenuDeliveryOrderLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainPerwTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPerwTBarangTitipan.ItemClick
    '    MenuDOTitipanLainPerwakilan.MdiParent = Me
    '    MenuDOTitipanLainPerwakilan.Show()
    '    MenuDOTitipanLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainPerwTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPerwTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananLainPerwakilan.MdiParent = Me
    '    MenuBonPesananLainPerwakilan.Show()
    '    MenuBonPesananLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainPerwMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPerwMonPay.ItemClick
    '    MonitoringPaymentLainPerwakilan.MdiParent = Me
    '    MonitoringPaymentLainPerwakilan.Show()
    '    MonitoringPaymentLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainStuffing_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainStuffing.ItemClick
    '    MenuStuffingLainPerwakilan.MdiParent = Me
    '    MenuStuffingLainPerwakilan.Show()
    '    MenuStuffingLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainPerwNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPerwNota.ItemClick
    '    MenuNotaSJLainPerwakilan.MdiParent = Me
    '    MenuNotaSJLainPerwakilan.Show()
    '    MenuNotaSJLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnSuratJalanTanpaHargaLain_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSuratJalanTanpaHargaLain.ItemClick
    '    MenuSJLainPerwakilan.MdiParent = Me
    '    MenuSJLainPerwakilan.Show()
    '    MenuSJLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPjLainPusatBarangDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPusatBarangDO.ItemClick
    '    MenuDeliveryOrderLainPusat.MdiParent = Me
    '    MenuDeliveryOrderLainPusat.Show()
    '    MenuDeliveryOrderLainPusat.Focus()
    'End Sub

    'Private Sub BtnPjLainPusatTBarangTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPusatTBarangTitipan.ItemClick
    '    MenuDOTitipanLainPusat.MdiParent = Me
    '    MenuDOTitipanLainPusat.Show()
    '    MenuDOTitipanLainPusat.Focus()
    'End Sub

    'Private Sub BtnPjLainPusatTBarangBonPesananTitipan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPusatTBarangBonPesananTitipan.ItemClick
    '    MenuBonPesananLainPusat.MdiParent = Me
    '    MenuBonPesananLainPusat.Show()
    '    MenuBonPesananLainPusat.Focus()
    'End Sub

    'Private Sub BtnPjLainPusatMonPay_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPusatMonPay.ItemClick
    '    MonitoringPaymentLainPusat.MdiParent = Me
    '    MonitoringPaymentLainPusat.Show()
    '    MonitoringPaymentLainPusat.Focus()
    'End Sub

    'Private Sub BtnPjLainPusatNota_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPjLainPusatNota.ItemClick
    '    MenuNotaSJLainPusat.MdiParent = Me
    '    MenuNotaSJLainPusat.Show()
    '    MenuNotaSJLainPusat.Focus()
    'End Sub

    'Private Sub BtnPenitipanBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPenitipanBarang.ItemClick
    '    MenuTitipBarang.MdiParent = Me
    '    MenuTitipBarang.Show()
    '    MenuTitipBarang.Focus()
    'End Sub

    'Private Sub BtnSJPenitipanBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSJPenitipanBarang.ItemClick
    '    MenuSJTitipBarang.MdiParent = Me
    '    MenuSJTitipBarang.Show()
    '    MenuSJTitipBarang.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditLanggananPerwakilan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditLanggananPerwakilan.ItemClick
    '    PaymentKreditLanggananPerwakilan.MdiParent = Me
    '    PaymentKreditLanggananPerwakilan.Show()
    '    PaymentKreditLanggananPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditLanggananPusat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditLanggananPusat.ItemClick
    '    PaymentKreditLanggananPusat.MdiParent = Me
    '    PaymentKreditLanggananPusat.Show()
    '    PaymentKreditLanggananPusat.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditSupermarketPerwakilan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditSupermarketPerwakilan.ItemClick
    '    PaymentKreditSupermarketPerwakilan.MdiParent = Me
    '    PaymentKreditSupermarketPerwakilan.Show()
    '    PaymentKreditSupermarketPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditSupermarketPusat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditSupermarketPusat.ItemClick
    '    PaymentKreditSupermarketPusat.MdiParent = Me
    '    PaymentKreditSupermarketPusat.Show()
    '    PaymentKreditSupermarketPusat.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditLainPerwakilan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditLainPerwakilan.ItemClick
    '    PaymentKreditLainPerwakilan.MdiParent = Me
    '    PaymentKreditLainPerwakilan.Show()
    '    PaymentKreditLainPerwakilan.Focus()
    'End Sub

    'Private Sub BtnPaymentKreditLainPusat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPaymentKreditLainPusat.ItemClick
    '    PaymentKreditLainPusat.MdiParent = Me
    '    PaymentKreditLainPusat.Show()
    '    PaymentKreditLainPusat.Focus()
    'End Sub

    'Private Sub BtnDebitNote_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDebitNote.ItemClick
    '    MenuDebitNote.MdiParent = Me
    '    MenuDebitNote.Show()
    '    MenuDebitNote.Focus()
    'End Sub

    'Private Sub BtnKreditNote_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnKreditNote.ItemClick
    '    MenuKreditNote.MdiParent = Me
    '    MenuKreditNote.Show()
    '    MenuKreditNote.Focus()
    'End Sub

    Private Sub BtnDailySalesReport_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDailySalesReport.ItemClick
        DailySalesReport.MdiParent = Me
        DailySalesReport.Show()
        DailySalesReport.Focus()
    End Sub

    Private Sub BtnSaldoStok_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnKartuStok.ItemClick
        KartuStok.MdiParent = Me
        KartuStok.Show()
        KartuStok.Focus()
    End Sub

    'Private Sub BtnTransferBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnTransferBarang.ItemClick
    '    MenuTransferGudang.MdiParent = Me
    '    MenuTransferGudang.Show()
    '    MenuTransferGudang.Focus()
    'End Sub

    'Private Sub BtnPenerimaanTransfer_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPenerimaanTransfer.ItemClick
    '    MenuPenerimaanTransfer.MdiParent = Me
    '    MenuPenerimaanTransfer.Show()
    '    MenuPenerimaanTransfer.Focus()
    'End Sub

    'Private Sub BtnPurchaseOrderSupermarket_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPurchaseOrderSupermarket.ItemClick
    '    MenuPOSupermarket.MdiParent = Me
    '    MenuPOSupermarket.Show()
    '    MenuPOSupermarket.Focus()
    'End Sub

    'Private Sub BtnPembelianSupermarket_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPembelianSupermarket.ItemClick
    '    MenuNotaPembelianSupermarket.MdiParent = Me
    '    MenuNotaPembelianSupermarket.Show()
    '    MenuNotaPembelianSupermarket.Focus()
    'End Sub

    'Private Sub BtnClaimPembelianSupermarket_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnClaimPembelianSupermarket.ItemClick
    '    MenuNotaClaimSupermarket.MdiParent = Me
    '    MenuNotaClaimSupermarket.Show()
    '    MenuNotaClaimSupermarket.Focus()
    'End Sub

    Private Sub BtnPerusahaan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPerusahaan.ItemClick
        FrmPerusahaan.MdiParent = Me
        FrmPerusahaan.Show()
        FrmPerusahaan.Focus()
    End Sub

    'Private Sub BtnMappingBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMappingBarang.ItemClick
    '    FrmMappingBarang.MdiParent = Me
    '    FrmMappingBarang.Show()
    '    FrmMappingBarang.Focus()
    'End Sub

    Private Sub BtnGroupUser_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnGroupUser.ItemClick
        MenuGroupUser.MdiParent = Me
        MenuGroupUser.Show()
        MenuGroupUser.Focus()
    End Sub

    Private Sub BtnPT_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPT.ItemClick
        MenuPT.MdiParent = Me
        MenuPT.Show()
        MenuPT.Focus()
    End Sub

    Private Sub BtnLaporanPembelian_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanPembelian.ItemClick
        LaporanPembelian.MdiParent = Me
        LaporanPembelian.Show()
        LaporanPembelian.Focus()
    End Sub

    Private Sub BtnLaporanDO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanDO.ItemClick
        LaporanDO.MdiParent = Me
        LaporanDO.Show()
        LaporanDO.Focus()
    End Sub

    Private Sub BtnLaporanNotaSJ_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanNotaSJ.ItemClick
        LaporanNotaSJ.MdiParent = Me
        LaporanNotaSJ.Show()
        LaporanNotaSJ.Focus()
    End Sub

    Private Sub BtnLaporanPriceList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanPriceList.ItemClick
        LaporanPriceList.MdiParent = Me
        LaporanPriceList.Show()
        LaporanPriceList.Focus()
    End Sub

    Private Sub BtnLaporanPenjualan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanPenjualan.ItemClick
        LaporanPenjualan.MdiParent = Me
        LaporanPenjualan.Show()
        LaporanPenjualan.Focus()
    End Sub

    'Private Sub BtnSaldoAwalBarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSaldoAwalBarang.ItemClick
    '    MenuSaldoAwal.MdiParent = Me
    '    MenuSaldoAwal.Show()
    '    MenuSaldoAwal.Focus()
    'End Sub

    'Private Sub BtnTransferBarangRetur_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnTransferBarangRetur.ItemClick
    '    MenuTransferBarangRetur.MdiParent = Me
    '    MenuTransferBarangRetur.Show()
    '    MenuTransferBarangRetur.Focus()
    'End Sub

    Private Sub BtnLPBL_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLPBL.ItemClick
        LaporanLPBL.MdiParent = Me
        LaporanLPBL.Show()
        LaporanLPBL.Focus()
    End Sub

    'Private Sub BtnAdjusmentStok_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnAdjusmentStok.ItemClick
    '    MenuAdjusmentStok.MdiParent = Me
    '    MenuAdjusmentStok.Show()
    '    MenuAdjusmentStok.Focus()
    'End Sub

    Private Sub BtnLPBH_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLPBH.ItemClick
        LaporanLPBH.MdiParent = Me
        LaporanLPBH.Show()
        LaporanLPBH.Focus()
    End Sub

    'Private Sub BtnReturPembelianTanpaTTB_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnReturPembelianTanpaTTB.ItemClick
    '    MenuNotaReturPembelianTanpaTTB.MdiParent = Me
    '    MenuNotaReturPembelianTanpaTTB.Show()
    '    MenuNotaReturPembelianTanpaTTB.Focus()
    'End Sub

    Private Sub BtnPostingPeriode_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPostingPeriode.ItemClick
        FrmPostingPeriode.MdiParent = Me
        FrmPostingPeriode.Show()
        FrmPostingPeriode.Focus()
    End Sub

    'Private Sub BtnPenerimaanTransferBarangRetur_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPenerimaanTransferBarangRetur.ItemClick
    '    MenuPenerimaanTransferBarangRetur.MdiParent = Me
    '    MenuPenerimaanTransferBarangRetur.Show()
    '    MenuPenerimaanTransferBarangRetur.Focus()
    'End Sub

    Private Sub BtnLaporantransferGudang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporantransferGudang.ItemClick
        LaporanTransferGudang.MdiParent = Me
        LaporanTransferGudang.Show()
        LaporanTransferGudang.Focus()
    End Sub

    Private Sub BtnMoDOOuts_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMoDOOuts.ItemClick
        FrmMonitoringDOOutstanding.MdiParent = Me
        FrmMonitoringDOOutstanding.Show()
        FrmMonitoringDOOutstanding.Focus()
    End Sub

    Private Sub BtnSummaryFinishGoods_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSummaryFinishGoods.ItemClick
        LaporanSummaryFinishGoods.MdiParent = Me
        LaporanSummaryFinishGoods.Show()
        LaporanSummaryFinishGoods.Focus()
    End Sub

    Private Sub BtnControlSummary_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnControlSummary.ItemClick
        LaporanControlSummary.MdiParent = Me
        LaporanControlSummary.Show()
        LaporanControlSummary.Focus()
    End Sub

    Private Sub BtnLaporanAdjusmentStok_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanAdjusmentStok.ItemClick
        LaporanAdjusmentStok.MdiParent = Me
        LaporanAdjusmentStok.Show()
        LaporanAdjusmentStok.Focus()
    End Sub

    Private Sub BtnLaporanReturPenjualan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLaporanReturPenjualan.ItemClick
        LaporanReturPenjualan.MdiParent = Me
        LaporanReturPenjualan.Show()
        LaporanReturPenjualan.Focus()
    End Sub

    Private Sub BtnCreateDSR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCreateDSRPrw.ItemClick
        MenuCreateDSRPrw.MdiParent = Me
        MenuCreateDSRPrw.Show()
        MenuCreateDSRPrw.Focus()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiPrw.ItemClick
        MenuValidasiDSRPrw.MdiParent = Me
        MenuValidasiDSRPrw.Show()
        MenuValidasiDSRPrw.Focus()
    End Sub

    Private Sub BtnKodePerkiraan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKodePerkiraan.ItemClick
        MenuKodePerkiraan.MdiParent = Me
        MenuKodePerkiraan.Show()
        MenuKodePerkiraan.Focus()
    End Sub

    Private Sub BtnJurnal_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnJurnal.ItemClick
        MenuJurnal.MdiParent = Me
        MenuJurnal.Show()
        MenuJurnal.Focus()
    End Sub

    Private Sub BtnKasMasuk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKasMasuk.ItemClick
        MenuKasMasuk.MdiParent = Me
        MenuKasMasuk.Show()
        MenuKasMasuk.Focus()
    End Sub

    Private Sub BtnKasKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKasKeluar.ItemClick
        MenuKasKeluar.MdiParent = Me
        MenuKasKeluar.Show()
        MenuKasKeluar.Focus()
    End Sub

    Private Sub BtnBankMasuk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnBankMasuk.ItemClick
        MenuBankMasuk.MdiParent = Me
        MenuBankMasuk.Show()
        MenuBankMasuk.Focus()
    End Sub

    Private Sub BtnBankKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnBankKeluar.ItemClick
        MenuBankKeluar.MdiParent = Me
        MenuBankKeluar.Show()
        MenuBankKeluar.Focus()
    End Sub

    Private Sub BtnSetupAkuntansi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnSetupAkuntansi.ItemClick
        FrmSetupAkuntansi.MdiParent = Me
        FrmSetupAkuntansi.Show()
        FrmSetupAkuntansi.Focus()
    End Sub

    Private Sub BtnCreateDSRPus_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCreateDSRPus.ItemClick
        MenuCreateDSRPus.MdiParent = Me
        MenuCreateDSRPus.Show()
        MenuCreateDSRPus.Focus()
    End Sub

    Private Sub BtnValidasiPus_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiPus.ItemClick
        MenuValidasiDSRPus.MdiParent = Me
        MenuValidasiDSRPus.Show()
        MenuValidasiDSRPus.Focus()
    End Sub

    Private Sub BtnHargaPromo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnHargaPromo.ItemClick
        MenuHargaPromo.MdiParent = Me
        MenuHargaPromo.Show()
        MenuHargaPromo.Focus()
    End Sub

    Private Sub BtnTandaTerima_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnTandaTerima.ItemClick
        MenuTandaTerima.MdiParent = Me
        MenuTandaTerima.Show()
        MenuTandaTerima.Focus()
    End Sub

    Private Sub BtnPenyerahanNota_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPenyerahanNota.ItemClick
        MenuPenyerahanNota.MdiParent = Me
        MenuPenyerahanNota.Show()
        MenuPenyerahanNota.Focus()
    End Sub

    Private Sub BtnPengembalianNota_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPengembalianNota.ItemClick
        MenuPengembalianNota.MdiParent = Me
        MenuPengembalianNota.Show()
        MenuPengembalianNota.Focus()
    End Sub

    Private Sub BtnProsesJurnalPrw_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnProsesJurnalPrw.ItemClick
        MenuProsesJurnalPrw.MdiParent = Me
        MenuProsesJurnalPrw.Show()
        MenuProsesJurnalPrw.Focus()
    End Sub

    Private Sub BtnProsesJurnalPus_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnProsesJurnalPus.ItemClick
        MenuProsesJurnalPus.MdiParent = Me
        MenuProsesJurnalPus.Show()
        MenuProsesJurnalPus.Focus()
    End Sub

    Private Sub BtnPermintaanDibuatkanFakturPajak_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPermintaanDibuatkanFakturPajak.ItemClick
        MenuPermintaanDibuatkanFakturPajak.MdiParent = Me
        MenuPermintaanDibuatkanFakturPajak.Show()
        MenuPermintaanDibuatkanFakturPajak.Focus()
    End Sub

    Private Sub BtnKonfirmasiDibuatkanFakturPajak_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKonfirmasiDibuatkanFakturPajak.ItemClick
        MenuKonfirmasiDibuatkanFakturPajak.MdiParent = Me
        MenuKonfirmasiDibuatkanFakturPajak.Show()
        MenuKonfirmasiDibuatkanFakturPajak.Focus()
    End Sub

    Private Sub BtnUangTitipan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnUangTitipan.ItemClick
        MenuUangTitipan.MdiParent = Me
        MenuUangTitipan.Show()
        MenuUangTitipan.Focus()
    End Sub

    Private Sub BtnMasterBank_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnMasterBank.ItemClick
        MenuMasterBank.MdiParent = Me
        MenuMasterBank.Show()
        MenuMasterBank.Focus()
    End Sub

    Private Sub BtnSetoranPerPT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnSetoranPerPT.ItemClick
        MenuSetoranPerPT.MdiParent = Me
        MenuSetoranPerPT.Show()
        MenuSetoranPerPT.Focus()
    End Sub

    Private Sub BtnKodeBatasan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKodeBatasan.ItemClick
        MenuKodeBatasan.MdiParent = Me
        MenuKodeBatasan.Show()
        MenuKodeBatasan.Focus()
    End Sub

    Private Sub BtnKartuPiutang_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKartuPiutang.ItemClick
        LaporanKartuPiutang.MdiParent = Me
        LaporanKartuPiutang.Show()
        LaporanKartuPiutang.Focus()
    End Sub

    Private Sub BtnPembayaranKontan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPembayaranKontan.ItemClick
        MenuPembayaranKontan.MdiParent = Me
        MenuPembayaranKontan.Show()
        MenuPembayaranKontan.Focus()
    End Sub

    Private Sub BtnLaporanSalesPerDO_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnLaporanSalesPerDO.ItemClick
        LaporanSalesPerDO.MdiParent = Me
        LaporanSalesPerDO.Show()
        LaporanSalesPerDO.Focus()
    End Sub

    Private Sub BtnKartuRetur_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKartuRetur.ItemClick
        LaporanKartuRetur.MdiParent = Me
        LaporanKartuRetur.Show()
        LaporanKartuRetur.Focus()
    End Sub

    Private Sub BtnCNDN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCN.ItemClick
        MenuKreditNote.MdiParent = Me
        MenuKreditNote.Show()
        MenuKreditNote.Focus()
    End Sub

    Private Sub BtnDN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnDN.ItemClick
        MenuDebitNote.MdiParent = Me
        MenuDebitNote.Show()
        MenuDebitNote.Focus()
    End Sub

    Private Sub BtnPengembalianDOKontan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPengembalianDOKontan.ItemClick
        MenuPengembalianDOKontan.MdiParent = Me
        MenuPengembalianDOKontan.Show()
        MenuPengembalianDOKontan.Focus()
    End Sub

    Private Sub BtnKekuranganDO_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKekuranganDO.ItemClick
        MenuKekuranganDOKontan.MdiParent = Me
        MenuKekuranganDOKontan.Show()
        MenuKekuranganDOKontan.Focus()

    End Sub

    Private Sub BtnValidasiPengembalian_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiPengembalian.ItemClick
        MenuValidasiPengembalianDOKontan.MdiParent = Me
        MenuValidasiPengembalianDOKontan.Show()
        MenuValidasiPengembalianDOKontan.Focus()

    End Sub

    Private Sub BtnValidasiKekurangan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiKekurangan.ItemClick
        MenuValidasiKekuranganDOKontan.MdiParent = Me
        MenuValidasiKekuranganDOKontan.Show()
        MenuValidasiKekuranganDOKontan.Focus()
    End Sub

    Private Sub BtnLaporanSaldoUM_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnLaporanSaldoUM.ItemClick
        LaporanSalesUM.MdiParent = Me
        LaporanSalesUM.Show()
        LaporanSalesUM.Focus()
    End Sub

    Private Sub BtnRekapSaldoDivisi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRekapSaldoDivisi.ItemClick
        LaporanRekapSaldoPerDivisi.MdiParent = Me
        LaporanRekapSaldoPerDivisi.Show()
        LaporanRekapSaldoPerDivisi.Focus()
    End Sub

    Private Sub BtnRekapOmsetDivisi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRekapOmsetDivisi.ItemClick
        LaporanRekapOmsetPembayaranPerDivisi.MdiParent = Me
        LaporanRekapOmsetPembayaranPerDivisi.Show()
        LaporanRekapOmsetPembayaranPerDivisi.Focus()
    End Sub

    Private Sub BtnRekapOmsetPembayaranCustomer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRekapOmsetPembayaranCustomer.ItemClick
        LaporanRekapOmstePembayaranCustomer.MdiParent = Me
        LaporanRekapOmstePembayaranCustomer.Show()
        LaporanRekapOmstePembayaranCustomer.Focus()
    End Sub

    Private Sub BtnRekapOmsetCorporate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRekapOmsetCorporate.ItemClick
        LaporanRekapOmsetPembayaranCorporate.MdiParent = Me
        LaporanRekapOmsetPembayaranCorporate.Show()
        LaporanRekapOmsetPembayaranCorporate.Focus()
    End Sub

    Private Sub BtnCutOffDOKontan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCutOffDOKontan.ItemClick
        MenuCuttOffDOKontan.MdiParent = Me
        MenuCuttOffDOKontan.Show()
        MenuCuttOffDOKontan.Focus()
    End Sub

    Private Sub BtnDebitNoteKontan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnDebitNoteKontan.ItemClick
        MenuDebitNoteKontan.MdiParent = Me
        MenuDebitNoteKontan.Show()
        MenuDebitNoteKontan.Focus()
    End Sub

    Private Sub BtnKreditNoteKontan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKreditNoteKontan.ItemClick
        MenuKreditNoteKontan.MdiParent = Me
        MenuKreditNoteKontan.Show()
        MenuKreditNoteKontan.Focus()
    End Sub

    Private Sub BtnLaporanJurnal_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnLaporanJurnal.ItemClick
        LaporanJurnal.MdiParent = Me
        LaporanJurnal.Show()
        LaporanJurnal.Focus()
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BtnLaporanJurnalDetail.ItemClick
        LaporanJurnalAR.MdiParent = Me
        LaporanJurnalAR.Show()
        LaporanJurnalAR.Focus()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCreateLapPembelian.ItemClick
        MenuCreateDSRPembelian.MdiParent = Me
        MenuCreateDSRPembelian.Show()
        MenuCreateDSRPembelian.Focus()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiLapPembelian.ItemClick
        MenuValidasiDSRPB.MdiParent = Me
        MenuValidasiDSRPB.Show()
        MenuValidasiDSRPB.Focus()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnProsesJurnalPB.ItemClick
        MenuProsesJurnalPB.MdiParent = Me
        MenuProsesJurnalPB.Show()
        MenuProsesJurnalPB.Focus()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCreateLapRJ.ItemClick
        MenuCreateLaporanReturPenjualan.MdiParent = Me
        MenuCreateLaporanReturPenjualan.Show()
        MenuCreateLaporanReturPenjualan.Focus()

    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiLapRJ.ItemClick
        MenuValidasiLapReturPenjualan.MdiParent = Me
        MenuValidasiLapReturPenjualan.Show()
        MenuValidasiLapReturPenjualan.Focus()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnProsesJurnalRJ.ItemClick
        MenuProsesJurnalRJ.MdiParent = Me
        MenuProsesJurnalRJ.Show()
        MenuProsesJurnalRJ.Focus()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnCreateLapRB.ItemClick
        MenuCreateLaporanReturPembelian.MdiParent = Me
        MenuCreateLaporanReturPembelian.Show()
        MenuCreateLaporanReturPembelian.Focus()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnValidasiLapRB.ItemClick
        MenuValidasiLapReturPembelian.MdiParent = Me
        MenuValidasiLapReturPembelian.Show()
        MenuValidasiLapReturPembelian.Focus()
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnProsesJurnalRB.ItemClick
        MenuProsesJurnalRB.MdiParent = Me
        MenuProsesJurnalRB.Show()
        MenuProsesJurnalRB.Focus()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnReturPusat.ItemClick
        MenuReturPusat.MdiParent = Me
        MenuReturPusat.Show()
        MenuReturPusat.Focus()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnPelunasanRetur.ItemClick
        MenuPelunasanRetur.MdiParent = Me
        MenuPelunasanRetur.Show()
        MenuPelunasanRetur.Focus()
    End Sub

    Private Sub BtnRincianPembayaran_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRincianPembayaran.ItemClick
        MenuRincianPembayaran.MdiParent = Me
        MenuRincianPembayaran.Show()
        MenuRincianPembayaran.Focus()
    End Sub
End Class