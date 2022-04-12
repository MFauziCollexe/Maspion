Public Class InputDOTitipanSupermarketPerwakilan
    Inherits FrmDOTitipan

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Titipan Supermarket Perwakilan"
        LblTitle.Caption = "DO Titipan Supermarket Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
    End Sub
End Class

Public Class EditDOTitipanSupermarketPerwakilan
    Inherits FrmDOTitipan

    Private Sub EditDeliveryOrderSupermarketPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit DO Titipan Supermarket Perwakilan"
        LblTitle.Caption = "DO Titipan Supermarket Perwakilan"
        TxtDivisi.Enabled = False

        Bagian = EBagian.Supermarket_Perwakilan
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Supermarket", "Perwakilan", "DO Titipan", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class