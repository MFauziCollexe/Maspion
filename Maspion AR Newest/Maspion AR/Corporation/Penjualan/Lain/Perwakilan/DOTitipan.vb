Public Class InputDOTitipanLainPerwakilan
    Inherits FrmDOTitipan

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Titipan Lain - lain Perwakilan"
        LblTitle.Caption = "Titipan Lain - lain Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Lain_Perwakilan
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
    End Sub
End Class

Public Class EditDOTitipanLainPerwakilan
    Inherits FrmDOTitipan

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit DO Titipan Lain - lain Perwakilan"
        LblTitle.Caption = "Titipan Lain - lain Perwakilan"
        TxtDivisi.Enabled = False

        Bagian = EBagian.Lain_Perwakilan
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Penjualan Lain - lain", "Perwakilan", "DO Titipan", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class