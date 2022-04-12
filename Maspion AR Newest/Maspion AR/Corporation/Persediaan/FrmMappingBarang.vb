Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors

Public Class FrmMappingBarang
    Protected dtBarang As New DataTable
    Protected dtMap As New DataTable
    Protected dtOriginal As New DataTable

#Region "Shared Sub"

    Protected Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        GridView2.CloseEditor()

        If dtMap.Select("[Kode Gudang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Detail
            If SQLServer.Delete("MAPPING_BARANG", "ID_BARANG='" & dtMap.Rows(0).Item("ID Barang") & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dtMap.Select("[ID Barang]<>''").CopyToDataTable, {"No.", "ID Barang", "Kode Gudang", "Area", "Rak"}, "MAPPING_BARANG") = False Then Exit Sub
            dtOriginal = dtMap.Select().CopyToDataTable
            SQLServer.EndTransaction()
        End Using
    End Sub
#End Region

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmPO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dtBarang.Dispose()
            dtMap.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub InputPO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3.PerformClick()
        End Select
    End Sub

    Private Sub FrmPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 35, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 40, False, , )
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan Koli", TypeCode.String, 25, False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Double, 15, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Satuan Dist.", TypeCode.String, 15, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Harga Dist.", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Konversi", TypeCode.Double, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Satuan Supermarket", TypeCode.String, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Harga Supermarket", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBBarang, GridView1, dtBarang)
        Using MyLoadData As New _LoadData
            MyLoadData.GetData("SELECT DISTINCT ID,KODE,NAMA,SAT_KOLI1,QTY_DIST,SAT_DIST1,HARGA_DIST,QTY_DIST,SAT_SUPER1,HARGA_SUPER FROM BARANG A INNER JOIN LINK_BARANG_DIVISI B ON A.ID=B.ID_BARANG" & IIf(TxtDivisi.Text = "", "", " WHERE B.KODE_DIVISI='" & TxtDivisi.Text & "'"))
            MyLoadData.SetDataDetail(dtBarang, False)
        End Using

        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False, , , , , False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 35, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Gudang", TypeCode.String, 35, , , , , RBeditMapGudang)
        InitGrid.AddColumnGrid("Nama Gudang", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Area", TypeCode.String, 100, True, , , , RBeditMap)
        InitGrid.AddColumnGrid("Rak", TypeCode.String, 100, True, , , , RBeditMap)
        InitGrid.EndInit(TBMap, GridView2, dtMap)
        dtOriginal = dtMap.Copy
        GridView2.Columns("Nama Gudang").AppearanceCell.BackColor = Color.WhiteSmoke
        Dim dr As DataRow = dtMap.NewRow
        dr(0) = 0
        dr(1) = GridView1.GetFocusedDataRow(0)
        dr(2) = ""
        dr(3) = ""
        dr(4) = ""
        dr(5) = ""
        dtMap.Rows.Add(dr)
        dtOriginal = dtMap.Select().CopyToDataTable
        GridView2.OptionsView.AllowCellMerge = True
    End Sub

    ''' <summary>
    ''' Cari Divisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtDivisi_Click(sender As Object, e As System.EventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
        Using MyLoadData As New _LoadData
            MyLoadData.GetData("SELECT DISTINCT ID,KODE,NAMA,SAT_KOLI1,QTY_DIST,SAT_DIST1,HARGA_DIST,QTY_DIST,SAT_SUPER1,HARGA_SUPER FROM BARANG A INNER JOIN LINK_BARANG_DIVISI B ON A.ID=B.ID_BARANG" & IIf(TxtDivisi.Text = "", "", " WHERE B.KODE_DIVISI='" & TxtDivisi.Text & "'"))
            MyLoadData.SetDataDetail(dtBarang, False)
        End Using
    End Sub
    Private Sub txtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    ''' <summary>
    ''' Gridview1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private status As Boolean = False
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If dtMap.Rows.Count > 0 Then
            If status = False Then
                If CompareTwoDataTable(dtMap, dtOriginal) = False Then
                    status = True
                    Select Case MessageBox.Show("Data Mapping Dirubah, Apakah Anda Mau Menyimpan Perubahan ?", "Pertanyaan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        Case Windows.Forms.DialogResult.Cancel
                            GridView1.FocusedRowHandle = e.PrevFocusedRowHandle
                            status = False
                            Exit Sub
                        Case Windows.Forms.DialogResult.Yes
                            Simpan()
                        Case Windows.Forms.DialogResult.No
                    End Select
                    status = False
                End If
            Else
                Exit Sub
            End If
        End If

        dtMap.Clear()
        dtOriginal.Clear()
        Try
            If GridView1.GetFocusedRow(0) IsNot Nothing Then
                Using MyLoadData As New _LoadData
                    MyLoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,A.GUDANG,B.NAMA_GUDANG,A.AREA,A.RAK FROM MAPPING_BARANG A LEFT JOIN GUDANG B ON A.GUDANG=B.KODE WHERE A.ID_BARANG='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                    MyLoadData.SetDataDetail(dtMap, False)
                    dtOriginal = dtMap.Select().CopyToDataTable
                End Using
            End If
        Catch
        End Try
        Try
            If GridView2.RowCount = 0 Then
                Dim dr As DataRow = dtMap.NewRow
                dr(0) = 0
                dr(1) = GridView1.GetFocusedDataRow(0)
                dr(2) = ""
                dr(3) = ""
                dr(4) = ""
                dr(5) = ""
                dtMap.Rows.Add(dr)
                dtOriginal = dtMap.Select().CopyToDataTable
            End If
            GridView2.FocusedColumn = GridView2.Columns(5)
        Catch
        End Try
    End Sub
    Public Shared Function CompareTwoDataTable(ByVal dt1 As DataTable, ByVal dt2 As DataTable) As Boolean
        If dt1.Rows.Count <> dt2.Rows.Count Then Return False
        For i = 0 To dt2.Rows.Count - 1
            For j = 0 To dt1.Columns.Count - 1
                If dt1.Rows(i).Item(j) <> dt2.Rows(i).Item(j) Then Return False
            Next
        Next
        Return True
    End Function

    ''' <summary>
    ''' Gridview2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView2_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView2.FocusedColumnChanged
        For i As Integer = 0 To GridView2.Columns.Count - 1
            If GridView2.Columns(i) Is GridView2.FocusedColumn Then
                GridView2.Columns(i).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                GridView2.Columns(i).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
            End If
        Next
        GridView2.RefreshData()
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView2.RowCount - 1
            GridView2.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub RBeditMap_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RBeditMap.ButtonClick
        If e.Button.Index = 0 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            If GridView2.RowCount = 0 Then
                AddRow(dtMap)
            End If
        ElseIf e.Button.Index = 1 Then
            Dim dr As DataRow = dtMap.NewRow
            dr(0) = 0
            dr(1) = GridView1.GetFocusedDataRow(0)
            If GridView2.FocusedColumn.FieldName = "Kode Gudang" Then
                dr(2) = ""
                dr(3) = ""
                dr(4) = ""
                dr(5) = ""
            ElseIf GridView2.FocusedColumn.FieldName = "Area" Then
                dr(2) = GridView2.GetFocusedDataRow(2)
                dr(3) = GridView2.GetFocusedDataRow(3)
                dr(4) = ""
                dr(5) = ""
            ElseIf GridView2.FocusedColumn.FieldName = "Rak" Then
                dr(2) = GridView2.GetFocusedDataRow(2)
                dr(3) = GridView2.GetFocusedDataRow(3)
                dr(4) = GridView2.GetFocusedDataRow(4)
                dr(5) = ""
            End If
            dtMap.Rows.InsertAt(dr, GridView2.FocusedRowHandle + 1)
        End If
        Urutan()
    End Sub

    Private Sub RBeditMapGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RBeditMapGudang.ButtonClick
        If e.Button.Index = 0 Then
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Gudang)
            GridView2.GetFocusedDataRow()("Kode Gudang") = kode
            GridView2.EditingValue = kode
            Using mydt As DataTable = SelectCon.execute("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & GridView2.GetFocusedDataRow()("Kode Gudang") & "'")
                If mydt.Rows.Count > 0 Then
                    kode = mydt.Rows(0).Item(0)
                End If
            End Using
            GridView2.GetFocusedDataRow()("Nama Gudang") = kode
        ElseIf e.Button.Index = 1 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            If GridView2.RowCount = 0 Then
                AddRow(dtMap)
            End If
        ElseIf e.Button.Index = 2 Then
            Dim dr As DataRow = dtMap.NewRow
            dr(0) = 0
            dr(1) = GridView1.GetFocusedDataRow(0)
            dr(2) = ""
            dr(3) = ""
            dr(4) = ""
            dr(5) = ""
            dtMap.Rows.InsertAt(dr, GridView2.FocusedRowHandle + 1)
        End If
        Urutan()
    End Sub
End Class

