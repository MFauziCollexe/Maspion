Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmValidasiDSRPembelian
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean
    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Nota / SJ", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Diskon", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Claim Bersih", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Terima", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Nota / SJ").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Nota / SJ"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Diskon").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Diskon"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Claim Bersih").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Claim Bersih"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Terima").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Terima"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub FrmValidasiDSRPembelian_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})

    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeGudang.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})

    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub
End Class
Public Class InputValidasiDSRPembelian
    Inherits FrmValidasiDSRPembelian
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub
    Private Sub TxtNoDSR_Click(sender As Object, e As System.EventArgs) Handles TxtNoDSR.Click
        TxtIDDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Pembelian)
    End Sub
    Private Sub TxtIdDSR_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDDSR.EditValueChanged
        On Error Resume Next
        SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_SUPPLIER, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA  FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub
    Private Sub TxtNoDSR_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDSR.KeyPress
        If CharKeypress(TxtNoDSR, e) Then TxtIDDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Pembelian)
    End Sub
    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_VALIDASI FROM AR_VALIDASI_DSR_PEMBELIAN WHERE NO_DSR Like 'VLPB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_DSR DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "VLPB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'VLPB','') AS INT)),0) AS ID FROM AR_VALIDASI_DSR_PEMBELIAN")
            TxtIDTransaksi.Text = "VLPB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoDSR, TglPengakuan, TxtDivisi}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_VALIDASI_DSR_PEMBELIAN") = False Then Exit Sub

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class
Public Class editValidasiDSRPembelian
    Inherits FrmValidasiDSRPembelian
    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_VALIDASI, TGL, ID_DSR, NO_DSR FROM AR_VALIDASI_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR})
        SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_SUPPLIER, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub


    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi}) Then Exit Sub
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("NO_VALIDASI, TGL, ID_DSR, NO_DSR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_VALIDASI_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_VALIDASI_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_VALIDASI_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
Public Class InputValidasiLapReturPenjualan
    Inherits FrmValidasiDSRPembelian
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Validasi Laporan Retur Penjualan"
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem5.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem7.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub
    Private Sub TxtNoDSR_Click(sender As Object, e As System.EventArgs) Handles TxtNoDSR.Click
        TxtIDDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_penjualan)
    End Sub
    Private Sub TxtIdDSR_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDDSR.EditValueChanged
        On Error Resume Next
        SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,A.NO_TTB, A.ID_CUSTOMER, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub
    Private Sub TxtNoDSR_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDSR.KeyPress
        If CharKeypress(TxtNoDSR, e) Then TxtIDDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_penjualan)
    End Sub
    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_VALIDASI FROM AR_VALIDASI_LAP_RETUR_PENJUALAN WHERE NO_LAP Like 'VLRJ-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_LAP DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "VLRJ-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'VLRJ','') AS INT)),0) AS ID FROM AR_VALIDASI_LAP_RETUR_PENJUALAN")
            TxtIDTransaksi.Text = "VLRJ" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoDSR, TglPengakuan, TxtDivisi}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_VALIDASI_LAP_RETUR_PENJUALAN") = False Then Exit Sub

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class
Public Class editValidasiLapReturPenjualan
    Inherits FrmValidasiDSRPembelian

    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Validasi Laporan Retur Penjualan"
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem5.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem7.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_VALIDASI, TGL, ID_LAP, NO_LAP FROM AR_VALIDASI_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR})
        SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,a.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub


    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi}) Then Exit Sub
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("NO_VALIDASI, TGL, ID_LAP, NO_LAP ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_VALIDASI_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_VALIDASI_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_VALIDASI_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class

Public Class inputvalidasiLapReturPembelian
    Inherits FrmValidasiDSRPembelian
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Validasi Laporan Retur Pembelian"
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem5.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem7.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub
    Private Sub TxtNoDSR_Click(sender As Object, e As System.EventArgs) Handles TxtNoDSR.Click
        TxtIDDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_Pembelian)
    End Sub
    Private Sub TxtIdDSR_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDDSR.EditValueChanged
        On Error Resume Next
        SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,A.NO_TTB, A.ID_CUSTOMER, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub
    Private Sub TxtNoDSR_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDSR.KeyPress
        If CharKeypress(TxtNoDSR, e) Then TxtIDDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_Pembelian)
    End Sub
    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_VALIDASI FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN WHERE NO_LAP Like 'VLRB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_LAP DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "VLRB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'VLRB','') AS INT)),0) AS ID FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN")
            TxtIDTransaksi.Text = "VLRB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoDSR, TglPengakuan, TxtDivisi}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_VALIDASI_LAP_RETUR_PEMBELIAN") = False Then Exit Sub

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class editvalidasiReturPembelian
    Inherits FrmValidasiDSRPembelian
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Validasi Laporan Retur Pembelian"
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem5.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem7.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_VALIDASI, TGL, ID_LAP, NO_LAP FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR})
        SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,a.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDDSR.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub


    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("NO_VALIDASI, TGL, ID_LAP, NO_LAP ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TxtIDDSR, TxtNoDSR, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_VALIDASI_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub


    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_PROSES_JURNAL where ID_DSR = '" & TxtIDDSR.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah dibuatkan Proses Jurnal, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_VALIDASI_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Hapus)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_VALIDASI_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            'Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Transaksi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnal.Submit()
            'Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon UCF", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalUCF.Submit()
            'Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtNoDSR.Text, "Jurnal Add. Diskon Divisi", SQLServer, ProsesJurnal.StatusJurnal.Batal)
            'ProsJurnalPT.Submit()

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

End Class