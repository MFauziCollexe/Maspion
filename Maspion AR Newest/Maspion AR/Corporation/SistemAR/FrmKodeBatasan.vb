Public MustInherit Class FrmKodeBatasan


    Private Sub FrmKodeBatasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
Public Class InputKodeBatasan
    Inherits FrmKodeBatasan
    Private Function Generate() As Boolean
        Dim urut As Short

        Using dtGenerate = SelectCon.execute("SELECT ID FROM AR_KODE_BATASAN ORDER BY ID DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtIDBank.Text = "KB" & Format(urut, "000000")
        End Using
        Return True
    End Function

    Private Sub Batal()
        Clean(Me.FindForm)
        TxtKodeBatasan.Focus()
    End Sub
    Private Sub InputDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Kode Batasan"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visibility = False
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        Generate()
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDBank, TxtKodeBatasan}) Then Exit Sub

        If QuestionInput() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.InsertHeader({TxtIDBank, TxtKodeBatasan, CekStatusAktif, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), TxtKeterangan}, "AR_KODE_BATASAN") = False Then Exit Sub
                SQLServer.EndTransaction()
                Generate()
                Batal()
            End Using
        End If
    End Sub

End Class

Public Class EditKodeBatasan
    Inherits FrmKodeBatasan
    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Kode Batasan"
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        'HakForm("", "Master", "Divisi", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub
    Private Sub GetData() Handles TxtIDBank.TextChanged
        Dim tempGrup As New DevExpress.XtraEditors.TextEdit
        LoadData.GetData("SELECT  KODE_BATASAN, KETERANGAN,STATUS_AKTIF FROM AR_KODE_BATASAN WHERE ID='" & TxtIDBank.Text & "'")
        LoadData.SetData({TxtKodeBatasan, TxtKeterangan, CekStatusAktif})
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDBank, TxtKodeBatasan}) Then Exit Sub

        If QuestionEdit() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.UpdateHeader("KODE_BATASAN, KETERANGAN,  STATUS_AKTIF, MDUSER, MDTIME", {TxtKodeBatasan, TxtKeterangan, CekStatusAktif, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "AR_KODE_BATASAN", "ID='" & TxtIDBank.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.Delete("AR_KODE_BATASAN", "ID='" & TxtIDBank.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub
End Class