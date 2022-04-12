
Public MustInherit Class FrmPaymentKredit
     Protected dt As DataTable
    Private StatusPPN As Integer = 0
    Protected Bagian As EBagian

#Region "Shared Sub"
    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        If _Toolbar1_Button1.Text = "F2 - Simpan" Then
            Simpan()
        Else
            Proses(0)
        End If
    End Sub

    Private Sub _Toolbar1_Button2_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button2.Click
        If _Toolbar1_Button2.Text = "F3 - Batal Proses" Then
            Proses(1)
        Else
            GetData()
        End If
    End Sub

    Private Sub _Toolbar1_Button4_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button4.Click
        If _Toolbar1_Button4.Text = "F5 - Hapus" Then
            HapusPayment()
        Else
            Proses(2)
        End If
    End Sub

    Private Sub Simpan()
        If dt.Select("Checklist='True'").Length = 0 Then
            MsgBox("Tidak Ada Data yg Akan Diproses !!!", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Peringatan")
            Exit Sub
        End If

        RefreshSelected()

        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(9))) Then
                MsgBox("Ada Tanggal Payment yang masih kosong, silahkan cek kembali !!! ")
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns(9)
                Exit Sub
            End If
        Next

        If QuestionInput() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.InsertDetail(dt.Select("Checklist=1").CopyToDataTable, {"ID Nota", "ID Customer", "No. Nota", "Total", "Tgl. Payment", "Bayar", ToObject(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "MONITORING_PAYMENT") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("Checklist=1").CopyToDataTable, {"ID Customer", "ID Nota", "No. Nota", "No. DO", "Tgl. Payment", ToNegative("Bayar"), ToObject(periode)}, "LOG_PIUTANG", "[ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Proses(1)
            RDStatus.SelectedIndex = 0
            GetData()
        End Using
    End Sub

    Private Sub HapusPayment()

        If dt.Select("Checklist=1").Length = 0 Then
            MsgBox("Tidak Ada Data yg Akan Diproses !!!", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Peringatan")
            Exit Sub
        End If

        RefreshSelected()

        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.InsertDetail(dt.Select("Checklist=1").CopyToDataTable, {"ID Nota", "ID Customer", "No. Nota", "Total", "Tgl. Payment", ToNegative("Bayar"), ToObject(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "MONITORING_PAYMENT") = False Then Exit Sub
            If SQLServer.InsertDetail(dt.Select("Checklist=1").CopyToDataTable, {"ID Customer", "ID Nota", "No. Nota", "No. DO", "Tgl. Payment", "Bayar", ToObject(periode)}, "LOG_PIUTANG", "[ID_CUSTOMER] ,[ID_INVOICE] ,[NO_INVOICE] ,[NO_PEMBAYARAN] ,[TGL] ,[TOTAL] ,[PERIODE]") = False Then Exit Sub
            SQLServer.EndTransaction()
            Proses(1)
            RDStatus.SelectedIndex = 0
            GetData()
        End Using
    End Sub
#End Region

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F2
                _Toolbar1_Button1.PerformClick()
            Case System.Windows.Forms.Keys.F3
                _Toolbar1_Button2.PerformClick()
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button4.PerformClick()
            Case System.Windows.Forms.Keys.F6
                _Toolbar1_Button3.PerformClick()
            Case System.Windows.Forms.Keys.F8
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        On Error Resume Next
        If GridView1.GetFocusedRow(0) = "True" Then
            GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = True
        Else
            GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = False
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        On Error Resume Next
        If GridView1.GetFocusedRow(0) = "True" Then
            GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = True
        Else
            GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = False
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns(0)) = "True" Then
            e.Appearance.BackColor = Color.LightGray
        Else
            e.Appearance.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Try
            If IsNumeric(e.Value) Then
                GridView1.GetFocusedDataRow(GridView1.FocusedColumn.FieldName) = Val(e.Value)
            Else
                GridView1.GetFocusedDataRow(GridView1.FocusedColumn.FieldName) = e.Value
            End If
            If e.Column.FieldName = "Checklist" Then
                If e.Value = "True" Then
                    GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = True
                    'GridView1.Columns(10).OptionsColumn.AllowFocus = True
                    GridView1.GetFocusedDataRow()("Tgl. Payment") = Now.Date
                Else
                    GridView1.Columns("Tgl. Payment").OptionsColumn.AllowFocus = False
                    'GridView1.Columns(10).OptionsColumn.AllowFocus = False
                    GridView1.GetFocusedDataRow()("Tgl. Payment") = Now.Date
                End If
            End If
        Catch
        End Try
    End Sub

    Protected Sub Proses(ByVal Proses As Integer)
        If Proses = -1 Then
            _Toolbar1_Button1.Text = "F2 - Proses"
            _Toolbar1_Button2.Text = "F3 - Bersih"
            _Toolbar1_Button4.Text = "F5 - Hapus Payment"
            GridView1.Columns(0).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            GridView1.ActiveFilterString = "Checklist = False True"
        ElseIf Proses = 0 Then
            _Toolbar1_Button1.Text = "F2 - Simpan"
            _Toolbar1_Button2.Text = "F3 - Batal Proses"
            GridView1.Columns(0).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            GridView1.ActiveFilterString = "Checklist = True"
        ElseIf Proses = 1 Then
            _Toolbar1_Button1.Text = "F2 - Proses"
            _Toolbar1_Button4.Text = "F5 - Hapus Payment"
            _Toolbar1_Button2.Text = "F3 - Bersih"
            GridView1.Columns(0).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            GridView1.ActiveFilterString = "Checklist = False True"
        ElseIf Proses = 2 Then
            _Toolbar1_Button4.Text = "F5 - Hapus"
            _Toolbar1_Button2.Text = "F3 - Batal Proses"
            GridView1.Columns(0).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            GridView1.ActiveFilterString = "Checklist = True"
        End If
        If RDStatus.SelectedIndex = 0 Then
            _Toolbar1_Button4.Enabled = False
            _Toolbar1_Button1.Enabled = True
            GridView1.Columns(0).Visible = True
        ElseIf RDStatus.SelectedIndex = 1 Then
            _Toolbar1_Button4.Enabled = True
            _Toolbar1_Button1.Enabled = False
            GridView1.Columns(0).Visible = True
        ElseIf RDStatus.SelectedIndex = 2 Then
            _Toolbar1_Button4.Enabled = False
            _Toolbar1_Button1.Enabled = False
            GridView1.Columns(0).Visible = False
        End If
        RefreshSelected()
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        Me.Close()
    End Sub

    Private Sub FrmMonitoringPayment_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TglPeriode.Value = Format(Now.Date, "01/MM/yyyy")
    End Sub

    Private Sub RDPembayaran_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RDStatus.SelectedIndexChanged, TglPeriode.ValueChanged
        GetData()
        Proses(-1)
    End Sub

    Protected Function RefreshSelected() As Boolean
        Try
            Dim mydt As DataTable = dt.Select("Checklist=1").CopyToDataTable
            Dim idDO As New List(Of String)
            Dim dtDO As New List(Of Date)
            For Each dr As DataRow In mydt.Rows
                idDO.Add(dr.Item(1))
                dtDO.Add(dr.Item(10))
            Next
            GetData()
            For i = 0 To idDO.Count
                Try
                    Dim dr As DataRow = dt.Select("[ID DO]='" & idDO.Item(i) & "'")(0)
                    dr(0) = True
                    dr(10) = dtDO.Item(i)
                Catch : End Try
            Next
        Catch ex As Exception
            'MsgBox("Tidak ada Data yang akan diproses !!")
            Return False
        End Try
        Return True
    End Function

    Protected Sub GetData()
        If RDStatus.SelectedIndex = 0 Then
            dt = SelectCon.execute("SELECT CAST(0 AS BIT) AS Checklist,A.ID_TRANSAKSI AS [ID Nota],A.NO_NOTA AS [No. Nota],A.ID_DO AS [ID DO],A.NO_DO AS [No. DO],A.TGL AS [Tgl. Transaksi],A.TGL_PENGAKUAN AS [Tgl. Pengakuan],C.ID AS [ID Customer],C.NAMA AS [Nama Customer],A.DPP+A.PPN AS Total,A.KETERANGAN_CETAK AS Keterangan ,A.KETERANGAN_INTERNAL AS [Keterangan Internal],CAST(NULL AS DATE) AS [Tgl. Payment],A.DPP+A.PPN AS Bayar FROM NOTA A INNER JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON B.KODE_CUSTOMER=C.ID LEFT JOIN VI_PAY_KREDIT D ON A.ID_TRANSAKSI=D.ID_TRANSAKSI WHERE PEMBAYARAN='Kredit' AND D.STATUS_LUNAS=0 AND A.BATAL<>1 AND A.BAGIAN='" & EnumDescription(Bagian) & "'")
        ElseIf RDStatus.SelectedIndex = 1 Then
            dt = SelectCon.execute("SELECT CAST(0 AS BIT) AS Checklist,A.ID_TRANSAKSI AS [ID Nota],A.NO_NOTA AS [No. Nota],A.ID_DO AS [ID DO],A.NO_DO AS [No. DO],A.TGL AS [Tgl. Transaksi],A.TGL_PENGAKUAN AS [Tgl. Pengakuan],C.ID AS [ID Customer],C.NAMA AS [Nama Customer],A.DPP+A.PPN AS Total,A.KETERANGAN_CETAK AS Keterangan ,A.KETERANGAN_INTERNAL AS [Keterangan Internal],CAST(D.TGL AS DATE) AS [Tgl. Payment],A.DPP+A.PPN AS Bayar FROM NOTA A INNER JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON B.KODE_CUSTOMER=C.ID LEFT JOIN VI_PAY_KREDIT D ON A.ID_TRANSAKSI=D.ID_TRANSAKSI WHERE PEMBAYARAN='Kredit' AND D.STATUS_LUNAS=1 AND A.BATAL<>1 AND A.BAGIAN='" & EnumDescription(Bagian) & "' AND A.PERIODE='" & Format(TglPeriode.Value, "MMyy") & "'")
        ElseIf RDStatus.SelectedIndex = 2 Then
            dt = SelectCon.execute("SELECT CAST(0 AS BIT) AS Checklist,A.ID_TRANSAKSI AS [ID Nota],A.NO_NOTA AS [No. Nota],A.ID_DO AS [ID DO],A.NO_DO AS [No. DO],A.TGL AS [Tgl. Transaksi],A.TGL_PENGAKUAN AS [Tgl. Pengakuan],C.ID AS [ID Customer],C.NAMA AS [Nama Customer],A.DPP+A.PPN AS Total,A.KETERANGAN_CETAK AS Keterangan ,A.KETERANGAN_INTERNAL AS [Keterangan Internal],CAST(D.TGL AS DATE) AS [Tgl. Payment],A.DPP+A.PPN AS Bayar FROM NOTA A INNER JOIN DELIVERY_ORDER B ON A.ID_DO=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON B.KODE_CUSTOMER=C.ID LEFT JOIN VI_PAY_KREDIT D ON A.ID_TRANSAKSI=D.ID_TRANSAKSI WHERE PEMBAYARAN='Kredit' AND A.BATAL<>1 AND A.BAGIAN='" & EnumDescription(Bagian) & "' AND A.PERIODE='" & Format(TglPeriode.Value, "MMyy") & "'")
        End If
        TBMonitoring.DataSource = dt
        Try
            GridView1.Columns(0).Width = 10
            GridView1.Columns(1).Width = 1
            GridView1.Columns(1).OptionsColumn.AllowFocus = False
            GridView1.Columns(1).Visible = False
            GridView1.Columns(2).Width = 25
            GridView1.Columns(2).OptionsColumn.AllowFocus = False
            GridView1.Columns(3).Width = 1
            GridView1.Columns(3).OptionsColumn.AllowFocus = False
            GridView1.Columns(3).Visible = False
            GridView1.Columns(4).Width = 25
            GridView1.Columns(4).OptionsColumn.AllowFocus = False
            GridView1.Columns(5).Width = 20
            GridView1.Columns(5).OptionsColumn.AllowFocus = False
            GridView1.Columns(6).Width = 20
            GridView1.Columns(7).Width = 40
            GridView1.Columns(7).OptionsColumn.AllowFocus = False
            GridView1.Columns(8).Width = 50
            GridView1.Columns(8).OptionsColumn.AllowFocus = False
            GridView1.Columns(9).Width = 30
            GridView1.Columns(9).OptionsColumn.AllowFocus = False
            GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns(9).DisplayFormat.FormatString = "n2"
            GridView1.Columns(10).Width = 75
            GridView1.Columns(10).OptionsColumn.AllowFocus = False
            GridView1.Columns(10).Width = 75
            GridView1.Columns(10).OptionsColumn.AllowFocus = False
            GridView1.Columns(11).Width = 75
            GridView1.Columns(11).OptionsColumn.AllowFocus = False
            GridView1.Columns(12).Width = 30
            GridView1.Columns(12).OptionsColumn.AllowFocus = False
            GridView1.Columns(13).Visible = False
            GridView1.BestFitColumns()
            GridView1.Columns(2).BestFit()
            GridView1.Columns(4).BestFit()

            GroupBox1.Text = "[ " & GridView1.RowCount & " Data Nota ] "
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _Toolbar1_Button6_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button6.Click
        GridView1.ShowPrintPreview()
    End Sub
End Class
