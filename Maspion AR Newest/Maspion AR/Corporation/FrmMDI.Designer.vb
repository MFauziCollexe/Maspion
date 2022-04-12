<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMDI
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMDI))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.BtnUbahPassword = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSwitchPeriode = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLogOut = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnExit = New DevExpress.XtraBars.BarButtonItem()
        Me.LblUser = New DevExpress.XtraBars.BarStaticItem()
        Me.LblTanggal = New DevExpress.XtraBars.BarStaticItem()
        Me.LblJam = New DevExpress.XtraBars.BarStaticItem()
        Me.LblVersion = New DevExpress.XtraBars.BarStaticItem()
        Me.LblKeyboard = New DevExpress.XtraBars.BarStaticItem()
        Me.BtnKaryawan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSupplier = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCustomer = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDivisi = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSBU = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnGudang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPurchaseOrderLangganan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPembelianLangganan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnClaimPembelianLangganan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnReturPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPusatTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPusatBarangDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPusatNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPusatMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPerwakilanBarangDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPerwMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananStuffing = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPerwNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPerwTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwakilanDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMonitoringCustomer = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSuratJalanTanpaHarga = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnBatasMin = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnBatasMax = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTandaTerimaBarangLangganan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnReturLangganan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPenerimaanBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTTB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnReturPenjualan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPriceList = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketStuffing = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCorporation = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnEkspedisi = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTransferBarangRetur = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPerwRefund = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMonitoringStok = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPusatBarangDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPusatTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPusatMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjSupermarketPusatNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPerwakilanBarangDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPerwTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPerwTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPerwMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainStuffing = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPerwNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSuratJalanTanpaHargaLain = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPusatBarangDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPusatTBarangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPusatTBarangBonPesananTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPusatMonPay = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPjLainPusatNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPenitipanBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSJPenitipanBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditLanggananPerwakilan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditLanggananPusat = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditSupermarketPerwakilan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditSupermarketPusat = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditLainPerwakilan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPaymentKreditLainPusat = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDebitNote = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKreditNote = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDailySalesReport = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKartuStok = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTransferBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPenerimaanTransfer = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPurchaseOrderSupermarket = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPembelianSupermarket = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnClaimPembelianSupermarket = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPerusahaan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMappingBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnGroupUser = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPT = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanNotaSJ = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanPriceList = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMoDOOuts = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanPenjualan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSaldoAwalBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLPBL = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnAdjusmentStok = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLPBH = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnReturPembelianTanpaTTB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPostingPeriode = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPenerimaanTransferBarangRetur = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporantransferGudang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSummaryFinishGoods = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnControlSummary = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanAdjusmentStok = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanReturPenjualan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCreateDSRPrw = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiPrw = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKodePerkiraan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnJurnal = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKasMasuk = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKasKeluar = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnBankMasuk = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnBankKeluar = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSetupAkuntansi = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCreateDSRPus = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiPus = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnHargaPromo = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTandaTerima = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPenyerahanNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPengembalianNota = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnProsesJurnalPrw = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnProsesJurnalPus = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPermintaanDibuatkanFakturPajak = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKonfirmasiDibuatkanFakturPajak = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnUangTitipan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMasterBank = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnSetoranPerPT = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKartuPiutang = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKodeBatasan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPembayaranKontan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanSalesPerDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKartuRetur = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCN = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDN = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPengembalianDOKontan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiPengembalian = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKekuranganDO = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiKekurangan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanSaldoUM = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnRekapSaldoDivisi = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnRekapOmsetDivisi = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnRekapOmsetPembayaranCustomer = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnRekapOmsetCorporate = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCutOffDOKontan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDebitNoteKontan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnKreditNoteKontan = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanJurnal = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnLaporanJurnalDetail = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCreateLapPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiLapPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnProsesJurnalPB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCreateLapRJ = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiLapRJ = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnProsesJurnalRJ = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCreateLapRB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnValidasiLapRB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnProsesJurnalRB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnReturPusat = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnPelunasanRetur = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnRincianPembayaran = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategoryPembelian = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PagePembelianLangganan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupPembelianLangganan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PagePembelianSupermarket = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupPembelianSupermarket = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategoryPenjualanLangganan = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PagePenjualanLanggananPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanLanggananPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PagePenjualanLanggananPusat = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanLanggananPusat = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategoryPenjualanSupermarket = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PagePenjualanSupermarketPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanSupermarketPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PagePenjualanSupermarketPusat = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanSupermarketPusat = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategoryPenjualanLain = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PagePenjualanLainPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanLainPerwakilan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PagePenjualanLainPusat = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupPenjualanLainPusat = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategoryAdditional = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PagePenitipanBarang = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupPenitipanBarang = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageRetur = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PagePersediaan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupPersediaanTransferGudang = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GrupMapping = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageMonitoring = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BtnMonitoringMinStok = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageDebitKreditNote = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageLaporan = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupLaporan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup7 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategoryAR = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup10 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup8 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup11 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup12 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup9 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup13 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup14 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup15 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup16 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategorySistem = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.PageSistem = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupSistem = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageUser = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupUser = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PageMaster = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GrupMasterUmum = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GrupLokasi = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.NavBarItem9 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Maspion.WaitForm1), True, True)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonDropDownControl = Me.ApplicationMenu1
        Me.RibbonControl.AutoSizeItems = True
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.LblUser, Me.LblTanggal, Me.LblJam, Me.LblVersion, Me.LblKeyboard, Me.BtnUbahPassword, Me.BtnLogOut, Me.BtnExit, Me.BtnSwitchPeriode, Me.BtnKaryawan, Me.BtnSupplier, Me.BtnCustomer, Me.BtnDivisi, Me.BtnSBU, Me.BtnGudang, Me.BtnPurchaseOrderLangganan, Me.BtnPembelianLangganan, Me.BtnClaimPembelianLangganan, Me.BtnReturPembelian, Me.BtnBarang, Me.BtnPjLanggananPusatTBarangTitipan, Me.BtnPjLanggananPusatTBarangBonPesananTitipan, Me.BtnPjLanggananPusatBarangDO, Me.BtnPjLanggananPusatNota, Me.BtnPjLanggananPusatMonPay, Me.BtnPjLanggananPerwakilanBarangDO, Me.BtnPjLanggananPerwMonPay, Me.BtnPjLanggananStuffing, Me.BtnPjLanggananPerwNota, Me.BtnPjLanggananPerwTBarangTitipan, Me.BtnPjLanggananPerwTBarangBonPesananTitipan, Me.BtnPjSupermarketPerwakilanDO, Me.BtnPjSupermarketPerwTBarangTitipan, Me.BtnPjSupermarketPerwTBarangBonPesananTitipan, Me.BtnMonitoringCustomer, Me.BtnSuratJalanTanpaHarga, Me.BtnBatasMin, Me.BtnBatasMax, Me.BtnTandaTerimaBarangLangganan, Me.BtnReturLangganan, Me.BtnPenerimaanBarang, Me.BtnTTB, Me.BtnReturPenjualan, Me.BtnPriceList, Me.BtnPjSupermarketPerwMonPay, Me.BtnPjSupermarketStuffing, Me.BtnPjSupermarketPerwNota, Me.BtnCorporation, Me.BtnEkspedisi, Me.BtnTransferBarangRetur, Me.BtnPjSupermarketPerwRefund, Me.BtnMonitoringStok, Me.BtnPjSupermarketPusatBarangDO, Me.BtnPjSupermarketPusatTBarangTitipan, Me.BtnPjSupermarketPusatTBarangBonPesananTitipan, Me.BtnPjSupermarketPusatMonPay, Me.BtnPjSupermarketPusatNota, Me.BtnPjLainPerwakilanBarangDO, Me.BtnPjLainPerwTBarangTitipan, Me.BtnPjLainPerwTBarangBonPesananTitipan, Me.BtnPjLainPerwMonPay, Me.BtnPjLainStuffing, Me.BtnPjLainPerwNota, Me.BtnSuratJalanTanpaHargaLain, Me.BtnPjLainPusatBarangDO, Me.BtnPjLainPusatTBarangTitipan, Me.BtnPjLainPusatTBarangBonPesananTitipan, Me.BtnPjLainPusatMonPay, Me.BtnPjLainPusatNota, Me.BtnPenitipanBarang, Me.BtnSJPenitipanBarang, Me.BtnPaymentKreditLanggananPerwakilan, Me.BtnPaymentKreditLanggananPusat, Me.BtnPaymentKreditSupermarketPerwakilan, Me.BtnPaymentKreditSupermarketPusat, Me.BtnPaymentKreditLainPerwakilan, Me.BtnPaymentKreditLainPusat, Me.BtnDebitNote, Me.BtnKreditNote, Me.BtnDailySalesReport, Me.BtnKartuStok, Me.BtnTransferBarang, Me.BtnPenerimaanTransfer, Me.BtnPurchaseOrderSupermarket, Me.BtnPembelianSupermarket, Me.BtnClaimPembelianSupermarket, Me.BtnPerusahaan, Me.BtnMappingBarang, Me.BtnGroupUser, Me.BtnPT, Me.BtnLaporanPembelian, Me.BtnLaporanDO, Me.BtnLaporanNotaSJ, Me.BtnLaporanPriceList, Me.BtnMoDOOuts, Me.BtnLaporanPenjualan, Me.BtnSaldoAwalBarang, Me.BtnLPBL, Me.BtnAdjusmentStok, Me.BtnLPBH, Me.BtnReturPembelianTanpaTTB, Me.BtnPostingPeriode, Me.BtnPenerimaanTransferBarangRetur, Me.BtnLaporantransferGudang, Me.BtnSummaryFinishGoods, Me.BtnControlSummary, Me.BtnLaporanAdjusmentStok, Me.BtnLaporanReturPenjualan, Me.BtnCreateDSRPrw, Me.BtnValidasiPrw, Me.BtnKodePerkiraan, Me.BtnJurnal, Me.BtnKasMasuk, Me.BtnKasKeluar, Me.BtnBankMasuk, Me.BtnBankKeluar, Me.BtnSetupAkuntansi, Me.BtnCreateDSRPus, Me.BtnValidasiPus, Me.BtnHargaPromo, Me.BtnTandaTerima, Me.BtnPenyerahanNota, Me.BtnPengembalianNota, Me.BtnProsesJurnalPrw, Me.BtnProsesJurnalPus, Me.BtnPermintaanDibuatkanFakturPajak, Me.BtnKonfirmasiDibuatkanFakturPajak, Me.BtnUangTitipan, Me.BtnMasterBank, Me.BtnSetoranPerPT, Me.BtnKartuPiutang, Me.BtnKodeBatasan, Me.BtnPembayaranKontan, Me.BtnLaporanSalesPerDO, Me.BtnKartuRetur, Me.BtnCN, Me.BtnDN, Me.BtnPengembalianDOKontan, Me.BtnValidasiPengembalian, Me.BtnKekuranganDO, Me.BtnValidasiKekurangan, Me.BtnLaporanSaldoUM, Me.BtnRekapSaldoDivisi, Me.BtnRekapOmsetDivisi, Me.BtnRekapOmsetPembayaranCustomer, Me.BtnRekapOmsetCorporate, Me.BtnCutOffDOKontan, Me.BtnDebitNoteKontan, Me.BtnKreditNoteKontan, Me.BtnLaporanJurnal, Me.BtnLaporanJurnalDetail, Me.BtnCreateLapPembelian, Me.BtnValidasiLapPembelian, Me.BtnProsesJurnalPB, Me.BtnCreateLapRJ, Me.BtnValidasiLapRJ, Me.BtnProsesJurnalRJ, Me.BtnCreateLapRB, Me.BtnValidasiLapRB, Me.BtnProsesJurnalRB, Me.BtnReturPusat, Me.BtnPelunasanRetur, Me.BtnRincianPembayaran})
        resources.ApplyResources(Me.RibbonControl, "RibbonControl")
        Me.RibbonControl.MaxItemId = 235
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategoryPembelian, Me.RibbonPageCategoryPenjualanLangganan, Me.RibbonPageCategoryPenjualanSupermarket, Me.RibbonPageCategoryPenjualanLain, Me.RibbonPageCategoryAdditional, Me.RibbonPageCategoryAR, Me.RibbonPageCategorySistem})
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PageUser, Me.PageMaster})
        Me.RibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'ApplicationMenu1
        '
        Me.ApplicationMenu1.ItemLinks.Add(Me.BtnUbahPassword)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BtnSwitchPeriode)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BtnLogOut)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BtnExit)
        Me.ApplicationMenu1.Name = "ApplicationMenu1"
        Me.ApplicationMenu1.Ribbon = Me.RibbonControl
        '
        'BtnUbahPassword
        '
        resources.ApplyResources(Me.BtnUbahPassword, "BtnUbahPassword")
        Me.BtnUbahPassword.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnUbahPassword.Id = 6
        Me.BtnUbahPassword.ImageOptions.Image = Global.Maspion.My.Resources.Resources.UbahPassword
        Me.BtnUbahPassword.Name = "BtnUbahPassword"
        Me.BtnUbahPassword.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnSwitchPeriode
        '
        resources.ApplyResources(Me.BtnSwitchPeriode, "BtnSwitchPeriode")
        Me.BtnSwitchPeriode.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnSwitchPeriode.Id = 10
        Me.BtnSwitchPeriode.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Switch_Periode
        Me.BtnSwitchPeriode.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Switch_Periode
        Me.BtnSwitchPeriode.Name = "BtnSwitchPeriode"
        Me.BtnSwitchPeriode.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BtnLogOut
        '
        resources.ApplyResources(Me.BtnLogOut, "BtnLogOut")
        Me.BtnLogOut.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnLogOut.Id = 8
        Me.BtnLogOut.ImageOptions.Image = Global.Maspion.My.Resources.Resources.LogOut
        Me.BtnLogOut.Name = "BtnLogOut"
        Me.BtnLogOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BtnExit
        '
        resources.ApplyResources(Me.BtnExit, "BtnExit")
        Me.BtnExit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnExit.Id = 9
        Me.BtnExit.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.ExitIcon
        Me.BtnExit.ImageOptions.Image = Global.Maspion.My.Resources.Resources.ExitIcon
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'LblUser
        '
        resources.ApplyResources(Me.LblUser, "LblUser")
        Me.LblUser.Id = 1
        Me.LblUser.Name = "LblUser"
        '
        'LblTanggal
        '
        resources.ApplyResources(Me.LblTanggal, "LblTanggal")
        Me.LblTanggal.Id = 2
        Me.LblTanggal.Name = "LblTanggal"
        '
        'LblJam
        '
        resources.ApplyResources(Me.LblJam, "LblJam")
        Me.LblJam.Id = 3
        Me.LblJam.Name = "LblJam"
        '
        'LblVersion
        '
        resources.ApplyResources(Me.LblVersion, "LblVersion")
        Me.LblVersion.Id = 4
        Me.LblVersion.Name = "LblVersion"
        '
        'LblKeyboard
        '
        resources.ApplyResources(Me.LblKeyboard, "LblKeyboard")
        Me.LblKeyboard.Id = 5
        Me.LblKeyboard.Name = "LblKeyboard"
        '
        'BtnKaryawan
        '
        resources.ApplyResources(Me.BtnKaryawan, "BtnKaryawan")
        Me.BtnKaryawan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnKaryawan.Id = 20
        Me.BtnKaryawan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Karyawan
        Me.BtnKaryawan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Karyawan
        Me.BtnKaryawan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Karyawan
        Me.BtnKaryawan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Karyawan
        Me.BtnKaryawan.Name = "BtnKaryawan"
        '
        'BtnSupplier
        '
        resources.ApplyResources(Me.BtnSupplier, "BtnSupplier")
        Me.BtnSupplier.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnSupplier.Enabled = False
        Me.BtnSupplier.Id = 57
        Me.BtnSupplier.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Supplier
        Me.BtnSupplier.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Supplier
        Me.BtnSupplier.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Supplier
        Me.BtnSupplier.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Supplier
        Me.BtnSupplier.Name = "BtnSupplier"
        Me.BtnSupplier.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BtnCustomer
        '
        resources.ApplyResources(Me.BtnCustomer, "BtnCustomer")
        Me.BtnCustomer.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnCustomer.Id = 58
        Me.BtnCustomer.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Pendaftaran_Costumer
        Me.BtnCustomer.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Pendaftaran_Costumer
        Me.BtnCustomer.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Pendaftaran_Costumer
        Me.BtnCustomer.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Pendaftaran_Costumer
        Me.BtnCustomer.Name = "BtnCustomer"
        '
        'BtnDivisi
        '
        resources.ApplyResources(Me.BtnDivisi, "BtnDivisi")
        Me.BtnDivisi.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnDivisi.Id = 59
        Me.BtnDivisi.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Divisi
        Me.BtnDivisi.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Divisi
        Me.BtnDivisi.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Divisi
        Me.BtnDivisi.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Divisi
        Me.BtnDivisi.Name = "BtnDivisi"
        '
        'BtnSBU
        '
        resources.ApplyResources(Me.BtnSBU, "BtnSBU")
        Me.BtnSBU.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnSBU.Id = 60
        Me.BtnSBU.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.SBU
        Me.BtnSBU.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.SBU
        Me.BtnSBU.ImageOptions.Image = Global.Maspion.My.Resources.Resources.SBU
        Me.BtnSBU.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.SBU
        Me.BtnSBU.Name = "BtnSBU"
        '
        'BtnGudang
        '
        resources.ApplyResources(Me.BtnGudang, "BtnGudang")
        Me.BtnGudang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnGudang.Id = 61
        Me.BtnGudang.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Gudang
        Me.BtnGudang.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Gudang
        Me.BtnGudang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Gudang
        Me.BtnGudang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Gudang
        Me.BtnGudang.Name = "BtnGudang"
        '
        'BtnPurchaseOrderLangganan
        '
        resources.ApplyResources(Me.BtnPurchaseOrderLangganan, "BtnPurchaseOrderLangganan")
        Me.BtnPurchaseOrderLangganan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPurchaseOrderLangganan.Id = 62
        Me.BtnPurchaseOrderLangganan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderLangganan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderLangganan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderLangganan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderLangganan.Name = "BtnPurchaseOrderLangganan"
        '
        'BtnPembelianLangganan
        '
        resources.ApplyResources(Me.BtnPembelianLangganan, "BtnPembelianLangganan")
        Me.BtnPembelianLangganan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPembelianLangganan.Id = 63
        Me.BtnPembelianLangganan.ImageOptions.DisabledImage = CType(resources.GetObject("BtnPembelianLangganan.ImageOptions.DisabledImage"), System.Drawing.Image)
        Me.BtnPembelianLangganan.ImageOptions.DisabledLargeImage = CType(resources.GetObject("BtnPembelianLangganan.ImageOptions.DisabledLargeImage"), System.Drawing.Image)
        Me.BtnPembelianLangganan.ImageOptions.Image = CType(resources.GetObject("BtnPembelianLangganan.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPembelianLangganan.ImageOptions.LargeImage = CType(resources.GetObject("BtnPembelianLangganan.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPembelianLangganan.Name = "BtnPembelianLangganan"
        '
        'BtnClaimPembelianLangganan
        '
        resources.ApplyResources(Me.BtnClaimPembelianLangganan, "BtnClaimPembelianLangganan")
        Me.BtnClaimPembelianLangganan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnClaimPembelianLangganan.Id = 64
        Me.BtnClaimPembelianLangganan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianLangganan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianLangganan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianLangganan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianLangganan.Name = "BtnClaimPembelianLangganan"
        '
        'BtnReturPembelian
        '
        resources.ApplyResources(Me.BtnReturPembelian, "BtnReturPembelian")
        Me.BtnReturPembelian.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnReturPembelian.Id = 65
        Me.BtnReturPembelian.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.ReturPembelian
        Me.BtnReturPembelian.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.ReturPembelian
        Me.BtnReturPembelian.ImageOptions.Image = Global.Maspion.My.Resources.Resources.ReturPembelian
        Me.BtnReturPembelian.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.ReturPembelian
        Me.BtnReturPembelian.Name = "BtnReturPembelian"
        '
        'BtnBarang
        '
        resources.ApplyResources(Me.BtnBarang, "BtnBarang")
        Me.BtnBarang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnBarang.Id = 67
        Me.BtnBarang.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Barang
        Me.BtnBarang.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Barang
        Me.BtnBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Barang
        Me.BtnBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Barang
        Me.BtnBarang.Name = "BtnBarang"
        '
        'BtnPjLanggananPusatTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjLanggananPusatTBarangTitipan, "BtnPjLanggananPusatTBarangTitipan")
        Me.BtnPjLanggananPusatTBarangTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPusatTBarangTitipan.Id = 87
        Me.BtnPjLanggananPusatTBarangTitipan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPusatTBarangTitipan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPusatTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPusatTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPusatTBarangTitipan.Name = "BtnPjLanggananPusatTBarangTitipan"
        '
        'BtnPjLanggananPusatTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjLanggananPusatTBarangBonPesananTitipan, "BtnPjLanggananPusatTBarangBonPesananTitipan")
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.Id = 88
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLanggananPusatTBarangBonPesananTitipan.Name = "BtnPjLanggananPusatTBarangBonPesananTitipan"
        '
        'BtnPjLanggananPusatBarangDO
        '
        resources.ApplyResources(Me.BtnPjLanggananPusatBarangDO, "BtnPjLanggananPusatBarangDO")
        Me.BtnPjLanggananPusatBarangDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPusatBarangDO.Id = 89
        Me.BtnPjLanggananPusatBarangDO.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLanggananPusatBarangDO.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLanggananPusatBarangDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLanggananPusatBarangDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLanggananPusatBarangDO.Name = "BtnPjLanggananPusatBarangDO"
        '
        'BtnPjLanggananPusatNota
        '
        resources.ApplyResources(Me.BtnPjLanggananPusatNota, "BtnPjLanggananPusatNota")
        Me.BtnPjLanggananPusatNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPusatNota.Id = 90
        Me.BtnPjLanggananPusatNota.ImageOptions.DisabledImage = CType(resources.GetObject("BtnPjLanggananPusatNota.ImageOptions.DisabledImage"), System.Drawing.Image)
        Me.BtnPjLanggananPusatNota.ImageOptions.DisabledLargeImage = CType(resources.GetObject("BtnPjLanggananPusatNota.ImageOptions.DisabledLargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPusatNota.ImageOptions.Image = CType(resources.GetObject("BtnPjLanggananPusatNota.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPjLanggananPusatNota.ImageOptions.LargeImage = CType(resources.GetObject("BtnPjLanggananPusatNota.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPusatNota.Name = "BtnPjLanggananPusatNota"
        '
        'BtnPjLanggananPusatMonPay
        '
        resources.ApplyResources(Me.BtnPjLanggananPusatMonPay, "BtnPjLanggananPusatMonPay")
        Me.BtnPjLanggananPusatMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPusatMonPay.Id = 91
        Me.BtnPjLanggananPusatMonPay.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLanggananPusatMonPay.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLanggananPusatMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLanggananPusatMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLanggananPusatMonPay.Name = "BtnPjLanggananPusatMonPay"
        '
        'BtnPjLanggananPerwakilanBarangDO
        '
        resources.ApplyResources(Me.BtnPjLanggananPerwakilanBarangDO, "BtnPjLanggananPerwakilanBarangDO")
        Me.BtnPjLanggananPerwakilanBarangDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPerwakilanBarangDO.Id = 92
        Me.BtnPjLanggananPerwakilanBarangDO.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLanggananPerwakilanBarangDO.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLanggananPerwakilanBarangDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLanggananPerwakilanBarangDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLanggananPerwakilanBarangDO.Name = "BtnPjLanggananPerwakilanBarangDO"
        '
        'BtnPjLanggananPerwMonPay
        '
        resources.ApplyResources(Me.BtnPjLanggananPerwMonPay, "BtnPjLanggananPerwMonPay")
        Me.BtnPjLanggananPerwMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPerwMonPay.Id = 94
        Me.BtnPjLanggananPerwMonPay.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLanggananPerwMonPay.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLanggananPerwMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLanggananPerwMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLanggananPerwMonPay.Name = "BtnPjLanggananPerwMonPay"
        '
        'BtnPjLanggananStuffing
        '
        resources.ApplyResources(Me.BtnPjLanggananStuffing, "BtnPjLanggananStuffing")
        Me.BtnPjLanggananStuffing.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananStuffing.Id = 95
        Me.BtnPjLanggananStuffing.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLanggananStuffing.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLanggananStuffing.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLanggananStuffing.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLanggananStuffing.Name = "BtnPjLanggananStuffing"
        '
        'BtnPjLanggananPerwNota
        '
        resources.ApplyResources(Me.BtnPjLanggananPerwNota, "BtnPjLanggananPerwNota")
        Me.BtnPjLanggananPerwNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPerwNota.Id = 96
        Me.BtnPjLanggananPerwNota.ImageOptions.DisabledImage = CType(resources.GetObject("BtnPjLanggananPerwNota.ImageOptions.DisabledImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwNota.ImageOptions.DisabledLargeImage = CType(resources.GetObject("BtnPjLanggananPerwNota.ImageOptions.DisabledLargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwNota.ImageOptions.Image = CType(resources.GetObject("BtnPjLanggananPerwNota.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPjLanggananPerwNota.ImageOptions.LargeImage = CType(resources.GetObject("BtnPjLanggananPerwNota.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwNota.Name = "BtnPjLanggananPerwNota"
        '
        'BtnPjLanggananPerwTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjLanggananPerwTBarangTitipan, "BtnPjLanggananPerwTBarangTitipan")
        Me.BtnPjLanggananPerwTBarangTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPerwTBarangTitipan.Enabled = False
        Me.BtnPjLanggananPerwTBarangTitipan.Id = 97
        Me.BtnPjLanggananPerwTBarangTitipan.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPerwTBarangTitipan.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPerwTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPerwTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLanggananPerwTBarangTitipan.Name = "BtnPjLanggananPerwTBarangTitipan"
        '
        'BtnPjLanggananPerwTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjLanggananPerwTBarangBonPesananTitipan, "BtnPjLanggananPerwTBarangBonPesananTitipan")
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.Enabled = False
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.Id = 98
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.DisabledImage = CType(resources.GetObject("BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.DisabledImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.DisabledLargeImage = CType(resources.GetObject("BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.DisabledLargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.Image = CType(resources.GetObject("BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.LargeImage = CType(resources.GetObject("BtnPjLanggananPerwTBarangBonPesananTitipan.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPjLanggananPerwTBarangBonPesananTitipan.Name = "BtnPjLanggananPerwTBarangBonPesananTitipan"
        '
        'BtnPjSupermarketPerwakilanDO
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwakilanDO, "BtnPjSupermarketPerwakilanDO")
        Me.BtnPjSupermarketPerwakilanDO.Id = 100
        Me.BtnPjSupermarketPerwakilanDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjSupermarketPerwakilanDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjSupermarketPerwakilanDO.Name = "BtnPjSupermarketPerwakilanDO"
        '
        'BtnPjSupermarketPerwTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwTBarangTitipan, "BtnPjSupermarketPerwTBarangTitipan")
        Me.BtnPjSupermarketPerwTBarangTitipan.Enabled = False
        Me.BtnPjSupermarketPerwTBarangTitipan.Id = 101
        Me.BtnPjSupermarketPerwTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjSupermarketPerwTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjSupermarketPerwTBarangTitipan.Name = "BtnPjSupermarketPerwTBarangTitipan"
        '
        'BtnPjSupermarketPerwTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwTBarangBonPesananTitipan, "BtnPjSupermarketPerwTBarangBonPesananTitipan")
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan.Enabled = False
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan.Id = 102
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Ordering
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Ordering
        Me.BtnPjSupermarketPerwTBarangBonPesananTitipan.Name = "BtnPjSupermarketPerwTBarangBonPesananTitipan"
        '
        'BtnMonitoringCustomer
        '
        resources.ApplyResources(Me.BtnMonitoringCustomer, "BtnMonitoringCustomer")
        Me.BtnMonitoringCustomer.Id = 103
        Me.BtnMonitoringCustomer.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.SPK
        Me.BtnMonitoringCustomer.Name = "BtnMonitoringCustomer"
        '
        'BtnSuratJalanTanpaHarga
        '
        resources.ApplyResources(Me.BtnSuratJalanTanpaHarga, "BtnSuratJalanTanpaHarga")
        Me.BtnSuratJalanTanpaHarga.Id = 104
        Me.BtnSuratJalanTanpaHarga.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Suplier
        Me.BtnSuratJalanTanpaHarga.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Suplier
        Me.BtnSuratJalanTanpaHarga.Name = "BtnSuratJalanTanpaHarga"
        '
        'BtnBatasMin
        '
        resources.ApplyResources(Me.BtnBatasMin, "BtnBatasMin")
        Me.BtnBatasMin.Id = 105
        Me.BtnBatasMin.Name = "BtnBatasMin"
        Me.BtnBatasMin.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.BtnBatasMin.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BtnBatasMax
        '
        resources.ApplyResources(Me.BtnBatasMax, "BtnBatasMax")
        Me.BtnBatasMax.Id = 106
        Me.BtnBatasMax.Name = "BtnBatasMax"
        Me.BtnBatasMax.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.BtnBatasMax.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BtnTandaTerimaBarangLangganan
        '
        resources.ApplyResources(Me.BtnTandaTerimaBarangLangganan, "BtnTandaTerimaBarangLangganan")
        Me.BtnTandaTerimaBarangLangganan.Id = 107
        Me.BtnTandaTerimaBarangLangganan.Name = "BtnTandaTerimaBarangLangganan"
        '
        'BtnReturLangganan
        '
        resources.ApplyResources(Me.BtnReturLangganan, "BtnReturLangganan")
        Me.BtnReturLangganan.Id = 108
        Me.BtnReturLangganan.Name = "BtnReturLangganan"
        '
        'BtnPenerimaanBarang
        '
        resources.ApplyResources(Me.BtnPenerimaanBarang, "BtnPenerimaanBarang")
        Me.BtnPenerimaanBarang.Id = 112
        Me.BtnPenerimaanBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PenerimaanBarang
        Me.BtnPenerimaanBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PenerimaanBarang
        Me.BtnPenerimaanBarang.Name = "BtnPenerimaanBarang"
        '
        'BtnTTB
        '
        resources.ApplyResources(Me.BtnTTB, "BtnTTB")
        Me.BtnTTB.Id = 113
        Me.BtnTTB.ImageOptions.Image = Global.Maspion.My.Resources.Resources.TTB
        Me.BtnTTB.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.TTB
        Me.BtnTTB.Name = "BtnTTB"
        Me.BtnTTB.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnReturPenjualan
        '
        resources.ApplyResources(Me.BtnReturPenjualan, "BtnReturPenjualan")
        Me.BtnReturPenjualan.Id = 114
        Me.BtnReturPenjualan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.return_icon
        Me.BtnReturPenjualan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.return_icon
        Me.BtnReturPenjualan.Name = "BtnReturPenjualan"
        Me.BtnReturPenjualan.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnPriceList
        '
        resources.ApplyResources(Me.BtnPriceList, "BtnPriceList")
        Me.BtnPriceList.Id = 116
        Me.BtnPriceList.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Price_List
        Me.BtnPriceList.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Price_List
        Me.BtnPriceList.Name = "BtnPriceList"
        '
        'BtnPjSupermarketPerwMonPay
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwMonPay, "BtnPjSupermarketPerwMonPay")
        Me.BtnPjSupermarketPerwMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPerwMonPay.Id = 117
        Me.BtnPjSupermarketPerwMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjSupermarketPerwMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjSupermarketPerwMonPay.Name = "BtnPjSupermarketPerwMonPay"
        '
        'BtnPjSupermarketStuffing
        '
        resources.ApplyResources(Me.BtnPjSupermarketStuffing, "BtnPjSupermarketStuffing")
        Me.BtnPjSupermarketStuffing.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketStuffing.Id = 118
        Me.BtnPjSupermarketStuffing.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjSupermarketStuffing.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjSupermarketStuffing.Name = "BtnPjSupermarketStuffing"
        '
        'BtnPjSupermarketPerwNota
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwNota, "BtnPjSupermarketPerwNota")
        Me.BtnPjSupermarketPerwNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPerwNota.Id = 119
        Me.BtnPjSupermarketPerwNota.ImageOptions.Image = Global.Maspion.My.Resources.Resources.invoice_512
        Me.BtnPjSupermarketPerwNota.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.invoice_512
        Me.BtnPjSupermarketPerwNota.Name = "BtnPjSupermarketPerwNota"
        '
        'BtnCorporation
        '
        resources.ApplyResources(Me.BtnCorporation, "BtnCorporation")
        Me.BtnCorporation.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnCorporation.Id = 1
        Me.BtnCorporation.ImageOptions.Image = Global.Maspion.My.Resources.Resources.company
        Me.BtnCorporation.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.company
        Me.BtnCorporation.Name = "BtnCorporation"
        '
        'BtnEkspedisi
        '
        resources.ApplyResources(Me.BtnEkspedisi, "BtnEkspedisi")
        Me.BtnEkspedisi.Id = 118
        Me.BtnEkspedisi.ImageOptions.Image = Global.Maspion.My.Resources.Resources.icon_truck
        Me.BtnEkspedisi.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.icon_truck
        Me.BtnEkspedisi.Name = "BtnEkspedisi"
        '
        'BtnTransferBarangRetur
        '
        resources.ApplyResources(Me.BtnTransferBarangRetur, "BtnTransferBarangRetur")
        Me.BtnTransferBarangRetur.Id = 119
        Me.BtnTransferBarangRetur.ImageOptions.Image = CType(resources.GetObject("BtnTransferBarangRetur.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnTransferBarangRetur.ImageOptions.LargeImage = CType(resources.GetObject("BtnTransferBarangRetur.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnTransferBarangRetur.Name = "BtnTransferBarangRetur"
        Me.BtnTransferBarangRetur.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnPjSupermarketPerwRefund
        '
        resources.ApplyResources(Me.BtnPjSupermarketPerwRefund, "BtnPjSupermarketPerwRefund")
        Me.BtnPjSupermarketPerwRefund.Id = 120
        Me.BtnPjSupermarketPerwRefund.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Refund
        Me.BtnPjSupermarketPerwRefund.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Refund
        Me.BtnPjSupermarketPerwRefund.Name = "BtnPjSupermarketPerwRefund"
        Me.BtnPjSupermarketPerwRefund.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnMonitoringStok
        '
        resources.ApplyResources(Me.BtnMonitoringStok, "BtnMonitoringStok")
        Me.BtnMonitoringStok.Id = 121
        Me.BtnMonitoringStok.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Stok
        Me.BtnMonitoringStok.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Stok
        Me.BtnMonitoringStok.Name = "BtnMonitoringStok"
        '
        'BtnPjSupermarketPusatBarangDO
        '
        resources.ApplyResources(Me.BtnPjSupermarketPusatBarangDO, "BtnPjSupermarketPusatBarangDO")
        Me.BtnPjSupermarketPusatBarangDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPusatBarangDO.Id = 122
        Me.BtnPjSupermarketPusatBarangDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjSupermarketPusatBarangDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjSupermarketPusatBarangDO.Name = "BtnPjSupermarketPusatBarangDO"
        '
        'BtnPjSupermarketPusatTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjSupermarketPusatTBarangTitipan, "BtnPjSupermarketPusatTBarangTitipan")
        Me.BtnPjSupermarketPusatTBarangTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPusatTBarangTitipan.Id = 123
        Me.BtnPjSupermarketPusatTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjSupermarketPusatTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjSupermarketPusatTBarangTitipan.Name = "BtnPjSupermarketPusatTBarangTitipan"
        '
        'BtnPjSupermarketPusatTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjSupermarketPusatTBarangBonPesananTitipan, "BtnPjSupermarketPusatTBarangBonPesananTitipan")
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan.Id = 124
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjSupermarketPusatTBarangBonPesananTitipan.Name = "BtnPjSupermarketPusatTBarangBonPesananTitipan"
        '
        'BtnPjSupermarketPusatMonPay
        '
        resources.ApplyResources(Me.BtnPjSupermarketPusatMonPay, "BtnPjSupermarketPusatMonPay")
        Me.BtnPjSupermarketPusatMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPusatMonPay.Id = 125
        Me.BtnPjSupermarketPusatMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjSupermarketPusatMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjSupermarketPusatMonPay.Name = "BtnPjSupermarketPusatMonPay"
        '
        'BtnPjSupermarketPusatNota
        '
        resources.ApplyResources(Me.BtnPjSupermarketPusatNota, "BtnPjSupermarketPusatNota")
        Me.BtnPjSupermarketPusatNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjSupermarketPusatNota.Id = 126
        Me.BtnPjSupermarketPusatNota.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Invoice_Penjualan
        Me.BtnPjSupermarketPusatNota.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Invoice_Penjualan
        Me.BtnPjSupermarketPusatNota.Name = "BtnPjSupermarketPusatNota"
        '
        'BtnPjLainPerwakilanBarangDO
        '
        resources.ApplyResources(Me.BtnPjLainPerwakilanBarangDO, "BtnPjLainPerwakilanBarangDO")
        Me.BtnPjLainPerwakilanBarangDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPerwakilanBarangDO.Id = 127
        Me.BtnPjLainPerwakilanBarangDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLainPerwakilanBarangDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BtnPjLainPerwakilanBarangDO.Name = "BtnPjLainPerwakilanBarangDO"
        '
        'BtnPjLainPerwTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjLainPerwTBarangTitipan, "BtnPjLainPerwTBarangTitipan")
        Me.BtnPjLainPerwTBarangTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPerwTBarangTitipan.Id = 128
        Me.BtnPjLainPerwTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLainPerwTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLainPerwTBarangTitipan.Name = "BtnPjLainPerwTBarangTitipan"
        '
        'BtnPjLainPerwTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjLainPerwTBarangBonPesananTitipan, "BtnPjLainPerwTBarangBonPesananTitipan")
        Me.BtnPjLainPerwTBarangBonPesananTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPerwTBarangBonPesananTitipan.Id = 129
        Me.BtnPjLainPerwTBarangBonPesananTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Ordering
        Me.BtnPjLainPerwTBarangBonPesananTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Ordering
        Me.BtnPjLainPerwTBarangBonPesananTitipan.Name = "BtnPjLainPerwTBarangBonPesananTitipan"
        '
        'BtnPjLainPerwMonPay
        '
        resources.ApplyResources(Me.BtnPjLainPerwMonPay, "BtnPjLainPerwMonPay")
        Me.BtnPjLainPerwMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPerwMonPay.Id = 130
        Me.BtnPjLainPerwMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLainPerwMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Pyment_Perwakilan
        Me.BtnPjLainPerwMonPay.Name = "BtnPjLainPerwMonPay"
        '
        'BtnPjLainStuffing
        '
        resources.ApplyResources(Me.BtnPjLainStuffing, "BtnPjLainStuffing")
        Me.BtnPjLainStuffing.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainStuffing.Id = 131
        Me.BtnPjLainStuffing.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLainStuffing.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Staffing
        Me.BtnPjLainStuffing.Name = "BtnPjLainStuffing"
        '
        'BtnPjLainPerwNota
        '
        resources.ApplyResources(Me.BtnPjLainPerwNota, "BtnPjLainPerwNota")
        Me.BtnPjLainPerwNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPerwNota.Id = 132
        Me.BtnPjLainPerwNota.ImageOptions.Image = Global.Maspion.My.Resources.Resources.invoice_512
        Me.BtnPjLainPerwNota.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.invoice_512
        Me.BtnPjLainPerwNota.Name = "BtnPjLainPerwNota"
        '
        'BtnSuratJalanTanpaHargaLain
        '
        resources.ApplyResources(Me.BtnSuratJalanTanpaHargaLain, "BtnSuratJalanTanpaHargaLain")
        Me.BtnSuratJalanTanpaHargaLain.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnSuratJalanTanpaHargaLain.Id = 133
        Me.BtnSuratJalanTanpaHargaLain.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Suplier
        Me.BtnSuratJalanTanpaHargaLain.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Suplier
        Me.BtnSuratJalanTanpaHargaLain.Name = "BtnSuratJalanTanpaHargaLain"
        '
        'BtnPjLainPusatBarangDO
        '
        resources.ApplyResources(Me.BtnPjLainPusatBarangDO, "BtnPjLainPusatBarangDO")
        Me.BtnPjLainPusatBarangDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPusatBarangDO.Id = 134
        Me.BtnPjLainPusatBarangDO.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLainPusatBarangDO.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order
        Me.BtnPjLainPusatBarangDO.Name = "BtnPjLainPusatBarangDO"
        '
        'BtnPjLainPusatTBarangTitipan
        '
        resources.ApplyResources(Me.BtnPjLainPusatTBarangTitipan, "BtnPjLainPusatTBarangTitipan")
        Me.BtnPjLainPusatTBarangTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPusatTBarangTitipan.Id = 135
        Me.BtnPjLainPusatTBarangTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLainPusatTBarangTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.DO_Titipan
        Me.BtnPjLainPusatTBarangTitipan.Name = "BtnPjLainPusatTBarangTitipan"
        '
        'BtnPjLainPusatTBarangBonPesananTitipan
        '
        resources.ApplyResources(Me.BtnPjLainPusatTBarangBonPesananTitipan, "BtnPjLainPusatTBarangBonPesananTitipan")
        Me.BtnPjLainPusatTBarangBonPesananTitipan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPusatTBarangBonPesananTitipan.Id = 136
        Me.BtnPjLainPusatTBarangBonPesananTitipan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLainPusatTBarangBonPesananTitipan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Bon_Pesanan_Titipan
        Me.BtnPjLainPusatTBarangBonPesananTitipan.Name = "BtnPjLainPusatTBarangBonPesananTitipan"
        '
        'BtnPjLainPusatMonPay
        '
        resources.ApplyResources(Me.BtnPjLainPusatMonPay, "BtnPjLainPusatMonPay")
        Me.BtnPjLainPusatMonPay.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPusatMonPay.Id = 137
        Me.BtnPjLainPusatMonPay.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLainPusatMonPay.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Monitoring_Payment
        Me.BtnPjLainPusatMonPay.Name = "BtnPjLainPusatMonPay"
        '
        'BtnPjLainPusatNota
        '
        resources.ApplyResources(Me.BtnPjLainPusatNota, "BtnPjLainPusatNota")
        Me.BtnPjLainPusatNota.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPjLainPusatNota.Id = 138
        Me.BtnPjLainPusatNota.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Invoice_Penjualan
        Me.BtnPjLainPusatNota.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Invoice_Penjualan
        Me.BtnPjLainPusatNota.Name = "BtnPjLainPusatNota"
        '
        'BtnPenitipanBarang
        '
        resources.ApplyResources(Me.BtnPenitipanBarang, "BtnPenitipanBarang")
        Me.BtnPenitipanBarang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPenitipanBarang.Id = 139
        Me.BtnPenitipanBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.TitipBarang
        Me.BtnPenitipanBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.TitipBarang
        Me.BtnPenitipanBarang.Name = "BtnPenitipanBarang"
        Me.BtnPenitipanBarang.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnSJPenitipanBarang
        '
        resources.ApplyResources(Me.BtnSJPenitipanBarang, "BtnSJPenitipanBarang")
        Me.BtnSJPenitipanBarang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnSJPenitipanBarang.Id = 140
        Me.BtnSJPenitipanBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.SuratJalanPenitipanBarang
        Me.BtnSJPenitipanBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.SuratJalanPenitipanBarang
        Me.BtnSJPenitipanBarang.Name = "BtnSJPenitipanBarang"
        '
        'BtnPaymentKreditLanggananPerwakilan
        '
        resources.ApplyResources(Me.BtnPaymentKreditLanggananPerwakilan, "BtnPaymentKreditLanggananPerwakilan")
        Me.BtnPaymentKreditLanggananPerwakilan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditLanggananPerwakilan.Id = 141
        Me.BtnPaymentKreditLanggananPerwakilan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLanggananPerwakilan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLanggananPerwakilan.Name = "BtnPaymentKreditLanggananPerwakilan"
        '
        'BtnPaymentKreditLanggananPusat
        '
        resources.ApplyResources(Me.BtnPaymentKreditLanggananPusat, "BtnPaymentKreditLanggananPusat")
        Me.BtnPaymentKreditLanggananPusat.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditLanggananPusat.Id = 142
        Me.BtnPaymentKreditLanggananPusat.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLanggananPusat.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLanggananPusat.Name = "BtnPaymentKreditLanggananPusat"
        '
        'BtnPaymentKreditSupermarketPerwakilan
        '
        resources.ApplyResources(Me.BtnPaymentKreditSupermarketPerwakilan, "BtnPaymentKreditSupermarketPerwakilan")
        Me.BtnPaymentKreditSupermarketPerwakilan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditSupermarketPerwakilan.Id = 143
        Me.BtnPaymentKreditSupermarketPerwakilan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditSupermarketPerwakilan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditSupermarketPerwakilan.Name = "BtnPaymentKreditSupermarketPerwakilan"
        '
        'BtnPaymentKreditSupermarketPusat
        '
        resources.ApplyResources(Me.BtnPaymentKreditSupermarketPusat, "BtnPaymentKreditSupermarketPusat")
        Me.BtnPaymentKreditSupermarketPusat.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditSupermarketPusat.Id = 144
        Me.BtnPaymentKreditSupermarketPusat.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditSupermarketPusat.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditSupermarketPusat.Name = "BtnPaymentKreditSupermarketPusat"
        '
        'BtnPaymentKreditLainPerwakilan
        '
        resources.ApplyResources(Me.BtnPaymentKreditLainPerwakilan, "BtnPaymentKreditLainPerwakilan")
        Me.BtnPaymentKreditLainPerwakilan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditLainPerwakilan.Id = 145
        Me.BtnPaymentKreditLainPerwakilan.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLainPerwakilan.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLainPerwakilan.Name = "BtnPaymentKreditLainPerwakilan"
        '
        'BtnPaymentKreditLainPusat
        '
        resources.ApplyResources(Me.BtnPaymentKreditLainPusat, "BtnPaymentKreditLainPusat")
        Me.BtnPaymentKreditLainPusat.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPaymentKreditLainPusat.Id = 146
        Me.BtnPaymentKreditLainPusat.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLainPusat.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PembayaranKredit
        Me.BtnPaymentKreditLainPusat.Name = "BtnPaymentKreditLainPusat"
        '
        'BtnDebitNote
        '
        resources.ApplyResources(Me.BtnDebitNote, "BtnDebitNote")
        Me.BtnDebitNote.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnDebitNote.Id = 147
        Me.BtnDebitNote.ImageOptions.Image = Global.Maspion.My.Resources.Resources.debitnote
        Me.BtnDebitNote.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.debitnote
        Me.BtnDebitNote.Name = "BtnDebitNote"
        Me.BtnDebitNote.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnKreditNote
        '
        resources.ApplyResources(Me.BtnKreditNote, "BtnKreditNote")
        Me.BtnKreditNote.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnKreditNote.Id = 149
        Me.BtnKreditNote.ImageOptions.Image = Global.Maspion.My.Resources.Resources.credit_512
        Me.BtnKreditNote.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.credit_512
        Me.BtnKreditNote.Name = "BtnKreditNote"
        Me.BtnKreditNote.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BtnDailySalesReport
        '
        resources.ApplyResources(Me.BtnDailySalesReport, "BtnDailySalesReport")
        Me.BtnDailySalesReport.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnDailySalesReport.Id = 150
        Me.BtnDailySalesReport.ImageOptions.Image = CType(resources.GetObject("BtnDailySalesReport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnDailySalesReport.ImageOptions.LargeImage = CType(resources.GetObject("BtnDailySalesReport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnDailySalesReport.Name = "BtnDailySalesReport"
        '
        'BtnKartuStok
        '
        resources.ApplyResources(Me.BtnKartuStok, "BtnKartuStok")
        Me.BtnKartuStok.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnKartuStok.Id = 151
        Me.BtnKartuStok.ImageOptions.Image = CType(resources.GetObject("BtnKartuStok.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnKartuStok.ImageOptions.LargeImage = CType(resources.GetObject("BtnKartuStok.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnKartuStok.Name = "BtnKartuStok"
        '
        'BtnTransferBarang
        '
        resources.ApplyResources(Me.BtnTransferBarang, "BtnTransferBarang")
        Me.BtnTransferBarang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnTransferBarang.Id = 152
        Me.BtnTransferBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Bahan_Keluar
        Me.BtnTransferBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Bahan_Keluar
        Me.BtnTransferBarang.Name = "BtnTransferBarang"
        '
        'BtnPenerimaanTransfer
        '
        resources.ApplyResources(Me.BtnPenerimaanTransfer, "BtnPenerimaanTransfer")
        Me.BtnPenerimaanTransfer.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPenerimaanTransfer.Id = 153
        Me.BtnPenerimaanTransfer.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Bahan_Masuk
        Me.BtnPenerimaanTransfer.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Bahan_Masuk
        Me.BtnPenerimaanTransfer.Name = "BtnPenerimaanTransfer"
        '
        'BtnPurchaseOrderSupermarket
        '
        resources.ApplyResources(Me.BtnPurchaseOrderSupermarket, "BtnPurchaseOrderSupermarket")
        Me.BtnPurchaseOrderSupermarket.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPurchaseOrderSupermarket.Id = 154
        Me.BtnPurchaseOrderSupermarket.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderSupermarket.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderSupermarket.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderSupermarket.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PO
        Me.BtnPurchaseOrderSupermarket.Name = "BtnPurchaseOrderSupermarket"
        '
        'BtnPembelianSupermarket
        '
        resources.ApplyResources(Me.BtnPembelianSupermarket, "BtnPembelianSupermarket")
        Me.BtnPembelianSupermarket.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPembelianSupermarket.Id = 155
        Me.BtnPembelianSupermarket.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Invoice_Pembelian
        Me.BtnPembelianSupermarket.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Invoice_Pembelian
        Me.BtnPembelianSupermarket.Name = "BtnPembelianSupermarket"
        '
        'BtnClaimPembelianSupermarket
        '
        resources.ApplyResources(Me.BtnClaimPembelianSupermarket, "BtnClaimPembelianSupermarket")
        Me.BtnClaimPembelianSupermarket.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnClaimPembelianSupermarket.Id = 156
        Me.BtnClaimPembelianSupermarket.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianSupermarket.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Claim
        Me.BtnClaimPembelianSupermarket.Name = "BtnClaimPembelianSupermarket"
        '
        'BtnPerusahaan
        '
        resources.ApplyResources(Me.BtnPerusahaan, "BtnPerusahaan")
        Me.BtnPerusahaan.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnPerusahaan.Id = 157
        Me.BtnPerusahaan.ImageOptions.Image = CType(resources.GetObject("BtnPerusahaan.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPerusahaan.ImageOptions.LargeImage = CType(resources.GetObject("BtnPerusahaan.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPerusahaan.Name = "BtnPerusahaan"
        '
        'BtnMappingBarang
        '
        resources.ApplyResources(Me.BtnMappingBarang, "BtnMappingBarang")
        Me.BtnMappingBarang.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnMappingBarang.Id = 158
        Me.BtnMappingBarang.ImageOptions.Image = Global.Maspion.My.Resources.Resources.PenerimaanBarang
        Me.BtnMappingBarang.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.PenerimaanBarang
        Me.BtnMappingBarang.Name = "BtnMappingBarang"
        '
        'BtnGroupUser
        '
        resources.ApplyResources(Me.BtnGroupUser, "BtnGroupUser")
        Me.BtnGroupUser.Id = 159
        Me.BtnGroupUser.ImageOptions.Image = CType(resources.GetObject("BtnGroupUser.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnGroupUser.ImageOptions.LargeImage = CType(resources.GetObject("BtnGroupUser.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnGroupUser.Name = "BtnGroupUser"
        '
        'BtnPT
        '
        resources.ApplyResources(Me.BtnPT, "BtnPT")
        Me.BtnPT.Id = 160
        Me.BtnPT.ImageOptions.Image = Global.Maspion.My.Resources.Resources.icon_pt
        Me.BtnPT.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.icon_pt
        Me.BtnPT.Name = "BtnPT"
        '
        'BtnLaporanPembelian
        '
        resources.ApplyResources(Me.BtnLaporanPembelian, "BtnLaporanPembelian")
        Me.BtnLaporanPembelian.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnLaporanPembelian.Id = 161
        Me.BtnLaporanPembelian.ImageOptions.Image = CType(resources.GetObject("BtnLaporanPembelian.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanPembelian.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanPembelian.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanPembelian.Name = "BtnLaporanPembelian"
        '
        'BtnLaporanDO
        '
        resources.ApplyResources(Me.BtnLaporanDO, "BtnLaporanDO")
        Me.BtnLaporanDO.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BtnLaporanDO.Id = 162
        Me.BtnLaporanDO.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanDO.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanDO.Name = "BtnLaporanDO"
        '
        'BtnLaporanNotaSJ
        '
        resources.ApplyResources(Me.BtnLaporanNotaSJ, "BtnLaporanNotaSJ")
        Me.BtnLaporanNotaSJ.Id = 163
        Me.BtnLaporanNotaSJ.ImageOptions.Image = CType(resources.GetObject("BtnLaporanNotaSJ.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanNotaSJ.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanNotaSJ.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanNotaSJ.Name = "BtnLaporanNotaSJ"
        '
        'BtnLaporanPriceList
        '
        resources.ApplyResources(Me.BtnLaporanPriceList, "BtnLaporanPriceList")
        Me.BtnLaporanPriceList.Id = 164
        Me.BtnLaporanPriceList.ImageOptions.Image = CType(resources.GetObject("BtnLaporanPriceList.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanPriceList.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanPriceList.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanPriceList.Name = "BtnLaporanPriceList"
        '
        'BtnMoDOOuts
        '
        resources.ApplyResources(Me.BtnMoDOOuts, "BtnMoDOOuts")
        Me.BtnMoDOOuts.Id = 165
        Me.BtnMoDOOuts.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Mon_DO
        Me.BtnMoDOOuts.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Mon_DO
        Me.BtnMoDOOuts.Name = "BtnMoDOOuts"
        '
        'BtnLaporanPenjualan
        '
        resources.ApplyResources(Me.BtnLaporanPenjualan, "BtnLaporanPenjualan")
        Me.BtnLaporanPenjualan.Id = 166
        Me.BtnLaporanPenjualan.ImageOptions.Image = CType(resources.GetObject("BtnLaporanPenjualan.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanPenjualan.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanPenjualan.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanPenjualan.Name = "BtnLaporanPenjualan"
        '
        'BtnSaldoAwalBarang
        '
        resources.ApplyResources(Me.BtnSaldoAwalBarang, "BtnSaldoAwalBarang")
        Me.BtnSaldoAwalBarang.Id = 167
        Me.BtnSaldoAwalBarang.ImageOptions.Image = CType(resources.GetObject("BtnSaldoAwalBarang.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSaldoAwalBarang.ImageOptions.LargeImage = CType(resources.GetObject("BtnSaldoAwalBarang.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnSaldoAwalBarang.Name = "BtnSaldoAwalBarang"
        '
        'BtnLPBL
        '
        resources.ApplyResources(Me.BtnLPBL, "BtnLPBL")
        Me.BtnLPBL.Id = 168
        Me.BtnLPBL.ImageOptions.Image = CType(resources.GetObject("BtnLPBL.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLPBL.ImageOptions.LargeImage = CType(resources.GetObject("BtnLPBL.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLPBL.Name = "BtnLPBL"
        '
        'BtnAdjusmentStok
        '
        resources.ApplyResources(Me.BtnAdjusmentStok, "BtnAdjusmentStok")
        Me.BtnAdjusmentStok.Id = 169
        Me.BtnAdjusmentStok.ImageOptions.Image = Global.Maspion.My.Resources.Resources.cash_inflow_512
        Me.BtnAdjusmentStok.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.cash_inflow_512
        Me.BtnAdjusmentStok.Name = "BtnAdjusmentStok"
        '
        'BtnLPBH
        '
        resources.ApplyResources(Me.BtnLPBH, "BtnLPBH")
        Me.BtnLPBH.Id = 170
        Me.BtnLPBH.ImageOptions.Image = CType(resources.GetObject("BtnLPBH.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLPBH.ImageOptions.LargeImage = CType(resources.GetObject("BtnLPBH.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLPBH.Name = "BtnLPBH"
        '
        'BtnReturPembelianTanpaTTB
        '
        resources.ApplyResources(Me.BtnReturPembelianTanpaTTB, "BtnReturPembelianTanpaTTB")
        Me.BtnReturPembelianTanpaTTB.Id = 171
        Me.BtnReturPembelianTanpaTTB.ImageOptions.Image = CType(resources.GetObject("BtnReturPembelianTanpaTTB.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnReturPembelianTanpaTTB.ImageOptions.LargeImage = CType(resources.GetObject("BtnReturPembelianTanpaTTB.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnReturPembelianTanpaTTB.Name = "BtnReturPembelianTanpaTTB"
        '
        'BtnPostingPeriode
        '
        resources.ApplyResources(Me.BtnPostingPeriode, "BtnPostingPeriode")
        Me.BtnPostingPeriode.Id = 172
        Me.BtnPostingPeriode.ImageOptions.Image = CType(resources.GetObject("BtnPostingPeriode.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPostingPeriode.ImageOptions.LargeImage = CType(resources.GetObject("BtnPostingPeriode.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPostingPeriode.Name = "BtnPostingPeriode"
        '
        'BtnPenerimaanTransferBarangRetur
        '
        resources.ApplyResources(Me.BtnPenerimaanTransferBarangRetur, "BtnPenerimaanTransferBarangRetur")
        Me.BtnPenerimaanTransferBarangRetur.Id = 173
        Me.BtnPenerimaanTransferBarangRetur.ImageOptions.Image = CType(resources.GetObject("BtnPenerimaanTransferBarangRetur.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPenerimaanTransferBarangRetur.ImageOptions.LargeImage = CType(resources.GetObject("BtnPenerimaanTransferBarangRetur.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnPenerimaanTransferBarangRetur.Name = "BtnPenerimaanTransferBarangRetur"
        '
        'BtnLaporantransferGudang
        '
        resources.ApplyResources(Me.BtnLaporantransferGudang, "BtnLaporantransferGudang")
        Me.BtnLaporantransferGudang.Id = 174
        Me.BtnLaporantransferGudang.ImageOptions.Image = CType(resources.GetObject("BtnLaporantransferGudang.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporantransferGudang.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporantransferGudang.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporantransferGudang.Name = "BtnLaporantransferGudang"
        '
        'BtnSummaryFinishGoods
        '
        resources.ApplyResources(Me.BtnSummaryFinishGoods, "BtnSummaryFinishGoods")
        Me.BtnSummaryFinishGoods.Id = 175
        Me.BtnSummaryFinishGoods.ImageOptions.Image = CType(resources.GetObject("BtnSummaryFinishGoods.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSummaryFinishGoods.ImageOptions.LargeImage = CType(resources.GetObject("BtnSummaryFinishGoods.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnSummaryFinishGoods.Name = "BtnSummaryFinishGoods"
        '
        'BtnControlSummary
        '
        resources.ApplyResources(Me.BtnControlSummary, "BtnControlSummary")
        Me.BtnControlSummary.Id = 176
        Me.BtnControlSummary.ImageOptions.Image = CType(resources.GetObject("BtnControlSummary.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnControlSummary.ImageOptions.LargeImage = CType(resources.GetObject("BtnControlSummary.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnControlSummary.Name = "BtnControlSummary"
        '
        'BtnLaporanAdjusmentStok
        '
        resources.ApplyResources(Me.BtnLaporanAdjusmentStok, "BtnLaporanAdjusmentStok")
        Me.BtnLaporanAdjusmentStok.Id = 177
        Me.BtnLaporanAdjusmentStok.ImageOptions.Image = CType(resources.GetObject("BtnLaporanAdjusmentStok.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanAdjusmentStok.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanAdjusmentStok.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanAdjusmentStok.Name = "BtnLaporanAdjusmentStok"
        '
        'BtnLaporanReturPenjualan
        '
        resources.ApplyResources(Me.BtnLaporanReturPenjualan, "BtnLaporanReturPenjualan")
        Me.BtnLaporanReturPenjualan.Id = 178
        Me.BtnLaporanReturPenjualan.ImageOptions.Image = CType(resources.GetObject("BtnLaporanReturPenjualan.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLaporanReturPenjualan.ImageOptions.LargeImage = CType(resources.GetObject("BtnLaporanReturPenjualan.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnLaporanReturPenjualan.Name = "BtnLaporanReturPenjualan"
        '
        'BtnCreateDSRPrw
        '
        resources.ApplyResources(Me.BtnCreateDSRPrw, "BtnCreateDSRPrw")
        Me.BtnCreateDSRPrw.Id = 179
        Me.BtnCreateDSRPrw.Name = "BtnCreateDSRPrw"
        '
        'BtnValidasiPrw
        '
        resources.ApplyResources(Me.BtnValidasiPrw, "BtnValidasiPrw")
        Me.BtnValidasiPrw.Id = 180
        Me.BtnValidasiPrw.Name = "BtnValidasiPrw"
        '
        'BtnKodePerkiraan
        '
        resources.ApplyResources(Me.BtnKodePerkiraan, "BtnKodePerkiraan")
        Me.BtnKodePerkiraan.Id = 181
        Me.BtnKodePerkiraan.Name = "BtnKodePerkiraan"
        '
        'BtnJurnal
        '
        resources.ApplyResources(Me.BtnJurnal, "BtnJurnal")
        Me.BtnJurnal.Id = 182
        Me.BtnJurnal.Name = "BtnJurnal"
        '
        'BtnKasMasuk
        '
        resources.ApplyResources(Me.BtnKasMasuk, "BtnKasMasuk")
        Me.BtnKasMasuk.Id = 183
        Me.BtnKasMasuk.Name = "BtnKasMasuk"
        '
        'BtnKasKeluar
        '
        resources.ApplyResources(Me.BtnKasKeluar, "BtnKasKeluar")
        Me.BtnKasKeluar.Id = 184
        Me.BtnKasKeluar.Name = "BtnKasKeluar"
        '
        'BtnBankMasuk
        '
        resources.ApplyResources(Me.BtnBankMasuk, "BtnBankMasuk")
        Me.BtnBankMasuk.Id = 185
        Me.BtnBankMasuk.Name = "BtnBankMasuk"
        '
        'BtnBankKeluar
        '
        resources.ApplyResources(Me.BtnBankKeluar, "BtnBankKeluar")
        Me.BtnBankKeluar.Id = 186
        Me.BtnBankKeluar.Name = "BtnBankKeluar"
        '
        'BtnSetupAkuntansi
        '
        resources.ApplyResources(Me.BtnSetupAkuntansi, "BtnSetupAkuntansi")
        Me.BtnSetupAkuntansi.Id = 187
        Me.BtnSetupAkuntansi.Name = "BtnSetupAkuntansi"
        '
        'BtnCreateDSRPus
        '
        resources.ApplyResources(Me.BtnCreateDSRPus, "BtnCreateDSRPus")
        Me.BtnCreateDSRPus.Id = 189
        Me.BtnCreateDSRPus.Name = "BtnCreateDSRPus"
        '
        'BtnValidasiPus
        '
        resources.ApplyResources(Me.BtnValidasiPus, "BtnValidasiPus")
        Me.BtnValidasiPus.Id = 190
        Me.BtnValidasiPus.Name = "BtnValidasiPus"
        '
        'BtnHargaPromo
        '
        resources.ApplyResources(Me.BtnHargaPromo, "BtnHargaPromo")
        Me.BtnHargaPromo.Id = 191
        Me.BtnHargaPromo.ImageOptions.Image = CType(resources.GetObject("BtnHargaPromo.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnHargaPromo.ImageOptions.LargeImage = CType(resources.GetObject("BtnHargaPromo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BtnHargaPromo.Name = "BtnHargaPromo"
        '
        'BtnTandaTerima
        '
        resources.ApplyResources(Me.BtnTandaTerima, "BtnTandaTerima")
        Me.BtnTandaTerima.Id = 192
        Me.BtnTandaTerima.Name = "BtnTandaTerima"
        '
        'BtnPenyerahanNota
        '
        resources.ApplyResources(Me.BtnPenyerahanNota, "BtnPenyerahanNota")
        Me.BtnPenyerahanNota.Id = 193
        Me.BtnPenyerahanNota.Name = "BtnPenyerahanNota"
        '
        'BtnPengembalianNota
        '
        resources.ApplyResources(Me.BtnPengembalianNota, "BtnPengembalianNota")
        Me.BtnPengembalianNota.Id = 194
        Me.BtnPengembalianNota.Name = "BtnPengembalianNota"
        '
        'BtnProsesJurnalPrw
        '
        resources.ApplyResources(Me.BtnProsesJurnalPrw, "BtnProsesJurnalPrw")
        Me.BtnProsesJurnalPrw.Id = 195
        Me.BtnProsesJurnalPrw.Name = "BtnProsesJurnalPrw"
        '
        'BtnProsesJurnalPus
        '
        resources.ApplyResources(Me.BtnProsesJurnalPus, "BtnProsesJurnalPus")
        Me.BtnProsesJurnalPus.Id = 196
        Me.BtnProsesJurnalPus.Name = "BtnProsesJurnalPus"
        '
        'BtnPermintaanDibuatkanFakturPajak
        '
        resources.ApplyResources(Me.BtnPermintaanDibuatkanFakturPajak, "BtnPermintaanDibuatkanFakturPajak")
        Me.BtnPermintaanDibuatkanFakturPajak.Id = 197
        Me.BtnPermintaanDibuatkanFakturPajak.Name = "BtnPermintaanDibuatkanFakturPajak"
        '
        'BtnKonfirmasiDibuatkanFakturPajak
        '
        resources.ApplyResources(Me.BtnKonfirmasiDibuatkanFakturPajak, "BtnKonfirmasiDibuatkanFakturPajak")
        Me.BtnKonfirmasiDibuatkanFakturPajak.Id = 198
        Me.BtnKonfirmasiDibuatkanFakturPajak.Name = "BtnKonfirmasiDibuatkanFakturPajak"
        '
        'BtnUangTitipan
        '
        resources.ApplyResources(Me.BtnUangTitipan, "BtnUangTitipan")
        Me.BtnUangTitipan.Id = 199
        Me.BtnUangTitipan.Name = "BtnUangTitipan"
        '
        'BtnMasterBank
        '
        resources.ApplyResources(Me.BtnMasterBank, "BtnMasterBank")
        Me.BtnMasterBank.Id = 200
        Me.BtnMasterBank.Name = "BtnMasterBank"
        '
        'BtnSetoranPerPT
        '
        resources.ApplyResources(Me.BtnSetoranPerPT, "BtnSetoranPerPT")
        Me.BtnSetoranPerPT.Id = 201
        Me.BtnSetoranPerPT.Name = "BtnSetoranPerPT"
        '
        'BtnKartuPiutang
        '
        resources.ApplyResources(Me.BtnKartuPiutang, "BtnKartuPiutang")
        Me.BtnKartuPiutang.Id = 202
        Me.BtnKartuPiutang.Name = "BtnKartuPiutang"
        '
        'BtnKodeBatasan
        '
        resources.ApplyResources(Me.BtnKodeBatasan, "BtnKodeBatasan")
        Me.BtnKodeBatasan.Id = 203
        Me.BtnKodeBatasan.Name = "BtnKodeBatasan"
        '
        'BtnPembayaranKontan
        '
        resources.ApplyResources(Me.BtnPembayaranKontan, "BtnPembayaranKontan")
        Me.BtnPembayaranKontan.Id = 204
        Me.BtnPembayaranKontan.Name = "BtnPembayaranKontan"
        '
        'BtnLaporanSalesPerDO
        '
        resources.ApplyResources(Me.BtnLaporanSalesPerDO, "BtnLaporanSalesPerDO")
        Me.BtnLaporanSalesPerDO.Id = 205
        Me.BtnLaporanSalesPerDO.Name = "BtnLaporanSalesPerDO"
        '
        'BtnKartuRetur
        '
        resources.ApplyResources(Me.BtnKartuRetur, "BtnKartuRetur")
        Me.BtnKartuRetur.Id = 206
        Me.BtnKartuRetur.Name = "BtnKartuRetur"
        '
        'BtnCN
        '
        resources.ApplyResources(Me.BtnCN, "BtnCN")
        Me.BtnCN.Id = 207
        Me.BtnCN.Name = "BtnCN"
        '
        'BtnDN
        '
        resources.ApplyResources(Me.BtnDN, "BtnDN")
        Me.BtnDN.Id = 208
        Me.BtnDN.Name = "BtnDN"
        '
        'BtnPengembalianDOKontan
        '
        resources.ApplyResources(Me.BtnPengembalianDOKontan, "BtnPengembalianDOKontan")
        Me.BtnPengembalianDOKontan.Id = 209
        Me.BtnPengembalianDOKontan.Name = "BtnPengembalianDOKontan"
        '
        'BtnValidasiPengembalian
        '
        resources.ApplyResources(Me.BtnValidasiPengembalian, "BtnValidasiPengembalian")
        Me.BtnValidasiPengembalian.Id = 210
        Me.BtnValidasiPengembalian.Name = "BtnValidasiPengembalian"
        '
        'BtnKekuranganDO
        '
        resources.ApplyResources(Me.BtnKekuranganDO, "BtnKekuranganDO")
        Me.BtnKekuranganDO.Id = 211
        Me.BtnKekuranganDO.Name = "BtnKekuranganDO"
        '
        'BtnValidasiKekurangan
        '
        resources.ApplyResources(Me.BtnValidasiKekurangan, "BtnValidasiKekurangan")
        Me.BtnValidasiKekurangan.Id = 212
        Me.BtnValidasiKekurangan.Name = "BtnValidasiKekurangan"
        '
        'BtnLaporanSaldoUM
        '
        resources.ApplyResources(Me.BtnLaporanSaldoUM, "BtnLaporanSaldoUM")
        Me.BtnLaporanSaldoUM.Id = 213
        Me.BtnLaporanSaldoUM.Name = "BtnLaporanSaldoUM"
        '
        'BtnRekapSaldoDivisi
        '
        resources.ApplyResources(Me.BtnRekapSaldoDivisi, "BtnRekapSaldoDivisi")
        Me.BtnRekapSaldoDivisi.Id = 214
        Me.BtnRekapSaldoDivisi.Name = "BtnRekapSaldoDivisi"
        '
        'BtnRekapOmsetDivisi
        '
        resources.ApplyResources(Me.BtnRekapOmsetDivisi, "BtnRekapOmsetDivisi")
        Me.BtnRekapOmsetDivisi.Id = 215
        Me.BtnRekapOmsetDivisi.Name = "BtnRekapOmsetDivisi"
        '
        'BtnRekapOmsetPembayaranCustomer
        '
        resources.ApplyResources(Me.BtnRekapOmsetPembayaranCustomer, "BtnRekapOmsetPembayaranCustomer")
        Me.BtnRekapOmsetPembayaranCustomer.Id = 216
        Me.BtnRekapOmsetPembayaranCustomer.Name = "BtnRekapOmsetPembayaranCustomer"
        '
        'BtnRekapOmsetCorporate
        '
        resources.ApplyResources(Me.BtnRekapOmsetCorporate, "BtnRekapOmsetCorporate")
        Me.BtnRekapOmsetCorporate.Id = 217
        Me.BtnRekapOmsetCorporate.Name = "BtnRekapOmsetCorporate"
        '
        'BtnCutOffDOKontan
        '
        resources.ApplyResources(Me.BtnCutOffDOKontan, "BtnCutOffDOKontan")
        Me.BtnCutOffDOKontan.Id = 218
        Me.BtnCutOffDOKontan.Name = "BtnCutOffDOKontan"
        '
        'BtnDebitNoteKontan
        '
        resources.ApplyResources(Me.BtnDebitNoteKontan, "BtnDebitNoteKontan")
        Me.BtnDebitNoteKontan.Id = 219
        Me.BtnDebitNoteKontan.Name = "BtnDebitNoteKontan"
        '
        'BtnKreditNoteKontan
        '
        resources.ApplyResources(Me.BtnKreditNoteKontan, "BtnKreditNoteKontan")
        Me.BtnKreditNoteKontan.Id = 220
        Me.BtnKreditNoteKontan.Name = "BtnKreditNoteKontan"
        '
        'BtnLaporanJurnal
        '
        resources.ApplyResources(Me.BtnLaporanJurnal, "BtnLaporanJurnal")
        Me.BtnLaporanJurnal.Id = 221
        Me.BtnLaporanJurnal.Name = "BtnLaporanJurnal"
        Me.BtnLaporanJurnal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BtnLaporanJurnalDetail
        '
        resources.ApplyResources(Me.BtnLaporanJurnalDetail, "BtnLaporanJurnalDetail")
        Me.BtnLaporanJurnalDetail.Id = 222
        Me.BtnLaporanJurnalDetail.Name = "BtnLaporanJurnalDetail"
        '
        'BtnCreateLapPembelian
        '
        resources.ApplyResources(Me.BtnCreateLapPembelian, "BtnCreateLapPembelian")
        Me.BtnCreateLapPembelian.Id = 223
        Me.BtnCreateLapPembelian.Name = "BtnCreateLapPembelian"
        '
        'BtnValidasiLapPembelian
        '
        resources.ApplyResources(Me.BtnValidasiLapPembelian, "BtnValidasiLapPembelian")
        Me.BtnValidasiLapPembelian.Id = 224
        Me.BtnValidasiLapPembelian.Name = "BtnValidasiLapPembelian"
        '
        'BtnProsesJurnalPB
        '
        resources.ApplyResources(Me.BtnProsesJurnalPB, "BtnProsesJurnalPB")
        Me.BtnProsesJurnalPB.Id = 225
        Me.BtnProsesJurnalPB.Name = "BtnProsesJurnalPB"
        '
        'BtnCreateLapRJ
        '
        resources.ApplyResources(Me.BtnCreateLapRJ, "BtnCreateLapRJ")
        Me.BtnCreateLapRJ.Id = 226
        Me.BtnCreateLapRJ.Name = "BtnCreateLapRJ"
        '
        'BtnValidasiLapRJ
        '
        resources.ApplyResources(Me.BtnValidasiLapRJ, "BtnValidasiLapRJ")
        Me.BtnValidasiLapRJ.Id = 227
        Me.BtnValidasiLapRJ.Name = "BtnValidasiLapRJ"
        '
        'BtnProsesJurnalRJ
        '
        resources.ApplyResources(Me.BtnProsesJurnalRJ, "BtnProsesJurnalRJ")
        Me.BtnProsesJurnalRJ.Id = 228
        Me.BtnProsesJurnalRJ.Name = "BtnProsesJurnalRJ"
        '
        'BtnCreateLapRB
        '
        resources.ApplyResources(Me.BtnCreateLapRB, "BtnCreateLapRB")
        Me.BtnCreateLapRB.Id = 229
        Me.BtnCreateLapRB.Name = "BtnCreateLapRB"
        '
        'BtnValidasiLapRB
        '
        resources.ApplyResources(Me.BtnValidasiLapRB, "BtnValidasiLapRB")
        Me.BtnValidasiLapRB.Id = 230
        Me.BtnValidasiLapRB.Name = "BtnValidasiLapRB"
        '
        'BtnProsesJurnalRB
        '
        resources.ApplyResources(Me.BtnProsesJurnalRB, "BtnProsesJurnalRB")
        Me.BtnProsesJurnalRB.Id = 231
        Me.BtnProsesJurnalRB.Name = "BtnProsesJurnalRB"
        '
        'BtnReturPusat
        '
        resources.ApplyResources(Me.BtnReturPusat, "BtnReturPusat")
        Me.BtnReturPusat.Id = 232
        Me.BtnReturPusat.Name = "BtnReturPusat"
        '
        'BtnPelunasanRetur
        '
        resources.ApplyResources(Me.BtnPelunasanRetur, "BtnPelunasanRetur")
        Me.BtnPelunasanRetur.Id = 233
        Me.BtnPelunasanRetur.Name = "BtnPelunasanRetur"
        '
        'BtnRincianPembayaran
        '
        resources.ApplyResources(Me.BtnRincianPembayaran, "BtnRincianPembayaran")
        Me.BtnRincianPembayaran.Id = 234
        Me.BtnRincianPembayaran.Name = "BtnRincianPembayaran"
        '
        'RibbonPageCategoryPembelian
        '
        resources.ApplyResources(Me.RibbonPageCategoryPembelian, "RibbonPageCategoryPembelian")
        Me.RibbonPageCategoryPembelian.Name = "RibbonPageCategoryPembelian"
        Me.RibbonPageCategoryPembelian.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PagePembelianLangganan, Me.PagePembelianSupermarket})
        '
        'PagePembelianLangganan
        '
        Me.PagePembelianLangganan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupPembelianLangganan})
        Me.PagePembelianLangganan.Name = "PagePembelianLangganan"
        resources.ApplyResources(Me.PagePembelianLangganan, "PagePembelianLangganan")
        Me.PagePembelianLangganan.Visible = False
        '
        'GrupPembelianLangganan
        '
        Me.GrupPembelianLangganan.ItemLinks.Add(Me.BtnPurchaseOrderLangganan)
        Me.GrupPembelianLangganan.ItemLinks.Add(Me.BtnPembelianLangganan, True)
        Me.GrupPembelianLangganan.ItemLinks.Add(Me.BtnClaimPembelianLangganan)
        Me.GrupPembelianLangganan.Name = "GrupPembelianLangganan"
        resources.ApplyResources(Me.GrupPembelianLangganan, "GrupPembelianLangganan")
        '
        'PagePembelianSupermarket
        '
        Me.PagePembelianSupermarket.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupPembelianSupermarket})
        Me.PagePembelianSupermarket.Name = "PagePembelianSupermarket"
        resources.ApplyResources(Me.PagePembelianSupermarket, "PagePembelianSupermarket")
        Me.PagePembelianSupermarket.Visible = False
        '
        'GrupPembelianSupermarket
        '
        Me.GrupPembelianSupermarket.ItemLinks.Add(Me.BtnPurchaseOrderSupermarket)
        Me.GrupPembelianSupermarket.ItemLinks.Add(Me.BtnPembelianSupermarket, True)
        Me.GrupPembelianSupermarket.ItemLinks.Add(Me.BtnClaimPembelianSupermarket)
        Me.GrupPembelianSupermarket.Name = "GrupPembelianSupermarket"
        resources.ApplyResources(Me.GrupPembelianSupermarket, "GrupPembelianSupermarket")
        '
        'RibbonPageCategoryPenjualanLangganan
        '
        resources.ApplyResources(Me.RibbonPageCategoryPenjualanLangganan, "RibbonPageCategoryPenjualanLangganan")
        Me.RibbonPageCategoryPenjualanLangganan.Name = "RibbonPageCategoryPenjualanLangganan"
        Me.RibbonPageCategoryPenjualanLangganan.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PagePenjualanLanggananPerwakilan, Me.PagePenjualanLanggananPusat})
        '
        'PagePenjualanLanggananPerwakilan
        '
        Me.PagePenjualanLanggananPerwakilan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanLanggananPerwakilan})
        Me.PagePenjualanLanggananPerwakilan.Name = "PagePenjualanLanggananPerwakilan"
        resources.ApplyResources(Me.PagePenjualanLanggananPerwakilan, "PagePenjualanLanggananPerwakilan")
        Me.PagePenjualanLanggananPerwakilan.Visible = False
        '
        'GroupPenjualanLanggananPerwakilan
        '
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananPerwakilanBarangDO)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananPerwTBarangTitipan, True)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananPerwTBarangBonPesananTitipan)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananPerwMonPay, True)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananStuffing, True)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPjLanggananPerwNota)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnSuratJalanTanpaHarga)
        Me.GroupPenjualanLanggananPerwakilan.ItemLinks.Add(Me.BtnPaymentKreditLanggananPerwakilan, True)
        Me.GroupPenjualanLanggananPerwakilan.Name = "GroupPenjualanLanggananPerwakilan"
        resources.ApplyResources(Me.GroupPenjualanLanggananPerwakilan, "GroupPenjualanLanggananPerwakilan")
        '
        'PagePenjualanLanggananPusat
        '
        Me.PagePenjualanLanggananPusat.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanLanggananPusat})
        Me.PagePenjualanLanggananPusat.Name = "PagePenjualanLanggananPusat"
        resources.ApplyResources(Me.PagePenjualanLanggananPusat, "PagePenjualanLanggananPusat")
        Me.PagePenjualanLanggananPusat.Visible = False
        '
        'GroupPenjualanLanggananPusat
        '
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPjLanggananPusatBarangDO)
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPjLanggananPusatTBarangTitipan, True)
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPjLanggananPusatTBarangBonPesananTitipan)
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPjLanggananPusatMonPay, True)
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPjLanggananPusatNota)
        Me.GroupPenjualanLanggananPusat.ItemLinks.Add(Me.BtnPaymentKreditLanggananPusat, True)
        Me.GroupPenjualanLanggananPusat.Name = "GroupPenjualanLanggananPusat"
        resources.ApplyResources(Me.GroupPenjualanLanggananPusat, "GroupPenjualanLanggananPusat")
        '
        'RibbonPageCategoryPenjualanSupermarket
        '
        resources.ApplyResources(Me.RibbonPageCategoryPenjualanSupermarket, "RibbonPageCategoryPenjualanSupermarket")
        Me.RibbonPageCategoryPenjualanSupermarket.Name = "RibbonPageCategoryPenjualanSupermarket"
        Me.RibbonPageCategoryPenjualanSupermarket.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PagePenjualanSupermarketPerwakilan, Me.PagePenjualanSupermarketPusat})
        '
        'PagePenjualanSupermarketPerwakilan
        '
        Me.PagePenjualanSupermarketPerwakilan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanSupermarketPerwakilan})
        Me.PagePenjualanSupermarketPerwakilan.Name = "PagePenjualanSupermarketPerwakilan"
        resources.ApplyResources(Me.PagePenjualanSupermarketPerwakilan, "PagePenjualanSupermarketPerwakilan")
        Me.PagePenjualanSupermarketPerwakilan.Visible = False
        '
        'GroupPenjualanSupermarketPerwakilan
        '
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwakilanDO)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwTBarangTitipan, True)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwTBarangBonPesananTitipan)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwMonPay, True)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketStuffing, True)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwNota)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPjSupermarketPerwRefund)
        Me.GroupPenjualanSupermarketPerwakilan.ItemLinks.Add(Me.BtnPaymentKreditSupermarketPerwakilan, True)
        Me.GroupPenjualanSupermarketPerwakilan.Name = "GroupPenjualanSupermarketPerwakilan"
        resources.ApplyResources(Me.GroupPenjualanSupermarketPerwakilan, "GroupPenjualanSupermarketPerwakilan")
        '
        'PagePenjualanSupermarketPusat
        '
        Me.PagePenjualanSupermarketPusat.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanSupermarketPusat})
        Me.PagePenjualanSupermarketPusat.Name = "PagePenjualanSupermarketPusat"
        resources.ApplyResources(Me.PagePenjualanSupermarketPusat, "PagePenjualanSupermarketPusat")
        Me.PagePenjualanSupermarketPusat.Visible = False
        '
        'GroupPenjualanSupermarketPusat
        '
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPjSupermarketPusatBarangDO)
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPjSupermarketPusatTBarangTitipan, True)
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPjSupermarketPusatTBarangBonPesananTitipan)
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPjSupermarketPusatMonPay, True)
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPjSupermarketPusatNota)
        Me.GroupPenjualanSupermarketPusat.ItemLinks.Add(Me.BtnPaymentKreditSupermarketPusat, True)
        Me.GroupPenjualanSupermarketPusat.Name = "GroupPenjualanSupermarketPusat"
        resources.ApplyResources(Me.GroupPenjualanSupermarketPusat, "GroupPenjualanSupermarketPusat")
        '
        'RibbonPageCategoryPenjualanLain
        '
        resources.ApplyResources(Me.RibbonPageCategoryPenjualanLain, "RibbonPageCategoryPenjualanLain")
        Me.RibbonPageCategoryPenjualanLain.Name = "RibbonPageCategoryPenjualanLain"
        Me.RibbonPageCategoryPenjualanLain.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PagePenjualanLainPerwakilan, Me.PagePenjualanLainPusat})
        '
        'PagePenjualanLainPerwakilan
        '
        Me.PagePenjualanLainPerwakilan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanLainPerwakilan})
        Me.PagePenjualanLainPerwakilan.Name = "PagePenjualanLainPerwakilan"
        resources.ApplyResources(Me.PagePenjualanLainPerwakilan, "PagePenjualanLainPerwakilan")
        Me.PagePenjualanLainPerwakilan.Visible = False
        '
        'GroupPenjualanLainPerwakilan
        '
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainPerwakilanBarangDO)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainPerwTBarangTitipan, True)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainPerwTBarangBonPesananTitipan)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainPerwMonPay, True)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainStuffing, True)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPjLainPerwNota)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnSuratJalanTanpaHargaLain)
        Me.GroupPenjualanLainPerwakilan.ItemLinks.Add(Me.BtnPaymentKreditLainPerwakilan, True)
        Me.GroupPenjualanLainPerwakilan.Name = "GroupPenjualanLainPerwakilan"
        resources.ApplyResources(Me.GroupPenjualanLainPerwakilan, "GroupPenjualanLainPerwakilan")
        '
        'PagePenjualanLainPusat
        '
        Me.PagePenjualanLainPusat.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GroupPenjualanLainPusat})
        Me.PagePenjualanLainPusat.Name = "PagePenjualanLainPusat"
        resources.ApplyResources(Me.PagePenjualanLainPusat, "PagePenjualanLainPusat")
        Me.PagePenjualanLainPusat.Visible = False
        '
        'GroupPenjualanLainPusat
        '
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPjLainPusatBarangDO)
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPjLainPusatTBarangTitipan, True)
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPjLainPusatTBarangBonPesananTitipan)
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPjLainPusatMonPay, True)
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPjLainPusatNota)
        Me.GroupPenjualanLainPusat.ItemLinks.Add(Me.BtnPaymentKreditLainPusat, True)
        Me.GroupPenjualanLainPusat.Name = "GroupPenjualanLainPusat"
        resources.ApplyResources(Me.GroupPenjualanLainPusat, "GroupPenjualanLainPusat")
        '
        'RibbonPageCategoryAdditional
        '
        resources.ApplyResources(Me.RibbonPageCategoryAdditional, "RibbonPageCategoryAdditional")
        Me.RibbonPageCategoryAdditional.Name = "RibbonPageCategoryAdditional"
        Me.RibbonPageCategoryAdditional.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PagePenitipanBarang, Me.PageRetur, Me.PagePersediaan, Me.PageMonitoring, Me.PageDebitKreditNote, Me.PageLaporan})
        '
        'PagePenitipanBarang
        '
        Me.PagePenitipanBarang.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupPenitipanBarang})
        Me.PagePenitipanBarang.Name = "PagePenitipanBarang"
        resources.ApplyResources(Me.PagePenitipanBarang, "PagePenitipanBarang")
        Me.PagePenitipanBarang.Visible = False
        '
        'GrupPenitipanBarang
        '
        Me.GrupPenitipanBarang.ItemLinks.Add(Me.BtnPenitipanBarang)
        Me.GrupPenitipanBarang.ItemLinks.Add(Me.BtnSJPenitipanBarang)
        Me.GrupPenitipanBarang.Name = "GrupPenitipanBarang"
        resources.ApplyResources(Me.GrupPenitipanBarang, "GrupPenitipanBarang")
        '
        'PageRetur
        '
        Me.PageRetur.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup5, Me.RibbonPageGroup4})
        Me.PageRetur.Name = "PageRetur"
        resources.ApplyResources(Me.PageRetur, "PageRetur")
        Me.PageRetur.Visible = False
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnTTB)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnReturPenjualan)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        resources.ApplyResources(Me.RibbonPageGroup5, "RibbonPageGroup5")
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BtnReturPembelian)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BtnTransferBarangRetur)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BtnPenerimaanTransferBarangRetur)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BtnReturPembelianTanpaTTB, True)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        resources.ApplyResources(Me.RibbonPageGroup4, "RibbonPageGroup4")
        '
        'PagePersediaan
        '
        Me.PagePersediaan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupPersediaanTransferGudang, Me.GrupMapping})
        Me.PagePersediaan.Name = "PagePersediaan"
        resources.ApplyResources(Me.PagePersediaan, "PagePersediaan")
        Me.PagePersediaan.Visible = False
        '
        'GrupPersediaanTransferGudang
        '
        Me.GrupPersediaanTransferGudang.ItemLinks.Add(Me.BtnTransferBarang)
        Me.GrupPersediaanTransferGudang.ItemLinks.Add(Me.BtnPenerimaanTransfer)
        Me.GrupPersediaanTransferGudang.ItemLinks.Add(Me.BtnAdjusmentStok)
        Me.GrupPersediaanTransferGudang.ItemLinks.Add(Me.BtnPostingPeriode)
        Me.GrupPersediaanTransferGudang.Name = "GrupPersediaanTransferGudang"
        resources.ApplyResources(Me.GrupPersediaanTransferGudang, "GrupPersediaanTransferGudang")
        '
        'GrupMapping
        '
        Me.GrupMapping.ItemLinks.Add(Me.BtnMappingBarang)
        Me.GrupMapping.ItemLinks.Add(Me.BtnSaldoAwalBarang)
        Me.GrupMapping.Name = "GrupMapping"
        resources.ApplyResources(Me.GrupMapping, "GrupMapping")
        '
        'PageMonitoring
        '
        Me.PageMonitoring.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.BtnMonitoringMinStok})
        Me.PageMonitoring.Name = "PageMonitoring"
        resources.ApplyResources(Me.PageMonitoring, "PageMonitoring")
        Me.PageMonitoring.Visible = False
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BtnMonitoringCustomer)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BtnMoDOOuts)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        resources.ApplyResources(Me.RibbonPageGroup1, "RibbonPageGroup1")
        '
        'BtnMonitoringMinStok
        '
        Me.BtnMonitoringMinStok.ItemLinks.Add(Me.BtnMonitoringStok)
        Me.BtnMonitoringMinStok.ItemLinks.Add(Me.BtnBatasMin)
        Me.BtnMonitoringMinStok.ItemLinks.Add(Me.BtnBatasMax)
        Me.BtnMonitoringMinStok.Name = "BtnMonitoringMinStok"
        resources.ApplyResources(Me.BtnMonitoringMinStok, "BtnMonitoringMinStok")
        '
        'PageDebitKreditNote
        '
        Me.PageDebitKreditNote.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup6})
        Me.PageDebitKreditNote.Name = "PageDebitKreditNote"
        resources.ApplyResources(Me.PageDebitKreditNote, "PageDebitKreditNote")
        Me.PageDebitKreditNote.Visible = False
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BtnDebitNote)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BtnKreditNote)
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        resources.ApplyResources(Me.RibbonPageGroup6, "RibbonPageGroup6")
        '
        'PageLaporan
        '
        Me.PageLaporan.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupLaporan, Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup7})
        Me.PageLaporan.Name = "PageLaporan"
        resources.ApplyResources(Me.PageLaporan, "PageLaporan")
        Me.PageLaporan.Visible = False
        '
        'GrupLaporan
        '
        Me.GrupLaporan.ItemLinks.Add(Me.BtnLaporanPriceList)
        Me.GrupLaporan.Name = "GrupLaporan"
        resources.ApplyResources(Me.GrupLaporan, "GrupLaporan")
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnLaporanDO)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnLaporanNotaSJ)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnDailySalesReport)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnLaporanPembelian)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnLaporanPenjualan)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        resources.ApplyResources(Me.RibbonPageGroup2, "RibbonPageGroup2")
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnKartuStok)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnLPBL)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnLPBH)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnLaporantransferGudang)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnLaporanAdjusmentStok)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnLaporanReturPenjualan)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        resources.ApplyResources(Me.RibbonPageGroup3, "RibbonPageGroup3")
        '
        'RibbonPageGroup7
        '
        Me.RibbonPageGroup7.ItemLinks.Add(Me.BtnSummaryFinishGoods)
        Me.RibbonPageGroup7.ItemLinks.Add(Me.BtnControlSummary)
        Me.RibbonPageGroup7.Name = "RibbonPageGroup7"
        resources.ApplyResources(Me.RibbonPageGroup7, "RibbonPageGroup7")
        '
        'RibbonPageCategoryAR
        '
        Me.RibbonPageCategoryAR.AutoStretchPageHeaders = True
        resources.ApplyResources(Me.RibbonPageCategoryAR, "RibbonPageCategoryAR")
        Me.RibbonPageCategoryAR.Name = "RibbonPageCategoryAR"
        Me.RibbonPageCategoryAR.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup10, Me.RibbonPageGroup8, Me.RibbonPageGroup11, Me.RibbonPageGroup12, Me.RibbonPageGroup9, Me.RibbonPageGroup13, Me.RibbonPageGroup14, Me.RibbonPageGroup15, Me.RibbonPageGroup16})
        Me.RibbonPage1.Name = "RibbonPage1"
        resources.ApplyResources(Me.RibbonPage1, "RibbonPage1")
        '
        'RibbonPageGroup10
        '
        Me.RibbonPageGroup10.ItemLinks.Add(Me.BtnKodePerkiraan)
        Me.RibbonPageGroup10.ItemLinks.Add(Me.BtnSetupAkuntansi)
        Me.RibbonPageGroup10.ItemLinks.Add(Me.BtnMasterBank)
        Me.RibbonPageGroup10.ItemLinks.Add(Me.BtnKodeBatasan)
        Me.RibbonPageGroup10.Name = "RibbonPageGroup10"
        resources.ApplyResources(Me.RibbonPageGroup10, "RibbonPageGroup10")
        '
        'RibbonPageGroup8
        '
        Me.RibbonPageGroup8.ItemLinks.Add(Me.BtnCreateDSRPrw)
        Me.RibbonPageGroup8.ItemLinks.Add(Me.BtnValidasiPrw)
        Me.RibbonPageGroup8.ItemLinks.Add(Me.BtnProsesJurnalPrw)
        Me.RibbonPageGroup8.Name = "RibbonPageGroup8"
        resources.ApplyResources(Me.RibbonPageGroup8, "RibbonPageGroup8")
        '
        'RibbonPageGroup11
        '
        Me.RibbonPageGroup11.ItemLinks.Add(Me.BtnCreateDSRPus)
        Me.RibbonPageGroup11.ItemLinks.Add(Me.BtnValidasiPus)
        Me.RibbonPageGroup11.ItemLinks.Add(Me.BtnProsesJurnalPus)
        Me.RibbonPageGroup11.Name = "RibbonPageGroup11"
        resources.ApplyResources(Me.RibbonPageGroup11, "RibbonPageGroup11")
        '
        'RibbonPageGroup12
        '
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnPenyerahanNota)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnPengembalianNota)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnPermintaanDibuatkanFakturPajak)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnKonfirmasiDibuatkanFakturPajak)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnTandaTerima)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnUangTitipan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnSetoranPerPT, True)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnPembayaranKontan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnCN)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnDN)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnPengembalianDOKontan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnValidasiPengembalian)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnKekuranganDO)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnValidasiKekurangan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnCutOffDOKontan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnDebitNoteKontan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnKreditNoteKontan)
        Me.RibbonPageGroup12.ItemLinks.Add(Me.BtnRincianPembayaran)
        Me.RibbonPageGroup12.Name = "RibbonPageGroup12"
        resources.ApplyResources(Me.RibbonPageGroup12, "RibbonPageGroup12")
        '
        'RibbonPageGroup9
        '
        Me.RibbonPageGroup9.ItemLinks.Add(Me.BtnKasMasuk)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.BtnKasKeluar)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.BtnBankMasuk)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.BtnBankKeluar)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.BtnJurnal)
        Me.RibbonPageGroup9.Name = "RibbonPageGroup9"
        resources.ApplyResources(Me.RibbonPageGroup9, "RibbonPageGroup9")
        '
        'RibbonPageGroup13
        '
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnKartuPiutang)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnLaporanSalesPerDO)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnKartuRetur)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnLaporanSaldoUM)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnRekapSaldoDivisi)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnRekapOmsetDivisi)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnRekapOmsetPembayaranCustomer)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnRekapOmsetCorporate)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnLaporanJurnal)
        Me.RibbonPageGroup13.ItemLinks.Add(Me.BtnLaporanJurnalDetail)
        Me.RibbonPageGroup13.Name = "RibbonPageGroup13"
        resources.ApplyResources(Me.RibbonPageGroup13, "RibbonPageGroup13")
        '
        'RibbonPageGroup14
        '
        Me.RibbonPageGroup14.ItemLinks.Add(Me.BtnCreateLapPembelian)
        Me.RibbonPageGroup14.ItemLinks.Add(Me.BtnValidasiLapPembelian)
        Me.RibbonPageGroup14.ItemLinks.Add(Me.BtnProsesJurnalPB)
        Me.RibbonPageGroup14.Name = "RibbonPageGroup14"
        resources.ApplyResources(Me.RibbonPageGroup14, "RibbonPageGroup14")
        '
        'RibbonPageGroup15
        '
        Me.RibbonPageGroup15.ItemLinks.Add(Me.BtnCreateLapRJ)
        Me.RibbonPageGroup15.ItemLinks.Add(Me.BtnValidasiLapRJ)
        Me.RibbonPageGroup15.ItemLinks.Add(Me.BtnProsesJurnalRJ)
        Me.RibbonPageGroup15.Name = "RibbonPageGroup15"
        resources.ApplyResources(Me.RibbonPageGroup15, "RibbonPageGroup15")
        '
        'RibbonPageGroup16
        '
        Me.RibbonPageGroup16.ItemLinks.Add(Me.BtnCreateLapRB)
        Me.RibbonPageGroup16.ItemLinks.Add(Me.BtnValidasiLapRB)
        Me.RibbonPageGroup16.ItemLinks.Add(Me.BtnProsesJurnalRB)
        Me.RibbonPageGroup16.ItemLinks.Add(Me.BtnReturPusat)
        Me.RibbonPageGroup16.ItemLinks.Add(Me.BtnPelunasanRetur)
        Me.RibbonPageGroup16.Name = "RibbonPageGroup16"
        resources.ApplyResources(Me.RibbonPageGroup16, "RibbonPageGroup16")
        '
        'RibbonPageCategorySistem
        '
        Me.RibbonPageCategorySistem.Name = "RibbonPageCategorySistem"
        Me.RibbonPageCategorySistem.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.PageSistem})
        resources.ApplyResources(Me.RibbonPageCategorySistem, "RibbonPageCategorySistem")
        '
        'PageSistem
        '
        Me.PageSistem.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupSistem})
        Me.PageSistem.Name = "PageSistem"
        resources.ApplyResources(Me.PageSistem, "PageSistem")
        '
        'GrupSistem
        '
        Me.GrupSistem.ItemLinks.Add(Me.BtnPerusahaan)
        Me.GrupSistem.ItemLinks.Add(Me.BtnGroupUser)
        Me.GrupSistem.Name = "GrupSistem"
        resources.ApplyResources(Me.GrupSistem, "GrupSistem")
        '
        'PageUser
        '
        Me.PageUser.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupUser})
        Me.PageUser.Name = "PageUser"
        resources.ApplyResources(Me.PageUser, "PageUser")
        '
        'GrupUser
        '
        Me.GrupUser.ItemLinks.Add(Me.BtnUbahPassword)
        Me.GrupUser.ItemLinks.Add(Me.BtnSwitchPeriode)
        Me.GrupUser.ItemLinks.Add(Me.BtnLogOut)
        Me.GrupUser.ItemLinks.Add(Me.BtnExit)
        Me.GrupUser.Name = "GrupUser"
        resources.ApplyResources(Me.GrupUser, "GrupUser")
        '
        'PageMaster
        '
        Me.PageMaster.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.GrupMasterUmum, Me.GrupLokasi})
        Me.PageMaster.Name = "PageMaster"
        resources.ApplyResources(Me.PageMaster, "PageMaster")
        Me.PageMaster.Visible = False
        '
        'GrupMasterUmum
        '
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnKaryawan)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnSupplier)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnCustomer)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnCorporation)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnDivisi)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnSBU)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnPT)
        Me.GrupMasterUmum.ItemLinks.Add(Me.BtnEkspedisi)
        Me.GrupMasterUmum.Name = "GrupMasterUmum"
        resources.ApplyResources(Me.GrupMasterUmum, "GrupMasterUmum")
        '
        'GrupLokasi
        '
        Me.GrupLokasi.ItemLinks.Add(Me.BtnGudang)
        Me.GrupLokasi.ItemLinks.Add(Me.BtnBarang)
        Me.GrupLokasi.ItemLinks.Add(Me.BtnPriceList)
        Me.GrupLokasi.ItemLinks.Add(Me.BtnHargaPromo)
        Me.GrupLokasi.Name = "GrupLokasi"
        resources.ApplyResources(Me.GrupLokasi, "GrupLokasi")
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.LblUser)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LblTanggal)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LblJam)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LblKeyboard)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LblVersion)
        resources.ApplyResources(Me.RibbonStatusBar, "RibbonStatusBar")
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.BackColor = CType(resources.GetObject("XtraTabbedMdiManager1.AppearancePage.HeaderActive.BackColor"), System.Drawing.Color)
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.BackColor2 = CType(resources.GetObject("XtraTabbedMdiManager1.AppearancePage.HeaderActive.BackColor2"), System.Drawing.Color)
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Font = CType(resources.GetObject("XtraTabbedMdiManager1.AppearancePage.HeaderActive.Font"), System.Drawing.Font)
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Options.UseBackColor = True
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Options.UseFont = True
        Me.XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader
        Me.XtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.FloatPageDragMode = DevExpress.XtraTabbedMdi.FloatPageDragMode.FullWindow
        Me.XtraTabbedMdiManager1.MdiParent = Me
        Me.XtraTabbedMdiManager1.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover
        Me.XtraTabbedMdiManager1.SetNextMdiChildMode = DevExpress.XtraTabbedMdi.SetNextMdiChildMode.TabControl
        Me.XtraTabbedMdiManager1.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.[True]
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem1.Id = 92
        Me.BarButtonItem1.ImageOptions.DisabledImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BarButtonItem1.ImageOptions.DisabledLargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BarButtonItem1.ImageOptions.Image = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BarButtonItem1.ImageOptions.LargeImage = Global.Maspion.My.Resources.Resources.Delivery_Order_Perwakilan
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'NavBarItem9
        '
        Me.NavBarItem9.Name = "NavBarItem9"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'FrmMDI
        '
        Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
        Me.Appearance.BackColor = CType(resources.GetObject("FrmMDI.Appearance.BackColor"), System.Drawing.Color)
        Me.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "FrmMDI"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents PageUser As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupUser As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LblUser As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LblTanggal As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LblJam As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LblVersion As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblKeyboard As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BtnUbahPassword As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLogOut As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSwitchPeriode As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PageMaster As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupMasterUmum As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnKaryawan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSupplier As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCustomer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDivisi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSBU As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnGudang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GrupLokasi As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PagePembelianLangganan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupPembelianLangganan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPurchaseOrderLangganan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPembelianLangganan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnClaimPembelianLangganan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnReturPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPusatTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPusatTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPusatBarangDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPusatNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPusatMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPerwakilanBarangDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPerwMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananStuffing As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPerwNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPerwTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLanggananPerwTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwakilanDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategoryPenjualanSupermarket As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents PagePenjualanSupermarketPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents PagePenjualanSupermarketPusat As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMonitoringCustomer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategoryPenjualanLain As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents PageMonitoring As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PagePenjualanLainPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents PagePenjualanLainPusat As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BtnSuratJalanTanpaHarga As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnBatasMin As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnBatasMax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMonitoringMinStok As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnTandaTerimaBarangLangganan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnReturLangganan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPenerimaanBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnTTB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnReturPenjualan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PageRetur As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPriceList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketStuffing As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BtnCorporation As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PagePenjualanLanggananPusat As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GroupPenjualanLanggananPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GroupPenjualanLanggananPusat As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageCategoryPenjualanLangganan As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents PagePenjualanLanggananPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageCategoryAdditional As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents BtnEkspedisi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnTransferBarangRetur As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPerwRefund As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMonitoringStok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPusatBarangDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPusatTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPusatTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPusatMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjSupermarketPusatNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupPenjualanSupermarketPusat As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPjLainPerwakilanBarangDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPerwTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPerwTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPerwMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainStuffing As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPerwNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSuratJalanTanpaHargaLain As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupPenjualanLainPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPjLainPusatBarangDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPusatTBarangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPusatTBarangBonPesananTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPusatMonPay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPjLainPusatNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupPenjualanLainPusat As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPenitipanBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PagePenitipanBarang As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupPenitipanBarang As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnSJPenitipanBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPaymentKreditLanggananPerwakilan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPaymentKreditLanggananPusat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPaymentKreditSupermarketPerwakilan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPaymentKreditSupermarketPusat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupPenjualanSupermarketPerwakilan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPaymentKreditLainPerwakilan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPaymentKreditLainPusat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDebitNote As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKreditNote As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PageDebitKreditNote As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnDailySalesReport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PageLaporan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupLaporan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnKartuStok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnTransferBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PagePersediaan As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupPersediaanTransferGudang As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPenerimaanTransfer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NavBarItem9 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents RibbonPageCategoryPembelian As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents BtnPurchaseOrderSupermarket As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PagePembelianSupermarket As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupPembelianSupermarket As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPembelianSupermarket As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnClaimPembelianSupermarket As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPerusahaan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PageSistem As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents GrupSistem As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnMappingBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GrupMapping As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnGroupUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents BtnPT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanNotaSJ As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanPriceList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMoDOOuts As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanPenjualan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSaldoAwalBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLPBL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnAdjusmentStok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLPBH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnReturPembelianTanpaTTB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPostingPeriode As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPenerimaanTransferBarangRetur As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporantransferGudang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnSummaryFinishGoods As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup7 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnControlSummary As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanAdjusmentStok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanReturPenjualan As DevExpress.XtraBars.BarButtonItem
    Private WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BtnCreateDSRPrw As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnValidasiPrw As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategoryAR As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup8 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnKodePerkiraan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnJurnal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup9 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnKasMasuk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKasKeluar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnBankMasuk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnBankKeluar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSetupAkuntansi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup10 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnCreateDSRPus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnValidasiPus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup11 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnHargaPromo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnTandaTerima As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup12 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnPenyerahanNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPengembalianNota As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnProsesJurnalPrw As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnProsesJurnalPus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPermintaanDibuatkanFakturPajak As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKonfirmasiDibuatkanFakturPajak As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnUangTitipan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMasterBank As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnSetoranPerPT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKartuPiutang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup13 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnKodeBatasan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPembayaranKontan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanSalesPerDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKartuRetur As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCN As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDN As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPengembalianDOKontan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnValidasiPengembalian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKekuranganDO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnValidasiKekurangan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanSaldoUM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnRekapSaldoDivisi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnRekapOmsetDivisi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnRekapOmsetPembayaranCustomer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnRekapOmsetCorporate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCutOffDOKontan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDebitNoteKontan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnKreditNoteKontan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanJurnal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnLaporanJurnalDetail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCreateLapPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup14 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnValidasiLapPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnProsesJurnalPB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCreateLapRJ As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup15 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnValidasiLapRJ As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnProsesJurnalRJ As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCreateLapRB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnValidasiLapRB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnProsesJurnalRB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup16 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnReturPusat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnPelunasanRetur As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategorySistem As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents BtnRincianPembayaran As DevExpress.XtraBars.BarButtonItem
End Class
