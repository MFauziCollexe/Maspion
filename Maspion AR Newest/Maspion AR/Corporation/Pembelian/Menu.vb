Imports DevExpress.XtraBars

Public Class MenuPriceList
    Inherits FrmMenuDetail

    Private Sub GetData()
        'TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,TGL,TGL_PRICE,C.NAMA,JENIS_PRICE,B.JENIS,STUFF((SELECT '; ' + '(' + D.KODE_APPROVE + ') ' + CUSTOMER.NAMA FROM DETAIL_PRICE_LIST_CUSTOMER D LEFT JOIN CUSTOMER ON D.KODE_APPROVE=CUSTOMER.KODE_APPROVE WHERE D.ID_TRANSAKSI=A.ID_TRANSAKSI ORDER BY NAMA FOR XML PATH('')), 1, 1, '') CUSTOMER,A.BATAL FROM PRICE_LIST A INNER JOIN DETAIL_PRICE_LIST B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE WHERE SUBSTRING(PERIODE,3,2)='" & Microsoft.VisualBasic.Right(periode, 2) & "'")
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,TGL,TGL_PRICE,C.NAMA, JENIS_PRICE,B.JENIS,A.CUSTOMER,A.BATAL FROM PRICE_LIST A INNER JOIN DETAIL_PRICE_LIST B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE WHERE SUBSTRING(PERIODE,3,2)='" & Microsoft.VisualBasic.Right(periode, 2) & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Price List ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal Transaksi"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Price List"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Jenis"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 50
        GridView1.Columns(7).Caption = "Nama Customer"
        GridView1.Columns(7).Width = 200
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,B.KODE,B.NAMA,A.SATUAN,A.SATUAN1,A.ISI,A.SATUANK,A.SATUANK1,A.HARGA_LAMA,A.HARGA_BARU FROM DETAIL_PRICE_LIST A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Barang"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Nama Barang"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Satuan 1"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(4).Caption = "Satuan 2"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(5).Caption = "Isi"
                GridView2.Columns(5).Width = 60
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n"
                GridView2.Columns(6).Caption = "Satuan Kecil 1"
                GridView2.Columns(6).Width = 60
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n"
                GridView2.Columns(7).Caption = "Satuan Kecil 2"
                GridView2.Columns(7).Width = 60
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n"
                GridView2.Columns(8).Caption = "Harga Lama"
                GridView2.Columns(8).Width = 60
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "c"
                GridView2.Columns(9).Caption = "Harga Baru"
                GridView2.Columns(9).Width = 60
                GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(9).DisplayFormat.FormatString = "c"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Price List"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Master", "Price List", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPriceList.MdiParent = Me.MdiParent
        InputPriceList.Show()
        InputPriceList.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPriceList.MdiParent = Me.MdiParent
                EditPriceList.Show()
                EditPriceList.Focus()
                EditPriceList.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPriceList
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
        GridView2.ShowPrintPreview()
        Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub
End Class
