﻿'================================================== INPUT PO ================================
Public Class InputPOSupermarket
    Inherits FrmPO

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Purchase Order Supermarket"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Bagian = EBagian.Pembelian_Supermarket
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT PO ================================
Public Class EditPOSupermarket
    Inherits FrmPO

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Purchase Order Supermarket"
        RDJenisPPN.Enabled = False
        TxtDivisi.Enabled = False

        Bagian = EBagian.Pembelian_Supermarket
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        HakForm("Pembelian", "Supermarket", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class