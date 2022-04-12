Public MustInherit Class FrmKaryawan
    Protected dtGudang As New DataTable
    Protected dtDivisi As New DataTable

    Private Sub FrmKaryawan_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub InputKaryawan_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Close()
    End Sub

    Sub Record()
        cmbJabatan.Properties.Items.Clear()
        Using dt2 = SelectCon.execute("SELECT NAMA FROM JABATAN ORDER BY NAMA")
            For i = 0 To dt2.Rows.Count - 1
                cmbJabatan.Properties.Items.Add(dt2.Rows(i).Item(0))
            Next
            cmbJabatan.SelectedIndex = -1
        End Using

        CmbDepartemen.Properties.Items.Clear()
        Using dt2 = SelectCon.execute("SELECT NAMA FROM DEPARTEMEN ORDER BY NAMA")
            For i = 0 To dt2.Rows.Count - 1
                CmbDepartemen.Properties.Items.Add(dt2.Rows(i).Item(0))
            Next
            CmbDepartemen.SelectedIndex = -1
        End Using

        'Using Data = con.execute("select * from [GROUPS USER] ")
        '    For i = 0 To Data.Rows.Count - 1
        '        'CmbIDGroup.Properties.Items.Add(data.Rows(i).Item(0))
        '        'CmbIDGroup.EditValue = data.Rows(i).Item(0)
        '    Next
        '    ' CmbIDGroup.SelectedIndex = 0
        '    'Catch ex As Exception
        '    'MsgBox(ex.ToString())
        '    'End Try
        'End Using
    End Sub

    Private Sub InputCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dt1.DateTime = CType(Format(Now, "dd/MM/yyyy"), Date)
        DTpo.DateTime = CType(Format(Now, "dd/MM/yyyy"), Date)

        Call Record()

        CmbAgama.Properties.Items.Add("ISLAM")
        CmbAgama.Properties.Items.Add("KRISTEN")
        CmbAgama.Properties.Items.Add("KATOLIK")
        CmbAgama.Properties.Items.Add("HINDU")
        CmbAgama.Properties.Items.Add("BUDHA")
        CmbAgama.SelectedIndex = 0

        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Gudang", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama Gudang", TypeCode.String, 100, False)
        InitGrid.AddColumnGrid("Ceklist", TypeCode.Boolean, 40)
        InitGrid.EndInit(TBGudang, GVGudang, dtGudang)

        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Divisi", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama Divisi", TypeCode.String, 100, False)
        InitGrid.AddColumnGrid("Ceklist", TypeCode.Boolean, 40)
        InitGrid.EndInit(TBLinkDivisi, GVDivisi, dtDivisi)


        Using qcmb = SelectCon.execute("SELECT [ID_GROUP] + '-' + [NAMA_GROUP] FROM [GROUP_USER] ORDER BY ID_GROUP")
            For c = 0 To qcmb.Rows.Count - 1
                CmbIDGroup.Properties.Items.Add(qcmb.Rows(c).Item(0))
            Next
            CmbIDGroup.SelectedIndex = 0
        End Using
    End Sub

    Private Sub BtnAddGrup_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddGrup.Click
        FrmJabatan.ShowDialog()
        Call Record()
    End Sub

    Private Sub GVDivisi_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDivisi.CellValueChanging
        GVDivisi.GetFocusedDataRow(GVDivisi.FocusedColumn.FieldName) = e.Value
    End Sub

    Private Sub GVGudang_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVGudang.CellValueChanging
        GVGudang.GetFocusedDataRow(GVGudang.FocusedColumn.FieldName) = e.Value
    End Sub

    Private Sub ChkUser_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkUser.CheckedChanged
        If ChkUser.Checked Then
            GBUser.Visible = True
        Else
            GBUser.Visible = False
        End If
    End Sub

    Private Sub ChkOtorisasi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkOtorisasi.CheckedChanged
        If ChkOtorisasi.Checked Then
            Label18.Visible = True
            txtOtorisasi.Visible = True
        Else
            Label18.Visible = False
            txtOtorisasi.Visible = False
            txtOtorisasi.Text = ""
        End If
    End Sub

    Private Sub BtnAddDepartemen_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddDepartemen.Click
        FrmDepartemen.ShowDialog()
        Call Record()
    End Sub

    Private Sub Txtpass_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Txtpass.ButtonClick
        Txtpass.Properties.UseSystemPasswordChar = True
    End Sub

    Private Sub Txtpass_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Txtpass.ButtonPressed
        Txtpass.Properties.UseSystemPasswordChar = False
    End Sub

    Private Sub TxtPass2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtPass2.ButtonClick
        TxtPass2.Properties.UseSystemPasswordChar = True
    End Sub

    Private Sub TxtPass2_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtPass2.ButtonPressed
        TxtPass2.Properties.UseSystemPasswordChar = False
    End Sub

    Private Sub txtOtorisasi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOtorisasi.ButtonClick
        txtOtorisasi.Properties.UseSystemPasswordChar = True
    End Sub

    Private Sub txtOtorisasi_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOtorisasi.ButtonPressed
        txtOtorisasi.Properties.UseSystemPasswordChar = False
    End Sub
End Class

Public Class InputKaryawan
    Inherits FrmKaryawan

    Private Sub Generate()
        Dim urut As Integer
        Using dt = SelectCon.execute("SELECT MAX(ID_USER) FROM USERS")
            If dt.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Left(dt.Rows(0).Item(0), 3) + 1
            End If
            TxtKode.Text = Format(urut, "000")
        End Using
    End Sub

    Private Sub Batal()
        Clean(Me)
        Dt1.DateTime = CType(Format(Now, "dd/MM/yyyy"), Date)
        DTpo.DateTime = CType(Format(Now, "dd/MM/yyyy"), Date)
        TxtNama.Focus()
        LoadData.GetData("SELECT KODE,NAMA_GUDANG,CAST(0 AS BIT) FROM GUDANG ORDER BY KODE")
        LoadData.SetDataDetail(dtGudang, False)
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
        Call Generate()
        Call Record()
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Empty(txtAlamatKantor) Then Exit Sub
        If Txtpass.Text = TxtPass2.Text = False Then Exit Sub

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = ("INSERT INTO [USERS] VALUES ('" & TxtKode.Text & "','" & TxtNama.Text & "','" & TxtNIK.Text & "','" & txtAlamatKantor.Text & "','" & TxtTelp.Text & "','" & txtKota.Text & "','" & Format(Dt1.EditValue, "MM/dd/yyyy") & "','" & RdKelamin.EditValue & "','" & RdStatus.EditValue & "','" & CmbAgama.SelectedItem & "','" & Format(DTpo.EditValue, "MM/dd/yyyy") & "','" & CmbDepartemen.SelectedItem & "','" & cmbJabatan.SelectedItem & "','" & txtKeterangan.Text & "','" & ChkUser.Checked & "','" & SmartEngine.encrypt(Txtpass.Text) & "','" & Split(CmbIDGroup.SelectedItem, "-")(0) & "','" & ChkRubahHarga.Checked & "','" & ChkOtorisasi.Checked & "','" & txtOtorisasi.Text & "','" & ChkPeriode.Checked & "','True','" & UserID & "',CURRENT_TIMESTAMP,NULL,NULL)")

        If con.exec(SQl) Then
            GVGudang.CloseEditor()
            For Each col As DataRow In dtGudang.Rows
                If col("Ceklist") = True Then
                    If con.exec("INSERT INTO LINK_USER_GUDANG VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
                End If
            Next
            GVDivisi.CloseEditor()
            For Each col As DataRow In dtDivisi.Rows
                If col("Ceklist") = True Then
                    If con.exec("INSERT INTO LINK_USER_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
                End If
            Next
            con.end_exec(True)

            MessageBox.Show("Data telah disimpan..!!", _
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
        MessageBox.Show("Data gagal Tersimpan..!!", _
                        "Penyimpanan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub InputKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Name = "InputKaryawan"
        Text = "Input Karyawan"
        _Toolbar1_Button4.Visible = False
        CkAktif.Visible = False
        Generate()
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal

        LoadData.GetData("SELECT KODE,NAMA_GUDANG,CAST(0 AS BIT) FROM GUDANG ORDER BY KODE")
        LoadData.SetDataDetail(dtGudang, False)
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
    End Sub
End Class

Public Class EditKaryawan
    Inherits FrmKaryawan

    Private Sub GetData()
        LoadData.GetData("SELECT NAMA_USER, NIK, ALAMAT, TELP, KOTA, KELAMIN, STATUS_NIKAH, AGAMA, TGL_LAHIR, TGL_MASUK, DEPARTEMEN, JABATAN, KETERANGAN, PASSWORD, PASSWORD, ID_GROUP, HAK_HARGA, HAK_PERIODE, HAK_OTORISASI, PASSWORD_OTORISASI, HAK_USER, STATUS_AKTIF  FROM USERS WHERE ID_USER = '" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtNIK, txtAlamatKantor, TxtTelp, txtKota, RdKelamin, RdStatus, CmbAgama, Dt1, DTpo, CmbDepartemen, cmbJabatan, txtKeterangan, Txtpass, TxtPass2, CmbIDGroup, ChkRubahHarga, ChkPeriode, ChkOtorisasi, txtOtorisasi, ChkUser, CkAktif})
        TxtPass2.Text = SmartEngine.decrypt(TxtPass2.Text)
        Txtpass.Text = SmartEngine.decrypt(Txtpass.Text)

        LoadData.GetData("SELECT KODE,NAMA_GUDANG,CAST(IIF((SELECT KODE_GUDANG FROM LINK_USER_GUDANG WHERE KODE_GUDANG=KODE AND ID_USER='" & TxtKode.Text & "') IS NULL,0,1) AS BIT) FROM GUDANG ORDER BY KODE")
        LoadData.SetDataDetail(dtGudang, False)
        LoadData.GetData("SELECT KODE,NAMA,CAST(IIF((SELECT KODE_DIVISI FROM LINK_USER_DIVISI WHERE KODE_DIVISI=KODE AND ID_USER='" & TxtKode.Text & "') IS NULL,0,1) AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        If Empty(txtAlamatKantor) Then Exit Sub
        If Txtpass.Text = TxtPass2.Text = False Then Exit Sub

        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = ("UPDATE [USERS] SET NAMA_USER='" & TxtNama.Text & "',NIK='" & TxtNIK.Text & "',ALAMAT='" & txtAlamatKantor.Text & "',TELP='" & TxtTelp.Text & "',KOTA='" & txtKota.Text & "',TGL_LAHIR='" & Format(Dt1.DateTime, "MM/dd/yyyy") & "',KELAMIN='" & RdKelamin.EditValue & "',STATUS_NIKAH='" & RdStatus.EditValue & "',AGAMA='" & CmbAgama.SelectedItem & "',TGL_MASUK='" & Format(DTpo.DateTime, "MM/dd/yyyy") & "',DEPARTEMEN='" & CmbDepartemen.SelectedItem & "',JABATAN='" & cmbJabatan.SelectedItem & "',KETERANGAN='" & txtKeterangan.Text & "',HAK_USER='" & ChkUser.Checked & "',PASSWORD='" & SmartEngine.encrypt(Txtpass.Text) & "',ID_GROUP='" & Split(CmbIDGroup.SelectedItem, "-")(0) & "',HAK_HARGA='" & ChkRubahHarga.Checked & "',HAK_OTORISASI='" & ChkOtorisasi.Checked & "',PASSWORD_OTORISASI='" & txtOtorisasi.Text & "',HAK_PERIODE='" & ChkPeriode.Checked & "',STATUS_AKTIF='" & CkAktif.Checked & "',MDUSER='" & UserID & "',MDTIME=CURRENT_TIMESTAMP WHERE ID_USER='" & TxtKode.Text & "'")

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_USER_GUDANG WHERE ID_USER='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM LINK_USER_DIVISI WHERE ID_USER='" & TxtKode.Text & "'") = False Then GoTo keluar
            For Each col As DataRow In dtGudang.Rows
                If col("Ceklist") = True Then
                    If con.exec("INSERT INTO LINK_USER_GUDANG VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
                End If
            Next
            GVDivisi.CloseEditor()
            For Each col As DataRow In dtDivisi.Rows
                If col("Ceklist") = True Then
                    If con.exec("INSERT INTO LINK_USER_DIVISI VALUES ('" & TxtKode.Text & "','" & col(0) & "')") = False Then GoTo keluar
                End If
            Next
            con.end_exec(True)

            MessageBox.Show("Data telah disimpan..!!", _
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
        MessageBox.Show("Data gagal Tersimpan..!!", _
                        "Penyimpanan Gagal", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    Private Sub _Toolbar1_Button4_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button4.Click
        If _Toolbar1_Button4.Visible = False Then Exit Sub
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()
        SQl = "DELETE FROM USERS WHERE ID_USER='" & TxtKode.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_USER_GUDANG WHERE ID_USER='" & TxtKode.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM LINK_USER_DIVISI WHERE ID_USER='" & TxtKode.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data sudah terhapus..!!", _
                            "Hapus Sukses", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.Close()
        Else
            GoTo keluar
        End If
        Exit Sub

keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal terhapus..!!", _
                "Hapus Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub EditKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Karyawan"
        AddHandler TxtKode.EditValueChanged, AddressOf GetData
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "Karyawan", ChkUser, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub
End Class