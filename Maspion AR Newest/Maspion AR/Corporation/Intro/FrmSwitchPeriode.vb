Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.Skins
Imports DevExpress.XtraBars.Ribbon
Imports System.IO

Public Class FrmSwitchPeriode
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim dt3 As DataTable
    Dim dt4 As DataTable
    Dim dt_cari4 As DataTable
    Public pass As Integer = 0

    Private Sub FrmLogin_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        TxtID.Focus()
    End Sub

    Private Sub FrmLogin_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub


    Private Sub FrmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        TglPeriode.Value = Format(Now.Date, "01/MM/yyyy")
    End Sub


    Private Sub TxtID_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtID.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : TxtUsername.Focus()
            Case Else
                KeyC = 0
        End Select
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

    Private Sub TxtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : TglPeriode.Focus()
            Case 38 : TxtUsername.Focus()
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

    Private Sub TxtUsername_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtUsername.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : TxtPassword.Focus()
            Case 38 : TxtID.Focus()
        End Select
    End Sub

    Private Sub TxtUsername_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsername.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub periode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TglPeriode.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                'e.Handled = True
                'SendKeys.Send("{Tab}")
                BtnMasuk.Focus()
                '                BtnMasuk_Click_1(sender, e)
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub BtnMasuk_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnMasuk.Click
        If pass = 3 Then
            Me.Close()
        End If


        Using dt = SelectCon.execute("SELECT * FROM USERS WHERE ID_USER = '" + TxtID.Text + "' AND NAMA_USER = '" + TxtUsername.Text + "' AND PASSWORD = '" + SmartEngine.encrypt(TxtPassword.Text) + "' AND STATUS_AKTIF='True' AND HAK_USER=1")
            If dt.Rows.Count > 0 Then
                GroupUser = dt.Rows(0).Item("id_group")
                HakRubahHarga = dt.Rows(0).Item("hak_harga")
                HakJabatan = dt.Rows(0).Item("JABATAN")

                If dt.Rows(0).Item("HAK_PERIODE") = 0 Then
                    If Format(TglPeriode.Value, "MMyy") <> Format(Now.Date, "MMyy") Then
                        MsgBox("Anda tidak punya hak akses untuk masuk di Periode ini!!!", vbInformation, "Informasi")
                        TglPeriode.Focus()
                        Exit Sub
                    End If
                End If
                'dtHakDetail = con.execute("SELECT * FROM HAK_DETAIL WHERE ID_GROUP='" & GroupUser & "'")

                'Using dt_cari4 = con.execute("SELECT STATUS_AKTIF_STOK,GUDANG,SUPPLIER FROM [SETUP MARKET]")
                '    If dt_cari4.Rows.Count > 0 Then
                '        CekStok = dt_cari4.Rows(0).Item(0)
                '        GudangPenjualan = dt_cari4.Rows(0).Item(1)
                '        DefaultSupplier = dt_cari4.Rows(0).Item(2)
                '    End If
                'End Using

                Using dt2 = SelectCon.execute("SELECT * FROM BUKU_PERIODE WHERE PERIODE = '" + Format(TglPeriode.Value, "MMyy") + "'")
                    If dt.Rows.Count > 0 Then
                        UserID = TxtID.Text
                        'Using dt4 = con.execute("SELECT * FROM DETAIL_GUDANG_KARYAWAN WHERE ID_USERS = '" + UserID + "'")
                        '    If dt4.Rows.Count > 0 Then
                        '        GudangID = dt4.Rows(0).Item("ID_GUDANG")
                        '    Else
                        '        GudangID = ""
                        '    End If
                        'End Using
                        UserName = TxtUsername.Text
                        passwd = TxtPassword.Text
                        periode = Format(TglPeriode.Value, "MMyy")
                        TxtID.Text = ""
                        TxtUsername.Text = ""
                        TxtPassword.Text = ""
                        Me.Hide()

                        Try
                            FrmMDI.Show()
                        Catch ex As Exception
                            MessageBox.Show(Err.Description, _
                     "Terjadi Kesalahan", _
                     MessageBoxButtons.OK, _
                     MessageBoxIcon.Error)
                        End Try
                    Else
                        MessageBox.Show("Periode Belum Ada !!", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            Else
                pass = pass + 1
                MessageBox.Show("Data Tidak Valid !!", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim trycon As New SQLServer

        If File.Exists(My.Application.Info.DirectoryPath & "\Config.ini") Then

            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Config.ini")
            Application.Restart()

        Else

        End If
    End Sub

    Private Sub TxtID_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtID.EditValueChanged

    End Sub

    Private Sub TxtUsername_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtUsername.EditValueChanged

    End Sub

    Private Sub TxtPassword_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtPassword.EditValueChanged

    End Sub

    Private Sub TglPeriode_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TglPeriode.ValueChanged

    End Sub
End Class