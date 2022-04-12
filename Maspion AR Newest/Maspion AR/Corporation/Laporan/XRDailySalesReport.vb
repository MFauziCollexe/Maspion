Imports DevExpress.XtraReports.UI
Imports System.Reflection
Imports DevExpress.XtraReports.Native.Data


Public Class XRDailySalesReport
    Private ListDivisi As New List(Of String)
    Private ListGudang As New List(Of String)

    Private Sub XrLabel8_PreviewDoubleClick(sender As Object, e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles XrLabel8.PreviewDoubleClick
        ShowDevexpressReport(ReportPreview.KeyReport.Nota_SJ, e.Brick.TextValue)
    End Sub

    Private Sub XrLabel35_PreviewDoubleClick(sender As Object, e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles XrLabel35.PreviewDoubleClick
        If e.Brick.TextValue.ToString.Contains("DO") Then
            ShowDevexpressReport(ReportPreview.KeyReport.DO_Kontan, e.Brick.TextValue)
        ElseIf e.Brick.TextValue.ToString.Contains("BON") Then
            ShowDevexpressReport(ReportPreview.KeyReport.Bon_Pesanan_Titipan, e.Brick.TextValue)
        End If
    End Sub

    Private Sub AddDisc_GetValue(sender As Object, e As DevExpress.XtraReports.UI.GetValueEventArgs) Handles AddDisc.GetValue
        'e.Value = Convert.ToDouble(GetCurrentColumnValue("DISC_QTY")).ToString("n0") & _
        '     IIf(GetCurrentColumnValue("DISC_1") = 0, "", "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_1")).ToString("n0")) & _
        '    IIf(GetCurrentColumnValue("DISC_2") = 0, "", "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_2")).ToString("n0")) & _
        '    IIf(GetCurrentColumnValue("DISC_3") = 0, "", "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_3")).ToString("n0")) & _
        '    IIf(GetCurrentColumnValue("DISC_QTY1") = 0, "", "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_QTY1")).ToString("n0"))
        e.Value = Convert.ToDouble(GetCurrentColumnValue("DISC_QTY")).ToString("n0") & _
                "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_1")).ToString("n0") & _
                "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_2")).ToString("n0") & _
                "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_3")).ToString("n0") & _
                "+" & Convert.ToDouble(GetCurrentColumnValue("DISC_QTY1")).ToString("n0")
    End Sub

    'Function LastBreak(sender As Object, field As String) As Boolean
    '    Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(sender, DevExpress.XtraReports.UI.GroupFooterBand)
    '    gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
    '    Dim browser As DevExpress.Data.Browsing.DataBrowser = Me.fDataContext(Me.DataSource, Me.DataMember)
    '    Try
    '        Dim groupValue As Object = browser.FindItemProperty(field, True).GetValue(browser.Current)
    '        browser.Position += 1
    '        Try
    '            If browser.HasLastPosition Then
    '                'e.Cancel = true;
    '                'gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
    '                Return True
    '            End If
    '            Dim nextValue As Object = browser.FindItemProperty(field, True).GetValue(browser.Current)
    '            If groupValue.ToString() <> nextValue.ToString() Then
    '                'gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
    '                Return True
    '            End If
    '        Finally
    '            browser.Position -= 1
    '        End Try
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    If browser.Count - 1 = browser.Position Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function

    Function GetNextValueByDivisi(ByVal Divisi)
        For Each div In ListDivisi
            If div = Divisi Then
                Dim NextPosition = ListDivisi.IndexOf(div) + 1
                If NextPosition = ListDivisi.Count Then
                    Return Divisi
                Else
                    Return ListDivisi.Item(NextPosition)
                End If
            End If
        Next
        Return ""
    End Function

    Function GetCountGudang(div As String) As Integer
        Dim i = 0
        For Each gd As String In ListGudang
            If Split(gd, ";")(0) = div Then
                i += 1
            End If
        Next
        Return i
    End Function

    Function GetNextValueByGudang(ByVal Gudang)
        Dim count As Integer = 0
        For Each div In ListGudang
            If Split(Gudang, ";")(0) = Split(div, ";")(0) Then
                If Split(Gudang, ";")(1) = Split(div, ";")(1) Then
                    Dim NextPosition = ListGudang.IndexOf(div) + 1
                    If NextPosition - count = GetCountGudang(Split(div, ";")(0)) Then
                        Return Split(Gudang, ";")(1)
                    Else
                        Return Split(ListGudang.Item(NextPosition), ";")(1)
                    End If
                End If
            Else
                count += 1
            End If
        Next
        Return ""
    End Function

    Private Sub GroupFooter1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
        Dim gf As DevExpress.XtraReports.UI.GroupFooterBand = CType(sender, DevExpress.XtraReports.UI.GroupFooterBand)
        Dim CurrentDivisi As String = GetCurrentColumnValue("DIVISI")
        Dim NextDivisi As String = GetNextValueByDivisi(CurrentDivisi)

        Dim CurrentGudang As String = GetCurrentColumnValue("GUDANG")
        Dim NextGudang As String = GetNextValueByGudang(CurrentDivisi & ";" & GetCurrentColumnValue("GUDANG"))

        If NextDivisi <> CurrentDivisi Then
            If NextGudang = CurrentGudang Then
                gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
            Else
                gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            End If
        Else
            If fDataBrowser.Count > 0 Then
                With TryCast(Me.fDataBrowser.List.Item(fDataBrowser.Count - 1).Row, DataRow)
                    If GetCurrentColumnValue("GUDANG") = .Item("GUDANG") AndAlso GetCurrentColumnValue("NAMA_DIVISI") = .Item("NAMA_DIVISI") AndAlso GetCurrentColumnValue("TGL_PENGAKUAN") = .Item("TGL_PENGAKUAN") Then
                        gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Else
                        gf.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    End If
                End With
            End If
        End If
    End Sub

    Function BelumAdaDivisi(divisi As String)
        For Each div In ListDivisi
            If div = divisi Then Return False
        Next
        Return True
    End Function

    Function BelumAdaGudang(gd As String)
        For Each div In ListGudang
            If div = gd Then Return False
        Next
        Return True
    End Function

    Private Sub XRDailySalesReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles Me.DataSourceRowChanged
        ListDivisi.Clear()
        ListGudang.Clear()
        For Each row As DataRow In TryCast(Me.DataSource, DataTable).Rows
            Dim divisi As String = row.Item("DIVISI")
            Dim gudang As String = divisi & ";" & IIf(row.Item("GUDANG") = "", "", row.Item("GUDANG"))
            If BelumAdaDivisi(divisi) Then ListDivisi.Add(divisi)
            If BelumAdaGudang(gudang) Then ListGudang.Add(gudang)
        Next
    End Sub
End Class