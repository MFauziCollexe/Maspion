Public MustInherit Class FrmDOTitipan
    Protected Bagian As EBagian

#Region "Shared Sub"

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
    End Sub

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.DO_Titipan, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Dim Filter As String = TxtNamaDivisi.Text
        Filter = Filter & IIf(EnumDescription(Bagian).Contains("Perwakilan"), "(P)", "(" & InisialPerusahaan & ")")
        Filter = Filter & IIf(EnumDescription(Bagian).Contains("Supermarket"), "(SUPER)", "")
        Using dtGenerate = SelectCon.execute("SELECT NO_DO FROM DELIVERY_ORDER WHERE NO_DO LIKE '" & Filter & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " AND PEMBAYARAN='Kontan' ORDER BY NO_DO DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = Filter & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'DO','') AS BIGINT)),0) AS ID FROM DELIVERY_ORDER")
            TxtIDTransaksi.Text = "DO" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan()
        If Empty(TxtIDCustomer) Then Exit Sub
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub
        If Empty(TxtIdSalesman) Then Exit Sub

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub

        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TglPricelist, ToSyntax("''"), TxtDivisi, ToSyntax("''"), TxtIDCustomer, TxtKodeApprove, ToSyntax("''"), TxtAlamatKirim, ToSyntax("'Kontan'"), ToSyntax("0"), TglTransaksi, txtKeterangan, txtKeteranganInternal, TxtSubtotal, ToSyntax("0"), ToSyntax("0"), TxtDiskonReguler, ToSyntax("0"), TxtDiskon1, ToSyntax("0"), TxtDiskon2, ToSyntax("0"), TxtDiskon3, ToSyntax("0"), TxtCashDiskon, ToSyntax("0"), ToSyntax("0"), ToSyntax("0"), TxtSubtotal, ToSyntax("0"), periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), ToSyntax("'Tanpa Barang'"), RdPKP, ToSyntax("NULL"), ToSyntax("0"), TxtIdSalesman}, "DELIVERY_ORDER") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT [NO_DO] ,[TGL] ,[TGL_PENGAKUAN] ,[TGL_PRICE] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_REG] ,[DISC_1] ,[DISC_2] ,[DISC_3] ,[CASH_DISC], [SALES], [PRINT_PKP] FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TglPricelist, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, TxtSubtotal, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon, TxtIdSalesman, RdPKP})
            Log.Load(Me, TxtIDTransaksi.Text)
        End If
    End Sub

    Private Function Restrict() As Boolean
        Using dtcek = SelectCon.execute("SELECT * FROM BON_PESANAN WHERE ID_DO='" & TxtIDTransaksi.Text & "' AND NO_DO='" & TxtNoTransaksi.Text & "'")
            If dtcek.Rows.Count > 1 Then
                MessageBox.Show("Bon Pesanan(Titipan) dari transaksi ini telah keluar." & vbCrLf & _
                                "Anda tidak dapat mengubah transaksi ini..!!", _
                       "Peringatan", _
                       MessageBoxButtons.OK, _
                       MessageBoxIcon.Information)
                Return True
            End If
        End Using
        Using dtcek As DataTable = SelectCon.execute("SELECT STATUS_LUNAS AS BAYAR FROM VI_PAY_KONTAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            If dtcek.Rows.Count > 0 Then
                If dtcek.Rows(0).Item(0) = 1 Then
                    MsgBox("Transaksi Sudah Dalam Proses Payment," & vbCrLf & _
                           "Anda Tidak Dapat Mengubah Transaksi Ini !!" & vbCrLf & _
                           "Hapus Payment DO Terlebih Dahulu Untuk Mengubah Transaksi Ini.", MsgBoxStyle.Information)
                    Return True
                End If
            End If
        End Using
        Return False
    End Function

    Protected Sub SimpanEdit()
        If Empty(TxtIDCustomer) Then Exit Sub
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(TglTransaksi) Then Exit Sub
        If Empty(TxtIdSalesman) Then Exit Sub
        If Restrict() Then Exit Sub

        If QuestionEdit() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[TGL] ,[TGL_PENGAKUAN] ,[TGL_PRICE] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[SUBTOTAL] ,[DISC_REG] ,[DISC_1] ,[DISC_2] ,[DISC_3] ,[CASH_DISC] ,[DPP] ,[MDUSER] ,[MDTIME], [SALES], [PRINT_PKP]", {TglTransaksi, TglPengakuan, TglPricelist, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, TxtSubtotal, TxtDiskonReguler, TxtDiskon1, TxtDiskon2, TxtDiskon3, TxtCashDiskon, TxtSubtotal, UserID, ToSyntax("CURRENT_TIMESTAMP"), TxtIdSalesman, RdPKP}, "DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If Restrict() Then Exit Sub
        If QuestionHapus() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using

    End Sub

    Protected Sub BatalTransaksi()
        If Restrict() Then Exit Sub

        If QuestionBatal() = False Then Exit Sub
        If AuthOTP(TxtIDTransaksi.Text, TxtNoTransaksi.Text, Text) = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "DELIVERY_ORDER", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
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
        TglPricelist.DateTime = Format(Now.Date, "dd/MM/yyyy")
    End Sub

    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , Bagian, TxtDivisi.Text)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        Using dtSupplier = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT,NO_NPWP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtSupplier.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtSupplier.Rows(0).Item("KODE_APPROVE")
                TxtNama.Text = dtSupplier.Rows(0).Item("NAMA")
                TxtAlamatKantor.Text = dtSupplier.Rows(0).Item("ALAMAT_KANTOR")
                TxtAlamatKirim.Text = dtSupplier.Rows(0).Item("LOKASI_PENGIRIMAN")
                If dtSupplier.Rows(0).Item("NO_NPWP") <> "" Then
                    RdPKP.Enabled = True
                Else
                    RdPKP.Enabled = False
                    RdPKP.Checked = False
                End If
            Else
                TxtNama.Text = ""
                TxtAlamatKantor.Text = ""
                TxtAlamatKirim.Text = ""
            End If
        End Using
    End Sub

    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , Bagian, TxtDivisi.Text)
    End Sub

    Private Sub TxtDivisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi, , , , , , , , , , , Bagian)
    End Sub

    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi, , , , , , , , , , , Bagian)
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub TglPricelist_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TglPricelist.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub CreateKeterangan()
        txtKeterangan.Text = "Tanggal Price List : " & Format(TglPricelist.DateTime, "dd-MM-yyyy") & vbCrLf & _
            " Diskon : " & TxtDiskonReguler.Text & " + " & TxtDiskon1.Text & " + " & TxtDiskon2.Text & " + " & TxtDiskon3.Text & " + " & TxtCashDiskon.Text
    End Sub

    Private Sub TxtDiskonReguler_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskonReguler.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub TxtDiskon1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskon1.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub TxtDiskon2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskon2.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub TxtDiskon3_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiskon3.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub TxtCashDiskon_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtCashDiskon.EditValueChanged
        CreateKeterangan()
    End Sub

    Private Sub TxtIdSalesman_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtIdSalesman.ButtonClick
        TxtIdSalesman.Text = Search(FrmPencarian.KeyPencarian.Karyawan, , , , , "Salesman")
    End Sub

    Private Sub TxtIdSalesman_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIdSalesman.EditValueChanged
        SetData("SELECT NAMA_USER FROM USERS WHERE ID_USER ='" & TxtIdSalesman.Text & "'", {TxtNamaSalesman})
    End Sub

    Private Sub TxtIdSalesman_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdSalesman.KeyPress
        If CharKeypress(TxtIdSalesman, e) Then TxtIdSalesman.Text = Search(FrmPencarian.KeyPencarian.Karyawan, , , , , "Salesman")
    End Sub
End Class

