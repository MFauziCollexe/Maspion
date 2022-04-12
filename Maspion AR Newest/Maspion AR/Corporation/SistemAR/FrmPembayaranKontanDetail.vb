Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmPembayaranKontanDetail
    Protected Status_Edit As Boolean
    Protected dt As New DataTable
    Protected dt2 As New DataTable
    Protected dt3 As New DataTable
    Dim aBankMasuk = Akun.BANK_MASUK_KONTAN
    Dim akasmasuk = Akun.KAS_MASUK_KONTAN
    Dim agiro = Akun.PIUTANG_GIRO_PW_KONTAN
    Dim setup As New SetupAkun
    Private Sub FrmPembayaranKontanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        DTTglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
        DTTglValuta.DateTime = Format(Now.Date, "dd/MM/yyyy")
        DTTanggalGiro.DateTime = Format(Now.Date, "dd/MM/yyyy")
        DTTanggalTransfer.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtPembulatan.Value = 0
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView2.OptionsView.ColumnAutoWidth = False
        GridView3.OptionsView.ColumnAutoWidth = False

        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id Retur", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. Retur", TypeCode.String, 80, True,,,, RepoCari, True)
        InitGrid.AddColumnGrid("Total Retur", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc)
        InitGrid.EndInit(TBDO, GridView1, dt)
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id CN / DN", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. CN / DN", TypeCode.String, 80, True,,,, RepoCari2, True)
        InitGrid.AddColumnGrid("Total CN / DN", TypeCode.Single, 50, False, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc2)
        InitGrid.EndInit(GridControl1, GridView2, dt2)
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Id Pengembalian", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("No. Pengembalian", TypeCode.String, 80, True,,,, RepoCari3, True)
        InitGrid.AddColumnGrid("Total Pengembalian", TypeCode.Single, 50, True, DevExpress.Utils.FormatType.Numeric, "n2",, RepoCalc3)
        InitGrid.EndInit(GridControl2, GridView3, dt3)
        AddRow(dt)
        AddRow(dt2)
        AddRow(dt3)
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
    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub TxtKodeCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeCustomer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        TxtIDCustomer.Text = kode
        Using dtcust = SelectCon.execute("select KODE_APPROVE from customer where ID = '" & kode & "'")
            If dtcust.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtcust.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeCustomer.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from CUSTOMER where ID = '" & TxtIDCustomer.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaCustomer.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        Dim kode = Search(FrmPencarian.KeyPencarian.Divisi)
        TxtKodeDivisi.Text = kode
    End Sub

    Private Sub TxtKodeDivisi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeDivisi.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from DIVISI where KODE = '" & TxtKodeDivisi.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaDivisi.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtNota_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        '     If TxtIDCustomer.Text = "" Then Exit Sub
        paramnotacustomer = ""
        Dim kode = Search(FrmPencarian.KeyPencarian.DO_KONTAN)
        TxtIDNota.Text = kode
        Using dtcek = SelectCon.execute("select NO_DO,DIVISI,DPP + PPN TOTAL,KODE_CUSTOMER from DELIVERY_ORDER where ID_TRANSAKSI = '" & kode & "'")
            If dtcek.Rows.Count > 0 Then
                'TxtNoDO.Text = dtcek.Rows(0)(0)
                TxtKodeDivisi.Text = dtcek.Rows(0)(1)
                TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
                TxtIDCustomer.Text = dtcek.Rows(0)(3)
            End If
        End Using
    End Sub
    Sub hitung()
        On Error Resume Next
        Dim totalretur As Double = 0
        Dim totalcn As Double = 0
        Dim totalsisa As Double = 0
        dt.AcceptChanges()
        dt2.AcceptChanges()
        dt3.AcceptChanges()
        totalretur = dt.Compute("sum([Total Retur])", "")
        totalcn = dt2.Compute("sum([Total CN / DN])", "")
        totalsisa = dt3.Compute("sum([Total Pengembalian])", "")
        If TxtTunai.Value + TxtTransfer.Value + TxtGiro.Value + totalretur + totalcn < TxtNilaiDOKontan.Value Then
            TxtNilaiPembayaran.Value = (TxtTunai.Value + TxtTransfer.Value + TxtGiro.Value - totalretur - totalcn + totalsisa) + TxtPembulatan.Value
        Else
            TxtNilaiPembayaran.Value = (TxtTunai.Value + TxtTransfer.Value + TxtGiro.Value - totalretur - totalcn + totalsisa) - TxtPembulatan.Value
        End If
    End Sub


    Private Sub CKTunai_CheckedChanged(sender As Object, e As EventArgs) Handles CKTunai.CheckedChanged
        If CKTunai.Checked = True Then
            TxtKodeAkunTunai.Text = setup.GetAkun(akasmasuk)
            LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem42.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            '  CKTransfer.Enabled = False
        Else
            'If CKGiro.Checked = False Then
            '    CKTransfer.Enabled = True
            'Else
            '    CKTransfer.Enabled = False
            'End If
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem42.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtTunai.Value = 0
        End If
    End Sub

    Private Sub CKGiro_CheckedChanged(sender As Object, e As EventArgs) Handles CKGiro.CheckedChanged
        If CKGiro.Checked = True Then
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem40.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem43.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem47.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            TxtKodeAkunGiro.Text = setup.GetAkun(agiro)

            '     CKTransfer.Enabled = False
        Else
            'If CKTunai.Checked = False Then
            '    CKTransfer.Enabled = True
            'Else
            '    CKTransfer.Enabled = False
            'End If
            TxtKodeAkunGiro.Text = ""
            TxtGiro.Value = 0
            TxtKodeBankInfoGiro.Text = ""
            TxtKodeBankGiro.Text = ""
            DTTanggalGiro.DateTime = Format(Now.Date, "dd/MM/yyyy")
            TxtNamaPengirimGiro.Text = ""
            LayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem40.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem43.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem47.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub CKTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles CKTransfer.CheckedChanged
        If CKTransfer.Checked = True Then
            TxtKodeAkunTransfer.Text = setup.GetAkun(aBankMasuk)
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem41.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem44.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem48.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            '     CKTunai.Enabled = False
            '    CKGiro.Enabled = False
        Else
            '   CKTunai.Enabled = True
            '  CKGiro.Enabled = True
            TxtTransfer.Value = 0
            TxtBankTransfer.Text = ""
            TxtNamaPengirim.Text = ""
            TxtBiayaTransfer.Value = 0
            TxtNamaPengirim.Text = ""
            DTTanggalTransfer.DateTime = Format(Now.Date, "dd/MM/yyyy")
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem41.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem44.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem48.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub TxtBankTransfer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtBankTransfer.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_BANK from AR_MASTER_BANK where ID_BANK = '" & TxtBankTransfer.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaBank.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtBankTransfer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtBankTransfer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Master_Bank)
        TxtBankTransfer.Text = kode
    End Sub

    Private Sub TxtTunai_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTunai.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtGiro_EditValueChanged(sender As Object, e As EventArgs) Handles TxtGiro.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtTransfer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTransfer.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtIDCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeCustomer.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeCustomer.Text = ""
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button1.ItemClick

    End Sub

    Private Sub TxtIDNota_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDNota.EditValueChanged
        Using dtcek = SelectCon.execute("select DELIVERY_ORDER.NO_DO,DIVISI,DPP + PPN - isnull(B.TOTAL_BAYAR,0)  + isnull(ARK.TOTAL,0) TOTAL,DELIVERY_ORDER.ID_TRANSAKSI from DELIVERY_ORDER left join V_AR_D_DO_T_PEMBAYARAN_KONTAN B ON DELIVERY_ORDER.ID_TRANSAKSI = b.id_TRANSAKSI left join AR_PEMBAYARAN_KONTAN ARK on ARK.ID_DO_KONTAN = DELIVERY_ORDER.ID_TRANSAKSI where DELIVERY_ORDER.ID_TRANSAKSI = '" & TxtIDNota.Text & "' and ARK.ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                'TxtNoDO.Text = dtcek.Rows(0)(0)
                TxtKodeDivisi.Text = dtcek.Rows(0)(1)
                ' TxtIDNota.Text = dtcek.Rows(0)(3)
                TxtNilaiDOKontan.Value = dtcek.Rows(0)(2)
            End If
        End Using
    End Sub

    Private Sub TxtPembulatan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPembulatan.EditValueChanged
        hitung()
    End Sub

    Private Sub TxtKodeBankGiro_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeBankGiro.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_BANK from AR_MASTER_BANK where ID_BANK = '" & TxtKodeBankGiro.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaBankGiro.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeBankGiro_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeBankGiro.ButtonClick
        divisibank = TxtKodeDivisi.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.Master_Bank)
        TxtKodeBankGiro.Text = kode
    End Sub

    Private Sub CKRetur_CheckedChanged(sender As Object, e As EventArgs) Handles CKRetur.CheckedChanged
        If CKRetur.Checked = True Then
            LayoutControlItem32.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem32.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub CKCNDN_CheckedChanged(sender As Object, e As EventArgs) Handles CKCNDN.CheckedChanged
        If CKCNDN.Checked = True Then
            LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub RepoCari_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari.ButtonClick
        If TxtKodeCustomer.Text = "" Then
            Exit Sub
        End If
        paramreturcustomer = TxtKodeCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.Retur_Penjualan)

        If kode <> "" Then
            Using dtget = SelectCon.execute("select DPP+PPN,NO_NOTA_RETUR from retur_penjualan where ID_TRANSAKSI = '" & kode & "'")
                If dtget.Rows.Count > 0 Then
                    GridView1.GetFocusedDataRow(0) = kode
                    GridView1.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView1.GetFocusedDataRow(1) = dtget.Rows(0)(1)
                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub RepoCari2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari2.ButtonClick
        If TxtKodeCustomer.Text = "" Then
            Exit Sub
        End If
        paramcndncustomer = TxtKodeCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.CN_DN)
        GridView2.GetFocusedDataRow(1) = kode
        If kode <> "" Then
            Using dtget = SelectCon.execute("select JUMLAH,ID_TRANSAKSI from DEBIT_KREDIT_NOTE where NO_TRANSAKSI = '" & kode & "' and JENIS = 'Kredit'")
                If dtget.Rows.Count > 0 Then

                    GridView2.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView2.GetFocusedDataRow(0) = dtget.Rows(0)(1)
                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("No. Retur")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("No. Retur")
            End If
            hitung()
        End If
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles TBDO.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "No. Retur" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("No. Retur").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("No. Retur")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub GridView2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView2.KeyUp
        If e.KeyCode = 46 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.FocusedColumn = GridView2.Columns(0)
            If GridView2.RowCount = 0 Then
                AddRow(dt2)
                GridView2.FocusedColumn = GridView2.Columns(0)
            End If
            hitung()
        End If
    End Sub

    Private Sub GridControl1_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView2.FocusedColumn.FieldName = "No. CN / DN" Then
                    If GridView2.FocusedRowHandle = GridView2.RowCount - 1 Then
                        If Len(GridView2.GetFocusedRow("No. CN / DN").ToString.Trim) > 0 Then
                            AddRow(dt2)
                            GridView2.FocusedColumn = GridView2.Columns("No. CN / DN")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            LayoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub RepoCari3_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoCari3.ButtonClick
        If TxtKodeCustomer.Text = "" Then
            Exit Sub
        End If
        paramnotacustomer = TxtKodeCustomer.Text
        Dim kode = Search(FrmPencarian.KeyPencarian.PENGEMBALIAN_DO_KONTAN)
        If kode <> "" Then
            Using dtget = SelectCon.execute("select isnull(SISA,0) - isnull(SISA_TERPAKAI,0),NO_PENGEMBALIAN from V_AR_SISA_PENGEMBALIAN_DO_KONTAN where ID_TRANSAKSI = '" & kode & "' ")
                If dtget.Rows.Count > 0 Then
                    GridView3.GetFocusedDataRow(0) = kode
                    GridView3.GetFocusedDataRow(2) = dtget.Rows(0)(0)
                    GridView3.GetFocusedDataRow(1) = dtget.Rows(0)(1)
                    SendKeys.Send("{ENTER}")
                    hitung()
                End If
            End Using
        End If
    End Sub

    Private Sub GridView3_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView3.KeyUp
        If e.KeyCode = 46 Then
            GridView3.DeleteRow(GridView3.FocusedRowHandle)
            GridView3.FocusedColumn = GridView3.Columns("No. Pengembalian")
            If GridView3.RowCount = 0 Then
                AddRow(dt3)
                GridView3.FocusedColumn = GridView3.Columns("No. Pengembalian")
            End If
            hitung()
        End If
    End Sub

    Private Sub GridControl2_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView3.FocusedColumn.FieldName = "No. Pengembalian" Then
                    If GridView3.FocusedRowHandle = GridView3.RowCount - 1 Then
                        If Len(GridView3.GetFocusedRow("No. Pengembalian").ToString.Trim) > 0 Then
                            AddRow(dt3)
                            GridView3.FocusedColumn = GridView3.Columns("No. Pengembalian")
                            hitung()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub TxtKodeAkunTunai_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeAkunTunai.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & TxtKodeAkunTunai.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaAkunTunai.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeAkunTunai_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeAkunTunai.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        TxtKodeAkunTunai.Text = kode
    End Sub

    Private Sub TxtKodeAkunGiro_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeAkunGiro.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        TxtKodeAkunGiro.Text = kode
    End Sub

    Private Sub TxtKodeAkunTransfer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeAkunTransfer.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        TxtKodeAkunTransfer.Text = kode
    End Sub

    Private Sub TxtKodeAkunGiro_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeAkunGiro.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & TxtKodeAkunGiro.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaAkunGiro.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodeAkunTransfer_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeAkunTransfer.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & TxtKodeAkunTransfer.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaAkunTransfer.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub GridView3_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanging
        hitung()
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        hitung()
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        hitung()
    End Sub

    Private Sub RepoCalc3_EditValueChanged(sender As Object, e As EventArgs) Handles RepoCalc3.EditValueChanged
        hitung()
    End Sub

    Private Sub RepoCalc2_EditValueChanged(sender As Object, e As EventArgs) Handles RepoCalc2.EditValueChanged
        hitung()
    End Sub

    Private Sub RepoCalc_EditValueChanged(sender As Object, e As EventArgs) Handles RepoCalc.EditValueChanged
        hitung()
    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TxtKodeBankInfoGiro_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeBankInfoGiro.ButtonClick
        divisibank = TxtKodeDivisi.Text

        Dim kode = Search(FrmPencarian.KeyPencarian.Master_Bank_Giro)
        TxtKodeBankInfoGiro.Text = kode
    End Sub

    Private Sub TxtKodeBankInfoGiro_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeBankInfoGiro.EditValueChanged
        Using dtget = SelectCon.execute("select NAMA_BANK from AR_MASTER_BANK where ID_BANK = '" & TxtKodeBankInfoGiro.Text & "'")
            If dtget.Rows.Count > 0 Then
                TxtNamaInfoBankGiro.Text = dtget.Rows(0)(0)
            End If
        End Using
    End Sub
End Class
Public Class InputPembayaranKontanDetail
    Inherits FrmPembayaranKontanDetail

    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Pembayaran DO Kontan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
        TxtBiayaTransfer.Value = 0
        TxtNilaiDOKontan.Value = 0

    End Sub

    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)

    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        If CKTransfer.Checked = False Then
            Using dtGenerate = SelectCon.execute("SELECT NO_PEMBAYARAN FROM AR_PEMBAYARAN_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " and isnull(STATUS_TRANSFER,0) = 0 ORDER BY NO_PEMBAYARAN DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "PDK/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
            End Using
        Else
            Using dtGenerate = SelectCon.execute("SELECT NO_PEMBAYARAN FROM AR_PEMBAYARAN_KONTAN WHERE YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND MONTH(TGL)=" & Format(TglTransaksi.EditValue, "MM") & " and isnull(STATUS_TRANSFER,0) = 1 ORDER BY NO_PEMBAYARAN DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
            End Using
            TxtNoTransaksi.Text = "PDK/KU/" & Format(TglTransaksi.EditValue, "yyMM") & "/" & Format(urut, "000000")
        End If
        If CKTransfer.Checked = True Then
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(REPLACE(ID_TRANSAKSI,'PDKKU',''),'PDK','') AS INT)),0) AS ID FROM AR_PEMBAYARAN_KONTAN")
                TxtIDTransaksi.Text = "PDKKU" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using

        Else
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(REPLACE(ID_TRANSAKSI,'PDKKU',''),'PDK','') AS INT)),0) AS ID FROM AR_PEMBAYARAN_KONTAN")
                TxtIDTransaksi.Text = "PDK" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using

        End If
        Return True
    End Function


    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick

        If Empty({TglTransaksi, TxtKodeCustomer}) Then Exit Sub
        '    GridView1.CloseEditor()
        If CKGiro.Checked = True Then
            If DTTglValuta.DateTime <> DTTanggalGiro.DateTime Then
                MsgBox("Tanggal Giro harus sama dengan tanggal valuta !")
                Exit Sub
            End If
        End If

        If CKTransfer.Checked = True Then
            If DTTglValuta.DateTime <> DTTanggalTransfer.DateTime Then
                MsgBox("Tanggal Transfer harus sama dengan tanggal valuta !")
                Exit Sub
            End If
        End If
        If RadioGroup1.SelectedIndex = 0 Then
            If TxtNilaiPembayaran.Value <> TxtNilaiDOKontan.Value Then
                MsgBox("Nominal Pembayaran tidak boleh beda dengan Nilai DO Kontan")
                Exit Sub
            End If
        Else
            If TxtNilaiPembayaran.Value > TxtNilaiDOKontan.Value Then
                MsgBox("Nominal Pembayaran tidak boleh beda dengan Nilai DO Kontan")
                Exit Sub
            End If
        End If
        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Using SQLServer As New SQLServerTransaction
        '    SQLServer.InitTransaction()
        '    'Header
        '    If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIDCustomer, TxtNoDO, CKTunai, CKGiro, CKTransfer, TxtTunai, TxtTransfer, TxtGiro, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtKeterangan, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtNilaiPembayaran, TxtIDNota, TxtPembulatan, TxtNoGiro, TxtNamaPengirimGiro, TxtKodeBankGiro, DTTglPengakuan, CKRetur, CKCNDN, RadioGroup1, CheckEdit1, DTTglValuta, TxtKodeAkunTunai, TxtKodeAkunTransfer, TxtKodeAkunGiro, TxtKodeBankInfoGiro, DTTanggalGiro, DTTanggalTransfer}, "AR_PEMBAYARAN_KONTAN") = False Then Exit Sub
        '    If SQLServer.InsertHeader({TxtIDNota, TxtIDCustomer, TxtNoDO, TxtNilaiDOKontan, DTTglPengakuan, TxtNilaiPembayaran, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "MONITORING_PAYMENT") = False Then Exit Sub
        '    If dt.Rows.Count > 0 Or dt2.Rows.Count > 0 Then
        '        If dt.Rows.Count > 0 Then
        '            If dt.Rows(dt.Rows.Count - 1)("No. Retur") = "" Then
        '                dt.Rows.RemoveAt(dt.Rows.Count - 1)
        '            End If
        '        End If
        '        If dt2.Rows.Count > 0 Then
        '            If dt2.Rows(dt2.Rows.Count - 1)("No. CN / DN") = "" Then
        '                dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
        '            End If
        '        End If
        '        If dt3.Rows.Count > 0 Then
        '            If dt3.Rows(dt3.Rows.Count - 1)("No. Pengembalian") = "" Then
        '                dt3.Rows.RemoveAt(dt3.Rows.Count - 1)
        '            End If
        '        End If

        '        dt.AcceptChanges()
        '        dt2.AcceptChanges()
        '        dt3.AcceptChanges()
        '        If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Retur", "No. Retur", "Total Retur"}, "AR_PEMBAYARAN_KONTAN_DETAIL_RETUR") = False Then Exit Sub
        '        If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id CN / DN", "No. CN / DN", "Total CN / DN"}, "AR_PEMBAYARAN_KONTAN_DETAIL_CNDN") = False Then Exit Sub
        '        If SQLServer.InsertDetail(dt3, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Pengembalian", "No. Pengembalian", "Total Pengembalian"}, "AR_PEMBAYARAN_KONTAN_DETAIL_SISA_PENGEMBALIAN") = False Then Exit Sub
        '    End If

        '    'proses jurnal
        '    Dim Setup As New SetupAkun
        '    Dim namapt As String = ""
        '    Dim kodept As String = ""
        '    Using dtcek = SelectCon.execute("select a.KODE_PT,c.NAMA NAMA_PT from LINK_PT_SBU  a join link_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join PT C ON C.KODE =a.KODE_PT where B.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '        If dtcek.Rows.Count > 0 Then
        '            namapt = dtcek.Rows(0)(1)
        '            kodept = dtcek.Rows(0)(0)
        '        End If
        '    End Using
        '    If CKTransfer.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtTransfer.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTransfer.Text, TxtNamaBank.Text, TxtTransfer.Value))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtTransfer.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTransfer.Text, ProsesJurnal.jeniskasbank.Bank_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTransfer.Text, TxtNamaBank.Text, TxtTransfer.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTransfer.Value))
        '            ProsJurnalucf.AddKasBank(New DetailKasBank(Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTransfer.Value))
        '            ProsJurnalucf.Submit()
        '        End If

        '    End If
        '    If CKTunai.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtTunai.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTunai.Text, TxtNamaAkunTunai.Text, TxtTunai.Value))

        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtTunai.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTunai.Text, ProsesJurnal.jeniskasbank.Kas_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTunai.Text, TxtNamaAkunTunai.Text, TxtTunai.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTunai.Value))
        '            ProsJurnalucf.AddKasBank(New DetailKasBank(Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTunai.Value))
        '            ProsJurnalucf.Submit()
        '        End If


        '    End If
        '    If CKGiro.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtGiro.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtGiro.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtGiro.Value))
        '            ProsJurnalucf.Submit()
        '        End If

        '    End If
        '    If CKCNDN.Checked = True Then

        '    End If
        '    If CKRetur.Checked = True Then

        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtGiro.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtGiro.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtGiro.Value))
        '            ProsJurnalucf.Submit()
        '        End If


        '    End If
        '    If CheckEdit1.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Dim totalpengembalian As Double = 0
        '        dt3.AcceptChanges()
        '        totalpengembalian = dt3.Compute("SUM([Total Pengembalian])", "")
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", totalpengembalian))
        '        Else
        '            Dim apndisisasby = "PENGEMBALIAN_PT_" & TxtKodeDivisi.Text
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndisisasby), Setup.GetNamaAkun(Setup.GetAkun(apndisisasby)), totalpengembalian))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, totalpengembalian))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim apndisisa = Akun.PNDI_PW_KONTAN
        '            Dim ahndisisa = Akun.HNDI_UCF_PW_KONTAN
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndisisa), "PNDI B.M PERWAKILAN JAKARTA", totalpengembalian))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", totalpengembalian))
        '            'If totalpengembalian - TxtNilaiDOKontan.Value > 0 Then
        '            '    ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahndisisa), "HNDI B.M PERWAKILAN JAKARTA", totalpengembalian - TxtNilaiDOKontan.Value > 0))
        '            'End If
        '            ProsJurnalucf.Submit()
        '        End If


        '        'Dim apiutangutd = Akun.PIUTANG_DAGANG_UT_PW_KONTAN_D
        '        'Dim ahndiucfpw = Akun.HNDI_PW_KONTAN
        '        'Dim apndiucfpw = Akun.PNDI_UCF_PW_KONTAN
        '        'Dim apiutangutk = Akun.PIUTANG_DAGANG_UT_PW_KONTAN_K
        '        'Dim notrans As String = ""
        '        'notrans = Strings.Right(TxtNoTransaksi.Text, 6)
        '        'Dim prosjurnalpw As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "Perwakilan", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        'prosjurnalpw.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangutd), "DIPERHITUNGKAN UM JKT NO. " & notrans & " TGL " & Format(DTTglPengakuan.DateTime, "dd/MM/yy") & " A/N " & TxtNamaCustomer.Text, totalpengembalian))

        '    End If
        '    SQLServer.EndTransaction()
        '    Batal()
        'End Using
    End Sub


End Class

Public Class EditPembayaranKontanDetail
    Inherits FrmPembayaranKontanDetail

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtBiayaTransfer.Value = 0
        TxtNilaiDOKontan.Value = 0
        Text = "Edit Pembayaran DO Kontan"
        Status_Edit = True
        'TxtNoDO.Enabled = False
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        'LoadData.GetData("select NO_PEMBAYARAN,TGL,ID_CUSTOMER,NO_DO_KONTAN,STATUS_TUNAI,STATUS_GIRO,STATUS_TRANSFER,NOMINAL_TUNAI,NOMINAL_GIRO,NOMINAL_TRANSFER,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER,KETERANGAN,TOTAL,ID_DO_KONTAN,PEMBULATAN,NO_GIRO,NAMA_PENGIRIM_GIRO,BANK_GIRO,TGL_PENGAKUAN,STATUS_RETUR,STATUS_CNDN,STATUS_PEMBAYARAN_PENUH,STATUS_SISA,TGL_VALUTA,KODE_AKUN_TUNAI,KODE_AKUN_TRANSFER,KODE_AKUN_GIRO,BANK_PENGIRIM_GIRO,TGL_GIRO,TGL_TRANSFER from AR_PEMBAYARAN_KONTAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        'LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIDCustomer, TxtNoDO, CKTunai, CKGiro, CKTransfer, TxtTunai, TxtGiro, TxtTransfer, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtKeterangan, TxtNilaiPembayaran, TxtIDNota, TxtPembulatan, TxtNoGiro, TxtNamaPengirimGiro, TxtKodeBankGiro, DTTglPengakuan, CKRetur, CKCNDN, RadioGroup1, CheckEdit1, DTTglValuta, TxtKodeAkunTunai, TxtKodeAkunTransfer, TxtKodeAkunGiro, TxtKodeBankInfoGiro, DTTanggalGiro, DTTanggalTransfer})
        'LoadData.GetData("select ID_RETUR,NO_RETUR,NOMINAL from AR_PEMBAYARAN_KONTAN_DETAIL_RETUR where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        'LoadData.SetDataDetail(dt, False)
        'LoadData.GetData("select ID_CNDN,NO_CNDN,NOMINAL from AR_PEMBAYARAN_KONTAN_DETAIL_CNDN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        'LoadData.SetDataDetail(dt2, False)
        'LoadData.GetData("select ID_PENGEMBALIAN,NO_PENGEMBALIAN,NOMINAL from AR_PEMBAYARAN_KONTAN_DETAIL_SISA_PENGEMBALIAN where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
        'LoadData.SetDataDetail(dt3, False)
        'hitung()
        'On Error Resume Next
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeCustomer}) Then Exit Sub
        If RadioGroup1.SelectedIndex = 0 Then
            If TxtNilaiPembayaran.Value <> TxtNilaiDOKontan.Value Then
                MsgBox("Nominal Pembayaran tidak boleh beda dengan Nilai DO Kontan")
                Exit Sub
            End If
        Else
            If TxtNilaiPembayaran.Value > TxtNilaiDOKontan.Value Then
                MsgBox("Nominal Pembayaran tidak boleh beda dengan Nilai DO Kontan")
                Exit Sub
            End If
        End If
        If CKGiro.Checked = True Then
            If DTTglValuta.DateTime <> DTTanggalGiro.DateTime Then
                MsgBox("Tanggal Giro harus sama dengan tanggal valuta !")
                Exit Sub
            End If
        End If

        If CKTransfer.Checked = True Then
            If DTTglValuta.DateTime <> DTTanggalTransfer.DateTime Then
                MsgBox("Tanggal Transfer harus sama dengan tanggal valuta !")
                Exit Sub
            End If
        End If
        If QuestionEdit() = False Then Exit Sub
        If dt.Rows.Count > 0 Then
            If dt.Rows(dt.Rows.Count - 1)("No. Retur") = "" Then
                dt.Rows.RemoveAt(dt.Rows.Count - 1)
            End If
        End If
        If dt2.Rows.Count > 0 Then
            If dt2.Rows(dt2.Rows.Count - 1)("No. CN / DN") = "" Then
                dt2.Rows.RemoveAt(dt2.Rows.Count - 1)
            End If
        End If
        If dt3.Rows.Count > 0 Then
            If dt3.Rows(dt3.Rows.Count - 1)("No. Pengembalian") = "" Then
                dt3.Rows.RemoveAt(dt3.Rows.Count - 1)
            End If
        End If
        dt.AcceptChanges()
        dt2.AcceptChanges()
        dt3.AcceptChanges()

        'Using SQLServer As New SQLServerTransaction
        '    SQLServer.InitTransaction()
        '    'Header()
        '    If SQLServer.UpdateHeader("TGL,ID_CUSTOMER, TOTAL, STATUS_TRANSFER,STATUS_TUNAI,STATUS_GIRO,BANK_TRANSFER,NAMA_PENGIRIM,BIAYA_TRANSFER,ID_DO_KONTAN, KETERANGAN,NOMINAL_TUNAI,NOMINAL_TRANSFER,NOMINAL_GIRO,NO_DO_KONTAN,PEMBULATAN,NO_GIRO,NAMA_PENGIRIM_GIRO,BANK_GIRO,TGL_PENGAKUAN,STATUS_RETUR,STATUS_CNDN,STATUS_PEMBAYARAN_PENUH,STATUS_SISA,TGL_VALUTA,KODE_AKUN_TUNAI,KODE_AKUN_TRANSFER,KODE_AKUN_GIRO,BANK_PENGIRIM_GIRO,TGL_GIRO,TGL_TRANSFER,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtIDCustomer, TxtNilaiPembayaran, CKTransfer, CKTunai, CKGiro, TxtBankTransfer, TxtNamaPengirim, TxtBiayaTransfer, TxtIDNota, TxtKeterangan, TxtTunai, TxtTransfer, TxtGiro, TxtNoDO, TxtPembulatan, TxtNoGiro, TxtNamaPengirimGiro, TxtKodeBankGiro, DTTglPengakuan, CKRetur, CKCNDN, RadioGroup1, CheckEdit1, DTTglValuta, TxtKodeAkunTunai, TxtKodeAkunTransfer, TxtKodeAkunGiro, TxtKodeBankInfoGiro, DTTanggalGiro, DTTanggalTransfer, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_PEMBAYARAN_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
        '    If SQLServer.UpdateHeader("ID_CUSTOMER,NO_TRANSAKSI,TAGIHAN,TGL_PAYMENT,BAYAR", {TxtIDCustomer, TxtNoDO, TxtNilaiDOKontan, DTTglPengakuan, TxtNilaiPembayaran}, "MONITORING_PAYMENT", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub

        '    If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
        '    If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_CNDN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
        '    If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_SISA_PENGEMBALIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

        '    If dt.Rows.Count > 0 Or dt2.Rows.Count > 0 Or dt3.Rows.Count > 0 Then
        '        If SQLServer.InsertDetail(dt, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Retur", "No. Retur", "Total Retur"}, "AR_PEMBAYARAN_KONTAN_DETAIL_RETUR") = False Then Exit Sub
        '        If SQLServer.InsertDetail(dt2, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id CN / DN", "No. CN / DN", "Total CN / DN"}, "AR_PEMBAYARAN_KONTAN_DETAIL_CNDN") = False Then Exit Sub
        '        If SQLServer.InsertDetail(dt3, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "Id Pengembalian", "No. Pengembalian", "Total Pengembalian"}, "AR_PEMBAYARAN_KONTAN_DETAIL_SISA_PENGEMBALIAN") = False Then Exit Sub

        '    End If

        '    'proses jurnal
        '    Dim Setup As New SetupAkun
        '    Dim namapt As String = ""
        '    Dim kodept As String = ""
        '    Using dtcek = SelectCon.execute("select a.KODE_PT,c.NAMA NAMA_PT from LINK_PT_SBU  a join link_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join PT C ON C.KODE =a.KODE_PT where B.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '        If dtcek.Rows.Count > 0 Then
        '            namapt = dtcek.Rows(0)(1)
        '            kodept = dtcek.Rows(0)(0)
        '        End If
        '    End Using
        '    If CKTransfer.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtTransfer.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTransfer.Text, TxtNamaBank.Text, TxtTransfer.Value))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtTransfer.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTransfer.Text, ProsesJurnal.jeniskasbank.Bank_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTransfer.Text, TxtNamaBank.Text, TxtTransfer.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTransfer.Value))
        '            ProsJurnalucf.AddKasBank(New DetailKasBank(Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTransfer.Value))
        '            ProsJurnalucf.Submit()
        '        End If

        '    End If
        '    If CKTunai.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtTunai.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTunai.Text, TxtNamaAkunTunai.Text, TxtTunai.Value))

        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtTunai.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTunai.Text, ProsesJurnal.jeniskasbank.Kas_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunTunai.Text, TxtNamaAkunTunai.Text, TxtTunai.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTunai.Value))
        '            ProsJurnalucf.AddKasBank(New DetailKasBank(Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtTunai.Value))
        '            ProsJurnalucf.Submit()
        '        End If

        '    End If
        '    If CKGiro.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", TxtGiro.Value))
        '        Else
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, TxtGiro.Value))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, TxtKodeAkunGiro.Text, TxtNamaBankGiro.Text & " " & TxtNoGiro.Text, TxtGiro.Value))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", TxtGiro.Value))
        '            ProsJurnalucf.Submit()
        '        End If

        '    End If
        '    If CKCNDN.Checked = True Then

        '    End If
        '    If CKRetur.Checked = True Then

        '    End If
        '    If CheckEdit1.Checked = True Then
        '        Dim apndiucfkontansbu = Akun.PNDI_UCF_SBU_KONTAN
        '        Dim aumjktkontansbu = Akun.UM_PW_KONTAN
        '        Dim idsbu As String = ""
        '        Dim totalpengembalian As Double = 0
        '        dt3.AcceptChanges()
        '        totalpengembalian = dt3.Compute("SUM([Total Pengembalian])", "")
        '        Using dtsbu = SelectCon.execute("select b.KODE from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '            If dtsbu.Rows.Count > 0 Then
        '                idsbu = dtsbu.Rows(0)(0)
        '            End If
        '        End Using
        '        Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", kodept, "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '        If kodept = "03" Then
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndiucfkontansbu), "PNDI B.M UNIT CENTRAL FUND (UCF) ", totalpengembalian))
        '        Else
        '            Dim apndisisasby = "PENGEMBALIAN_PT_" & TxtKodeDivisi.Text
        '            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndisisasby), Setup.GetNamaAkun(Setup.GetAkun(apndisisasby)), totalpengembalian))
        '        End If
        '        ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(aumjktkontansbu), "NOTA KONTAN " & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Strings.Right(TxtNoDO.Text, 6) & " A/N " & TxtNamaCustomer.Text, totalpengembalian))
        '        ProsJurnal.Submit()
        '        If kodept = "03" Then
        '            Dim apndisisa = Akun.PNDI_PW_KONTAN
        '            Dim ahndisisa = Akun.HNDI_UCF_PW_KONTAN
        '            Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Edit)
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apndisisa), "PNDI B.M PERWAKILAN JAKARTA", totalpengembalian))
        '            Dim AHNDIUCF = "DIVISI_UCF_KONTAN" & TxtKodeDivisi.Text
        '            Dim namasbu As String = ""
        '            Using dtsbu = SelectCon.execute("select b.NAMA from LINK_SBU_DIVISI a join SBU b on a.KODE_SBU = b.KODE where A.KODE_DIVISI = '" & TxtKodeDivisi.Text & "'")
        '                If dtsbu.Rows.Count > 0 Then
        '                    namasbu = dtsbu.Rows(0)(0)
        '                End If
        '            End Using
        '            ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHNDIUCF), "HNDI " & namasbu & " (" & TxtNamaDivisi.Text & ") ", totalpengembalian))
        '            'If totalpengembalian - TxtNilaiDOKontan.Value > 0 Then
        '            '    ProsJurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahndisisa), "HNDI B.M PERWAKILAN JAKARTA", totalpengembalian - TxtNilaiDOKontan.Value > 0))
        '            'End If
        '            ProsJurnalucf.Submit()
        '        End If


        '        'Dim apiutangutd = Akun.PIUTANG_DAGANG_UT_PW_KONTAN_D
        '        'Dim ahndiucfpw = Akun.HNDI_PW_KONTAN
        '        'Dim apndiucfpw = Akun.PNDI_UCF_PW_KONTAN
        '        'Dim apiutangutk = Akun.PIUTANG_DAGANG_UT_PW_KONTAN_K
        '        'Dim notrans As String = ""
        '        'notrans = Strings.Right(TxtNoTransaksi.Text, 6)
        '        'Dim prosjurnalpw As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "Perwakilan", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Baru)
        '        'prosjurnalpw.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangutd), "DIPERHITUNGKAN UM JKT NO. " & notrans & " TGL " & Format(DTTglPengakuan.DateTime, "dd/MM/yy") & " A/N " & TxtNamaCustomer.Text, totalpengembalian))

        '    End If
        '    SQLServer.EndTransaction()
        '    Me.Dispose()
        'End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_PEMBAYARAN_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("MONITORING_PAYMENT", "ID_TRANSAKSI='" & TxtIDNota.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_RETUR", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_CNDN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("AR_PEMBAYARAN_KONTAN_DETAIL_SISA_PENGEMBALIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If CKTunai.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTunai.Text, ProsesJurnal.jeniskasbank.Kas_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalucf.Submit()
            End If
            If CKGiro.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalucf.Submit()
            End If
            If CKTransfer.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTransfer.Text, ProsesJurnal.jeniskasbank.Bank_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalucf.Submit()
            End If
            If CKRetur.Checked = True Then

            End If
            If CKCNDN.Checked = True Then

            End If
            If CheckEdit1.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalucf.Submit()
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_PEMBAYARAN_KONTAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If CKTunai.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTunai.Text, ProsesJurnal.jeniskasbank.Kas_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalucf.Submit()
            End If
            If CKGiro.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalucf.Submit()
            End If
            If CKTransfer.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Kas, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", TxtKodeAkunTransfer.Text, ProsesJurnal.jeniskasbank.Bank_Masuk, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalucf.Submit()
            End If
            If CKRetur.Checked = True Then

            End If
            If CKCNDN.Checked = True Then

            End If
            If CheckEdit1.Checked = True Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "03", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()

                Dim ProsJurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, DTTglPengakuan.DateTime, "", TxtNoTransaksi.Text, "Jurnal Transaksi", "UCF", "", 999, 0, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalucf.Submit()
            End If
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

End Class