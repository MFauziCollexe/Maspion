
Public MustInherit Class FrmNotaReturPenjualan
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
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli TTB", TypeCode.Decimal, 40, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Kuantum TTB", TypeCode.Decimal, 50, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs TTB", TypeCode.Decimal, 60, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli", TypeCode.Decimal, 30, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Decimal, 50, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Disc %", TypeCode.Decimal, 60, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Decimal, 100, True, DevExpress.Utils.FormatType.Numeric, "c2", , ReCalc)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
        Using dtCustomer = SelectCon.execute("SELECT NO_NPWP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                If dtCustomer.Rows(0).Item("NO_NPWP") <> "" Then
                    RdPKP.Enabled = True
                Else
                    RdPKP.Enabled = False
                End If
            End If
        End Using

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
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
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
        TxtIDTTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_TTB)
    End Sub
    Private Sub TxtNoTTB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoTTB.KeyPress
        If CharKeypress(TxtNoTTB, e) Then TxtIDTTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_TTB)
    End Sub
    Private Sub TxtIDTTB_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIDTTB.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT NO_NOTA,TGL_PENGAKUAN,DIVISI,KODE_CUSTOMER,KODE_APPROVE,ALAMAT,GUDANG,KETERANGAN_CETAK FROM TTB WHERE ID_TRANSAKSI='" & TxtIDTTB.Text & "'")
            LoadData.SetData({TxtNoTTB, TglTTB, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan})
            SplashScreenManager1.ShowWaitForm()
            If bg = "Langganan" Then
                'LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,HARGA_DIST AS HARGA,0,0,(A.QUANTITY-A.QUANTITY_T)*HARGA_DIST FROM V_D_TTB_T_RJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTTB.Text & "' AND ST=0 ORDER BY URUTAN")
                LoadData.GetData("SELECT DISTINCT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,C.HARGA_BARU AS HARGA,0,0,(A.QUANTITY-A.QUANTITY_T)*C.HARGA_BARU FROM V_D_TTB_T_RJ A WITH(NOLOCK) LEFT JOIN BARANG B WITH(NOLOCK) ON A.ID_BARANG=B.ID LEFT JOIN (SELECT A.ID_BARANG,MAX(HARGA_BARU) HARGA_BARU FROM VI_PRICE_LIST A WITH(NOLOCK) INNER JOIN (SELECT MAX(TGL_PRICE) TGL,ID_BARANG FROM VI_PRICE_LIST WITH(NOLOCK) WHERE JENIS='Langganan' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') GROUP BY ID_BARANG) B ON A.ID_BARANG=B.ID_BARANG AND A.TGL_PRICE=B.TGL AND JENIS='Langganan' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') GROUP BY A.ID_BARANG) C ON A.ID_BARANG=C.ID_BARANG WHERE A.ID_TRANSAKSI='" & TxtIDTTB.Text & "' AND ST=0 ORDER BY URUTAN")
            ElseIf bg = "Supermarket" Then
                'LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,HARGA_SUPER AS HARGA,0,0,(A.QUANTITY-A.QUANTITY_T)*(HARGA_SUPER) FROM V_D_TTB_T_RJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTTB.Text & "' AND ST=0 ORDER BY URUTAN")
                LoadData.GetData("SELECT DISTINCT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,C.HARGA_BARU AS HARGA,0,0,(A.QUANTITY-A.QUANTITY_T)*C.HARGA_BARU FROM V_D_TTB_T_RJ A WITH(NOLOCK) LEFT JOIN BARANG B WITH(NOLOCK) ON A.ID_BARANG=B.ID LEFT JOIN (SELECT A.ID_BARANG,MAX(HARGA_BARU) HARGA_BARU FROM VI_PRICE_LIST A WITH(NOLOCK) INNER JOIN (SELECT MAX(TGL_PRICE) TGL,ID_BARANG FROM VI_PRICE_LIST WITH(NOLOCK) WHERE JENIS='Supermarket' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') GROUP BY ID_BARANG) B ON A.ID_BARANG=B.ID_BARANG AND A.TGL_PRICE=B.TGL AND JENIS='Supermarket' AND (ID='UMUM' OR ID='" & TxtIDCustomer.Text & "') GROUP BY A.ID_BARANG) C ON A.ID_BARANG=C.ID_BARANG WHERE A.ID_TRANSAKSI='" & TxtIDTTB.Text & "' AND ST=0 AND B.STATUS_AKTIF=1 ORDER BY URUTAN")
            Else
                MsgBox("Group Customer untuk Customer ini belum ada !!!")
            End If
            SplashScreenManager1.CloseWaitForm()
            LoadData.SetDataDetail(dt, False)
            Urutan()
            Hitung()
        End If
        If TxtIDTTB.Text = "" Then
            TBDO.Enabled = False
        Else
            TBDO.Enabled = True
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            If Val(col("Koli")) > col("Koli TTB") Then
                MsgBox("Koli Tidak Boleh Melebihi Koli TTB !!")
                col("Koli") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            If Val(col("Kuantum")) > col("Kuantum TTB") Then
                MsgBox("Kuantum Tidak Boleh Melebihi Kuantum TTB !!")
                col("Kuantum") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            If Val(col("Pieces")) > col("Pcs TTB") Then
                MsgBox("Pcs Tidak Boleh Melebihi Pcs TTB !!")
                col("Pieces") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Kuantum") = CDbl(col("Isi")) * CDbl(col("Koli"))
            col("Pieces") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
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
        For Each col As DataRow In dt.Rows
            Subtotal = 0
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Subtotal = col("Pieces") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
                Total = Total + Subtotal
            End If
            TxtSubTotal.Text = (Total)
        Next

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
            CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value) + _
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
        For Each col As DataRow In dt.Rows
            Subtotal = 0
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Subtotal = col("Pieces") * ((col("Harga Satuan") - col("Disc Satuan")) / col("Konv"))
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
Diskon3:                TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskon3.Value) / 100)
                        GoTo CashDiskon
                    Case TxtDiskon3Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value)
                        TxtDiskon3.Value = Math.Round(CDbl(TxtDiskon3Nominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo CashDiskon
                    Case TxtCashDiskon.Name
CashDiskon:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskonNominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtCashDiskon.Value) / 100)
                        GoTo DiskonQty2
                    Case TxtCashDiskonNominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value)
                        TxtCashDiskon.Value = Math.Round(CDbl(TxtCashDiskonNominal.Value) / (Total - TempTotalDiskon) * 100)
                        GoTo DiskonQty2
                    Case TxtDiskonQty2.Name
DiskonQty2:             TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
                        CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value)
                        TxtDiskonQty2Nominal.Value = Math.Round((Total - TempTotalDiskon) * CDbl(TxtDiskonQty2.Value) / 100)
                    Case TxtDiskonQty2Nominal.Name
                        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
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

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Text) + CDbl(TxtDiskonRegulerNominal.Text) + CDbl(TxtDiskon1Nominal.Text) + _
            CDbl(TxtDiskon2Nominal.Text) + CDbl(TxtDiskon3Nominal.Text) + CDbl(TxtCashDiskonNominal.Text) + _
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
#End Region
End Class


Public Class InputNotaReturPenjualan
    Inherits FrmNotaReturPenjualan
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
    End Sub

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Nota Retur Penjualan"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_RETUR FROM RETUR_PENJUALAN WHERE NO_NOTA_RETUR Like '" & TxtNamaDivisi.Text & "(" & InisialPerusahaan & ")" & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_NOTA_RETUR DESC")
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

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'RTR','') AS INT)),0) AS ID FROM RETUR_PENJUALAN")
            TxtIDTransaksi.Text = "RTR" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        If ChkBatal.Checked Then
            If Empty({TxtNoNotaSJ}) Then Exit Sub
        End If
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, ChkBatal, TxtNoNotaSJ, ChkBebasPPN, RdPKP}, "RETUR_PENJUALAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PENJUALAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditNotaReturPenjualan
    Inherits FrmNotaReturPenjualan

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Nota Retur Penjualan"
        Status_Edit = True
        RDJenisPPN.Enabled = False
        HakForm("", "Retur", "Nota Retur Penjualan", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        TBDO.Enabled = True
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT [NO_NOTA_RETUR] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TTB] ,[NO_TTB] ,[TGL_TTB] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] ,[STATUS_BATAL_NOTA] ,[NO_NOTA] ,[BEBAS_PPN], [PRINT_PKP] FROM RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN, ChkBatal, TxtNoNotaSJ, ChkBebasPPN, RdPKP})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS, A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,A.DISC,A.DISKON_SATUAN,0 FROM (RETUR_PENJUALAN AA INNER JOIN DETAIL_RETUR_PENJUALAN A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_TTB_T_RJ B ON AA.ID_TTB=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
        Urutan()
        HitungTanpaDiskon()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtNoTransaksi}) Then Exit Sub
        If ChkBatal.Checked Then
            If Empty({TxtNoNotaSJ}) Then Exit Sub
        End If
        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_NOTA_RETUR] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TTB] ,[NO_TTB] ,[TGL_TTB] ,[DIVISI] ,[JENIS_PPN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME] ,[STATUS_BATAL_NOTA] ,[NO_NOTA] ,[BEBAS_PPN], [PRINT_PKP]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTTB, TxtNoTTB, TglTTB, TxtDivisi, RDJenisPPN, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), ChkBatal, TxtNoNotaSJ, ChkBebasPPN, RdPKP}, "RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PENJUALAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", "Pieces", "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "RETUR_PENJUALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class