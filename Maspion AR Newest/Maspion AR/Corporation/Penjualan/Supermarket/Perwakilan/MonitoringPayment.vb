Public Class MonitoringPaymentSupermarketPerwakilan
    Inherits FrmMonitoringPayment

   Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Supermarket Perwakilan"
        LblTitle.Text = "Monitoring Payment Supermarket Perwakilan"
        Bagian = EBagian.Supermarket_Perwakilan
        GetData()
    End Sub
End Class
