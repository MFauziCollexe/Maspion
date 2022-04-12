
Public MustInherit Class FrmSJ
    Protected dt As New DataTable
    Private _Status_Edit As Boolean
    Property Status_Edit As Boolean
        Set(value As Boolean)
            _Status_Edit = value
            If value Then
                TxtNoNota.Enabled = False
            Else
                TxtNoNota.Enabled = True
            End If
        End Set
        Get
            Return _Status_Edit
        End Get
    End Property
    Private _Bagian As EBagian
    Property Bagian As EBagian
        Set(value As EBagian)
            _Bagian = value
            LblTitle.Caption = "SJ Tanpa Harga " & EnumDescription(value)
        End Set
        Get
            Return _Bagian
        End Get
    End Property

#Region "Shared Sub"
    Private Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        If _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then Exit Sub
        ShowDevexpressReport(ReportPreview.KeyReport.Surat_Jalan, TxtIDTransaksi.Text)
    End Sub

#Region "Input"
    Protected Sub Batal()
        Clean(Me)
        TxtDivisi.Enabled = True
        dt.Clear()
        AddRow(dt)
    End Sub

    Protected Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(NO_SJ AS BIGINT)), 0) NO_SJ FROM SURAT_JALAN WHERE YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND BAGIAN LIKE '%Langganan%'")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = Format(urut, "000000")
        End Using

        'Using dtGenerate = SelectCon.execute("SELECT TOP 1 NO_SJ FROM SURAT_JALAN WHERE NO_SJ ='" & TxtNoTransaksi.Text & "'")
        '    If dtGenerate.Rows.Count > 0 Then
        '        MsgBox("Nomor Transaksi " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
        '        Return False
        '    End If
        'End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'SJ','') AS BIGINT)),0) AS ID FROM SURAT_JALAN")
            TxtIDTransaksi.Text = "SJ" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Protected Sub Simpan()
        If Empty({TglPengakuan, TxtIDNota}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        'MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, EnumDescription(Bagian), RdPKP}, "SURAT_JALAN") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(TxtIDNota.Text), "ID Barang", "Satuan", "Koli SJ", "Qty SJ", "Pcs SJ", "Konv", "Isi", "No."}, "DETAIL_SURAT_JALAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub
#End Region

#Region "Edit"
    Protected Sub GetData()
        LoadData.GetData("SELECT [NO_SJ] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_NOTA] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL], [PRINT_PKP] FROM SURAT_JALAN WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, RdPKP})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,C.KODE,C.NAMA,A.SATUAN,(B.KOLI-B.KOLI_T)+A.KOLI,(B.QUANTITY-B.QUANTITY_T)+A.QUANTITY,(B.PCS-B.PCS_T)+A.PCS,A.KOLI,A.QUANTITY,A.PCS,A.KONVERSI,A.ISI FROM DETAIL_SURAT_JALAN A INNER JOIN V_D_NOTA_T_SJ B ON A.ID_NOTA=B.ID_TRANSAKSI AND A.ID_BARANG=B.ID_BARANG LEFT JOIN BARANG C ON A.ID_BARANG=C.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN")
        LoadData.SetDataDetail(dt, False)
        Log.Load(Me, TxtIDTransaksi.Text)
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TglPengakuan, TxtIDNota}) Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_SJ] ,[TGL] ,[TGL_PENGAKUAN] ,[ID_NOTA] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT_KIRIM] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME] ,[PRINT_PKP]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtIDNota, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), RdPKP}, "SURAT_JALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_SURAT_JALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), ToObject(TxtIDNota.Text), "ID Barang", "Satuan", "Koli SJ", "Qty SJ", "Pcs SJ", "Konv", "Isi", "No."}, "DETAIL_SURAT_JALAN") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("SURAT_JALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("DETAIL_SURAT_JALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "SURAT_JALAN", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
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
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 60, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Koli Nota", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Qty Nota", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Pcs Nota", TypeCode.Decimal, 25, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Koli SJ", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Qty SJ", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pcs SJ", TypeCode.Decimal, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Decimal, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.EndInit(TBDO, GridView1, dt)
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.Column.OptionsColumn.AllowFocus Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    ''' <summary>
    ''' Cari Nota
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtNoNota_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoNota.ButtonClick
        TxtIDNota.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Perwakilan, , , , , , , , Bagian)
    End Sub
    Private Sub TxtNoNota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoNota.KeyPress
        If CharKeypress(TxtIDNota, e) Then TxtIDNota.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Nota_Perwakilan, , , , , , , , Bagian)
    End Sub
    Private Sub TxtIDNota_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDNota.EditValueChanged
        If Status_Edit = False Then
            Using MyLoadData As New _LoadData
                LoadData.GetData("SELECT NO_NOTA,TGL,DIVISI,KODE_CUSTOMER,KODE_APPROVE,ALAMAT_KIRIM,KETERANGAN_CETAK,KETERANGAN_INTERNAL FROM NOTA WHERE ID_TRANSAKSI='" & TxtIDNota.Text & "'")
                LoadData.SetData({TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatKirim, txtKeterangan, txtKeteranganInternal})

                LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QTY,A.PCS-A.PCS_T AS PCS,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.KONVERSI,A.ISI FROM V_D_NOTA_T_SJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDNota.Text & "' AND ST=0")
                LoadData.SetDataDetail(dt, False)
                Urutan()
            End Using
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli SJ" Then
            If Val(col("Koli SJ")) > col("Koli Nota") Then
                MsgBox("Koli SJ Tidak Boleh Melebihi Koli Nota !!")
                col("Koli SJ") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Qty SJ" Then
            If Val(col("Qty SJ")) > col("Qty Nota") Then
                MsgBox("Qty SJ Tidak Boleh Melebihi Qty Nota !!")
                col("Qty SJ") = 0
                GridView1.EditingValue = 0
                GridView1.RefreshEditor(True)
            End If
        ElseIf GridView1.FocusedColumn.FieldName = "Pcs SJ" Then
            If Val(col("Pcs SJ")) > col("Pcs Nota") Then
                MsgBox("Pcs SJ Tidak Boleh Melebihi Pcs Nota !!")
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
    End Sub

End Class


