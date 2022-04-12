
Public MustInherit Class FrmKas
    Protected dt As New DataTable
    Private Jenis As String
    Private Table As String
    Private Nomor As String
    Public Enum _Tipe
        Kas_Masuk = 1
        Kas_Keluar = 2
        Bank_Masuk = 3
        Bank_Keluar = 4
    End Enum
    Private __Tipe As _Tipe
    Property Tipe As _Tipe
        Set(value As _Tipe)
            __Tipe = value
            If value = _Tipe.Kas_Masuk Then
                Table = "AR_KAS"
                Nomor = "NO_KAS"
                Jenis = "KM"
            ElseIf value = _Tipe.Kas_Keluar Then
                Table = "AR_KAS"
                Nomor = "NO_KAS"
                Jenis = "KK"
            ElseIf value = _Tipe.Bank_Masuk Then
                Table = "AR_BANK"
                Nomor = "NO_BANK"
                Jenis = "BM"
            ElseIf value = _Tipe.Bank_Keluar Then
                Table = "AR_BANK"
                Nomor = "NO_BANK"
                Jenis = "BK"
            End If
        End Set
        Get
            Return __Tipe
        End Get
    End Property

#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        'ShowDevexpressReport(ReportPreview.KeyReport.Purchase_Order, TxtIDTransaksi.Text)
        'Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Dim fmt As String = ""
        If Tipe = _Tipe.Kas_Masuk Then
            fmt = "KM"
        ElseIf Tipe = _Tipe.Kas_Keluar Then
            fmt = "KK"
        ElseIf Tipe = _Tipe.Bank_Masuk Then
            fmt = "BM"
        ElseIf Tipe = _Tipe.Bank_Keluar Then
            fmt = "BK"
        End If
        fmt = fmt & "/" & Format(TglPengakuan.EditValue, "MMyy") & "/"

        Using dtGenerate = SelectCon.execute("SELECT " & Nomor & " FROM " & Table & " WHERE " & Nomor & " Like '" & fmt & "%' ORDER BY " & Nomor & " DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = fmt & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'" & fmt.Substring(0, 1) & "','') AS BIGINT)),0) AS ID FROM " & Table)
            TxtIDTransaksi.Text = fmt.Substring(0, 1) & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan(sender As Object, e As System.EventArgs)
        If Empty({TglTransaksi, TglPengakuan, TxtKodePerkiraan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Nama Perkiraan]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Nominal") = 0 Then
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtKodePerkiraan, TxtNoRef, ToSyntax("NULL"), txtKeteranganInternal, txtKeterangan, ToObject(Jenis), periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, Table) = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Nama Perkiraan]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Kode Perkiraan", "Keterangan", "Nominal", "No."}, Table & "_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT " & Nomor & ", TGL, TGL_PENGAKUAN, KODE_PERKIRAAN, NO_REF, KETERANGAN_INTERNAL, KETERANGAN_CETAK FROM " & Table & " WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtKodePerkiraan, TxtNoRef, txtKeteranganInternal, txtKeterangan})

            LoadData.GetData("SELECT A.URUTAN, A.KODE_PERKIRAAN, B.NAMA_PERKIRAAN, A.KETERANGAN, A.NOMINAL FROM " & Table & "_DETAIL A JOIN AR_KODE_PERKIRAAN B ON A.KODE_PERKIRAAN=B.KODE_PERKIRAAN WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, True)
        End If
        Urutan()
        Hitung()
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

        If Empty({TglTransaksi, TglPengakuan, TxtKodePerkiraan}) Then Exit Sub

        If dt.Select("[Nama Perkiraan]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Nominal") = 0 Then
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
            If SQLServer.UpdateHeader(Nomor & ", TGL, TGL_PENGAKUAN, KODE_PERKIRAAN, NO_REF, KETERANGAN_INTERNAL, KETERANGAN_CETAK, MDUSER ,MDTIME", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtKodePerkiraan, TxtNoRef, txtKeteranganInternal, txtKeterangan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, Table, "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete(Table & "_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Nama Perkiraan]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Kode Perkiraan", "Keterangan", "Nominal", "No."}, Table & "_DETAIL") = False Then Exit Sub
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
            If SQLServer.Delete(Table & "_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete(Table, "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, Table, "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
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
        InitGrid.AddColumnGrid("Nominal", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, "n2", , ReCalc)
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
                ElseIf GridView1.FocusedColumn.FieldName = "Nominal" Then
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
                    col("Nominal") = 0
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
                    col("Nominal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Keterangan")
                Else
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Perkiraan") = ""
                    GridView1.EditingValue = ""
                    col("Nama Perkiraan") = ""
                    col("Keterangan") = ""
                    col("Nominal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Kode Perkiraan")
                End If
            End Using
        End If
    End Sub

    Protected Sub Hitung()
        'On Error Resume Next
        Dim Nominal As Double = 0
        For Each col As DataRow In dt.Rows
            Nominal += col("Nominal")
        Next

        TxtTotal.Value = Nominal
    End Sub

    Private Sub TxtKodePerkiraan_Click(sender As Object, e As System.EventArgs) Handles TxtKodePerkiraan.Click
        TxtKodePerkiraan.Text = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
    End Sub
    Private Sub TxtKodePerkiraan_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodePerkiraan.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & TxtKodePerkiraan.Text & "'", {TxtNamaPerkiraan})
    End Sub
End Class

'================================================== INPUT ================================
Public Class InputKasMasuk
    Inherits FrmKas

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kas Masuk"
        Tipe = _Tipe.Kas_Masuk
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT ================================
Public Class EditKasMasuk
    Inherits FrmKas

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kas Masuk"
        Tipe = _Tipe.Kas_Masuk
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        'HakForm("Pembelian", "Langganan", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class

'================================================== INPUT ================================
Public Class InputKasKeluar
    Inherits FrmKas

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kas Keluar"
        Tipe = _Tipe.Kas_Keluar
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT ================================
Public Class EditKasKeluar
    Inherits FrmKas

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kas Keluar"
        Tipe = _Tipe.Kas_Keluar
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        'HakForm("Pembelian", "Langganan", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class

'================================================== INPUT ================================
Public Class InputBankMasuk
    Inherits FrmKas

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bank Masuk"
        Tipe = _Tipe.Bank_Masuk
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT ================================
Public Class EditBankMasuk
    Inherits FrmKas

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Bank Masuk"
        Tipe = _Tipe.Bank_Masuk
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        'HakForm("Pembelian", "Langganan", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class

'================================================== INPUT ================================
Public Class InputBankKeluar
    Inherits FrmKas

    Private Sub InputPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bank Keluar"
        Tipe = _Tipe.Bank_Keluar
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
        Generate()
    End Sub
End Class

'================================================== EDIT ================================
Public Class EditBankKeluar
    Inherits FrmKas

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Bank Keluar"
        Tipe = _Tipe.Bank_Keluar
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        'HakForm("Pembelian", "Langganan", "Purchase Order", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub
End Class