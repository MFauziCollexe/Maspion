
Public Class MenuTitipBarang
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI,NO_TITIP,TGL,NO_NOTA,TGL_NOTA,NAMA,ALAMAT_KIRIM FROM TITIP_BARANG A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.KODE_APPROVE WHERE PERIODE='" & periode & "' ORDER BY TGL")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Nota ]"
        GridView1.Columns(0).Caption = "ID. Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Titipan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Titipan"
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
        GridView1.Columns(6).Caption = "Alamat Kirim"
        GridView1.Columns(6).Width = 150
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,ROUND(A.QUANTITY * (A.HARGA),2) FROM DETAIL_TITIP_BARANG A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY URUTAN")
                    LoadDataToGrid.Init("ID", 15, , , False)
                    LoadDataToGrid.Init("Kode Barang", 50)
                    LoadDataToGrid.Init("Nama Barang", 150)
                    LoadDataToGrid.Init("Satuan", 30)
                    LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                    LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                    LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                    LoadDataToGrid.Init("Harga", 40, DevExpress.Utils.FormatType.Numeric, "n")
                    LoadDataToGrid.Init("Subtotal", 60, DevExpress.Utils.FormatType.Numeric, "n")
                    LoadDataToGrid.EndInit(TBMenuDetailMenu, GridView2)
                End Using
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Titip Barang Langganan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Penitipan Barang", "Titip Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputTitipBarangLangganan.MdiParent = Me.MdiParent
        InputTitipBarangLangganan.Show()
        InputTitipBarangLangganan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                If CekData("SELECT ID_TITIP FROM SJ_TITIP_BARANG WHERE ID_TITIP='" & GridView1.GetFocusedRow(0) & "'") Then Exit Sub
                EditTitipBarangLangganan.MdiParent = Me.MdiParent
                EditTitipBarangLangganan.Show()
                EditTitipBarangLangganan.Focus()
                EditTitipBarangLangganan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditTitipBarangLangganan
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

Public Class MenuSJTitipBarang
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI,NO_SJ,TGL,NO_TITIP,TGL_TITIP,NAMA,ALAMAT_KIRIM FROM SJ_TITIP_BARANG A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.KODE_APPROVE WHERE PERIODE='" & periode & "' ORDER BY TGL")
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
        GridView1.Columns(3).Caption = "No. Titip"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Titip"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Alamat Kirim"
        GridView1.Columns(6).Width = 150
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,QUANTITY,A.SATUAN FROM DETAIL_SJ_TITIP_BARANG A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "ID Barang"
                GridView2.Columns(1).Width = 40
                GridView2.Columns(2).Caption = "Kode Barang"
                GridView2.Columns(2).Width = 50
                GridView2.Columns(3).Caption = "Nama Barang"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Kuantum"
                GridView2.Columns(4).Width = 40
                GridView2.Columns(5).Caption = "Satuan"
                GridView2.Columns(5).Width = 50
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Titip Barang Langganan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Penitipan Barang", "Surat Jalan Penitipan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputSJTitipBarangLangganan.MdiParent = Me.MdiParent
        InputSJTitipBarangLangganan.Show()
        InputSJTitipBarangLangganan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditSJTitipBarangLangganan.MdiParent = Me.MdiParent
                EditSJTitipBarangLangganan.Show()
                EditSJTitipBarangLangganan.Focus()
                EditSJTitipBarangLangganan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditSJTitipBarangLangganan
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