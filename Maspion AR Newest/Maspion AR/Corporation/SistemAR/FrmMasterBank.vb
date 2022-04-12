Imports DevExpress.XtraEditors.Controls

Public MustInherit Class FrmMasterBank
    Private Sub FrmMasterBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtKodeAkun_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeAkun.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.Kode_Perkiraan)
        TxtKodeAkun.Text = kode
    End Sub

    Private Sub TxtKodeAkun_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeAkun.EditValueChanged
        Using dt = SelectCon.execute("select NAMA_PERKIRAAN from AR_KODE_PERKIRAAN where KODE_PERKIRAAN = '" & TxtKodeAkun.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaAkun.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub

    Private Sub TxtKodePT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodePT.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.PT)
        TxtKodePT.Text = kode
    End Sub

    Private Sub TxtKodePT_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodePT.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from PT where KODE = '" & TxtKodePT.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaPT.Text = dt.Rows(0)(0)
            End If
        End Using
        TxtKodeSBU.Text = ""
        TxtNamaSBU.Text = ""
    End Sub

    Private Sub TxtKodeSBU_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtKodeSBU.ButtonClick
        Dim kode = Search(FrmPencarian.KeyPencarian.SBU,,,,, TxtKodePT.Text)

        TxtKodeSBU.Text = kode
    End Sub

    Private Sub TxtKodeSBU_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodeSBU.EditValueChanged
        Using dt = SelectCon.execute("select NAMA from SBU where KODE = '" & TxtKodeSBU.Text & "'")
            If dt.Rows.Count > 0 Then
                TxtNamaSBU.Text = dt.Rows(0)(0)
            End If
        End Using
    End Sub
End Class

Public Class InputMasterBank
    Inherits FrmMasterBank
    Private Function Generate() As Boolean
        Dim urut As Short

        Using dtGenerate = SelectCon.execute("SELECT ID_BANK FROM AR_MASTER_BANK ORDER BY ID_BANK DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtIDBank.Text = "B" & Format(urut, "000000")
        End Using
        Return True
    End Function
    Private Sub Batal()
        Clean(Me.FindForm)
        TxtNamaBank.Focus()
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDBank, TxtNamaBank, TxtKodeAkun}) Then Exit Sub

        If QuestionInput() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.InsertHeader({TxtIDBank, TxtNamaBank, TxtKodeAkun, TxtNomorRekening, TxtKeterangan, CekStatusAktif, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), CKBankGiro, TxtKodePT, TxtKodeSBU}, "AR_MASTER_BANK") = False Then Exit Sub
                SQLServer.EndTransaction()
                Generate()
                Batal()
            End Using
        End If
    End Sub

    Private Sub InputDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Master Bank"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visibility = False
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf Batal
        Generate()
    End Sub
End Class

Public Class EditMasterBank
    Inherits FrmMasterBank
    Private Sub EditDivisi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Master Bank"
        AddHandler _Toolbar1_Button2.ItemClick, AddressOf GetData
        'HakForm("", "Master", "Divisi", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtIDBank.TextChanged
        Dim tempGrup As New DevExpress.XtraEditors.TextEdit
        LoadData.GetData("SELECT  NAMA_BANK, KODE_PERKIRAAN, NO_REKENING, KETERANGAN,STATUS_AKTIF,BANK_GIRO,KODE_PT,KODE_SBU FROM AR_MASTER_BANK WHERE ID_BANK='" & TxtIDBank.Text & "'")
        LoadData.SetData({TxtNamaBank, TxtKodeAkun, TxtNomorRekening, TxtKeterangan, CekStatusAktif, CKBankGiro, TxtKodePT, TxtKodeSBU})
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If Empty({TxtIDBank, TxtNamaBank, TxtKodeAkun}) Then Exit Sub

        If QuestionEdit() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.UpdateHeader("NAMA_BANK, KODE_PERKIRAAN, NO_REKENING, KETERANGAN,  STATUS_AKTIF, MDUSER, MDTIME,BANK_GIRO,KODE_PT,KODE_SBU", {TxtNamaBank, TxtKodeAkun, TxtNomorRekening, TxtKeterangan, CekStatusAktif, UserID, ToSyntax("CURRENT_TIMESTAMP"), CKBankGiro, TxtKodePT, TxtKodeSBU}, "AR_MASTER_BANK", "ID_BANK='" & TxtIDBank.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.ItemClick
        If QuestionHapus() Then
            Using SQLServer As New SQLServerTransaction
                SQLServer.InitTransaction()
                If SQLServer.Delete("AR_MASTER_BANK", "ID_BANK='" & TxtIDBank.Text & "'") = False Then Exit Sub
                SQLServer.EndTransaction()
                Me.Dispose()
            End Using
        End If
    End Sub
End Class