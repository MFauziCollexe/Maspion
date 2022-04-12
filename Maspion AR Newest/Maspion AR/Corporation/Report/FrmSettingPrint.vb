Imports System.Drawing.Printing
Imports System.IO
Imports System.Xml

Public Class FrmSettingPrint
    Dim pkInstalledPrinters As String
    Dim ysk As String
    Public Sub KeySend(ByVal e As String)
        ysk = e
    End Sub

    Private Sub FrmSettingPrint_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ComboBox1.Items.Clear()
    End Sub

    Private Sub FrmSettingPrint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each Me.pkInstalledPrinters In PrinterSettings.InstalledPrinters
            ComboBox1.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        If File.Exists(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini") Then
            Dim ini As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini")
            ComboBox1.Text = ini
        Else
            ComboBox1.SelectedIndex = 1
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If File.Exists(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini") Then
            Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini", False)
                sw.WriteLine(ComboBox1.Text)
            End Using
        Else
            If Not (File.Exists(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini")) Then
                MkDir(My.Application.Info.DirectoryPath & "\PrinterConfig\")
                Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini", False)
                    sw.WriteLine(ComboBox1.Text)
                End Using
            Else
                Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\PrinterConfig\" & ysk & ".ini", False)
                    sw.WriteLine(ComboBox1.Text)
                End Using
            End If
        End If

        ComboBox1.Items.Clear()
        Me.Close()
    End Sub


    Private Sub createNode(ByVal pID As String, ByVal pName As String, ByVal pPrice As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("PrinterServer")
        writer.WriteStartElement("Printer_id")
        writer.WriteString(pID)
        writer.WriteEndElement()
        writer.WriteStartElement("Display")
        writer.WriteString(pName)
        writer.WriteEndElement()
        writer.WriteStartElement("Printer")
        writer.WriteString(pPrice)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub
End Class