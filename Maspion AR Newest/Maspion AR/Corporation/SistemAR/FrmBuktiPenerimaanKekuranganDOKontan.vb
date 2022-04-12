Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmBuktiPenerimaanKekuranganDOKontan
    Protected dt As New DataTable
    Protected dt2 As New DataTable
    Protected dtcek2 As New DataTable
    Protected Status_Edit As Boolean
    Protected jenis As String = ""
    Private Sub FrmBuktiPenerimaanKekuranganDOKontan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        jenis = "input"
        LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        TglTransaksi.DateTime = Now.Date
        TxtTahunPencarian.Text = Now.Year
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Keterangan", TypeCode.String, 80, False,,,, RepositoryItemComboBox1, True)
        InitGrid.AddColumnGrid("Tanggal", TypeCode.DateTime, 80, False,,,, RepositoryItemDateEdit1, True)
        InitGrid.AddColumnGrid("ID Nota / SJ", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. Nota / SJ", TypeCode.String, 80, False,,,, RepoCari2, True)
        InitGrid.AddColumnGrid("Nilai", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.AddColumnGrid("Total", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.EndInit(TBDetail, GridView1, dt)
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id Bukti Pengembalian", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. Bukti Pengembalian", TypeCode.String, 80, True,,,, RepoCari, True)
        InitGrid.AddColumnGrid("Total Bukti Pengembalian", TypeCode.Single, 50, True, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc)
        InitGrid.EndInit(GridControl1, GridView2, dt2)
        AddRow(dt)
        AddRow(dt2)
        GridView1.GetFocusedDataRow(0) = RepositoryItemComboBox1.Items(0)
    End Sub
    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Bukti_Kekurangan_DO_Kontan, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub
    Private Sub TxtNoDO_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        If jenis = "input" Then
            Dim kode = Search(FrmPencarian.KeyPencarian.DO_KONTAN_LANGGANAN_KEKURANGAN)
            TxtIDDOKontan.Text = kode
            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER from DELIVERY_ORDER where ID_TRANSAKSI = '" & kode & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                End If
            End Using
        ElseIf jenis = "validasi" Then
            Dim kode = Search(FrmPencarian.KeyPencarian.KEKURANGAN_DO_KONTAN_VALIDASI)
            TxtIDDOKontan.Text = kode
            Using dtcek = SelectCon.execute("select NO_KEKURANGAN,DIVISI,DPP + PPN TOTAL,A.KODE_APPROVE,A.KODE_CUSTOMER,B.KETERANGAN from DELIVERY_ORDER A left join AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN B ON A.ID_TRANSAKSI = B.ID_DO_KONTAN where B.ID_TRANSAKSI = '" & kode & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                    TxtKeterangan.Text = dtcek.Rows(0)(5)
                End If
            End Using
        End If
    End Sub

    Private Sub TxtNoDO_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoDO.EditValueChanged

        '        If Status_Edit = False Then
        '            If jenis = "input" Then
        '                If TxtNoDO.Text <> "" Then
        '                    LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
        '                    LoadData.SetDataDetail(dt, False)
        '                    hitung()
        '                End If
        '            ElseIf jenis = "validasi" Then

        '                If Status_Edit = False Then
        '                    If TxtIDDOKontan.Text <> "" Then
        '                        LoadData.GetData("
        'select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI= '" & TxtIDDOKontan.Text & "'")
        '                        LoadData.SetDataDetail(dt, False)

        '                    End If
        '                End If
        '            End If

        '        End If
    End Sub

    Private Sub TxtIDLangganan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDLangganan.EditValueChanged
        SetData("select NAMA from CUSTOMER where KODE_APPROVE = '" & TxtIDLangganan.Text & "'", {TxtNamaLangganan})
    End Sub

    Private Sub TxtIDDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDDivisi.EditValueChanged
        SetData("select NAMA from DIVISI where KODE = '" & TxtIDDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub GridView2_RowCountChanged(sender As Object, e As EventArgs) Handles GridView1.RowCountChanged
        If GridView1.RowCount > 0 Then
            'If GridView2.FocusedRowHandle >= 0 Then
            '    GridView2.GetFocusedDataRow(0) = RepositoryItemComboBox1.Items(0)
            '    If GridView2.GetFocusedDataRow("Keterangan") = "Pembayaran" Then
            '        GridView2.Columns("Total").OptionsColumn.AllowFocus = True
            '        GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = False
            '    Else
            '        GridView2.Columns("Total").OptionsColumn.AllowFocus = False
            '        GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = True
            '    End If
            'End If

        End If
    End Sub

    Private Sub RepoCari2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari2.ButtonClick
        If TxtIDLangganan.Text = "" Then
            Exit Sub
        End If
        paramnotacustomer = TxtKodeLangganan.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.NOTA)

        If kode <> "" Then
            Using dtget = SelectCon.execute("select DPP+PPN,NO_NOTA from NOTA where ID_TRANSAKSI = '" & kode & "'")
                If dtget.Rows.Count > 0 Then
                    GridView1.GetFocusedDataRow(2) = kode
                    GridView1.GetFocusedDataRow(4) = dtget.Rows(0)(0)
                    GridView1.GetFocusedDataRow(3) = dtget.Rows(0)(1)

                    SendKeys.Send("{ENTER}")
                    '  hitung()
                End If
            End Using
        End If
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Keterangan")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Keterangan")
            End If
            hitung()
        End If
    End Sub
    Sub hitung()
        dt.AcceptChanges()
        dt2.AcceptChanges()

        If dt.Rows.Count > 0 Then
            TxtTotalPenjualan.Value = 0
            TxtJumlahYgBelumDibayar.Value = 0
            Dim totalpengembalian As Double = 0
            If dt2.Rows.Count > 0 Then
                For i2 = 0 To dt2.Rows.Count - 1
                    totalpengembalian += dt2.Rows(i2)("Total Bukti Pengembalian")
                Next
            End If
            For i = 0 To dt.Rows.Count - 1
                TxtTotalPenjualan.Value += dt.Rows(i)("Nilai")
                TxtJumlahYgBelumDibayar.Value += dt.Rows(i)("Total") - dt.Rows(i)("Nilai")
            Next
            TxtDibayar.Value = TxtTunai.Value + totalpengembalian
        End If

    End Sub
    Private Sub RepositoryItemComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox1.SelectedValueChanged

        'If GridView2.GetFocusedDataRow("Keterangan") = "Pembayaran" Then
        '    GridView2.Columns("Total").OptionsColumn.AllowFocus = True
        '    GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = False
        'Else
        '    GridView2.Columns("Total").OptionsColumn.AllowFocus = False
        '    GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = True
        'End If
    End Sub

    Private Sub TBDetail_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles TBDetail.EditorKeyDown
        dt.AcceptChanges()
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "Total" Or GridView1.FocusedColumn.FieldName = "No. Nota / SJ" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Keterangan").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Keterangan")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub


    Private Sub GridView2_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
    End Sub

    Private Sub GridView2_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        'If GridView2.RowCount > 0 Then
        '    If GridView2.FocusedRowHandle >= 0 Then

        '        If GridView2.GetFocusedDataRow("Keterangan") = "Pembayaran" Then
        '            GridView2.Columns("Total").OptionsColumn.AllowFocus = True
        '            GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = False
        '        Else
        '            GridView2.Columns("Total").OptionsColumn.AllowFocus = False
        '            GridView2.Columns("No. Nota / SJ").OptionsColumn.AllowFocus = True
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub TxtIDDOKontan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDDOKontan.EditValueChanged
        If jenis = "input" Then
            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER from DELIVERY_ORDER where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                End If
            End Using
            If Status_Edit = False Then
                If TxtIDDOKontan.Text <> "" Then
                    LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
        union all
        select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
        union all
        select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
                    LoadData.SetDataDetail(dt, False)

                End If
            End If
        ElseIf jenis = "validasi" Then
            Using dtcek = SelectCon.execute("select NO_KEKURANGAN,DIVISI,DPP + PPN TOTAL,A.KODE_APPROVE,A.KODE_CUSTOMER,B.KETERANGAN from DELIVERY_ORDER A left join AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN B ON A.ID_TRANSAKSI = B.ID_DO_KONTAN where B.ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                    TxtKeterangan.Text = dtcek.Rows(0)(5)
                End If
            End Using

            If Status_Edit = False Then
                If TxtIDDOKontan.Text <> "" Then
                    LoadData.GetData("
        select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI= '" & TxtIDDOKontan.Text & "'")
                    LoadData.SetDataDetail(dt, False)

                End If
            End If

        End If


        hitung()
    End Sub

    Private Sub TxtKodeLangganan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeLangganan.EditValueChanged

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CKTunai.CheckedChanged
        If CKTunai.Checked = True Then
            LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CKSisa.CheckedChanged
        If CKSisa.Checked = True Then
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub GridControl1_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.EditorKeyDown
        dt2.AcceptChanges()
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView2.FocusedColumn.FieldName = "No. Bukti Pengembalian" Or GridView2.FocusedColumn.FieldName = "Total Bukti Pengembalian" Then
                    If GridView2.FocusedRowHandle = GridView2.RowCount - 1 Then
                        If Len(GridView2.GetFocusedRow("No. Bukti Pengembalian").ToString.Trim) > 0 Then
                            AddRow(dt2)
                            GridView2.FocusedColumn = GridView2.Columns("No. Bukti Pengembalian")
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub GridView2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView2.KeyUp
        If e.KeyCode = 46 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.FocusedColumn = GridView2.Columns("No. Bukti Pengembalian")
            If GridView2.RowCount = 0 Then
                AddRow(dt2)
                GridView2.FocusedColumn = GridView2.Columns("No. Bukti Pengembalian")
            End If

        End If
    End Sub

    Private Sub RepoCari_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari.ButtonClick
        If TxtIDLangganan.Text = "" Then
            Exit Sub
        End If
        paramnotacustomer = TxtKodeLangganan.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.PENGEMBALIAN_DO_KONTAN)

        If kode <> "" Then
            Using dtget = SelectCon.execute("select isnull(SISA,0) - isnull(SISA_TERPAKAI,0),NO_PENGEMBALIAN from V_AR_SISA_PENGEMBALIAN_DO_KONTAN where ID_TRANSAKSI = '" & kode & "' ")
                If dtget.Rows.Count > 0 Then
                    GridView2.GetFocusedDataRow(0) = kode
                    GridView2.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView2.GetFocusedDataRow(1) = dtget.Rows(0)(1)
                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub TxtTunai_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTunai.EditValueChanged
        hitung()
    End Sub

    Private Sub CKCustom_CheckedChanged(sender As Object, e As EventArgs) Handles CKCustom.CheckedChanged
        If CKCustom.Checked = True Then
            LayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        End If
    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub BtnKodeAkunDebet_EditValueChanged(sender As Object, e As EventArgs) Handles BtnKodeAkunDebet.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & BtnKodeAkunDebet.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtKeteranganDebet.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub BtnKodeAkunDebet_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnKodeAkunDebet.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        BtnKodeAkunDebet.Text = kode
    End Sub

    Private Sub BtnKodeAkunKredit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnKodeAkunKredit.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        BtnKodeAkunKredit.Text = kode
    End Sub

    Private Sub BtnKodeAkunKredit_EditValueChanged(sender As Object, e As EventArgs) Handles BtnKodeAkunKredit.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & BtnKodeAkunKredit.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtKeteranganKredit.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtIDDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtIDDivisi.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Divisi)
        TxtIDDivisi.Text = kode
    End Sub

    Private Sub TxtNoDO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNoDO.KeyPress
        Dim iddo As String
        Dim iddivisi As String
        Dim tahun As String
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TxtIDDivisi.Text = "" Then
                MessageBox.Show("Divisi tidak boleh kosong", "Pemberitahuan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtIDDivisi.Focus()
                Exit Sub
            End If

            If TxtTahunPencarian.Text = "" Then
                MessageBox.Show("Tahun Pencarian tidak boleh kosong", "Pemberitahuan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtTahunPencarian.Focus()
                Exit Sub
            End If
            TxtNoDO.Text = TxtNamaDivisi.Text & "(J)" & Format(Val(TxtNoDO.Text), "000000")

            iddo = ""
            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER,ID_TRANSAKSI from DELIVERY_ORDER where NO_DO = '" & TxtNoDO.Text & "' and YEAR(TGL)=" & TxtTahunPencarian.Text & " and PEMBAYARAN='Kontan'")
                If dtcek.Rows.Count > 0 Then
                    'TxtNoDO.Text = dtcek.Rows(0)(0)
                    'TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                    iddo = dtcek.Rows(0)(5)
                    Using dtcek2 = SelectCon.execute("select NO_KEKURANGAN from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN where NO_DO_KONTAN = '" & TxtNoDO.Text & "' and ID_DO_KONTAN='" & iddo & "'")
                        If dtcek2.Rows.Count > 0 Then
                            MessageBox.Show("No. DO " & TxtNoDO.Text & " ini telah dibuatkan Bukti Penerimaan Kekurangan DO Kontan No. " & dtcek2(0)(0), "Pemberitahuan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtIDLangganan.Text = ""
                            TxtKodeLangganan.Text = ""
                            iddivisi = TxtIDDivisi.Text
                            tahun = TxtTahunPencarian.Text
                            Clean(Me)
                            LoadData.GetData("
        select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI= ''")
                            LoadData.SetDataDetail(dt, False)
                            TxtIDDivisi.Text = iddivisi
                            TxtTahunPencarian.Text = tahun
                            TxtNoDO.Focus()
                            Exit Sub
                        End If
                    End Using
                    TxtIDDOKontan.Text = iddo

                    If Status_Edit = False Then
                        If TxtNoDO.Text <> "" Then
                            If jenis = "input" Then
                                LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
                            union all
select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
union all
select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
                                LoadData.SetDataDetail(dt, False)
                                hitung()
                            ElseIf jenis = "validasi" Then
                                LoadData.GetData("
        select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI= '" & TxtIDDOKontan.Text & "'")
                                LoadData.SetDataDetail(dt, False)
                                hitung()
                            End If
                        End If
                    End If
                Else
                    TxtIDLangganan.Text = ""
                    TxtKodeLangganan.Text = ""
                    MessageBox.Show("No. DO " & TxtNoDO.Text & " tidak tersedia", "Pemberitahuan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End Using
        End If
    End Sub

    Private Sub TxtNoDO_GotFocus(sender As Object, e As EventArgs) Handles TxtNoDO.GotFocus
        TxtNoDO.Text = ""
    End Sub
End Class
Public Class InputBuktiPenerimaanKekuranganDOKontan
    Inherits FrmBuktiPenerimaanKekuranganDOKontan


    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Bukti Kekurangan Uang DO Kontan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

    End Sub



    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)

    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_KEKURANGAN FROM AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_KEKURANGAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            'TxtNoTransaksi.Text = "BKU/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
            TxtNoTransaksi.Text = "BPK/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using


        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'BKU','') AS INT)),0) AS ID FROM AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN")
            TxtIDTransaksi.Text = "BKU" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using

        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoDO}) Then Exit Sub
        '    GridView1.CloseEditor()
        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtIDDOKontan}, "AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(dt.Rows.Count - 1)("Nilai") = 0 And dt.Rows(dt.Rows.Count - 1)("Total") = 0 Then
                        dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    End If
                End If
                dt.AcceptChanges()
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Keterangan", "Tanggal", "No. Nota / SJ", "ID Nota / SJ", "Nilai", "Total"}, "AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub

End Class
Public Class EditBuktiPenerimaanKekuranganDOKontan
    Inherits FrmBuktiPenerimaanKekuranganDOKontan
    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Bukti Kekurangan Uang DO Kontan"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub


    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("select NO_KEKURANGAN,TGL,NO_DO_KONTAN,ID_DO_KONTAN,KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_KURANG_BAYAR from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar})
        LoadData.GetData("select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt, False)
        hitung()
        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        Using dt = SelectCon.execute("select ID_KEKURANGAN from AR_VALIDASI_KEKURANGAN_DO_KONTAN where ID_KEKURANGAN = '" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                MsgBox("Data sudah di validasi, tidak bisa di ubah !")
                Exit Sub
            End If
        End Using
        If Empty({TglTransaksi, TxtNoTransaksi, TxtNoDO}) Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        If dt.Rows.Count > 0 Then
            If dt.Rows(dt.Rows.Count - 1)("Nilai") = 0 And dt.Rows(dt.Rows.Count - 1)("Total") = 0 Then
                dt.Rows.RemoveAt(dt.Rows.Count - 1)
            End If
        End If
        dt.AcceptChanges()
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL,NO_DO_KONTAN, ID_DO_KONTAN, KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_KURANG_BAYAR,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Keterangan", "Tanggal", "No. Nota / SJ", "ID Nota / SJ", "Nilai", "Total"}, "AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dt = SelectCon.execute("select ID_KEKURANGAN from AR_VALIDASI_KEKURANGAN_DO_KONTAN where ID_KEKURANGAN = '" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                MsgBox("Data sudah di validasi, tidak bisa di hapus !")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        Using dt = SelectCon.execute("select ID_KEKURANGAN from AR_VALIDASI_KEKURANGAN_DO_KONTAN where ID_KEKURANGAN = '" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                MsgBox("Data sudah di validasi, tidak bisa di batalkan !")
                Exit Sub
            End If
        End Using
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
Public Class InputValidasiPenerimaanKekuranganDOKontan
    Inherits FrmBuktiPenerimaanKekuranganDOKontan
    Private Sub FrmBuktiPenerimaanKekuranganDOKontan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Validasi Bukti Kekurangan Uang DO Kontan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
        LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem5.Text = "No. Bukti Kekurangan Uang DO Kontan"
        LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        jenis = "validasi"
    End Sub



    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)

    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_VALIDASI FROM AR_VALIDASI_KEKURANGAN_DO_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_VALIDASI DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "VBK/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using


        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'VBK','') AS INT)),0) AS ID FROM AR_VALIDASI_KEKURANGAN_DO_KONTAN")
            TxtIDTransaksi.Text = "VBK" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using

        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoDO}) Then Exit Sub
        '    GridView1.CloseEditor()
        If TxtDibayar.Value * -1 <> TxtJumlahYgBelumDibayar.Value Then
            MsgBox("Jumlah Dibayar harus sama")
            Exit Sub
        End If
        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDDOKontan, TxtNoDO, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, CKTunai, CKSisa, TxtTunai, TxtDibayar, CKCustom, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiDebet, BtnKodeAkunKredit, TxtKeteranganKredit, TxtNilaiKredit}, "AR_VALIDASI_KEKURANGAN_DO_KONTAN") = False Then Exit Sub
            If dt2.Rows.Count > 0 Then
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows(dt2.Rows.Count - 1)("Total Bukti Pengembalian") = 0 Then
                        dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
                    End If
                End If
                dt2.AcceptChanges()
                If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id. Bukti Pengembalian", "No. Bukti Pengembalian", "Total Bukti Pengembalian"}, "AR_VALIDASI_KEKURANGAN_DO_KONTAN_DETAIL_SISA_PENGEMBALIAN") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub

End Class
Public Class EditValidasiPenerimaanKekuranganDOKontan
    Inherits FrmBuktiPenerimaanKekuranganDOKontan
    Private Sub FrmBuktiPenerimaanKekuranganDOKontan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Validasi Bukti Kekurangan Uang DO Kontan"
        Status_Edit = True
        LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem5.Text = "No. Bukti Kekurangan Uang DO Kontan"
        LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        jenis = "validasi"
    End Sub


    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("select NO_VALIDASI,A.TGL,A.NO_KEKURANGAN,ID_KEKURANGAN,KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_KURANG_BAYAR,STATUS_TUNAI,STATUS_SISA_PENGEMBALIAN,NOMINAL_TUNAI,JUMLAH_DIBAYAR,A.STATUS_CUSTOM,A.KODE_AKUN_DEBET,A.KETERANGAN_DEBET,A.NILAI_DEBET,A.KODE_AKUN_KREDIT,A.KETERANGAN_KREDIT,A.NILAI_KREDIT from AR_VALIDASI_KEKURANGAN_DO_KONTAN A join AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN B ON A.ID_KEKURANGAN = B.ID_TRANSAKSI where A.ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar, CKTunai, CKSisa, TxtTunai, TxtDibayar, CKCustom, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiDebet, BtnKodeAkunKredit, TxtKeteranganKredit, TxtNilaiKredit})
        LoadData.GetData("select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_KEKURANGAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        LoadData.SetDataDetail(dt, False)
        LoadData.GetData("select ID_PENGEMBALIAN,NO_PENGEMBALIAN,NOMINAL from AR_VALIDASI_KEKURANGAN_DO_KONTAN_DETAIL_SISA_PENGEMBALIAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt2, False)
        hitung()
        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtNoDO}) Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        If dt2.Rows.Count > 0 Then
            If dt2.Rows(dt2.Rows.Count - 1)("Total Bukti Pengembalian") = 0 Then
                dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
            End If
        End If
        dt2.AcceptChanges()
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL,ID_KEKURANGAN, NO_KEKURANGAN,STATUS_TUNAI,STATUS_SISA_PENGEMBALIAN,NOMINAL_TUNAI,JUMLAH_DIBAYAR,STATUS_CUSTOM,KODE_AKUN_DEBET,KETERANGAN_DEBET,NILAI_DEBET,KODE_AKUN_KREDIT,KETERANGAN_KREDIT,NILAI_KREDIT,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtIDDOKontan, TxtNoDO, CKTunai, CKSisa, TxtTunai, TxtDibayar, CKCustom, BtnKodeAkunDebet, TxtKeteranganDebet, TxtNilaiDebet, BtnKodeAkunKredit, TxtKeteranganKredit, TxtNilaiKredit, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_VALIDASI_KEKURANGAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_VALIDASI_KEKURANGAN_DO_KONTAN_DETAIL_SISA_PENGEMBALIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If dt2.Rows.Count > 0 Then
                If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id. Bukti Pengembalian", "No. Bukti Pengembalian", "Total Bukti Pengembalian"}, "AR_VALIDASI_KEKURANGAN_DO_KONTAN_DETAIL_SISA_PENGEMBALIAN") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_VALIDASI_KEKURANGAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_VALIDASI_KEKURANGAN_DO_KONTAN_DETAIL_SISA_PENGEMBALIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_VALIDASI_KEKURANGAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

End Class