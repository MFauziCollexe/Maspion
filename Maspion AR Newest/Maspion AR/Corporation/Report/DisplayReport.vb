Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Drawing.Printing

Public Class DisplayReport
    Property Report_Name As String
    Property Key As String
    Property NomorNota As String
    Property GroupBarang As String
    Property KodeBarang As String
    Property KodeSupplier As String
    Property KodeCustomer As String
    Property KodeGudang As String
    Property KodeGudangTujuan As String
    Property JenisPembayaran As String
    Property TglAwal As Date
    Property TglAkhir As Date
    Property JatuhTempo As Date
    Dim LocalPrinter As System.Drawing.Printing.PrintDocument = New PrintDocument()
    Dim Report As New ReportDocument
    Dim MyCRtablelogoninfos As New TableLogOnInfos
    Dim MyCRtablelogoninfo As New TableLogOnInfo
    Dim MyCRconnectioninfo As New ConnectionInfo
    Dim MyCRtables As Tables
    Dim MyCRtable As Table

    Private Sub setting_nota()
        On Error Resume Next
        Report.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
        Report.PrintOptions.PrinterName = NamaPrinter
        Report.Load(Report_Name, OpenReportMethod.OpenReportByDefault)
        MyCRtables = Report.Database.Tables
        For Each Me.MyCRtable In MyCRtables
            MyCRtablelogoninfo = MyCRtable.LogOnInfo
            MyCRtablelogoninfo.ConnectionInfo = MyCRconnectioninfo
            MyCRtable.ApplyLogOnInfo(MyCRtablelogoninfo)
        Next
        Report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperQuarto
    End Sub

    Private Sub setting_laporan()
        On Error Resume Next
        report.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
        report.PrintOptions.PrinterName = NamaPrinter
        report.Load(report_name)
        MyCRtables = Report.Database.Tables
        For Each Me.MyCRtable In MyCRtables
            MyCRtablelogoninfo = MyCRtable.LogOnInfo
            MyCRtablelogoninfo.ConnectionInfo = MyCRconnectioninfo
            MyCRtable.ApplyLogOnInfo(MyCRtablelogoninfo)
        Next
        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
    End Sub

    Private Sub CRViewer_Load(sender As Object, e As System.EventArgs) Handles CrViewer.Load
        Dim pil As String
        Dim TempStatus As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TempPeriode As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TempPerusahaan As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TempAlamat As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim astring As String() = TxtServer.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        report.Load(report_name)
        With MyCRconnectioninfo
            .ServerName = astring(0)
            .DatabaseName = Mid(astring(1), 1, Len(astring(1)) - 2)
            .UserID = "sa"
            .Password = "Gsmart16816899"
        End With

        If File.Exists(My.Application.Info.DirectoryPath & "\PrinterConfig\" & key & ".ini") Then
            Dim ini As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\PrinterConfig\" & key & ".ini")
            Dim newString As String = ini.Replace(vbCr, "").Replace(vbLf, "")
            NamaPrinter = newString
        End If

        Select Case key
            Case "LAPORAN_PENDAFTARAN_MEMBER"
                setting_laporan()

                TempStatus = Report.ReportDefinition.Sections(0).ReportObjects("text2")

                If JenisPembayaran = 1 Then
                    TempStatus.Text = "Laporan Nota Pembelian Yang Sudah Lunas"
                Else
                    TempStatus.Text = "Laporan Nota Pembelian Yang Belum Lunas"
                End If

                pil = ""
                If KodeSupplier <> "" Then
                    pil = pil & " AND {SUPPLIER.ID}='" & KodeSupplier & "'"
                End If

                TempPerusahaan = Report.ReportDefinition.Sections(0).ReportObjects("txtNama")
                TempAlamat = Report.ReportDefinition.Sections(0).ReportObjects("txtAlamat")
                Using dtCari = con.execute("select * from PERUSAHAAN")
                    If dtCari.Rows.Count > 0 Then
                        TempPerusahaan.Text = dtCari.Rows(0).Item("PERUSAHAAN")
                        TempAlamat.Text = dtCari.Rows(0).Item("ALAMAT") & ", " & dtCari.Rows(0).Item("KOTA")
                    End If
                End Using
                TempPeriode = Report.ReportDefinition.Sections(0).ReportObjects("txtPeriode")
                TempPeriode.Text = Format(TglAwal.Date, "dd MMM yyyy") & " s/d " & Format(TglAkhir.Date, "dd MMM yyyy")
                Report.RecordSelectionFormula = "{MEMBER.TANGGAL} >= #" & Format(TglAwal, "yyyy-MM-dd") & "# AND {MEMBER.TANGGAL} <= #" & Format(TglAkhir, "yyyy-MM-dd") & "# " & pil
        End Select

        CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Report.VerifyDatabase()
        CrViewer.ReportSource = Report
        CrViewer.RefreshReport()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Change Default Printer" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\PrinterConfig\" & key & ".ini") Then
                FrmSettingPrint.KeySend(key)
                FrmSettingPrint.ShowDialog()
            Else
                FrmSettingPrint.KeySend(key)
                FrmSettingPrint.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DisplayReport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If key <> "NOTA_PO" And key <> "NOTA_SO" Then
            Button1.Text = "Information"
        Else
            Button1.Text = "Change Default Printer"
        End If
    End Sub
End Class