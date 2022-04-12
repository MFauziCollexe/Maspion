Public Class XRNotaDOTitipan

    Private Sub XrLabel66_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabel66.PrintOnPage
        
    End Sub

    Private Sub LblCounter_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles LblCounter.PrintOnPage
        If LblCounter.Text.Contains("DO") Or LblCounter.Text.Contains("BON") Then
            LblCounter.Text = SelectCon.execute("SELECT DBO.CEK_REVISI_COPY('" & LblCounter.Text & "')")(0)(0)
        End If
    End Sub

    'Public Function NamaAngka(Angka As Integer) As String
    '    Select Case Angka
    '        Case 1 : Return "Satu"
    '        Case 2 : Return "Satu"
    '        Case 3 : Return "Satu"
    '        Case 4 : Return "Satu"
    '        Case 5 : Return "Satu"
    '        Case 6 : Return "Satu"
    '        Case 1 : Return "Satu"

    '    End Select
    '    Return ""
    'End Function


    Private Sub Terbilang_GetValue(sender As Object, e As DevExpress.XtraReports.UI.GetValueEventArgs) Handles Terbilang.GetValue
        e.Value = Module1.Terbilang((CDbl(GetCurrentColumnValue("DPP")) + CDbl(GetCurrentColumnValue("PPN"))))
    End Sub
End Class