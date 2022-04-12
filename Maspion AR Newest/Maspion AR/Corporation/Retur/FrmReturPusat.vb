
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public MustInherit Class FrmReturPusat
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean
    Dim bg As String

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.Retur_Penjualan, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False

        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False, , , , ReBEditBarang)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 30, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Harga Retur Pusat", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
        RGJenis.SelectedIndex = 0
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
        'Using dtCustomer = SelectCon.execute("SELECT NO_NPWP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
        '    If dtCustomer.Rows.Count > 0 Then
        '        If dtCustomer.Rows(0).Item("NO_NPWP") <> "" Then
        '            RdPKP.Enabled = True
        '        Else
        '            RdPKP.Enabled = False
        '        End If
        '    End If
        'End Using

        On Error Resume Next
        bg = SelectCon.execute("SELECT CASE WHEN GROUP_CUSTOMER='Distributor' THEN 'Langganan' ELSE GROUP_CUSTOMER END AS GRUP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'").Rows(0).Item(0)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})

        'Dim oldval As Integer = Microsoft.VisualBasic.Right(TxtNoTransaksi.Text, 6)
        'Dim MyFormat As String = "(" & InisialPerusahaan & ")"
        'TxtNoTransaksi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'TxtNoTransaksi.Properties.Mask.EditMask = TxtNamaDivisi.Text & MyFormat & "000000"
        'TxtNoTransaksi.Properties.Mask.UseMaskAsDisplayFormat = True
        'TxtNoTransaksi.EditValue = oldval
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs)
        '       SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    ''' <summary>
    ''' Cari TTB
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoTTB_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoTTB.ButtonClick
        TxtIDTTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Retur_Pembelian)
    End Sub
    Private Sub TxtNoTTB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoTTB.KeyPress
        If CharKeypress(TxtNoTTB, e) Then TxtIDTTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Retur_Pembelian)
    End Sub
    Private Sub TxtIDTTB_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDTTB.EditValueChanged
        On Error Resume Next
        If Status_Edit = False Then
            LoadData.GetData("SELECT NO_RETUR,TGL_PENGAKUAN,DIVISI,KETERANGAN_CETAK,[DISC_QTY],[DISC_REG],[DISC_1],[DISC_2],[DISC_3],[CASH_DISC],[DISC_QTY1] FROM RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTTB.Text & "'")
            LoadData.SetData({TxtNoTTB, TglTTB, TxtDivisi, txtKeterangan, TxtDiskonQty1, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon, TxtDiskonQty2})
            SplashScreenManager1.ShowWaitForm()
            LoadData.GetData("select urutan,ID_BARANG,b.KODE,b.NAMA,a.SATUAN,a.ISI,a.KOLI,a.QUANTITY,a.pcs,a.KONVERSI,a.HARGA,0 as harga_retur_pusat,a.DISC,a.DISKON_SATUAN,0 as subtotal from DETAIL_RETUR_PEMBELIAN a join BARANG b on a.ID_BARANG = b.ID where a.id_transaksi = '" & TxtIDTTB.Text & "' order by a.urutan")
            SplashScreenManager1.CloseWaitForm()
            LoadData.SetDataDetail(dt, False)
            Urutan()
            Hitung()
        End If
        If RGJenis.SelectedIndex = 1 Then
            If TxtIDTTB.Text = "" Then
                TBDO.Enabled = False
            Else
                TBDO.Enabled = True
            End If
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        If GridView1.GetFocusedDataRow("Kode Barang") = "" Then Exit Sub
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            'If Val(col("Koli")) > col("Koli TTB") Then
            '    MsgBox("Koli Tidak Boleh Melebihi Koli TTB !!")
            '    col("Koli") = 0
            '    GridView1.EditingValue = 0
            '    GridView1.RefreshEditor(True)
            'End If
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            'If Val(col("Kuantum")) > col("Kuantum TTB") Then
            '    MsgBox("Kuantum Tidak Boleh Melebihi Kuantum TTB !!")
            '    col("Kuantum") = 0
            '    GridView1.EditingValue = 0
            '    GridView1.RefreshEditor(True)
            'End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            'If Val(col("Pieces")) > col("Pcs TTB") Then
            '    MsgBox("Pcs Tidak Boleh Melebihi Pcs TTB !!")
            '    col("Pieces") = 0
            '    GridView1.EditingValue = 0
            '    GridView1.RefreshEditor(True)
            'End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Kuantum") = CDbl(col("Isi")) * CDbl(col("Koli"))
            col("Pieces") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Retur Pusat") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Retur Pusat") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Truncate(CDbl(col("Kuantum")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            Hitung()
        End If
        Hitung()
    End Sub

    Private Sub TxtDiskonQty1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskonQty1.EditValueChanged, TxtDiskonQty1Nominal.EditValueChanged, TxtDiskonReguler.EditValueChanged, TxtDiskonRegulerNominal.EditValueChanged, TxtDiskon1.EditValueChanged, TxtDiskon1Nominal.EditValueChanged, TxtDiskon2.EditValueChanged, TxtDiskon2Nominal.EditValueChanged, TxtDiskon3.EditValueChanged, TxtDiskon3Nominal.EditValueChanged, TxtCashDiskon.EditValueChanged, TxtCashDiskonNominal.EditValueChanged, TxtDiskonQty2.EditValueChanged, TxtDiskonQty2Nominal.EditValueChanged
        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                        Hitung()
                End Select
            End If
        End If
    End Sub

    'Rubah Harga
    Private Sub BtnRubahHarga_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnRubahHarga.ItemClick
        Using LoadDataToGrid As New _LoadDataToGrid
            LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='" & bg & "' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') ORDER BY TGL_PRICE DESC")
            LoadDataToGrid.Init("Pilih", 25)
            LoadDataToGrid.Init("Harga", 50, DevExpress.Utils.FormatType.Numeric, "n", , False)
            LoadDataToGrid.Init("Tgl. Price", 50, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", , False)
            LoadDataToGrid.EndInit(TBHarga, GridViewHarga)
        End Using
        GridViewHarga.Columns(0).ColumnEdit = BtnPilihHarga
        GridViewHarga.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridViewHarga.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        TBDO.Enabled = False
        DockPanelHarga.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
    End Sub
    Private Sub TBHarga_DoubleClick(sender As Object, e As System.EventArgs) Handles TBHarga.DoubleClick, BtnPilihHarga.Click
        GridView1.GetFocusedDataRow()("Harga Satuan") = GridViewHarga.GetFocusedDataRow()(1)
        Hitung()
        GridView1.RefreshData()
        DockPanelHarga.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
        TBDO.Enabled = True
    End Sub
    Private Sub DockPanelHarga_ClosedPanel(sender As Object, e As DevExpress.XtraBars.Docking.DockPanelEventArgs) Handles DockPanelHarga.ClosedPanel
        TBDO.Enabled = True
    End Sub

    Private Sub TBDO_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBDO.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

#Region "Method"
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub
    Protected Sub HitungTanpaDiskon()
        On Error Resume Next
        Dim TempTotalDiskon As Double = 0
        Dim Total As Double = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Select("[Kode Barang] <> ''")
            Subtotal = 0
            col("Disc Satuan") = col("Harga Retur Pusat") * col("Disc %") / 100
            Subtotal = col("Pieces") * ((col("Harga Retur Pusat") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = (Total)
        Next

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
            CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value) +
            CDbl(TxtDiskonQty2Nominal.Value)
        DPP = Math.Round(Total - CDbl(TempTotalDiskon))

        If RDJenisPPN.SelectedIndex = 1 Then
            DPP = DPP / 1.1
            If ChkBebasPPN.Checked Then
                TxtPPN.Value = 0
            Else
                TxtPPN.Value = DPP * 0.1
            End If
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
        TxtDPP.Value = DPP
        If TxtPPN.Text = "" Then TxtPPN.Text = 0
        TxtTotal.Text = CDbl(DPP) + CDbl(TxtPPN.Text)
    End Sub
    Protected Sub Hitung()

        On Error Resume Next
        Dim TempTotalDiskon As Double = 0
        Dim Total As Double = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Select("[Kode Barang] <> ''")
            Subtotal = 0
            col("Disc Satuan") = col("Harga Retur Pusat") * col("Disc %") / 100
            Subtotal = col("Pieces") * ((col("Harga Retur Pusat") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = Total
        Next

        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name, TxtDiskonQty1Nominal.Name, TxtDiskonReguler.Name, TxtDiskonRegulerNominal.Name, TxtDiskon1.Name, TxtDiskon1Nominal.Name, TxtDiskon2.Name, TxtDiskon2Nominal.Name, TxtDiskon3.Name, TxtDiskon3Nominal.Name, TxtCashDiskon.Name, TxtCashDiskonNominal.Name, TxtDiskonQty2.Name, TxtDiskonQty2Nominal.Name
                    Case Else
                        GoTo DiskonQty1
                End Select
            End If
        End If

        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Parent.Name
                    Case TxtDiskonQty1.Name
DiskonQty1:             TxtDiskonQty1Nominal.Text = CDbl(dt.Compute("Sum(Kuantum)", "")) * CDbl(TxtDiskonQty1.Text)
                        GoTo DiskonReguler
                    Case TxtDiskonQty1Nominal.Name
                        TxtDiskonQty1.Text = CDbl(TxtDiskonQty1Nominal.Text) / CDbl(dt.Compute("Sum(Kuantum)", ""))
                        GoTo DiskonReguler
                    Case TxtDiskonReguler.Name
DiskonReguler:          TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonRegulerNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonReguler.Value) / 100)
                        GoTo Diskon1
                    Case TxtDiskonRegulerNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value)
                        TxtDiskonReguler.Value = Math.Round(CDbl(TxtDiskonRegulerNominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon1
                    Case TxtDiskon1.Name
Diskon1:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon1.Value) / 100)
                        GoTo Diskon2
                    Case TxtDiskon1Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value)
                        TxtDiskon1.Value = Math.Round(CDbl(TxtDiskon1Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon2
                    Case TxtDiskon2.Name
Diskon2:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon2.Value) / 100)
                        GoTo Diskon3
                    Case TxtDiskon2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value)
                        TxtDiskon2.Value = Math.Round(CDbl(TxtDiskon2Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo Diskon3
                    Case TxtDiskon3.Name
Diskon3:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon3.Value) / 100)
                        GoTo CashDiskon
                    Case TxtDiskon3Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3.Value = Math.Round(CDbl(TxtDiskon3Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo CashDiskon
                    Case TxtCashDiskon.Name
CashDiskon:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskonNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtCashDiskon.Value) / 100)
                        GoTo DiskonQty2
                    Case TxtCashDiskonNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskon.Value = Math.Round(CDbl(TxtCashDiskonNominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo DiskonQty2
                    Case TxtDiskonQty2.Name
DiskonQty2:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonQty2.Value) / 100)
                    Case TxtDiskonQty2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) +
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2.Value = Math.Round(CDbl(TxtDiskonQty2Nominal.Value) / (Total - TempTotalDiskon) * 100)
                End Select
            End If
        End If

        If TxtDiskonQty1.Value = 0 Then
            TxtDiskonQty2.Enabled = True
            TxtDiskonQty2Nominal.Enabled = True
        Else
            TxtDiskonQty2.Enabled = False
            TxtDiskonQty2Nominal.Enabled = False
        End If

        If TxtDiskonQty2.Value = 0 Then
            TxtDiskonQty1.Enabled = True
            TxtDiskonQty1Nominal.Enabled = True
        Else
            TxtDiskonQty1.Enabled = False
            TxtDiskonQty1Nominal.Enabled = False
        End If

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Text) + CDbl(TxtDiskonRegulerNominal.Text) + CDbl(TxtDiskon1Nominal.Text) +
            CDbl(TxtDiskon2Nominal.Text) + CDbl(TxtDiskon3Nominal.Text) + CDbl(TxtCashDiskonNominal.Text) +
            CDbl(TxtDiskonQty2Nominal.Text)
        DPP = Math.Round(Total - TempTotalDiskon)

        If RDJenisPPN.SelectedIndex = 1 Then
            DPP = DPP / 1.1
            If ChkBebasPPN.Checked Then
                TxtPPN.Value = 0
            Else
                TxtPPN.Value = DPP * 0.1
            End If
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
        TxtDPP.Value = DPP
        If TxtPPN.Text = "" Then TxtPPN.Text = 0
        TxtTotal.Text = CDbl(DPP) + CDbl(TxtPPN.Text)
    End Sub

    Private Sub ChkBebasPPN_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkBebasPPN.CheckedChanged
        If ActiveControl IsNot Nothing Then
            If TypeName(ActiveControl) = "LayoutControl" Then
                Select Case TryCast(ActiveControl, DevExpress.XtraLayout.LayoutControl).ActiveControl.Name
                    Case ChkBebasPPN.Name
                        Hitung()
                End Select
            End If
        End If
    End Sub

    Private Sub RDJenisPPN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPPN.SelectedIndexChanged
        Hitung()
        If RDJenisPPN.SelectedIndex = 0 Then
            ChkBebasPPN.Checked = False
            ChkBebasPPN.Enabled = False
        Else
            ChkBebasPPN.Enabled = True
        End If
    End Sub

    Private Sub RGJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RGJenis.SelectedIndexChanged

        If RGJenis.SelectedIndex = 0 Then
            TxtNoTTB.Enabled = False
            TglTTB.Enabled = False
            TglTTB.DateTime = Now.Date

            TxtDivisi.ReadOnly = False
            TxtDivisi.Enabled = True
            LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            TxtKodeApprove.Enabled = True
            TBDO.Enabled = True
            If Status_Edit = False Then
                TxtIDCustomer.Text = ""
                TxtDivisi.Text = ""
                TxtKodeApprove.Text = ""
                If TxtIDTTB.Text <> "" Then
                    TxtIDTTB.Text = ""
                    TxtNoTTB.Text = ""
                End If

                dt.Clear()
                AddRow(dt)
            End If

            If GridView1.Columns.Count > 0 Then
                GridView1.Columns("Kode Barang").OptionsColumn.AllowFocus = True
                GridView1.Columns("Kode Barang").OptionsColumn.ReadOnly = True
                GridView1.Columns("Kuantum").OptionsColumn.AllowFocus = True
                GridView1.Columns("Pieces").OptionsColumn.AllowFocus = True
                GridView1.Columns("Koli").OptionsColumn.AllowFocus = True
                GridView1.Columns("Harga Satuan").OptionsColumn.AllowFocus = False
                GridView1.Columns("Harga Satuan").Visible = False
            End If
        ElseIf RGJenis.SelectedIndex = 1 Then


            TxtNoTTB.Enabled = True
            TglTTB.Enabled = True
            TxtDivisi.ReadOnly = True
            TxtDivisi.Enabled = False

            LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TxtKodeApprove.Enabled = False
            If Status_Edit = False Then
                dt.Clear()
                TxtIDCustomer.Text = ""
                TxtDivisi.Text = ""
                TxtKodeApprove.Text = ""
                If TxtIDTTB.Text <> "" Then
                    TxtIDTTB.Text = ""
                    TxtNoTTB.Text = ""

                End If
                TBDO.Enabled = False
            End If


            If GridView1.Columns.Count > 0 Then
                GridView1.Columns("Kode Barang").OptionsColumn.AllowFocus = False
                GridView1.Columns("Kode Barang").OptionsColumn.ReadOnly = True
                GridView1.Columns("Kuantum").OptionsColumn.AllowFocus = False
                GridView1.Columns("Pieces").OptionsColumn.AllowFocus = False
                GridView1.Columns("Koli").OptionsColumn.AllowFocus = False
                GridView1.Columns("Harga Satuan").OptionsColumn.AllowFocus = False
                GridView1.Columns("Harga Satuan").Visible = True
            End If

        End If
    End Sub

    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer)

    End Sub

    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtKodeApprove, e) Then TxtIDCustomer.Text = SearchTransaction(FrmPencarian.KeyPencarian.Customer)

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Hitung()
    End Sub

    Private Sub ReBEditBarang_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles REBEditBarang.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If
            Dim bagian As String = ""
            If TxtKodeApprove.Text = "" Then
                MsgBox("Kolom Customer Masih Kosong !!")
                TxtKodeApprove.Focus()
                Exit Sub
            End If
            Using dtbagian = SelectCon.execute("select GROUP_CUSTOMER from CUSTOMER where KODE_APPROVE = '" & TxtKodeApprove.Text & "'")
                If dtbagian.Rows.Count > 0 Then
                    bagian = dtbagian.Rows(0)(0)
                End If

            End Using
            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(bagian.Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST*A.QTY_KOLI AS ISI ") & " ," & IIf(bagian.Contains("Langganan"), "A.QTY_DIST", "1") & " AS KONV,C.TGL_AWAL TGL_PRICE FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG " & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR " & IIf(bagian.Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE (A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "') " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
                If dt_cari.Rows.Count = 1 Then
                    If dt.Select("[ID Barang]='" & col("Kode Barang") & "' OR [Kode Barang]='" & col("Kode Barang") & "'").Length > 1 Then
                        MsgBox("Barang Sudah Ada !!")
                        col("ID Barang") = ""
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    ElseIf IsDBNull(dt_cari.Rows(0).Item("HARGA")) Then
                        MsgBox("Harga untuk Item ini masih kosong !!")
                        col("ID Barang") = ""
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    End If
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
                    'TglPricelist.DateTime = dt_cari.Rows(0).Item("TGL_PRICE")
                    'CekPromo()
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Barang_Divisi, GridView1.EditingValue,
                              FrmPencarian.TypeButton.Barang, , , TxtDivisi.Text, Format(TglPengakuan.DateTime, "yyyy-MM-dd"))
            If kode = "" Then
                col("ID Barang") = kode
                GridView1.EditingValue = kode
            Else
                If dt.Select("[ID Barang]='" & kode & "'").Length > 0 Then
                    MsgBox("Barang Sudah Ada !!")
                    col("ID Barang") = ""
                    GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                    Exit Sub
                Else
                    col("ID Barang") = kode
                End If
            End If
            Using dt_cari = SelectCon.execute("SELECT TOP 1 A.ID,A.KODE,A.NAMA," & IIf(bagian.Contains("Langganan"), "A.SAT_DIST1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_DIST) AS HARGA, A.QTY_KOLI AS ISI ", "A.SAT_SUPER1 AS SATUAN ,ISNULL(C.HARGA_BARU,A.HARGA_SUPER) AS HARGA, A.QTY_DIST*A.QTY_KOLI AS ISI ") & " ," & IIf(bagian.Contains("Langganan"), "A.QTY_DIST", "1") & " AS KONV,C.TGL_AWAL TGL_PRICE FROM BARANG A LEFT JOIN VI_PRICE_LIST_PROMO C ON A.ID=C.ID_BARANG " & "AND (C.ID='" & TxtIDCustomer.Text & "' OR C.ID='UMUM') AND CONVERT(DATE,'" & Format(TglPengakuan.DateTime, "MM-dd-yyyy") & "') BETWEEN C.TGL_AWAL AND C.TGL_AKHIR " & IIf(bagian.Contains("Langganan"), " AND C.JENIS='Langganan'", " AND C.JENIS='Supermarket'") & " LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE A.ID='" & col("ID Barang") & "' " & " AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_AWAL DESC,C.ID")
                If dt_cari.Rows.Count > 0 Then
                    If IsDBNull(dt_cari.Rows(0).Item("HARGA")) Then
                        MsgBox("Harga untuk Item ini masih kosong !!")
                        col("ID Barang") = ""
                        GridView1.EditingValue = kode
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    End If
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Pieces") = 0
                    col("Kuantum") = 0
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
                    '    TglPricelist.DateTime = dt_cari.Rows(0).Item("TGL_PRICE")
                    '   CekPromo()
                Else
                    col("Kode Barang") = ""
                    col("Nama Barang") = ""
                    col("Isi") = 0
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    col("Konv") = 0
                    col("Satuan") = ""
                    col("Harga Satuan") = 0
                    col("Disc %") = 0
                    col("Disc Satuan") = 0
                    col("Subtotal") = 0
                End If
            End Using

            'ElseIf GridView1.FocusedColumn.FieldName = "Satuan" Then
            '    Dim col As DataRow = GridView1.GetFocusedDataRow()
            '    Dim satuan As String = Search(FrmPencarian.KeyPencarian.Satuan_Barang, , , , , _
            '                                  GridView1.GetFocusedRow("ID Barang"))
            '    If satuan = "" Then
            '        Exit Sub
            '    Else
            '        col("Satuan") = satuan
            '        Using dt_cari = SelectCon.execute("SELECT " & IIf(EnumDescription(Bagian).Contains("Langganan"), "HARGA_DIST AS HARGA ", "HARGA_SUPER AS HARGA ") & " FROM BARANG WHERE ID='" & col("ID Barang") & "'")
            '            If dt_cari.Rows.Count > 0 Then
            '                col("Harga Satuan") = dt_cari.Rows(0).Item("HARGA")
            '            Else
            '                col("Harga Satuan") = 0
            '            End If
            '        End Using
            '        Hitung()
            '        SendKeys.Send("{Right}")
            '    End If
        End If
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles TBDO.EditorKeyDown


        'If GridView1.FocusedColumn.FieldName = "Kode Barang" Then

        '    If GridView1.EditingValue = "" Then
        '        SendKeys.Send("{Left}")
        '    Else
        '        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        '        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        '        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 30, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        '        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        '        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        '        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        '        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        '        InitGrid.AddColumnGrid("Harga Retur Pusat", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2")
        '        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        '        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        '        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")

        '        'Get Data
        '        Dim col As DataRow = GridView1.GetFocusedDataRow()
        '        Using dt_cari = SelectCon.execute("SELECT NAMA,SATUAN FROM ITEM WHERE KODE='" & GridView1.EditingValue & "'")
        '            If dt_cari.Rows.Count > 0 Then
        '                col("No.") = GridView1.FocusedRowHandle + 1
        '                col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
        '                col("Isi") = 0
        '                col("Koli") = 0
        '                col("Kuantum") = 0
        '                col("Pieces") = 0
        '                col("Konv") = 0
        '                col("Satuan") = ""
        '                col("Harga Satuan") = 0
        '                col("Disc %") = 0
        '                col("Disc Satuan") = 0
        '                col("Subtotal") = 0
        '            Else
        '                col("No.") = vbNull
        '                col("Kode Barang") = ""
        '                col("Nama Barang") = ""
        '                col("Isi") = 0
        '                col("Koli") = 0
        '                col("Kuantum") = 0
        '                col("Pieces") = 0
        '                col("Konv") = 0
        '                col("Satuan") = ""
        '                col("Harga Satuan") = 0
        '                col("Disc %") = 0
        '                col("Disc Satuan") = 0
        '                col("Subtotal") = 0
        '            End If
        '        End Using
        '    End If
        'End If
        dt.AcceptChanges()
        Dim KeyAscii As Integer = e.KeyCode
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Disc Satuan").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                            ' hitung()
                        End If
                    End If
                End If
        End Select
    End Sub



    Private Sub TxtDivisi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub TxtNoTTB_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoTTB.EditValueChanged

    End Sub

    Private Sub TBDO_KeyUp(sender As Object, e As KeyEventArgs) Handles TBDO.KeyUp

    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            End If
            ' hitung()
        End If
    End Sub

#End Region
End Class


Public Class InputReturPusat
    Inherits FrmReturPusat
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
    End Sub

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Retur Pusat"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_RETUR_PUSAT FROM RETUR_PUSAT WHERE NO_RETUR_PUSAT Like '" & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_RETUR_PUSAT DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & Format(urut, "000000")
        End Using

        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_RETUR FROM RETUR_PENJUALAN WHERE NO_NOTA_RETUR ='" & TxtNoTransaksi.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "'")
        '    If dtGenerate.Rows.Count > 0 Then
        '        MsgBox("Nomor transaksi " & TxtNoTransaksi.Text & " telah dipakai !!")
        '        Return False
        '    End If
        'End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'RTP','') AS INT)),0) AS ID FROM RETUR_PUSAT")
            TxtIDTransaksi.Text = "RTP" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If RGJenis.SelectedIndex = 0 Then
            If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        End If
        'If ChkBatal.Checked Then
        '    If Empty({TxtNoNotaSJ}) Then Exit Sub
        'End If
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, RGJenis, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatKantor, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, ChkBebasPPN}, "RETUR_PUSAT") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Retur Pusat", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PUSAT") = False Then Exit Sub
            '  If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditReturPusat
    Inherits FrmReturPusat

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Retur Pusat"
        Status_Edit = True
        RDJenisPPN.Enabled = False
        RGJenis.Enabled = False
        HakForm("", "Retur", "Nota Retur Penjualan", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        TBDO.Enabled = True
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT [NO_RETUR_PUSAT] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_NOTA_RETUR] ,[NO_NOTA_RETUR] ,[TGL_NOTA_RETUR] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE]  ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN]   ,[BEBAS_PPN],JENIS_RETUR  FROM RETUR_PUSAT WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, ChkBebasPPN, RGJenis})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI, A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,drp.HARGA,A.HARGA,A.DISC,A.DISKON_SATUAN,0 FROM (RETUR_PUSAT AA INNER JOIN DETAIL_RETUR_PUSAT A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_RB_T_RP B ON AA.ID_NOTA_RETUR=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID left join DETAIL_RETUR_PEMBELIAN DRP on drp.ID_TRANSAKSI = aa.ID_NOTA_RETUR and drp.ID_BARANG = a.ID_BARANG WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        Urutan()
        HitungTanpaDiskon()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If RGJenis.SelectedIndex = 1 Then
            If Empty({TxtDivisi, TglTransaksi, TxtNoTransaksi}) Then Exit Sub
        Else
            If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtNoTransaksi}) Then Exit Sub
        End If

        'If ChkBatal.Checked Then
        '    If Empty({TxtNoNotaSJ}) Then Exit Sub
        'End If
        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_RETUR_PUSAT] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_NOTA_RETUR] ,[NO_NOTA_RETUR] ,[TGL_NOTA_RETUR],JENIS_RETUR ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME] ,[BEBAS_PPN]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, RGJenis, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatKantor, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ChkBebasPPN}, "RETUR_PUSAT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_RETUR_PUSAT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            '  If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Retur Pusat", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PUSAT") = False Then Exit Sub
            '    If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_RETUR_PUSAT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            '  If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("RETUR_PUSAT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            ' If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "RETUR_PUSAT", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class