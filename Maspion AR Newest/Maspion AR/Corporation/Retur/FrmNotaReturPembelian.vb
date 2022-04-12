
Public MustInherit Class FrmNotaReturPembelian
    Protected dt As New DataTable
    Protected DPP As Double
    Private _Status_Edit As Boolean
    Protected Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtNoTransaksi.Properties.ReadOnly = True
            Else
                TxtNoTransaksi.Properties.ReadOnly = False
            End If
        End Set
        Get
            Return _Status_Edit
        End Get
    End Property

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.Retur_Pembelian, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
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

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID TTB", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 60, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Kd. Packing", TypeCode.String, 80)
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
        AddRow(dt)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})

        Dim oldval As Integer = Microsoft.VisualBasic.Right(TxtNoTransaksi.Text, 6)
        TxtNoTransaksi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        TxtNoTransaksi.Properties.Mask.EditMask = TxtNamaDivisi.Text & "000000"
        TxtNoTransaksi.Properties.Mask.UseMaskAsDisplayFormat = True
        TxtNoTransaksi.EditValue = oldval
    End Sub

    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
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
    Private Sub TxtNoTTB_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ReBEdit.ButtonClick
        Dim Kode As String = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_TTB_Retur_Pembelian, , TxtDivisi.Text)
        If dt.Select("[ID TTB]='" & Kode & "'").Length = 0 Then
            SetData("SELECT A.KODE,NAMA FROM DIVISI A INNER JOIN TTB B ON A.KODE=B.DIVISI WHERE B.ID_TRANSAKSI='" & Kode & "'", {TxtDivisi, TxtNamaDivisi})
            'Using MyDt As DataTable = SelectCon.execute("SELECT A.URUTAN,A.ID_TRANSAKSI [ID TTB],C.NO_NOTA [No. TTB],A.ID_BARANG [ID Barang],B.KODE [Kode Barang],B.NAMA [Nama Barang],A.SATUAN,A.ISI,'' [Kd. Packing],A.KOLI-A.KOLI_T [Koli TTB],A.QUANTITY-A.QUANTITY_T [Kuantum TTB],A.PCS-A.PCS_T [Pcs TTB],0 [Koli],0 [Kuantum],0 [Pieces],A.KONVERSI [Konv],CASE WHEN A.SATUAN=B.SAT_DIST1 THEN HARGA_DIST ELSE HARGA_SUPER END AS [Harga Satuan],0 [Disc %],0 [Disc Satuan],(A.QUANTITY-A.QUANTITY_T)*(CASE WHEN A.SATUAN=B.SAT_DIST1 THEN HARGA_DIST ELSE HARGA_SUPER END) [Subtotal] FROM V_D_TTB_T_RB_N_TBR A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN TTB C ON A.ID_TRANSAKSI=C.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & Kode & "' AND ST=0 " & IIf(TxtDivisi.Text = "", "", " AND DIVISI='" & TxtDivisi.Text & "'") & " ORDER BY URUTAN")
            Using MyDt As DataTable = SelectCon.execute("SELECT A.URUTAN,A.ID_TRANSAKSI [ID TTB],C.NO_NOTA [No. TTB],A.ID_BARANG [ID Barang],B.KODE [Kode Barang],B.NAMA [Nama Barang],B.SAT_DIST1 AS SATUAN,B.QTY_KOLI ISI,'' [Kd. Packing],ROUND((A.KOLI-A.KOLI_T)/(B.QTY_DIST*B.QTY_KOLI),0,1) [Koli TTB],ROUND((A.QUANTITY-A.QUANTITY_T)/B.QTY_DIST,0,1) [Kuantum TTB],A.PCS-A.PCS_T [Pcs TTB],0 [Koli],0 [Kuantum],0 [Pieces],B.QTY_DIST [Konv],HARGA_BARU AS [Harga Satuan],0 [Disc %],0 [Disc Satuan],(A.QUANTITY-A.QUANTITY_T)*HARGA_BARU [Subtotal] FROM V_D_TTB_T_RB_N_TBR A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID LEFT JOIN TTB C ON A.ID_TRANSAKSI=C.ID_TRANSAKSI LEFT JOIN (SELECT ID_BARANG,HARGA_BARU,ROW_NUMBER() OVER (PARTITION BY ID_BARANG ORDER BY TGL_PRICE DESC) AS rn FROM VI_PRICE_LIST WHERE JENIS='Langganan') D ON A.ID_BARANG=D.ID_BARANG AND D.rn=1 WHERE A.ID_TRANSAKSI='" & Kode & "' AND ST=0 " & IIf(TxtDivisi.Text = "", "", " AND DIVISI='" & TxtDivisi.Text & "'") & " ORDER BY URUTAN")
                If MyDt.Rows.Count > 0 Then
                    dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    For Each dr As DataRow In MyDt.Rows
                        dt.ImportRow(dr)
                    Next
                    AddRow(dt)
                End If
            End Using
            Urutan()
            Hitung()
        Else
            MsgBox("No. TTB sudah ada !")
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
            col("Pieces") = Math.Round(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc %" Then
            col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
            col("Disc %") = Math.Truncate(col("Disc Satuan") / col("Harga Satuan") * 100)
            Hitung()
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Round(CDbl(col("Kuantum")) * CDbl(col("Konv")))
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
            TxtSubTotal.Text = Math.Round(Total)
        Next

        TempTotalDiskon = CDbl(TxtDiskonQty1Nominal.Value) + CDbl(TxtDiskonRegulerNominal.Value) + CDbl(TxtDiskon1Nominal.Value) + _
            CDbl(TxtDiskon2Nominal.Value) + CDbl(TxtDiskon3Nominal.Value) + CDbl(TxtCashDiskonNominal.Value) + _
            CDbl(TxtDiskonQty2Nominal.Value)
        DPP = Math.Round(Total - CDbl(TempTotalDiskon))

        If RDJenisPPN.SelectedIndex = 1 Then
            TxtPPN.Text = 0.1 * DPP
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
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
            TxtPPN.Text = 0.1 * DPP
        ElseIf RDJenisPPN.SelectedIndex = 0 Then
            TxtPPN.Text = 0
        End If
        If TxtPPN.Text = "" Then TxtPPN.Text = 0
        TxtTotal.Text = CDbl(DPP) + CDbl(TxtPPN.Text)
    End Sub
#End Region

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("ID TTB").ToString.Trim) > 0 Then
            GridView1.Columns("No. TTB").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("No. TTB").OptionsColumn.AllowEdit = True
        End If
    End Sub

    'Rubah Harga
    Private Sub BtnRubahHarga_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnRubahHarga.ItemClick
        Using LoadDataToGrid As New _LoadDataToGrid
            LoadDataToGrid.BeginInit("SELECT 'Pilih' AS PILIH,HARGA_BARU,TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & GridView1.GetFocusedDataRow()("ID Barang") & "' AND JENIS='Langganan' ORDER BY TGL_PRICE DESC")
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
End Class


Public Class InputNotaReturPembelian
    Inherits FrmNotaReturPembelian
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Nota Retur Pembelian"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_RETUR FROM RETUR_PEMBELIAN WHERE NO_RETUR Like '" & TxtNamaDivisi.Text & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_RETUR DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        'Using dtGenerate = SelectCon.execute("SELECT NO_RETUR FROM RETUR_PEMBELIAN WHERE NO_RETUR='" & TxtNoTransaksi.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy"))
        '    If dtGenerate.Rows.Count > 0 Then
        '        MsgBox("Nomor " & TxtNoTransaksi.Text & " Sudah Pernah Dipakai !")
        '        Return False
        '    End If
        'End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'RB','') AS INT)),0) AS ID FROM RETUR_PEMBELIAN")
            TxtIDTransaksi.Text = "RB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TglPengakuan, TxtKodeGudang}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong !!!", MsgBoxStyle.Information, "Peringatan")
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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPPN, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "RETUR_PEMBELIAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID TTB", "No. TTB", "ID Barang", "Isi", "Kd. Packing", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PEMBELIAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pieces"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditNotaReturPembelian
    Inherits FrmNotaReturPembelian

    Private Sub EditPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Nota Retur Pembelian"
        Status_Edit = True
        RDJenisPPN.Enabled = False
        HakForm("", "Retur", "Retur Pembelian", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
    End Sub

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT NO_RETUR ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[JENIS_PPN] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[PPN] FROM RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPPN, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, TxtPPN})

        LoadData.GetData("SELECT A.URUTAN,A.ID_TTB,A.NO_TTB,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI,A.KODE_PACKING,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS, A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,A.DISC,A.DISKON_SATUAN,0 FROM (RETUR_PEMBELIAN AA INNER JOIN DETAIL_RETUR_PEMBELIAN A ON AA.ID_TRANSAKSI=A.ID_TRANSAKSI) LEFT JOIN V_D_TTB_T_RB_N_TBR B ON A.ID_TTB=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, True)
        Urutan()
        HitungTanpaDiskon()
    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TglTransaksi, TxtNoTransaksi, TxtKodeGudang}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("[NO_RETUR] ,[TGL] ,[TGL_PENGAKUAN] ,[DIVISI] ,[JENIS_PPN] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_QTY] ,[DISC_QTY_NOMINAL] ,[DISC_REG] ,[DISC_REG_NOMINAL] ,[DISC_1] ,[DISC_1_NOMINAL] ,[DISC_2] ,[DISC_2_NOMINAL] ,[DISC_3] ,[DISC_3_NOMINAL] ,[CASH_DISC] ,[CASH_DISC_NOMINAL] ,[DISC_QTY1] ,[DISC_QTY_NOMINAL1] ,[DPP] ,[PPN] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPPN, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, TxtSubTotal, TxtDiskonQty1, TxtDiskonQty1Nominal, TxtDiskonReguler, TxtDiskonRegulerNominal, TxtDiskon1, TxtDiskon1Nominal, TxtDiskon2, TxtDiskon2Nominal, TxtDiskon3, TxtDiskon3Nominal, TxtCashDiskon, TxtCashDiskonNominal, TxtDiskonQty2, TxtDiskonQty2Nominal, DPP, TxtPPN, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID TTB", "No. TTB", "ID Barang", "Isi", "Kd. Packing", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Harga Satuan", "Disc %", "Disc Satuan", "No."}, "DETAIL_RETUR_PEMBELIAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pieces"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "RETUR_PEMBELIAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class