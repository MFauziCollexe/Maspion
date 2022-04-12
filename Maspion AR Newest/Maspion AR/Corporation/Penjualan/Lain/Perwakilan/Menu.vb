Public Class MenuDeliveryOrderLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,B.NAMA,D.NAMA_USER,G.NAMA_GUDANG,A.PEMBAYARAN,A.TERMS,DPP+PPN AS TOTAL,A.BATAL FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER LEFT JOIN GUDANG G ON A.GUDANG=G.KODE WHERE BAGIAN='Lain Perwakilan' AND JENIS_DO='Ada Barang' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
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
        GridView1.Columns(3).Caption = "Tanggal Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Pembuat"
        GridView1.Columns(5).Width = 50
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 50
        GridView1.Columns(7).Caption = "Pembayaran"
        GridView1.Columns(7).Width = 20
        GridView1.Columns(8).Caption = "Terms"
        GridView1.Columns(8).Width = 15
        GridView1.Columns(9).Caption = "Total"
        GridView1.Columns(9).Width = 40
        GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(9).DisplayFormat.FormatString = "n2"
        GridView1.Columns(10).Visible = False
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
        Key = "Delivery Order Lain Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Perwakilan", "Delivery Order", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
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
        InputDeliveryOrderLainPerwakilan.MdiParent = Me.MdiParent
        InputDeliveryOrderLainPerwakilan.Show()
        InputDeliveryOrderLainPerwakilan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDeliveryOrderLainPerwakilan.MdiParent = Me.MdiParent
                EditDeliveryOrderLainPerwakilan.Show()
                EditDeliveryOrderLainPerwakilan.Focus()
                EditDeliveryOrderLainPerwakilan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditDeliveryOrderLainPerwakilan
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Bar2.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuDOTitipanLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,B.NAMA,D.NAMA_USER,A.TGL_PRICE,DPP+PPN AS TOTAL,A.BATAL FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Perwakilan' AND JENIS_DO='Tanpa Barang' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
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
        Key = "DO Titipan Lain Perwakilan"
        AddHandler Activated, AddressOf GetData
        SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        HakMenu("Penjualan Lain - lain", "Perwakilan", "DO Titipan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.DO_Titipan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDOTitipanLainPerwakilan.MdiParent = Me.MdiParent
        InputDOTitipanLainPerwakilan.Show()
        InputDOTitipanLainPerwakilan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonBaru.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDOTitipanLainPerwakilan.MdiParent = Me.MdiParent
                EditDOTitipanLainPerwakilan.Show()
                EditDOTitipanLainPerwakilan.Focus()
                EditDOTitipanLainPerwakilan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuBonPesananLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_BON,A.TGL,A.TGL_PENGAKUAN,A.NO_DO,A.TGL_PRICE,B.NAMA,D.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM BON_PESANAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Perwakilan' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "'")
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
        Key = "Bon Pesanan Lain Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Perwakilan", "Bon Pesanan (Titipan)", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Titipan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBonPesananLainPerwakilan.MdiParent = Me.MdiParent
        InputBonPesananLainPerwakilan.Show()
        InputBonPesananLainPerwakilan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonBaru.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBonPesananLainPerwakilan.MdiParent = Me.MdiParent
                EditBonPesananLainPerwakilan.Show()
                EditBonPesananLainPerwakilan.Focus()
                EditBonPesananLainPerwakilan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuStuffingLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI,NO_STUFFING,TGL,NO_DO,TGL_DO,NAMA,D.NAMA_USER,A.BATAL FROM STUFFING A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Perwakilan' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "' ORDER BY TGL")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Nota ]"
        GridView1.Columns(0).Caption = "ID. Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Stuffing"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Stuffing"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. DO"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. DO"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Pembuat"
        GridView1.Columns(6).Width = 50
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT URUTAN,B.KODE,NAMA,QUANTITY,SATUAN FROM DETAIL_STUFFING A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Barang"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Nama Barang"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Kuantum"
                GridView2.Columns(3).Width = 40
                GridView2.Columns(4).Caption = "Satuan"
                GridView2.Columns(4).Width = 50
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Stuffing Lain Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Perwakilan", "Stuffing", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Stuffing, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputStuffingLainPerwakilan.MdiParent = Me.MdiParent
        InputStuffingLainPerwakilan.Show()
        InputStuffingLainPerwakilan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonBaru.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditStuffingLainPerwakilan.MdiParent = Me.MdiParent
                EditStuffingLainPerwakilan.Show()
                EditStuffingLainPerwakilan.Focus()
                EditStuffingLainPerwakilan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuNotaSJLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT ID_TRANSAKSI,NO_NOTA,TGL,TGL_PENGAKUAN,NO_DO,TGL_DO,B.NAMA,D.NAMA_USER,A.DPP+A.PPN AS TOTAL,A.BATAL FROM NOTA A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Perwakilan' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "' ORDER BY TGL")
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
        Key = "Nota / SJ Lain Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Perwakilan", "Nota / Surat Jalan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Nota_SJ
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputNotaSJLainPerwakilan.MdiParent = Me.MdiParent
        InputNotaSJLainPerwakilan.Show()
        InputNotaSJLainPerwakilan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonBaru.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditNotaSJLainPerwakilan.MdiParent = Me.MdiParent
                EditNotaSJLainPerwakilan.Show()
                EditNotaSJLainPerwakilan.Focus()
                EditNotaSJLainPerwakilan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class

Public Class MenuSJLainPerwakilan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI,NO_SJ,TGL,NO_NOTA,TGL_NOTA,NAMA,D.NAMA_USER,A.BATAL FROM SURAT_JALAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN LINK_USER_DIVISI C ON A.DIVISI=C.KODE_DIVISI LEFT JOIN USERS D ON A.CRUSER=D.ID_USER WHERE BAGIAN='Lain Perwakilan' AND PERIODE='" & periode & "' AND C.ID_USER='" & UserID & "' ORDER BY TGL")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Nota ]"
        GridView1.Columns(0).Caption = "ID. Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. SJ"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. SJ"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Nota"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Nota"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Pembuat"
        GridView1.Columns(6).Width = 50
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI,A.QUANTITY,A.PCS FROM DETAIL_SURAT_JALAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Satuan"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(5).Caption = "Koli"
                GridView2.Columns(5).Width = 40
                GridView2.Columns(6).Caption = "Kuantum"
                GridView2.Columns(6).Width = 40
                GridView2.Columns(7).Caption = "Pcs"
                GridView2.Columns(7).Width = 40
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "SJ Tanpa Harga Lain Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Penjualan Lain - lain", "Perwakilan", "Surat Jalan Tanpa Harga", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Surat_Jalan, GridView1.GetFocusedRow(0))
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputSJLainPusat.MdiParent = Me.MdiParent
        InputSJLainPusat.Show()
        InputSJLainPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonBaru.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditSJLainPusat.MdiParent = Me.MdiParent
                EditSJLainPusat.Show()
                EditSJLainPusat.Focus()
                EditSJLainPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class