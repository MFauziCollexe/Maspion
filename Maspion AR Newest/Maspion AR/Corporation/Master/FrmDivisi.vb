Public MustInherit Class FrmDivisi
    Protected dt As New DataTable

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

    Private Sub FrmDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Ceklist", TypeCode.Boolean, 40)
        InitGrid.AddColumnGrid("Kode SBU", TypeCode.String, 30, False)
        InitGrid.AddColumnGrid("Nama SBU", TypeCode.String, 100, False)
        InitGrid.EndInit(TBLinkSBU, GridView1, dt)
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        For Each r As DataRow In dt.Rows
            r.Item(0) = "False"
        Next
        SetDataTable(GridView1, e)
    End Sub
End Class


Public Class InputDivisi
    Inherits FrmDivisi

    Private Sub Batal()
        Clean(Me.FindForm)
        TxtKode.Focus()
        LoadData.GetData("SELECT CAST(0 AS BIT),KODE,NAMA FROM SBU ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If QuestionInput() Then
            GridView1.CloseEditor()
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.InsertHeader({TxtKode, TxtNama, TxtPenanggungJawab, TxtKeterangan, "True", UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL")}, "DIVISI") = False Then Exit Sub
                If dt.Select("[Ceklist]='True'").Length > 0 Then
                    If SQLServer.InsertDetail(dt.Select("[Ceklist]=1").CopyToDataTable, {"Kode SBU", ToObject(TxtKode.Text)}, "LINK_SBU_DIVISI") = False Then Exit Sub
                End If
                SQLServer.EndTransaction()
                Batal()
            End Using
        End If
    End Sub

    Private Sub InputDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Divisi"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal

        LoadData.GetData("SELECT CAST(0 AS BIT),KODE,NAMA FROM SBU ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub
End Class

Public Class EditDivisi
    Inherits FrmDivisi

    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Divisi"
        TxtKode.Enabled = False
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "Divisi", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtKode.TextChanged
        LoadData.GetData("SELECT NAMA,PENANGGUNG_JAWAB,KETERANGAN,STATUS_AKTIF FROM DIVISI WHERE KODE='" & TxtKode.Text & "'")
        LoadData.SetData({TxtNama, TxtPenanggungJawab, TxtKeterangan, CekStatusAktif})
        LoadData.GetData("SELECT CAST(IIF(B.KODE_DIVISI IS NULL,0,1) AS BIT),KODE,NAMA FROM SBU A LEFT JOIN LINK_SBU_DIVISI B ON A.KODE=B.KODE_SBU AND B.KODE_DIVISI='" & TxtKode.Text & "' ORDER BY KODE")
        LoadData.SetDataDetail(dt, False)
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub

        If QuestionEdit() Then
            GridView1.CloseEditor()
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.UpdateHeader("NAMA,PENANGGUNG_JAWAB,KETERANGAN,STATUS_AKTIF,MDUSER,MDTIME", _
                                          {TxtNama, TxtPenanggungJawab, TxtKeterangan, CekStatusAktif, UserID, ToSyntax("CURRENT_TIMESTAMP")}, _
                                          "DIVISI", "KODE='" & TxtKode.Text & "'") = False Then Exit Sub
                If SQLServer.Delete("LINK_SBU_DIVISI", "KODE_DIVISI='" & TxtKode.Text & "'") = False Then Exit Sub
                If dt.Select("[Ceklist]='True'").Length > 0 Then
                    If SQLServer.InsertDetail(dt.Select("[Ceklist]=1").CopyToDataTable, _
                                              {"Kode SBU", ToObject(TxtKode.Text)}, "LINK_SBU_DIVISI") = False Then Exit Sub
                End If
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.Click
        If QuestionHapus() Then
            GridView1.CloseEditor()
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.Delete("DIVISI", "KODE='" & TxtKode.Text & "'") = False Then Exit Sub
                If SQLServer.Delete("LINK_SBU_DIVISI", "KODE_DIVISI='" & TxtKode.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub
End Class