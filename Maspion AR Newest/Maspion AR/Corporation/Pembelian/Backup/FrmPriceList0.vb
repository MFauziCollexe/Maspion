
Public Class FrmPriceList
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean = False

#Region "Shared Sub"
    Protected Sub Batal()
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub
    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_TRANSAKSI FROM PRICE_LIST WHERE NO_TRANSAKSI Like 'PL/" & Format(TglTransaksi.DateTime, "yyMM") & "%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_TRANSAKSI DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PL/" & Format(TglTransaksi.DateTime, "yyMM") & "/" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PL','') AS BIGINT)),0) AS ID FROM PRICE_LIST")
            TxtIDTransaksi.Text = "PL" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
    End Sub
    Protected Sub Simpan()
        If Empty({TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)("Kode Barang")) > 0 Then
                If GridView1.GetDataRow(i)("Harga Baru") = 0 Then
                    MsgBox("Ada Harga Baru Masih Nol !!!", MsgBoxStyle.Information, "Peringatan")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Harga Baru")
                    Exit Sub
                End If
            End If
        Next

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
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPriceList, TxtIDCustomer, TxtKodeApprove, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, "PRICE_LIST") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan Besar", "Satuan Besar2", "Isi", "Satuan Kecil", "Satuan Kecil2", "Harga Lama", "Harga Baru", "JENIS SATUAN", "No."}, "DETAIL_PRICE_LIST") = False Then Exit Sub
            For Each dr As DataRow In dt.Select("[Kode Barang]<>''").CopyToDataTable.Rows
                If SQLServer.UpdateHeader(IIf(dr("JENIS SATUAN") = "Langganan", "HARGA_DIST", "HARGA_SUPER"), {dr("Harga Baru")}, "BARANG", "ID='" & dr("ID Barang") & "'") = False Then Exit Sub
            Next
            SQLServer.EndTransaction()
            Log.Insert(Me, TxtIDTransaksi.Text)
            Batal()
        End Using
    End Sub

    Protected Sub GetData()
        If TxtIDTransaksi.Text <> "" Then
            LoadData.GetData("SELECT [NO_TRANSAKSI] ,[TGL] ,[TGL_PRICE] ,[DIVISI] ,[JENIS_PRICE] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] FROM PRICE_LIST WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPriceList, TxtIDCustomer, TxtKodeApprove, txtKeterangan, txtKeteranganInternal})

            LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.SATUAN1,A.ISI,A.SATUANK,A.SATUANK1,A.HARGA_LAMA,A.HARGA_BARU,A.JENIS FROM DETAIL_PRICE_LIST A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, True)
        End If
        Log.Load(Me, TxtIDTransaksi.Text)
        Urutan()
    End Sub

    Protected Sub SimpanEdit()
        If Empty({TxtDivisi, TglTransaksi, TglPengakuan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)("Kode Barang")) > 0 Then
                If GridView1.GetDataRow(i)("Harga Baru") = 0 Then
                    MsgBox("Ada Harga Baru Masih Nol !!!", MsgBoxStyle.Information, "Peringatan")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Harga Baru")
                    Exit Sub
                End If
            End If
        Next

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_TRANSAKSI] ,[TGL] ,[TGL_PRICE] ,[DIVISI] ,[JENIS_PRICE] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtDivisi, RDJenisPriceList, TxtIDCustomer, TxtKodeApprove, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "PRICE_LIST", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_PRICE_LIST", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Satuan Besar", "Satuan Besar2", "Isi", "Satuan Kecil", "Satuan Kecil2", "Harga Lama", "Harga Baru", "JENIS SATUAN", "No."}, "DETAIL_PRICE_LIST") = False Then Exit Sub
            For Each dr As DataRow In dt.Select("[Kode Barang]<>''").CopyToDataTable.Rows
                If SQLServer.UpdateHeader(IIf(dr("JENIS SATUAN") = "Langganan", "HARGA_DIST", "HARGA_SUPER"), {dr("Harga Baru")}, "BARANG", "ID='" & dr("ID Barang") & "'") = False Then Exit Sub
            Next
            SQLServer.EndTransaction()
            Log.Edit(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus()
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_PRICE_LIST", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("PRICE_LIST", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi()
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "PRICE_LIST", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Batal(Me, TxtIDTransaksi.Text)
            Me.Dispose()
        End Using
    End Sub
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
        TglPengakuan.DateTime = Format(Now.Date, "dd/MM/yyyy")

        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 60, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan Besar", TypeCode.String, 50, , , , , ReBEdit)
        InitGrid.AddColumnGrid("Satuan Besar2", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Isi", TypeCode.Double, 15, False, DevExpress.Utils.FormatType.Numeric)
        InitGrid.AddColumnGrid("Satuan Kecil", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Satuan Kecil2", TypeCode.String, 0, False, , , , , False)
        InitGrid.AddColumnGrid("Harga Lama", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Harga Baru", TypeCode.Double, 50, True, DevExpress.Utils.FormatType.Numeric, "n2", , ReCalc)
        InitGrid.AddColumnGrid("JENIS SATUAN", TypeCode.String, 0, False, , , , , False)
        InitGrid.EndInit(TBDetailPrice, GridView1, dt)
        GridView1.Columns("Satuan Besar").OptionsColumn.ReadOnly = True
        AddRow(dt)
    End Sub

    Private Sub TxtDivisi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtDivisi.ButtonClick
        TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub
    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(TxtDivisi, e) Then TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub TBDO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDetailPrice.EditorKeyDown
        Dim KeyAscii As Integer = e.KeyCode
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call ReBEdit_ButtonClick(sender, New System.EventArgs)
            End Select
        ElseIf GridView1.FocusedColumn.FieldName = "Satuan Besar" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter, System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.Left
                Case Else
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call ReBEdit_ButtonClick(sender, New System.EventArgs)
            End Select
        ElseIf GridView1.FocusedColumn.FieldName = "Harga Baru" Then
            Select Case KeyAscii
                Case System.Windows.Forms.Keys.Enter
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Kode Barang").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            End If
        End If
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ReBEdit_ButtonClick(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If

            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT A.ID, A.KODE, A.NAMA, A.SAT_DIST1, A.SAT_DIST2, A.QTY_DIST, A.SAT_SUPER1, A.SAT_SUPER2, A.HARGA_DIST,A.HARGA_DIST FROM BARANG A WHERE A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "'")
                If dt_cari.Rows.Count > 0 Then
                    If dt.Select("[ID Barang]='" & col("Kode Barang") & "' OR [Kode Barang]='" & col("Kode Barang") & "'").Length > 1 Then
                        MsgBox("Barang Sudah Ada !!")
                        col("ID Barang") = ""
                        GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        Exit Sub
                    End If
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Satuan Besar") = dt_cari.Rows(0).Item("SAT_DIST1")
                    col("Satuan Besar2") = dt_cari.Rows(0).Item("SAT_DIST2")
                    col("Isi") = dt_cari.Rows(0).Item("QTY_DIST")
                    col("Satuan Kecil") = dt_cari.Rows(0).Item("SAT_SUPER1")
                    col("Satuan Kecil2") = dt_cari.Rows(0).Item("SAT_SUPER2")
                    col("Harga Lama") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("Harga Baru") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("JENIS SATUAN") = "Langganan"
                    GridView1.FocusedColumn = GridView1.Columns("Satuan Besar")
                    Exit Sub
                Else
                    GoTo CariData
                End If
            End Using

CariData:
            Dim kode As String = Search(FrmPencarian.KeyPencarian.Barang_Divisi, GridView1.EditingValue, _
                              FrmPencarian.TypeButton.Barang, , , TxtDivisi.Text)
            If kode = "" Then
                col("ID Barang") = kode
                GridView1.EditingValue = kode
            Else
                If dt.Select("[ID Barang]='" & kode & "'").Length > 0 Then
                    MsgBox("Barang Sudah Ada !!")
                    col("ID Barang") = ""
                    GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                    Exit Sub
                Else
                    col("ID Barang") = kode
                    GridView1.EditingValue = kode
                End If
            End If
            Using dt_cari = SelectCon.execute("SELECT A.ID, A.KODE, A.NAMA, A.SAT_DIST1, A.SAT_DIST2, A.QTY_DIST, A.SAT_SUPER1, A.SAT_SUPER2, A.HARGA_DIST,A.HARGA_DIST FROM BARANG A WHERE A.ID='" & col("ID Barang") & "'")
                If dt_cari.Rows.Count > 0 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Satuan Besar") = dt_cari.Rows(0).Item("SAT_DIST1")
                    col("Satuan Besar2") = dt_cari.Rows(0).Item("SAT_DIST2")
                    col("Isi") = dt_cari.Rows(0).Item("QTY_DIST")
                    col("Satuan Kecil") = dt_cari.Rows(0).Item("SAT_SUPER1")
                    col("Satuan Kecil2") = dt_cari.Rows(0).Item("SAT_SUPER2")
                    col("Harga Lama") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("Harga Baru") = dt_cari.Rows(0).Item("HARGA_DIST")
                    col("JENIS SATUAN") = "Langganan"
                    GridView1.FocusedColumn = GridView1.Columns("Satuan Besar")
                Else
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = ""
                    col("Kode Barang") = ""
                    col("Nama Barang") = ""
                    col("Satuan Besar") = ""
                    col("Satuan Besar2") = ""
                    col("Isi") = 0
                    col("Satuan Kecil") = ""
                    col("Satuan Kecil2") = ""
                    col("Harga Lama") = 0
                    col("Harga Baru") = 0
                    col("JENIS SATUAN") = ""
                End If
            End Using
        ElseIf GridView1.FocusedColumn.FieldName = "Satuan Besar" Then
            Dim col As DataRow = GridView1.GetFocusedDataRow()
            Dim satuan As String = Search(FrmPencarian.KeyPencarian.Satuan_Barang, , , , , _
                                          GridView1.GetFocusedRow("ID Barang"))
            If satuan = "" Then
                Exit Sub
            Else
                col("Satuan Besar") = satuan
                Using dt_cari = SelectCon.execute("SELECT SATUANA1, SATUANA2, ISI,SATUANB1,SATUANB2,HARGA,JENIS FROM BARANG CROSS APPLY(VALUES (SAT_DIST1, SAT_DIST2, QTY_DIST, SAT_SUPER1, SAT_SUPER2,HARGA_DIST,'Langganan'), (SAT_SUPER1, SAT_SUPER2, 1,SAT_SUPER1, SAT_SUPER2,HARGA_SUPER,'Supermarket')) AS C (SATUANA1, SATUANA2, ISI,SATUANB1,SATUANB2, HARGA,JENIS) WHERE ID='" & col("ID Barang") & "' AND (SATUANA1='" & satuan & "' OR SATUANA2='" & satuan & "')")
                    If dt_cari.Rows.Count > 0 Then
                        col("Satuan Besar") = dt_cari.Rows(0).Item("SATUANA1")
                        col("Satuan Besar2") = dt_cari.Rows(0).Item("SATUANA2")
                        col("Isi") = dt_cari.Rows(0).Item("ISI")
                        col("Satuan Kecil") = dt_cari.Rows(0).Item("SATUANB1")
                        col("Satuan Kecil2") = dt_cari.Rows(0).Item("SATUANB2")
                        col("Harga Lama") = dt_cari.Rows(0).Item("HARGA")
                        col("Harga Baru") = dt_cari.Rows(0).Item("HARGA")
                        col("JENIS SATUAN") = dt_cari.Rows(0).Item("JENIS")
                    Else
                        col("Satuan Besar") = ""
                        col("Satuan Besar2") = ""
                        col("Isi") = 0
                        col("Satuan Kecil") = ""
                        col("Satuan Kecil2") = ""
                        col("Harga Lama") = 0
                        col("Harga Baru") = 0
                        col("JENIS SATUAN") = ""
                    End If
                End Using
                SendKeys.Send("{Right}")
            End If
        End If
    End Sub

    Private Sub RDJenisPriceList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenisPriceList.SelectedIndexChanged
        If RDJenisPriceList.SelectedIndex = 0 Then
            TxtKodeApprove.Enabled = False
            TxtKodeApprove.Text = ""
        ElseIf RDJenisPriceList.SelectedIndex = 1 Then
            TxtKodeApprove.Enabled = True
        End If
    End Sub

    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan)
    End Sub
    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged, TxtKodeApprove.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama})
    End Sub
    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan)
    End Sub

    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

    Private Sub RDJenis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDJenis.SelectedIndexChanged
        If RDJenis.SelectedIndex > -1 Then
            TBDetailPrice.Enabled = True
        End If
    End Sub
End Class

Public Class InputPriceList
    Inherits FrmPriceList

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Price List"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False

        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf Simpan
    End Sub
End Class

Public Class EditPriceList
    Inherits FrmPriceList

    Private Sub EditDeliveryOrderLanggananPusat_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Price List"
        TxtDivisi.Enabled = False
        Status_Edit = True
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        AddHandler TxtIDTransaksi.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button5.ItemClick, AddressOf Hapus
        AddHandler _Toolbar1_Button4.ItemClick, AddressOf BatalTransaksi
        AddHandler _Toolbar1_Button1.ItemClick, AddressOf SimpanEdit
    End Sub

    
End Class