Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Public Class UbahPassword
    Private dt As DataTable
    Private dtpass As DataTable
    Private dtGenerate As DataTable
    Private dtCustomer As DataTable
    Private dt_cari As DataTable
    Private nama As String
    Private counter As Integer

    Private Sub simpan_Click(sender As System.Object, e As System.EventArgs) Handles simpan.Click
        If TxtPassword.Text = "" Then
            MessageBox.Show("Kolom Password Lama Masih Kosong !!!", "Perhatian", MessageBoxButtons.OK)
            Exit Sub
        End If
        If TxtPassword2.Text = "" Then
            MessageBox.Show("Kolom Password Lama Masih Kosong !!!", "Perhatian", MessageBoxButtons.OK)
            Exit Sub
        End If
        If TxtVerify.Text = "" Then
            MessageBox.Show("Kolom Password Lama Masih Kosong !!!", "Perhatian", MessageBoxButtons.OK)
            Exit Sub
        End If


        dtpass = SelectCon.execute("SELECT [PASSWORD] FROM USERS WHERE ID_USER ='" & UserID & "' AND [PASSWORD] = '" + SmartEngine.encrypt(TxtPassword.Text) + "'  ")
        If dtpass.Rows.Count = 0 Then
            MessageBox.Show("Password Lama yang Anda Masukkan Salah !!!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TxtPassword2.Text <> TxtVerify.Text Then
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE USERS SET [PASSWORD] = '" + SmartEngine.encrypt(TxtVerify.Text) + "' WHERE ID_USER ='" & TxtID.Text & "'"

        If con.exec(SQl) Then

            con.end_exec(True)
            MessageBox.Show("Perubahan Password Sukses..!!", _
                           "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                          MessageBoxIcon.Information)
            Me.Dispose()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Password gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub Batal()
        TxtPassword.Text = ""
        TxtPassword2.Text = ""
        TxtVerify.Text = ""
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Call Batal()
    End Sub

    Private Sub keluar_Click(sender As System.Object, e As System.EventArgs) Handles keluar.Click
        Me.Close()
    End Sub

    Private Sub TxtID_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub TxtNamaUser_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamaUser.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub TxtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub TxtPassword2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword2.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub TxtVerify_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtVerify.EditValueChanged
        If TxtPassword2.Text = TxtVerify.Text Then
            Label5.ForeColor = Color.Green
            Label5.Text = "Verifikasi Password Sama"
        Else
            Label5.ForeColor = Color.Red
            Label5.Text = "Verifikasi Password Tidak Sama"
        End If
    End Sub

    Private Sub TxtVerify_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVerify.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub UbahPassword_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                simpan_Click(sender, e)
            Case System.Windows.Forms.Keys.F3
                ToolStripButton2_Click(sender, e)
            Case System.Windows.Forms.Keys.F4
                keluar_Click(sender, e)
        End Select
    End Sub

    Private Sub GetData()
        dt = SelectCon.execute("SELECT * FROM USERS WHERE ID_USER ='" & UserID & "'")
        If dt.Rows.Count > 0 Then
            TxtID.Text = dt.Rows(0).Item("ID_USER")
            TxtNamaUser.Text = dt.Rows(0).Item("NAMA_USER")
        Else
            MessageBox.Show(Err.Description, _
                                      "Error", _
                                      MessageBoxButtons.OK, _
                                      MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UbahPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TxtID.Text = userid
    End Sub

    Private Sub TxtID_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtID.EditValueChanged
        GetData()
    End Sub

    Private Sub TxtPassword2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtPassword2.EditValueChanged
        If TxtPassword2.Text = TxtVerify.Text Then
            Label5.ForeColor = Color.Green
            Label5.Text = "Verifikasi Password Sama"
        Else
            Label5.ForeColor = Color.Red
            Label5.Text = "Verifikasi Password Tidak Sama"
        End If
    End Sub
End Class