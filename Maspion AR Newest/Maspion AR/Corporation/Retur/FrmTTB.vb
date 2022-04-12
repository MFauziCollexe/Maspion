
Public MustInherit Class FrmTTB
    Protected dt As New DataTable
    Protected Status_Edit As Boolean
    Protected Bagian As String

    Private Sub FrmTTB_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        'If Status_Edit Then
        '    TxtNoTransaksi.Properties.ReadOnly = True
        'Else : TxtNoTransaksi.Properties.ReadOnly = False
        'End If
    End Sub

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
        ShowDevexpressReport(ReportPreview.KeyReport.TTB, TxtIDTransaksi.Text)
        Log.Cetak(Me, TxtIDTransaksi.Text)
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
        InitGrid.AddColumnGrid("ID Barang", TypeCode.String, 35, False, , , , , False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 40, True, , , , ReBEdit)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 25, False, , , , ReBEdit)
        InitGrid.AddColumnGrid("Isi", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Koli", TypeCode.Single, 15, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Kuantum", TypeCode.Single, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Pieces", TypeCode.Single, 25, True, DevExpress.Utils.FormatType.Numeric, , , ReCalc)
        InitGrid.AddColumnGrid("Konv", TypeCode.Single, 15, False, DevExpress.Utils.FormatType.Numeric, , , , False)
        InitGrid.AddColumnGrid("Keterangan", TypeCode.String, 150, True)
        InitGrid.EndInit(TBDO, GridView1, dt)
        AddRow(dt)
    End Sub
    ''' <summary>
    ''' Customer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtIDCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDCustomer.EditValueChanged
        SetData("SELECT KODE_APPROVE,NAMA,ALAMAT_KANTOR FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'", {TxtKodeApprove, TxtNama, TxtAlamatKantor})
        Using dtCustomer = SelectCon.execute("SELECT NO_NPWP FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'")
            If dtCustomer.Rows.Count > 0 Then
                If dtCustomer.Rows(0).Item("NO_NPWP") <> "" Then
                    RdPKP.Enabled = True
                Else
                    RdPKP.Enabled = False
                End If
            End If
        End Using

        On Error Resume Next
        Bagian = SelectCon.execute("SELECT GROUP_CUSTOMER FROM CUSTOMER WHERE ID='" & TxtIDCustomer.Text & "'").Rows(0).Item(0)
        If Bagian = "" Then
            RdGroupCustomer.SelectedIndex = -1
        Else
            RdGroupCustomer.SelectedIndex = IIf(Bagian = "Distributor", 0, 1)
        End If
    End Sub
    Private Sub TxtKodeApprove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeApprove.ButtonClick
        TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , , TxtDivisi.Text)
    End Sub

    Private Sub TxtKodeApprove_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeApprove.KeyPress
        If CharKeypress(TxtIDCustomer, e) Then TxtIDCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer_Penjualan, , , , , , , , , , , , TxtDivisi.Text)

    End Sub
    ''' <summary>
    ''' Divisi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    Private Sub TBDO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDO.EditorKeyDown
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            ReBEdit.ReadOnly = False
        ElseIf GridView1.FocusedColumn.FieldName = "Satuan" Then
            ReBEdit.ReadOnly = True
        End If

        Select Case e.KeyCode
            Case System.Windows.Forms.Keys.Enter
                If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call REBEdit_Click(sender, e)
                ElseIf GridView1.FocusedColumn.FieldName = "Keterangan" Then
                    If GridView1.FocusedRowHandle = GridView1.RowCount - 1 Then
                        If Len(GridView1.GetFocusedRow("Kode Barang").ToString.Trim) > 0 Then
                            AddRow(dt)
                            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
                        End If
                    End If
                End If
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z"), Asc("0") To Asc("9"), System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Delete
                If GridView1.FocusedColumn.FieldName = "Satuan" Then
                    e.Handled = False
                    e.SuppressKeyPress = True
                    Call REBEdit_Click(sender, e)
                ElseIf GridView1.FocusedColumn.FieldName = "Keterangan" Then
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Gridview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub
    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        AllowEditColumn(GridView1, "Kode Barang", "Nama Barang")
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub
    ''' <summary>
    ''' Gudang
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtKodeGudang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtKodeGudang.ButtonClick
        TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub
    Private Sub TxtKodeGudang_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE ='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub
    Private Sub TxtKodeGudang_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeGudang.KeyPress
        If CharKeypress(TxtKodeGudang, e) Then TxtKodeGudang.Text = Search(FrmPencarian.KeyPencarian.Gudang)
    End Sub

    Private Sub REBEdit_Click(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        If GridView1.FocusedColumn.FieldName = "Kode Barang" Then
            If TxtDivisi.Text = "" Then
                MsgBox("Kolom Divisi Masih Kosong !!")
                TxtDivisi.Focus()
                Exit Sub
            End If

            If Bagian = "" Then
                MsgBox("Kolom Customer Masih Kosong !!")
                Exit Sub
            End If

            Dim col As DataRow = GridView1.GetFocusedDataRow()
            'CEK DATA ADA / TIDAK 
            Using dt_cari = SelectCon.execute("SELECT A.ID,A.KODE,A.NAMA, " & IIf(Bagian = "Distributor", "A.SAT_DIST1", "A.SAT_SUPER1") & " AS SATUAN," & IIf(Bagian = "Distributor", "A.QTY_KOLI", "A.QTY_DIST*A.QTY_KOLI") & " AS ISI ," & IIf(Bagian = "Distributor", "A.QTY_DIST", "1") & " AS KONV, FORMAT(HARGA_BARU,'n0','id-id') AS HARGA_BARU FROM BARANG A INNER JOIN V_SATUAN_TO_PCS B ON A.ID=B.ID AND B.SATUAN1= A.SAT_DIST1 LEFT JOIN VI_PRICE_LIST C ON A.ID=C.ID_BARANG  AND C.JENIS='" & IIf(Bagian = "Distributor", "Langganan", "Supermarket") & "' AND (C.ID='UMUM' OR C.ID='" & TxtIDCustomer.Text & "') LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "' AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_PRICE DESC")
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
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Keterangan") = dt_cari.Rows(0).Item("HARGA_BARU")
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
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
            Using dt_cari = SelectCon.execute("SELECT A.ID,A.KODE,A.NAMA, " & IIf(Bagian = "Distributor", "A.SAT_DIST1", "A.SAT_SUPER1") & " AS SATUAN , " & IIf(Bagian = "Distributor", "A.QTY_KOLI", "A.QTY_DIST*A.QTY_KOLI") & " AS ISI ," & IIf(Bagian = "Distributor", "A.QTY_DIST", "1") & " AS KONV, FORMAT(HARGA_BARU,'n0','id-id') AS HARGA_BARU FROM BARANG A INNER JOIN V_SATUAN_TO_PCS B ON A.ID=B.ID AND B.SATUAN1= A.SAT_DIST1 LEFT JOIN VI_PRICE_LIST C ON A.ID=C.ID_BARANG  AND C.JENIS='" & IIf(Bagian = "Distributor", "Langganan", "Supermarket") & "' AND (C.ID='UMUM' OR C.ID='" & TxtIDCustomer.Text & "') LEFT JOIN LINK_BARANG_DIVISI D ON A.ID=D.ID_BARANG WHERE A.ID='" & col("Kode Barang") & "' OR A.KODE='" & col("Kode Barang") & "' AND A.STATUS_AKTIF=1 AND D.KODE_DIVISI='" & TxtDivisi.Text & "' ORDER BY C.TGL_PRICE DESC")
                If dt_cari.Rows.Count > 0 Then
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = dt_cari.Rows(0).Item("ID")
                    col("Kode Barang") = dt_cari.Rows(0).Item("KODE")
                    GridView1.EditingValue = dt_cari.Rows(0).Item("KODE")
                    col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                    col("Satuan") = dt_cari.Rows(0).Item("SATUAN")
                    col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONV")), 0, dt_cari.Rows(0).Item("KONV"))
                    col("Keterangan") = dt_cari.Rows(0).Item("HARGA_BARU")
                    GridView1.FocusedColumn = GridView1.Columns("Koli")
                Else
                    col("No.") = GridView1.FocusedRowHandle + 1
                    col("ID Barang") = ""
                    col("Kode Barang") = ""
                    col("Nama Barang") = ""
                    col("Satuan") = ""
                    col("Isi") = 0
                    col("Koli") = 0
                    col("Kuantum") = 0
                    col("Pieces") = 0
                    col("Konv") = 0
                    col("Keterangan") = ""
                End If
            End Using

        ElseIf GridView1.FocusedColumn.FieldName = "Satuan" Then
            Dim col As DataRow = GridView1.GetFocusedDataRow()
            Dim satuan As String = Search(FrmPencarian.KeyPencarian.Satuan_Barang, , , , , _
                                          GridView1.GetFocusedRow("ID Barang"))
            If satuan = "" Then
                Exit Sub
            Else
                col("Satuan") = satuan
                Using dt_cari = SelectCon.execute("SELECT ISI,KONVERSI FROM BARANG CROSS APPLY( VALUES (SAT_DIST1,SAT_DIST2,QTY_KOLI,QTY_DIST),(SAT_SUPER1, SAT_SUPER2,QTY_DIST, 1)) AS B (SATUAN1,SATUAN2,ISI,KONVERSI) WHERE ID='" & col("ID Barang") & "' AND (SATUAN1='" & satuan & "' OR SATUAN2='" & satuan & "')")
                    If dt_cari.Rows.Count > 0 Then
                        col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                        col("Koli") = 0
                        col("Kuantum") = 0
                        col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONVERSI")), 0, dt_cari.Rows(0).Item("KONVERSI"))
                        col("Pieces") = 0
                    Else
                        'col("Isi") = IIf(IsDBNull(dt_cari.Rows(0).Item("ISI")), 0, dt_cari.Rows(0).Item("ISI"))
                        'col("Koli") = 0
                        'col("Kuantum") = 0
                        'col("Konv") = IIf(IsDBNull(dt_cari.Rows(0).Item("KONVERSI")), 0, dt_cari.Rows(0).Item("KONVERSI"))
                        'col("Pieces") = 0
                        MsgBox("Satuan Tidak Ditemukan !!")
                    End If
                End Using
                SendKeys.Send("{Right}")
            End If
        End If
    End Sub

    Private Sub ReCalc_EditValueChanged(sender As Object, e As System.EventArgs) Handles ReCalc.EditValueChanged
        Dim col As DataRow = GridView1.GetFocusedDataRow
        If GridView1.FocusedColumn.FieldName = "Koli" Then
            col("Kuantum") = CDbl(col("Isi")) * CDbl(col("Koli"))
            col("Pieces") = Math.Truncate(CDbl(col("Isi")) * CDbl(col("Koli")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Kuantum" Then
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
            col("Pieces") = Math.Truncate(CDbl(col("Kuantum")) * CDbl(col("Konv")))
        ElseIf GridView1.FocusedColumn.FieldName = "Pieces" Then
            col("Kuantum") = Math.Truncate((CDbl(col("Pieces")) / CDbl(col("Konv"))))
            col("Koli") = Math.Truncate((CDbl(col("Kuantum")) / CDbl(col("Isi"))))
        End If
    End Sub

#Region "Method"
    Private Sub AllowEditColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EditColumn As String, ByVal CheckColumn As String)
        On Error Resume Next
        If Len(Gridview.GetFocusedRow(CheckColumn).ToString.Trim) > 0 Then
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = False
        Else
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = True
        End If
    End Sub
    Protected Sub Urutan()
        For i = 0 To GridView1.RowCount - 1
            GridView1.GetDataRow(i)(0) = i + 1
        Next
    End Sub

#End Region

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.Columns("Kode Barang")
            End If
            Urutan()
        End If
    End Sub
End Class

#Region "Child"
Public Class InputTTB
    Inherits FrmTTB
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
        Bagian = ""
    End Sub

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Tanda Terima Barang"
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_TTB FROM TTB WHERE NO_TTB Like '" & TxtNamaDivisi.Text & "%' AND YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "' ORDER BY NO_TTB DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = TxtNamaDivisi.Text & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT TOP 1 NO_NOTA FROM TTB WHERE YEAR(TGL_PENGAKUAN)=" & Format(TglPengakuan.EditValue, "yyyy") & " ORDER BY NO_NOTA DESC")
            If dtGenerate.Rows.Count > 0 Then
                If dtGenerate.Rows(0).Item(0) = "" Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                TxtNoNota.Text = Format(urut, "000000")
                'MsgBox("Nomor Nota " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
                'Return False
            Else
                urut = 1
                TxtNoNota.Text = Format(urut, "000000")
            End If
        End Using

        'Using dtGenerate = SelectCon.execute("SELECT NO_TTB FROM TTB WHERE NO_TTB = '" & TxtNoTransaksi.Text & "' AND YEAR(TGL_PENGAKUAN)=" & Format(TglTransaksi.EditValue, "yyyy") & " AND DIVISI='" & TxtDivisi.Text & "'")
        '    If dtGenerate.Rows.Count > 0 Then
        '        MsgBox("Nomor Transaksi " & dtGenerate.Rows(0).Item(0) & " Telah dipakai !")
        '        Return False
        '    End If
        'End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'TTB','') AS INT)),0) AS ID FROM TTB")
            TxtIDTransaksi.Text = "TTB" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtKodeApprove, TxtIDCustomer, TxtDivisi, TglTransaksi, TglPengakuan, TxtKodeGudang, TglNota}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Pieces") = 0 Then
                    MsgBox("Ada Kuantum yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If Format(TglPengakuan.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        'If Generate() = False Then Exit Sub
        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, RdPKP}, "TTB") = False Then Exit Sub
            'Detail
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Keterangan", "No."}, "DETAIL_TTB") = False Then Exit Sub
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public Class EditTTB
    Inherits FrmTTB

    Private Function RestrictEdit() As Boolean
        Using dt As DataTable = SelectCon.execute("SELECT RETUR_PEMBELIAN.NO_RETUR FROM DETAIL_RETUR_PEMBELIAN INNER JOIN RETUR_PEMBELIAN ON DETAIL_RETUR_PEMBELIAN.ID_TRANSAKSI=RETUR_PEMBELIAN.ID_TRANSAKSI WHERE ID_TTB='" & TxtIDTransaksi.Text & "' AND BATAL=0 UNION ALL SELECT TRANSFER_BARANG_RETUR.NO_TRANSAKSI FROM DETAIL_TRANSFER_BARANG_RETUR INNER JOIN TRANSFER_BARANG_RETUR ON DETAIL_TRANSFER_BARANG_RETUR.ID_TRANSAKSI=TRANSFER_BARANG_RETUR.ID_TRANSAKSI WHERE ID_TTB='" & TxtIDTransaksi.Text & "' AND BATAL=0  UNION ALL SELECT NO_NOTA_RETUR FROM RETUR_PENJUALAN WHERE ID_TTB='" & TxtIDTransaksi.Text & "' AND BATAL=0 ")
            If dt.Rows.Count > 0 Then
                MsgBox("Transaksi sudah dalam proses selanjutnya dengan nomor : " & dt.Rows(0).Item(0) & "," & vbCrLf _
                       & "Anda tidak dapat mengubah transaksi ini !")
                Return True
            End If
        End Using

        Return False
    End Function

    Private Sub EditTTB_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Tanda Terima Barang"
        HakForm("", "Retur", "Tanda Terima Barang", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        TxtDivisi.Enabled = False
    End Sub

    Protected Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        LoadData.GetData("SELECT [NO_TTB] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL], [PRINT_PKP] FROM TTB WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
        LoadData.SetData({TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, RdPKP})

        LoadData.GetData("SELECT A.URUTAN,A.ID_BARANG, B.KODE, B.NAMA, A.SATUAN, A.ISI ,A.KOLI ,A.QUANTITY ,A.PCS ,A.KONVERSI ,A.KETERANGAN FROM DETAIL_TTB A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & TxtIDTransaksi.Text & "' ORDER BY URUTAN")
        LoadData.SetDataDetail(dt, True)
    End Sub

    Protected Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDCustomer, TxtDivisi, TglTransaksi, TxtKodeGudang, TxtNoNota, TglNota}) Then Exit Sub
        If RestrictEdit() Then Exit Sub

        If dt.Select("[Kode Barang]<>''").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            If Len(GridView1.GetDataRow(i)(2)) > 0 Then
                If GridView1.GetDataRow(i)("Pieces") = 0 Then
                    MsgBox("Ada Kuantum yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Kuantum")
                    Exit Sub
                End If
            End If
        Next

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.UpdateHeader("[NO_TTB] ,[TGL] ,[TGL_PENGAKUAN] ,[NO_NOTA] ,[TGL_NOTA] ,[DIVISI] ,[KODE_CUSTOMER] ,[KODE_APPROVE] ,[ALAMAT] ,[GUDANG] ,[KETERANGAN_CETAK] ,[KETERANGAN_INTERNAL] ,[MDUSER] ,[MDTIME], [PRINT_PKP]", {TxtNoTransaksi, TglTransaksi, TglPengakuan, TxtNoNota, TglNota, TxtDivisi, TxtIDCustomer, TxtKodeApprove, TxtAlamatGudang, TxtKodeGudang, txtKeterangan, txtKeteranganInternal, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP"), RdPKP}, "TTB", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            'Detail
            If SQLServer.Delete("DETAIL_TTB", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("[Kode Barang]<>''").CopyToDataTable, {ToObject(TxtIDTransaksi.Text), ToObject(TxtNoTransaksi.Text), "ID Barang", "Isi", "Koli", "Kuantum", "Satuan", "Konv", "Pieces", "Keterangan", "No."}, "DETAIL_TTB") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Protected Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If RestrictEdit() Then Exit Sub
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("DETAIL_TTB", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("TTB", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Protected Sub BatalTransaksi() Handles _Toolbar1_Button4.ItemClick
        If RestrictEdit() Then Exit Sub
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "TTB", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class
#End Region