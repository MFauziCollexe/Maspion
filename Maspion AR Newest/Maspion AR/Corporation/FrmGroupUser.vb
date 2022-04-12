Public Class FrmGroupUser
    Private MySelectCon As New SelectSQLServer
    Dim dtMaster As DataTable
    Dim dtPembelianLangganan As DataTable
    Dim dtPembelianSuper As DataTable
    Dim dtPenjLanggananPerw As DataTable
    Dim dtPenjLanggananPus As DataTable
    Dim dtPenjSupermarketPerw As DataTable
    Dim dtPenjSupermarketPus As DataTable
    Dim dtPenjLainPerw As DataTable
    Dim dtPenjLainPus As DataTable
    Dim dtPenitipan As DataTable
    Dim dtRetur As DataTable
    Dim dtPersediaan As DataTable
    Dim dtMonitoring As DataTable
    Dim dtDebitKreditNote As DataTable
    Dim dtLaporan As DataTable
    Dim dtSistem As DataTable
    Dim dtsistemar As DataTable
    Private _StatusEdit As Boolean = False
    Property StatusEdit As Boolean
        Set(value As Boolean)
            _StatusEdit = value
            If value Then : txtKode.Enabled = False : _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else : txtKode.Enabled = True : _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never : End If
        End Set
        Get
            Return _StatusEdit
        End Get
    End Property

    Private Sub FrmGroupUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler GVPenjualanLanggananPerwakilan.CellValueChanging, AddressOf SetDataTableG
        GetData()
    End Sub

    Private Sub SetDataTableG(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        SetDataTable(sender, e)
    End Sub

    Private Sub SetColumnnGrid(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView)
        Gridview.Columns(0).Width = 200
        Gridview.Columns(1).Width = 25
        Gridview.Columns(2).Width = 25
        Gridview.Columns(3).Width = 25
        Gridview.Columns(4).Width = 25
        Gridview.Columns(5).Width = 25
        Gridview.Columns(6).Width = 25
        Gridview.Columns(7).Visible = False
        Gridview.Columns(8).Visible = False

        Gridview.Columns(0).OptionsColumn.AllowFocus = False
        Gridview.Columns(1).OptionsColumn.AllowFocus = True
        Gridview.Columns(2).OptionsColumn.AllowFocus = True
        Gridview.Columns(3).OptionsColumn.AllowFocus = True
        Gridview.Columns(4).OptionsColumn.AllowFocus = True
        Gridview.Columns(5).OptionsColumn.AllowFocus = True
        Gridview.Columns(6).OptionsColumn.AllowFocus = True
        Gridview.OptionsNavigation.EnterMoveNextColumn = True
        Gridview.OptionsNavigation.AutoFocusNewRow = True
        Gridview.BestFitColumns()
    End Sub

    Private Sub _Toolbar1_Button1_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button1.ItemClick
        Simpan()
    End Sub

    Private Sub _Toolbar1_Button3_ItemClick(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub GetData()
        Dim Code As String = Nothing
        If StatusEdit Then
            Code = txtKode.Text
            Try : txtNama.Text = SelectCon.execute("SELECT NAMA_GROUP FROM GROUP_USER WHERE ID_GROUP='" & Code & "'").Rows(0).Item(0)
            Catch : End Try
        Else : Code = "Default" : End If

        Dim dtHeader As DataTable
        dtHeader = MySelectCon.execute("SELECT A.GROUP_HEADER,ISNULL(B.HAK_GH,A.HAK_GH) AS HAK_GH,A.HEADER,ISNULL(B.HAK_H,A.HAK_H) AS HAK_H FROM (SELECT DISTINCT GROUP_HEADER,HAK_GH,HEADER,HAK_H FROM HAK_USER WHERE ID_GROUP='Default') AS A LEFT JOIN (SELECT DISTINCT GROUP_HEADER,HAK_GH,HEADER,HAK_H FROM HAK_USER WHERE ID_GROUP='" & Code & "') AS B ON A.GROUP_HEADER=B.GROUP_HEADER AND A.HEADER=B.HEADER")
        Dim dtAll As DataTable
        dtAll = MySelectCon.execute("SELECT ISNULL(B.ITEM,A.ITEM) AS ITEM ,ISNULL(B.LIHAT,A.LIHAT) AS LIHAT,ISNULL(B.BARU,A.BARU) AS BARU,ISNULL(B.EDIT,A.EDIT) AS EDIT,ISNULL(B.BATAL,A.BATAL) AS BATAL,ISNULL(B.HAPUS,A.HAPUS) AS HAPUS,ISNULL(B.CETAK,A.CETAK) AS CETAK,A.HEADER,A.GROUP_HEADER  FROM (SELECT ITEM,LIHAT,BARU,EDIT,BATAL,HAPUS,CETAK,HEADER,GROUP_HEADER FROM HAK_USER WHERE ID_GROUP='Default') AS A LEFT JOIN (SELECT ITEM,LIHAT,BARU,EDIT,BATAL,HAPUS,CETAK,HEADER,GROUP_HEADER FROM HAK_USER WHERE ID_GROUP='" & Code & "') AS B ON A.GROUP_HEADER=B.GROUP_HEADER AND A.HEADER=B.HEADER AND A.ITEM=B.ITEM ORDER BY A.GROUP_HEADER")
        'Sistem AR
        Try
            If dtHeader.Select("HEADER='Sistem AR'")(0).Item(3) Then
                ceksistemar.Checked = True : TBSistemAR.Enabled = True
            Else : CekSistemAR.Checked = False : TBSistemAR.Enabled = False : End If
            dtsistemar = dtAll.Select("HEADER='Sistem AR'").CopyToDataTable
            TBSistemAR.DataSource = dtsistemar
            TBSistemAR.Refresh()
            SetColumnnGrid(GVPenjualanLanggananPerwakilan)
        Catch : End Try
        'Sistem
        Try
            If dtHeader.Select("HEADER='Sistem'")(0).Item(3) Then
                CekSistem.Checked = True : TBSistem.Enabled = True
            Else : CekSistem.Checked = False : TBSistem.Enabled = False : End If
            dtSistem = dtAll.Select("HEADER='Sistem'").CopyToDataTable
            TBSistem.DataSource = dtSistem
            TBSistem.Refresh()
            SetColumnnGrid(GVSistem)
        Catch : End Try
    End Sub

    Private Sub Batal()
        Call GetData()
        txtKode.Text = ""
        txtNama.Text = ""
        txtKode.Focus()
    End Sub

    Private Sub _Toolbar1_Button2_ItemClick(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button2.ItemClick
        Call Batal()
    End Sub

    Protected Sub Simpan()
        GVPenjualanLanggananPerwakilan.CloseEditor()
        GVSistem.CloseEditor()

        If Empty({txtKode, txtNama}) Then Exit Sub
        If QuestionInput() = False Then Exit Sub

        If StatusEdit = False Then
            Using dt As DataTable = SelectCon.execute("SELECT * FROM GROUP_USER WHERE ID_GROUP='" & txtKode.Text & "'")
                If dt.Rows.Count > 0 Then
                    MsgBox("Kode Group User Sudah Pernah Dipakai Untuk Group : " & dt.Rows(0).Item("NAMA_GROUP") & " !")
                    Exit Sub
                End If
            End Using
        End If

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If StatusEdit Then
                If SQLServer.UpdateHeader("ID_GROUP,NAMA_GROUP,MDUSER,MDTIME", {txtKode, txtNama, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "GROUP_USER", "ID_GROUP='" & txtKode.Text & "'") = False Then Exit Sub
                If SQLServer.Delete("HAK_USER", "ID_GROUP='" & txtKode.Text & "' and header in ('Sistem','Sistem AR')") = False Then Exit Sub
            Else : If SQLServer.InsertHeader({txtKode, txtNama, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL")}, "GROUP_USER") = False Then Exit Sub
            End If
            'Detail
            If SQLServer.InsertDetail(dtsistemar, {ToObject(txtKode.Text), "GROUP_HEADER", ToObject(CekSistemAR.Checked.ToString), "HEADER", ToObject(CekSistemAR.Checked.ToString), "ITEM", "LIHAT", "BARU", "EDIT", "BATAL", "HAPUS", "CETAK"}, "HAK_USER") = False Then Exit Sub
            If SQLServer.InsertDetail(dtSistem, {ToObject(txtKode.Text), "GROUP_HEADER", ToSyntax("NULL"), "HEADER", ToObject(CekSistem.Checked.ToString), "ITEM", "LIHAT", "BARU", "EDIT", "BATAL", "HAPUS", "CETAK"}, "HAK_USER") = False Then Exit Sub
            SQLServer.EndTransaction()
        End Using
        Log.Insert(Me, txtKode.Text)
        If StatusEdit Then : Dispose() : Else : Batal() : End If
    End Sub

    Private Sub _Toolbar1_Button5_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("GROUP_USER", "ID_GROUP='" & txtKode.Text & "'") = False Then Exit Sub
            If SQLServer.Delete("HAK_USER", "ID_GROUP='" & txtKode.Text & "'") = False Then Exit Sub
            SQLServer.EndTransaction()
            Log.Hapus(Me, txtKode.Text)
            Me.Dispose()
        End Using
    End Sub

    Private Sub txtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtKode.EditValueChanged
        If StatusEdit Then
            GetData()
        End If
    End Sub

    Private Sub SetActive(ByRef Cek As DevExpress.XtraEditors.CheckEdit, ByRef ctl As Control)
        If Cek.Checked Then
            ctl.Enabled = True
        Else : ctl.Enabled = False
        End If
    End Sub
    'Private Sub CekPenjualanLangganan_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CekSistemAR.CheckedChanged
    '    SetActive(sender, SCPenjualanLangganan)
    'End Sub
    Private Sub CekPenjualanLanggananPerwakilan_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub CekSistem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CekSistem.CheckedChanged
        SetActive(sender, TBSistem)
    End Sub

    Private Sub CekSistemAR_CheckedChanged(sender As Object, e As EventArgs) Handles CekSistemAR.CheckedChanged
        SetActive(sender, TBSistemAR)
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            For i = 0 To GVPenjualanLanggananPerwakilan.RowCount - 1
                Dim col As DataRow = GVPenjualanLanggananPerwakilan.GetDataRow(i)
                col(1) = 1
                col(2) = 1
                col(3) = 1
                col(4) = 1
                col(5) = 1
                col(6) = 1
            Next
        Else
            For i = 0 To GVPenjualanLanggananPerwakilan.RowCount - 1
                Dim col As DataRow = GVPenjualanLanggananPerwakilan.GetDataRow(i)
                col(1) = 0
                col(2) = 0
                col(3) = 0
                col(4) = 0
                col(5) = 0
                col(6) = 0
            Next
        End If
    End Sub
End Class

Public Class EditGroupUser
    Inherits FrmGroupUser

    Private Sub EditGroupUser_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        StatusEdit = True
        Text = "Edit Group User"
    End Sub
End Class

Public Class MenuGroupUser
    Inherits FrmMenu

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("select ID_GROUP,NAMA_GROUP FROM GROUP_USER ORDER BY ID_GROUP")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Group User ]"
        GridView1.Columns(0).Caption = "Id"
        GridView1.Columns(0).Width = 50
        GridView1.Columns(1).Caption = "Nama"
        GridView1.Columns(1).Width = 125
    End Sub

    Private Sub MenuKaryawan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Group User"
        AddHandler Me.Activated, AddressOf GetData
        HakMenu("", "Sistem", "Group User", BarButtonBaru, {BtnEdit, BarButtonEdit}, BtnCetak)
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        FrmGroupUser.MdiParent = Me.MdiParent
        FrmGroupUser.StatusEdit = False
        FrmGroupUser.Show()
        FrmGroupUser.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditGroupUser.MdiParent = Me.MdiParent
                EditGroupUser.Show()
                EditGroupUser.Focus()
                EditGroupUser.txtKode.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class