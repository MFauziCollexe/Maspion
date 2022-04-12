Public MustInherit Class FrmBarang
    Protected dtDivisi As New DataTable
    Protected dtPromo As New DataTable

    Private Sub BtnGroupBarang_Click(sender As System.Object, e As System.EventArgs) Handles BtnGroupBarang.Click
        FrmGrupBarang.ShowDialog()
        CmbGroupBarang.Properties.Items.Clear()
        Using dtload = SelectCon.execute("SELECT KODE+'-'+NAMA FROM GROUP_BARANG ORDER BY KODE")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    CmbGroupBarang.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using
    End Sub

    Private Sub FrmBarang_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub FrmBarang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Divisi
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Divisi", TypeCode.String, 30)
        InitGrid.AddColumnGrid("Nama Divisi", TypeCode.String, 100)
        InitGrid.AddColumnGrid("Ceklist", TypeCode.Boolean, 40)
        InitGrid.EndInit(TBDivisi, GridView2, dtDivisi)
        'Promo
        InitGrid.Clear()
        InitGrid.AddColumnGrid("Kode Promo", TypeCode.String, 40, , , , , RepoBtnPromo)
        InitGrid.AddColumnGrid("Nama Promo", TypeCode.String, 100, False)
        InitGrid.AddColumnGrid("Tgl Awal", TypeCode.DateTime, 30, True, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.AddColumnGrid("Tgl Akhir", TypeCode.DateTime, 30, True, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
        InitGrid.EndInit(TBPromo, GVPromo, dtPromo)
        Using dtload = SelectCon.execute("SELECT KODE+'-'+NAMA FROM GROUP_BARANG ORDER BY KODE")
            If dtload.Rows.Count > 0 Then
                For I = 0 To dtload.Rows.Count - 1
                    CmbGroupBarang.Properties.Items.Add(dtload.Rows(I).Item(0))
                Next
            End If
        End Using

        TglPriceList.DateTime = Now.Date
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.Click
        dtDivisi.Dispose()
        Dispose()
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        For Each r As DataRow In dtDivisi.Rows
            r.Item(2) = "False"
        Next
        SetDataTable(GridView2, e)
    End Sub

    Private Sub PencarianSatuan(ByRef Ctrl As Control)
        Ctrl.Text = Search(FrmPencarian.KeyPencarian.Satuan, , FrmPencarian.TypeButton.Satuan)
    End Sub

    Private Sub TxtSatuanSupermarket1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanSupermarket1.ButtonClick
        PencarianSatuan(TxtSatuanSupermarket1)
    End Sub

    Private Sub TxtSatuanSupermarket2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanSupermarket2.ButtonClick
        PencarianSatuan(TxtSatuanSupermarket2)
    End Sub

    Private Sub TxtSatuanSupermarket2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtSatuanSupermarket2.EditValueChanged, TxtSatuanSupermarket1.EditValueChanged
        LblSatuanSupermarket.Text = TxtSatuanSupermarket1.Text & " / " & TxtSatuanSupermarket2.Text
        LblKoliKecil.Text = LblSatuanSupermarket.Text
    End Sub

    Private Sub TxtSatuanDistributor1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanDistributor1.ButtonClick
        PencarianSatuan(TxtSatuanDistributor1)
    End Sub

    Private Sub TxtSatuanDistributor2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanDistributor2.ButtonClick
        PencarianSatuan(TxtSatuanDistributor2)
    End Sub

    Private Sub TxtSatuanDistributor2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtSatuanDistributor2.EditValueChanged, TxtSatuanDistributor1.EditValueChanged
        LblSatuanDist.Text = TxtSatuanDistributor1.Text & " / " & TxtSatuanDistributor2.Text
    End Sub

    Private Sub TxtSatuanKoli1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanKoli1.ButtonClick
        PencarianSatuan(TxtSatuanKoli1)
    End Sub

    Private Sub TxtSatuanKoli2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtSatuanKoli2.ButtonClick
        PencarianSatuan(TxtSatuanKoli2)
    End Sub

    Private Sub BtnTambahSatuan_Click(sender As System.Object, e As System.EventArgs) Handles BtnTambahSatuan.Click
        FrmSatuan.ShowDialog()
    End Sub

    Private Sub BtnKoliKecil_Click(sender As System.Object, e As System.EventArgs) Handles BtnKoliKecil.Click
        TxtKoliKecil.Visible = True
        LblKoliKecil.Visible = True
    End Sub

    Private Sub TxtKoliKecil_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtKoliKecil.EditValueChanged
        TxtQtyKoli.Text = TxtKoliKecil.Value / TxtQtyDist.Value
        'TxtQtyKoli.Value = TxtKoliKecil.Value / TxtQtyDist.Value
    End Sub

    Private Sub TxtQtyKoli_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtQtyKoli.EditValueChanged
        If ActiveControl IsNot Nothing Then
            If ActiveControl.Parent.Name = TxtQtyKoli.Name Then
                TxtKoliKecil.Visible = False
                LblKoliKecil.Visible = False
            End If
        End If
    End Sub

    Private Sub RepoBtnPromo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnPromo.ButtonClick
        Dim col As DataRow = GVPromo.GetFocusedDataRow()
        Dim kode As String = Search(FrmPencarian.KeyPencarian.Promo, GVPromo.EditingValue, FrmPencarian.TypeButton.Promo)
        If kode = "" Then
            col("Kode Promo") = kode
            GVPromo.EditingValue = kode
        Else
            col("Kode Promo") = kode
        End If
        Using dt_cari = SelectCon.execute("SELECT TOP 1 KODE,NAMA_PROMO FROM PROMO WHERE KODE='" & col("Kode Promo") & "'")
            If dt_cari.Rows.Count > 0 Then
                col("Kode Promo") = dt_cari.Rows(0).Item("KODE")
                GVPromo.EditingValue = dt_cari.Rows(0).Item("KODE")
                col("Nama Promo") = dt_cari.Rows(0).Item("NAMA_PROMO")
                AddRow(dtPromo)
                GVPromo.FocusedColumn = GVPromo.Columns("Kode Promo")
            Else
                col("Kode Promo") = ""
                col("Nama Promo") = ""
            End If
        End Using
    End Sub

    Private Sub GVPromo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GVPromo.KeyUp
        If e.KeyCode = 46 Then
            GVPromo.DeleteRow(GVPromo.FocusedRowHandle)
            GVPromo.FocusedColumn = GVPromo.Columns("Kode Promo")
            If GVPromo.RowCount = 0 Then
                AddRow(dtPromo)
                GVPromo.FocusedColumn = GVPromo.Columns("Kode Promo")
            End If
        End If
    End Sub
End Class


Public Class InputBarang
    Inherits FrmBarang

    Private Sub Generate()
        Dim urut As Integer

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID,'BR','') AS BIGINT)),0) FROM BARANG")
            If (dtGenerate.Rows(0).Item(0)) = 0 Then
                urut = 1
            Else
                urut = dtGenerate.Rows(0).Item(0) + 1
            End If
            TxtIDBarang.Text = "BR" & urut
        End Using
    End Sub

    Private Sub Batal()
        Clean(Me.FindForm)
        Generate()
        TxtKode.Focus()
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
        dtPromo.Clear()
        AddRow(dtPromo)
        TxtKoliKecil.Visible = False
        LblKoliKecil.Visible = False
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty({TxtKode, TxtNama}) Then Exit Sub
        If RDStatusBarang.SelectedIndex = -1 Then
            MsgBox("Status Barang Belum diisi !!", MsgBoxStyle.Information)
            RDStatusBarang.Focus()
            Exit Sub
        End If
        If dtDivisi.Select("[Ceklist]<>0").Length > 0 = False Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        Dim divisi As String = ""
        Try : divisi = dtDivisi.Select("[Ceklist]<>0")(0).Item(0)
        Catch : End Try
        If SelectCon.execute("SELECT KODE FROM BARANG A LEFT JOIN LINK_BARANG_DIVISI B ON A.ID=B.ID_BARANG WHERE A.KODE='" & TxtKode.Text & "' AND B.KODE_DIVISI='" & divisi & "'").Rows.Count > 0 Then
            MsgBox("Kode Barang Sudah digunakan !", MsgBoxStyle.Information)
            Exit Sub
        End If

        Generate()
        If QuestionInput() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDBarang, TxtKode, TxtKodePabrik, TxtNama, TxtNamaAlias1, TxtNamaAlias2, TxtNamaAlias3, Split(CmbGroupBarang.SelectedItem, "-")(0), ChkBatasMin, txtBatasMin, ChkBatasMax, TxtBatasMax, txtInnerP, txtInnerL, txtInnerT, txtOuterP, txtOuterL, txtOuterT, TxtKodeAkun, RDStatusBarang, TxtSatuanSupermarket1, TxtSatuanSupermarket2, TxtHargaSupermarket, TxtSatuanDistributor1, TxtSatuanDistributor2, TxtHargaDistributor, TxtQtyDist, TxtSatuanKoli1, TxtSatuanKoli2, TxtQtyKoli, ToSyntax("1"), UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), TglPriceList}, "BARANG") = False Then Exit Sub
            'Detail
            SQLServer.InsertDetail(dtDivisi.Select("[Ceklist]<>0").CopyToDataTable, {ToObject(TxtIDBarang.Text), "Kode Divisi"}, "LINK_BARANG_DIVISI")
            If dtPromo.Select("LEN([Kode Promo])>0").Length > 0 Then SQLServer.InsertDetail(dtPromo.Select("LEN([Kode Promo])>0").CopyToDataTable, {ToObject(TxtIDBarang.Text), "Kode Promo", "Tgl Awal", "Tgl Akhir"}, "LINK_BARANG_PROMO")
            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub

    Private Sub InputBarang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Input Barang"
        CekStatusAktif.Visible = False
        _Toolbar1_Button4.Visible = False
        AddHandler _Toolbar1_Button2.Click, AddressOf Batal
        Generate()
        LoadData.GetData("SELECT KODE,NAMA,CAST(0 AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
        AddRow(dtPromo)
    End Sub
End Class

Public Class EditBarang
    Inherits FrmBarang

    Private Sub EditBarang_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Text = "Edit Barang"
        AddHandler _Toolbar1_Button2.Click, AddressOf GetData
        HakForm("", "Master", "Barang", CekStatusAktif, _Toolbar1_Button4, _Toolbar1_Button4)
    End Sub

    Private Sub GetData() Handles TxtIDBarang.TextChanged
        LoadData.GetData("SELECT [KODE] ,[KODE_PABRIK] ,[NAMA] ,[NAMA_ALIAS1] ,[NAMA_ALIAS2] ,[NAMA_ALIAS3] ,[GROUP_BARANG] ,[EN_BATAS_MIN] ,[BATAS_MIN] ,[EN_BATAS_MAX] ,[BATAS_MAX] ,[IN_P] ,[IN_L] ,[IN_T] ,[OUT_P] ,[OUT_L] ,[OUT_T] ,[AKUN] ,[STATUS_PERSEDIAAN] ,[SAT_SUPER1] ,[SAT_SUPER2] ,[HARGA_SUPER] ,[SAT_DIST1] ,[SAT_DIST2] ,[HARGA_DIST] ,[QTY_DIST] ,[SAT_KOLI1] ,[SAT_KOLI2] ,[QTY_KOLI] ,[STATUS_AKTIF], [TGL_PL] FROM BARANG WHERE ID='" & TxtIDBarang.Text & "'")
        LoadData.SetData({TxtKode, TxtKodePabrik, TxtNama, TxtNamaAlias1, TxtNamaAlias2, TxtNamaAlias3, CmbGroupBarang, ChkBatasMin, txtBatasMin, ChkBatasMax, TxtBatasMax, txtInnerP, txtInnerL, txtInnerT, txtOuterP, txtOuterL, txtOuterT, TxtKodeAkun, RDStatusBarang, TxtSatuanSupermarket1, TxtSatuanSupermarket2, TxtHargaSupermarket, TxtSatuanDistributor1, TxtSatuanDistributor2, TxtHargaDistributor, TxtQtyDist, TxtSatuanKoli1, TxtSatuanKoli2, TxtQtyKoli, CekStatusAktif, TglPriceList})

        LoadData.GetData("SELECT KODE,NAMA,CAST(IIF((SELECT ID_BARANG FROM LINK_BARANG_DIVISI WHERE KODE_DIVISI=KODE AND ID_BARANG='" & TxtIDBarang.Text & "') IS NULL,0,1) AS BIT) FROM DIVISI ORDER BY KODE")
        LoadData.SetDataDetail(dtDivisi, False)
        LoadData.GetData("SELECT C.KODE,C.NAMA_PROMO,A.TGL_AWAL,A.TGL_AKHIR FROM LINK_BARANG_PROMO A LEFT JOIN PROMO C ON A.KODE_PROMO=C.KODE WHERE A.ID_BARANG='" & TxtIDBarang.Text & "'")
        LoadData.SetDataDetail(dtPromo, True)

        If TxtQtyKoli.Value < 1 Then
            TxtKoliKecil.Visible = True
            LblKoliKecil.Visible = True
            TxtKoliKecil.Value = TxtQtyKoli.Value * TxtQtyDist.Value
        End If

        'LoadData.GetData("SELECT HARGA_BARU FROM VI_PRICE_LIST WHERE ID_BARANG='" & TxtIDBarang.Text & "' AND ID='UMUM' AND JENIS='Supermarket' ORDER BY TGL_PRICE DESC")
        'LoadData.SetData({TxtHargaSupermarket})
        'LoadData.GetData("SELECT HARGA_BARU, TGL_PRICE FROM VI_PRICE_LIST WHERE ID_BARANG='" & TxtIDBarang.Text & "' AND ID='UMUM' AND JENIS='Langganan' ORDER BY TGL_PRICE DESC")
        'LoadData.SetData({TxtHargaDistributor, TglPriceList})
    End Sub

    Private Sub Simpan() Handles _Toolbar1_Button1.Click
        If Empty(TxtKode) Then Exit Sub
        If Empty(TxtNama) Then Exit Sub
        Dim ceksatuan As Boolean = False

        Dim divisi As String = ""
        Try : divisi = dtDivisi.Select("[Ceklist]<>0")(0).Item(0)
        Catch : End Try
        If SelectCon.execute("SELECT KODE FROM BARANG A LEFT JOIN LINK_BARANG_DIVISI B ON A.ID=B.ID_BARANG WHERE A.KODE='" & TxtKode.Text & "' AND B.KODE_DIVISI='" & divisi & "'").Rows.Count > 1 Then
            MsgBox("Kode Barang Sudah digunakan !", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Apakah anda ingin mengubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        con.begin_exec()

        SQl = "UPDATE BARANG SET [KODE]='" & TxtKode.Text & "' ,[KODE_PABRIK]='" & TxtKodePabrik.Text & "' ,[NAMA]='" & Replace(TxtNama.Text, "'", "`") & "' ,[NAMA_ALIAS1]='" & Replace(TxtNamaAlias1.Text, "'", "`") & "' ,[NAMA_ALIAS2]='" & Replace(TxtNamaAlias2.Text, "'", "`") & "' ,[NAMA_ALIAS3]='" & Replace(TxtNamaAlias3.Text, "'", "`") & "' ,[GROUP_BARANG]='" & Replace(Split(CmbGroupBarang.SelectedItem, "-")(0), "'", "`") & "' ,[EN_BATAS_MIN]='" & ChkBatasMin.Checked & "', [BATAS_MIN]='" & Replace(CDbl(txtBatasMin.Text), ",", ".") & "',[EN_BATAS_MAX]='" & ChkBatasMax.Checked & "' ,[BATAS_MAX]='" & Replace(CDbl(TxtBatasMax.Text), ",", ".") & "' ,[IN_P]='" & Replace(CDbl(txtInnerP.Text), ",", ".") & "' ,[IN_L]='" & Replace(CDbl(txtInnerL.Text), ",", ".") & "' ,[IN_T]='" & Replace(CDbl(txtInnerT.Text), ",", ".") & "' ,[OUT_P]='" & Replace(CDbl(txtOuterP.Text), ",", ".") & "' ,[OUT_L]='" & Replace(CDbl(txtOuterL.Text), ",", ".") & "' ,[OUT_T]='" & Replace(CDbl(txtOuterT.Text), ",", ".") & "' ,[AKUN]='" & TxtKodeAkun.Text & "' ,[SAT_SUPER1]='" & Replace(TxtSatuanSupermarket1.Text, "'", "`") & "' ,[SAT_SUPER2]='" & Replace(TxtSatuanSupermarket2.Text, "'", "`") & "' ,[HARGA_SUPER]=" & Replace(CDbl(TxtHargaSupermarket.Text), ",", ".") & " ,[SAT_DIST1]='" & Replace(TxtSatuanDistributor1.Text, "'", "`") & "' ,[SAT_DIST2]='" & Replace(TxtSatuanDistributor2.Text, "'", "`") & "' ,[HARGA_DIST]=" & Replace(CDbl(TxtHargaDistributor.Text), ",", ".") & " ,[QTY_DIST]=" & Replace(CDbl(TxtQtyDist.Text), ",", ".") & " ,[SAT_KOLI1]='" & Replace(TxtSatuanKoli1.Text, "'", "`") & "' ,[SAT_KOLI2]='" & Replace(TxtSatuanKoli2.Text, "'", "`") & "' ,[QTY_KOLI]=" & Replace(CDbl(TxtQtyKoli.Text), ",", ".") & " ,[STATUS_PERSEDIAAN]='" & Replace(RDStatusBarang.EditValue, "'", "`") & "', [STATUS_AKTIF]='" & CekStatusAktif.CheckState & "', [MDUSER]='" & UserID & "',[MDTIME]=CURRENT_TIMESTAMP, [TGL_PL]='" & Format(TglPriceList.DateTime, "yyyy-MM-dd") & "' WHERE ID='" & TxtIDBarang.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_BARANG_DIVISI WHERE ID_BARANG='" & TxtIDBarang.Text & "'") = False Then GoTo keluar
            GridView2.CloseEditor()
            For i = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(i, GridView2.Columns(2)) = True Then
                    If con.exec("INSERT INTO LINK_BARANG_DIVISI VALUES ('" & TxtIDBarang.Text & "','" & GridView2.GetRowCellValue(i, GridView2.Columns(0)) & "')") = False Then GoTo keluar
                End If
            Next
            If con.exec("DELETE FROM LINK_BARANG_PROMO WHERE ID_BARANG='" & TxtIDBarang.Text & "'") = False Then GoTo keluar
            GVPromo.CloseEditor()
            For i = 0 To GVPromo.RowCount - 1
                If Len(GVPromo.GetRowCellValue(i, GVPromo.Columns(0))) > 1 Then
                    If con.exec("INSERT INTO LINK_BARANG_PROMO VALUES ('" & TxtIDBarang.Text & "','" & GVPromo.GetDataRow(i)(0) & "','" & Format(GVPromo.GetDataRow(i)(2), "yyyy-MM-dd") & "','" & Format(GVPromo.GetDataRow(i)(3), "yyyy-MM-dd") & "')") = False Then GoTo keluar
                End If
            Next
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dirubah..!!", _
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
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button4.Click
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.No Then
            Exit Sub
        End If

        If SelectCon.execute("SELECT ID_BARANG FROM ( SELECT DISTINCT ID_BARANG FROM DETAIL_TRANSFER_GUDANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PENERIMAAN_TRANSFER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_RETUR_PENJUALAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_BON_PESANAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SALDO_AWAL_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PEMBELIAN UNION ALL SELECT DISTINCT ID_BARANG FROM SALDO_STOK_BACKUP_CUTOFF UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TITIP_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_STUFFING UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_CLAIM UNION ALL SELECT DISTINCT ID_BARANG FROM ADJUSMENT_BULANAN UNION ALL SELECT DISTINCT ID_BARANG FROM SALDO_STOK UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_RETUR_PEMBELIAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TRANSFER_BARANG_RETUR UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PENERIMAAN_TRANSFER_BARANG_RETUR UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PRICE_LIST UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_NOTA UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SURAT_JALAN UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_SJ_TITIP_BARANG UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_DELIVERY_ORDER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_TTB UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_PURCHASE_ORDER UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_ADJUSMENT_STOK UNION ALL SELECT DISTINCT ID_BARANG FROM DETAIL_REFUND) Z WHERE ID_BARANG='" & TxtIDBarang.Text & "'").Rows.Count > 0 Then
            MsgBox("Barang ini sudah pernah dipakai pada transaksi !")
            Exit Sub
        End If


        con.begin_exec()

        SQl = "DELETE FROM BARANG WHERE ID='" & TxtIDBarang.Text & "'"

        If con.exec(SQl) Then
            If con.exec("DELETE FROM LINK_BARANG_DIVISI WHERE ID_BARANG='" & TxtIDBarang.Text & "'") = False Then GoTo keluar
            If con.exec("DELETE FROM LINK_BARANG_PROMO WHERE ID_BARANG='" & TxtIDBarang.Text & "'") = False Then GoTo keluar
            con.end_exec(True)
            MessageBox.Show("Data Baru telah dihapus..!!", _
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
        MessageBox.Show("Data gagal tersimpan..!!", _
                "Penyimpanan Gagal", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
    End Sub
End Class
