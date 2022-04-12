Public MustInherit Class FrmDiskon
    Protected dt As New DataTable
    Protected counter As Integer
    Dim Nomer As Integer
    Protected StatusEdit As Byte

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dt.Dispose()
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

    Private Sub FrmDiskon_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 5, False)
        InitGrid.AddColumnGrid("Nama Diskon", TypeCode.String, 100, True)
        InitGrid.AddColumnGrid("Diskon (%)", TypeCode.Double, 50, True)
        InitGrid.EndInit(TBDiskon, GridView1, dt)
    End Sub

    Private Sub TBDiskon_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBDiskon.EditorKeyDown
        On Error Resume Next
        If e.KeyCode = Keys.Enter Then
            If StatusEdit = False Then
                For i = 0 To GridView1.RowCount - 1
                    If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(1))) = False Then
                        Nomer = CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(0)))
                    End If
                Next i
                If Nomer < 4 Then
                    EnterNewRow(GridView1, dt, "Diskon (%)", "Nama Diskon")
                    'GridView1.GetFocusedDataRow().Item(0) = GridView1.FocusedRowHandle + 1
                    counter = counter + 1
                    urutan()
                    GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                End If
            Else
                EnterNewRow(GridView1, dt, "Diskon (%)", "Nama Diskon")
                counter = counter + 1
                urutan()
                GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                For i = 0 To GridView1.RowCount - 1
                    If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(1))) = False Then
                        Nomer = CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(0)))
                    End If
                Next i
                If Nomer < 5 Then
                    EnterNewRow(GridView1, dt, "Diskon (%)", "Nama Diskon")                  
                    counter = counter + 1
                    urutan()
                    GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                Else
                    GridView1.DeleteRow(GridView1.FocusedRowHandle)
                    GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                    counter = counter - 1
                End If
            End If

        End If
    End Sub

    Private Sub urutan()

        For i = 0 To counter - 1
            If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns("Diskon (%)"))) <> True Then
                GridView1.SetRowCellValue(i, GridView1.Columns("No."), i + 1)
            End If
        Next
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.VisibleColumns(1)
            counter = counter - 1
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.VisibleColumns(1)
            End If
            urutan()
        End If
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKode.EditValueChanged

    End Sub
End Class


Public Class InputDiskon
    Inherits FrmDiskon


    Private Sub Batal()
        Clean(Me.FindForm)
        TxtKode.Focus()
        counter = 0
        dt.Clear()
        AddRow(dt)
        dt.Rows(0).Item(0) = "1"
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Len(TxtKode.Text) <> 5 Then
            MsgBox("Kode Harus 5 Digit !!")
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "INSERT INTO DISKON (KODE,NAMA,KETERANGAN,STATUS_AKTIF,CRUSER,CRTIME) VALUES ('" & TxtKode.Text & "','" & Replace(TxtNama.Text, "'", "`") & "','" & Replace(TxtKeterangan.Text, "'", "`") & "',1,'" & UserID & "',CURRENT_TIMESTAMP)"

        If con.exec(SQl) Then
            GridView1.CloseEditor()
            For i = 0 To GridView1.RowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(1))) = False Then
                    If CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(2))) <> 0 Then
                        If con.exec("INSERT INTO DETAIL_DISKON VALUES ('" & TxtKode.Text & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(1)) & "'," & Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(2))), ",", ".") & "," & GridView1.GetRowCellValue(i, GridView1.Columns(0)) & ")") = False Then GoTo keluar
                    End If
                End If
            Next i
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
        Text = "Input Diskon"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
        counter = 0
        StatusEdit = False
        AddRow(dt)
        dt.Rows(0).Item(0) = "1"
    End Sub
End Class

Public Class EditDiskon
    Inherits FrmDiskon


    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Diskon"
        TxtKode.Properties.ReadOnly = True
        counter = 0
        StatusEdit = True
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        LoadData.GetData("SELECT NAMA,KETERANGAN,STATUS_AKTIF FROM DISKON WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtKeterangan, CekStatusAktif})

        LoadData.GetData("SELECT URUTAN,NAMA,DISKON FROM DETAIL_DISKON WHERE KODE='" & TxtKode.Text & "' ORDER BY KODE")        
        LoadData.SetDataDetail(dt, False)
        counter = dt.Rows.Count

    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE DISKON SET NAMA='" & Replace(TxtNama.Text, "'", "`") & "',KETERANGAN='" & Replace(TxtKeterangan.Text, "'", "`") & "',STATUS_AKTIF='" & CekStatusAktif.EditValue & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_DISKON WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo keluar
            GridView1.CloseEditor()
            For i = 0 To GridView1.RowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(1))) = False Then
                    If CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(2))) <> 0 Then
                        If con.exec("INSERT INTO DETAIL_DISKON VALUES ('" & TxtKode.Text & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(1)) & "'," & Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(2))), ",", ".") & "," & GridView1.GetRowCellValue(i, GridView1.Columns(0)) & ")") = False Then GoTo keluar
                    End If
                End If
            Next i
            con.end_exec(True)
            MessageBox.Show("Data telah dirubah..!!", _
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

        SQl = "DELETE FROM DISKON WHERE KODE='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM DETAIL_DISKON WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data telah dihapus..!!", _
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