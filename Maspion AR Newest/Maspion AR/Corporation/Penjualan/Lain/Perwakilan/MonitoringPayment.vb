Public Class MonitoringPaymentLainPerwakilan
    Inherits FrmMonitoringPayment

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Lain Perwakilan"
        LblTitle.Text = "Monitoring Payment Lain Perwakilan"
        Bagian = EBagian.Lain_Perwakilan
        GetData()
    End Sub
End Class
