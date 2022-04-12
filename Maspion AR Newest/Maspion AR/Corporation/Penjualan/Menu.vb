
Public Class MenuDebitNote
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_TRANSAKSI,A.TGL,A.TGL_PENGAKUAN,B.NAMA,JUMLAH FROM DEBIT_KREDIT_NOTE A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID WHERE JENIS='Debit' AND PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Debit Note ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Total"
        GridView1.Columns(5).Width = 40
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(5).DisplayFormat.FormatString = "c2"
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Debit Note"
        AddHandler Activated, AddressOf GetData
        SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputDebitNote.MdiParent = Me.MdiParent
        InputDebitNote.Show()
        InputDebitNote.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditDebitNote.MdiParent = Me.MdiParent
                EditDebitNote.Show()
                EditDebitNote.Focus()
                EditDebitNote.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class


Public Class MenuKreditNote
    Inherits FrmMenuDetail

    Private Sub GetData()
        TBMenu.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI,A.NO_TRANSAKSI,A.TGL,A.TGL_PENGAKUAN,B.NAMA,JUMLAH FROM DEBIT_KREDIT_NOTE A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID WHERE JENIS='Kredit' AND PERIODE='" & periode & "'")
        TBMenu.Refresh()
        Frame1.Text = "[ " & GridView1.DataRowCount & " Data Kredit Note ]"
        GridView1.Columns(0).Caption = "ID Transaksi"
        GridView1.Columns(0).Width = 30
        GridView1.Columns(1).Caption = "No. Transaksi"
        GridView1.Columns(1).Width = 50
        GridView1.Columns(2).Caption = "Tanggal"
        GridView1.Columns(2).Width = 30
        GridView1.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(2).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(3).Caption = "Tanggal Pengakuan"
        GridView1.Columns(3).Width = 30
        GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns(3).DisplayFormat.FormatString = "dd-MM-yyyy"
        GridView1.Columns(4).Caption = "Nama Customer"
        GridView1.Columns(4).Width = 75
        GridView1.Columns(5).Caption = "Total"
        GridView1.Columns(5).Width = 40
        GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns(5).DisplayFormat.FormatString = "c2"
    End Sub

    Private Sub MenuPO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Key = "Kredit Note"
        AddHandler Activated, AddressOf GetData
        SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub Baru() Handles BarButtonBaru.ItemClick
        InputKreditNote.MdiParent = Me.MdiParent
        InputKreditNote.Show()
        InputKreditNote.Focus()
    End Sub

    Private Sub Edit() Handles BarButtonEdit.ItemClick
        If GridView1.RowCount > 0 Then
            If Not IsDBNull(GridView1.GetFocusedRow(0)) Then
                EditKreditNote.MdiParent = Me.MdiParent
                EditKreditNote.Show()
                EditKreditNote.Focus()
                EditKreditNote.TxtIDTransaksi.Text = GridView1.GetFocusedRow(0)
            End If
        End If
    End Sub
End Class
