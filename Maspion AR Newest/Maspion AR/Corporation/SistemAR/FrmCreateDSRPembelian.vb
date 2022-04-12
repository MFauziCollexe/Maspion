Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmCreateDSRPembelian
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean

    Enum JenisEnum
        Perwakilan = 1
        Pusat = 2
        Supermarket = 3
        ReturPenjualan = 4
        ReturPembelian = 5
        DOKontan = 6
    End Enum
    Public _Jenis As JenisEnum


    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        If _Jenis = JenisEnum.ReturPenjualan Then
            LayoutControlItem2.Text = "No. Lap. Retur Penjualan"
            LayoutControlItem5.Text = "Tanggal Lap. Retur Penjualan"
            InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
            InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 40, False,,,,, False)
            InitGrid.AddColumnGrid("Nota", TypeCode.String, 70, False)
            '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
            InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
            InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
            InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 80, False)
            InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
            InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
            InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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
        Else
            LayoutControlItem2.Text = "No. Lap. Pembelian"
            LayoutControlItem5.Text = "Tanggal Lap. Pembelian"
            InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
            InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
            InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
            '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
            InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
            InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
            InitGrid.AddColumnGrid("Nilai Nota / SJ", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
            InitGrid.AddColumnGrid("Diskon", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
            InitGrid.AddColumnGrid("Claim Bersih", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
            InitGrid.AddColumnGrid("Nilai Terima", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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
        End If

    End Sub

    Private Sub FrmCreateDSRPembelian_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Protected Function Generate() As Boolean
        If _Jenis = JenisEnum.ReturPenjualan Then
            Dim urut As Short
            Using dtGenerate = SelectCon.execute("SELECT NO_LAP FROM AR_LAP_RETUR_PENJUALAN WHERE NO_LAP Like 'LRJ-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_LAP DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "LRJ-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'LRJ','') AS INT)),0) AS ID FROM AR_LAP_RETUR_PENJUALAN")
                TxtIDTransaksi.Text = "LRJ" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
            Return True
        ElseIf _Jenis = JenisEnum.ReturPembelian Then

            Dim urut As Short
            Using dtGenerate = SelectCon.execute("SELECT NO_LAP FROM AR_LAP_RETUR_PEMBELIAN WHERE NO_LAP Like 'LRB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_LAP DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "LRB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'LRB','') AS INT)),0) AS ID FROM AR_LAP_RETUR_PEMBELIAN")
                TxtIDTransaksi.Text = "LRB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
            Return True

        Else
            Dim urut As Short
            Using dtGenerate = SelectCon.execute("SELECT NO_DSR FROM AR_DSR_PEMBELIAN WHERE NO_DSR Like 'LPB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_DSR DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "LPB-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'LPB','') AS INT)),0) AS ID FROM AR_DSR_PEMBELIAN")
                TxtIDTransaksi.Text = "LPB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
            Return True
        End If

    End Function

    Private Sub FrmCreateDSRPembelian_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.Click

    End Sub

    Private Sub TxtDivisi_Click(sender As Object, e As EventArgs) Handles TxtDivisi.Click
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})

    End Sub

    Private Sub TxtDivisi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)

    End Sub

    Private Sub TxtKodeGudang_Click(sender As Object, e As EventArgs) Handles TxtKodeGudang.Click
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang_All)

    End Sub

    Private Sub TxtKodeGudang_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeGudang.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})

    End Sub

    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang_All)

    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub RGJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RGJenis.SelectedIndexChanged

    End Sub
End Class
Public Class InputCreateDSRPembelian
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Create Laporan Pembelian"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub GetDataDSR() Handles TxtDivisi.EditValueChanged, TxtKodeGudang.EditValueChanged, TglPengakuan.EditValueChanged, RGJenis.SelectedIndexChanged
        Using dturut = SelectCon.execute("select isnull(max(urutan_DSR),0)URUTAN from AR_DSR_PEMBELIAN where  divisi = '" & TxtDivisi.Text & "' and GUDANG = '" & TxtKodeGudang.Text & "' and format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglPengakuan.DateTime, "MMyy") & "'")
            If dturut.Rows.Count > 0 Then
                TxtUrutan.Text = dturut.Rows(0)(0) + 1
            Else
                TxtUrutan.Text = 1
            End If
        End Using
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(Nota, 6) AS INT)) 'No.',* FROM ( SELECT DISTINCT PEMBELIAN.ID_TRANSAKSI AS 'Id Nota', PEMBELIAN.NO_NOTA AS 'Nota', PEMBELIAN.KODE_SUPPLIER 'Id Supplier', SBU.NAMA AS 'Nama',PEMBELIAN.DPP+PEMBELIAN.PPN NILAI_NOTA,(PEMBELIAN.SUBTOTAL - PEMBELIAN.DPP) - (isnull(CLAIM.SUBTOTAL,0) - isnull(CLAIM.DPP,0))
DISKON,IIF(CLAIM.DPP IS NULL,0,IIF(CLAIM.BATAL=1,0,CLAIM.DPP)) + IIF(CLAIM.PPN IS NULL,0,IIF(CLAIM.BATAL=1,0,CLAIM.PPN)) AS CLAIM_BERSIH,PEMBELIAN.SUBTOTAL-isnull(CLAIM.SUBTOTAL,0) NILAI_TERIMA FROM PEMBELIAN LEFT JOIN SBU ON PEMBELIAN.KODE_SUPPLIER = SBU.KODE LEFT OUTER JOIN CLAIM ON PEMBELIAN.ID_TRANSAKSI = CLAIM.ID_NOTA WHERE PEMBELIAN.GUDANG = '" & TxtKodeGudang.Text & "' and PEMBELIAN.BATAL = 0  and CONVERT(DATE,PEMBELIAN.TGL_PENGAKUAN,103) = CONVERT(DATE,'" & TglPengakuan.DateTime & "',103) AND PEMBELIAN.DIVISI='" & TxtDivisi.Text & "' and PEMBELIAN.ID_TRANSAKSI NOT IN (select ID_NOTA FROM AR_DSR_DETAIL_PEMBELIAN WITH(NOLOCK))) A  ORDER BY CAST(RIGHT(Nota, 6) AS INT)")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtDivisi, TxtUrutan}) Then Exit Sub
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
        dt.AcceptChanges()

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtUrutan}, "AR_DSR_PEMBELIAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "Id Supplier", "Nilai Nota / SJ", "Diskon", "Claim Bersih", "Nilai Terima", "No."}, "AR_DSR_DETAIL_PEMBELIAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class
Public Class EditCreateDSRPembelian
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Create Laporan Pembelian"
    End Sub
    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_DSR, TGL, TGL_PENGAKUAN, DIVISI, GUDANG,URUTAN_DSR FROM AR_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_SUPPLIER, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN where ID_DSR = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi, TxtUrutan}) Then Exit Sub

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_DSR] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG], URUTAN_DSR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_DSR_DETAIL_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "Id Supplier", "Nilai Nota / SJ", "Diskon", "Claim Bersih", "Nilai Terima", "No."}, "AR_DSR_DETAIL_PEMBELIAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN where ID_DSR = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_DSR_DETAIL_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_DSR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
Public Class createlaporanreturpenjualan
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Jenis = JenisEnum.ReturPenjualan
        Text = "Input Create Laporan Retur Penjualan"
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        RGJenis2.SelectedIndex = 0
        LayoutControlItem2.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem5.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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

    Private Sub GetDataDSR() Handles TxtDivisi.EditValueChanged, TxtKodeGudang.EditValueChanged, TglPengakuan.EditValueChanged, RGJenis2.SelectedIndexChanged
        Dim jenis As String = ""
        If RGJenis2.SelectedIndex = 0 Then
            jenis = "Distributor"
        ElseIf RGJenis2.SelectedIndex = 1 Then
            jenis = "Supermarket"
        ElseIf RGJenis2.SelectedIndex = 2 Then
            jenis = ""
        End If
        Using dturut = SelectCon.execute("select isnull(max(URUTAN_LAP),0)URUTAN from AR_LAP_RETUR_PENJUALAN where   format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglPengakuan.DateTime, "MMyy") & "'")
            If dturut.Rows.Count > 0 Then
                TxtUrutan.Text = dturut.Rows(0)(0) + 1
            Else
                TxtUrutan.Text = 1
            End If
        End Using
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(NO_NOTA_RETUR, 6) AS INT)) 'No.',* FROM (SELECT A.ID_TRANSAKSI ID_NOTA, A.NO_NOTA_RETUR , C.ID,C.NAMA,B.NO_NOTA NO_TTB,  A.SUBTOTAL, A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1 AS DISCOUNT,A.SUBTOTAL - (A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1) NETTO FROM RETUR_PENJUALAN AS A LEFT OUTER JOIN TTB AS B ON A.ID_TTB = B.ID_TRANSAKSI LEFT OUTER JOIN CUSTOMER AS C ON A.KODE_CUSTOMER = C.ID LEFT OUTER JOIN DIVISI AS D ON A.DIVISI = D.KODE left join customer csg on csg.KODE_APPROVE = b.KODE_APPROVE  WHERE A.BATAL = 0 and A.GUDANG = '" & TxtKodeGudang.Text & "'  and CONVERT(DATE,A.TGL_PENGAKUAN,103) = CONVERT(DATE,'" & TglPengakuan.DateTime & "',103) AND A.DIVISI='" & TxtDivisi.Text & "'  and isnull(csg.GROUP_CUSTOMER,'') = '" & jenis & "' and A.ID_TRANSAKSI NOT IN (select ID_NOTA FROM AR_LAP_RETUR_PENJUALAN_DETAIL WITH(NOLOCK)))A  ORDER BY CAST(RIGHT(NO_NOTA_RETUR, 6) AS INT)")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtDivisi, TxtUrutan}) Then Exit Sub
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
        dt.AcceptChanges()

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtUrutan, RGJenis2}, "AR_LAP_RETUR_PENJUALAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "No. TTB", "Id Customer", "Nilai Bruto", "Nilai Discount", "Nilai Netto", "No."}, "AR_LAP_RETUR_PENJUALAN_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class Editlaporanreturpenjualan
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Jenis = JenisEnum.ReturPenjualan
        Text = "Edit Create Laporan Retur Penjualan"
        GridView1.OptionsView.ColumnAutoWidth = False
        LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        RGJenis2.SelectedIndex = 0
        InitGrid.Clear()
        dt.Columns.Clear()
        LayoutControlItem2.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem5.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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
        LoadData.GetData("SELECT NO_LAP, TGL, TGL_PENGAKUAN, DIVISI, GUDANG,URUTAN_LAP,JENIS_RETUR FROM AR_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan, RGJenis2})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        Using dtcek = SelectCon.execute("select ID_LAP FROM AR_VALIDASI_LAP_RETUR_PENJUALAN where ID_LAP = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi, TxtUrutan}) Then Exit Sub

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_LAP] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG], URUTAN_LAP,JENIS_RETUR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan, RGJenis2, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_LAP_RETUR_PENJUALAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "No. TTB", "Id Customer", "Nilai Bruto", "Nilai Discount", "Nilai Netto", "No."}, "AR_LAP_RETUR_PENJUALAN_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_LAP FROM AR_VALIDASI_LAP_RETUR_PENJUALAN where ID_LAP = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_LAP_RETUR_PENJUALAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_LAP_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class


Public Class createlaporanreturpembelian
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Jenis = JenisEnum.ReturPembelian
        Text = "Input Create Laporan Retur Pembelian"
        RGJenis.SelectedIndex = 0
        LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem2.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem5.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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

    Private Sub GetDataDSR() Handles TxtDivisi.EditValueChanged, TxtKodeGudang.EditValueChanged, TglPengakuan.EditValueChanged, RGJenis.SelectedIndexChanged
        Dim jenis As String = ""
        If RGJenis.SelectedIndex = 0 Then
            jenis = "Distributor"
        ElseIf RGJenis.SelectedIndex = 1 Then
            jenis = "Supermarket"
        ElseIf RGJenis.SelectedIndex = 2 Then
            jenis = ""
        End If
        Using dturut = SelectCon.execute("select isnull(max(URUTAN_LAP),0)URUTAN from AR_LAP_RETUR_PEMBELIAN where   format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglPengakuan.DateTime, "MMyy") & "'")
            If dturut.Rows.Count > 0 Then
                TxtUrutan.Text = dturut.Rows(0)(0) + 1
            Else
                TxtUrutan.Text = 1
            End If
        End Using
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(NO_RETUR, 6) AS INT)) 'No.',* FROM (SELECT A.ID_TRANSAKSI ID_NOTA, A.NO_RETUR , C.ID,C.NAMA,isnull(B.NO_NOTA,'') NO_TTB,  A.SUBTOTAL, A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1 AS DISCOUNT,A.SUBTOTAL - (A.DISC_QTY_NOMINAL + A.DISC_REG_NOMINAL + A.DISC_1_NOMINAL + A.DISC_2_NOMINAL + A.DISC_3_NOMINAL + A.CASH_DISC_NOMINAL + A.DISC_QTY_NOMINAL1) NETTO FROM RETUR_PEMBELIAN AS A left join (select distinct ID_TRANSAKSI,ID_TTB from DETAIL_RETUR_PEMBELIAN WITH(NOLOCK)) F ON F.ID_TRANSAKSI = A.ID_TRANSAKSI LEFT OUTER JOIN TTB AS B ON F.ID_TTB = B.ID_TRANSAKSI CROSS JOIN PERUSAHAAN E LEFT OUTER JOIN CUSTOMER AS C ON e.CUST_PEMBELIAN = C.ID LEFT OUTER JOIN DIVISI AS D ON A.DIVISI = D.KODE left join customer csg on csg.KODE_APPROVE = b.KODE_APPROVE  WHERE A.BATAL = 0 and A.GUDANG = '" & TxtKodeGudang.Text & "'  and CONVERT(DATE,A.TGL_PENGAKUAN,103) = CONVERT(DATE,'" & TglPengakuan.DateTime & "',103) AND A.DIVISI='" & TxtDivisi.Text & "' and isnull(csg.GROUP_CUSTOMER,'') = '" & jenis & "' and A.ID_TRANSAKSI NOT IN (select ID_NOTA FROM AR_LAP_RETUR_PEMBELIAN_DETAIL WITH(NOLOCK)))A  ORDER BY CAST(RIGHT(NO_RETUR, 6) AS INT)")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtDivisi, TxtUrutan}) Then Exit Sub
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
        dt.AcceptChanges()

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtUrutan, RGJenis}, "AR_LAP_RETUR_PEMBELIAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "No. TTB", "Id Supplier", "Nilai Bruto", "Nilai Discount", "Nilai Netto", "No."}, "AR_LAP_RETUR_PEMBELIAN_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class


Public Class Editlaporanreturpembelian
    Inherits FrmCreateDSRPembelian
    Private Sub FrmCreateDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Jenis = JenisEnum.ReturPenjualan
        Text = "Edit Create Laporan Retur Pembelian"
        RGJenis.SelectedIndex = 0
        LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Columns.Clear()
        LayoutControlItem2.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem5.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 20, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 80, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 200, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 80, False, DevExpress.Utils.FormatType.Numeric, "n2")
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
        LoadData.GetData("SELECT NO_LAP, TGL, TGL_PENGAKUAN, DIVISI, GUDANG,URUTAN_LAP,JENIS_RETUR FROM AR_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan, RGJenis})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        Using dtcek = SelectCon.execute("select ID_LAP FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN where ID_LAP = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di ubah!")
                Exit Sub
            End If
        End Using
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi, TxtUrutan}) Then Exit Sub

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_LAP] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[GUDANG], URUTAN_LAP,JENIS_RETUR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, TxtKodeGudang, TxtUrutan, RGJenis, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_LAP_RETUR_PEMBELIAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "No. TTB", "Id Supplier", "Nilai Bruto", "Nilai Discount", "Nilai Netto", "No."}, "AR_LAP_RETUR_PEMBELIAN_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        Using dtcek = SelectCon.execute("select ID_LAP FROM AR_VALIDASI_LAP_RETUR_PEMBELIAN where ID_LAP = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Data sudah divalidasi, tidak bisa di hapus!")
                Exit Sub
            End If
        End Using
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_LAP_RETUR_PEMBELIAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_LAP_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
