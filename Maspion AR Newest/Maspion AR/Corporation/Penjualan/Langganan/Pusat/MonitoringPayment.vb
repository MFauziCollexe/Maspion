Public Class MonitoringPaymentLanggananPusat
    Inherits FrmMonitoringPayment

     Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Langganan Pusat"
        LblTitle.Text = "Monitoring Payment Langganan Pusat"
        Bagian = EBagian.Langganan_Pusat
        GetData()
    End Sub
End Class
