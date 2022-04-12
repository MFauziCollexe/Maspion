Public Class FrmPerusahaan

    Protected dtCustomer As New DataTable

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Dispose()
    End Sub

    Private Sub FrmDivisi_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F4
                _Toolbar1_Button3.PerformClick()
        End Select
    End Sub

    Private Sub FrmDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadData.GetData("SELECT [NAMA] ,[INITIAL] ,[ALAMAT] ,[KOTA] ,[TELP] ,[FAX] ,[REKENING] ,[NPWP] ,[TGL_PENGUKUAN] ,[CUST_PEMBELIAN], EMAIL_OTP, OTP_AKTIF FROM PERUSAHAAN")
        LoadData.SetData({TxtNamaPerusahaan, TxtInisialPerusahaan, TxtAlamat, TxtKota, TxtTelepon, TxtFax, TxtRekening, TxtNPWP, DTPengukuhan, TxtIDCustomer, TxtEmailOTP, ChkOTP})


        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID DO", TypeCode.String, 20, False, , , DevExpress.Utils.DefaultBoolean.True)
        InitGrid.AddColumnGrid("No. DO", TypeCode.String, 50, True, , , DevExpress.Utils.DefaultBoolean.True, RBEdit)
        InitGrid.AddColumnGrid("Tgl Pengakuan", TypeCode.DateTime, 25, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Customer", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Total Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Total Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Pembuat", TypeCode.String, 40, False)
        InitGrid.EndInit(TBDO, GridView1, dtDO)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Nota", TypeCode.String, 20, False, , , DevExpress.Utils.DefaultBoolean.True)
        InitGrid.AddColumnGrid("No. Nota/SJ", TypeCode.String, 50, True, , , DevExpress.Utils.DefaultBoolean.True, RBeditNotaSJ)
        InitGrid.AddColumnGrid("Tgl Pengakuan", TypeCode.DateTime, 25, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Customer", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Total Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Total Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Pembuat", TypeCode.String, 40, False)
        InitGrid.EndInit(TBNotaSJ, GridView2, dtNotaSJ)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Bon", TypeCode.String, 20, False, , , DevExpress.Utils.DefaultBoolean.True)
        InitGrid.AddColumnGrid("No. Bon", TypeCode.String, 50, True, , , DevExpress.Utils.DefaultBoolean.True, RepoBon)
        InitGrid.AddColumnGrid("Tgl", TypeCode.DateTime, 25, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Customer", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Total Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Total Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Pembuat", TypeCode.String, 40, False)
        InitGrid.EndInit(TBBonTitipan, GridView3, dtBonTitipan)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Retur", TypeCode.String, 20, False, , , DevExpress.Utils.DefaultBoolean.True)
        InitGrid.AddColumnGrid("No. Retur", TypeCode.String, 50, True, , , DevExpress.Utils.DefaultBoolean.True, RepoReturPenjualan)
        InitGrid.AddColumnGrid("Tgl", TypeCode.DateTime, 25, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Customer", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Total Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Total Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Pembuat", TypeCode.String, 40, False)
        InitGrid.EndInit(TBReturPenjualan, GridView4, dtReturPenjualan)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Retur", TypeCode.String, 20, False, , , DevExpress.Utils.DefaultBoolean.True)
        InitGrid.AddColumnGrid("No. Retur", TypeCode.String, 50, True, , , DevExpress.Utils.DefaultBoolean.True, RepoReturPembelian)
        InitGrid.AddColumnGrid("Tgl", TypeCode.DateTime, 25, False, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Keterangan Internal", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Total Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Total Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Pembuat", TypeCode.String, 40, False)
        InitGrid.EndInit(TBReturPembelian, GridView5, dtReturPembelian)

        'Add Column Table Customer
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode PT", TypeCode.String, 25, True)
        InitGrid.AddColumnGrid("Nama PT", TypeCode.String, 75, False)
        InitGrid.AddColumnGrid("ID Customer", TypeCode.String, 25, True)
        InitGrid.AddColumnGrid("Kode Approve", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama Customer", TypeCode.String, 75, False)
        InitGrid.EndInit(TBCustomer, GVCustomer, dtCustomer)
        AddRow(dtCustomer)
        GVCustomer.Columns(0).ColumnEdit = RepoPT
        GVCustomer.Columns(2).ColumnEdit = ReBEdit

        LoadData.GetData("SELECT A.KODE_PT, B.NAMA, A.ID_CUSTOMER, C.KODE_APPROVE, C.NAMA FROM SETUP_CUSTOMER_PEMBELIAN A JOIN PT B ON A.KODE_PT=B.KODE
JOIN CUSTOMER C ON A.ID_CUSTOMER=C.ID")
        LoadData.SetDataDetail(dtCustomer, True)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty({TxtNamaPerusahaan, TxtInisialPerusahaan, TxtIDCustomer}) Then Exit Sub
        If QuestionInput() = False Then Exit Sub

        GVCustomer.CloseEditor()
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.Delete("PERUSAHAAN") = False Then Exit Sub
            If SQLServer.InsertHeader({TxtNamaPerusahaan, TxtInisialPerusahaan, TxtAlamat, TxtKota, TxtTelepon, TxtFax, TxtRekening, TxtNPWP, DTPengukuhan, TxtIDCustomer, ToSyntax("0"), TxtEmailOTP, ChkOTP}, "PERUSAHAAN") = False Then Exit Sub
            If SQLServer.Delete("SETUP_CUSTOMER_PEMBELIAN") = False Then Exit Sub
            If SQLServer.InsertDetail(dtCustomer, {"Kode PT", "ID Customer"}, "SETUP_CUSTOMER_PEMBELIAN") = False Then Exit Sub

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    'Customer
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , EBagian.Langganan_Pusat)
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , EBagian.Langganan_Pusat)
    End Sub
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        Using dtCustomer = SelectCon.execute("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR,LOKASI_PENGIRIMAN,SYARAT_PEMBAYARAN_KREDIT FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                TxtKodeApprove.Text = dtCustomer.Rows(0).Item("KODE_APPROVE")
                TxtNamaCustomer.Text = dtCustomer.Rows(0).Item("NAMA")
            Else
                TxtKodeApprove.Text = ""
                TxtNamaCustomer.Text = ""
            End If
        End Using
    End Sub

#Region "Ubah Nomor"
    Private dtDO As New DataTable
    Private Sub LoadNoDO()
        LoadData.GetData("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_DO,A.TGL_PENGAKUAN,B.NAMA,A.SUBTOTAL,A.DPP+A.PPN,C.NAMA_USER FROM DELIVERY_ORDER A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER WHERE YEAR(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "yyyy") & " AND MONTH(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "MM") & " AND A.BATAL=0")
        LoadData.SetDataDetail(dtDO, False)
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_DO", {e.Value}, "DELIVERY_ORDER", "ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("NO_DO", {e.Value}, "NOTA", "ID_DO='" & GridView1.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
    End Sub
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging, GridView2.CellValueChanging, GridView3.CellValueChanging
        SetDataTable(sender, e)
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        RBEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub
    Private Sub RBEdit_ButtonClick(sender As Object, e As System.EventArgs) Handles RBEdit.ButtonClick
        RBEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    End Sub

    Private dtNotaSJ As New DataTable
    Private Sub LoadNoSJ()
        LoadData.GetData("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL_PENGAKUAN,B.NAMA,A.SUBTOTAL,A.DPP+A.PPN,C.NAMA_USER FROM NOTA A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER WHERE YEAR(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "yyyy") & " AND MONTH(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "MM") & " AND A.BATAL=0")
        LoadData.SetDataDetail(dtNotaSJ, False)
    End Sub
    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_NOTA", {e.Value}, "NOTA", "ID_TRANSAKSI='" & GridView2.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("NO_TRANSAKSI", {e.Value}, "SALDO_STOK", "ID_TRANSAKSI='" & GridView2.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
    End Sub
    Private Sub GridView2_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView2.FocusedRowChanged
        RBeditNotaSJ.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub
    Private Sub RBeditNotaSJ_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RBeditNotaSJ.ButtonClick
        RBeditNotaSJ.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    End Sub

    Private dtBonTitipan As New DataTable
    Private Sub LoadNoBon()
        LoadData.GetData("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_BON,A.TGL_PENGAKUAN,B.NAMA,A.SUBTOTAL,A.DPP+A.PPN,C.NAMA_USER FROM BON_PESANAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER WHERE YEAR(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "yyyy") & " AND MONTH(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "MM") & " AND A.BATAL=0")
        LoadData.SetDataDetail(dtBonTitipan, False)
    End Sub
    Private Sub GridView3_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_BON", {e.Value}, "BON_PESANAN", "ID_TRANSAKSI='" & GridView3.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("NO_TRANSAKSI", {e.Value}, "SALDO_STOK", "ID_TRANSAKSI='" & GridView3.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
    End Sub
    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        RepoBon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub
    Private Sub RepoBon_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBon.ButtonClick
        RepoBon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    End Sub

    Private dtReturPenjualan As New DataTable
    Private Sub LoadNoreturPenjualan()
        LoadData.GetData("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA_RETUR,A.TGL_PENGAKUAN,B.NAMA,A.SUBTOTAL,A.DPP+A.PPN,C.NAMA_USER FROM RETUR_PENJUALAN A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID LEFT JOIN USERS C ON A.CRUSER=C.ID_USER WHERE YEAR(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "yyyy") & " AND MONTH(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "MM") & " AND A.BATAL=0")
        LoadData.SetDataDetail(dtReturPenjualan, False)
    End Sub
    Private Sub GridView4_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView4.CellValueChanged
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_NOTA_RETUR", {e.Value}, "RETUR_PENJUALAN", "ID_TRANSAKSI='" & GridView4.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("NO_TRANSAKSI", {e.Value}, "SALDO_STOK", "ID_TRANSAKSI='" & GridView4.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
    End Sub
    Private Sub GridView4_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView4.FocusedRowChanged
        RepoReturPenjualan.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub
    Private Sub RepoReturPenjualan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoReturPenjualan.ButtonClick
        RepoReturPenjualan.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    End Sub

    Private dtReturPembelian As New DataTable
    Private Sub LoadNoreturPembelian()
        LoadData.GetData("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_RETUR,A.TGL_PENGAKUAN,A.KETERANGAN_INTERNAL,A.SUBTOTAL,A.DPP+A.PPN,C.NAMA_USER FROM RETUR_PEMBELIAN A LEFT JOIN USERS C ON A.CRUSER=C.ID_USER WHERE YEAR(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "yyyy") & " AND MONTH(A.TGL_PENGAKUAN)=" & Format(DtTanggalAwal.Value, "MM") & " AND A.BATAL=0")
        LoadData.SetDataDetail(dtReturPembelian, False)
    End Sub
    Private Sub GridView5_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("NO_RETUR", {e.Value}, "RETUR_PEMBELIAN", "ID_TRANSAKSI='" & GridView5.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            If SQLServer.UpdateHeader("NO_TRANSAKSI", {e.Value}, "SALDO_STOK", "ID_TRANSAKSI='" & GridView5.GetFocusedDataRow(0) & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
    End Sub
    Private Sub GridView5_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView5.FocusedRowChanged
        RepoReturPembelian.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub
    Private Sub RepoReturPembelian_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoReturPembelian.ButtonClick
        RepoReturPembelian.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    End Sub
#End Region

    Private Sub BtnLoadDO_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadDO.Click
        SplashScreenManager1.ShowWaitForm()
        LoadNoDO()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnLoadNota_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadNota.Click
        SplashScreenManager1.ShowWaitForm()
        LoadNoSJ()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnLoadTitipan_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadTitipan.Click
        SplashScreenManager1.ShowWaitForm()
        LoadNoBon()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FrmPerusahaan_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        DtTanggalAwal.Value = "1/" & Now.Month.ToString & "/" & Now.Year.ToString
    End Sub

    Private Sub BtnLoadReturPenjualan_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadReturPenjualan.Click
        SplashScreenManager1.ShowWaitForm()
        LoadNoreturPenjualan()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnLoadReturPembelian_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadReturPembelian.Click
        SplashScreenManager1.ShowWaitForm()
        LoadNoreturPembelian()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PT_Keypress() Handles RepoPT.Click
        Dim kode = Search(FrmPencarian.KeyPencarian.PT)
        If dtCustomer.Select("[Kode PT]='" & kode & "'").Length = 0 Then
            Dim col As DataRow = GVCustomer.GetFocusedDataRow
            GVCustomer.SetFocusedValue(kode)
            col("Kode PT") = kode
            Using dtLoad = SelectCon.execute("SELECT KODE,NAMA FROM PT WHERE KODE='" & col("Kode PT") & "'")
                If dtLoad.Rows.Count > 0 Then
                    col("Kode PT") = dtLoad.Rows(0).Item(0)
                    col("Nama PT") = dtLoad.Rows(0).Item(1)
                Else
                    col("Kode PT") = ""
                    col("Nama PT") = ""
                End If
            End Using
            GVCustomer.FocusedColumn = GVCustomer.Columns("ID Customer")
        Else
            MsgBox("Kode PT Sudah Ada !!", MsgBoxStyle.Information)
            GVCustomer.FocusedColumn = GVCustomer.Columns("Kode PT")
        End If
    End Sub

    Private Sub Customer_Keypress() Handles ReBEdit.Click
        Dim kode = Search(FrmPencarian.KeyPencarian.Customer)
        If dtCustomer.Select("[ID Customer]='" & kode & "'").Length = 0 Then
            Dim col As DataRow = GVCustomer.GetFocusedDataRow
            GVCustomer.SetFocusedValue(kode)
            col("ID Customer") = kode
            Using dtLoad = SelectCon.execute("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & col("ID Customer") & "'")
                If dtLoad.Rows.Count > 0 Then
                    col("Kode Approve") = dtLoad.Rows(0).Item(0)
                    col("Nama Customer") = dtLoad.Rows(0).Item(1)
                Else
                    col("Kode Approve") = ""
                    col("Nama Customer") = ""
                End If
            End Using
            If col("ID Customer") <> "" And col("Kode PT") <> "" Then
                AddRow(dtCustomer)
                GVCustomer.FocusedColumn = GVCustomer.Columns("Kode PT")
            End If
        Else
            MsgBox("Kode Customer Sudah Ada !!", MsgBoxStyle.Information)
            GVCustomer.FocusedColumn = GVCustomer.Columns("ID Customer")
        End If
    End Sub

    Private Sub GVCustomer_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVCustomer.FocusedColumnChanged
        On Error Resume Next
        If Len(GVCustomer.GetFocusedRow("ID Customer").ToString.Trim) > 0 Then
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = True
        End If

        If Len(GVCustomer.GetFocusedRow("Kode PT").ToString.Trim) > 0 Then
            GVCustomer.Columns("Kode PT").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("Kode PT").OptionsColumn.AllowEdit = True
        End If
    End Sub
    Private Sub GVCustomer_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCustomer.FocusedRowChanged
        On Error Resume Next
        If Len(GVCustomer.GetFocusedRow("ID Customer").ToString.Trim) > 0 Then
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = True
        End If

        If Len(GVCustomer.GetFocusedRow("Kode PT").ToString.Trim) > 0 Then
            GVCustomer.Columns("Kode PT").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("Kode PT").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GVCustomer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GVCustomer.KeyDown
        If e.KeyCode = 46 Then
            GVCustomer.DeleteRow(GVCustomer.FocusedRowHandle)
            GVCustomer.FocusedColumn = GVCustomer.VisibleColumns(0)
            If GVCustomer.RowCount = 0 Then
                AddRow(dtCustomer)
                GVCustomer.FocusedColumn = GVCustomer.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub GVCustomer_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCustomer.CellValueChanging
        Try
            If IsNumeric(e.Value) Then
                GVCustomer.GetFocusedDataRow(GVCustomer.FocusedColumn.FieldName) = Val(e.Value)
            Else
                GVCustomer.GetFocusedDataRow(GVCustomer.FocusedColumn.FieldName) = e.Value
            End If
        Catch
        End Try
    End Sub

End Class

