Public Class InputBonPesananSupermarketPerwakilan
    Inherits FrmBonPesanan

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bon Pesanan Supermarket Perwakilan"
        LblTitle.Caption = "Bon Pesanan Supermarket Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditBonPesananSupermarketPerwakilan
    Inherits FrmBonPesanan

    Private Sub EditDeliveryOrderSupermarketPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Bon Pesanan Supermarket Perwakilan"
        LblTitle.Caption = "Bon Pesanan Supermarket Perwakilan"
        RDJenisPPN.Enabled = False
        TxtDivisi.Enabled = False
        TxtIDDO.Enabled = False
        Status_Edit = True
        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Supermarket", "Perwakilan", "Bon Pesanan (Titipan)", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class
