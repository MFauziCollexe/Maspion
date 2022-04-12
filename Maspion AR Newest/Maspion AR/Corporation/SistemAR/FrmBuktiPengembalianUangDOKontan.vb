Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmBuktiPengembalianUangDOKontan
    Protected dt As New DataTable
    Protected dtcek2 As New DataTable
    Protected jenisinput As String = ""
    Protected Status_Edit As Boolean
    Private Sub FrmBuktiPengembalianUangDOKontan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        jenisinput = "Input"
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
        AddRow(dt)
        GridView1.GetFocusedDataRow(0) = RepositoryItemComboBox1.Items(0)
    End Sub

    Private Sub TxtNoDO_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        If jenisinput = "Input" Then
            Dim kode = Search2(FrmPencarian2.KeyPencarian.DO_KONTAN_LANGGANAN_PENGEMBALIAN)
            TxtIDDOKontan.Text = kode
            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER from DELIVERY_ORDER where ID_TRANSAKSI = '" & kode & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    'TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                End If
            End Using
        ElseIf jenisinput = "validasi" Then
            paramnotacustomer = ""
            Dim kode = Search2(FrmPencarian2.KeyPencarian.PENGEMBALIAN_DO_KONTAN_VALIDASI)
            TxtIDDOKontan.Text = kode
            Using dtcek = SelectCon.execute("select A.NO_PENGEMBALIAN,DIVISI,DPP + PPN TOTAL,b.KODE_APPROVE,b.KODE_CUSTOMER from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN A join DELIVERY_ORDER b on a.ID_DO_KONTAN = b.ID_TRANSAKSI where A.ID_TRANSAKSI = '" & kode & "'")
                If dtcek.Rows.Count > 0 Then
                    TxtNoDO.Text = dtcek.Rows(0)(0)
                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                End If
            End Using
        End If
    End Sub

    Private Sub TxtNoDO_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoDO.EditValueChanged
        '        If Status_Edit = False Then
        '            If TxtNoDO.Text <> "" Then
        '                If jenisinput = "Input" Then
        '                    LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
        '                    LoadData.SetDataDetail(dt, False)
        '                    hitung()
        '                ElseIf jenisinput = "validasi" Then
        '                    LoadData.GetData("
        'select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        '                    LoadData.SetDataDetail(dt, False)
        '                    hitung()
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
    Private Sub GridView2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
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
        If dt.Rows.Count > 0 Then
            TxtTotalPenjualan.Value = 0
            TxtJumlahYgBelumDibayar.Value = 0
            For i = 0 To dt.Rows.Count - 1
                TxtTotalPenjualan.Value += dt.Rows(i)("Nilai")
                TxtJumlahYgBelumDibayar.Value += dt.Rows(i)("Total") - dt.Rows(i)("Nilai")
            Next
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
        '        If jenisinput = "Input" Then
        '            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER from DELIVERY_ORDER where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        '                If dtcek.Rows.Count > 0 Then
        '                    TxtNoDO.Text = dtcek.Rows(0)(0)
        '                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
        '                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
        '                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
        '                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
        '                End If
        '            End Using
        '        ElseIf jenisinput = "validasi" Then
        '            Using dtcek = SelectCon.execute("select NO_PENGEMBALIAN,DIVISI,DPP + PPN TOTAL,A.KODE_APPROVE,A.KODE_CUSTOMER from DELIVERY_ORDER A join AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN B ON A.ID_TRANSAKSI = b.ID_DO_KONTAN where B.ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        '                If dtcek.Rows.Count > 0 Then
        '                    TxtNoDO.Text = dtcek.Rows(0)(0)
        '                    TxtIDDivisi.Text = dtcek.Rows(0)(1)
        '                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
        '                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
        '                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
        '                End If
        '            End Using
        '        End If
        '        If Status_Edit = False Then
        '            If TxtIDDOKontan.Text <> "" Then
        '                If jenisinput = "Input" Then
        '                    LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
        'union all
        'select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
        '                    LoadData.SetDataDetail(dt, False)
        '                    hitung()
        '                ElseIf jenisinput = "validasi" Then
        '                    LoadData.GetData("
        'select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        '                    LoadData.SetDataDetail(dt, False)
        '                    hitung()
        '                End If
        '            End If
        '        End If
        '        hitung()
    End Sub

    Private Sub TxtKodeLangganan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeLangganan.EditValueChanged

    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TxtIDDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtIDDivisi.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Divisi)
        TxtIDDivisi.Text = kode
    End Sub

    Private Sub TxtIDDivisi_BackColorChanged(sender As Object, e As EventArgs) Handles TxtIDDivisi.BackColorChanged

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
            Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_APPROVE,KODE_CUSTOMER,ID_TRANSAKSI from DELIVERY_ORDER where NO_DO= '" & TxtNoDO.Text & "' and YEAR(TGL)=" & TxtTahunPencarian.Text & " and PEMBAYARAN='Kontan'")
                If dtcek.Rows.Count > 0 Then
                    'TxtNoDO.Text = dtcek.Rows(0)(0)
                    'TxtIDDivisi.Text = dtcek.Rows(0)(1)
                    'TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                    TxtIDLangganan.Text = dtcek.Rows(0)(3)
                    TxtKodeLangganan.Text = dtcek.Rows(0)(4)
                    iddo = dtcek.Rows(0)(5)
                    Using dtcek2 = SelectCon.execute("select NO_PENGEMBALIAN from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN where NO_DO_KONTAN = '" & TxtNoDO.Text & "' and ID_DO_KONTAN='" & iddo & "'")
                        If dtcek2.Rows.Count > 0 Then
                            MessageBox.Show("No. DO " & TxtNoDO.Text & " ini telah dibuatkan Bukti Pengembalian Uang DO Kontan No. " & dtcek2.Rows(0)(0), "Pemberitahuan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtIDLangganan.Text = ""
                            TxtKodeLangganan.Text = ""
                            iddivisi = TxtIDDivisi.Text
                            tahun = TxtTahunPencarian.Text
                            Clean(Me)
                            LoadData.GetData("
        select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI= ''")
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
                            If jenisinput = "Input" Then
                                LoadData.GetData("select 'Pembayaran',TGL,ID_TRANSAKSI,''NO_NOTA,0 NILAI,DPP+PPN TOTAL from delivery_order where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'
                            union all
        select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO = '" & TxtIDDOKontan.Text & "' and BATAL = 0
        union all
        select 'Penjualan (-)',TGL,ID_TRANSAKSI,NO_NOTA,DPP+PPN,0 as total from nota where ID_DO in (select ID_TRANSAKSI from BON_PESANAN where ID_DO =  '" & TxtIDDOKontan.Text & "') and BATAL = 0")
                                LoadData.SetDataDetail(dt, False)
                                hitung()
                            ElseIf jenisinput = "validasi" Then
                                LoadData.GetData("
        select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
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
Public Class inputvalidasipengembalian
    Inherits FrmBuktiPengembalianUangDOKontan
    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        jenisinput = "validasi"
        Text = "Input Validasi Bukti Pengembalian Uang DO Kontan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
        LayoutControlItem5.Text = "No. Bukti Pengembalian"
        GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False

    End Sub


    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_VALIDASI FROM AR_VALIDASI_PENGEMBALIAN_DO_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_VALIDASI DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "VBP/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using


        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'VBP','') AS INT)),0) AS ID FROM AR_VALIDASI_PENGEMBALIAN_DO_KONTAN")
            TxtIDTransaksi.Text = "VBP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDDOKontan, TxtNoDO, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_VALIDASI_PENGEMBALIAN_DO_KONTAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
            dt.Clear()
            GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            Batal()
        End Using
    End Sub


End Class

Public Class Editvalidasipengembalian
    Inherits FrmBuktiPengembalianUangDOKontan
    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        jenisinput = "validasi"
        Text = "Edit Validasi Bukti Pengembalian Uang DO Kontan"
        Status_Edit = True
        LayoutControlItem5.Text = "No. Bukti Pengembalian"
        GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False

    End Sub



    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("select NO_VALIDASI,A.TGL,A.NO_PENGEMBALIAN,ID_PENGEMBALIAN,KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_BELUM_DIBAYAR from AR_VALIDASI_PENGEMBALIAN_DO_KONTAN A JOIN AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN B ON A.ID_PENGEMBALIAN = B.ID_TRANSAKSI where A.ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar})
        LoadData.GetData("select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDDOKontan.Text & "'")
        LoadData.SetDataDetail(dt, False)
        hitung()
        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtNoDO}) Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL,NO_PENGEMBALIAN, ID_PENGEMBALIAN,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtNoDO, TxtIDDOKontan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_VALIDASI_PENGEMBALIAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_VALIDASI_PENGEMBALIAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_VALIDASI_PENGEMBALIAN_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

End Class

Public Class InputBuktiPengembalianUangDOKontan
    Inherits FrmBuktiPengembalianUangDOKontan


    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Bukti Pengembalian Uang DO Kontan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

    End Sub



    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        dt.Clear()
        Clean(Me)

    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_PENGEMBALIAN FROM AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_PENGEMBALIAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "BPU/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using


        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'BPU','') AS INT)),0) AS ID FROM AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN")
            TxtIDTransaksi.Text = "BPU" & CInt(dtGenerate.Rows(0).Item(0)) + 1
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtIDDOKontan}, "AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(dt.Rows.Count - 1)("Nilai") = 0 And dt.Rows(dt.Rows.Count - 1)("Total") = 0 Then
                        dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    End If
                End If
                dt.AcceptChanges()
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Keterangan", "Tanggal", "No. Nota / SJ", "ID Nota / SJ", "Nilai", "Total"}, "AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            dt.Clear()
            Batal()
        End Using
    End Sub

End Class
Public Class EditBuktiPengembalianUangDOKontan
    Inherits FrmBuktiPengembalianUangDOKontan
    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Bukti Pengembalian Uang DO Kontan"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Bukti_Pengembalian_DO_Kontan, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("select NO_PENGEMBALIAN,TGL,NO_DO_KONTAN,ID_DO_KONTAN,KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_BELUM_DIBAYAR from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar})
        LoadData.GetData("select KETERANGAN,TANGGAL_NOTA,ID_NOTA,NO_NOTA,NILAI,TOTAL from AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt, False)
        hitung()
        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtNoDO}) Then Exit Sub
        Using dt = SelectCon.execute("select ID_PENGEMBALIAN from AR_VALIDASI_PENGEMBALIAN_DO_KONTAN where ID_PENGEMBALIAN = '" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                MsgBox("Data sudah di validasi, tidak bisa di ubah !")
                Exit Sub
            End If
        End Using
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
            If SQLServer.UpdateHeader("TGL,NO_DO_KONTAN, ID_DO_KONTAN, KODE_CUSTOMER,KODE_APPROVE,KETERANGAN,TOTAL_PENJUALAN,JUMLAH_BELUM_DIBAYAR,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtNoDO, TxtIDDOKontan, TxtKodeLangganan, TxtIDLangganan, TxtKeterangan, TxtTotalPenjualan, TxtJumlahYgBelumDibayar, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Keterangan", "Tanggal", "No. Nota / SJ", "ID Nota / SJ", "Nilai", "Total"}, "AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dt = SelectCon.execute("select ID_PENGEMBALIAN from AR_VALIDASI_PENGEMBALIAN_DO_KONTAN where ID_PENGEMBALIAN = '" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                MsgBox("Data sudah di validasi, tidak bisa di hapus !")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_BUKTI_PENGEMBALIAN_UANG_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        Using dt = SelectCon.execute("select ID_PENGEMBALIAN from AR_VALIDASI_PENGEMBALIAN_DO_KONTAN where ID_PENGEMBALIAN = '" & TxtIDTransaksi.Text & "'")
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