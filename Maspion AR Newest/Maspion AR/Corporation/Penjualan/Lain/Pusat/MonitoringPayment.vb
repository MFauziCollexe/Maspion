Public Class MonitoringPaymentLainPusat
    Inherits FrmMonitoringPayment

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Monitoring Payment Lain Pusat"
        LblTitle.Text = "Monitoring Payment Lain Pusat"
        Bagian = EBagian.Lain_Pusat
        GetData()
    End Sub
End Class
