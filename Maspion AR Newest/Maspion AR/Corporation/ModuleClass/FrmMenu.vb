Imports DevExpress.XtraLayout
Imports DevExpress.Utils.Win
Imports DevExpress.XtraGrid.Views.Grid

Public MustInherit Class FrmMenu
    Protected _Key As String
    Private rowHandle As Integer = -1
    Private AdaKolomBatal As Boolean = False

    Protected Property Key As String
        Set(value As String)
            _Key = value
            Text = "Menu " & value
            Name = "Menu " & value
        End Set
        Get
            Return _Key
        End Get
    End Property

    Protected Sub Hak(ByVal HakBaru As Boolean, ByVal HakEdit As Boolean, ByVal HakCetakDaftar As Boolean, ByVal HakCetak As Boolean, ByVal HakInfo As Boolean)
        If HakBaru = False Then BarButtonBaru.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakEdit = False Then BarButtonEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakEdit = False Then BtnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakCetakDaftar = False Then BarButtonCetakDaftar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakCetak = False Then BtnCetak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        If HakInfo = False Then BtnLihat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Protected Sub SetFocusRow()
        On Error Resume Next
        If rowHandle <> -1 Then
            GridView1.FocusedRowHandle = rowHandle
        End If
    End Sub

    Private Sub FrmMenu_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If BarButtonBaru.Visibility = DevExpress.XtraBars.BarItemVisibility.Never And BarButtonEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then BarStaticSplit1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub MenuKaryawan_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    End Sub

    Private Sub GridView1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseUp
        Dim view As GridView = DirectCast(sender, GridView)
        Dim hit As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If hit.InColumn AndAlso Not hit.Column.SortOrder = DevExpress.Data.ColumnSortOrder.None Then
            GridView1.FocusedRowHandle = GridView1.RowCount - 1
        End If
    End Sub

    Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        On Error Resume Next
        If AdaKolomBatal Then
            If GridView1.GetDataRow(e.RowHandle).Item("BATAL") = True Then
                e.Appearance.BackColor = Color.Crimson
                e.Appearance.ForeColor = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        rowHandle = e.FocusedRowHandle
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

    Private Sub BtnCetakBeberapa_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCetakBeberapa.ItemClick
        Using frm As New FrmMultiselect
            frm.Gridview = GridView1
            frm.Data = TBMenu.DataSource
            frm.ShowDialog()
        End Using
    End Sub
End Class

