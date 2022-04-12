
Public MustInherit Class FrmPenyerahanNota
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

    'Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
    '    ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, TxtIDTransaksi.Text)
    '    Log.Cetak(Me, TxtIDTransaksi.Text)
    'End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 50, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("DO", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("DSR", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("No. Validasi", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Bruto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Std. Disc", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Add. Disc", TypeCode.Single, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Cash Disc", TypeCode.Single, 30, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Netto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Std. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Std. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Add. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Add. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Cash Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Cash Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub TxtKodeHeadCollector_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeHeadCollector.ButtonClick
        TxtKodeHeadCollector.Text = Search(FrmPencarian.KeyPencarian.Karyawan)
    End Sub
    Private Sub TxtKodeHeadCollector_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodeHeadCollector.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_USER FROM USERS WHERE ID_USER='" & TxtKodeHeadCollector.Text & "'", {TxtNamaHeadCollector})
    End Sub

    Private Sub TxtKodeCollector_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeCollector.ButtonClick
        TxtKodeCollector.Text = Search(FrmPencarian.KeyPencarian.Karyawan)
    End Sub
    Private Sub TxtKodeCollector_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodeCollector.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_USER FROM USERS WHERE ID_USER='" & TxtKodeCollector.Text & "'", {TxtNamaCollector})
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub Urutin()
        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("No.") = i + 1
        Next
    End Sub

    Private Sub TambahNota()
        If dt.Select("[Nota]='" & TxtCariNota.Text & "'").Count = 0 Then
            Using dtCari = SelectCon.execute("SELECT * FROM V_AR_DSR_T_PENYERAHAN WHERE ID_NOTA='" & TxtCariNota.Text & "' OR NO_NOTA='" & TxtCariNota.Text & "'")
                If dtCari.Rows.Count > 0 Then
                    If dtCari.Rows(0).Item("ST") = 0 Or dtCari.Rows(0).Item("ID_PENYERAHAN") = TxtIDTransaksi.Text Then
                        Dim dr = dt.NewRow
                        dr.Item("No.") = dt.Rows.Count + 1
                        dr.Item("Id Nota") = dtCari.Rows(0).Item("ID_NOTA")
                        dr.Item("Nota") = dtCari.Rows(0).Item("NO_NOTA")
                        dr.Item("DO") = dtCari.Rows(0).Item("NO_DO")
                        dr.Item("DSR") = dtCari.Rows(0).Item("NO_DSR")
                        dr.Item("No. Validasi") = dtCari.Rows(0).Item("NO_VALIDASI")
                        dr.Item("Id Customer") = dtCari.Rows(0).Item("ID_CUSTOMER")
                        dr.Item("Nama") = dtCari.Rows(0).Item("NAMA")
                        dr.Item("Bruto") = dtCari.Rows(0).Item("BRUTO")
                        dr.Item("Std. Disc") = dtCari.Rows(0).Item("STD_DISC")
                        dr.Item("Add. Disc") = dtCari.Rows(0).Item("ADD_DISC")
                        dr.Item("Cash Disc") = dtCari.Rows(0).Item("CASH_DISC")
                        dr.Item("Netto") = dtCari.Rows(0).Item("NETTO")
                        dt.Rows.Add(dr)
                        GridView1.BestFitColumns()
                        Urutin()
                    Else
                        MessageBox.Show("Nota sudah dibuatkan penyerahan dengan nomor `" & dtCari.Rows(0).Item("NO_PENYERAHAN") & "`!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Nomor Nota tidak ditemukan atau Nota belum divalidasi!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Else
            MessageBox.Show("Nota sudah dimasukkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        TxtCariNota.EditValue = ""
    End Sub

    Private Sub TxtCariNota_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCariNota.KeyDown
        If e.KeyCode = Keys.Enter Then
            TambahNota()
        End If
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        TambahNota()
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            Urutin()
        End If
    End Sub
End Class


Public Class InputPenyerahanNota
    Inherits FrmPenyerahanNota

    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Penyerahan Nota"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_PENYERAHAN FROM AR_PENYERAHAN_NOTA WHERE NO_PENYERAHAN Like 'PN-" & Format(TglTransaksi.EditValue, "yyMM") & "-%' ORDER BY NO_PENYERAHAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PN-" & Format(TglTransaksi.EditValue, "yyMM") & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PN','') AS INT)),0) AS ID FROM AR_PENYERAHAN_NOTA")
            TxtIDTransaksi.Text = "PN" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtKodeHeadCollector, TxtKodeCollector}) Then Exit Sub
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtKodeHeadCollector, TxtKodeCollector, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_PENYERAHAN_NOTA") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "No."}, "AR_PENYERAHAN_NOTA_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditPenyerahanNota
    Inherits FrmPenyerahanNota

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Penyerahan Nota"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_PENYERAHAN, TGL, HEAD_COLLECTOR, COLLECTOR FROM AR_PENYERAHAN_NOTA WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtKodeHeadCollector, TxtKodeCollector})

        LoadData.GetData("SELECT AA.URUTAN, A.ID_NOTA, A.NO_NOTA, A.NO_DO, A.NO_DSR, A.NO_VALIDASI, A.ID_CUSTOMER, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, 
        A.CASH_DISC, A.NETTO FROM AR_PENYERAHAN_NOTA_DETAIL AA JOIN V_AR_DSR_T_PENYERAHAN A ON A.ID_NOTA=AA.ID_NOTA JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID 
        WHERE AA.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY AA.URUTAN")
        LoadData.SetDataDetail(dt, False)
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeCollector, TxtKodeHeadCollector}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_PENYERAHAN, TGL, HEAD_COLLECTOR, COLLECTOR ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TxtKodeHeadCollector, TxtKodeCollector, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_PENYERAHAN_NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PENYERAHAN_NOTA_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "No."}, "AR_PENYERAHAN_NOTA_DETAIL") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_PENYERAHAN_NOTA_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PENYERAHAN_NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_PENYERAHAN_NOTA", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
