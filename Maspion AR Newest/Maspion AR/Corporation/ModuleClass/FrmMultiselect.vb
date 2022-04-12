Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class FrmMultiselect
    Dim dt As DataTable
    Property key As ReportPreview.KeyReport
    Private AdaKolomBatal As Boolean = False

    Public WriteOnly Property Data As DataTable
        Set(value As DataTable)
            If value.Rows.Count > 0 Then
                dt = Nothing
                dt = value.Select().CopyToDataTable
                Dim dc As New DataColumn
                dc.Caption = "Check"
                dc.DataType = GetType(Boolean)
                dc.ColumnName = "Check"
                dc.DefaultValue = False
                dt.Columns.Add(dc)
                GridControl1.DataSource = dt
            End If
        End Set
    End Property
    Private Mygrid As GridView
    Public WriteOnly Property Gridview As GridView
        Set(value As GridView)
            Mygrid = value
        End Set
    End Property

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub FrmMultiselect_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        If AdaKolomBatal Then
            GridView1.ActiveFilterString = "[BATAL] = False"
        End If
        For i = 0 To Mygrid.Columns.Count - 1
            GridView1.Columns(i).Caption = Mygrid.Columns(i).Caption
            GridView1.Columns(i).Width = Mygrid.Columns(i).Width
            GridView1.Columns(i).Visible = Mygrid.Columns(i).Visible
            GridView1.Columns(i).OptionsColumn.AllowFocus = False
            On Error Resume Next
            GridView1.Columns(i).DisplayFormat.FormatType = Mygrid.Columns(i).DisplayFormat.FormatType
            GridView1.Columns(i).DisplayFormat.FormatString = Mygrid.Columns(i).DisplayFormat.FormatString
        Next
        GridView1.Columns("Check").Visible = True
        GridView1.Columns("Check").OptionsColumn.AllowFocus = True
        GridView1.Columns("Check").Width = 15
        GridView1.BestFitColumns()
    End Sub

    Private Sub BtnPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        If dt.Select("Check=1").Length > 0 Then
            Dim lstno As New List(Of String)
            For Each dr As DataRow In dt.Select("Check=1")
                lstno.Add(dr(0))
            Next
            ShowDevexpressReport(key, GridView1.GetFocusedRow(0), , , , , , , , lstno)
            For Each dr As DataRow In dt.Select("Check=1")
                Log.Cetak(Me, dr(0))
            Next
        Else
            MsgBox("Tidak ada data yang akan di cetak !")
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridView1.Columns.Clear()
    End Sub

    Private Sub GridControl1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles GridControl1.DataSourceChanged
        If GridControl1.DataSource IsNot Nothing Then
            For Each dc As DataColumn In TryCast(GridControl1.DataSource, DataTable).Columns
                If dc.ColumnName = "BATAL" Then AdaKolomBatal = True
            Next
        End If
    End Sub
End Class