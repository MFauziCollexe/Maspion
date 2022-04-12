
Public Class MenuKodePerkiraan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT KODE_PERKIRAAN, NAMA_PERKIRAAN, JENIS, URUTAN, CASE STATUS_AKTIF WHEN 1 THEN 'Aktif' ELSE 'Tidak Aktif' END AS STATUS_AKTIF, KAS_BANK FROM AR_KODE_PERKIRAAN ORDER BY KODE_PERKIRAAN")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kode Perkiraan ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Jenis"
        GridView1.Columns(2).Width = 75
        GridView1.Columns(3).Caption = "Urutan"
        GridView1.Columns(3).Width = 25
        GridView1.Columns(4).Caption = "Status Aktif"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Kas/Bank"
        GridView1.Columns(5).Width = 75
    End Sub


    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kode Perkiraan"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Kode Perkiraan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKodePerkiraan.MdiParent = Me.MdiParent
        InputKodePerkiraan.Show()
        InputKodePerkiraan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKodePerkiraan.MdiParent = Me.MdiParent
                EditKodePerkiraan.Show()
                EditKodePerkiraan.Focus()
                EditKodePerkiraan.TxtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKodePerkiraan
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
Public Class MenuMasterBank
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_BANK,NAMA_BANK,A.KODE_PERKIRAAN,B.NAMA_PERKIRAAN,NO_REKENING,KETERANGAN from AR_MASTER_BANK A INNER JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN = B.KODE_PERKIRAAN")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Master Bank ]"
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Kode Perkiraan"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Nama Perkiraan"
        GridView1.Columns(3).Width = 125
        GridView1.Columns(4).Caption = "No. Rekening"
        GridView1.Columns(4).Width = 100
        GridView1.Columns(5).Caption = "Keterangan"
        GridView1.Columns(5).Width = 100
    End Sub
    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Master Bank"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Master Bank", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputMasterBank.MdiParent = Me.MdiParent
        InputMasterBank.Show()
        InputMasterBank.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditMasterBank.MdiParent = Me.MdiParent
                EditMasterBank.Show()
                EditMasterBank.Focus()
                EditMasterBank.TxtIDBank.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditMasterBank
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDBank.Text = GridView1.GetFocusedRow(0)
                frm.Bar3.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

End Class


Public Class MenuKreditNoteKontan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_TRANSAKSI,NO_TRANSAKSI,TGL,A.KODE_APPROVE,KODE_CUSTOMER,B.NAMA CUSTOMER,JENIS_CNDN,A.NO_NOTA,A.JUMLAH from DEBIT_KREDIT_NOTE A join CUSTOMER B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID where JENIS = 'Kredit' and JENIS_CNDN = 'DO Kontan' and PERIODE = '" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kredit Note Kontan]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Approve"
        GridView1.Columns(3).Width = 125
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 100
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 100
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "No. Nota"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Jumlah"
        GridView1.Columns(8).Width = 100
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
    End Sub
    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kredit Note Kontan"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Kredit Note Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKreditNoteKontan.MdiParent = Me.MdiParent
        InputKreditNoteKontan.Show()
        InputKreditNoteKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKreditNoteKontan.MdiParent = Me.MdiParent
                EditKreditNoteKontan.Show()
                EditKreditNoteKontan.Focus()
                EditKreditNoteKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKreditNoteKontan
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

End Class


Public Class MenuKreditNote
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_TRANSAKSI,NO_TRANSAKSI,TGL,A.KODE_APPROVE,KODE_CUSTOMER,B.NAMA CUSTOMER,JENIS_CNDN,A.NO_NOTA,A.JUMLAH from DEBIT_KREDIT_NOTE A join CUSTOMER B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID where JENIS = 'Kredit'  and JENIS_CNDN <> 'DO Kontan' and PERIODE = '" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kredit Note ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Approve"
        GridView1.Columns(3).Width = 125
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 100
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 100
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "No. Nota"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Jumlah"
        GridView1.Columns(8).Width = 100
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
    End Sub
    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kredit Note"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Kredit Note", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKreditNote.MdiParent = Me.MdiParent
        InputKreditNote.Show()
        InputKreditNote.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKreditNote.MdiParent = Me.MdiParent
                EditKreditNote.Show()
                EditKreditNote.Focus()
                EditKreditNote.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKreditNote
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

End Class

Public Class MenuPengembalianDOKontan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_PENGEMBALIAN,A.NO_DO_KONTAN, A.TGL, C.KODE_APPROVE, C.NAMA, A.JUMLAH_BELUM_DIBAYAR, A.BATAL FROM AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN A LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Pengembalian DO Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Pengembalian"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "No. DO Kontan"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Tanggal"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Kurang / Lebih Bayar"
        GridView1.Columns(6).Width = 30
        GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(6).DisplayFormat.FormatString = "n0"
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KETERANGAN, A.TANGGAL_NOTA, A.NO_NOTA,A.NILAI,a.TOTAL  FROM AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.KETERANGAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Keterangan"
                GridView2.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "Tanggal"
                GridView1.Columns(1).Width = 30
                GridView1.Columns(1).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(1).DisplayFormat.FormatString = "dd-MM-yyyy"
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nilai"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Bukti Pengembalian Uang DO Kontan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Bukti Pengembalian Uang DO Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBuktiPengembalianUangDOKontan.MdiParent = Me.MdiParent
        InputBuktiPengembalianUangDOKontan.Show()
        InputBuktiPengembalianUangDOKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBuktiPengembalianUangDOKontan.MdiParent = Me.MdiParent
                EditBuktiPengembalianUangDOKontan.Show()
                EditBuktiPengembalianUangDOKontan.Focus()
                EditBuktiPengembalianUangDOKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditBuktiPengembalianUangDOKontan
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

Public Class MenuReturPusat
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT distinct A.ID_TRANSAKSI,A.NO_RETUR_PUSAT,A.JENIS_RETUR,A.TGL,B.NAMA,A.ALAMAT_KIRIM,A.NO_NOTA_RETUR,A.KETERANGAN_CETAK,C.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM RETUR_PUSAT A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID and a.KODE_APPROVE = b.KODE_APPROVE LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE PERIODE='" & periode & "' AND D.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Retur Pusat ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Jenis Retur"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Tanggal"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Alamat Kirim"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "No. Retur"
        GridView1.Columns(6).Width = 40
        GridView1.Columns(7).Caption = "Keterangan Cetak"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Pembuat"
        GridView1.Columns(8).Width = 75
        GridView1.Columns(9).Caption = "Total"
        GridView1.Columns(9).Width = 40
        GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(9).DisplayFormat.FormatString = "c2"
        GridView1.Columns(10).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.PCS,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.PCS * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100)/A.KONVERSI,2) AS SUBTOTAL FROM DETAIL_RETUR_PUSAT A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
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
        Key = "Retur Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Retur Pusat", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Retur_Penjualan
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputReturPusat.MdiParent = Me.MdiParent
        InputReturPusat.Show()
        InputReturPusat.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditReturPusat.MdiParent = Me.MdiParent
                EditReturPusat.Show()
                EditReturPusat.Focus()
                EditReturPusat.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditReturPusat
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


Public Class MenuPelunasanRetur
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT distinct PR.ID_TRANSAKSI,PR.NO_PELUNASAN_RETUR,a.NO_RETUR_PUSAT,A.JENIS_RETUR,A.TGL,B.NAMA,A.ALAMAT_KIRIM,A.NO_NOTA_RETUR,A.KETERANGAN_CETAK,C.NAMA_USER,DPP+PPN AS TOTAL,A.BATAL FROM RETUR_PUSAT A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID and a.KODE_APPROVE = b.KODE_APPROVE LEFT JOIN USERS C ON A.CRUSER=C.ID_USER LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI join AR_PELUNASAN_RETUR PR ON PR.ID_RETUR_PUSAT = a.ID_TRANSAKSI WHERE pr.PERIODE='" & periode & "' AND D.ID_USER='" & UserID & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Retur Pusat ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "No. Retur Pusat"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Jenis Retur"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tanggal"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Alamat Kirim"
        GridView1.Columns(6).Width = 150
        GridView1.Columns(7).Caption = "No. Retur"
        GridView1.Columns(7).Width = 40
        GridView1.Columns(8).Caption = "Keterangan Cetak"
        GridView1.Columns(8).Width = 100
        GridView1.Columns(9).Caption = "Pembuat"
        GridView1.Columns(9).Width = 75
        GridView1.Columns(10).Caption = "Total"
        GridView1.Columns(10).Width = 40
        GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(10).DisplayFormat.FormatString = "c2"
        GridView1.Columns(10).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.KOLI,A.QUANTITY,A.PCS,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.PCS * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100)/A.KONVERSI,2) AS SUBTOTAL FROM DETAIL_RETUR_PUSAT A LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI= (select ID_RETUR_PUSAT FROM AR_PELUNASAN_RETUR with(nolock) WHERE ID_TRANSAKSI = '" & GridView1.GetFocusedRow(0) & "') ORDER BY A.URUTAN")
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
        Key = "Pelunasan Retur"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Pelunasan Retur", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        keyPrint = ReportPreview.KeyReport.Retur_Penjualan
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPelunasanRetur.MdiParent = Me.MdiParent
        InputPelunasanRetur.Show()
        InputPelunasanRetur.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPelunasanRetur.MdiParent = Me.MdiParent
                EditPelunasanRetur.Show()
                EditPelunasanRetur.Focus()
                EditPelunasanRetur.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPelunasanRetur
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


Public Class MenuCuttOffDOKontan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_CUTOFF,A.TGL, A.DIVISI,C.NAMA NAMADIVISI, A.BATAL FROM AR_CUTOFF_DO_KONTAN A LEFT JOIN DIVISI C ON A.DIVISI=C.KODE WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Cut Off DO Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Cut Off"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Divisi"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Nama Divisi"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_DO_KONTAN, A.TANGGAL_DO,a.KODE_APPROVE,b.NAMA CUSTOMER,a.dpp,a.PPN,a.TOTAL  FROM AR_CUTOFF_DO_KONTAN_DETAIL A join customer b on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 40
                GridView2.Columns(1).Caption = "No. DO Kontan"
                GridView2.Columns(1).Width = 35
                GridView1.Columns(2).Caption = "Tanggal DO Kontan"
                GridView1.Columns(2).Width = 30
                GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
                GridView2.Columns(3).Caption = "Kode Approve"
                GridView2.Columns(3).Width = 35
                GridView2.Columns(4).Caption = "Customer"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(5).Caption = "DPP"
                GridView2.Columns(5).Width = 50
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "PPN"
                GridView2.Columns(6).Width = 50
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Total"
                GridView2.Columns(7).Width = 50
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Cut Off DO Kontan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Cut Off DO Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        inputcutoffdokontan.MdiParent = Me.MdiParent
        inputcutoffdokontan.Show()
        inputcutoffdokontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                editcutoffdokontan.MdiParent = Me.MdiParent
                editcutoffdokontan.Show()
                editcutoffdokontan.Focus()
                editcutoffdokontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New editcutoffdokontan
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


Public Class MenuValidasiPengembalianDOKontan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.ID_PENGEMBALIAN, A.NO_VALIDASI,A.NO_PENGEMBALIAN, A.TGL, C.KODE_APPROVE, C.NAMA, B.JUMLAH_BELUM_DIBAYAR, A.BATAL FROM AR_VALIDASI_PENGEMBALIAN_DO_KONTAN A LEFT JOIN AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN B ON A.ID_PENGEMBALIAN = B.ID_TRANSAKSI left join CUSTOMER C ON B.KODE_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi Pengembalian DO Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "ID Pengembailan"
        GridView1.Columns(1).Width = 40
        GridView1.Columns(1).Visible = False
        GridView1.Columns(2).Caption = "No. Validasi"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "No. Pengembalian"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tanggal"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Kode Customer"
        GridView1.Columns(5).Width = 50
        GridView1.Columns(6).Caption = "Nama Customer"
        GridView1.Columns(6).Width = 150
        GridView1.Columns(7).Caption = "Kurang / Lebih Bayar"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n0"
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(1)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KETERANGAN, A.TANGGAL_NOTA, A.NO_NOTA,A.NILAI,a.TOTAL  FROM AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(1) & "' ORDER BY A.KETERANGAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Keterangan"
                GridView2.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "Tanggal"
                GridView1.Columns(1).Width = 30
                GridView1.Columns(1).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(1).DisplayFormat.FormatString = "dd-MM-yyyy"
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nilai"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi Bukti Pengembalian Uang DO Kontan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi Bukti Pengembalian Uang DO Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        inputvalidasipengembalian.MdiParent = Me.MdiParent
        inputvalidasipengembalian.Show()
        inputvalidasipengembalian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Editvalidasipengembalian.MdiParent = Me.MdiParent
                Editvalidasipengembalian.Show()
                Editvalidasipengembalian.Focus()
                Editvalidasipengembalian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New Editvalidasipengembalian
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

Public Class MenuKekuranganDOKontan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_KEKURANGAN,A.NO_DO_KONTAN, A.TGL, C.KODE_APPROVE, C.NAMA, A.JUMLAH_KURANG_BAYAR, A.BATAL FROM AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN A LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kekurangan DO Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Kekurangan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "No. DO Kontan"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Tanggal"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Kurang / Lebih Bayar"
        GridView1.Columns(6).Width = 30
        GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(6).DisplayFormat.FormatString = "n0"
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KETERANGAN, A.TANGGAL_NOTA, A.NO_NOTA,A.NILAI,a.TOTAL  FROM AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.KETERANGAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Keterangan"
                GridView2.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "Tanggal"
                GridView1.Columns(1).Width = 30
                GridView1.Columns(1).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(1).DisplayFormat.FormatString = "dd-MM-yyyy"
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nilai"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Bukti Kekurangan Uang DO Kontan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Bukti Kekurangan Uang DO Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBuktiPenerimaanKekuranganDOKontan.MdiParent = Me.MdiParent
        InputBuktiPenerimaanKekuranganDOKontan.Show()
        InputBuktiPenerimaanKekuranganDOKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBuktiPenerimaanKekuranganDOKontan.MdiParent = Me.MdiParent
                EditBuktiPenerimaanKekuranganDOKontan.Show()
                EditBuktiPenerimaanKekuranganDOKontan.Focus()
                EditBuktiPenerimaanKekuranganDOKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditBuktiPenerimaanKekuranganDOKontan
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


Public Class MenuValidasiKekuranganDOKontan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,B.ID_TRANSAKSI ID_KEKURANGAN, A.NO_VALIDASI,A.NO_KEKURANGAN, A.TGL, C.KODE_APPROVE, C.NAMA, B.JUMLAH_KURANG_BAYAR, A.BATAL FROM AR_VALIDASI_KEKURANGAN_DO_KONTAN A left join AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN B ON A.ID_KEKURANGAN = B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON B.KODE_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kekurangan DO Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "ID Kekurangan"
        GridView1.Columns(1).Width = 40
        GridView1.Columns(1).Visible = False
        GridView1.Columns(2).Caption = "No. Pengembalian"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "No. DO Kontan"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tanggal"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Kode Customer"
        GridView1.Columns(5).Width = 50
        GridView1.Columns(6).Caption = "Nama Customer"
        GridView1.Columns(6).Width = 150
        GridView1.Columns(7).Caption = "Kurang Bayar"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n0"
        GridView1.Columns(8).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.KETERANGAN, A.TANGGAL_NOTA, A.NO_NOTA,A.NILAI,a.TOTAL  FROM AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(1) & "' ORDER BY A.KETERANGAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "Keterangan"
                GridView2.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "Tanggal"
                GridView1.Columns(1).Width = 30
                GridView1.Columns(1).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(1).DisplayFormat.FormatString = "dd-MM-yyyy"
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nilai"
                GridView2.Columns(3).Width = 50
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 50
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi Bukti Kekurangan Uang DO Kontan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi Bukti Kekurangan Uang DO Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputValidasiPenerimaanKekuranganDOKontan.MdiParent = Me.MdiParent
        InputValidasiPenerimaanKekuranganDOKontan.Show()
        InputValidasiPenerimaanKekuranganDOKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditValidasiPenerimaanKekuranganDOKontan.MdiParent = Me.MdiParent
                EditValidasiPenerimaanKekuranganDOKontan.Show()
                EditValidasiPenerimaanKekuranganDOKontan.Focus()
                EditValidasiPenerimaanKekuranganDOKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditValidasiPenerimaanKekuranganDOKontan
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

Public Class MenuDebitNote
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_TRANSAKSI,NO_TRANSAKSI,TGL,A.KODE_APPROVE,KODE_CUSTOMER,B.NAMA CUSTOMER,JENIS_CNDN,A.NO_NOTA,A.JUMLAH from DEBIT_KREDIT_NOTE A join CUSTOMER B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID where JENIS = 'Debit' and JENIS_CNDN <> 'DO Kontan' and PERIODE = '" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Debit Note ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Approve"
        GridView1.Columns(3).Width = 125
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 100
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 100
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "No. Nota"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Jumlah"
        GridView1.Columns(8).Width = 100
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
    End Sub
    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Debit Note"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Debit Note", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDebitNote.MdiParent = Me.MdiParent
        InputDebitNote.Show()
        InputDebitNote.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDebitNote.MdiParent = Me.MdiParent
                EditDebitNote.Show()
                EditDebitNote.Focus()
                EditDebitNote.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditDebitNote
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

End Class

Public Class MenuDebitNoteKontan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_TRANSAKSI,NO_TRANSAKSI,TGL,A.KODE_APPROVE,KODE_CUSTOMER,B.NAMA CUSTOMER,JENIS_CNDN,A.NO_NOTA,A.JUMLAH from DEBIT_KREDIT_NOTE A join CUSTOMER B on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID where JENIS = 'Debit' and JENIS_CNDN = 'DO Kontan' and PERIODE = '" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Debit Note Kontan]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 125
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 50
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Approve"
        GridView1.Columns(3).Width = 125
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 100
        GridView1.Columns(5).Caption = "Nama Customer"
        GridView1.Columns(5).Width = 100
        GridView1.Columns(6).Caption = "Jenis"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "No. Nota"
        GridView1.Columns(7).Width = 100
        GridView1.Columns(8).Caption = "Jumlah"
        GridView1.Columns(8).Width = 100
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n2"
    End Sub
    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Debit Note Kontan"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Debit Note Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDebitNoteKontan.MdiParent = Me.MdiParent
        InputDebitNoteKontan.Show()
        InputDebitNoteKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDebitNoteKontan.MdiParent = Me.MdiParent
                EditDebitNoteKontan.Show()
                EditDebitNoteKontan.Focus()
                EditDebitNoteKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditDebitNoteKontan
                frm.MdiParent = Me.MdiParent
                frm.Show()
                frm.Focus()
                frm.Text = Replace(frm.Text, "Edit", "Lihat")
                frm.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
                frm.Toolbar1.Visible = False
                frm._Toolbar1_Button1.Enabled = False
            End If
        End If
    End Sub

End Class


Public Class MenuKodeBatasan
        Inherits FrmMenu

        Private Sub GetData()
            TBMenu.DataSource = SelectCon.execute("select ID,KODE_BATASAN,KETERANGAN from AR_KODE_BATASAN")
            TBMenu.Refresh()
            Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kode Batasan ]"
            GridView1.Columns(0).Caption = "ID"
            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Caption = "Kode Batasan"
            GridView1.Columns(1).Width = 125
            GridView1.Columns(2).Caption = "Keterangan"
            GridView1.Columns(2).Width = 100
        End Sub

        Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            Key = "Kode Batasan"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Kode Batasan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Master", "Divisi", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

        Private Sub Baru() Handles BarButtonBaru.ItemClick
            InputKodeBatasan.MdiParent = Me.MdiParent
            InputKodeBatasan.Show()
            InputKodeBatasan.Focus()
        End Sub

        Private Sub Edit() Handles BarButtonEdit.ItemClick
            If GridView1.RowCount > 0 Then
                If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                    EditKodeBatasan.MdiParent = Me.MdiParent
                    EditKodeBatasan.Show()
                    EditKodeBatasan.Focus()
                    EditKodeBatasan.TxtIDBank.Text = GridView1.GetFocusedRow(0)
                End If
            End If
        End Sub

        Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
            If GridView1.RowCount > 0 Then
                If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                    Dim frm As New EditKodeBatasan
                    frm.MdiParent = Me.MdiParent
                    frm.Show()
                    frm.Focus()
                    frm.Text = Replace(frm.Text, "Edit", "Lihat")
                    frm.TxtIDBank.Text = GridView1.GetFocusedRow(0)
                    frm.Bar3.Visible = False
                    frm._Toolbar1_Button1.Enabled = False
                End If
            End If
        End Sub
    End Class

    Public Class MenuCreateDSRPrw
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Perwakilan' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data DSR ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. DSR"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. DSR"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Daily Sales Report Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Daily Sales Report Perwakilan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputCreateDSRPrw.MdiParent = Me.MdiParent
        InputCreateDSRPrw.Show()
        InputCreateDSRPrw.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditCreateDSRPrw.MdiParent = Me.MdiParent
                EditCreateDSRPrw.Show()
                EditCreateDSRPrw.Focus()
                EditCreateDSRPrw.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditCreateDSRPrw
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

Public Class MenuCreateDSRPembelian
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR_PEMBELIAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Lap. Pembelian]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. DSR"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. DSR"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA  FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Nilai Nota"
                GridView2.Columns(3).Width = 35
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Diskon"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Klaim Bersih"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Terima"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Laporan Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Laporan Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick

        InputCreateDSRPembelian.MdiParent = Me.MdiParent
        InputCreateDSRPembelian.Show()
        InputCreateDSRPembelian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditCreateDSRPembelian.MdiParent = Me.MdiParent
                EditCreateDSRPembelian.Show()
                EditCreateDSRPembelian.Focus()
                EditCreateDSRPembelian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditCreateDSRPembelian
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

Public Class MenuCreateLaporanReturPenjualan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_PENJUALAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Lap. Retur Penjualan]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Lap"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Lap"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB,  B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota Retur"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Laporan Retur Penjualan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Laporan Retur Penjualan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        createlaporanreturpenjualan.MdiParent = Me.MdiParent
        createlaporanreturpenjualan.Show()
        createlaporanreturpenjualan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Editlaporanreturpenjualan.MdiParent = Me.MdiParent
                Editlaporanreturpenjualan.Show()
                Editlaporanreturpenjualan.Focus()
                Editlaporanreturpenjualan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New Editlaporanreturpenjualan
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


Public Class MenuCreateLaporanReturPembelian
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_Pembelian A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Lap. Retur Pembelian]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Lap"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Lap"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB,  B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_Pembelian_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota Retur"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Laporan Retur Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Laporan Retur Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        createlaporanreturpembelian.MdiParent = Me.MdiParent
        createlaporanreturpembelian.Show()
        createlaporanreturpembelian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Editlaporanreturpembelian.MdiParent = Me.MdiParent
                Editlaporanreturpembelian.Show()
                Editlaporanreturpembelian.Focus()
                Editlaporanreturpembelian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New Editlaporanreturpembelian
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

Public Class MenuCreateDSRPus
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Pusat' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data DSR ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. DSR"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. DSR"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Divisi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Gudang"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Daily Sales Report Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Daily Sales Report Pusat", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputCreateDSRPus.MdiParent = Me.MdiParent
        InputCreateDSRPus.Show()
        InputCreateDSRPus.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditCreateDSRPus.MdiParent = Me.MdiParent
                EditCreateDSRPus.Show()
                EditCreateDSRPus.Focus()
                EditCreateDSRPus.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditCreateDSRPus
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

Public Class MenuValidasiDSRPrw
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_VALIDASI,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_VALIDASI_DSR AA JOIN AR_DSR A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Perwakilan' AND AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Validasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. DSR"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. DSR"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR WHERE ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi DSR Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi DSR Perwakilan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputValidasiDSRPrw.MdiParent = Me.MdiParent
        InputValidasiDSRPrw.Show()
        InputValidasiDSRPrw.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditValidasiDSRPrw.MdiParent = Me.MdiParent
                EditValidasiDSRPrw.Show()
                EditValidasiDSRPrw.Focus()
                EditValidasiDSRPrw.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditValidasiDSRPrw
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


Public Class MenuValidasiDSRPB
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_VALIDASI,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_VALIDASI_DSR_PEMBELIAN AA JOIN AR_DSR_PEMBELIAN A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi Lap. Pembelian ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Validasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Pembelian"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Pembelian"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35

                GridView2.Columns(2).Caption = "Nama"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Nilai Nota"
                GridView2.Columns(3).Width = 35
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Diskon"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Klaim Bersih"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Terima"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi Lap. Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi Laporan Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputValidasiDSRPembelian.MdiParent = Me.MdiParent
        InputValidasiDSRPembelian.Show()
        InputValidasiDSRPembelian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                editValidasiDSRPembelian.MdiParent = Me.MdiParent
                editValidasiDSRPembelian.Show()
                editValidasiDSRPembelian.Focus()
                editValidasiDSRPembelian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New editValidasiDSRPembelian
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
Public Class MenuValidasiLapReturPenjualan
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_VALIDASI,AA.TGL, AA.NO_LAP, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_VALIDASI_LAP_RETUR_PENJUALAN AA JOIN AR_LAP_RETUR_PENJUALAN A ON AA.ID_LAP=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi Lap. Retur Penjualan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Validasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Retur Penjualan"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Retur Penjualan"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB,  B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.NO_LAP='" & GridView1.GetFocusedDataRow(3) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota Retur"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi Lap. Retur Penjualan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi Laporan Retur Penjualan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputValidasiLapReturPenjualan.MdiParent = Me.MdiParent
        InputValidasiLapReturPenjualan.Show()
        InputValidasiLapReturPenjualan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                editValidasiLapReturPenjualan.MdiParent = Me.MdiParent
                editValidasiLapReturPenjualan.Show()
                editValidasiLapReturPenjualan.Focus()
                editValidasiLapReturPenjualan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New editValidasiLapReturPenjualan
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

Public Class MenuValidasiLapReturPembelian
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_VALIDASI,AA.TGL, AA.NO_LAP, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN AA JOIN AR_LAP_RETUR_PEMBELIAN A ON AA.ID_LAP=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi Lap. Retur Pembelian ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Validasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Retur Pembelian"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Retur Pembelian"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB,  B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.NO_LAP='" & GridView1.GetFocusedDataRow(3) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota Retur"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi Lap. Retur Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi Laporan Retur Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        inputvalidasiLapReturPembelian.MdiParent = Me.MdiParent
        inputvalidasiLapReturPembelian.Show()
        inputvalidasiLapReturPembelian.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                editvalidasiReturPembelian.MdiParent = Me.MdiParent
                editvalidasiReturPembelian.Show()
                editvalidasiReturPembelian.Focus()
                editvalidasiReturPembelian.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New editvalidasiReturPembelian
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


Public Class MenuValidasiDSRPus
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_VALIDASI,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_VALIDASI_DSR AA JOIN AR_DSR A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Pusat' AND AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Validasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. DSR"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. DSR"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR WHERE ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Validasi DSR Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Validasi DSR Pusat", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputValidasiDSRPus.MdiParent = Me.MdiParent
        InputValidasiDSRPus.Show()
        InputValidasiDSRPus.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditValidasiDSRPus.MdiParent = Me.MdiParent
                EditValidasiDSRPus.Show()
                EditValidasiDSRPus.Focus()
                EditValidasiDSRPus.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditValidasiDSRPus
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

Public Class MenuProsesJurnalPrw
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_PROSES,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_PROSES_JURNAL AA JOIN AR_DSR A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Perwakilan' AND AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Proses"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. DSR"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. DSR"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR WHERE NO_DSR='" & GridView1.GetFocusedRow(3) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Proses Jurnal Perwakilan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Proses Jurnal Perwakilan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputProsesJurnalPrw.MdiParent = Me.MdiParent
        InputProsesJurnalPrw.Show()
        InputProsesJurnalPrw.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditProsesJurnalPrw.MdiParent = Me.MdiParent
                EditProsesJurnalPrw.Show()
                EditProsesJurnalPrw.Focus()
                EditProsesJurnalPrw.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditProsesJurnalPrw
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
Public Class MenuProsesJurnalPB
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_PROSES,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_PROSES_JURNAL AA JOIN AR_DSR_PEMBELIAN A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Proses"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Pembelian"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Pembelian"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,  B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN WHERE NO_DSR='" & GridView1.GetFocusedRow(3) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama"
                GridView2.Columns(2).Width = 150
                GridView2.Columns(3).Caption = "Nilai Nota"
                GridView2.Columns(3).Width = 35
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
                GridView2.Columns(4).Caption = "Diskon"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Klaim Bersih"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Terima"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Proses Jurnal Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Proses Jurnal Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        inputprosesjurnalpb.MdiParent = Me.MdiParent
        inputprosesjurnalpb.Show()
        inputprosesjurnalpb.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditProsesJurnalPb.MdiParent = Me.MdiParent
                EditProsesJurnalPb.Show()
                EditProsesJurnalPb.Focus()
                EditProsesJurnalPb.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditProsesJurnalPb
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



Public Class MenuProsesJurnalRJ
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_PROSES,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_PROSES_JURNAL AA JOIN AR_LAP_RETUR_PENJUALAN A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Proses"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Retur Penjualan"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Retur Penjualan"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_LAP FROM AR_VALIDASI_LAP_RETUR_PENJUALAN WHERE NO_LAP='" & GridView1.GetFocusedRow(3) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Proses Jurnal Retur Penjualan"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Proses Jurnal Retur Penjualan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputProsesJurnalReturJual.MdiParent = Me.MdiParent
        InputProsesJurnalReturJual.Show()
        InputProsesJurnalReturJual.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditProsesJurnalReturJual.MdiParent = Me.MdiParent
                EditProsesJurnalReturJual.Show()
                EditProsesJurnalReturJual.Focus()
                EditProsesJurnalReturJual.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditProsesJurnalReturJual
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


Public Class MenuProsesJurnalRB
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_PROSES,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_PROSES_JURNAL AA JOIN AR_LAP_RETUR_PEMBELIAN A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE   AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Proses"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Lap. Retur Pembelian"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. Lap. Retur Pembelian"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_LAP FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN WHERE NO_LAP='" & GridView1.GetFocusedRow(3) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. TTB"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nilai Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Nilai Diskon"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Nilai Netto"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Proses Jurnal Retur Pembelian"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Proses Jurnal Retur Pembelian", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        inputprosesjurnalreturbeli.MdiParent = Me.MdiParent
        inputprosesjurnalreturbeli.Show()
        inputprosesjurnalreturbeli.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                editprosesjurnalreturbeli.MdiParent = Me.MdiParent
                editprosesjurnalreturbeli.Show()
                editprosesjurnalreturbeli.Focus()
                editprosesjurnalreturbeli.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New editprosesjurnalreturbeli
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


Public Class MenuProsesJurnalPus
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT AA.ID_TRANSAKSI, AA.NO_PROSES,AA.TGL, AA.NO_DSR, A.TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG, AA.BATAL FROM AR_PROSES_JURNAL AA JOIN AR_DSR A ON AA.ID_DSR=A.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE A.JENIS='Pusat' AND AA.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Validasi ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Proses"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. DSR"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Tgl. DSR"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(4).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(5).Caption = "Divisi"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Gudang"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI=(SELECT TOP 1 ID_DSR FROM AR_VALIDASI_DSR WHERE NO_DSR='" & GridView1.GetFocusedRow(3) & "') ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Nama"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Proses Jurnal Pusat"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Proses Jurnal Pusat", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputProsesJurnalPus.MdiParent = Me.MdiParent
        InputProsesJurnalPus.Show()
        InputProsesJurnalPus.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditProsesJurnalPus.MdiParent = Me.MdiParent
                EditProsesJurnalPus.Show()
                EditProsesJurnalPus.Focus()
                EditProsesJurnalPus.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditProsesJurnalPus
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

Public Class MenuTandaTerima
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_TT, A.TGL_PENGAKUAN, C.KODE_APPROVE, C.NAMA, A.TOTAL, A.BATAL FROM AR_TANDA_TERIMA A LEFT JOIN CUSTOMER C ON A.ID_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Tanda Terima ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Tanda Terima"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Pengakuan"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Customer"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "Total"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(5).DisplayFormat.FormatString = "n0"
        GridView1.Columns(6).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, A.NO_DSR, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_TANDA_TERIMA_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "No. DSR"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Tanda Terima"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Tanda Terima", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputTandaTerima.MdiParent = Me.MdiParent
        InputTandaTerima.Show()
        InputTandaTerima.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditTandaTerima.MdiParent = Me.MdiParent
                EditTandaTerima.Show()
                EditTandaTerima.Focus()
                EditTandaTerima.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditTandaTerima
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




Public Class MenuSetoranPerPT
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_SETORAN, A.TGL_PENGAKUAN, C.KODE_APPROVE, C.NAMA,D.NAMA as NAMA_PT,case when a.STATUS_GIRO = 1 then 'Giro' when a.STATUS_TRANSFER = 1 then 'Transfer' when a.STATUS_TUNAI = 1 then 'Tunai' end as METODE, A.TOTAL,A.TOTAL_SETORAN, A.BATAL FROM AR_SETORAN_PER_PT A LEFT JOIN CUSTOMER C ON A.ID_CUSTOMER=C.ID left join PT D ON D.KODE = A.KODE_PT WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Setoran Per PT. ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Setoran Per PT"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Pengakuan"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Customer"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 80
        GridView1.Columns(5).Caption = "Nama PT"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Metode Pembayaran"
        GridView1.Columns(6).Width = 100
        GridView1.Columns(7).Caption = "Total"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n0"
        GridView1.Columns(8).Caption = "Total Setoran"
        GridView1.Columns(8).Width = 30
        GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(8).DisplayFormat.FormatString = "n0"
        GridView1.Columns(9).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, A.NO_DSR, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_SETORAN_PER_PT_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "No. DSR"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Bruto"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Std. Disc"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Add. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Cash Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Netto"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Setoran Per PT"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputSetoranPerPT.MdiParent = Me.MdiParent
        InputSetoranPerPT.Show()
        InputSetoranPerPT.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditSetoranPerPT.MdiParent = Me.MdiParent
                EditSetoranPerPT.Show()
                EditSetoranPerPT.Focus()
                EditSetoranPerPT.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditSetoranPerPT
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
Public Class MenuPenyerahanNota
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_PENYERAHAN, A.TGL, C.NAMA_USER HEAD_COLLECTOR, D.NAMA_USER COLLECTOR, A.BATAL 
        FROM AR_PENYERAHAN_NOTA A LEFT JOIN USERS C ON A.HEAD_COLLECTOR=C.ID_USER LEFT JOIN USERS D ON A.COLLECTOR=D.ID_USER WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Penyerahan Nota ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Penyerahan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Head Collector"
        GridView1.Columns(3).Width = 150
        GridView1.Columns(4).Caption = "Collector"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.URUTAN, B.NO_NOTA, B.NO_DO, B.NO_DSR, C.NO_VALIDASI, B.BRUTO, B.STD_DISC, B.ADD_DISC, B.CASH_DISC, B.NETTO 
                FROM AR_PENYERAHAN_NOTA_DETAIL A JOIN AR_DSR_DETAIL B ON A.ID_NOTA=B.ID_NOTA JOIN AR_VALIDASI_DSR C ON C.ID_DSR=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "No. DSR"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "No. Validasi DSR"
                GridView2.Columns(4).Width = 150
                GridView2.Columns(5).Caption = "Bruto"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Std. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Add. Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Cash Disc"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
                GridView2.Columns(9).Caption = "Netto"
                GridView2.Columns(9).Width = 35
                GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(9).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Penyerahan Nota"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPenyerahanNota.MdiParent = Me.MdiParent
        InputPenyerahanNota.Show()
        InputPenyerahanNota.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPenyerahanNota.MdiParent = Me.MdiParent
                EditPenyerahanNota.Show()
                EditPenyerahanNota.Focus()
                EditPenyerahanNota.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPenyerahanNota
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

Public Class MenuPengembalianNota
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_PENGEMBALIAN, A.TGL, D.NAMA_USER COLLECTOR, A.BATAL 
        FROM AR_PENGEMBALIAN_NOTA A LEFT JOIN USERS D ON A.COLLECTOR=D.ID_USER WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Pengembalian Nota ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Pengembalian"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Collector"
        GridView1.Columns(3).Width = 150
        GridView1.Columns(4).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT DISTINCT A.URUTAN, B.NO_NOTA, B.NO_DO, B.NO_DSR, C.NO_VALIDASI, B.BRUTO, B.STD_DISC, B.ADD_DISC, B.CASH_DISC, B.NETTO 
                FROM AR_PENGEMBALIAN_NOTA_DETAIL A JOIN AR_DSR_DETAIL B ON A.ID_NOTA=B.ID_NOTA JOIN AR_VALIDASI_DSR C ON C.ID_DSR=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "DO"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "No. DSR"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "No. Validasi DSR"
                GridView2.Columns(4).Width = 150
                GridView2.Columns(5).Caption = "Bruto"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
                GridView2.Columns(6).Caption = "Std. Disc"
                GridView2.Columns(6).Width = 35
                GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(6).DisplayFormat.FormatString = "n2"
                GridView2.Columns(7).Caption = "Add. Disc"
                GridView2.Columns(7).Width = 35
                GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                GridView2.Columns(8).Caption = "Cash Disc"
                GridView2.Columns(8).Width = 35
                GridView2.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(8).DisplayFormat.FormatString = "n2"
                GridView2.Columns(9).Caption = "Netto"
                GridView2.Columns(9).Width = 35
                GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(9).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Pengembalian Nota"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPengembalianNota.MdiParent = Me.MdiParent
        InputPengembalianNota.Show()
        InputPengembalianNota.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPengembalianNota.MdiParent = Me.MdiParent
                EditPengembalianNota.Show()
                EditPengembalianNota.Focus()
                EditPengembalianNota.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPengembalianNota
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


Public Class MenuPermintaanDibuatkanFakturPajak
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_PERMOHONAN, A.TGL, B.NAMA, A.BATAL 
        FROM AR_PERMOHONAN_FAKTUR A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Permintaan Faktur Pajak ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Permintaan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Customer"
        GridView1.Columns(3).Width = 150
        GridView1.Columns(4).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, dbo.GetNoPO(B.KETERANGAN_CETAK), B.NO_NOTA, B.TGL_PENGAKUAN, B.DPP+B.PPN TOTAL FROM AR_PERMOHONAN_FAKTUR_DETAIL A JOIN NOTA B ON A.ID_NOTA=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "No. PO"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Tgl. Pengakuan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView2.Columns(3).DisplayFormat.FormatString = "dd/MM/yyyy"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 150
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Permintaan Dibuatkan Faktur Pajak"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPermintaanDibuatkanFakturPajak.MdiParent = Me.MdiParent
        InputPermintaanDibuatkanFakturPajak.Show()
        InputPermintaanDibuatkanFakturPajak.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPermintaanDibuatkanFakturPajak.MdiParent = Me.MdiParent
                EditPermintaanDibuatkanFakturPajak.Show()
                EditPermintaanDibuatkanFakturPajak.Focus()
                EditPermintaanDibuatkanFakturPajak.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPermintaanDibuatkanFakturPajak
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


Public Class MenuKonfirmasiDibuatkanFakturPajak
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_KONFIRMASI, A.TGL, A.NO_PERMOHONAN, B.NAMA, A.BATAL 
        FROM AR_KONFIRMASI_FAKTUR A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Konfirmasi Faktur Pajak ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Konfirmasi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "No. Permintaan"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Customer"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, dbo.GetNoPO(B.KETERANGAN_CETAK), B.NO_NOTA, B.TGL_PENGAKUAN, B.DPP+B.PPN TOTAL, A.NO_SERI FROM AR_KONFIRMASI_FAKTUR_DETAIL A JOIN NOTA B ON A.ID_NOTA=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "No. PO"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "No. Nota"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Tgl. Pengakuan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView2.Columns(3).DisplayFormat.FormatString = "dd/MM/yyyy"
                GridView2.Columns(4).Caption = "Total"
                GridView2.Columns(4).Width = 150
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "No. Seri"
                GridView2.Columns(5).Width = 35
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Konfirmasi Dibuatkan Faktur Pajak"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKonfirmasiDibuatkanFakturPajak.MdiParent = Me.MdiParent
        InputKonfirmasiDibuatkanFakturPajak.Show()
        InputKonfirmasiDibuatkanFakturPajak.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKonfirmasiDibuatkanFakturPajak.MdiParent = Me.MdiParent
                EditKonfirmasiDibuatkanFakturPajak.Show()
                EditKonfirmasiDibuatkanFakturPajak.Focus()
                EditKonfirmasiDibuatkanFakturPajak.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKonfirmasiDibuatkanFakturPajak
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

Public Class MenuUangTitipan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_UT, A.TGL, B.KODE_APPROVE, B.NAMA,case when STATUS_TRANSFER = 1 then 'Transfer' when STATUS_TUNAI = 1 and STATUS_GIRO = 0 then 'Tunai' when STATUS_GIRO = 1 and STATUS_TUNAI = 0 then 'Giro' when STATUS_GIRO = 1 and STATUS_TUNAI = 1 then 'Giro dan Tunai' when STATUS_CUSTOM = 1 then 'Custom' end as Metode, iif(STATUS_CUSTOM = 1,DEBET_NILAI,A.NOMINAL_PERWAKILAN) NOMINAL_PERWAKILAN,A.NOMINAL_PUSAT,  A.BATAL FROM AR_UANG_TITIPAN A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Uang Titipan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Uang Titipan"
        GridView1.Columns(1).Width = 50
        'GridView1.Columns(2).Caption = "No. Tanda Terima"
        'GridView1.Columns(2).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Kode Customer"
        GridView1.Columns(3).Width = 50
        GridView1.Columns(4).Caption = "Customer"
        GridView1.Columns(4).Width = 150
        GridView1.Columns(5).Caption = "Metode Pembayaran"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Nominal Perwakilan"
        GridView1.Columns(6).Width = 30
        GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(6).DisplayFormat.FormatString = "n2"
        GridView1.Columns(7).Caption = "Nominal Pusat"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n2"
        'GridView1.Columns(7).Caption = "Metode"
        'GridView1.Columns(7).Width = 30
        GridView1.Columns(8).Visible = False
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Uang Titipan"
        AddHandler Activated, AddressOf GetData
        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputUangTitipan.MdiParent = Me.MdiParent
        InputUangTitipan.Show()
        InputUangTitipan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditUangTitipan.MdiParent = Me.MdiParent
                EditUangTitipan.Show()
                EditUangTitipan.Focus()
                EditUangTitipan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditUangTitipan
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

Public Class MenuRincianPembayaran
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_RINCIAN_PEMBAYARAN, A.TGL_PENGAKUAN, C.NAMA, A.BATAL FROM AR_RINCIAN_PEMBAYARAN A LEFT JOIN CUSTOMER C ON A.ID_CUSTOMER=C.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Rincian Pembayaran ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Rincian Pembayaran"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Pengakuan"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Nama Customer"
        GridView1.Columns(3).Width = 150
        'GridView1.Columns(4).Caption = "Total"
        'GridView1.Columns(4).Width = 30
        'GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'GridView1.Columns(4).DisplayFormat.FormatString = "n0"
        GridView1.Columns(4).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.NO_NOTA, A.DEBET, A.KREDIT FROM AR_RINCIAN_PEMBAYARAN_DETAIL1 A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Nota"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Debet"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(2).DisplayFormat.FormatString = "n2"
                GridView2.Columns(3).Caption = "Kredit"
                GridView2.Columns(3).Width = 35
                GridView2.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(3).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuRincianPembayaran_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Rincian Pembayaran"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Rincian Pembayaran", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputRincianPembayaran.MdiParent = Me.MdiParent
        InputRincianPembayaran.Show()
        InputRincianPembayaran.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditRincianPembayaran.MdiParent = Me.MdiParent
                EditRincianPembayaran.Show()
                EditRincianPembayaran.Focus()
                EditRincianPembayaran.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditRincianPembayaran
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

Public Class MenuPembayaranKontan
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_PEMBAYARAN,A.NO_DO_KONTAN, A.TGL, B.KODE_APPROVE, B.NAMA,case when STATUS_TRANSFER = 1 then 'Transfer' when STATUS_TUNAI = 1 and STATUS_GIRO = 0 then 'Tunai' when STATUS_GIRO = 1 and STATUS_TUNAI = 0 then 'Giro' when STATUS_GIRO = 1 and STATUS_TUNAI = 1 then 'Giro dan Tunai'end as Metode, TOTAL,  A.BATAL FROM AR_PEMBAYARAN_KONTAN A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Pembayaran Kontan ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Pembayaran Kontan"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "No. DO Kontan"
        GridView1.Columns(2).Width = 50
        'GridView1.Columns(2).Caption = "No. Tanda Terima"
        'GridView1.Columns(2).Width = 50
        GridView1.Columns(3).Caption = "Tanggal"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Kode Customer"
        GridView1.Columns(4).Width = 50
        GridView1.Columns(5).Caption = "Customer"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Metode Pembayaran"
        GridView1.Columns(6).Width = 150
        GridView1.Columns(7).Caption = "Total"
        GridView1.Columns(7).Width = 30
        GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(7).DisplayFormat.FormatString = "n2"

        'GridView1.Columns(7).Caption = "Metode"
        'GridView1.Columns(7).Width = 30
        GridView1.Columns(8).Visible = False
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Pembayaran Kontan"
        AddHandler Activated, AddressOf GetData
        HakMenu("Sistem AR", "Sistem AR", "Pembayaran Kontan", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputPembayaranKontan.MdiParent = Me.MdiParent
        InputPembayaranKontan.Show()
        InputPembayaranKontan.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditPembayaranKontan.MdiParent = Me.MdiParent
                EditPembayaranKontan.Show()
                EditPembayaranKontan.Focus()
                EditPembayaranKontan.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditPembayaranKontan
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


#Region "Akuntansi"
Public Class MenuJurnal
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT ID_JURNAL, NO_JURNAL, TGL, TGL_PENGAKUAN, LINK_TRANSAKSI, LINK_KASBANK, KETERANGAN_INTERNAL, BATAL FROM AR_JURNAL WHERE PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Jurnal ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Jurnal"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Link Transaksi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Link Kas/Bank"
        GridView1.Columns(5).Width = 30
        GridView1.Columns(6).Caption = "Keterangan Internal"
        GridView1.Columns(6).Width = 40
        GridView1.Columns(7).Caption = "Batal"
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.DEBET, A.KREDIT FROM AR_JURNAL_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_JURNAL='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Perkiraan"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama Perkiraan"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Keterangan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Debet"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
                GridView2.Columns(5).Caption = "Kredit"
                GridView2.Columns(5).Width = 35
                GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(5).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Jurnal"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Jurnal", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputJurnal.MdiParent = Me.MdiParent
        InputJurnal.Show()
        InputJurnal.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditJurnal.MdiParent = Me.MdiParent
                EditJurnal.Show()
                EditJurnal.Focus()
                EditJurnal.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditJurnal
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


Public Class MenuKasMasuk
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_KAS, A.TGL, A.TGL_PENGAKUAN, A.LINK_TRANSAKSI, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.BATAL FROM AR_KAS A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.JENIS='KM' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kas Keluar ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Bukti"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Link Transaksi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Kode Perkiraan"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Nama Perkiraan"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.NOMINAL FROM AR_KAS_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Perkiraan"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama Perkiraan"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Keterangan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nominal"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kas Masuk"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Kas Masuk", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKasMasuk.MdiParent = Me.MdiParent
        InputKasMasuk.Show()
        InputKasMasuk.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKasMasuk.MdiParent = Me.MdiParent
                EditKasMasuk.Show()
                EditKasMasuk.Focus()
                EditKasMasuk.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKasMasuk
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

Public Class MenuKasKeluar
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_KAS, A.TGL, A.TGL_PENGAKUAN, A.LINK_TRANSAKSI, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.BATAL FROM AR_KAS A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.JENIS='KK' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kas Keluar ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Bukti"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Link Transaksi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Kode Perkiraan"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Nama Perkiraan"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.NOMINAL FROM AR_KAS_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Perkiraan"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama Perkiraan"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Keterangan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nominal"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kas Keluar"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Kas Keluar", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKasKeluar.MdiParent = Me.MdiParent
        InputKasKeluar.Show()
        InputKasKeluar.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKasKeluar.MdiParent = Me.MdiParent
                EditKasKeluar.Show()
                EditKasKeluar.Focus()
                EditKasKeluar.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditKasKeluar
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


Public Class MenuBankMasuk
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_BANK, A.TGL, A.TGL_PENGAKUAN, A.LINK_TRANSAKSI, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.BATAL FROM AR_BANK A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.JENIS='BM' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Bank Masuk ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Bukti"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Link Transaksi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Kode Perkiraan"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Nama Perkiraan"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.NOMINAL FROM AR_BANK_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Perkiraan"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama Perkiraan"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Keterangan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nominal"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Bank Masuk"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Bank Masuk", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBankMasuk.MdiParent = Me.MdiParent
        InputBankMasuk.Show()
        InputBankMasuk.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBankMasuk.MdiParent = Me.MdiParent
                EditBankMasuk.Show()
                EditBankMasuk.Focus()
                EditBankMasuk.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditBankMasuk
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

Public Class MenuBankKeluar
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_BANK, A.TGL, A.TGL_PENGAKUAN, A.LINK_TRANSAKSI, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.BATAL FROM AR_BANK A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.JENIS='BK' AND A.PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Bank Keluar ]"
        GridView1.Columns(0).Caption = "ID"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(0).Visible = False
        GridView1.Columns(1).Caption = "No. Bukti"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tgl. Dibuat"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tgl. Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Link Transaksi"
        GridView1.Columns(4).Width = 30
        GridView1.Columns(5).Caption = "Kode Perkiraan"
        GridView1.Columns(5).Width = 75
        GridView1.Columns(6).Caption = "Nama Perkiraan"
        GridView1.Columns(6).Width = 75
        GridView1.Columns(7).Visible = False
        GetDataDetail()
    End Sub

    Private Sub GetDataDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                TBMenuDetailMenu.DataSource = SelectCon.execute("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.NOMINAL FROM AR_BANK_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                TBMenuDetailMenu.Refresh()
                GridView2.Columns(0).Caption = "No."
                GridView2.Columns(0).Width = 15
                GridView2.Columns(1).Caption = "Kode Perkiraan"
                GridView2.Columns(1).Width = 35
                GridView2.Columns(2).Caption = "Nama Perkiraan"
                GridView2.Columns(2).Width = 35
                GridView2.Columns(3).Caption = "Keterangan"
                GridView2.Columns(3).Width = 150
                GridView2.Columns(4).Caption = "Nominal"
                GridView2.Columns(4).Width = 35
                GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns(4).DisplayFormat.FormatString = "n2"
            End If
        End If
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Bank Keluar"
        AddHandler Activated, AddressOf GetData
        AddHandler GridView1.FocusedRowChanged, AddressOf GetDataDetail
        HakMenu("Sistem AR", "Sistem AR", "Bank Keluar", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)

        'HakMenu("", "Retur", "Tanda Terima Barang", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
        'BtnCetakBeberapa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'keyPrint = ReportPreview.KeyReport.TTB
    End Sub

    Private Sub Cetak() Handles BtnCetak.ItemClick
        'If BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        'ShowDevexpressReport(ReportPreview.KeyReport.TTB, GridView1.GetFocusedRow(0))
        'Log.Cetak(Me, GridView1.GetFocusedRow(0))
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputBankKeluar.MdiParent = Me.MdiParent
        InputBankKeluar.Show()
        InputBankKeluar.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditBankKeluar.MdiParent = Me.MdiParent
                EditBankKeluar.Show()
                EditBankKeluar.Focus()
                EditBankKeluar.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub

    Private Sub BtnLihat_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLihat.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                Dim frm As New EditBankKeluar
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
#End Region