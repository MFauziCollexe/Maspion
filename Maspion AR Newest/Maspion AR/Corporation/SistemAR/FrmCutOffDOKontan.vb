Imports DevExpress.XtraEditors.Controls

Public MustInherit Class FrmCutOffDOKontan
    Protected dt As New DataTable
    Protected Status_Edit As Boolean
    Private Sub FrmCutOffDOKontan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTTanggal.DateTime = Now.Date
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.String, 20, False,,,, , True)
        InitGrid.AddColumnGrid("No. DO Kontan", TypeCode.String, 80, True,,,, RepositoryItemButtonEdit1, True)
        InitGrid.AddColumnGrid("ID DO Kontan", TypeCode.String, 80, False,,,, , False)
        InitGrid.AddColumnGrid("Tanggal DO", TypeCode.DateTime, 80, False,,,,, True)
        InitGrid.AddColumnGrid("Kode Approve", TypeCode.String, 80, False,,,, , True)
        InitGrid.AddColumnGrid("Kode Customer", TypeCode.String, 50, False, ,,, , True)
        InitGrid.AddColumnGrid("Customer", TypeCode.String, 50, False,,,, , True)
        InitGrid.AddColumnGrid("DPP", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.AddColumnGrid("PPN", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.AddColumnGrid("Total", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.EndInit(GCDOKontan, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub GCDOKontan_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GCDOKontan.EditorKeyDown
        dt.AcceptChanges()
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "No. DO Kontan" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("No. DO Kontan").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("No. DO Kontan")
                            ' hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("No. DO Kontan")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("No. DO Kontan")
            End If
            ' hitung()
        End If
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        If TxtKodeDivisi.Text = "" Then Exit Sub
        paramnotacustomer = TxtKodeDivisi.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.DO_KONTAN_DIVISI)
        If kode = "" Then Exit Sub
        If dt.Select("ID DO Kontan = '" & kode & "'").Length = 1 Then Exit Sub
        Using dtload = SelectCon.execute("select 0 as urutan,NO_DO,ID_TRANSAKSI,TGL_PENGAKUAN,A.KODE_APPROVE,KODE_CUSTOMER,B.NAMA,DPP,PPN,DPP+PPN TOTAL from DELIVERY_ORDER a join customer b on a.KODE_APPROVE = b.KODE_APPROVE and a.KODE_CUSTOMER = b.ID where A.ID_TRANSAKSI = '" & kode & "'")
            If dtload.Rows.Count > 0 Then
                GridView1.GetFocusedDataRow(0) = GridView1.RowCount
                GridView1.GetFocusedDataRow(1) = dtload.Rows(0)(1)
                GridView1.GetFocusedDataRow(2) = dtload.Rows(0)(2)
                GridView1.GetFocusedDataRow(3) = dtload.Rows(0)(3)
                GridView1.GetFocusedDataRow(4) = dtload.Rows(0)(4)
                GridView1.GetFocusedDataRow(5) = dtload.Rows(0)(5)
                GridView1.GetFocusedDataRow(6) = dtload.Rows(0)(6)
                GridView1.GetFocusedDataRow(7) = dtload.Rows(0)(7)
                GridView1.GetFocusedDataRow(8) = dtload.Rows(0)(8)
                GridView1.GetFocusedDataRow(9) = dtload.Rows(0)(9)
                SendKeys.Send("{ENTER}")
            End If
        End Using
    End Sub

    Private Sub TxtKodeDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeDivisi.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Divisi)
        TxtKodeDivisi.Text = kode

    End Sub

    Private Sub TxtKodeDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeDivisi.EditValueChanged
        Using dtload = SelectCon.execute("select NAMA from DIVISI where KODE = '" & TxtKodeDivisi.Text & "'")
            If dtload.Rows.Count > 0 Then
                TxtNamaDivisi.Text = dtload.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub
End Class
Public Class inputcutoffdokontan
    Inherits FrmCutOffDOKontan
    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Cut Off DO Kontan"
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
        Using dtGenerate = SelectCon.execute("SELECT NO_CUTOFF FROM AR_CUTOFF_DO_KONTAN WHERE YEAR(TGL)=" & Format(DTTanggal.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(DTTanggal.EditValue, "MM") & "   ORDER BY NO_CUTOFF DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoBukti.Text = "CDO/" & Format(DTTanggal.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using
        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'CDO','') AS INT)),0) AS ID FROM AR_CUTOFF_DO_KONTAN")
            TxtIDTransaksi.Text = "CDO" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using

        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({DTTanggal, TxtKodeDivisi}) Then Exit Sub
        '    GridView1.CloseEditor()

        If Format(DTTanggal.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoBukti.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoBukti, DTTanggal, TxtKodeDivisi, TxtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_CUTOFF_DO_KONTAN") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(dt.Rows.Count - 1)("No. DO Kontan") = "" Then
                        dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    End If
                End If
                dt.AcceptChanges()
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoBukti.Text), "ID DO Kontan", "No. DO Kontan", "Tanggal DO", "Kode Approve", "Kode Customer", "DPP", "PPN", "Total", "No."}, "AR_CUTOFF_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub


End Class

Public Class editcutoffdokontan
    Inherits FrmCutOffDOKontan
    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Cut Off DO Kontan"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("select NO_CUTOFF,TGL,DIVISI,KETERANGAN from AR_CUTOFF_DO_KONTAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoBukti, DTTanggal, TxtKodeDivisi, TxtKeterangan})
        LoadData.GetData("select URUTAN,NO_DO_KONTAN,ID_DO_KONTAN,TANGGAL_DO,a.KODE_APPROVE,a.KODE_CUSTOMER,b.nama,DPP,PPN,TOTAL from AR_CUTOFF_DO_KONTAN_DETAIL a join customer b on a.kode_approve = b.kode_approve and a.kode_customer = b.ID  where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        LoadData.SetDataDetail(dt, False)

        On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({DTTanggal, TxtNoBukti, TxtKodeDivisi}) Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        If dt.Rows.Count > 0 Then
            If dt.Rows(dt.Rows.Count - 1)("No. DO Kontan") = "" Then
                dt.Rows.RemoveAt(dt.Rows.Count - 1)
            End If
        End If

        dt.AcceptChanges()
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL,DIVISI, KETERANGAN,[MDUSER] ,[MDTIME]", {DTTanggal, TxtKodeDivisi, TxtKeterangan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_CUTOFF_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_CUTOFF_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If dt.Rows.Count > 0 Then
                If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoBukti.Text), "ID DO Kontan", "No. DO Kontan", "Tanggal DO", "Kode Approve", "Kode Customer", "DPP", "PPN", "Total", "No."}, "AR_CUTOFF_DO_KONTAN_DETAIL") = False Then Exit Sub
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_CUTOFF_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_CUTOFF_DO_KONTAN_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_CUTOFF_DO_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class