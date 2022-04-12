Public Class MonitoringPaymentLanggananPerwakilan
    Inherits FrmMonitoringPayment

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Langganan Perwakilan"
        LblTitle.Text = "Monitoring Payment Langganan Perwakilan"
        Bagian = EBagian.Langganan_Perwakilan
        GetData()
    End Sub
End Class
