
Public MustInherit Class FrmJurnal
    Protected dt As New DataTable

#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.Purchase_Order, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Dim fmt As String = ""
        If CmbJenis.SelectedIndex = 0 Then
            fmt = "JS"
        ElseIf CmbJenis.SelectedIndex = 1 Then
            fmt = "JM"
        ElseIf CmbJenis.SelectedIndex = 2 Then
            fmt = "JP"
        End If
        fmt = fmt & "/" & Format(TglPengakuan.EditValue, "MMyy") & "/"

        Using dtGenerate = SelectCon.execute("SELECT NO_JURNAL FROM AR_JURNAL WHERE NO_JURNAL Like '" & fmt & "%' ORDER BY NO_JURNAL DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = fmt & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_JURNAL,'JR','') AS BIGINT)),0) AS ID FROM AR_JURNAL")
            TxtIDTransaksi.Text = "JR" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan(sender As Object, e As System.EventArgs)
        If Empty({CmbJenis, TglTransaksi, TglPengakuan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Nama Perkiraan]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If TxtTotalDebet.Value <> TxtTotalKredit.Value Then
            MsgBox("Total debet dan kredit tidak sama!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Debet") = 0 And GridView1.GetDataRow(i)("Kredit") = 0 Then
                    MsgBox("Ada Nominal yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Debet")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TglValuta, CmbJenis, TxtNoRef, ToSyntax("NULL"), ToSyntax("NULL"), txtKeteranganInternal, txtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_JURNAL") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Nama Perkiraan]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Kode Perkiraan", "Keterangan", "Debet", "Kredit", "No."}, "AR_JURNAL_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            CmbJenis.Enabled = False

            LoadData.GetData("SELECT NO_JURNAL, TGL, TGL_PENGAKUAN, TGL_VALUTA, JENIS, NO_REF, KETERANGAN_INTERNAL, KETERANGAN_CETAK FROM AR_JURNAL WHERE ID_JURNAL='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TglValuta, CmbJenis, TxtNoRef, txtKeteranganInternal, txtKeterangan})

            LoadData.GetData("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.DEBET, A.KREDIT FROM AR_JURNAL_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_JURNAL='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, True)
        End If
        Urutan()
        Hitung()

        Using dt As DataTable = SelectCon.execute("SELECT LINK_TRANSAKSI, LINK_KASBANK FROM AR_JURNAL WHERE ID_JURNAL='" & TxtIDTransaksi.Text & "'")
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("LINK_TRANSAKSI")) Or Not IsDBNull(dt.Rows(0).Item("LINK_TRANSAKSI")) Then
                    Bar2.Visible = False
                    _Toolbar1_Button1.Enabled = False
                End If
            End If
        End Using
    End Sub

    Protected Sub SimpanEdit(sender As Object, e As System.EventArgs)
        'Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
        '    If dtcek.Rows.Count > 0 Then
        '        If dtcek.Rows(0).Item(0) <> "" Then
        '            MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf &
        '                   "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf &
        '                   "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If
        '    End If
        'End Using

        If Empty({CmbJenis, TglTransaksi, TglPengakuan}) Then Exit Sub

        If dt.Select("[Nama Perkiraan]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If TxtTotalDebet.Value <> TxtTotalKredit.Value Then
            MsgBox("Total debet dan kredit tidak sama!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Debet") = 0 And GridView1.GetDataRow(i)("Kredit") = 0 Then
                    MsgBox("Ada Nominal yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Debet")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("NO_JURNAL, TGL, TGL_PENGAKUAN, TGL_VALUTA, JENIS, NO_REF, KETERANGAN_INTERNAL, KETERANGAN_CETAK ,MDUSER ,MDTIME", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TglValuta, CmbJenis, TxtNoRef, txtKeteranganInternal, txtKeterangan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_JURNAL", "ID_JURNAL='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_JURNAL_DETAIL", "ID_JURNAL='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Nama Perkiraan]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Kode Perkiraan", "Keterangan", "Debet", "Kredit", "No."}, "AR_JURNAL_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus(sender As Object, e As System.EventArgs)
        'Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
        '    If dtcek.Rows.Count > 0 Then
        '        If dtcek.Rows(0).Item(0) <> "" Then
        '            MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf &
        '                   "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf &
        '                   "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If
        '    End If
        'End Using

        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_JURNAL_DETAIL", "ID_JURNAL='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_JURNAL", "ID_JURNAL='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi(sender As Object, e As System.EventArgs)
        'Using dtcek As DataTable = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE ID_PO='" & TxtIDTransaksi.Text & "' AND BATAL=0")
        '    If dtcek.Rows.Count > 0 Then
        '        If dtcek.Rows(0).Item(0) <> "" Then
        '            MsgBox("Transaksi Sudah Dalam Proses D.O., nomor DO : " & dtcek.Rows(0).Item(0) & vbCrLf &
        '                   "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf &
        '                   "Hapus D.O. Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If
        '    End If
        'End Using

        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_JURNAL", "ID_JURNAL='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub
#End Region

    Private Sub FrmPO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub InputPO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F6
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F7
                _Toolbar1_Button5.PerformClick()
            Case System.Windows.Forms.Keys.F8
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub FrmPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("Kode Perkiraan", TypeCode.String, 40, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Perkiraan", TypeCode.String, 100, False)
        InitGrid.AddColumnGrid("Keterangan", TypeCode.String, 150, True)
        InitGrid.AddColumnGrid("Debet", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, "n2", , ReCalc)
        InitGrid.AddColumnGrid("Kredit", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, "n2", , ReCalc)
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDO.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "Kode Perkiraan" Then
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call REBEdit_Click(sender, e)
                ElseIf GridView1.FocusedColumn.FieldName = "Kredit" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Kode Perkiraan").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Kode Perkiraan")
                            Hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        AllowEditColumn(GridView1, "Kode Perkiraan", "Nama Perkiraan")
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        AllowEditColumn(GridView1, "Kode Perkiraan", "Nama Perkiraan")
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Perkiraan")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Perkiraan")
            End If
            Hitung()
            Urutan()
        End If
    End Sub
    Private Sub AllowEditColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EditColumn As String, ByVal CheckColumn As String)
        On Error Resume Next
        If Len(Gridview.GetFocusedRow(CheckColumn).ToString.Trim) > 0 Then
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = False
        Else
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = True
        End If
    End Sub
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Hitung()
    End Sub

    Private Sub REBEdit_Click(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Perkiraan" Then
            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT * FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & col("Kode Perkiraan") & "'")
                If dt_cari.Rows.Count = 1 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Perkiraan") = dt_cari.Rows(0).Item("KODE_PERKIRAAN")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE_PERKIRAAN")
                    col("Nama Perkiraan") = dt_cari.Rows(0).Item("NAMA_PERKIRAAN")
                    col("Keterangan") = ""
                    col("Debet") = 0
                    col("Kredit") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Keterangan")
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
            If kode = "" Then
                col("Kode Perkiraan") = kode
                GridView1.EditingValue = kode
            Else
                col("Kode Perkiraan") = kode
                GridView1.EditingValue = kode
            End If
            Using dt_cari = SelectCon.execute("SELECT * FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & col("Kode Perkiraan") & "'")
                If dt_cari.Rows.Count > 0 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Perkiraan") = dt_cari.Rows(0).Item("KODE_PERKIRAAN")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE_PERKIRAAN")
                    col("Nama Perkiraan") = dt_cari.Rows(0).Item("NAMA_PERKIRAAN")
                    col("Keterangan") = ""
                    col("Debet") = 0
                    col("Kredit") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Keterangan")
                Else
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Perkiraan") = ""
                    GridView1.EditingValue = ""
                    col("Nama Perkiraan") = ""
                    col("Keterangan") = ""
                    col("Debet") = 0
                    col("Kredit") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Kode Perkiraan")
                End If
            End Using
        End If
    End Sub

    Protected Sub Hitung()
        'On Error Resume Next
        Dim Debet As Double = 0
        Dim Kredit As Double = 0
        For Each col As DataRow In dt.Rows
            Debet += col("Debet")
            Kredit += col("Kredit")
        Next

        TxtTotalDebet.Value = Debet
        TxtTotalKredit.Value = Kredit
    End Sub
End Class

'================================================== INPUT ================================
Public Class InputJurnal
    Inherits FrmJurnal

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Jurnal"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT ================================
Public Class EditJurnal
    Inherits FrmJurnal

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Jurnal"

        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        'HakForm("Pembelian", "Langganan", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class