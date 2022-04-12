
Imports System.Net.Mail

Public Class FrmEditOTP
    Property IdTransaksi As String
    Property NoTransaksi As String
    Property Recipients As String
    Property FormName As String
    Dim KonekJaringan As Boolean = True
    Dim OTP As String

    Private Sub FrmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TxtOTP.Focus()

        Module1.Authorize = False
        Dim random As New Random()
        OTP = random.Next(176258, 995296)
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Exec("INSERT INTO LOG_EDIT (ID_TRANSAKSI, NO_TRANSAKSI, FORM, CRUSER, CRTIME, OTP)
                    VALUES ('" & IdTransaksi & "', '" & NoTransaksi & "', '" & FormName & "', '" & UserID & "', CURRENT_TIMESTAMP, '" & OTP & "')") = False Then Me.Dispose()
            SQLServer.EndTransaction(False)
        End Using
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            'Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("no-reply@gsmart-it.net", "Gsmart16816899")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = False
            Smtp_Server.Host = "us2.smtp.mailhostbox.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("no-reply@gsmart-it.net", "Maspion Mailer Agent")
            For Each recipient In Recipients.Split(",")
                e_mail.To.Add(recipient.Trim)
            Next
            e_mail.Subject = "Kode OTP Untuk " & NoTransaksi
            e_mail.IsBodyHtml = True
            e_mail.Body = "Gunakan Kode OTP <b>" & OTP & "</b> Untuk Edit Transaksi Nomor " & NoTransaksi & "."
            Smtp_Server.Send(e_mail)
        Catch error_t As Exception
            If error_t.ToString.ToLower.Contains("the remote name could not be resolved") Then
                MsgBox("Anda harus terhubung ke internet!")
                KonekJaringan = False
            Else
                MsgBox(error_t.ToString)
            End If
        End Try
    End Sub

    Private Sub TxtID_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtOTP.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : TxtKeterangan.Focus()
            Case Else
                KeyC = 0
        End Select
    End Sub

    Private Sub TxtID_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOTP.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub BtnMasuk_Click(sender As System.Object, e As System.EventArgs) Handles BtnMasuk.Click
        Using dt = SelectCon.execute("SELECT * FROM LOG_EDIT WHERE ID_TRANSAKSI = '" & IdTransaksi & "' AND OTP = '" & TxtOTP.EditValue & "' AND CRUSER='" & UserID & "'")
            If dt.Rows.Count > 0 Then
                Using SQLServer As New SQLServerTransaction
                    SQLServer.InitTransaction()
                    If SQLServer.Exec("UPDATE LOG_EDIT SET KETERANGAN='" & TxtKeterangan.EditValue & "' WHERE ID_TRANSAKSI='" & IdTransaksi & "' AND OTP='" & TxtOTP.EditValue & "' AND CRUSER='" & UserID & "'") = False Then Exit Sub
                    SQLServer.EndTransaction(False)
                End Using
                Module1.Authorize = True
                Me.Dispose()
            Else
                MessageBox.Show("OTP Tidak Valid !!", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
    End Sub

    Private Sub FrmEditOTP_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not KonekJaringan Then Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class