﻿Public Class InputStuffingLanggananPerwakilan
    Inherits FrmStuffing

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Stuffing Langganan Perwakilan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        Bagian = EBagian.Langganan_Perwakilan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditStuffingLanggananPerwakilan
    Inherits FrmStuffing

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Stuffing Langganan Perwakilan"
        TxtDivisi.Enabled = False
        Status_Edit = True

        Bagian = EBagian.Langganan_Perwakilan
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        HakForm("Penjualan Langganan", "Perwakilan", "Stuffing", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class