Imports DevExpress.XtraEditors.Controls

Public MustInherit Class FrmDebitKreditNote
    Protected Jenis As JenisTransaksi
    Protected Enum JenisTransaksi
        Debit = 1
        Kredit = 2
    End Enum

#Region "Shared Sub"

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        TxtSubTotal.Text = "0"
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        If Jenis = JenisTransaksi.Debit Then
            Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM DEBIT_KREDIT_NOTE WHERE NO_TRANSAKSI LIKE 'DN" & Format(TglPengakuan.DateTime, "yyMM") & "%' ORDER BY NO_TRANSAKSI DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "DN" & Format(TglPengakuan.DateTime, "yyMM") & Format(urut, "000000")
            End Using
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'DN','') AS BIGINT)),0) AS ID FROM DEBIT_KREDIT_NOTE WHERE JENIS='Debit'")
                TxtIDTransaksi.Text = "DN" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        ElseIf Jenis = JenisTransaksi.Kredit Then
            Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM DEBIT_KREDIT_NOTE WHERE NO_TRANSAKSI LIKE 'CN" & Format(TglPengakuan.DateTime, "yyMM") & "%' ORDER BY NO_TRANSAKSI DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoTransaksi.Text = "CN" & Format(TglPengakuan.DateTime, "yyMM") & Format(urut, "000000")
            End Using
            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'CN','') AS BIGINT)),0) AS ID FROM DEBIT_KREDIT_NOTE WHERE JENIS='Kredit'")
                TxtIDTransaksi.Text = "CN" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End If
    End Sub

    Protected Sub Simpan()
        If Empty(TxtKode) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        con.begin_exec()
        If con.exec("INSERT INTO DEBIT_KREDIT_NOTE VALUES ('" & TxtIDTransaksi.Text & "','" & TxtNoTransaksi.Text & "','" & Format(TglTransaksi.DateTime, "MM/dd/yyyy") & "','" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "','" & TxtKode.Text & "','" & TxtKodeApprove.Text & "'," & Replace(CDbl(TxtSubTotal.Text), ",", ".") & ",'" & Replace(txtKeterangan.Text, "'", "`") & "','" & Replace(txtKeteranganInternal.Text, "'", "`") & "','" & periode & "','" & UserID & "',CURRENT_TIMESTAMP,null,null,0,'" & Jenis.ToString & "','" & TxtIDNota.Text & "','" & TxtKodeNota.Text & "','" & CMBJenis.SelectedItem & "')") = False Then GoTo keluar

        If Jenis = JenisTransaksi.Debit Then
            If con.exec("INSERT INTO LOG_PIUTANG ([ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]) VALUES ('" & TxtKode.Text & "','" & TxtIDTransaksi.Text & "','" & TxtNoTransaksi.Text & "',NULL,'" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "'," & Replace(-1 * CDbl(TxtSubTotal.Text), ",", ".") & ",'" & periode & "')") = False Then GoTo keluar
        ElseIf Jenis = JenisTransaksi.Kredit Then
            If con.exec("INSERT INTO LOG_PIUTANG ([ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]) VALUES ('" & TxtKode.Text & "','" & TxtIDTransaksi.Text & "','" & TxtNoTransaksi.Text & "',NULL,'" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "'," & Replace(CDbl(TxtSubTotal.Text), ",", ".") & ",'" & periode & "')") = False Then GoTo keluar
        End If

        con.end_exec(True)
        MessageBox.Show("Data telah disimpan..!!",
                        "Penyimpanan Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        Batal()
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!",
                "Penyimpanan Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT [NO_TRANSAKSI] ,[TGL] ,[TGL_PENGAKUAN] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[JUMLAH] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL],ID_NOTA,NO_NOTA,JENIS_CNDN FROM DEBIT_KREDIT_NOTE WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtKode, TxtKodeApprove, TxtSubTotal, txtKeterangan, txtKeteranganInternal, TxtIDNota, TxtKodeNota, CMBJenis})
            Using dt = SelectCon.execute("select JENIS_CNDN from DEBIT_KREDIT_NOTE where ID_TRANSAKSI = '" & TxtIDTransaksi.Text & "'")
                If dt.Rows.Count > 0 Then
                    CMBJenis.SelectedItem = dt.Rows(0)(0)
                End If
            End Using
        End If
    End Sub

    Protected Sub SimpanEdit()
        If Empty(TxtKode) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()
        If con.exec("UPDATE DEBIT_KREDIT_NOTE SET TGL='" & Format(TglTransaksi.DateTime, "MM/dd/yyyy") & "',TGL_PENGAKUAN='" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "',KODE_CUSTOMER='" & TxtKode.Text & "',KODE_APPROVE='" & TxtKodeApprove.Text & "',JUMLAH=" & Replace(CDbl(TxtSubTotal.Text), ",", ".") & ",KETERANGAN_CETAK='" & Replace(txtKeterangan.Text, "'", "`") & "',KETERANGAN_INTERNAL='" & Replace(txtKeteranganInternal.Text, "'", "`") & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP,ID_NOTA = '" & Replace(TxtIDNota.Text, "'", "`") & "',NO_NOTA = '" & Replace(TxtKodeNota.Text, "'", "`") & "',JENIS_CNDN = '" & Replace(CMBJenis.SelectedItem, "'", "`") & "' WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar

        If con.exec("DELETE FROM LOG_PIUTANG WHERE ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        If Jenis = JenisTransaksi.Debit Then
            If con.exec("INSERT INTO LOG_PIUTANG ([ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]) VALUES ('" & TxtKode.Text & "','" & TxtIDTransaksi.Text & "','" & TxtNoTransaksi.Text & "',NULL,'" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "'," & Replace(-1 * CDbl(TxtSubTotal.Text), ",", ".") & ",'" & periode & "')") = False Then GoTo keluar
        ElseIf Jenis = JenisTransaksi.Kredit Then
            If con.exec("INSERT INTO LOG_PIUTANG ([ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]) VALUES ('" & TxtKode.Text & "','" & TxtIDTransaksi.Text & "','" & TxtNoTransaksi.Text & "',NULL,'" & Format(TglPengakuan.DateTime, "MM/dd/yyyy") & "'," & Replace(CDbl(TxtSubTotal.Text), ",", ".") & ",'" & periode & "')") = False Then GoTo keluar
        End If

        con.end_exec(True)
        MessageBox.Show("Data telah dirubah..!!",
                        "Penyimpanan Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        Me.Dispose()
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!",
                "Penyimpanan Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
    End Sub

    Protected Sub Hapus()

        If MsgBox("Apakah anda ingin menghapus Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()
        If con.exec("DELETE FROM DEBIT_KREDIT_NOTE WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        If con.exec("DELETE FROM LOG_PIUTANG WHERE ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar

        con.end_exec(True)
        MessageBox.Show("Data telah dihapus..!!",
                        "Penyimpanan Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        Me.Dispose()
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!",
                "Penyimpanan Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
    End Sub

    Protected Sub BatalTransaksi()

        If MsgBox("Apakah anda ingin membatalkan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()
        If con.exec("UPDATE DEBIT_KREDIT_NOTE SET BATAL=1 WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar
        If con.exec("DELETE FROM LOG_PIUTANG WHERE ID_INVOICE='" & TxtIDTransaksi.Text & "'") = False Then GoTo keluar

        con.end_exec(True)
        MessageBox.Show("Data telah dibatalkan..!!",
                        "Penyimpanan Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        Me.Dispose()
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!",
                "Penyimpanan Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
    End Sub
#End Region
#End Region

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F6
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F7
                _Toolbar1_Button5.PerformClick()
            Case System.Windows.Forms.Keys.F8
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")
    End Sub

    Private Sub TxtKode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKode.ButtonClick
        TxtKode.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKode.EditValueChanged
        Using dtSupplier = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT FROM CUSTOMER WHERE ID='" & TxtKode.Text & "'")
            If dtSupplier.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtSupplier.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtSupplier.Rows(0).Item("NAMA")
                TxtAlamatKantor.Text = dtSupplier.Rows(0).Item("ALAMAT_KANTOR")
            Else
                TxtNama.Text = ""
                TxtAlamatKantor.Text = ""
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Close()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeNota.EditValueChanged

    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeNota.ButtonClick
        If TxtKode.Text = "" Then Exit Sub
        paramnotacustomer = TxtKode.Text
        paramjenisnota = CMBJenis.SelectedItem
        TxtIDNota.Text = Search(FrmPencarian.KeyPencarian.NOTA)
        Using dt = SelectCon.execute("select NO_NOTA, NO_REF,TGL_PENGAKUAN,TGL from NOTA where ID_TRANSAKSI = '" & TxtIDNota.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtKodeNota.Text = dt.Rows(0)(0)
                TxtNoRefNota.Text = dt.Rows(0)(1)
                TglPengakuan.DateTime = dt.Rows(0)(2)
                '  TglTransaksi.DateTime = dt.Rows(0)(3)
            End If
        End Using
        paramjenisnota = ""
        paramnotacustomer = ""
    End Sub

    Private Sub TxtIDNota_EditValueChanged(sender As Object, e As EventArgs) Handles TxtIDNota.EditValueChanged
        Using dt = SelectCon.execute("select NO_NOTA, NO_REF from NOTA where ID_TRANSAKSI = '" & TxtIDNota.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtKodeNota.Text = dt.Rows(0)(0)
                TxtNoRefNota.Text = dt.Rows(0)(1)
            End If
        End Using
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As Object, e As EventArgs) Handles _Toolbar1_Button1.Click

    End Sub

    Private Sub CMBJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBJenis.SelectedIndexChanged
        If CMBJenis.SelectedItem = "Retur Penjualan" Or CMBJenis.SelectedItem = "Retur Pembelian" Then
            LabelControl7.Visible = True
            TxtNoRetur.Visible = True
        Else
            LabelControl7.Visible = False
            TxtNoRetur.Visible = False
        End If
    End Sub

    Private Sub TxtNoRetur_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoRetur.EditValueChanged

    End Sub

    Private Sub TxtNoRetur_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRetur.ButtonClick
        If TxtKode.Text = "" Then Exit Sub
        paramreturcustomer = TxtKodeApprove.Text
        paramjenisnota = CMBJenis.SelectedItem
        TxtIDRetur.Text = Search(FrmPencarian.KeyPencarian.Retur_Penjualan)
        Using dt = SelectCon.execute("select NO_NOTA_RETUR, TGL_PENGAKUAN,TGL from RETUR_PENJUALAN where ID_TRANSAKSI = '" & TxtIDNota.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtKodeNota.Text = dt.Rows(0)(0)
                ' TxtNoRefNota.Text = dt.Rows(0)(1)
                TglPengakuan.DateTime = dt.Rows(0)(2)
                '  TglTransaksi.DateTime = dt.Rows(0)(3)
            End If
        End Using
        paramjenisnota = ""
        paramnotacustomer = ""
    End Sub
End Class

Public Class InputDebitNote
    Inherits FrmDebitKreditNote

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Debit Note"
        LblTitle.Text = "Debit Note"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
        _Toolbar1_Button6.Visible = False
        Jenis = JenisTransaksi.Debit
        CMBJenis.Properties.Items.Clear()
        CMBJenis.Properties.Items.Add("Retur Pembelian")
        AddHandler _Toolbar1_Button1.Click, AddressOf Simpan
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class InputDebitNoteKontan
    Inherits FrmDebitKreditNote
    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Debit Note Kontan"
        LblTitle.Text = "Debit Note Kontan"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
        _Toolbar1_Button6.Visible = False
        CMBJenis.Properties.Items.Clear()
        ' CMBJenis.Properties.Items.Add("Cash Discount")
        ' CMBJenis.Properties.Items.Add("Quantity Discount")
        '  CMBJenis.Properties.Items.Add("Tradings Term")
        '  CMBJenis.Properties.Items.Add("Nota / Surat Jalan")
        CMBJenis.Properties.Items.Add("DO Kontan")
        CMBJenis.SelectedIndex = 0
        ' CMBJenis.Properties.Items.Add("Biaya-Biaya")
        Jenis = JenisTransaksi.Debit
        AddHandler _Toolbar1_Button1.Click, AddressOf Simpan
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class InputKreditNoteKontan
    Inherits FrmDebitKreditNote
    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kredit Note Kontan"
        LblTitle.Text = "Kredit Note Kontan"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
        _Toolbar1_Button6.Visible = False
        CMBJenis.Properties.Items.Clear()
        ' CMBJenis.Properties.Items.Add("Cash Discount")
        ' CMBJenis.Properties.Items.Add("Quantity Discount")
        '  CMBJenis.Properties.Items.Add("Tradings Term")
        '  CMBJenis.Properties.Items.Add("Nota / Surat Jalan")
        CMBJenis.Properties.Items.Add("DO Kontan")
        ' CMBJenis.Properties.Items.Add("Biaya-Biaya")
        CMBJenis.SelectedIndex = 0
        Jenis = JenisTransaksi.Kredit
        AddHandler _Toolbar1_Button1.Click, AddressOf Simpan
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditDebitNote
    Inherits FrmDebitKreditNote

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Debit Note"
        LblTitle.Text = "Debit Note"

        Jenis = JenisTransaksi.Debit
        AddHandler _Toolbar1_Button1.Click, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.Click, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.Click, AddressOf Hapus
    End Sub
End Class

Public Class EditDebitNoteKontan
    Inherits FrmDebitKreditNote

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Debit Note Kontan"
        LblTitle.Text = "Debit Note Kontan"

        Jenis = JenisTransaksi.Debit
        AddHandler _Toolbar1_Button1.Click, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.Click, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.Click, AddressOf Hapus
    End Sub
End Class

Public Class InputKreditNote
    Inherits FrmDebitKreditNote

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kredit Note"
        LblTitle.Text = "Kredit Note"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
        _Toolbar1_Button6.Visible = False
        CMBJenis.Properties.Items.Clear()
        CMBJenis.Properties.Items.Add("Cash Discount")
        CMBJenis.Properties.Items.Add("Quantity Discount")
        CMBJenis.Properties.Items.Add("Tradings Term")
        CMBJenis.Properties.Items.Add("Nota / Surat Jalan")
        CMBJenis.Properties.Items.Add("Retur Penjualan")
        CMBJenis.Properties.Items.Add("Biaya-Biaya")
        Jenis = JenisTransaksi.Kredit
        AddHandler _Toolbar1_Button1.Click, AddressOf Simpan
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditKreditNote
    Inherits FrmDebitKreditNote

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kredit Note"
        LblTitle.Text = "Kredit Note"
        CMBJenis.Properties.Items.Clear()
        CMBJenis.Properties.Items.Add("Cash Discount")
        CMBJenis.Properties.Items.Add("Quantity Discount")
        CMBJenis.Properties.Items.Add("Tradings Term")
        CMBJenis.Properties.Items.Add("Nota / Surat Jalan")
        ' CMBJenis.Properties.Items.Add("DO Kontan")
        CMBJenis.Properties.Items.Add("Biaya-Biaya")
        Jenis = JenisTransaksi.Kredit
        AddHandler _Toolbar1_Button1.Click, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.Click, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.Click, AddressOf Hapus
    End Sub
End Class


Public Class EditKreditNoteKontan
    Inherits FrmDebitKreditNote

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kredit Note Kontan"
        LblTitle.Text = "Kredit Note Kontan"
        CMBJenis.Properties.Items.Clear()

        CMBJenis.Properties.Items.Add("DO Kontan")
        CMBJenis.SelectedIndex = 0
        Jenis = JenisTransaksi.Kredit
        AddHandler _Toolbar1_Button1.Click, AddressOf SimpanEdit
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button4.Click, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button5.Click, AddressOf Hapus
    End Sub
End Class