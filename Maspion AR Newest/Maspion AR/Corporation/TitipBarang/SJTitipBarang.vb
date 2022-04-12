Public Class InputSJTitipBarangLangganan
    Inherits FrmSJTitipBarang

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input SJ Titip Barang Langganan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Generate()

        'Bagian = EBagian.Langganan_Pusat
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditSJTitipBarangLangganan
    Inherits FrmSJTitipBarang

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit SJ Titip Barang Langganan"
        TxtDivisi.Enabled = False
        Status_Edit = True

        'Bagian = EBagian.Langganan_Pusat
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("", "Penitipan Barang", "Surat Jalan Penitipan Barang", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class