Public Class MenuTTB
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_TTB, A.TGL_PENGAKUAN, A.NO_NOTA, A.TGL_NOTA, B.NAMA, C.NAMA_USER,A.BATAL FROM TTB A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE PERIODE='" & periode & "' AND D.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data TTB ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Nota"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Tanggal Nota"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Pembuat"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG, B.KODE, B.NAMA, A.QUANTITY, A.SATUAN, A.KETERANGAN FROM DETAIL_TTB A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Kuantum"
                GridView2.Columns(4).Width = 40
                GridView2.Columns(5).Caption = "Satuan"
                GridView2.Columns(5).Width = 30
                GridView2.Columns(6).Caption = "Keterangan"
                GridView2.Columns(6).Width = 150
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Tanda Terima Barang"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputTTB.MdiParent = Me.MdiParent
        InputTTB.Show()
        InputTTB.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditTTB.MdiParent = Me.MdiParent
                EditTTB.Show()
                EditTTB.Focus()
                EditTTB.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditTTB
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuNotaReturPenjualan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_NOTA_RETUR,A.TGL,B.NAMA,A.ALAMAT_KIRIM,A.NO_TTB,A.KETERANGAN_CETAK,C.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM RETUR_PENJUALAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE PERIODE='" & periode & "' AND D.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Alamat Kirim"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "No. TTB"
        GridView1.Columns(5).Width = 40
        GridView1.Columns(6).Caption = "Keterangan Cetak"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 75
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
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.PCS,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.PCS * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100)/A.KONVERSI,2) AS SUBTOTAL FROM DETAIL_RETUR_PENJUALAN A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 30
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Kuantum"
                GridView2.Columns(6).Width = 40
                GridView2.Columns(7).Caption = "Satuan"
                GridView2.Columns(7).Width = 50
                GridView2.Columns(8).Caption = "Harga"
                GridView2.Columns(8).Width = 60
                GridView2.Columns(9).Caption = "Disc %"
                GridView2.Columns(9).Width = 30
                GridView2.Columns(10).Caption = "Disc Satuan"
                GridView2.Columns(10).Width = 60
                GridView2.Columns(11).Caption = "Subtotal"
                GridView2.Columns(11).Width = 70
                GridView2.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(11).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Retur_Penjualan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Nota Retur Penjualan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Nota Retur Penjualan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Retur_Penjualan
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaReturPenjualan.MdiParent = Me.MdiParent
        InputNotaReturPenjualan.Show()
        InputNotaReturPenjualan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaReturPenjualan.MdiParent = Me.MdiParent
                EditNotaReturPenjualan.Show()
                EditNotaReturPenjualan.Focus()
                EditNotaReturPenjualan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditNotaReturPenjualan
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuNotaReturPembelian
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_RETUR,A.TGL,C.NAMA,C.ALAMAT_KANTOR,STUFF((SELECT DISTINCT ';' + X.NO_TTB FROM DETAIL_RETUR_PEMBELIAN X WHERE X.ID_TRANSAKSI=A.ID_TRANSAKSI FOR XML PATH('')), 1, 1, ''),A.KETERANGAN_INTERNAL,D.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM RETUR_PEMBELIAN A INNER JOIN DETAIL_RETUR_PEMBELIAN AA ON A.ID_TRANSAKSI=AA.ID_TRANSAKSI CROSS JOIN PERUSAHAAN B LEFT JOIN CUSTOMER C ON B.CUST_PEMBELIAN=C.ID LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN LINK_USER_DIVISI E ON A.DIVISI=E.KODE_DIVISI WHERE AA.ID_TTB IS NOT NULL AND PERIODE='" & periode & "'  AND E.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Alamat Kirim"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "NO. TTB"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Keterangan Internal"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 75
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
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.PCS,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.PCS * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100)/A.KONVERSI,2) AS SUBTOTAL FROM DETAIL_RETUR_PEMBELIAN A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 30
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Pcs"
                GridView2.Columns(6).Width = 40
                GridView2.Columns(7).Caption = "Satuan"
                GridView2.Columns(7).Width = 50
                GridView2.Columns(8).Caption = "Harga"
                GridView2.Columns(8).Width = 60
                GridView2.Columns(9).Caption = "Disc %"
                GridView2.Columns(9).Width = 30
                GridView2.Columns(10).Caption = "Disc Satuan"
                GridView2.Columns(10).Width = 60
                GridView2.Columns(11).Caption = "Subtotal"
                GridView2.Columns(11).Width = 70
                GridView2.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(11).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Nota Retur Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Retur Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Retur_Pembelian
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Retur_Pembelian, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaReturPembelian.MdiParent = Me.MdiParent
        InputNotaReturPembelian.Show()
        InputNotaReturPembelian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaReturPembelian.MdiParent = Me.MdiParent
                EditNotaReturPembelian.Show()
                EditNotaReturPembelian.Focus()
                EditNotaReturPembelian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditNotaReturPembelian
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuTransferBarangRetur
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,A.TGL,E.NAMA_GUDANG,F.NAMA_GUDANG,STUFF((SELECT DISTINCT ';' + X.NO_TTB FROM DETAIL_TRANSFER_BARANG_RETUR X WHERE X.ID_TRANSAKSI=A.ID_TRANSAKSI FOR XML PATH('')), 1, 1, ''),A.KETERANGAN_INTERNAL,D.NAMA_USER,A.BATAL FROM TRANSFER_BARANG_RETUR A CROSS JOIN PERUSAHAAN B LEFT JOIN CUSTOMER C ON B.CUST_PEMBELIAN=C.ID LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN GUDANG E ON A.GUDANG_SUMBER=E.KODE LEFT JOIN GUDANG F ON A.GUDANG_TUJUAN=F.KODE LEFT JOIN LINK_USER_DIVISI G ON A.DIVISI=G.KODE_DIVISI WHERE PERIODE='" & periode & "' AND G.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Gudang Sumber"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Gudang Tujuan"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "No. TTB"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Keterangan Internal"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 75
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA FROM DETAIL_TRANSFER_BARANG_RETUR A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 30
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Satuan"
                GridView2.Columns(6).Width = 50
                GridView2.Columns(7).Caption = "Harga"
                GridView2.Columns(7).Width = 60
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Transfer Barang Retur"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Transfer Barang Retur", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Transfer_Barang_Retur
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Transfer_Barang_Retur, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputTransferBarangRetur.MdiParent = Me.MdiParent
        InputTransferBarangRetur.Show()
        InputTransferBarangRetur.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditTransferBarangRetur.MdiParent = Me.MdiParent
                EditTransferBarangRetur.Show()
                EditTransferBarangRetur.Focus()
                EditTransferBarangRetur.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditTransferBarangRetur
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuNotaReturPembelianTanpaTTB
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_RETUR,A.TGL,C.NAMA,C.ALAMAT_KANTOR,A.KETERANGAN_CETAK,D.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM RETUR_PEMBELIAN A INNER JOIN DETAIL_RETUR_PEMBELIAN AA ON A.ID_TRANSAKSI=AA.ID_TRANSAKSI CROSS JOIN PERUSAHAAN B LEFT JOIN CUSTOMER C ON B.CUST_PEMBELIAN=C.ID LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN LINK_USER_DIVISI G ON A.DIVISI=G.KODE_DIVISI WHERE AA.ID_TTB IS NULL AND PERIODE='" & periode & "' AND G.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Alamat Kirim"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "Keterangan Cetak"
        GridView1.Columns(5).Width = 100
        GridView1.Columns(6).Caption = "Pembuat"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Total"
        GridView1.Columns(7).Width = 40
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "c2"
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100),2) AS SUBTOTAL FROM DETAIL_RETUR_PEMBELIAN A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 30
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Satuan"
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
                GridView2.Columns(10).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Nota Retur Pembelian Tanpa TTB"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Retur Pembellian Tanpa TTB", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Retur_Pembelian
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Retur_Pembelian_Tanpa_TTB, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaReturPembelianTanpaTTB.MdiParent = Me.MdiParent
        InputNotaReturPembelianTanpaTTB.Show()
        InputNotaReturPembelianTanpaTTB.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaReturPembelianTanpaTTB.MdiParent = Me.MdiParent
                EditNotaReturPembelianTanpaTTB.Show()
                EditNotaReturPembelianTanpaTTB.Focus()
                EditNotaReturPembelianTanpaTTB.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditNotaReturPembelianTanpaTTB
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuPenerimaanTransferBarangRetur
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,A.TGL,A.NO_TRANSFER,E.NAMA_GUDANG,F.NAMA_GUDANG,STUFF((SELECT DISTINCT ';' + X.NO_TTB FROM DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR X WHERE X.ID_TRANSAKSI=A.ID_TRANSAKSI FOR XML PATH('')), 1, 1, ''),A.KETERANGAN_INTERNAL,D.NAMA_USER,A.BATAL FROM PENERIMAAN_TRANSFER_BARANG_RETUR A CROSS JOIN PERUSAHAAN B LEFT JOIN CUSTOMER C ON B.CUST_PEMBELIAN=C.ID LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN GUDANG E ON A.GUDANG_SUMBER=E.KODE LEFT JOIN GUDANG F ON A.GUDANG_TUJUAN=F.KODE LEFT JOIN LINK_USER_DIVISI G ON A.DIVISI=G.KODE_DIVISI WHERE PERIODE='" & periode & "' AND G.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Purchase Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Transfer"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Gudang Sumber"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Gudang Tujuan"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "No. TTB"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Keterangan Internal"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Pembuat"
        GridView1.Columns(8).Width = 75
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA FROM DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(1).Visible = False
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 30
                GridView2.Columns(5).Caption = "Kuantum"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Satuan"
                GridView2.Columns(6).Width = 50
                GridView2.Columns(7).Caption = "Harga"
                GridView2.Columns(7).Width = 60
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Penerimaan Transfer Barang Retur"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Retur", "Penerimaan Transfer Barang Retur", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.Transfer_Barang_Retur
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPenerimaanTransferBarangRetur.MdiParent = Me.MdiParent
        InputPenerimaanTransferBarangRetur.Show()
        InputPenerimaanTransferBarangRetur.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPenerimaanTransferBarangRetur.MdiParent = Me.MdiParent
                EditPenerimaanTransferBarangRetur.Show()
                EditPenerimaanTransferBarangRetur.Focus()
                EditPenerimaanTransferBarangRetur.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPenerimaanTransferBarangRetur
                frm.MdiParent = Me.MdiParent
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class