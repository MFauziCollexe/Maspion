Imports System.IO
Imports System.Runtime.InteropServices

Public Class FrmKoneksi
    Dim dt As DataTable
    Dim trycon As New SQLServer
    Dim status As Boolean = False

    Dim ApplName As String
    Dim strUsername As String
    Dim strPassword As String
    Dim DirectoryServer As String

    Public Sub InitializeUpdate()
        Try
            If File.Exists(My.Application.Info.DirectoryPath & "\ServerUpdate.ini") Then
                Dim info() As String = Split(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\ServerUpdate.ini"), ";")
                DirectoryServer = info(0)
                strUsername = info(1)
                strPassword = info(2)
                ApplName = info(3)
                Dim startInfo As New ProcessStartInfo("cmd.exe", String.Format("/k {0} & {1}", _
                                               "net use " & DirectoryServer & " /user:" & strUsername & " " & strPassword, "exit"))
                startInfo.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(startInfo)
            Else
                MsgBox("ServerUpdate.ini Tidak ditemukan !")
                MsgBox("Pengecekan Update Gagal !!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim NewVersion As String = My.Computer.FileSystem.ReadAllText(DirectoryServer & "\Version.txt").Trim
            If Me.ProductVersion >= NewVersion Then
            Else
                'SplashScreen1.Close()
                Dim Res As Integer = MessageBox.Show("Aplikasi Ini Memerlukan Pembaruan Perangkat Lunak ", "Update Aplikasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Res = DialogResult.Yes Then
                    My.Application.SaveMySettingsOnExit = True
                    Dim locat As String = System.Reflection.Assembly.GetEntryAssembly.Location
                    Dim MyDirectory As String = System.IO.Path.GetDirectoryName(locat)
                    For Each proc As Process In System.Diagnostics.Process.GetProcessesByName(My.Application.Info.ProductName)
                        Try : SplashScreen1.Dispose()
                            proc.Kill()
                        Catch : End Try
                    Next
                    Process.Start(MyDirectory + "\SmartUpdater.exe")
                    End
                End If
            End If

            'Dim instance As WebClient = New WebClient
            'Dim address As String = "http://private.gsmart-it.net/metro/version.txt"
            'Dim returnValue As String = instance.DownloadString(address)
            'If Me.ProductVersion >= returnValue Then

            'Else
            '    Dim Res As Integer = MessageBox.Show("Aplikasi Ini Memerlukan Pembaruan Perangkat Lunak ", "Update Aplikasi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            '    If Res = DialogResult.Yes Then
            '        'delform.ShowDialog()
            '        My.Application.SaveMySettingsOnExit = True
            '        Dim locat As String = System.Reflection.Assembly.GetEntryAssembly.Location
            '        Dim MyDirectory As String = System.IO.Path.GetDirectoryName(locat)
            '        Process.Start(MyDirectory + "\G-SmartUpdater.exe")
            '        End

            '    End If

            'End If
        Catch
        End Try
    End Sub

    Private Sub BtnMasuk_Click(sender As System.Object, e As System.EventArgs) Handles BtnMasuk.Click
        Dim TxServer As String = TxtPilihServer.Text + ";" + TxtDatabaseName.Text
        If TxtPilihServer.Text = "" Then
            MsgBox("Server masih kosong!!!", vbInformation, "Info")
            TxtPilihServer.Focus()
            Exit Sub
        End If

        If TxtDatabaseName.Text = "" Then
            MsgBox("Nama Database masih kosong!!!", vbInformation, "Info")
            TxtDatabaseName.Focus()
            Exit Sub
        End If

        If RdLocation.SelectedIndex = 1 Then
            If TxtPilihServer.Text <> "" Then
                Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\Config.ini", False)
                    sw.WriteLine(TxServer)
                End Using

                Dim trycon As New SQLServer
                If trycon.TryConnect(TxServer) = True Then
                    Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\Config.ini", False)
                        sw.WriteLine(TxServer)
                    End Using
                    MessageBox.Show("Database Server Telah Di Set !!", _
           "Pengaturan Sukses", _
           MessageBoxButtons.OK, _
           MessageBoxIcon.Information)
                    Application.Restart()
                Else
                    MsgBox("DATABASE SERVER TIDAK DITEMUKAN", vbInformation, "KONEKSI DATABASE")
                    trycon.CloseConn()
                End If
            Else
                MessageBox.Show("Server Tidak Boleh Kosong", _
               "Terjadi Kesalahan", _
               MessageBoxButtons.OK, _
               MessageBoxIcon.Information)
            End If
        Else
            If trycon.TryConnect(TxServer) = True Then
                Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\Config.ini", False)
                    sw.WriteLine(TxServer)
                End Using
                Application.Restart()
            Else
                MsgBox("DATABASE SERVER TIDAK DITEMUKAN", vbInformation, "HONDA")
                trycon.CloseConn()
            End If
        End If
    End Sub

    Private Sub RdLocation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RdLocation.SelectedIndexChanged
        If RdLocation.SelectedIndex = 1 Then
            TxtPilihServer.Enabled = True
            TxtDatabaseName.Enabled = True
            TxtPilihServer.Text = ""
            TxtDatabaseName.Text = ""
        Else
            TxtPilihServer.Enabled = False
            TxtPilihServer.Text = "Localhost"
            TxtDatabaseName.Text = ""
        End If
    End Sub

    Private Sub FrmKoneksi_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If status = True Then
            MyBase.Hide()
            FrmLogin.Show()
            FrmLogin.TxtID.Focus()
        End If
    End Sub

    Private Sub FrmKoneksi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeUpdate()
        If File.Exists(My.Application.Info.DirectoryPath & "\Release.txt") Then
            FrmReleaseInfo.Show()
        End If
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()

        'For Each proc As Process In System.Diagnostics.Process.GetProcessesByName(My.Application.Info.ProductName)
        '    Try
        '        Dim myPID As Integer = Process.GetCurrentProcess().Id
        '        If proc.Id <> myPID Then
        '            SplashScreen1.Dispose()
        '            If MessageBox.Show("Aplikasi ini sudah terbuka sebelumnya !!!" & vbCrLf & "Pilih 'OK' untuk menutup aplikasi sebelumnya !", "Aplikasi Sudah dibuka !", MessageBoxButtons.OK, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
        '                proc.Kill()
        '            Else
        '                End
        '            End If
        '        End If
        '    Catch ex As Exception

        '    End Try
        'Next

        If File.Exists(My.Application.Info.DirectoryPath & "\Config.ini") Then
            If trycon.TryConnect(TxtServer) = True Then
                status = True
            Else
                MsgBox("DATABASE SERVER TIDAK DITEMUKAN", vbInformation, "KONEKSI DATABASE")
                trycon.CloseConn()
            End If
        End If
    End Sub

    Private Sub TxtPilihServer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPilihServer.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : TxtDatabaseName.Focus()
        End Select
    End Sub

    Private Sub TxtPilihServer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPilihServer.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Private Sub TxtDatabaseName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDatabaseName.KeyDown
        Dim KeyC As Integer
        KeyC = e.KeyCode
        Select Case KeyC
            Case 40 : BtnMasuk.Focus()
            Case 38 : TxtPilihServer.Focus()
        End Select
    End Sub

    Private Sub TxtDatabaseName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDatabaseName.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Else
                KeyAscii = 0
        End Select
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class