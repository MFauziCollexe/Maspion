Public Class XRNotaDeliveryOrder

    Private Sub XrLabel66_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabel66.PrintOnPage
        'Dim temp1 As String
        'Dim bil As String
        'Dim Panjang As Double
        'Dim Panjang2 As Double
        'Dim temp As String
        'Dim temp2 As String
        'Dim Pos As Double
        'Dim St As Double
        'Dim pul_ribu As Double
        'Dim pul_ratus As Double
        'Dim pul_satu As Double
        'temp1 = ""
        'temp = CStr(VALUE + ",00")
        'Pos = InStr(temp, ",")
        'temp2 = Mid(temp, Pos + 1, Len(temp) - Pos)
        'Panjang2 = Len(temp2)
        'Panjang = Pos - 1
        'St = 1

        'If Panjang = 11 Then
        '    bil = Mid(temp, St, 1)
        '    Panjang = Panjang - 1
        '    St = St + 1
        '    If bil = "1" Then
        '        temp1 = temp1 & "Seratus "
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Ratus "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Ratus "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Ratus "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Ratus "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Ratus "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Ratus "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Ratus "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Ratus "
        '    End If
        'End If

        'If Panjang = 10 Then
        '    Panjang = Panjang - 1
        '    bil = Mid(temp, St, 1)
        '    St = St + 1
        '    If bil = "1" Then
        '        Panjang = Panjang - 2
        '        bil = Mid(temp, St, 1)
        '        St = St + 2
        '        If bil = "1" Then
        '            temp1 = temp1 & "Sebelas "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Duabelas "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tigabelas "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empatbelas "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Limabelas "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enambelas "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuhbelas "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapanbelas "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilanbelas "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Sepuluh "
        '        End If
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Puluh "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Puluh "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Puluh "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Puluh "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Puluh "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Puluh "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Puluh "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Puluh "
        '    End If
        'End If

        'If Panjang = 9 Then
        '    Panjang = Panjang - 2
        '    bil = Mid(temp, St, 1)
        '    St = St + 2

        '    If bil = "1" Then
        '        temp1 = temp1 & "Satu "
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan "
        '    End If

        'End If

        'If temp1 <> "" Then
        '    temp1 = temp1 & "Juta "
        'End If

        'If Panjang = 7 Then
        '    pul_ribu = 0
        '    Panjang = Panjang - 1
        '    bil = Mid(temp, St, 1)
        '    St = St + 1
        '    If bil = "1" Then
        '        temp1 = temp1 & "Seratus "
        '        pul_ratus = 1
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Ratus "
        '        pul_ratus = 1
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Ratus "
        '        pul_ratus = 1
        '    End If
        'End If

        'If Panjang = 6 Then
        '    pul_ribu = 0
        '    Panjang = Panjang - 1
        '    bil = Mid(temp, St, 1)
        '    St = St + 1
        '    If bil = "1" Then
        '        Panjang = Panjang - 2
        '        bil = Mid(temp, St, 1)
        '        St = St + 2

        '        If bil = "1" Then
        '            temp1 = temp1 & "Sebelas "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Dua Belas "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tiga Belas "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "EmpatBelas "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Lima Belas "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enam Belas "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuh Belas "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapan Belas "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilan Belas "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Sepuluh "
        '        End If
        '        temp1 = temp1 & "Ribu "
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Puluh "
        '        pul_ribu = 1
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Puluh "
        '        pul_ribu = 1
        '    End If
        'End If

        'If Panjang = 5 Then
        '    Panjang = Panjang - 2
        '    bil = Mid(temp, St, 1)
        '    St = St + 2

        '    If bil = "1" Then

        '        If temp1 = "" Then
        '            temp1 = temp1 & "Seribu "
        '            pul_satu = 0
        '        Else
        '            pul_satu = 1
        '            temp1 = temp1 & "Satu "
        '        End If
        '    ElseIf bil = "2" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Dua "
        '    ElseIf bil = "3" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Tiga "
        '    ElseIf bil = "4" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Empat "
        '    ElseIf bil = "5" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Lima "
        '    ElseIf bil = "6" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Enam "
        '    ElseIf bil = "7" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Tujuh "
        '    ElseIf bil = "8" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Delapan "
        '    ElseIf bil = "9" Then
        '        pul_satu = 1
        '        temp1 = temp1 & "Sembilan "
        '    End If

        '    If (pul_satu = 1 And bil <> "0") Or pul_ribu = 1 Or pul_ratus = 1 Then
        '        temp1 = temp1 & "Ribu "
        '    End If

        'End If

        'If Panjang = 3 Then
        '    Panjang = Panjang - 1
        '    bil = Mid(temp, St, 1)
        '    St = St + 1

        '    If bil = "1" Then
        '        temp1 = temp1 & "Seratus "
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Ratus "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Ratus "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Ratus "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Ratus "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Ratus "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Ratus "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Ratus "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Ratus "
        '    End If
        'End If

        'If Panjang = 2 Then
        '    Panjang = Panjang - 1
        '    bil = Mid(temp, St, 1)
        '    St = St + 1
        '    If bil = "1" Then
        '        Panjang = Panjang - 1
        '        bil = Mid(temp, St, 1)
        '        St = St + 1

        '        If bil = "1" Then
        '            temp1 = temp1 & "Sebelas "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Duabelas "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tigabelas "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empatbelas "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Limabelas "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enambelas "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuhbelas "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapanbelas "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilanbelas "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Sepuluh "
        '        End If
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua Puluh "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga Puluh "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat Puluh "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima Puluh "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam Puluh "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh Puluh "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan Puluh "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan Puluh "
        '    End If
        'End If

        'If Panjang = 1 Then
        '    bil = Mid(temp, St, 1)

        '    If bil = "1" Then
        '        temp1 = temp1 & "Satu "
        '    ElseIf bil = "2" Then
        '        temp1 = temp1 & "Dua "
        '    ElseIf bil = "3" Then
        '        temp1 = temp1 & "Tiga "
        '    ElseIf bil = "4" Then
        '        temp1 = temp1 & "Empat "
        '    ElseIf bil = "5" Then
        '        temp1 = temp1 & "Lima "
        '    ElseIf bil = "6" Then
        '        temp1 = temp1 & "Enam "
        '    ElseIf bil = "7" Then
        '        temp1 = temp1 & "Tujuh "
        '    ElseIf bil = "8" Then
        '        temp1 = temp1 & "Delapan "
        '    ElseIf bil = "9" Then
        '        temp1 = temp1 & "Sembilan "
        '    ElseIf bil = "0" Then
        '        temp1 = temp1 & " "
        '    End If
        'End If

        'temp1 = temp1 & "Rupiah "

        'If CDbl(temp2) = 0 Then
        '    XrLabel66.Text = temp1
        'Else

        '    temp1 = temp1 & "koma "
        '    St = 1
        '    If Panjang2 = 4 Then
        '        Panjang2 = Panjang2 - 1
        '        bil = Mid(temp2, St, 1)
        '        St = St + 1

        '        If bil = "1" Then
        '            temp1 = temp1 & "Satu "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Dua "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tiga "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empat "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Lima "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enam "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuh "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapan "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilan "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Nol "
        '        End If

        '    End If

        '    If Panjang2 = 3 Then
        '        Panjang2 = Panjang2 - 1
        '        bil = Mid(temp2, St, 1)
        '        St = St + 1

        '        If bil = "1" Then
        '            temp1 = temp1 & "Satu "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Dua "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tiga "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empat "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Lima "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enam "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuh "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapan "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilan "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Nol "
        '        End If
        '    End If

        '    If Panjang2 = 2 Then
        '        Panjang2 = Panjang2 - 1
        '        bil = Mid(temp2, St, 1)
        '        St = St + 1
        '        If bil = "1" Then
        '            temp1 = temp1 & "Satu "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Dua "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tiga "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empat "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Lima "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enam "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuh "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapan "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilan "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Nol "
        '        End If
        '    End If
        '    If Panjang2 = 1 Then
        '        bil = Mid(temp2, St, 1)

        '        If bil = "1" Then
        '            temp1 = temp1 & "Satu "
        '        ElseIf bil = "2" Then
        '            temp1 = temp1 & "Dua "
        '        ElseIf bil = "3" Then
        '            temp1 = temp1 & "Tiga "
        '        ElseIf bil = "4" Then
        '            temp1 = temp1 & "Empat "
        '        ElseIf bil = "5" Then
        '            temp1 = temp1 & "Lima "
        '        ElseIf bil = "6" Then
        '            temp1 = temp1 & "Enam "
        '        ElseIf bil = "7" Then
        '            temp1 = temp1 & "Tujuh "
        '        ElseIf bil = "8" Then
        '            temp1 = temp1 & "Delapan "
        '        ElseIf bil = "9" Then
        '            temp1 = temp1 & "Sembilan "
        '        ElseIf bil = "0" Then
        '            temp1 = temp1 & "Nol "
        '        End If
        '    End If


        '    temp1 = temp1 & "Sen"
        '    XrLabel66.Text = temp1
        'End If
    End Sub

    Private Sub LblCounter_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles LblCounter.PrintOnPage
        If LblCounter.Text.Contains("DO") Or LblCounter.Text.Contains("BON") Then
            LblCounter.Text = SelectCon.execute("SELECT DBO.CEK_REVISI_COPY('" & LblCounter.Text & "')")(0)(0)
        End If
    End Sub

    Private Sub Terbilang_GetValue(sender As Object, e As DevExpress.XtraReports.UI.GetValueEventArgs) Handles Terbilang.GetValue
        e.Value = Module1.Terbilang((CDbl(GetCurrentColumnValue("DPP")) + CDbl(GetCurrentColumnValue("PPN"))))
    End Sub

    Private Sub XrLabelPT_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelPT.BeforePrint
        Dim Id As String = GetCurrentColumnValue("ID_TRANSAKSI")
        If Id.Contains("DO") Then
            Using dt As DataTable = SelectCon.execute("SELECT PT.NAMA FROM DELIVERY_ORDER A JOIN LINK_SBU_DIVISI B ON A.DIVISI=B.KODE_DIVISI JOIN LINK_PT_SBU C ON B.KODE_SBU=C.KODE_SBU JOIN PT ON PT.KODE=C.KODE_PT WHERE A.ID_TRANSAKSI='" & Id & "' AND BAGIAN LIKE '%Pusat%' ")
                If dt.Rows.Count > 0 Then
                    XrLabelPT.Text = dt.Rows(0).Item(0)
                End If
            End Using
        Else
            Using dt As DataTable = SelectCon.execute("SELECT PT.NAMA FROM BON_PESANAN A JOIN LINK_SBU_DIVISI B ON A.DIVISI=B.KODE_DIVISI JOIN LINK_PT_SBU C ON B.KODE_SBU=C.KODE_SBU JOIN PT ON PT.KODE=C.KODE_PT WHERE A.ID_TRANSAKSI='" & Id & "' AND BAGIAN LIKE '%Pusat%' ")
                If dt.Rows.Count > 0 Then
                    XrLabelPT.Text = dt.Rows(0).Item(0)
                End If
            End Using
        End If
    End Sub

    Private Sub XrLabelPT_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabelPT.PrintOnPage
       
    End Sub
End Class