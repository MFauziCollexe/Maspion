Public MustInherit Class FrmCustomer
   
    Public dtBank As New DataTable
    Public dtJaminan As New DataTable
    Public dtLimitPiutang As New DataTable
    Public dtCabang As New DataTable

    Private Sub FrmCustomer_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F4
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F7
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub LoadCombo()
        'Load Provinsi
        Try
            CmbDataLanggananPropinsi.Properties.Items.Clear()
            CmbDataPropinsi.Properties.Items.Clear()
            CmbNPWPKota.Properties.Items.Clear()
            CmbInformasiKota.Properties.Items.Clear()
            CmbInformasiReferensiKota.Properties.Items.Clear()
            CmbDataPemilikKota.Properties.Items.Clear()
        Catch
        End Try
        Using dtload = SelectCon.execute("SELECT NAMA FROM PROVINSI ORDER BY NAMA")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    CmbDataLanggananPropinsi.Properties.Items.Add(dtload.Rows(I).Item(0))
                    CmbDataPropinsi.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
        'Load Kota
        Using dtload = SelectCon.execute("SELECT KOTA FROM DETAIL_PROVINSI ORDER BY KOTA")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    CmbNPWPKota.Properties.Items.Add(dtload.Rows(I).Item(0))
                    CmbInformasiKota.Properties.Items.Add(dtload.Rows(I).Item(0))
                    CmbInformasiReferensiKota.Properties.Items.Add(dtload.Rows(I).Item(0))
                    CmbDataPemilikKota.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
        'Load PT
        Using dtload = SelectCon.execute("SELECT KODE+'-'+NAMA FROM PT ORDER BY NAMA")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    CmbPT.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
    End Sub

    Private Sub FrmCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Add Column Table Hubungan Bank
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Nama Bank", TypeCode.String)
        InitGrid.AddColumnGrid("Pemilik", TypeCode.String)
        InitGrid.AddColumnGrid("No. Account", TypeCode.String)
        InitGrid.AddColumnGrid("Keterangan", TypeCode.String)
        InitGrid.EndInit(TBInformasiHubunganBank, GridView1, dtBank)
        AddRow(dtBank)
        'Add Column Table Jaminan
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Jaminan", TypeCode.String)
        InitGrid.EndInit(TBInformasiJaminan, GridView2, dtJaminan)
        AddRow(dtJaminan)
        'Add Column Table Limit Piutang
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode SBU", TypeCode.String, False)
        InitGrid.AddColumnGrid("SBU", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("Nilai", TypeCode.Double, 50, True, DevExpress.Utils.FormatType.Numeric, "c2")
        InitGrid.EndInit(TBDataPemilikLimitPiutang, GridView3, dtLimitPiutang)
        GridView3.Columns("Kode SBU").ColumnEdit = ReBEdit
        GridView3.Columns("Nilai").ColumnEdit = RepoCalcPiutang
        AddRow(dtLimitPiutang)

        'Add Column Table Cabang
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Cabang", TypeCode.String, 25)
        InitGrid.AddColumnGrid("Nama Cabang", TypeCode.String, 50)
        InitGrid.AddColumnGrid("Alamat Cabang", TypeCode.String, 100)
        InitGrid.EndInit(TBCabang, GridView4, dtCabang)
        AddRow(dtCabang)
        LoadCombo()
    End Sub

    Private Sub keluar_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dtBank.Dispose()
        dtJaminan.Dispose()
        dtLimitPiutang.Dispose()
        Dispose()
    End Sub

    Private Sub CmbDataLanggananPropinsi_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbDataLanggananPropinsi.SelectedIndexChanged
        CmbDataLanggananKota.Properties.Items.Clear()
        Try
            Using dtload = SelectCon.execute("SELECT A.KOTA FROM DETAIL_PROVINSI A INNER JOIN PROVINSI B ON A.KODE=B.KODE WHERE B.NAMA='" & CmbDataLanggananPropinsi.SelectedItem.ToString & "'")
                If dtload.Rows.Count > 0 Then
                    For i = 0 To dtload.Rows.Count - 1
                        CmbDataLanggananKota.Properties.Items.Add(dtload.Rows(i).Item(0))
                    Next
                End If
                CmbDataLanggananKota.SelectedIndex = -1
            End Using
        Catch
        End Try
    End Sub

    Private Sub BtnTambahProvinsi_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambahProvinsi.Click
        FrmProvinsi.ShowDialog()
        LoadCombo()
    End Sub

    Private Sub CmbGroupCust_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDGroupCust.SelectedIndexChanged, CkKredit.CheckedChanged, CmbPT.SelectedIndexChanged
        If RDGroupCust.SelectedIndex = -1 Then
            TxtLimitPiutang.Enabled = False
            TBDataPemilikLimitPiutang.Enabled = False
        ElseIf RDGroupCust.SelectedIndex = 0 Then
            TxtLimitPiutang.Enabled = True
            TBDataPemilikLimitPiutang.Enabled = False
            If CkKredit.Checked Then
                TxtLimitPiutang.Enabled = True
            Else
                TxtLimitPiutang.EditValue = 0
                TxtLimitPiutang.Enabled = False
            End If
        Else
            TxtLimitPiutang.Enabled = False
            If CmbPT.SelectedItem IsNot Nothing Then
                If CkKredit.Checked Then
                    TBDataPemilikLimitPiutang.Enabled = True
                Else
                    TBDataPemilikLimitPiutang.Enabled = False
                End If
            Else
                TBDataPemilikLimitPiutang.Enabled = False
            End If
        End If
    End Sub

    Private Sub TBInformasiHubunganBank_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBInformasiHubunganBank.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            EnterNewRow(GridView1, dtBank, "Keterangan", "Nama Bank", , "Nama Bank")
        End If
    End Sub

    Private Sub TBInformasiJaminan_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBInformasiJaminan.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            GridView2.SetFocusedRowCellValue(GridView2.Columns(0), GridView2.EditingValue)
            EnterNewRow(GridView2, dtJaminan, "Jaminan", "Jaminan", , "Jaminan")
        End If
    End Sub

    Private Sub TBDataPemilikLimitPiutang_EditorKeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TBDataPemilikLimitPiutang.EditorKeyPress
        If GridView3.FocusedColumn.FieldName = "Kode SBU" Then
            'If CharKeypress(e) Then
            '    ReBEdit_Click(sender, e)
            'End If
        End If
    End Sub

    Private Sub TBDataPemilikLimitPiutang_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDataPemilikLimitPiutang.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            If GridView3.FocusedColumn.FieldName = "Kode SBU" Then
                e.Handled = False
                Call ReBEdit_Click(sender, e)
            ElseIf GridView3.FocusedColumn.FieldName = "Nilai" Then
                If GridView3.FocusedRowHandle = GridView3.RowCount - 1 Then
                    If Len(GridView3.GetFocusedDataRow("SBU")) > 1 Then
                        AddRow(dtLimitPiutang)
                        GridView3.FocusedColumn = GridView3.Columns("Kode SBU")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TBCabang_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBCabang.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            EnterNewRow(GridView4, dtCabang, "Alamat Cabang", "Kode Cabang", , "Kode Cabang")
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            If GridView1.RowCount = 0 Then
                AddRow(dtBank)
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = 46 Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)
            If GridView2.RowCount = 0 Then
                AddRow(dtJaminan)
                GridView2.FocusedColumn = GridView2.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub GridView3_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Private Sub AllowEditColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EditColumn As String, ByVal CheckColumn As String)
        On Error Resume Next
        If Len(Gridview.GetFocusedRow(CheckColumn).ToString.Trim) > 0 Then
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = False
        Else
            Gridview.Columns(EditColumn).OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView3_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView3.FocusedColumnChanged
        AllowEditColumn(sender, "Kode SBU", "SBU")
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        AllowEditColumn(sender, "Kode SBU", "SBU")
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = 46 Then
            GridView3.DeleteRow(GridView3.FocusedRowHandle)
            GridView3.FocusedColumn = GridView3.VisibleColumns(0)
            If GridView3.RowCount = 0 Then
                AddRow(dtLimitPiutang)
                GridView3.FocusedColumn = GridView3.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub GridView4_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView4.CellValueChanging
        Try
            If IsNumeric(e.Value) Then
                GridView4.GetFocusedDataRow(GridView4.FocusedColumn.FieldName) = Val(e.Value)
            Else
                GridView4.GetFocusedDataRow(GridView4.FocusedColumn.FieldName) = e.Value
            End If
        Catch
        End Try
    End Sub

    Private Sub GridView4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView4.KeyDown
        If e.KeyCode = 46 Then
            GridView4.DeleteRow(GridView4.FocusedRowHandle)
            GridView4.FocusedColumn = GridView4.VisibleColumns(0)
            If GridView4.RowCount = 0 Then
                AddRow(dtCabang)
                GridView4.FocusedColumn = GridView4.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub ReBEdit_Click(sender As Object, e As System.EventArgs) Handles ReBEdit.ButtonClick
        Dim kode As String = GridView3.EditingValue
        If dtLimitPiutang.Select("[Kode SBU]='" & kode & "'").Length <= 1 Then
            Dim col As DataRow = GridView3.GetFocusedDataRow
            Using dtcari As DataTable = SelectCon.execute("SELECT NAMA FROM SBU WHERE KODE='" & kode & "'")
                If dtcari.Rows.Count > 0 Then
                    col(0) = kode
                    col(1) = dtcari.Rows(0).Item(0)
                    col(2) = 0
                Else
                    GoTo caridata
                End If
            End Using
            GridView3.FocusedColumn = GridView3.Columns("Nilai")
        Else
            GridView3.EditingValue = ""
            MsgBox("Kode SBU Sudah Ada !!", MsgBoxStyle.Information)
            GridView3.FocusedColumn = GridView3.Columns("Kode SBU")
        End If
        Exit Sub
caridata:
        kode = Search(FrmPencarian.KeyPencarian.SBU, kode, , , , Split(CmbPT.SelectedItem, "-")(0))
        If dtLimitPiutang.Select("[Kode SBU]='" & kode & "'").Length = 0 Then
            Dim col As DataRow = GridView3.GetFocusedDataRow
            Using dtcari As DataTable = SelectCon.execute("SELECT NAMA FROM SBU WHERE KODE='" & kode & "'")
                If dtcari.Rows.Count > 0 Then
                    GridView3.EditingValue = kode
                    col(0) = kode
                    col(1) = dtcari.Rows(0).Item(0)
                    col(2) = 0
                Else
                    col(1) = ""
                    col(2) = 0
                End If
            End Using
            GridView3.FocusedColumn = GridView3.Columns("Nilai")
        Else
            GridView3.EditingValue = ""
            MsgBox("Kode SBU Sudah Ada !!", MsgBoxStyle.Information)
            GridView3.FocusedColumn = GridView3.Columns("Kode SBU")
        End If
    End Sub

    Private Sub CmbPT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbPT.SelectedIndexChanged
        dtLimitPiutang.Clear()
        AddRow(dtLimitPiutang)
    End Sub

    Private Sub _Toolbar1_Button6_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button6.Click
        Dim frm As New InputCustomer
        frm.MdiParent = Me.MdiParent
        frm.Show()
        frm.Focus()
        Dim ctl() As Control
        For Each MyControl In frm.XtraScrollableControl1.Controls
            ctl = Me.XtraScrollableControl1.Controls.Find(MyControl.Name, True)
            Select Case TypeName(MyControl)
                Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit", "CalcEdit"
                    Try : MyControl.Text = ctl(0).Text
                    Catch : End Try
                Case "ComboBoxEdit"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem = _
                        DirectCast(ctl(0), DevExpress.XtraEditors.ComboBoxEdit).SelectedItem
                    Catch : End Try
                Case "CheckEdit"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = _
                        DirectCast(ctl(0), DevExpress.XtraEditors.CheckEdit).Checked
                    Catch : End Try
                Case "DateEdit"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = _
                        DirectCast(ctl(0), DevExpress.XtraEditors.DateEdit).DateTime
                        DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                    Catch : End Try
                Case "RadioGroup"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).EditValue = _
                        DirectCast(ctl(0), DevExpress.XtraEditors.RadioGroup).EditValue
                    Catch : End Try
            End Select
        Next

        CopyDataTable(frm.dtBank, Me.dtBank)
        CopyDataTable(frm.dtCabang, Me.dtCabang)
        CopyDataTable(frm.dtJaminan, Me.dtJaminan)
        CopyDataTable(frm.dtLimitPiutang, Me.dtLimitPiutang)
    End Sub

    Sub CopyDataTable(target As DataTable, source As DataTable)
        target.Clear()
        For Each r As DataRow In source.Rows
            target.ImportRow(r)
        Next
    End Sub

    Private Sub CkKontan_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CkKontan.CheckedChanged

    End Sub
End Class


Public Class InputCustomer
    Inherits FrmCustomer

    Private Sub Generate() Handles TxtDataLanggananNama.TextChanged
        Dim urut As Short
        Dim date1 As String
        date1 = Format(Now, "yy")
        Using dtcust = SelectCon.execute("SELECT ID FROM CUSTOMER WHERE ID Like 'C" & Mid(UCase(TxtDataLanggananNama.Text), 1, 1) & date1 & Format(Now, "MM") & "%' ORDER BY ID DESC")
            If dtcust.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Mid(dtcust.Rows(0).Item(0), 7, 3) + 1
            End If
            TxtKode.Text = "C" & Mid(UCase(TxtDataLanggananNama.Text), 1, 1) & date1 & Format(Now, "MM") & Format(urut, "000")
        End Using
    End Sub

    Private Sub Batal()
        Clean(Me)
        TxtDataLanggananNama.Focus()
        dtBank.Clear()
        AddRow(dtBank)
        dtCabang.Clear()
        AddRow(dtCabang)
        dtJaminan.Clear()
        AddRow(dtJaminan)
        dtLimitPiutang.Clear()
        AddRow(dtLimitPiutang)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtDataLanggananNama, LabelControl3) Then Exit Sub
        If Empty(TxtDataLanggananAlamat, LabelControl4) Then Exit Sub
        If Empty(CmbPT, LabelControl33) Then Exit Sub
        If RDGroupCust.SelectedIndex = 1 Or RDGroupCust.SelectedIndex = 2 Then
            If CkKredit.Checked Then
                If dtLimitPiutang.Rows.Count = 1 Then
                    If dtLimitPiutang.Rows(0).Item(0) Is "" Then
                        MsgBox("Data Limit Puitang Masih Kosong !!", MsgBoxStyle.Information)
                        TBDataPemilikLimitPiutang.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        Generate()
        con.begin_exec()

        SQl = "INSERT INTO CUSTOMER ([ID] ,[GROUP_CUSTOMER] ,[NAMA] ,[ALAMAT_KANTOR] ,[PROPINSI] ,[KOTA] ,[KODE_POS] ,[KELURAHAN] ,[KECAMATAN] ,[NO_TELP] ,[NO_FAX] ,[EMAIL] ,[NO_NPWP] ,[NAMA_PKP] ,[ALAMAT_PKP] ,[KOTA_NPWP] ,[KODE_POS_NPWP] ,[LOKASI_PENGIRIMAN] ,[ALAMAT_PENAGIHAN] ,[KOTA_INFORMASI] ,[NO_TELP_INFORMASI] ,[CONTACT_PERSON] ,[TEMPAT_USAHA] ,[JENIS_USAHA] ,[PEMASARAN] ,[NAMA_REFERENSI] ,[ALAMAT_REFERENSI] ,[KOTA_REFERENSI] ,[TELP_REFERENSI] ,[NAMA_PEMILIK] ,[ALAMAT_PEMILIK] ,[KOTA_PEMILIK] ,[KODE_POS_PEMILIK] ,[TELP_PEMILIK] ,[FAX_PEMILIK] ,[EMAIL_PEMILIK] ,[KAB_PEMILIK] ,[PROPINSI_PEMILIK] ,[SYARAT_PEMBAYARAN_KONTAN] , [SYARAT_PEMBAYARAN_KREDIT], [SYARAT_PEMBAYARAN_LAIN], [HARI] ,[KETERANGAN_PEMBAYARAN] ,[LIMIT_PIUTANG] ,[KETERANGAN] ,[STATUS_AKTIF] ,[CRUSER] ,[CRTIME] ,[KODE_PT]) VALUES ('" & TxtKode.Text & "','" & Replace(RDGroupCust.EditValue, "'", "`") & "','" & Replace(TxtDataLanggananNama.Text, "'", "`") & "','" & Replace(TxtDataLanggananAlamat.Text, "'", "`") & "','" & Replace(CmbDataLanggananPropinsi.SelectedItem, "'", "`") & "','" & Replace(CmbDataLanggananKota.Text, "'", "`") & "','" & TxtDataLanggananKodePos.Text & "','" & Replace(TxtDataLanggananKelurahan.Text, "'", "`") & "','" & Replace(TxtDataLanggananKecamatan.Text, "'", "`") & "','" & Replace(TxtDataLanggananTelp.Text, "'", "`") & "','" & Replace(TxtDataLanggananNoFax.Text, "'", "`") & "','" & Replace(TxtDataLanggananEmail.Text, "'", "`") & "','" & Replace(TxtNPWP.Text, "'", "`") & "','" & Replace(txtNamaPKP.Text, "'", "`") & "','" & Replace(txtAlamatPKP.Text, "'", "`") & "','" & Replace(CmbNPWPKota.SelectedItem, "'", "`") & "','" & Replace(TxtNPWPKodePos.Text, "'", "`") & "','" & Replace(TxtInformasiLokasiKirim.Text, "'", "`") & "','" & Replace(TxtInformasiAlamatPenagihan.Text, "'", "`") & "','" & Replace(CmbInformasiKota.SelectedItem, "'", "`") & "','" & Replace(TxtInformasiTelp.Text, "'", "`") & "','" & Replace(TxtInformasiKontakPerson.Text, "'", "`") & "','" & Replace(RDInformasiTempatUsaha.EditValue, "'", "`") & "','" & Replace(CmbInformasiJenisUsaha.SelectedItem, "'", "`") & "','" & Replace(TxtInformasiPemasaran.Text, "'", "`") & "','" & Replace(TxtInformasiReferensiNama.Text, "'", "`") & "','" & Replace(TxtInformasiReferensiAlamat.Text, "'", "`") & "','" & Replace(CmbInformasiReferensiKota.SelectedItem, "'", "`") & "','" & Replace(TxtInformasiReferensiTelp.Text, "'", "`") & "','" & Replace(TxtDataPemilikNama.Text, "'", "`") & "','" & Replace(TxtDataPemilikAlamat.Text, "'", "`") & "','" & Replace(CmbDataPemilikKota.SelectedItem, "'", "`") & "','" & Replace(TxtDataPemilikKodePos.Text, "'", "`") & "','" & Replace(TxtDataPemilikTelp.Text, "'", "`") & "','" & Replace(TxtDataPemilikNoFax.Text, "'", "`") & "','" & Replace(TxtDataPemilikEmail.Text, "'", "`") & "','" & Replace(TxtDataPemilikKabKota.Text, "'", "`") & "','" & Replace(CmbDataPemilikKota.SelectedItem, "'", "`") & "','" & Replace(CkKontan.EditValue, "'", "`") & "','" & Replace(CkKredit.EditValue, "'", "`") & "','" & Replace(CkLain.EditValue, "'", "`") & "'," & Replace(CDbl(TxtDataPemilikHari.Text), ",", ".") & ",'" & Replace(TxtDataPemilikLain.Text, "'", "`") & "'," & Replace(CDbl(TxtLimitPiutang.Text), ",", ".") & ",'" & Replace(TxtKeterangan.Text, "'", "`") & "',1,'" & UserID & "',CURRENT_TIMESTAMP,'" & Replace(Split(CmbPT.SelectedItem, "-")(0), "'", "`") & "')"

        If con.exec(SQl) Then
            GridView1.CloseEditor()
            For i = 0 To GridView1.RowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(0))) = False Then
                    If Len(GridView1.GetRowCellValue(i, GridView1.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_BANK VALUES ('" & TxtKode.Text & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(0)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(1)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(2)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(3)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView2.CloseEditor()
            For i = 0 To GridView2.RowCount - 1
                If IsDBNull(GridView2.GetRowCellValue(i, GridView2.Columns(0))) = False Then
                    If Len(GridView2.GetRowCellValue(i, GridView2.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_JAMINAN VALUES ('" & TxtKode.Text & "','" & GridView2.GetRowCellValue(i, GridView2.Columns(0)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView3.CloseEditor()
            For i = 0 To GridView3.RowCount - 1
                If IsDBNull(GridView3.GetRowCellValue(i, GridView3.Columns(1))) = False Then
                    If Len(GridView3.GetRowCellValue(i, GridView3.Columns(1))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_LIMITPIUTANG VALUES ('" & TxtKode.Text & "','" & GridView3.GetRowCellValue(i, GridView3.Columns(0)) & "'," & Replace(CDbl(GridView3.GetRowCellValue(i, GridView3.Columns(2))), ",", ".") & ")") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView4.CloseEditor()
            For i = 0 To GridView4.RowCount - 1
                If IsDBNull(GridView4.GetRowCellValue(i, GridView4.Columns(0))) = False Then
                    If Len(GridView4.GetRowCellValue(i, GridView4.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_CABANG VALUES ('" & TxtKode.Text & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(0)) & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(1)) & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(2)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next

            con.end_exec(True)
            MessageBox.Show("Data Baru telah disimpan..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Batal()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub InputCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Customer"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
        _Toolbar1_Button6.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditCustomer
    Inherits FrmCustomer

    Private Sub EditCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Customer"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "Customer", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        If TxtKode.Text <> "" Then
            LoadData.GetData("SELECT [GROUP_CUSTOMER] ,[NAMA] ,[ALAMAT_KANTOR] ,[PROPINSI] ,[KOTA] ,[KODE_POS] ,[KELURAHAN] ,[KECAMATAN] ,[NO_TELP] ,[NO_FAX] ,[EMAIL] ,[NO_NPWP] ,[NAMA_PKP] ,[ALAMAT_PKP] ,[KOTA_NPWP] ,[KODE_POS_NPWP] ,[LOKASI_PENGIRIMAN] ,[ALAMAT_PENAGIHAN] ,[KOTA_INFORMASI] ,[NO_TELP_INFORMASI] ,[CONTACT_PERSON] ,[TEMPAT_USAHA] ,[JENIS_USAHA] ,[PEMASARAN] ,[NAMA_REFERENSI] ,[ALAMAT_REFERENSI] ,[KOTA_REFERENSI] ,[TELP_REFERENSI] ,[NAMA_PEMILIK] ,[ALAMAT_PEMILIK] ,[KOTA_PEMILIK] ,[KODE_POS_PEMILIK] ,[TELP_PEMILIK] ,[FAX_PEMILIK] ,[EMAIL_PEMILIK] ,[KAB_PEMILIK] ,[PROPINSI_PEMILIK] ,[SYARAT_PEMBAYARAN_KONTAN],[SYARAT_PEMBAYARAN_KREDIT],[SYARAT_PEMBAYARAN_LAIN] ,[HARI] ,[KETERANGAN_PEMBAYARAN] ,[LIMIT_PIUTANG] ,[KETERANGAN] ,[STATUS_AKTIF] ,[KODE_PT] FROM CUSTOMER WHERE ID='" & TxtKode.Text & "'")
            LoadData.SetData({RDGroupCust, TxtDataLanggananNama, TxtDataLanggananAlamat, CmbDataLanggananPropinsi, CmbDataLanggananKota, TxtDataLanggananKodePos, TxtDataLanggananKelurahan, TxtDataLanggananKecamatan, TxtDataLanggananTelp, TxtDataLanggananNoFax, TxtDataLanggananEmail, TxtNPWP, txtNamaPKP, txtAlamatPKP, CmbNPWPKota, TxtNPWPKodePos, TxtInformasiLokasiKirim, TxtInformasiAlamatPenagihan, CmbInformasiKota, TxtInformasiTelp, TxtInformasiKontakPerson, RDInformasiTempatUsaha, CmbInformasiJenisUsaha, TxtInformasiPemasaran, TxtInformasiReferensiNama, TxtInformasiReferensiAlamat, CmbInformasiReferensiKota, TxtInformasiReferensiTelp, TxtDataPemilikNama, TxtDataPemilikAlamat, CmbDataPemilikKota, TxtDataPemilikKodePos, TxtDataPemilikTelp, TxtDataPemilikNoFax, TxtDataPemilikEmail, TxtDataPemilikKabKota, CmbDataPemilikKota, CkKontan, CkKredit, CkLain, TxtDataPemilikHari, TxtDataPemilikLain, TxtLimitPiutang, TxtKeterangan, CekStatusAktif, CmbPT})

            LoadData.GetData("SELECT NAMA_BANK,PEMILIK,NOMOR_ACCOUNT,KETERANGAN FROM DETAIL_CUSTOMER_BANK WHERE ID='" & TxtKode.Text & "' ORDER BY NAMA_BANK")
            LoadData.SetDataDetail(dtBank, True)

            LoadData.GetData("SELECT JAMINAN FROM DETAIL_CUSTOMER_JAMINAN WHERE ID='" & TxtKode.Text & "' ORDER BY JAMINAN")
            LoadData.SetDataDetail(dtJaminan, True)

            LoadData.GetData("SELECT A.KODE_SBU,B.NAMA,A.LIMIT FROM DETAIL_CUSTOMER_LIMITPIUTANG A LEFT JOIN SBU B ON A.KODE_SBU=B.KODE WHERE A.ID='" & TxtKode.Text & "'")
            LoadData.SetDataDetail(dtLimitPiutang, True)

            LoadData.GetData("SELECT KODE_CABANG,NAMA_CABANG,ALAMAT_CABANG FROM DETAIL_CUSTOMER_CABANG WHERE ID='" & TxtKode.Text & "' ORDER BY KODE_CABANG")
            LoadData.SetDataDetail(dtCabang, True)
        End If
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtDataLanggananNama, LabelControl3) Then Exit Sub
        If Empty(TxtDataLanggananAlamat, LabelControl4) Then Exit Sub
        If Empty(CmbPT, LabelControl33) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE CUSTOMER SET [GROUP_CUSTOMER]='" & Replace(RDGroupCust.EditValue, "'", "`") & "' ,[NAMA]='" & Replace(TxtDataLanggananNama.Text, "'", "`") & "' ,[ALAMAT_KANTOR]='" & Replace(TxtDataLanggananAlamat.Text, "'", "`") & "' ,[PROPINSI]='" & Replace(CmbDataLanggananPropinsi.SelectedItem, "'", "`") & "' ,[KOTA]='" & Replace(CmbDataLanggananKota.Text, "'", "`") & "' ,[KODE_POS]='" & TxtDataLanggananKodePos.Text & "' ,[KELURAHAN]='" & Replace(TxtDataLanggananKelurahan.Text, "'", "`") & "' ,[KECAMATAN]='" & Replace(TxtDataLanggananKecamatan.Text, "'", "`") & "' ,[NO_TELP]='" & Replace(TxtDataLanggananTelp.Text, "'", "`") & "' ,[NO_FAX]='" & Replace(TxtDataLanggananNoFax.Text, "'", "`") & "' ,[EMAIL]='" & Replace(TxtDataLanggananEmail.Text, "'", "`") & "' ,[NO_NPWP]='" & Replace(TxtNPWP.Text, "'", "`") & "' ,[NAMA_PKP]='" & Replace(txtNamaPKP.Text, "'", "`") & "' ,[ALAMAT_PKP]='" & Replace(txtAlamatPKP.Text, "'", "`") & "' ,[KOTA_NPWP]='" & Replace(CmbNPWPKota.SelectedItem, "'", "`") & "' ,[KODE_POS_NPWP]='" & Replace(TxtNPWPKodePos.Text, "'", "`") & "' ,[LOKASI_PENGIRIMAN]='" & Replace(TxtInformasiLokasiKirim.Text, "'", "`") & "' ,[ALAMAT_PENAGIHAN]='" & Replace(TxtInformasiAlamatPenagihan.Text, "'", "`") & "' ,[KOTA_INFORMASI]='" & Replace(CmbInformasiKota.SelectedItem, "'", "`") & "' ,[NO_TELP_INFORMASI]='" & Replace(TxtInformasiTelp.Text, "'", "`") & "' ,[CONTACT_PERSON]='" & Replace(TxtInformasiKontakPerson.Text, "'", "`") & "' ,[TEMPAT_USAHA]='" & Replace(RDInformasiTempatUsaha.EditValue, "'", "`") & "' ,[JENIS_USAHA]='" & Replace(CmbInformasiJenisUsaha.SelectedItem, "'", "`") & "' ,[PEMASARAN]='" & Replace(TxtInformasiPemasaran.Text, "'", "`") & "' ,[NAMA_REFERENSI]='" & Replace(TxtInformasiReferensiNama.Text, "'", "`") & "' ,[ALAMAT_REFERENSI]='" & Replace(TxtInformasiReferensiAlamat.Text, "'", "`") & "' ,[KOTA_REFERENSI]='" & Replace(CmbInformasiReferensiKota.SelectedItem, "'", "`") & "' ,[TELP_REFERENSI]='" & Replace(TxtInformasiReferensiTelp.Text, "'", "`") & "' ,[NAMA_PEMILIK]='" & Replace(TxtDataPemilikNama.Text, "'", "`") & "' ,[ALAMAT_PEMILIK]='" & Replace(TxtDataPemilikAlamat.Text, "'", "`") & "' ,[KOTA_PEMILIK]='" & Replace(CmbDataPemilikKota.SelectedItem, "'", "`") & "' ,[KODE_POS_PEMILIK]='" & Replace(TxtDataPemilikKodePos.Text, "'", "`") & "' ,[TELP_PEMILIK]='" & Replace(TxtDataPemilikTelp.Text, "'", "`") & "' ,[FAX_PEMILIK]='" & Replace(TxtDataPemilikNoFax.Text, "'", "`") & "' ,[EMAIL_PEMILIK]='" & Replace(TxtDataPemilikEmail.Text, "'", "`") & "' ,[KAB_PEMILIK]='" & Replace(TxtDataPemilikKabKota.Text, "'", "`") & "' ,[PROPINSI_PEMILIK]='" & Replace(CmbDataPemilikKota.SelectedItem, "'", "`") & "' ,[SYARAT_PEMBAYARAN_KONTAN]='" & Replace(CkKontan.EditValue, "'", "`") & "',[SYARAT_PEMBAYARAN_KREDIT]='" & Replace(CkKredit.EditValue, "'", "`") & "',[SYARAT_PEMBAYARAN_LAIN]='" & Replace(CkLain.EditValue, "'", "`") & "' ,[HARI]=" & Replace(CDbl(TxtDataPemilikHari.Text), ",", ".") & " ,[KETERANGAN_PEMBAYARAN]='" & Replace(TxtDataPemilikLain.Text, "'", "`") & "' ,[LIMIT_PIUTANG]=" & Replace(CDbl(TxtLimitPiutang.Text), ",", ".") & " ,[KETERANGAN]='" & Replace(TxtKeterangan.Text, "'", "`") & "' ,[STATUS_AKTIF]='" & CekStatusAktif.CheckState & "' ,[MDUSER]='" & UserID & "' ,[MDTIME]=CURRENT_TIMESTAMP ,KODE_PT='" & Replace(Split(CmbPT.SelectedItem, "-")(0), "'", "`") & "' WHERE [ID]='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_CUSTOMER_JAMINAN WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_BANK WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_LIMITPIUTANG WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_CABANG WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            GridView1.CloseEditor()
            For i = 0 To GridView1.RowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(0))) = False Then
                    If Len(GridView1.GetRowCellValue(i, GridView1.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_BANK VALUES ('" & TxtKode.Text & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(0)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(1)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(2)) & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(3)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView2.CloseEditor()
            For i = 0 To GridView2.RowCount - 1
                If IsDBNull(GridView2.GetRowCellValue(i, GridView2.Columns(0))) = False Then
                    If Len(GridView2.GetRowCellValue(i, GridView2.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_JAMINAN VALUES ('" & TxtKode.Text & "','" & GridView2.GetRowCellValue(i, GridView2.Columns(0)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView3.CloseEditor()
            For i = 0 To GridView3.RowCount - 1
                If IsDBNull(GridView3.GetRowCellValue(i, GridView3.Columns(1))) = False Then
                    If Len(GridView3.GetRowCellValue(i, GridView3.Columns(1))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_LIMITPIUTANG VALUES ('" & TxtKode.Text & "','" & GridView3.GetRowCellValue(i, GridView3.Columns(0)) & "'," & Replace(CDbl(GridView3.GetRowCellValue(i, GridView3.Columns(2))), ",", ".") & ")") = False Then GoTo keluar
                    End If
                End If
            Next
            GridView4.CloseEditor()
            For i = 0 To GridView4.RowCount - 1
                If IsDBNull(GridView4.GetRowCellValue(i, GridView4.Columns(0))) = False Then
                    If Len(GridView4.GetRowCellValue(i, GridView4.Columns(0))) > 0 Then
                        If con.exec("INSERT INTO DETAIL_CUSTOMER_CABANG VALUES ('" & TxtKode.Text & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(0)) & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(1)) & "','" & GridView4.GetRowCellValue(i, GridView4.Columns(2)) & "')") = False Then GoTo keluar
                    End If
                End If
            Next
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dirubah..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Dispose()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.Click
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "DELETE FROM CUSTOMER WHERE ID='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_CUSTOMER_JAMINAN WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_BANK WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_LIMITPIUTANG WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CUSTOMER_CABANG WHERE ID='" & TxtKode.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dihapus..!!", _
                            "Penyimpanan Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Dispose()
        Else
            GoTo keluar
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal terhapus..!!", _
                "Penghapusan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub
End Class