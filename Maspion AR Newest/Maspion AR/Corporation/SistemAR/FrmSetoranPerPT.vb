Imports DevExpress.XtraEditors.Controls

Public MustInherit Class FrmSetoranPerPT
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean
    Private Sub CKTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles CKTransfer.CheckedChanged
        If CKTransfer.Checked = True Then
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Else
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtTransfer.Value = 0
            TxtBankTransfer.Text = ""
            TxtNamaBank.Text = ""
            TxtNamaPengirim.Text = ""
            TxtBiayaTransfer.Value = 0
        End If
    End Sub
    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
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
    Private Sub FrmSetoranPerPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("DO", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Id DSR", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("DSR", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Bruto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Std. Disc", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Add. Disc", TypeCode.Single, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Cash Disc", TypeCode.Single, 30, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Netto", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)
    End Sub
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)

        TxtIDCustomer.Text = kode
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        dt.Clear()
        AddRow(dt)
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtCustomer.Rows(0).Item("NAMA")
                TxtAlamatKirim.Text = dtCustomer.Rows(0).Item("ALAMAT_KANTOR")
            Else
                TxtNama.Text = ""
                TxtKodeApprove.Text = ""
                TxtAlamatKirim.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then
            Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
            TxtIDCustomer.Text = kode
        End If
    End Sub
    Sub Hitung()
        Dim total As Double = 0
        For Each dr As DataRow In dt.Rows
            total += dr("Netto")
        Next
        TxtSubTotal.Value = total
    End Sub

    Private Sub TxtPT_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPT.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from PT where KODE = '" & TxtPT.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaPT.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtPT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtPT.ButtonClick
        paramptcustomer = TxtIDCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.PT_Setoran)
        TxtPT.Text = kode
    End Sub

    Private Sub TxtBankTransfer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtBankTransfer.EditValueChanged
        Using dt = SelectCon.execute("select NAMA_BANK from AR_MASTER_BANK where ID_BANK = '" & TxtBankTransfer.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaBank.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtBankTransfer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtBankTransfer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Master_Bank)
        TxtBankTransfer.Text = kode
    End Sub

    Private Sub CKTunai_CheckedChanged(sender As Object, e As EventArgs) Handles CKTunai.CheckedChanged
        If CKTunai.Checked = True Then
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtTunai.Value = 0
        End If
    End Sub

    Private Sub CKGiro_CheckedChanged(sender As Object, e As EventArgs) Handles CKGiro.CheckedChanged
        If CKGiro.Checked = True Then
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtGiro.Value = 0
            TxtNoGiro.Text = ""
            TxtKodeBankGiro.Text = ""
            TxtNamaBankGiro.Text = ""
            TxtNamaPengirimGiro.Text = ""
        End If
    End Sub

    Private Sub TxtKodeApprove_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeApprove.EditValueChanged

    End Sub
End Class

Public Class InputSetoranPerPT
    Inherits FrmSetoranPerPT

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Setoran Per PT"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_SETORAN FROM AR_SETORAN_PER_PT WHERE NO_SETORAN Like 'SP/" & Format(TglPengakuan.EditValue, "yyMM") & "/%' ORDER BY NO_SETORAN DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "SP/" & Format(TglPengakuan.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'SP','') AS INT)),0) AS ID FROM AR_SETORAN_PER_PT")
            TxtIDTransaksi.Text = "SP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub GetDataDSR() Handles TxtIDCustomer.EditValueChanged
        Dim Filter = ""
        LoadData.GetData("SELECT ROW_NUMBER() OVER (ORDER BY CAST(RIGHT(Nota, 6) AS INT)) 'No.',* FROM ( SELECT DISTINCT ID_NOTA AS 'Id Nota', NO_NOTA AS 'Nota',NO_DO AS 'DO', ID_TRANSAKSI AS 'Id DSR', NO_DSR AS 'DSR', BRUTO AS 'Bruto', STD_DISC AS 'Std. Disc', ADD_DISC AS 'Add. Disc', CASH_DISC AS 'Cash Disc', NETTO AS 'Netto' FROM V_AR_D_DSR_T_TT WHERE ID_CUSTOMER='" & TxtIDCustomer.EditValue & "' AND ST=0) A  ORDER BY CAST(RIGHT(Nota, 6) AS INT)")
        LoadData.SetDataDetail(dt, False)
        Hitung()
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtKodeApprove, TglPengakuan, TxtPT}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, TxtSubTotal, txtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtTotalSetoran, CKTunai, CKGiro, CKTransfer, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtPT}, "AR_SETORAN_PER_PT") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id DSR", "DSR", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No."}, "AR_SETORAN_PER_PT_DETAIL") = False Then Exit Sub

            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub

End Class

Public Class EditSetoranPerPT
    Inherits FrmSetoranPerPT

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Setoran Per PT"
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_SETORAN, TGL, TGL_PENGAKUAN, ID_CUSTOMER, KETERANGAN,KODE_PT,TOTAL_SETORAN,status_tunai,status_giro,STATUS_TRANSFER,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER FROM AR_SETORAN_PER_PT WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDCustomer, txtKeterangan, TxtPT, TxtTotalSetoran, CKTunai, CKGiro, CKTransfer, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer})

        LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.NO_DO, A.ID_DSR, A.NO_DSR, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_SETORAN_PER_PT_DETAIL A WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        Hitung()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeApprove, TxtPT}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL, TGL_PENGAKUAN, ID_CUSTOMER, TOTAL, KETERANGAN ,TOTAL_SETORAN,STATUS_TUNAI,STATUS_GIRO,STATUS_TRANSFER,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER,KODE_PT,[MDUSER] ,[MDTIME]", {TglTransaksi, TglPengakuan, TxtIDCustomer, TxtSubTotal, txtKeterangan, TxtTotalSetoran, CKTunai, CKGiro, CKTransfer, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtPT, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_SETORAN_PER_PT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("AR_SETORAN_PER_PT_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Nota", "Nota", "DO", "Id DSR", "DSR", "Bruto", "Std. Disc", "Add. Disc", "Cash Disc", "Netto", "No."}, "AR_SETORAN_PER_PT_DETAIL") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_SETORAN_PER_PT_DETAIL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_SETORAN_PER_PT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_SETORAN_PER_PT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

End Class
