Public Class FrmMonitoringDOOutstanding 
    Private dt As DataTable

    Private dtDivisi As New DataTable
    Private Sub loadDivisi()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode", TypeCode.String, 20, False)
        InitGrid.AddColumnGrid("Divisi", TypeCode.String, 25, False)
        InitGrid.AddColumnGrid("Check", TypeCode.Boolean, 20)
        InitGrid.EndInit(TBDivisi, GridView2, dtDivisi)

        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI WHERE STATUS_AKTIF=1 ORDER BY NAMA")
        LoadData.SetDataDetail(dtDivisi, False)
    End Sub
    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        SetDataTable(sender, e)
    End Sub

    Sub LoadDataGrid()
        SplashScreenManager1.ShowWaitForm()
        Dim filter As String = " AND ("
        For Each r As DataRow In dtDivisi.Rows
            If r(2) Then
                If filter <> " AND (" Then
                    filter = filter & " OR "
                End If
                filter = filter & "B.DIVISI='" & r(0) & "' OR BB.DIVISI='" & r(0) & "' "
            End If
        Next
        filter = filter & ") "
        If filter = " AND () " Then filter = ""

        If RdBagian.SelectedIndex = 1 Then
            Filter = Filter & " AND (B.BAGIAN LIKE '%Pusat%' OR BB.BAGIAN LIKE '%Pusat%')"
        ElseIf RdBagian.SelectedIndex = 2 Then
            Filter = Filter & " AND (B.BAGIAN LIKE '%Perwakilan%' OR BB.BAGIAN LIKE '%Perwakilan%')"
        End If
        If RDPenjualan.SelectedIndex = 1 Then
            Filter = Filter & " AND (B.BAGIAN LIKE '%Langganan%' OR BB.BAGIAN LIKE '%Langganan%')"
        ElseIf RDPenjualan.SelectedIndex = 2 Then
            Filter = Filter & " AND (B.BAGIAN LIKE '%Supermarket%' OR BB.BAGIAN LIKE '%Supermarket%')"
        End If
        If RdPembayaran.SelectedIndex = 1 Then
            filter = filter & " AND (B.PEMBAYARAN='Kontan')"
        ElseIf RdPembayaran.SelectedIndex = 2 Then
            filter = Filter & " AND (B.PEMBAYARAN='Kredit')"
        End If
        dt = SelectCon.execute("SELECT ROW_NUMBER() OVER (PARTITION BY A.ID_TRANSAKSI ORDER BY A.URUTAN) URUT,ISNULL(B.TGL_PENGAKUAN,BB.TGL_PENGAKUAN) TGL_PENGAKUAN,ISNULL(B.NO_DO,BB.NO_BON) NO_DO, CUST.NAMA, G.NAMA_GUDANG,DIV.NAMA DIVISI,BR.NAMA AS NAMA_BARANG,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QUANTITY,A.PCS-A.PCS_T AS PCS,A.HARGA FROM (SELECT V_D_DB_PERW_T_STUFF.[ID_TRANSAKSI] ,[NO_DO] ,[ID_BARANG] ,[KOLI] ,[ISI] ,[QUANTITY] ,[KONVERSI] ,[PCS] ,[SATUAN] ,[URUTAN] ,[DISC] ,[DISKON_SATUAN] ,[HARGA] ,[GUDANG] ,[PCS_T] ,[QUANTITY_T] ,[KOLI_T] ,[ST] ,[STK] FROM V_D_DB_PERW_T_STUFF LEFT JOIN CLOSING_TRANSAKSI ON V_D_DB_PERW_T_STUFF.ID_TRANSAKSI=CLOSING_TRANSAKSI.ID_TRANSAKSI WHERE ST=0 AND CLOSING_TRANSAKSI.ID_TRANSAKSI IS NULL UNION ALL SELECT V_D_DB_PUSAT_T_NOTA.[ID_TRANSAKSI] ,[NO_DO] ,[ID_BARANG] ,[KOLI] ,[ISI] ,[QUANTITY] ,[KONVERSI] ,[PCS] ,[SATUAN] ,[URUTAN] ,[DISC] ,[DISKON_SATUAN] ,[HARGA] ,'' [GUDANG] ,[PCS_T] ,[QUANTITY_T] ,[KOLI_T] ,[ST] ,[STK] FROM V_D_DB_PUSAT_T_NOTA LEFT JOIN CLOSING_TRANSAKSI ON V_D_DB_PUSAT_T_NOTA.ID_TRANSAKSI=CLOSING_TRANSAKSI.ID_TRANSAKSI WHERE ST=0 AND CLOSING_TRANSAKSI.ID_TRANSAKSI IS NULL) A LEFT JOIN DELIVERY_ORDER B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN BON_PESANAN BB ON A.ID_TRANSAKSI=BB.ID_TRANSAKSI LEFT JOIN CUSTOMER CUST ON B.KODE_CUSTOMER=CUST.ID OR BB.KODE_CUSTOMER=CUST.ID LEFT JOIN BARANG BR ON A.ID_BARANG=BR.ID LEFT JOIN GUDANG G ON A.GUDANG=G.KODE LEFT JOIN DIVISI DIV ON B.DIVISI=DIV.KODE WHERE (B.BATAL=0 OR BB.BATAL=0) AND ((CONVERT(DATE,B.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,B.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103)) OR (CONVERT(DATE,BB.TGL_PENGAKUAN,103) >= CONVERT(DATE,'" & DtTanggalAwal.Value & "',103) AND CONVERT(DATE,BB.TGL_PENGAKUAN,103) <= CONVERT(DATE,'" & DtTanggalAkhir.Value & "',103))) " & filter)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
        'GridView1.RefreshData()
        'GridControl1.RefreshDataSource()
        'GridControl1.Refresh()
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub FrmMonitoringDOOutstanding_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadDivisi()
    End Sub

    Private Sub MenuKaryawan_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F5
                _Toolbar1_Button9.PerformClick()
            Case 65
                txtCari.Focus()
        End Select
    End Sub

    Private Sub _Toolbar1_Button9_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button9.Click
        Me.Dispose()
    End Sub

    Private Sub txtCari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCari.EditValueChanged
        GridView1.FindFilterText = txtCari.Text
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        LoadDataGrid()
    End Sub
End Class