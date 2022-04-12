Public Class FrmProvinsi
    Protected dt As New DataTable

    Protected Sub GetMenu()
        TBMenuPropinsi.DataSource = SelectCon.execute("SELECT KODE,NAMA FROM PROVINSI ORDER BY KODE")
        GridView1.Columns(0).Caption = "Kode"
        GridView1.Columns(0).Width = 40
        GridView1.Columns(1).Caption = "Nama Provinsi"
        GridView1.Columns(1).Width = 60
    End Sub
    Protected Sub GetDetailMenu()
        If GridView1.RowCount > 0 Then
            Try
                TBDetailMenuPropinsi.DataSource = SelectCon.execute("SELECT KOTA FROM DETAIL_PROVINSI WHERE KODE='" & GridView1.GetFocusedRow(0) & "'")
                GridView2.Columns(0).Caption = "List Kota"
            Catch
            End Try
        End If
    End Sub
    Protected Sub Generate()
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT KODE FROM PROVINSI WHERE KODE Like 'PRV%' ORDER BY KODE DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                Dim ada As String = dtGenerate.Rows(0).Item(0)
                urut = ada.Substring(3, 2) + 1
            End If
            TxtKode.Text = "PRV" & Format(urut, "00")
        End Using
    End Sub
    Protected Sub GetData()
        Try
            TxtKode.Text = GridView1.GetFocusedRow(0)
            TxtNama.Text = GridView1.GetFocusedRow(1)
        Catch
        End Try
        Try
            Dim col As DataRow
            Using dtload = SelectCon.execute("SELECT KOTA FROM DETAIL_PROVINSI WHERE KODE='" & TxtKode.Text & "'")
                If dtload.Rows.Count > 0 Then
                    Try
                        dt.Clear()
                    Catch
                    End Try
                    For i = 0 To dtload.Rows.Count - 1
                        AddRow(dt)
                        col = GridView3.GetDataRow(i)
                        col(0) = dtload.Rows(i).Item(0)
                    Next
                End If
            End Using
        Catch
        End Try
    End Sub

    Private Sub BtnTambah_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambah.Click
        GroupInput.Text = "Input Provinsi"
        GroupInput.Visible = True
        AddRow(dt)
        Generate()
        TxtNama.Focus()
    End Sub

    Private Sub FrmProvinsi_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FrmProvinsi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kota", TypeCode.String)
        InitGrid.EndInit(TBPropinsi, GridView3, dt)
        GetMenu()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        GetDetailMenu()
    End Sub

    Private Sub BtnTutup_Click(sender As System.Object, e As System.EventArgs) Handles BtnTutup.Click
        GroupInput.Visible = False
        dt.Clear()
        TxtKode.Text = Nothing
        TxtNama.Text = Nothing
    End Sub

    Private Sub TBProvinsi_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBPropinsi.EditorKeyDown
        If e.KeyCode = Keys.Enter Then
            If GridView3.FocusedRowHandle = GridView3.RowCount - 1 Then
                If IsDBNull(GridView3.EditingValue) = False Then
                    If GridView3.EditingValue <> "" Then
                        AddRow(dt)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnSimpan_Click(sender As System.Object, e As System.EventArgs) Handles BtnSimpan.Click
        If Empty(TxtKode) Then Exit Sub
        Dim col As DataRow

        If GroupInput.Text = "Input Provinsi" Then
            If MessageBox.Show("Apakah anda yakin ingin menyimpan data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Generate()
                con.begin_exec()
                If con.exec("INSERT INTO PROVINSI VALUES ('" & TxtKode.Text & "','" & TxtNama.Text & "','" & UserID & "',CURRENT_TIMESTAMP,NULL,NULL)") = False Then GoTo Keluar
                For i = 0 To GridView3.RowCount - 1
                    col = GridView3.GetDataRow(i)
                    If IsDBNull(col(0)) = False Then
                        If col(0) <> "" Then
                            If con.exec("INSERT INTO DETAIL_PROVINSI VALUES ('" & TxtKode.Text & "','" & Replace(col(0), "'", "") & "')") = False Then GoTo keluar
                        End If
                    End If
                Next

                con.end_exec(True)

                MessageBox.Show("Data Baru telah disimpan..!!", _
                               "Penyimpanan Sukses", _
                               MessageBoxButtons.OK, _
                               MessageBoxIcon.Information)
                GetMenu()
                BtnTutup_Click(sender, e)
            End If
        ElseIf GroupInput.Text = "Edit Provinsi" Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                con.begin_exec()
                If con.exec("UPDATE PROVINSI SET NAMA='" & TxtNama.Text & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo Keluar
                If con.exec("DELETE FROM DETAIL_PROVINSI WHERE KODE='" & TxtKode.Text & "'") = False Then GoTo keluar
                For i = 0 To GridView3.RowCount - 1
                    col = GridView3.GetDataRow(i)
                    If col(0) <> "" Then
                        If con.exec("INSERT INTO DETAIL_PROVINSI VALUES ('" & TxtKode.Text & "','" & Replace(col(0), "'", "") & "')") = False Then GoTo keluar
                    End If
                Next
                con.end_exec(True)

                MessageBox.Show("Data telah dirubah..!!", _
                               "Penyimpanan Sukses", _
                               MessageBoxButtons.OK, _
                               MessageBoxIcon.Information)
                GetMenu()
                BtnTutup_Click(sender, e)
            End If
        End If
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                        "Penyimpanan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        GroupInput.Text = "Edit Provinsi"
        GroupInput.Visible = True
        GetData()
        TxtNama.Focus()
    End Sub

    Private Sub GridView3_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView3.KeyUp
        If e.KeyCode = 46 Then
            GridView3.DeleteRow(GridView3.FocusedRowHandle)
            GridView3.FocusedColumn = GridView3.VisibleColumns(1)
            If GridView3.RowCount = 0 Then
                AddRow(dt)
                GridView3.FocusedColumn = GridView3.VisibleColumns(1)
            End If
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As System.Object, e As System.EventArgs) Handles BtnBatal.Click
        Generate()
        TxtNama.Text = Nothing
        dt.Clear()
        TxtNama.Focus()
    End Sub

    Private Sub BtnHapus_Click(sender As System.Object, e As System.EventArgs) Handles BtnHapus.Click
        If MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            con.begin_exec()
            If con.exec("DELETE FROM DETAIL_PROVINSI WHERE KODE='" & GridView1.GetFocusedRow(0) & "'") = False Then GoTo Keluar
            If con.exec("DELETE FROM PROVINSI WHERE KODE='" & GridView1.GetFocusedRow(0) & "'") = False Then GoTo Keluar
            con.end_exec(True)

            MessageBox.Show("Data Berhasil Dihapus..!!", _
                           "Penghapusan Sukses", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Information)
            GetMenu()
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