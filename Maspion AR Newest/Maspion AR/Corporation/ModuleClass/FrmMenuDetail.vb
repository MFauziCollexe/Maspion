Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public MustInherit Class FrmMenuDetail
    Protected _Key As String
    Protected rowHandle As Integer = -1
    Protected StatusLoad As Boolean = False
    Private AdaKolomBatal As Boolean = False
    Private AdaKolomSTK As Boolean = False
    Protected keyPrint As ReportPreview.KeyReport

    Protected Property Key As String
        Set(value As String)
            _Key = value
            Text = "Menu " & value
            Name = "Menu" & value
            GroupBox1.Text = "Detail " & value
        End Set
        Get
            Return _Key
        End Get
    End Property

    Protected Sub SetFocusRow()
        On Error Resume Next
        If rowHandle <> -1 Then
            GridView1.FocusedRowHandle = rowHandle
        End If
    End Sub

    Protected Sub Hak(ByVal HakBaru As Boolean, ByVal HakEdit As Boolean, ByVal HakCetakDaftar As Boolean, ByVal HakCetak As Boolean, ByVal HakInfo As Boolean)
        If HakBaru = False Then BarButtonBaru.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakEdit = False Then BarButtonEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakEdit = False Then BtnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakCetakDaftar = False Then BarButtonCetakDaftar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakCetak = False Then BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakInfo = False Then BtnLihat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub MenuDetail_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                BarButtonBaru.PerformClick()
            Case System.Windows.Forms.Keys.F3
                BarButtonEdit.PerformClick()
            Case System.Windows.Forms.Keys.F5
                BarButtonKeluar.PerformClick()
            Case System.Windows.Forms.Keys.F6
                BarButtonCetakDaftar.PerformClick()
            Case System.Windows.Forms.Keys.F7
                BtnCetakBeberapa.PerformClick()
            Case System.Windows.Forms.Keys.F
                If Shift = 4 Then BarButtonFirst.PerformClick()
            Case System.Windows.Forms.Keys.P
                If Shift = 4 Then BarButtonPrevious.PerformClick()
            Case System.Windows.Forms.Keys.N
                If Shift = 4 Then BarButtonNext.PerformClick()
            Case System.Windows.Forms.Keys.L
                If Shift = 4 Then BarButtonLast.PerformClick()
        End Select
    End Sub

    Private Sub TBMenu_DataSourceChanged(sender As Object, e As System.EventArgs) Handles TBMenu.DataSourceChanged
        If TBMenu.DataSource IsNot Nothing Then
            For Each dc As DataColumn In TryCast(TBMenu.DataSource, DataTable).Columns
                If dc.ColumnName = "BATAL" Then AdaKolomBatal = True
                If dc.ColumnName = "STK" Then AdaKolomSTK = True
            Next
        End If
    End Sub

    Private Sub TBMenu_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBMenu.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub BtnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEdit.ItemClick
        BarButtonEdit.PerformClick()
    End Sub

    Private Sub BarButtonFirst_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonFirst.ItemClick
        GridView1.MoveFirst()
    End Sub

    Private Sub BarButtonPrevious_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonPrevious.ItemClick
        GridView1.MovePrev()
    End Sub

    Private Sub BarButtonNext_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonNext.ItemClick
        GridView1.MoveNext()
    End Sub

    Private Sub BarButtonLast_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonLast.ItemClick
        GridView1.MoveLast()
    End Sub

    Private Sub BarButtonCetakDaftar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonCetakDaftar.ItemClick
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub BarButtonKeluar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonKeluar.ItemClick
        Me.Dispose()
    End Sub

    Private Sub GridView1_ColumnFilterChanged(sender As Object, e As System.EventArgs) Handles GridView1.ColumnFilterChanged
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data " & Key & " ]"
        On Error Resume Next
        If AdaKolomBatal Then
            If GridView1.GetDataRow(GridView1.FocusedRowHandle).Item("BATAL") = True Then
                BtnEdit.Enabled = False
                BarButtonEdit.Enabled = False
            Else
                BtnEdit.Enabled = True
                BarButtonEdit.Enabled = True
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If StatusLoad = False Then
            rowHandle = e.FocusedRowHandle
        End If
        On Error Resume Next
        If AdaKolomBatal Then
            If GridView1.GetDataRow(e.FocusedRowHandle).Item("BATAL") = True Then
                BtnEdit.Enabled = False
                BarButtonEdit.Enabled = False
            Else
                BtnEdit.Enabled = True
                BarButtonEdit.Enabled = True
            End If
        End If
    End Sub
    Private id As String
    Private sa As Boolean

    Private no As String
    Private sts As Boolean
    Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        On Error Resume Next
        'BATAL
        If AdaKolomBatal Then
            If e.RowHandle >= 0 Then
                If GridView1.GetDataRow(e.RowHandle).Item("BATAL") = True Then
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.ForeColor = Color.WhiteSmoke
                End If
            End If
        End If
        'TERPENUHI SEBAGIAN
        If Key.Contains("Delivery Order") Then
            If e.RowHandle >= 0 Then
                If e.Column Is GridView1.Columns(0) Then
                    Using mydt As DataTable = _
                        SelectCon.execute("SELECT SUM(PCS_T) TERPENUHI FROM V_D_DB_PERW_T_STUFF WHERE ID_TRANSAKSI='" & _
                                          GridView1.GetDataRow(e.RowHandle).Item(0) & "' AND STK=0")
                        If mydt.Rows.Count > 0 Then
                            If mydt.Rows(0).Item(0) > 0 Then
                                no = GridView1.GetDataRow(e.RowHandle).Item(0)
                                sts = True
                                e.Appearance.BackColor = Color.Pink
                                'e.Appearance.ForeColor = Color.WhiteSmoke
                            Else
                                no = ""
                                sts = False
                            End If
                        End If
                    End Using
                Else
                    If GridView1.GetDataRow(e.RowHandle).Item(0) = no AndAlso sts = True Then
                        e.Appearance.BackColor = Color.Pink
                        'e.Appearance.ForeColor = Color.WhiteSmoke
                    End If
                End If
            End If
        End If
        'ST
        If AdaKolomSTK Then
            If e.RowHandle >= 0 Then
                If GridView1.GetDataRow(e.RowHandle).Item("STK") = True Then
                    e.Appearance.BackColor = Color.PaleGreen
                    'e.Appearance.ForeColor = Color.WhiteSmoke
                End If
            End If
        End If
        'CLOSING
        If e.RowHandle >= 0 Then
            If e.Column Is GridView1.Columns(0) Then
                If SelectCon.execute("SELECT * FROM CLOSING_TRANSAKSI WHERE ID_TRANSAKSI='" & GridView1.GetDataRow(e.RowHandle).Item(0) & "'").Rows.Count > 0 Then
                    id = GridView1.GetDataRow(e.RowHandle).Item(0)
                    sa = True
                    e.Appearance.BackColor = Color.Blue
                    e.Appearance.ForeColor = Color.WhiteSmoke
                Else
                    id = ""
                    sa = False
                End If
            Else
                If GridView1.GetDataRow(e.RowHandle).Item(0) = id AndAlso sa = True Then
                    e.Appearance.BackColor = Color.Blue
                    e.Appearance.ForeColor = Color.WhiteSmoke
                End If
            End If
        End If
    End Sub

    Private Sub BtnCetakBeberapa_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCetakBeberapa.ItemClick
        Using frm As New FrmMultiselect
            frm.Data = TBMenu.DataSource
            frm.Gridview = GridView1
            frm.key = keyPrint
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub GridView1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseUp
        Dim view As GridView = DirectCast(sender, GridView)
        Dim hit As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If hit.InColumn AndAlso Not hit.Column.SortOrder = DevExpress.Data.ColumnSortOrder.None Then
            GridView1.FocusedRowHandle = GridView1.RowCount - 1
        End If
    End Sub

    Private Sub FrmMenuDetail_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        
    End Sub
End Class

