Public Class PaymentKreditSupermarketPerwakilan
    Inherits FrmPaymentKredit

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Payment Kredit Supermarket Perwakilan"
        LblTitle.Text = "Payment Kredit Supermarket Perwakilan"
        Bagian = EBagian.Supermarket_Perwakilan
        GetData()

        Dim aksesSimpan = GetAksesBaru("Penjualan Supermarket", "Perwakilan", "Payment Kredit")
        If Not aksesSimpan Then
            _Toolbar1_Button1.Enabled = False
            _Toolbar1_Button1.Visible = False

            _Toolbar1_Button2.Enabled = False
            _Toolbar1_Button2.Visible = False

            _Toolbar1_Button4.Enabled = False
            _Toolbar1_Button4.Visible = False
        End If
    End Sub
End Class
