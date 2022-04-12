Public Class MenuDeliveryOrderLainPusat
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_DO,A.TGL_PENGAKUAN,B.NAMA,D.NAMA_USER,G.NAMA_GUDANG,A.PEMBAYARAN,A.TERMS,DPP+PPN AS TOTAL,A.BATAL FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN GUDANG G ON A.GUDANG=G.KODE WHERE BAGIAN='Lain Pusat' AND JENIS_DO='Ada Barang' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Delivery Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Pengakuan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Pembuat"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 50
        GridView1.Columns(6).Caption = "Pembayaran"
        GridView1.Columns(6).Width = 20
        GridView1.Columns(7).Caption = "Terms"
        GridView1.Columns(7).Width = 15
        GridView1.Columns(8).Caption = "Total"
        GridView1.Columns(8).Width = 40
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100),2) AS SUBTOTAL FROM DETAIL_DELIVERY_ORDER A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
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
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 40
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
        Key = "Delivery Order Lain Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Pusat", "Delivery Order", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.DO_Kontan
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        Using dtcek As DataTable = SelectCon.execute("SELECT PEMBAYARAN FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) = "Kontan" Then
                    ShowDevexpressReport(ReportPreview.KeyReport.DO_Kontan, GridView1.GetFocusedRow(0))
                ElseIf dtcek.Rows(0).Item(0) = "Kredit" Then
                    ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Order, GridView1.GetFocusedRow(0))
                End If
            End If
        End Using
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDeliveryOrderLainPusat.MdiParent = Me.MdiParent
        InputDeliveryOrderLainPusat.Show()
        InputDeliveryOrderLainPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDeliveryOrderLainPusat.MdiParent = Me.MdiParent
                EditDeliveryOrderLainPusat.Show()
                EditDeliveryOrderLainPusat.Focus()
                EditDeliveryOrderLainPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                Log.Load(EditDeliveryOrderLainPusat, GridView1.GetFocusedRow(0))
            End If
        End If
    End Sub
End Class

Public Class MenuDOTitipanLainPusat
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,B.NAMA,D.NAMA_USER,A.TGL_PRICE,DPP+PPN AS TOTAL,A.BATAL FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Pusat' AND JENIS_DO='Tanpa Barang' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Delivery Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Pembuat"
        GridView1.Columns(5).Width = 50
        GridView1.Columns(6).Caption = "Tgl. Price List"
        GridView1.Columns(6).Width = 30
        GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(6).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(7).Caption = "Total"
        GridView1.Columns(7).Width = 40
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "c2"
        GridView1.Columns(8).Visible = False
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "DO Titipan Lain Pusat"
        AddHandler Activated, AddressOf GetData
        SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        HakMenu("Penjualan Lain - lain", "Pusat", "DO Titipan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.DO_Titipan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDOTitipanLainPusat.MdiParent = Me.MdiParent
        InputDOTitipanLainPusat.Show()
        InputDOTitipanLainPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDOTitipanLainPusat.MdiParent = Me.MdiParent
                EditDOTitipanLainPusat.Show()
                EditDOTitipanLainPusat.Focus()
                EditDOTitipanLainPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuBonPesananLainPusat
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_BON,A.TGL,A.TGL_PENGAKUAN,A.NO_DO,A.TGL_PRICE,B.NAMA,D.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM BON_PESANAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Pusat' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Delivery Order ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "No. DO Titipan"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Tgl. Price List"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(5).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(6).Caption = "Nama Customer"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 50
        GridView1.Columns(8).Caption = "Total"
        GridView1.Columns(8).Width = 40
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100),2) AS SUBTOTAL FROM DETAIL_BON_PESANAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
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
                GridView2.Columns(4).Caption = "Koli"
                GridView2.Columns(4).Width = 40
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
        Key = "Bon Pesanan Lain Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Pusat", "Bon Pesanan (Titipan)", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Titipan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBonPesananLainPusat.MdiParent = Me.MdiParent
        InputBonPesananLainPusat.Show()
        InputBonPesananLainPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBonPesananLainPusat.MdiParent = Me.MdiParent
                EditBonPesananLainPusat.Show()
                EditBonPesananLainPusat.Focus()
                EditBonPesananLainPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuNotaSJLainPusat
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT ID_TRANSAKSI,NO_NOTA,TGL,TGL_PENGAKUAN,NO_DO,TGL_DO,B.NAMA,D.NAMA_USER,A.DPP+A.PPN AS TOTAL,A.BATAL FROM NOTA A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Pusat' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "' ORDER BY TGL")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Nota ]"
        GridView1.Columns(0).Caption = "ID. Nota"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Nota"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Nota"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "No. DO"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Tgl. DO"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(5).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(6).Caption = "Nama Customer"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Pembuat"
        GridView1.Columns(7).Width = 50
        GridView1.Columns(8).Caption = "Total"
        GridView1.Columns(8).Width = 40
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100),2) AS SUBTOTAL FROM DETAIL_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Barang"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Nama Barang"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Koli"
                GridView2.Columns(3).Width = 40
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
        Key = "Nota / SJ Lain Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Pusat", "Nota / Surat Jalan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Nota_SJ
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaSJLainPusat.MdiParent = Me.MdiParent
        InputNotaSJLainPusat.Show()
        InputNotaSJLainPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaSJLainPusat.MdiParent = Me.MdiParent
                EditNotaSJLainPusat.Show()
                EditNotaSJLainPusat.Focus()
                EditNotaSJLainPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

