Public Class MonitoringPaymentSupermarketPusat
    Inherits FrmMonitoringPayment

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Supermarket Pusat"
        LblTitle.Text = "Monitoring Payment Supermarket Pusat"
        Bagian = EBagian.Supermarket_Pusat
        GetData()
    End Sub
End Class
