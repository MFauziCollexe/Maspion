Public Class InputDeliveryOrderLainPusat
    Inherits FrmDeliveryOrder

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Delivery Order Lain Pusat"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Lain_Pusat
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Call Generate()
    End Sub
End Class

Public Class EditDeliveryOrderLainPusat
    Inherits FrmDeliveryOrder

    Private Sub EditDeliveryOrderLainPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Delivery Order Lain Pusat"
        RDPembayaran.Enabled = False
        Status_Edit = True

        Bagian = EBagian.Lain_Pusat
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Lain - lain", "Pusat", "Delivery Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class