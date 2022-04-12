Public Class MenuPOSupermarket
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_PO,A.TGL_PENGAKUAN,B.NAMA,STUFF((SELECT '; ' + ' ' + D.NO_DO + ' ' FROM DETAIL_PURCHASE_ORDER D WHERE D.ID_TRANSAKSI=A.ID_TRANSAKSI ORDER BY D.NO_DO FOR XML PATH('')), 1, 1, '') NO_DO,D.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM PURCHASE_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE PERIODE='" & periode & "' AND A.BAGIAN LIKE '%Supermarket%' AND C.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Pengakuan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "No. DO"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "Pembuat"
        GridView1.Columns(5).Width = 40
        GridView1.Columns(6).Caption = "Total"
        GridView1.Columns(6).Width = 40
        GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(6).DisplayFormat.FormatString = "n2"
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL FROM DETAIL_PURCHASE_ORDER A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Kuantum"
                GridView2.Columns(4).Width = 40
                GridView2.Columns(5).Caption = "Satuan"
                GridView2.Columns(5).Width = 50
                GridView2.Columns(6).Caption = "Harga"
                GridView2.Columns(6).Width = 60
                GridView2.Columns(7).Caption = "Disc %"
                GridView2.Columns(7).Width = 30
                GridView2.Columns(8).Caption = "Disc Satuan"
                GridView2.Columns(8).Width = 60
                GridView2.Columns(9).Caption = "Subtotal"
                GridView2.Columns(9).Width = 70
                GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(9).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Purchase Order Supermarket"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Pembelian", "Supermarket", "Purchase Order", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPOSupermarket.MdiParent = Me.MdiParent
        InputPOSupermarket.Show()
        InputPOSupermarket.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPOSupermarket.MdiParent = Me.MdiParent
                EditPOSupermarket.Show()
                EditPOSupermarket.Focus()
                EditPOSupermarket.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPOSupermarket
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Purchase_Order, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub
End Class

Public Class MenuNotaClaimSupermarket
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_CLAIM,A.TGL_PENGAKUAN,A.NO_NOTA,A.TGL_NOTA,B.NAMA,C.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM CLAIM A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE PERIODE='" & periode & "' AND A.BAGIAN LIKE '%Supermarket%' AND D.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal Pengakuan"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Nota"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Tanggal Nota"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 20
        GridView1.Columns(6).Caption = "Pembuat"
        GridView1.Columns(6).Width = 40
        GridView1.Columns(7).Caption = "Total"
        GridView1.Columns(7).Width = 40
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n2"
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA - A.DISKON_SATUAN),2) AS SUBTOTAL FROM DETAIL_CLAIM A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Quantity"
                GridView2.Columns(4).Width = 40
                GridView2.Columns(5).Caption = "Satuan"
                GridView2.Columns(5).Width = 50
                GridView2.Columns(6).Caption = "Harga"
                GridView2.Columns(6).Width = 60
                GridView2.Columns(7).Caption = "Disc %"
                GridView2.Columns(7).Width = 30
                GridView2.Columns(8).Caption = "Disc Satuan"
                GridView2.Columns(8).Width = 60
                GridView2.Columns(9).Caption = "Subtotal"
                GridView2.Columns(9).Width = 70
                GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(9).DisplayFormat.FormatString = "c"
            End If
        End If
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_Claim, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Nota Claim Pembelian Supermarket"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Pembelian", "Supermarket", "Claim Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputClaimPembelianSupermarket.MdiParent = Me.MdiParent
        InputClaimPembelianSupermarket.Show()
        InputClaimPembelianSupermarket.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditClaimPembelianSupermarket.MdiParent = Me.MdiParent
                EditClaimPembelianSupermarket.Show()
                EditClaimPembelianSupermarket.Focus()
                EditClaimPembelianSupermarket.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditClaimPembelianSupermarket
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuNotaPembelianSupermarket
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL_PENGAKUAN,A.NO_NOTA_PENJUALAN, A.NO_PO,A.TGL_PO,B.NAMA,C.NAMA_USER,A.DPP+A.PPN AS TOTAL,A.BATAL FROM PEMBELIAN A LEFT JOIN SBU B ON A.KODE_SUPPLIER=B.KODE LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE BAGIAN LIKE '%Supermarket%' AND D.ID_USER='" & UserID & "' AND PERIODE='" & periode & "' ORDER BY TGL")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Nota ]"
        GridView1.Columns(0).Caption = "ID. Nota"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Nota Pembelian"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Pengakuan"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Nota Penjualan"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "No. DO"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Tgl. DO"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(5).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(6).Caption = "Nama Customer"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(8).Caption = "Total"
        GridView1.Columns(8).Width = 40
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "c2"
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,B.KODE,B.NAMA,A.SATUAN,A.KOLI,A.QUANTITY,A.PCS,A.DISC,A.HARGA,A.DISKON_SATUAN,(A.PCS * ((A.HARGA-A.DISKON_SATUAN)/A.KONVERSI)) FROM DETAIL_PEMBELIAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Barang"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Nama Barang"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Satuan"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 40
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Pcs"
                GridView2.Columns(6).Width = 50
                GridView2.Columns(7).Caption = "Harga"
                GridView2.Columns(7).Width = 60
                GridView2.Columns(8).Caption = "Disc %"
                GridView2.Columns(8).Width = 30
                GridView2.Columns(9).Caption = "Disc Satuan"
                GridView2.Columns(9).Width = 60
                GridView2.Columns(10).Caption = "Subtotal"
                GridView2.Columns(10).Width = 70
                GridView2.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(10).DisplayFormat.FormatString = "c2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Nota Pembelian Supermarket"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Pembelian", "Supermarket", "Nota Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaPembelianSupermarket.MdiParent = Me.MdiParent
        InputNotaPembelianSupermarket.Show()
        InputNotaPembelianSupermarket.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaPembelianSupermarket.MdiParent = Me.MdiParent
                EditNotaPembelianSupermarket.Show()
                EditNotaPembelianSupermarket.Focus()
                EditNotaPembelianSupermarket.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditNotaPembelianSupermarket
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class
