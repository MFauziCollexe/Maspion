
Public MustInherit Class FrmSJTitipBarang
    Protected dt As New DataTable
    Protected Status_Edit As Boolean
    Protected Bagian As String

#Region "Shared Sub"

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT TOP 1 NO_SJ FROM SJ_TITIP_BARANG WHERE NO_SJ Like 'SJTB/" & TxtNamaDivisi.Text & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_SJ DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "SJTB/" & TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'SJTB','') AS BIGINT)),0) AS ID FROM SJ_TITIP_BARANG")
            TxtIDTransaksi.Text = "SJTB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub

    Protected Sub Simpan()
        If Empty({TglTransaksi, TglPengakuan, TxtIDTB}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTB, TxtNoTB, TglTB, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, Bagian}, "SJ_TITIP_BARANG") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli SJ", "Qty SJ", "Satuan", "Konv", "Pcs SJ", "Harga Satuan", "No."}, "DETAIL_SJ_TITIP_BARANG") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pcs SJ"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        LoadData.GetData("SELECT [NO_SJ] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TITIP] ,[NO_TITIP] ,[TGL_TITIP] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] FROM SJ_TITIP_BARANG WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTB, TxtNoTB, TglTB, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,A.ISI, ROUND(B.KOLI-B.KOLI_T+A.KOLI,0), ROUND(B.QUANTITY-B.QUANTITY_T+A.QUANTITY,0), ROUND(B.PCS-B.PCS+A.PCS,0),A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.HARGA,ROUND(A.PCS * (A.HARGA) / A.KONVERSI,2) FROM SJ_TITIP_BARANG INNER JOIN DETAIL_SJ_TITIP_BARANG A ON SJ_TITIP_BARANG.ID_TRANSAKSI=A.ID_TRANSAKSI INNER JOIN V_D_TITIP_T_SJ B ON SJ_TITIP_BARANG.ID_TITIP=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtKodeGudang}) Then Exit Sub
        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_SJ] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_TITIP] ,[NO_TITIP] ,[TGL_TITIP] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDTB, TxtNoTB, TglTB, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "SJ_TITIP_BARANG", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_SJ_TITIP_BARANG", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli SJ", "Qty SJ", "Satuan", "Konv", "Pcs SJ", "Harga Satuan", "No."}, "DETAIL_SJ_TITIP_BARANG") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(Format(TglTransaksi.DateTime, "MM/dd/yyyy")), ToObject(Format(TglPengakuan.DateTime, "MM/dd/yyyy")), ToObject(TxtKodeGudang.Text), "ID Barang", "Kode Barang", ToNegative("Pcs SJ"), "Satuan", "Harga Satuan", ToObject(periode)}, "SALDO_STOK", "[ID_TRANSAKSI] ,[NO_TRANSAKSI] ,[TGL_TRANSAKSI] ,[TGL_PENGAKUAN] ,[GUDANG] ,[ID_BARANG] ,[KODE_BARANG] ,[QUANTITY] ,[SATUAN] ,[HARGA] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_SJ_TITIP_BARANG", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SALDO_STOK", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("SJ_TITIP_BARANG", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "SJ_TITIP_BARANG", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
#End Region

#End Region

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
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
        'GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 50, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 80, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli Titip", TypeCode.Decimal, 40, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Titip", TypeCode.Decimal, 40, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Titip", TypeCode.Decimal, 40, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli SJ", TypeCode.Decimal, 40, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty SJ", TypeCode.Decimal, 40, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs SJ", TypeCode.Decimal, 40, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Decimal, 100, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Decimal, 170, False, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDO, GridView1, dt)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli SJ" Then
            If Val(col("Koli SJ")) > col("Koli Titip") Then
                MsgBox("Koli SJ Tidak Boleh Melebihi Koli Titip !!")
                col("Koli SJ") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty SJ" Then
            If Val(col("Qty SJ")) > col("Qty Titip") Then
                MsgBox("Qty SJ Tidak Boleh Melebihi Qty Titip !!")
                col("Qty SJ") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs SJ" Then
            If Val(col("Pcs SJ")) > col("Pcs Titip") Then
                MsgBox("Pcs SJ Tidak Boleh Melebihi Pcs Titip !!")
                col("Pcs SJ") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        End If

        If GridView1.FocusedColumn.FieldName = "Koli SJ" Then
            col("Qty SJ") = CDbl(col("Isi")) * CDbl(col("Koli SJ"))
            col("Pcs SJ") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli SJ")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Qty SJ" Then
            col("Koli SJ") = Math.Truncate((CDbl(col("Qty SJ")) / CDbl(col("Isi"))))
            col("Pcs SJ") = Math.Truncate(CDbl(col("Qty SJ")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs SJ" Then
            col("Qty SJ") = Math.Truncate((CDbl(col("Pcs SJ")) / CDbl(col("Konv"))))
            col("Koli SJ") = Math.Truncate((CDbl(col("Qty SJ")) / CDbl(col("Isi"))))
        End If
        Hitung()
    End Sub

    Private Sub TxtIDTB_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDTB.EditValueChanged
        If Status_Edit = False Then
            LoadData.GetData("SELECT NO_NOTA,TGL,DIVISI,KODE_CUSTOMER,ALAMAT_KIRIM,GUDANG FROM TITIP_BARANG WHERE ID_TRANSAKSI='" & TxtIDTB.Text & "'")
            LoadData.SetData({TxtNoTB, TglTB, TxtDivisi, TxtIDCustomer, TxtAlamatKirim, TxtKodeGudang})

            Try
                Bagian = SelectCon.execute("SELECT BAGIAN FROM TITIP_BARANG WHERE ID_TRANSAKSI='" & TxtIDTB.Text & "'").Rows(0).Item(0)
            Catch
            End Try

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.ISI,ROUND(A.KOLI-A.KOLI_T,0),ROUND(A.QUANTITY-A.QUANTITY_T,0),ROUND(A.PCS-A.PCS_T,0),ROUND(A.KOLI-A.KOLI_T,0),ROUND(A.QUANTITY-A.QUANTITY_T,0),ROUND(A.PCS-A.PCS_T,0),A.KONVERSI,A.HARGA,ROUND((A.PCS-A.PCS_T) * A.HARGA / A.KONVERSI,2) FROM V_D_TITIP_T_SJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTB.Text & "' AND A.ST=0 ORDER BY URUTAN")
            LoadData.SetDataDetail(dt, False)
            Urutan()
            Hitung()
        End If
    End Sub
    Private Sub TxtNoTB_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoTB.ButtonClick
        TxtIDTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Titip_Barang)
    End Sub
    Private Sub TxtNoTB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoTB.KeyPress
        If CharKeypress(TxtIDTB, e) Then TxtIDTB.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Titip_Barang)
    End Sub

    Protected Sub Hitung()
        On Error Resume Next
        Dim TempTotalDiskon As Decimal = 0
        Dim Total As Decimal = 0
        Dim Subtotal As Decimal = 0
        For Each col As DataRow In dt.Rows
            Subtotal = 0
            Subtotal = col("Pcs SJ") * (col("Harga Satuan") / col("Konv"))
            If Subtotal >= 0 Then
                col("Subtotal") = Subtotal
            End If
        Next
    End Sub
End Class


