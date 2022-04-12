Public MustInherit Class FrmCorporation
    Protected dtLimitPiutang As New DataTable
    Protected dtCustomer As New DataTable

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dtCustomer.Dispose()
        Me.Dispose()
    End Sub

    Private Sub FrmDivisi_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
        End Select
    End Sub

    Private Sub FrmDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Add Column Table Limit Piutang
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode SBU", TypeCode.String, 25, True)
        InitGrid.AddColumnGrid("Sentral Bisnis Unit", TypeCode.String, 75, False)
        InitGrid.AddColumnGrid("Nilai", TypeCode.Double, 50, True, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBLimitPiutang, GVLimitPiutang, dtLimitPiutang)
        AddRow(dtLimitPiutang)
        GVLimitPiutang.Columns("Nilai").ColumnEdit = ReCalc
        GVLimitPiutang.Columns("Kode SBU").ColumnEdit = ReBEditSBU
        'Add Column Table Customer
        InitGrid.Clear()
        InitGrid.AddColumnGrid("ID Customer", TypeCode.String, 25, True)
        InitGrid.AddColumnGrid("Kode Approve", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama Customer", TypeCode.String, 75, False)
        InitGrid.EndInit(TBCustomer, GVCustomer, dtCustomer)
        AddRow(dtCustomer)
        GVCustomer.Columns("ID Customer").ColumnEdit = ReBEdit
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
            If col("ID Customer") <> "" Then AddRow(dtCustomer)
        Else
            MsgBox("Kode Customer Sudah Ada !!", MsgBoxStyle.Information)
            GVCustomer.FocusedColumn = GVCustomer.Columns("ID Customer")
        End If
    End Sub

    Private Sub TBCustomer_EditorKeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TBCustomer.EditorKeyPress
        If CharKeypress(e) Then
            Customer_Keypress()
        End If
    End Sub

    Private Sub ReBEditSBU_Click(sender As Object, e As System.EventArgs) Handles ReBEditSBU.Click
        Dim kode As String = Search(FrmPencarian.KeyPencarian.SBU)
        If dtLimitPiutang.Select("[Kode SBU]='" & kode & "'").Length = 0 Then
            Dim col As DataRow = GVLimitPiutang.GetFocusedDataRow
            col(0) = kode
            Using dtcari As DataTable = SelectCon.execute("SELECT NAMA FROM SBU WHERE KODE='" & kode & "'")
                If dtcari.Rows.Count > 0 Then
                    col(1) = dtcari.Rows(0).Item(0)
                    col(2) = 0
                Else
                    col(1) = ""
                    col(2) = 0
                End If
            End Using
            GVLimitPiutang.FocusedColumn = GVLimitPiutang.Columns("Nilai")
        Else
            MsgBox("Kode SBU Sudah Ada !!", MsgBoxStyle.Information)
            GVLimitPiutang.FocusedColumn = GVLimitPiutang.Columns("Kode SBU")
        End If
    End Sub

    Private Sub TBDataPemilikLimitPiutang_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBLimitPiutang.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            If GVLimitPiutang.FocusedColumn.FieldName = "Kode SBU" Then
                ReBEditSBU_Click(sender, e)
            Else
                EnterNewRow(GVLimitPiutang, dtLimitPiutang, "Nilai", "Kode SBU", , "Kode SBU")
            End If
        End If
    End Sub

    Private Sub GVCustomer_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVCustomer.FocusedColumnChanged
        On Error Resume Next
        If Len(GVCustomer.GetFocusedRow("ID Customer").ToString.Trim) > 0 Then
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = True
        End If
    End Sub
    Private Sub GVCustomer_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCustomer.FocusedRowChanged
        On Error Resume Next
        If Len(GVCustomer.GetFocusedRow("ID Customer").ToString.Trim) > 0 Then
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = False
        Else
            GVCustomer.Columns("ID Customer").OptionsColumn.AllowEdit = True
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

    Private Sub GVLimitPiutang_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GVLimitPiutang.KeyDown
        If e.KeyCode = 46 Then
            GVLimitPiutang.DeleteRow(GVLimitPiutang.FocusedRowHandle)
            GVLimitPiutang.FocusedColumn = GVLimitPiutang.VisibleColumns(0)
            If GVLimitPiutang.RowCount = 0 Then
                AddRow(dtLimitPiutang)
                GVLimitPiutang.FocusedColumn = GVLimitPiutang.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub GVLimitPiutang_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVLimitPiutang.CellValueChanging
        Try
            If IsNumeric(e.Value) Then
                GVLimitPiutang.GetFocusedDataRow(GVLimitPiutang.FocusedColumn.FieldName) = Val(e.Value)
            Else
                GVLimitPiutang.GetFocusedDataRow(GVLimitPiutang.FocusedColumn.FieldName) = e.Value
            End If
        Catch
        End Try
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

    Private Sub TxtKodeCustomer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKodeCustomer.EditValueChanged
        SetData("SELECT NAMA,KODE_APPROVE FROM CUSTOMER WHERE ID='" & TxtKodeCustomer.Text & "'", {TxtNamaCustomer, TxtKodeApprove})
        Using setdata As New _LoadData
            setdata.GetData("SELECT A.KODE_SBU,B.NAMA,A.LIMIT FROM DETAIL_CUSTOMER_LIMITPIUTANG A LEFT JOIN SBU B ON A.KODE_SBU=B.KODE WHERE A.ID='" & TxtKodeCustomer.Text & "'")
            setdata.SetDataDetail(dtLimitPiutang, True)
        End Using

        If TxtKodeCustomer.Text IsNot "" Then
            If dtCustomer.Rows.Count = 1 Then
                Dim dr As DataRow = GVCustomer.GetDataRow(0)
                dr(0) = TxtKodeCustomer.Text
                dr(1) = TxtKodeApprove.Text
                dr(2) = TxtNamaCustomer.Text
            Else
                Dim col As DataRow = GVCustomer.GetDataRow(dtCustomer.Rows.Count - 1)
                If col(1) Is "" Then
                    col(0) = TxtKodeCustomer.Text
                    col(1) = TxtKodeApprove.Text
                    col(2) = TxtNamaCustomer.Text
                Else
                    Dim dr As DataRow = dtCustomer.NewRow
                    dr(0) = TxtKodeCustomer.Text
                    dr(1) = TxtKodeApprove.Text
                    dr(2) = TxtNamaCustomer.Text
                    dtCustomer.Rows.Add(dr)
                End If
            End If
            AddRow(dtCustomer)
        End If
    End Sub

    Private Sub TxtKodeCustomer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKodeCustomer.KeyPress
        If CharKeypress(TxtKodeCustomer, e) Then
            TxtKodeCustomer.Text = Search(FrmPencarian.KeyPencarian.Customer)
        End If
    End Sub
End Class

Public Class InputCorporation
    Inherits FrmCorporation

    Private Sub Batal()
        Clean(Me)
        TxtKode.Focus()
        dtCustomer.Clear()
        AddRow(dtCustomer)
        dtLimitPiutang.Clear()
        AddRow(dtLimitPiutang)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Len(TxtKode.Text) <> 5 Then
            MsgBox("Kode Corporate Harus 5 Digit !!")
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "INSERT INTO CORPORATION VALUES ('" & TxtKode.Text & "','" & Replace(TxtNama.Text, "'", "`") & "','" & Replace(TxtAlamat.Text, "'", "`") & "','" & Replace(TxtTelepon.Text, "'", "`") & "','" & Replace(TxtPenanggungJawab.Text, "'", "`") & "','" & TxtKodeCustomer.Text & "','" & Replace(TxtKeterangan.Text, "'", "`") & "',1,'" & UserID & "',CURRENT_TIMESTAMP,NULL,NULL)"

        If con.exec(SQl) Then
            GVLimitPiutang.CloseEditor()
            For Each col As DataRow In dtLimitPiutang.Rows
                If CDbl(col("Nilai")) > 0 Then
                    If con.exec("INSERT INTO DETAIL_CORPORATION_LIMITPIUTANG VALUES ('" & TxtKode.Text & "','" & col("Kode SBU") & "'," & Replace(CDbl(col("Nilai")), ",", ".") & ")") = False Then GoTo keluar
                End If
            Next
            GVCustomer.CloseEditor()
            For Each col As DataRow In dtCustomer.Rows
                If col("ID Customer") <> "" Then
                    If con.exec("INSERT INTO LINK_CORPORATION_CUSTOMER VALUES ('" & TxtKode.Text & "','" & col("ID Customer") & "')") = False Then GoTo keluar
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

    Private Sub InputDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Corporation"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
    End Sub
End Class

Public Class EditCorporation
    Inherits FrmCorporation

    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Corporation"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "Corporation", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        LoadData.GetData("SELECT [NAMA] ,[ALAMAT] ,[TELP] ,[PENANGGUNG_JAWAB] ,[ID_CUSTOMER] ,[KETERANGAN] ,[STATUS_AKTIF] FROM CORPORATION WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtAlamat, TxtTelepon, TxtPenanggungJawab, TxtKodeCustomer, TxtKeterangan, CekStatusAktif})

        LoadData.GetData("SELECT A.KODE,A.NAMA,ISNULL(B.LIMIT,0) AS LIMIT FROM SBU A LEFT JOIN DETAIL_CORPORATION_LIMITPIUTANG B ON A.KODE=B.KODE_SBU WHERE B.KODE='" & TxtKode.Text & "' ORDER BY KODE")
        LoadData.SetDataDetail(dtLimitPiutang, True)

        LoadData.GetData("SELECT A.ID,A.KODE_APPROVE,A.NAMA FROM CUSTOMER A INNER JOIN LINK_CORPORATION_CUSTOMER B ON A.ID=B.ID_CUSTOMER AND B.KODE_CORPORATION='" & TxtKode.Text & "' ORDER BY A.NAMA")
        LoadData.SetDataDetail(dtCustomer, True)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE CORPORATION SET NAMA='" & Replace(TxtNama.Text, "'", "`") & "',ALAMAT='" & Replace(TxtAlamat.Text, "'", "`") & "',TELP='" & Replace(TxtTelepon.Text, "'", "`") & "',PENANGGUNG_JAWAB='" & Replace(TxtPenanggungJawab.Text, "'", "`") & "',ID_CUSTOMER='" & TxtKodeCustomer.Text & "',KETERANGAN='" & Replace(TxtKeterangan.Text, "'", "`") & "',STATUS_AKTIF='" & CekStatusAktif.Checked & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CORPORATION_LIMITPIUTANG WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo keluar
            GVLimitPiutang.CloseEditor()
            For Each col As DataRow In dtLimitPiutang.Rows
                If CDbl(col("Nilai")) > 0 Then
                    If con.exec("INSERT INTO DETAIL_CORPORATION_LIMITPIUTANG VALUES ('" & TxtKode.Text & "','" & col("Kode SBU") & "'," & Replace(CDbl(col("Nilai")), ",", ".") & ")") = False Then GoTo keluar
                End If
            Next
            GVCustomer.CloseEditor()
            For Each col As DataRow In dtCustomer.Rows
                If col("ID Customer") <> "" Then
                    If con.exec("INSERT INTO LINK_CORPORATION_CUSTOMER VALUES ('" & TxtKode.Text & "','" & col("ID Customer") & "')") = False Then GoTo keluar
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

        SQl = "DELETE FROM CORPORATION WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_CORPORATION_CUSTOMER WHERE KODE_CORPORATION='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM DETAIL_CORPORATION_LIMITPIUTANG WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo keluar
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
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub
End Class