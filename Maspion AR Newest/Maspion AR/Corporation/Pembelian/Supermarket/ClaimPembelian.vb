﻿Public Class InputClaimPembelianSupermarket
    Inherits FrmNotaClaim

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Claim Pembelian"
        LblTitle.Caption = "Claim Pembelian Supermarket"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        Bagian = EBagian.Pembelian_Supermarket
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditClaimPembelianSupermarket
    Inherits FrmNotaClaim

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Claim Pembelian Supermarket"
        LblTitle.Caption = "Claim Pembelian Supermarket"
        RDJenisPPN.Enabled = False
        TxtDivisi.Enabled = False
        Bagian = EBagian.Pembelian_Supermarket

        Status_Edit = True
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        HakForm("Pembelian", "Supermarket", "Claim Pembelian", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class