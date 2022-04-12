Public Class InputDeliveryOrderLanggananPerwakilan
    Inherits FrmDeliveryOrder

    Private Sub InputDeliveryOrderLanggananPerwakilan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Delivery Order Langganan Perwakilan"
        LblTitle.Caption = "Delivery Order Langganan Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Langganan_Perwakilan
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditDeliveryOrderLanggananPerwakilan
    Inherits FrmDeliveryOrder

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Delivery Order Langganan Perwakilan"
        LblTitle.Caption = "Delivery Order Langganan Perwakilan"
        RDPembayaran.Enabled = False
        Status_Edit = True

        Bagian = EBagian.Langganan_Perwakilan
        Jenis = EJenis.Ada_Barang
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Langganan", "Perwakilan", "Delivery Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class