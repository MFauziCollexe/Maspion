
Public Class MenuKaryawan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_USER,NAMA_USER,NAMA_GROUP,ALAMAT,KOTA,TELP,JABATAN from USERS A LEFT JOIN GROUP_USER B ON A.ID_GROUP=B.ID_GROUP where ID_USER <> '000' ORDER BY id_user")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Karyawan ]"
        GridView1.Columns(0).Caption = "Id Karyawan"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Group User"
        GridView1.Columns(2).Width = 100
        GridView1.Columns(3).Caption = "Alamat"
        GridView1.Columns(3).Width = 175
        GridView1.Columns(4).Caption = "Kota"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Tlp"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Jabatan"
        GridView1.Columns(6).Width = 100
    End Sub


    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Karyawan"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Karyawan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKaryawan.MdiParent = Me.MdiParent
        InputKaryawan.Show()
        InputKaryawan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKaryawan.MdiParent = Me.MdiParent
                EditKaryawan.Show()
                EditKaryawan.Focus()
                EditKaryawan.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKaryawan
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

'Public Class MenuSupplier
'    Inherits FrmMenu

'    Private Sub GetData()
'        TBMenu.DataSource = SelectCon.execute("SELECT ID,NAMA,ALAMAT_KANTOR,KOTA,TELP,FAX,CONTACT_PERSON,NPWP,CASE STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM SUPPLIER ORDER BY ID")
'        TBMenu.Refresh()
'        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Supplier ]"
'        GridView1.Columns(0).Caption = "Id Supplier"
'        GridView1.Columns(0).Width = 50
'        GridView1.Columns(1).Caption = "Nama"
'        GridView1.Columns(1).Width = 125
'        GridView1.Columns(2).Caption = "Alamat"
'        GridView1.Columns(2).Width = 175
'        GridView1.Columns(3).Caption = "Kota"
'        GridView1.Columns(3).Width = 75
'        GridView1.Columns(4).Caption = "Tlp"
'        GridView1.Columns(4).Width = 75
'        GridView1.Columns(5).Caption = "Fax"
'        GridView1.Columns(5).Width = 75
'        GridView1.Columns(6).Caption = "Contact Person"
'        GridView1.Columns(6).Width = 100
'        GridView1.Columns(7).Caption = "NPWP"
'        GridView1.Columns(7).Width = 75
'        GridView1.Columns(8).Caption = "Status Aktif"
'        GridView1.Columns(8).Width = 50
'    End Sub


'    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
'        Key = "Supplier"
'        AddHandler Me.Activated, AddressOf GetData
'    End Sub

'    Private Sub Baru() Handles BarButtonBaru.ItemClick
'        InputSupplier.MdiParent = Me.MdiParent
'        InputSupplier.Show()
'        InputSupplier.Focus()
'    End Sub

'    Private Sub Edit() Handles BarButtonEdit.ItemClick
'        If GridView1.RowCount > 0 Then
'            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
'                EditSupplier.MdiParent = Me.MdiParent
'                EditSupplier.Show()
'                EditSupplier.Focus()
'                EditSupplier.TxtKode.Text = GridView1.GetFocusedRow(0)
'            End If
'        End If
'    End Sub
'End Class

Public Class MenuCustomer
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID,C.KODE_CORPORATION,KODE_APPROVE,GROUP_CUSTOMER,A.NAMA,ALAMAT_KANTOR,B.NAMA,NO_TELP,NO_NPWP,CONTACT_PERSON,CASE A.STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM CUSTOMER A LEFT JOIN PT B ON A.KODE_PT=B.KODE LEFT JOIN LINK_CORPORATION_CUSTOMER C ON A.ID=C.ID_CUSTOMER ORDER BY ID")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Customer ]"
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "Kode Corp."
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Kode Customer"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Group Customer"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Nama"
        GridView1.Columns(4).Width = 125
        GridView1.Columns(5).Caption = "Alamat"
        GridView1.Columns(5).Width = 175
        GridView1.Columns(6).Caption = "PT"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Caption = "Tlp"
        GridView1.Columns(7).Width = 75
        GridView1.Columns(8).Caption = "NPWP"
        GridView1.Columns(8).Width = 75
        GridView1.Columns(9).Caption = "Contact Person"
        GridView1.Columns(9).Width = 100
        GridView1.Columns(10).Caption = "Status Aktif"
        GridView1.Columns(10).Width = 50
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Customer"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Customer", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputCustomer.MdiParent = Me.MdiParent
        InputCustomer.Show()
        InputCustomer.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditCustomer.MdiParent = Me.MdiParent
                EditCustomer.Show()
                EditCustomer.Focus()
                EditCustomer.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditCustomer
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuDivisi
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.KODE,A.NAMA,A.PENANGGUNG_JAWAB,A.KETERANGAN,C.NAMA,CASE A.STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM DIVISI A LEFT JOIN LINK_SBU_DIVISI B ON A.KODE=B.KODE_DIVISI LEFT JOIN SBU C ON B.KODE_SBU=C.KODE ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Divisi ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Penanggung Jawab"
        GridView1.Columns(2).Width = 125
        GridView1.Columns(3).Caption = "Keterangan"
        GridView1.Columns(3).Width = 150
        GridView1.Columns(4).Caption = "SBU"
        GridView1.Columns(4).Width = 125
        GridView1.Columns(5).Caption = "Status Aktif"
        GridView1.Columns(5).Width = 75
    End Sub


    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Divisi"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDivisi.MdiParent = Me.MdiParent
        InputDivisi.Show()
        InputDivisi.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDivisi.MdiParent = Me.MdiParent
                EditDivisi.Show()
                EditDivisi.Focus()
                EditDivisi.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditDivisi
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuSBU
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,INISIAL,CASE STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM SBU ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Sentral Bisnis Unit ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 150
        GridView1.Columns(2).Caption = "Alamat"
        GridView1.Columns(2).Width = 175
        GridView1.Columns(3).Caption = "Telp"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Penanggung Jawab"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Inisial"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Status Aktif"
        GridView1.Columns(6).Width = 50
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail() Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KODE_DIVISI,B.NAMA,B.PENANGGUNG_JAWAB FROM LINK_SBU_DIVISI A LEFT JOIN DIVISI B ON A.KODE_DIVISI=B.KODE WHERE A.KODE_SBU='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Kode Divisi"
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nama Divisi"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Penanggung Jawab"
                GridView2.Columns(2).Width = 50
            End If
        End If
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Sentral Bisnis Unit"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "SBU", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputSBU.MdiParent = Me.MdiParent
        InputSBU.Show()
        InputSBU.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditSBU.MdiParent = Me.MdiParent
                EditSBU.Show()
                EditSBU.Focus()
                EditSBU.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditSBU
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuPT
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,INISIAL,CASE STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM PT ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data PT ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 150
        GridView1.Columns(2).Caption = "Alamat"
        GridView1.Columns(2).Width = 175
        GridView1.Columns(3).Caption = "Telp"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Penanggung Jawab"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Inisial"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Status Aktif"
        GridView1.Columns(6).Width = 50
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail() Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KODE_SBU,B.NAMA,B.PENANGGUNG_JAWAB FROM LINK_PT_SBU A LEFT JOIN SBU B ON A.KODE_SBU=B.KODE WHERE A.KODE_PT='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Kode SBU"
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nama SBU"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Penanggung Jawab"
                GridView2.Columns(2).Width = 50
            End If
        End If
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "PT"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "PT", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPT.MdiParent = Me.MdiParent
        InputPT.Show()
        InputPT.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPT.MdiParent = Me.MdiParent
                EditPT.Show()
                EditPT.Focus()
                EditPT.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPT
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuGudang
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA_GUDANG,ALAMAT,TELP,PENANGGUNG_JAWAB,STATUS_AKTIF FROM GUDANG ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Gudang ]"
        GridView1.Columns(0).Caption = "Kode Gudang"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama Gudang"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Alamat"
        GridView1.Columns(2).Width = 175
        GridView1.Columns(3).Caption = "Tlp"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Penanggung Jawab"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Status Aktif"
        GridView1.Columns(5).Width = 75
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail() Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KODE_DIVISI,B.NAMA,B.PENANGGUNG_JAWAB FROM LINK_GUDANG_DIVISI A LEFT JOIN DIVISI B ON A.KODE_DIVISI=B.KODE WHERE A.KODE_GUDANG='" & GridView1.GetFocusedRow(0) & "'")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Kode Divisi"
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nama Divisi"
                GridView2.Columns(1).Width = 50
                GridView2.Columns(2).Caption = "Penanggung Jawab"
                GridView2.Columns(2).Width = 50
            End If
        End If
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Gudang"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Gudang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputGudang.MdiParent = Me.MdiParent
        InputGudang.Show()
        InputGudang.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditGudang.MdiParent = Me.MdiParent
                EditGudang.Show()
                EditGudang.Focus()
                EditGudang.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditGudang
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuBarang
    Inherits FrmMenu

    Private Sub GetData() Handles Me.Activated
        TBMenu.DataSource = SelectCon.execute("SELECT A.[ID] ,A.[KODE] ,A.[NAMA], D.NAMA ,A.HARGA_DIST ,A.HARGA_SUPER ,A.SAT_KOLI1, A.QTY_KOLI, A.SAT_DIST1,A.QTY_DIST,A.SAT_SUPER1,A.TGL_PL ,B.[NAMA] ,A.[STATUS_PERSEDIAAN], CASE A.[STATUS_AKTIF] WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END  FROM BARANG A LEFT JOIN GROUP_BARANG B ON A.GROUP_BARANG=B.KODE LEFT JOIN LINK_BARANG_DIVISI C ON A.ID=C.ID_BARANG LEFT JOIN DIVISI D ON C.KODE_DIVISI=D.KODE ORDER BY A.STATUS_AKTIF DESC")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Barang ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "Kode"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Nama"
        GridView1.Columns(2).Width = 150
        GridView1.Columns(3).Caption = "Divisi"
        GridView1.Columns(3).Width = 25
        GridView1.Columns(4).Caption = "Harga Dist."
        GridView1.Columns(4).Width = 50
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(4).DisplayFormat.FormatString = "c2"
        GridView1.Columns(5).Caption = "Harga Spr."
        GridView1.Columns(5).Width = 50
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(5).DisplayFormat.FormatString = "c2"
        GridView1.Columns(6).Caption = "Sat. Koli"
        GridView1.Columns(6).Width = 25
        GridView1.Columns(7).Caption = "Isi"
        GridView1.Columns(7).Width = 25
        GridView1.Columns(8).Caption = "Sat. Dist"
        GridView1.Columns(8).Width = 25
        GridView1.Columns(9).Caption = "Isi"
        GridView1.Columns(9).Width = 25
        GridView1.Columns(10).Caption = "Sat. Spr"
        GridView1.Columns(10).Width = 25
        GridView1.Columns(11).Caption = "Tgl. Price List"
        GridView1.Columns(11).Width = 50
        GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridView1.Columns(11).DisplayFormat.FormatString = "dd/MM/yyyy"
        GridView1.Columns(12).Caption = "Group Barang"
        GridView1.Columns(12).Width = 80
        GridView1.Columns(13).Caption = "Status Persediaan"
        GridView1.Columns(13).Width = 75
        GridView1.Columns(14).Caption = "Status Aktif"
        GridView1.Columns(14).Width = 30
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Barang"
        HakMenu("", "Master", "Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBarang.MdiParent = Me.MdiParent
        InputBarang.Show()
        InputBarang.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBarang.MdiParent = Me.MdiParent
                EditBarang.Show()
                EditBarang.Focus()
                EditBarang.TxtIDBarang.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditBarang
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDBarang.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

'Public Class MenuDiskon
'    Inherits FrmMenu

'    Private Sub GetData()
'        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA,KETERANGAN,STATUS_AKTIF FROM DISKON ORDER BY KODE")
'        TBMenu.Refresh()
'        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Diskon ]"
'        GridView1.Columns(0).Caption = "Kode Diskon"
'        GridView1.Columns(0).Width = 50
'        GridView1.Columns(1).Caption = "Nama Diskon"
'        GridView1.Columns(1).Width = 125
'        GridView1.Columns(2).Caption = "Keterangan"
'        GridView1.Columns(2).Width = 175
'        GridView1.Columns(3).Caption = "Status Aktif"
'        GridView1.Columns(3).Width = 75
'    End Sub


'    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
'        Key = "Diskon"
'        AddHandler Me.Activated, AddressOf GetData
'    End Sub

'    Private Sub Baru() Handles BarButtonBaru.ItemClick
'        InputDiskon.MdiParent = Me.MdiParent
'        InputDiskon.Show()
'        InputDiskon.Focus()
'    End Sub

'    Private Sub Edit() Handles BarButtonEdit.ItemClick
'        If GridView1.RowCount > 0 Then
'            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
'                EditDiskon.MdiParent = Me.MdiParent
'                EditDiskon.Show()
'                EditDiskon.Focus()
'                EditDiskon.TxtKode.Text = GridView1.GetFocusedRow(0)
'            End If
'        End If
'    End Sub
'End Class

Public Class MenuCorporation
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,CASE STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END FROM CORPORATION ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Sentral Bisnis Unit ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 150
        GridView1.Columns(2).Caption = "Alamat"
        GridView1.Columns(2).Width = 175
        GridView1.Columns(3).Caption = "Telp"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Penanggung Jawab"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Status Aktif"
        GridView1.Columns(5).Width = 50
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Corporation"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Corporation", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputCorporation.MdiParent = Me.MdiParent
        InputCorporation.Show()
        InputCorporation.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditCorporation.MdiParent = Me.MdiParent
                EditCorporation.Show()
                EditCorporation.Focus()
                EditCorporation.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditCorporation
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuEkspedisi
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE,NAMA,ALAMAT,TELP,PENANGGUNG_JAWAB,STATUS_AKTIF FROM EKSPEDISI ORDER BY KODE")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Ekspedisi ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama Ekspedisi"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Alamat"
        GridView1.Columns(2).Width = 175
        GridView1.Columns(3).Caption = "Tlp"
        GridView1.Columns(3).Width = 75
        GridView1.Columns(4).Caption = "Penanggung Jawab"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Status Aktif"
        GridView1.Columns(5).Width = 75
    End Sub


    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Ekspedisi"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Master", "Ekspedisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputEkspedisi.MdiParent = Me.MdiParent
        InputEkspedisi.Show()
        InputEkspedisi.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditEkspedisi.MdiParent = Me.MdiParent
                EditEkspedisi.Show()
                EditEkspedisi.Focus()
                EditEkspedisi.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditEkspedisi
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtKode.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub
End Class

Public Class MenuHargaPromo
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,TGL,TGL_AWAL,TGL_AKHIR,C.NAMA, JENIS_PRICE,B.JENIS,A.CUSTOMER,A.BATAL FROM HARGA_PROMO A INNER JOIN DETAIL_HARGA_PROMO B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE WHERE SUBSTRING(PERIODE,3,2)='" & Microsoft.VisualBasic.Right(periode, 2) & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Harga Promo ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal Transaksi"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Berlaku"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Tanggal Berlaku"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 30
        GridView1.Columns(7).Caption = "Jenis"
        GridView1.Columns(7).Width = 50
        GridView1.Columns(8).Caption = "Nama Customer"
        GridView1.Columns(8).Width = 200
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,B.KODE,B.NAMA,A.SATUAN,A.SATUAN1,A.ISI,A.SATUANK,A.SATUANK1,A.HARGA_LAMA,A.HARGA_BARU FROM DETAIL_HARGA_PROMO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
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
        Key = "Harga Promo"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("", "Master", "Price List", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputHargaPromo.MdiParent = Me.MdiParent
        InputHargaPromo.Show()
        InputHargaPromo.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditHargaPromo.MdiParent = Me.MdiParent
                EditHargaPromo.Show()
                EditHargaPromo.Focus()
                EditHargaPromo.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditHargaPromo
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
