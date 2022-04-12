Public Class FrmMonitoringCustomer      
    Dim pos As Long
    Private dt As DataTable

    Private Sub _Toolbar1_Button9_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button9.Click

        If _Toolbar1_Button9.Text = "F3 - &Batal Proses" Then
            GridView1.Columns("checklist").FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            Call Proses()
            _Toolbar1_Button9.Text = "F3 - &Keluar"
            _Toolbar1_Button1.Text = "F2 - &Proses"
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub Proses()
        On Error Resume Next
        dt = SelectCon.execute("SELECT convert(bit,0) as Checklist,ID,GROUP_CUSTOMER,A.NAMA,ALAMAT_KANTOR,B.NAMA,NO_TELP,NO_FAX,CONTACT_PERSON FROM CUSTOMER A LEFT JOIN PT B ON A.KODE_PT=B.KODE WHERE KODE_APPROVE IS NULL ORDER BY ID,A.CRTIME")
        TBMonitoringSPK.DataSource = dt
        TBMonitoringSPK.Refresh()
        SetGrid()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Customer ]"
    End Sub

    Private Sub FrmMonitoringDO_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        txtCari.Focus()
        Call Proses()
    End Sub

    Private Sub SetGrid()
        GridView1.Columns(0).Caption = "Checklist"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Id Customer"
        GridView1.Columns(1).Width = 75
        GridView1.Columns(2).Caption = "Group Customer"
        GridView1.Columns(2).Width = 100
        GridView1.Columns(3).Caption = "Nama"
        GridView1.Columns(3).Width = 200
        GridView1.Columns(4).Caption = "Alamat"
        GridView1.Columns(4).Width = 300
        GridView1.Columns(5).Caption = "PT"
        GridView1.Columns(5).Width = 150
        GridView1.Columns(6).Caption = "Tlp"
        GridView1.Columns(6).Width = 150
        GridView1.Columns(7).Caption = "Fax"
        GridView1.Columns(7).Width = 150
        GridView1.Columns(8).Caption = "Contact Person"
        GridView1.Columns(8).Width = 175


        GridView1.Columns(1).OptionsColumn.AllowFocus = False
        GridView1.Columns(2).OptionsColumn.AllowFocus = False
        GridView1.Columns(3).OptionsColumn.AllowFocus = False
        GridView1.Columns(4).OptionsColumn.AllowFocus = False
        GridView1.Columns(5).OptionsColumn.AllowFocus = False
        GridView1.Columns(6).OptionsColumn.AllowFocus = False
        GridView1.Columns(7).OptionsColumn.AllowFocus = False
        GridView1.Columns(8).OptionsColumn.AllowFocus = False

    End Sub

    Private Sub txtCari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCari.EditValueChanged
        GridView1.FindFilterText = """" & txtCari.Text & """"
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click       
        On Error Resume Next
        Using MyDt As DataTable = dt.Select("Checklist=1").CopyToDataTable
            If MyDt.Rows.Count > 0 Then
                GBstatus.Visible = True
                TxtKode.Text = MyDt.Rows(0).Item(1)
                Nama.Text = MyDt.Rows(0).Item(3)
                TBMonitoringSPK.Enabled = False
                Frame2.Enabled = False
                Toolbar1.Enabled = False
            Else
                MsgBox("Tidak Ada Data yang Diproses !!!")
            End If
        End Using
    End Sub


    Private Sub Simpan()     

        Using dtcek As DataTable = SelectCon.execute("SELECT NAMA FROM CUSTOMER WHERE KODE_APPROVE='" & txtKodeApprove.Text & "'")
            If dtcek.Rows.Count > 0 Then
                MsgBox("Kode Approve Sudah Pernah Dipakai Untuk Customer " & dtcek.Rows(0).Item(0) & " !!")
                Exit Sub
            End If
        End Using

        If MsgBox("Apakah anda ingin menyimpan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If


        con.begin_exec()

        GridView1.CloseEditor()

        SQl = "UPDATE CUSTOMER SET KODE_APPROVE='" & txtKodeApprove.Text & "' WHERE ID='" & TxtKode.Text & "'"

        If con.exec(SQl) = False Then
            GoTo keluar
        Else
            If con.exec("INSERT INTO CUSTOMER_STATUS VALUES ('" & TxtKode.Text & "','" & txtKodeApprove.Text & "'," & RDstatus.SelectedIndex & ",'" & Replace(TxtKeterangan.Text, "'", "`") & "','" & UserID & "',CURRENT_TIMESTAMP)") = False Then GoTo keluar
        End If

        con.end_exec(True)

disimpan:
        MessageBox.Show("Data telah disimpan..!!", _
                        "Penyimpanan Sukses", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
        Me.Dispose()
        Exit Sub
keluar:
        con.end_exec(False)
        MsgBox(Err.Description)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Sukses", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)

    End Sub



    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(sender, e)
        If GridView1.FocusedValue = True Then
            If pos >= 0 Then
                GridView1.SetRowCellValue(pos, GridView1.Columns(0), False)
                pos = GridView1.FocusedRowHandle
            End If
        End If
        GridView1.RefreshData()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        GBstatus.Visible = False
        Nama.Text = ""
        TxtKode.Text = ""
        txtKodeApprove.Text = ""
        TxtKeterangan.Text = ""
        TBMonitoringSPK.Enabled = True
        Frame2.Enabled = True
        Toolbar1.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        GBstatus.Visible = False
        Nama.Text = ""
        TxtKode.Text = ""
        txtKodeApprove.Text = ""
        TxtKeterangan.Text = ""
        TBMonitoringSPK.Enabled = True
        Frame2.Enabled = True
        Toolbar1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Call Simpan()
    End Sub

    Private Sub FrmMonitoringCustomer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1_Click(sender, e)
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button9_Click(sender, e)
            Case System.Windows.Forms.Keys.F8
                Button1.PerformClick()
            Case System.Windows.Forms.Keys.F9
                Button2.PerformClick()
        End Select
    End Sub

    Private Sub RDstatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDstatus.SelectedIndexChanged
        If RDstatus.SelectedIndex = 1 Then
            txtKodeApprove.Enabled = True
            txtKodeApprove.BackColor = Color.White
            txtKodeApprove.Focus()
        Else
            txtKodeApprove.Enabled = False
            txtKodeApprove.BackColor = Color.WhiteSmoke
        End If
    End Sub
End Class