Public MustInherit Class FrmDeliveryOrder
    Private dt As New DataTable

    Private Sub batal()
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
        Using dtGenerate = SelectCon.execute("SELECT NO_NOTA_PO FROM PO WHERE NO_NOTA_PO Like 'PO/" & date1 & Format(DTpo.DateTime, "MM") & "%' ORDER BY NO_NOTA_PO DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                Dim ada As String = dtGenerate.Rows(0).Item(0)
                urut = ada.Substring(8, 4) + 1
            End If
            TxtNo.Text = "PO/" & date1 & Format(DTpo.DateTime, "MM") & Format(urut, "/0000")
        End Using
    End Sub

    Private Sub InputPO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1_Click(sender, e)
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2_Click(sender, e)
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button3_Click(sender, e)
        End Select
    End Sub

    Private Sub InputPO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DTpo.DateTime = Format(Now.Date, "dd/MM/yyyy")
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

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub TxtKode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKode.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z")
                e.KeyChar = ""
                'TxtKode.Text = Search(FrmPencarian.KeyPencarian.Supplier, , FrmPencarian.TypeButton.Supplier)
        End Select
    End Sub

    Private Sub TBinputPO_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBinputPO.EditorKeyDown
        If e.KeyCode = 13 Then
            If GridView1.FocusedColumn.FieldName = "Disc Item" Then
                If IsDBNull(GridView1.GetRowCellValue(GridView1.RowCount - 1, GridView1.Columns(0))) = False Then
                    GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "Kode Barang" Then
                '  Dim kode = Search(FrmPencarian.KeyPencarian.Item, GridView1.EditingValue, _
                '                               FrmPencarian.TypeButton.Item)

                Try
                    'For i = 0 To GridView1.RowCount - 2
                    '    If GridView1.GetRowCellValue(i, GridView1.Columns(1)) = kode Then
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
                            'col("No.") = counter
                            col("Nama Barang") = dt_cari.Rows(0).Item(0)
                            col("Harga") = 0
                            col("Satuan") = dt_cari.Rows(0).Item(1)
                            col("Collie") = 0
                            col("Keterangan") = ""
                        Else
                            col("Nama Barang") = ""
                            col("Harga") = 0
                            col("Collie") = 0
                            col("Satuan") = ""
                            col("Keterangan") = ""
                            col("Qty") = 0
                        End If
                    End Using
                End If
            End If
        End If
    End Sub


    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        Dim i As Integer
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtDivisi) Then Exit Sub
        If Empty(DTpo) Then Exit Sub


        If GridView1.RowCount = 0 Then
            MsgBox("Data Detail PO masih kosong!!!", vbCritical, "Peringatan")
            Exit Sub
        End If

        For i = 0 To GridView1.RowCount - 1
            If Len(GridView1.GetRowCellValue(i, GridView1.Columns(2))) > 0 Then
                If GridView1.GetRowCellValue(i, GridView1.Columns("Qty")) = 0 Then
                    MsgBox("Ada Quantity yang masih 0, silahkan cek kembali !!! ")
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("Qty")
                    Exit Sub
                End If
            End If
        Next

        If Format(DTpo.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda lakukan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin menyimpan Transaksi ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        Generate()
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNo.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        con.begin_exec()
        'If con.exec("INSERT INTO PO VALUES ('" & TxtNo.Text & "','" & TxtNoPO.Text & "','" & Format(DTpo.EditValue, "MM/dd/yyyy") & "','" & TxtKode.Text & "','" & TxtAlamatT.Text & "','" & CmbPembayaran.Text & "'," & TxtHari.Text & ",'" & Format(TanggalKirim.EditValue, "MM/dd/yyyy") & "'," & Replace(CDbl(TxtSubTotal.Text), ",", ".") & "," & Replace(CDbl(Txtdiskon2.Text), ",", ".") & "," & Replace(CDbl(txtDPP.Text), ",", ".") & "," & Replace(CDbl(txtPPN.Text), ",", ".") & ",'" & TxtKeterangan.Text & "','" & periode & "','" & UserID & "',CURRENT_TIMESTAMP,null,null,0)") = False Then GoTo keluar

        FrmLoading.Show()
        FrmLoading.DataKeseluruhan = GridView1.RowCount + 1
        FrmLoading.Proses = 0
        GridView1.CloseEditor()
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(1))) = False Then
                If GridView1.GetRowCellValue(i, GridView1.Columns(2)) <> "" Then
                    'If con.exec("INSERT INTO DETAIL_PO VALUES ('" & TxtNo.Text & "','" & GridView1.GetRowCellValue(i, GridView1.Columns(1)) & "'," & Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(3))), ",", ".") & ",'" & GridView1.GetRowCellValue(i, GridView1.Columns(4)) & "'," & Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(5))), ",", ".") & "," & IIf(IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(6))) = True, 0, Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(6))), ",", ".")) & "," & IIf(IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(7))) = True, 0, Replace(CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(7))), ",", ".")) & "," & GridView1.GetRowCellValue(i, GridView1.Columns(0)) & ",0,0)") = False Then GoTo keluar
                End If
            End If
            Application.DoEvents()
            FrmLoading.Proses = FrmLoading.Proses + 1
        Next
        FrmLoading.Dispose()

        con.end_exec(True)
        MessageBox.Show("Data telah disimpan..!!", _
                        "Penyimpanan Sukses", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)

        If CekCetak.Checked Then
            'ShowDevexpressReport(ReportPreview.KeyReport.Nota_PO, TxtNo.Text)
        End If

        batal()
        Exit Sub
keluar:
        con.end_exec(False)
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub DTpo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DTpo.KeyPress, DateEdit2.KeyPress, DateEdit1.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z")
        End Select
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        On Error Resume Next
        Dim col As DataRow = GridView1.GetDataRow(e.RowHandle)

        If GridView1.FocusedColumn.FieldName = "Kode Barang" Or GridView1.FocusedColumn.FieldName = "Qty" Or GridView1.FocusedColumn.FieldName = "Satuan" Then
            'Using dt_cari2 = con.execute("select TOP 1 A.HARGA from DETAIL_PEMBELIAN A INNER JOIN PEMBELIAN B ON A.NO_PEMBELIAN=B.NO_PEMBELIAN WHERE A.KODE_BARANG= '" & GridView1.GetFocusedRowCellValue(GridView1.Columns(1)).ToString & "' and A.SATUAN= '" & GridView1.GetFocusedRowCellValue(GridView1.Columns(4)).ToString & "' ORDER BY B.TGL_NOTA DESC")
            '    If dt_cari2.Rows.Count > 0 Then
            '        col("Harga") = dt_cari2.Rows(0).Item(0)
            '        col("Disc%") = 0
            '        col("Disc Item") = 0
            '        col("Subtotal") = col("Qty") * col("Harga") * ((100 - (col("Disc Item") / (col("Harga") * col("Qty")) * 100)) / 100)
            '    End If
            'End Using
        End If


    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        If Len(GridView1.GetFocusedRow(2)) > 1 Then
            GridView1.Columns(1).OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns(1).OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If IsDBNull(GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.FocusedColumn)) = False Then
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns(0).OptionsColumn.AllowEdit = True
        End If
        If Len(GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.Columns(2))) > 1 Then
            GridView1.Columns(1).OptionsColumn.AllowEdit = False
        Else
            GridView1.Columns(1).OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub GridView1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z")
            Case 13
                e.Handled = True
                SendKeys.Send("{Tab}")
        End Select
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

    Private Sub _Toolbar1_Button2_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button2.Click
        Call batal()
    End Sub

    Private Sub GridView1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = 46 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.FocusedColumn = GridView1.VisibleColumns(1)
            If GridView1.RowCount = 0 Then
                GridView1.FocusedColumn = GridView1.VisibleColumns(1)
            End If
        End If
    End Sub

    Private Sub DTpo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DTpo.KeyUp, DateEdit2.KeyUp, DateEdit1.KeyUp
        If DTpo.Text = "" Then
            DTpo.DateTime = Now.Date
        End If
    End Sub
End Class

Public Class InputNotaSJSuper
    Inherits FrmDeliveryOrder

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Nota / Surat Jalan Supermarket"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputNotaSJDistributor
    Inherits FrmDeliveryOrder

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Nota / Surat Jalan Distributor"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class

Public Class InputNotaSJLain
    Inherits FrmDeliveryOrder

    Private Sub InputPreDOSuper_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Nota / Surat Jalan Lain"
        _Toolbar1_Button4.Visible = False
        _Toolbar1_Button5.Visible = False
    End Sub
End Class