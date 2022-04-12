Public Class XRReturPembelian

    Private Sub Terbilang_GetValue(sender As Object, e As DevExpress.XtraReports.UI.GetValueEventArgs) Handles Terbilang.GetValue
        e.Value = Module1.Terbilang((CDbl(GetCurrentColumnValue("DPP")) + CDbl(GetCurrentColumnValue("PPN"))))
    End Sub
End Class