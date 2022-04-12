Public Class InputDeliveryOrderSupermarketPerwakilan
    Inherits FrmDeliveryOrder

    Private Sub InputDeliveryOrderSupermarketPerwakilan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Delivery Order Supermarket Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Supermarket_Perwakilan
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Call Generate()
    End Sub
End Class

Public Class EditDeliveryOrderSupermarketPerwakilan
    Inherits FrmDeliveryOrder

    Private Sub EditDeliveryOrderSupermarketPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Delivery Order Supermarket Perwakilan"
        RDPembayaran.Enabled = False
        Status_Edit = True

        Bagian = EBagian.Supermarket_Perwakilan
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Supermarket", "Perwakilan", "Delivery Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class