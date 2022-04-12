Public Class InputNotaPembelianLangganan
    Inherits FrmNotaPembelian

    Private Sub InputNotaSJLanggananPerwakilan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Pembelian Langganan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        Bagian = EBagian.Pembelian_Langganan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditNotaPembelianLangganan
    Inherits FrmNotaPembelian

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Pembelian Langganan"
        RDJenisPPN.Enabled = False
        TxtDivisi.Enabled = False
        Status_Edit = True
        TxtNoPO.Enabled = False

        Bagian = EBagian.Pembelian_Langganan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        HakForm("Pembelian", "Langganan", "Nota Pembelian", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class