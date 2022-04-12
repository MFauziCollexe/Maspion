
Public MustInherit Class FrmDO
    Protected dt As New DataTable
    Protected StatusEdit As Boolean

    Private Sub FrmDO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F6
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F7
                _Toolbar1_Button5.PerformClick()
        End Select
    End Sub

    Private Sub InputPO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        'Add Column Gridview
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 15, False)
        InitGrid.AddColumnGrid("Kode Barang", TypeCode.String, 60)
        InitGrid.AddColumnGrid("Nama Barang", TypeCode.String, 150, False)
        InitGrid.AddColumnGrid("Collie", TypeCode.Double, 25)
        InitGrid.AddColumnGrid("Quantity", TypeCode.Double, 25)
        InitGrid.AddColumnGrid("Satuan", TypeCode.String, 50)
        InitGrid.AddColumnGrid("Harga Satuan", TypeCode.Double, 50)
        InitGrid.AddColumnGrid("Disc %", TypeCode.Double, 25)
        InitGrid.AddColumnGrid("Disc Satuan", TypeCode.Double, 50)
        InitGrid.AddColumnGrid("Subtotal", TypeCode.Double, 100, False)
        InitGrid.EndInit(TBinputPO, GridView1, dt)
        AddRow(dt)
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click, Me.FormClosing
        dt.Dispose()
        Me.Dispose()
    End Sub

    Private Sub TBinputPO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBinputPO.EditorKeyDown
        If e.KeyCode = 13 Then
            If GridView1.FocusedColumn.FieldName = "Disc Satuan" Then
                If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
                    If StatusEdit = False Then
                        AddRow(dt)
                        GridView1.GetFocusedDataRow("No.") = vbNull
                    End If
                    GridView1.FocusedColumn = GridView1.VisibleColumns("Kode Barang")
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "Kode Barang" Then
                '  Dim kode = Search(FrmPencarian.KeyPencarian.Item, GridView1.EditingValue, _
                '                               FrmPencarian.TypeButton.Item)

                Try
                    'For i = 0 To GridView1.RowCount - 2
                    '    If GridView1.GetRowCellValue(i, GridView1.Columns("Kode Barang")) = kode Then
                    '        MsgBox("Kode Barang Sudah Ada !!")
                    '        GridView1.EditingValue = ""
                    '        SendKeys.Send("{Left}")
                    '        Exit Sub
                    '    End If
                    'Next
                    'GridView1.EditingValue = kode
                Catch ex As Exception
                End Try

                If GridView1.EditingValue = "" Then
                    SendKeys.Send("{Left}")
                Else
                    'Get Data
                    Dim col As DataRow = GridView1.GetFocusedDataRow()
                    Using dt_cari = SelectCon.execute("SELECT NAMA,SATUAN FROM ITEM WHERE KODE='" & GridView1.EditingValue & "'")
                        If dt_cari.Rows.Count > 0 Then
                            col("No.") = GridView1.FocusedRowHandle + 1
                            col("Nama Barang") = dt_cari.Rows(0).Item("NAMA")
                            col("Collie") = 0
                            col("Quantity") = 0
                            col("Satuan") = ""
                            col("Harga Satuan") = 0
                            col("Disc %") = 0
                            col("Disc Satuan") = 0
                            col("Subtotal") = 0
                        Else
                            col("No.") = vbNull
                            col("Kode Barang") = ""
                            col("Nama Barang") = ""
                            col("Collie") = 0
                            col("Quantity") = 0
                            col("Satuan") = ""
                            col("Harga Satuan") = 0
                            col("Disc %") = 0
                            col("Disc Satuan") = 0
                            col("Subtotal") = 0
                        End If
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub DTpo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DTpo.KeyPress, TglHarga.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z")
        End Select
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Dim col As DataRow = GridView1.GetFocusedDataRow()
        Select Case GridView1.FocusedColumn.FieldName
            Case "Quantity", "Harga Satuan"
                col("Subtotal") = col("Quantity") * (col("Harga Satuan") * ((100 - (col("Disc Satuan") / col("Harga Satuan") * 100)) / 100))
            Case "Disc %"
                col("Disc Satuan") = col("Harga Satuan") * col("Disc %") / 100
                col("Subtotal") = col("Quantity") * (col("Harga Satuan") * ((100 - (col("Disc Satuan") / col("Harga Satuan") * 100)) / 100))
            Case "Disc Satuan"
                col("Disc %") = Math.Round(col("Disc Satuan") / col("Harga Satuan") * 100, 2)
                col("Subtotal") = col("Quantity") * (col("Harga Satuan") * ((100 - (col("Disc Satuan") / col("Harga Satuan") * 100)) / 100))
        End Select
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If Len(GridView1.GetFocusedRow("Nama Barang").ToString.Trim) > 0 Then
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns("Kode Barang").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub TxtKode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKode.EditValueChanged
        Using dtSupplier = SelectCon.execute("select id,nama,alamat_kantor from supplier where id='" & TxtKode.Text & "'")
            If dtSupplier.Rows.Count > 0 Then
                TxtNama.Text = dtSupplier.Rows(0).Item("nama")
                If IsDBNull(dtSupplier.Rows(0).Item("alamat_kantor")) = True Then
                    TxtAlamatK.Text = ""
                Else
                    TxtAlamatK.Text = dtSupplier.Rows(0).Item("alamat_kantor")
                End If
            Else
                TxtNama.Text = ""
                TxtAlamatK.Text = ""
            End If
        End Using
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
         If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            If GridView1.RowCount = 0 Then
                AddRow(dt)
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            End If
        End If
    End Sub

    Private Sub TxtDivisi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDivisi.KeyPress
        If CharKeypress(e) Then
            TxtDivisi.Text = Search(FrmPencarian.KeyPencarian.Divisi)
        End If
    End Sub
End Class


Public Class InputBonPesananSuper
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & "(SUPER)" & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bon Pesanan Supermarket"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOKontanSuper
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & "(SUPER)" & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Kontan Supermarket"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOTitipanSuper
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & "(SUPER)" & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Titipan Supermarket"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class


Public Class InputBonPesananDistributor
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bon Pesanan Distributor"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOKontanDistributor
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Kontan Distributor"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOTitipanDistributor
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Titipan Distributor"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputBonPesananLain
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Bon Pesanan Lain - lain"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOKontanLain
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Kontan Lain - lain"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputDOTitipanLain
    Inherits FrmDO

    Private Sub batal() Handles _Toolbar1_Button2.Click
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
        TxtNo.Text = ""
        TxtDivisi.Text = ""
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamatK.Text = ""
        TxtAlamatKirim.Text = ""
        txtKeterangan.Text = ""
        CekCetak.Checked = False
        dt.Clear()
        AddRow(dt)
        DTpo.Focus()
    End Sub

    Private Sub Generate()
        Dim urut As Short
        Dim date1 As String
        date1 = Format(DTpo.DateTime, "yy")
        'Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
        '    If dtGenerate.Rows.Count = 0 Then
        '        urut = 1
        '    Else
        '        Dim ada As String = dtGenerate.Rows(0).Item(0)
        '        urut = ada.Substring(8, 4) + 1
        '    End If
        'End Using
        urut = 1
        TxtNo.Text = TxtDivisi.Text & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "000000")
    End Sub

    Private Sub InputBonPesananSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input DO Titipan Lain - lain"
        StatusEdit = False
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class