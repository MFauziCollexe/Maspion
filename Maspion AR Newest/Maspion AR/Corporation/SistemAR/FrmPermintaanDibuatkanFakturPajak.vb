
Public MustInherit Class FrmPermintaanDibuatkanFakturPajak
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
        InitGrid.AddColumnGrid("Pilih", TypeCode.Boolean, 30, True)
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("No. PO", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Tanggal", TypeCode.DateTime, 60, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Jumlah", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns("Tanggal")
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yyyy"
        End With
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    'CUSTOMER
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIdCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtIdCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeCustomer.Text = ""
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

End Class


Public Class InputPermintaanDibuatkanFakturPajak
    Inherits FrmPermintaanDibuatkanFakturPajak

    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Permintaan Dibuatkan Faktur Pajak"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        TxtIdCustomer.Text = ""
        TxtIdCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Permintaan_FPajak)
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeCustomer.KeyPress
        If CharKeypress(TxtKodeCustomer, e) Then TxtIdCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Permintaan_FPajak)
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIdCustomer.EditValueChanged
        LoadData.GetData("SELECT CAST(0 as bit) PILIH, ROW_NUMBER() OVER(ORDER BY B.ID_TRANSAKSI) NOMOR, dbo.GetNoPO(B.KETERANGAN_CETAK) NO_PO, B.ID_TRANSAKSI, B.NO_NOTA, CAST(B.TGL_PENGAKUAN AS DATE), B.DPP+B.PPN TOTAL FROM V_AR_DSR_T_PENYERAHAN A JOIN NOTA B ON A.ID_NOTA=B.ID_TRANSAKSI WHERE A.ST=1 AND A.PG=0 AND A.BF=0 AND A.ID_CUSTOMER='" & TxtIdCustomer.Text & "'")
        LoadData.SetDataDetail(dt, False)
        GridView1.BestFitColumns()
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_PERMOHONAN FROM AR_PERMOHONAN_FAKTUR WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " ORDER BY NO_PERMOHONAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PDFP/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PDFP','') AS INT)),0) AS ID FROM AR_PERMOHONAN_FAKTUR")
            TxtIDTransaksi.Text = "PDFP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtKodeCustomer}) Then Exit Sub
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIdCustomer, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "AR_PERMOHONAN_FAKTUR") = False Then Exit Sub

            For Each dr As DataRow In dt.Rows
                If dr.Item("Pilih") = True Then
                    If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, ToObject(dr.Item("Id Nota")), ToObject(dr.Item("No."))}, "AR_PERMOHONAN_FAKTUR_DETAIL") = False Then Exit Sub
                End If
            Next

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditPermintaanDibuatkanFakturPajak
    Inherits FrmPermintaanDibuatkanFakturPajak

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Permintaan Dibuatkan Faktur Pajak"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_PERMOHONAN, TGL, ID_CUSTOMER FROM AR_PERMOHONAN_FAKTUR WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdCustomer})

        LoadData.GetData("SELECT CAST(1 AS BIT) PILIH, A.URUTAN, dbo.GetNoPO(B.KETERANGAN_CETAK), A.ID_NOTA, B.NO_NOTA, B.TGL_PENGAKUAN, B.DPP+B.PPN TOTAL FROM AR_PERMOHONAN_FAKTUR_DETAIL A JOIN NOTA B ON A.ID_NOTA=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeCustomer}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL ,[MDUSER] ,[MDTIME]", {TglTransaksi, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_PERMOHONAN_FAKTUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            If SQLServer.Delete("AR_PERMOHONAN_FAKTUR_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            For Each dr As DataRow In dt.Rows
                If dr.Item("Pilih") = True Then
                    If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, ToObject(dr.Item("Id Nota")), ToObject(dr.Item("No."))}, "AR_PERMOHONAN_FAKTUR_DETAIL") = False Then Exit Sub
                End If
            Next

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_PERMOHONAN_FAKTUR_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PERMOHONAN_FAKTUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_PERMOHONAN_FAKTUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
