
Public MustInherit Class FrmProsesJurnal
    Protected dt As New DataTable
    Protected DPP As Double
    Protected Status_Edit As Boolean

    Enum JenisEnum
        Perwakilan = 1
        Pusat = 2
        Pembelian = 3
        Retur_Penjualan = 4
        Retur_Pembelian = 5
    End Enum
    Private _Jenis As JenisEnum
    Public Property Jenis As JenisEnum
        Set(value As JenisEnum)
            _Jenis = value
            If value = JenisEnum.Pusat Then
                LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            If value = JenisEnum.Perwakilan Then
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            If value = JenisEnum.Pembelian Then
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            End If
            If value = JenisEnum.Retur_Penjualan Then
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            End If
            If value = JenisEnum.Retur_Pembelian Then
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            End If
        End Set
        Get
            Return _Jenis
        End Get
    End Property

    Private Sub FrmDeliveryOrder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Apakah anda yakin ingin keluar dari menu ini ?", "Pertanyaan !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dt.Dispose()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    'Protected Sub Cetak() Handles _Toolbar1_Button6.ItemClick
    '    ShowDevexpressReport(ReportPreview.KeyReport.Penerimaan_Transfer_Barang_Retur, TxtIDTransaksi.Text)
    '    Log.Cetak(Me, TxtIDTransaksi.Text)
    'End Sub

    Private Sub FrmDeliveryOrder_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
            Case System.Windows.Forms.Keys.F8
                _Toolbar1_Button6.PerformClick()
        End Select
    End Sub

    Private Sub FrmDeliveryOrder_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        InitGrid.AddColumnGrid("DO", TypeCode.String, 60, False)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Std. Disc", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Add. Disc", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Cash Disc", TypeCode.Double, 30, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Netto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Std. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Std. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Add. Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Add. Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Cash Disc").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Cash Disc"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        SetDataTable(GridView1, e)
        GridView1.RefreshData()
    End Sub

    'DIVISI
    Private Sub TxtDivisi_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtDivisi.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA FROM DIVISI WHERE KODE='" & TxtDivisi.Text & "'", {TxtNamaDivisi})
    End Sub

    'GUDANG
    Private Sub TxtKodeGudang_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtKodeGudang.EditValueChanged
        On Error Resume Next
        SetData("SELECT NAMA_GUDANG FROM GUDANG WHERE KODE='" & TxtKodeGudang.Text & "'", {TxtNamaGudang})
    End Sub

    Private Sub _Toolbar1_Button3_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button3.ItemClick
        Me.Close()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoDSR.EditValueChanged

    End Sub

    Private Sub TglTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles TglTransaksi.EditValueChanged
        Using dturut = SelectCon.execute("select isnull(max(urutan_proses_jurnal),0) URUTAN from AR_PROSES_JURNAL a join (select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PENJUALAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PENJUALAN with(nolock))) b on b.ID_TRANSAKSI = a.ID_DSR where format(TGL_PENGAKUAN,'yyyy-MM-dd') = '" & Format(TglTransaksi.DateTime, "yyyy-MM-dd") & "'")
            If dturut.Rows.Count > 0 Then
                If dturut.Rows(0)(0) = 0 Then
                    TxtUrutan.Text = 1
                Else
                    TxtUrutan.Text = dturut.Rows(0)(0)
                End If
            Else
                Dim datebefore As DateTime = Format(DateAdd(DateInterval.Day, -1, datebefore), "yyyy-MM-dd")
                Using dturut2 = SelectCon.execute("select isnull(max(urutan_proses_jurnal),0) URUTAN from AR_PROSES_JURNAL a join (select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PENJUALAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PENJUALAN with(nolock))) b on b.ID_TRANSAKSI = a.ID_DSR where format(TGL_PENGAKUAN,'yyyy-MM-dd') <'" & Format(TglTransaksi.DateTime, "yyyy-MM-dd") & "'")
                    If dturut2.Rows.Count > 0 Then
                        TxtUrutan.Text = dturut2.Rows(0)(0) + 1
                    Else
                        TxtUrutan.Text = 1

                    End If
                End Using
            End If
        End Using
    End Sub

    Private Sub TglPengakuan_EditValueChanged(sender As Object, e As EventArgs) Handles TglPengakuan.EditValueChanged

    End Sub

    Private Sub TxtUrutan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtUrutan.EditValueChanged

    End Sub

    Private Sub _Toolbar1_Button1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _Toolbar1_Button1.ItemClick

    End Sub
End Class


Public MustInherit Class InputProsesJurnal
    Inherits FrmProsesJurnal
    Private Sub Batal() Handles _Toolbar1_Button2.ItemClick
        Clean(Me)
        dt.Clear()
        AddRow(dt)
    End Sub

    Private Sub TxtNoDSR_Click(sender As Object, e As System.EventArgs) Handles TxtNoDSR.Click
        If Jenis = JenisEnum.Pembelian Then
            TxtIdDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Pembelian_Belum_jurnal)
        ElseIf Jenis = JenisEnum.Retur_Penjualan Then
            TxtIdDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_retur_penjualan_Belum_jurnal)
        ElseIf jenis = JenisEnum.Retur_Pembelian Then
            TxtIdDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_Pembelian_Belum_Jurnal)

        Else
            TxtIdDSR.Text = SearchTransaction(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Belum_Jurnal)
        End If
    End Sub
    Private Sub TxtIdDSR_EditValueChanged(sender As Object, e As System.EventArgs) Handles TxtIdDSR.EditValueChanged
        On Error Resume Next
        If Jenis = JenisEnum.Pembelian Then
            SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_SUPPLIER, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        ElseIf Jenis = JenisEnum.Retur_Penjualan Then
            SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        ElseIf jenis = JenisEnum.Retur_Pembelian Then
            SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})
            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        Else
            SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG, PEMBAYARAN FROM AR_DSR WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran})
            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.NO_DO, A.ID_CUSTOMER, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' and isnull(a.batal,0) = 0 ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        End If
        Using dturut = SelectCon.execute("select isnull(max(urutan_proses_jurnal),0) URUTAN from AR_PROSES_JURNAL a join (select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PENJUALAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PENJUALAN with(nolock))) b on b.ID_TRANSAKSI = a.ID_DSR where format(TGL_PENGAKUAN,'MMyy') = '" & Format(TglTransaksi.DateTime, "MMyy") & "'")
            If dturut.Rows.Count > 0 Then
                If dturut.Rows(0)(0) = 0 Then
                    TxtUrutan.Text = 1
                Else
                    TxtUrutan.Text = dturut.Rows(0)(0)
                End If
            Else
                Dim datebefore As DateTime = Format(DateAdd(DateInterval.Day, -1, datebefore), "yyyy-MM-dd")
                Using dturut2 = SelectCon.execute("select isnull(max(urutan_proses_jurnal),0) URUTAN from AR_PROSES_JURNAL a join (select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_DSR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_DSR from AR_VALIDASI_DSR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PEMBELIAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PEMBELIAN with(nolock))
union all
select ID_TRANSAKSI,DIVISI,GUDANG,TGL_PENGAKUAN from AR_LAP_RETUR_PENJUALAN AD where AD.ID_TRANSAKSI in (select ID_LAP from AR_VALIDASI_LAP_RETUR_PENJUALAN with(nolock))) b on b.ID_TRANSAKSI = a.ID_DSR where format(TGL_PENGAKUAN,'yyyy-MM-dd') < '" & Format(TglTransaksi.DateTime, "yyyy-MM-dd") & "'")
                    If dturut2.Rows.Count > 0 Then
                        TxtUrutan.Text = dturut2.Rows(0)(0) + 1
                    Else
                        TxtUrutan.Text = 1

                    End If
                End Using
            End If
        End Using

    End Sub
    Private Sub TxtNoDSR_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoDSR.KeyPress
        If Jenis = JenisEnum.Pembelian Then
            If CharKeypress(TxtNoDSR, e) Then TxtIdDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Pembelian_Belum_jurnal)
        ElseIf Jenis = JenisEnum.Retur_Penjualan Then
            If CharKeypress(TxtNoDSR, e) Then TxtIdDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_retur_penjualan_Belum_jurnal)
        ElseIf jenis = JenisEnum.Retur_Pembelian Then
            If CharKeypress(TxtNoDSR, e) Then TxtIdDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Lap_Retur_Pembelian_Belum_Jurnal)
        Else

            If CharKeypress(TxtNoDSR, e) Then TxtIdDSR.Text = Search(FrmPencarianTransaksi.KeyPencarian.Transaksi_Create_DSR_Belum_Jurnal)
        End If

    End Sub

    Private Function Generate() As Boolean
        Dim urut As Short
        Using dtGenerate = SelectCon.execute("SELECT NO_PROSES FROM AR_PROSES_JURNAL WHERE NO_PROSES Like 'PJN-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-%' AND YEAR(TGL)=" & Format(TglTransaksi.EditValue, "yyyy") & " ORDER BY NO_PROSES DESC")
            If dtGenerate.Rows.Count = 0 Then
                urut = 1
            Else
                urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
            End If
            TxtNoTransaksi.Text = "PJN-" & TxtNamaDivisi.Text & "-" & TxtKodeGudang.Text & "-" & Format(urut, "000000")
        End Using

        Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'PJN','') AS INT)),0) AS ID FROM AR_PROSES_JURNAL")
            TxtIDTransaksi.Text = "PJN" & CInt(dtGenerate.Rows(0).Item(0)) + 1
        End Using
        Return True
    End Function

    Private Sub Simpan() Handles _Toolbar1_Button1.ItemClick
        If TglTransaksi.EditValue <> TglPengakuan.EditValue Then
            MsgBox("Tgl transaksi yang anda masukkan harus sama dengan tanggal pengakuan", vbInformation, "Informasi")

            Exit Sub
        End If
        Dim jenis_jurnal As String = ""
        If Empty({TglTransaksi, TxtNoDSR, TglPengakuan, TxtDivisi, TxtUrutan}) Then Exit Sub
        GridView1.CloseEditor()

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If Format(TglTransaksi.EditValue, "MMyy") <> periode Then
            MsgBox("Tgl transaksi yang anda masukkan tidak sesuai dengan periode yang masuki", vbInformation, "Informasi")
            Exit Sub
        End If

        If QuestionInput() = False Then Exit Sub
        If Not Generate() Then Exit Sub
        MessageBox.Show("Anda menggunakan nomor transaksi " & TxtNoTransaksi.Text & " !!!", "Pemberitahuan Nomor Transaksi !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({TxtIDTransaksi, TxtNoTransaksi, TglTransaksi, TxtIdDSR, TxtNoDSR, periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, TxtUrutan}, "AR_PROSES_JURNAL") = False Then Exit Sub

            Dim DIVISI As String = TxtDivisi.Text
            Dim Setup As New SetupAkun
            Dim Bagian As String = ""
            'Cek Supermarket/Distributor
            Using cekDt As DataTable = SelectCon.execute("SELECT BAGIAN FROM NOTA WITH(NOLOCK) WHERE ID_TRANSAKSI='" & dt.Rows(0).Item("Id Nota") & "'")
                If cekDt.Rows.Count > 0 Then
                    If cekDt.Rows(0).Item(0).ToString.Contains("Supermarket") Then
                        Bagian = "SP"
                    Else
                        Bagian = "DST"
                    End If
                End If
            End Using
            If Jenis = JenisEnum.Pembelian Then
                Using cekDt As DataTable = SelectCon.execute("SELECT BAGIAN FROM PEMBELIAN WITH(NOLOCK) WHERE ID_TRANSAKSI='" & dt.Rows(0).Item("Id Nota") & "'")
                    If cekDt.Rows.Count > 0 Then
                        If cekDt.Rows(0).Item(0).ToString.Contains("Supermarket") Then
                            Bagian = "SP"
                        Else
                            Bagian = "DST"
                        End If
                    End If
                End Using
                Dim jumlahnota As Double = 0
                Dim diskon As Double = 0
                Dim totalklaim As Double = 0
                Dim jumlahterima As Double = 0
                Dim notatambahanklaim = ""
                Dim notatambahandiskon = ""
                Dim notacashdiskon = ""
                Dim listnota As String = ""
                Dim ekspedisiklaim As String = ""
                dt.AcceptChanges()

                For Each dr As DataRow In dt.Rows
                    Dim nonotajual As String = ""
                    Using dtjual = SelectCon.execute("select NO_NOTA_PENJUALAN from PEMBELIAN where ID_TRANSAKSI = '" & dr.Item("Id Nota") & "' ")
                        If dtjual.Rows.Count > 0 Then
                            nonotajual = dtjual.Rows(0)(0)
                        End If
                    End Using
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(nonotajual, 6))
                    If dr.Item("Claim Bersih") > 0 Then
                        notatambahanklaim &= IIf(notatambahanklaim = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                        Using dtcari = SelectCon.execute("select b.NAMA from CLAIM a join EKSPEDISI b on a.KODE_EKSPEDISI = b.KODE where a.ID_NOTA = '" & dr.Item("Id Nota") & "'")
                            If dtcari.Rows.Count > 0 Then
                                ekspedisiklaim &= IIf(ekspedisiklaim = "", "", ", ") & dtcari.Rows(0)(0)
                            End If
                        End Using
                    End If
                    If dr.Item("Diskon") > 0 Then
                        notatambahandiskon &= IIf(notatambahandiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    jumlahnota += dr.Item("Nilai Nota / SJ")
                    diskon += dr.Item("Diskon")
                    totalklaim += dr.Item("Claim Bersih")
                    jumlahterima += dr.Item("Nilai Terima")
                Next
                Dim apersediaanpw = Akun.PERSEDIAAN_PWPB
                Dim adiskonpw = Akun.CADANGAN_PWPB
                Dim apersediaanpt = Akun.PERSEDIAAN_PUPB
                Dim adiskonpt = Akun.CADANGAN_PUPB
                Dim aklaim = Akun.KLAIM_EKSPEDISI
                Using dtcekpt = SelectCon.execute("select c.NAMA from LINK_PT_SBU A join LINK_SBU_DIVISI B ON A.KODE_SBU = b.KODE_SBU join pt c on a.kode_pt = c.kode where b.KODE_DIVISI ='" & TxtDivisi.Text & "'")
                    If dtcekpt.Rows.Count > 0 Then
                        If dtcekpt.Rows(0)(0) = "PT. MASPION" Then
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)

                            Dim AHDIPW = "DIVISI_PEMBELIAN_PERWAKILAN_" & DIVISI
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanpw), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") untuk " & TxtNamaGudang.Text, jumlahterima))
                            If totalklaim > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(aklaim), Setup.GetNamaAkun(Setup.GetAkun(aklaim)) & " " & ekspedisiklaim & " " & TxtNamaDivisi.Text & "(" & Bagian & ") " & notatambahanklaim, totalklaim))
                            End If
                            If diskon > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonpw), "DISC PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") ", diskon))
                            End If
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHDIPW), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & listnota & ")", jumlahnota))

                            ProsJurnal.Submit()
                        Else
                            Dim pt As String = ""
                            Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr_PEMBELIAN d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                                If dtcari.Rows.Count > 0 Then
                                    pt = dtcari.Rows(0)(0)
                                End If
                            End Using
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)

                            Dim AHDAPT = "DIVISI_PEMBELIAN_PUSAT_PERWAKILAN_" & DIVISI
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanpt), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")", jumlahterima))
                            If totalklaim > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(aklaim), Setup.GetNamaAkun(Setup.GetAkun(aklaim)) & " " & ekspedisiklaim & " " & TxtNamaDivisi.Text & "(" & Bagian & ") " & notatambahanklaim, totalklaim))
                            End If

                            If diskon > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonpt), "DISC PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") ", diskon))
                            End If
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHDAPT), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")" & vbTab & "(" & InisialPerusahaan & ")", jumlahnota))

                            ProsJurnal.Submit()
                        End If
                    End If
                End Using
            ElseIf Jenis = JenisEnum.Retur_Penjualan Then
                Dim jumlahbruto As Double = 0
                Dim jumlahdiskon As Double = 0
                Dim jumlahnetto As Double = 0

                For Each dr As DataRow In dt.Rows

                    jumlahbruto += dr.Item("Nilai Bruto")
                    jumlahdiskon += dr.Item("Nilai Discount")
                    jumlahnetto += dr.Item("Nilai Netto")
                Next
                Dim apiutangdagangrj = Akun.PIUTANG_DAGANG_RJ
                Dim apersediaanrj = Akun.PERSEDIAAN_RETUR_JUAL
                Dim adiskonrj = Akun.CADANGAN_RETUR_JUAL
                Dim urutanlpbl As String = ""
                Using dturutan = SelectCon.execute("select URUTAN_LAP from AR_LAP_RETUR_PENJUALAN where ID_TRANSAKSI = '" & TxtIdDSR.Text & "'")
                    If dturutan.Rows.Count > 0 Then
                        urutanlpbl = dturutan.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanrj), "LAP. PENERIMAAN BRG LANGGANAN NO. " & urutanlpbl, jumlahbruto))
                For Each dr As DataRow In dt.Rows
                    Dim noretur As String = ""

                    noretur = Strings.Right(dr("Nota"), 6)
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(apiutangdagangrj), dr("Nama") & "(" & TxtNamaDivisi.Text & " " & noretur & ")", dr("Nilai Netto")))
                Next
                If jumlahdiskon <> 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonrj), "TOTAL CAD. DISC. " & "(" & "LPBL NO. " & urutanlpbl & ")", jumlahdiskon))
                End If
                ProsJurnal.Submit()
            ElseIf Jenis = JenisEnum.Retur_Pembelian Then
                Dim jumlahbruto As Double = 0
                Dim jumlahdiskon As Double = 0
                Dim jumlahnetto As Double = 0
                Dim listnota = ""
                For Each dr As DataRow In dt.Rows
                    ' If dr.Item("Diskon") > 0 Then
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    ' End If
                    jumlahbruto += dr.Item("Nilai Bruto")
                    jumlahdiskon += dr.Item("Nilai Discount")
                    jumlahnetto += dr.Item("Nilai Netto")
                Next
                Dim apiutangreturbeliucf = Akun.PIUTANG_RETUR_BELI_UCF
                Dim apersediaanreturbelipw = Akun.PERSEDIAAN_RETUR_BELI_PW
                Dim acadangandiskonrb = Akun.CADANGAN_RETUR_BELI
                Dim apiutangreturbelipusat = Akun.PIUTANG_RETUR_BELI_PUSAT
                Dim ahutangreturbelipw = Akun.HUTANG_RETUR_BELI_PW
                Dim apersediaanreturbelipusat = Akun.PERSEDIAAN_RETUR_BELI_PUSAT
                Dim ahutangreturbeliucf = Akun.HUTANG_RETUR_BELI_UCF
                Dim urutanlpbh As String = ""
                Using dturutan = SelectCon.execute("select URUTAN_LAP from AR_LAP_RETUR_PEMBELIAN where ID_TRANSAKSI = '" & TxtIdDSR.Text & "'")
                    If dturutan.Rows.Count > 0 Then
                        urutanlpbh = dturutan.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangreturbeliucf), "UCF " & "(" & "SJ. NO." & listnota & ") ", jumlahnetto))
                If jumlahdiskon <> 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(acadangandiskonrb), "TOTAL CAD. DISC. " & "(" & "LPBH NO. " & urutanlpbh & ")", jumlahdiskon))
                End If
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(apersediaanreturbelipw), "LAP PENGELUARAN BRG HARIAN " & "NO. " & urutanlpbh, jumlahbruto))
                ProsJurnal.Submit()

                Dim prosesjurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                prosesjurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangreturbelipusat), "PNDI B.M KANTOR PUSAT SBY LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahutangreturbelipw), "HNDI B.M PERW. JKT LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalucf.Submit()

                Dim prosesjurnalpusat As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "03", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                For Each dr2 As DataRow In dt.Rows
                    Dim noretur As String = ""
                    noretur = Strings.Right(dr2("Nota"), 6)
                    prosesjurnalpusat.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanreturbelipusat), "PERSED KP SBY " & "(" & "SJ. NO. " & noretur & " LPBH NO. " & urutanlpbh & ")", dr2("Nilai Netto")))
                Next
                prosesjurnalpusat.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahutangreturbeliucf), "UCF LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalpusat.Submit()
            Else

                Dim NotaTambahanDiskon = ""
                Dim notacashdiskon = ""
                Dim notastddiskon = ""
                Dim Netto As Double = 0
                Dim CashDisc As Double = 0
                Dim StdDisc As Double = 0
                Dim AddDisc As Double = 0
                Dim listnota As String = ""

                For Each dr As DataRow In dt.Rows
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    If dr.Item("Add. Disc") > 0 Then
                        NotaTambahanDiskon &= IIf(NotaTambahanDiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    If dr.Item("Cash Disc") > 0 Then
                        notacashdiskon &= IIf(notacashdiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    If dr.Item("Std. Disc") > 0 Then
                        notastddiskon &= IIf(notastddiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    Netto += dr.Item("Netto")
                    CashDisc += dr.Item("Cash Disc")
                    StdDisc += dr.Item("Std. Disc")
                    AddDisc += dr.Item("Add. Disc")
                Next

                '' JURNAL TRANSAKSI ''

                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                Dim APiutang = Akun.PIUTANG_PERWAKILAN
                Dim ACash = Akun.CASH_PERWAKILAN
                Dim ACadangan = Akun.CADANGAN_PERWAKILAN
                Dim AUCF = Akun.UCF_PERWAKILAN
                Dim APersediaan = Akun.PERSEDIAAN_PERWAKILAN
                If Jenis = JenisEnum.Pusat Then
                    Using dtCek As DataTable = SelectCon.execute("SELECT DO.PEMBAYARAN, A.BAGIAN FROM NOTA A WITH(NOLOCK) JOIN DELIVERY_ORDER DO WITH(NOLOCK) ON A.ID_DO=DO.ID_TRANSAKSI WHERE A.NO_NOTA='" & dt.Rows(0).Item("Nota") & "' AND A.NO_DO='" & dt.Rows(0).Item("DO") & "'")
                        If dtCek.Rows(0).Item(0) = "Kontan" Then
                            APiutang = Akun.PIUTANG_PUSKON
                            ACash = Akun.CASH_PUSKON
                            ACadangan = Akun.CADANGAN_PUSKON
                            AUCF = Akun.UCF_PUSKON
                            APersediaan = Akun.PERSEDIAAN_PUSKON
                        End If
                        If dtCek.Rows(0).Item(0) = "Kredit" Then
                            APiutang = Akun.PIUTANG_PUSKRE
                            ACash = Akun.CASH_PUSKRE
                            ACadangan = Akun.CADANGAN_PUSKRE
                            AUCF = Akun.UCF_PUSKRE
                            APersediaan = Akun.PERSEDIAAN_PUSKRE
                        End If
                    End Using
                End If

                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APiutang), "PENJUALAN " & TxtNamaDivisi.Text & "(" & Bagian & ") untuk " & TxtNamaGudang.Text, Netto))
                If StdDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ACadangan), "DISC PENJUALAN " & TxtNamaDivisi.Text & "(" & Bagian & ") " & "  untuk " & TxtNamaGudang.Text & "", StdDisc))
                End If
                If AddDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(AUCF), "MSP/TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")  untuk " & TxtNamaGudang.Text & "", AddDisc))
                End If
                If CashDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ACash), "CASH DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & notacashdiskon & ")  untuk " & TxtNamaGudang.Text & "", CashDisc))
                End If
                Dim Persediaan As Double = Netto + CashDisc + StdDisc + AddDisc
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(APersediaan), "LAP. PENJUALAN MASPION TGL " & Format(TglPengakuan.DateTime, "dd/MM/yyyy"), Persediaan))
                ProsJurnal.Submit()

                '' JURNAL ADD DISKON ''
                If AddDisc > 0 Then
                    Dim APTUntukUCF = "DIVISI_UCF_" & DIVISI
                    Dim APerwakilan = Akun.PERWAKILAN
                    Dim APTUntukUCFSP = Akun.DIVISI_UCF_SUPERMARKET
                    Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon UCF", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                    If Bagian = "SP" Then
                        ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APTUntukUCFSP), Setup.GetNamaAkun(Setup.GetAkun(APTUntukUCFSP)), AddDisc))
                    ElseIf Bagian = "DST" Then
                        ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APTUntukUCF), Setup.GetNamaAkun(Setup.GetAkun(APTUntukUCF)), AddDisc))
                    End If
                    ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(APerwakilan), "KP/TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")", AddDisc))
                    ProsJurnalUCF.Submit()

                    Dim ADiskonTambah = "DISC_TAMBAH_" & Bagian
                    Dim AUCFUntukPT = "UCF_PT_" & DIVISI
                    Dim pt As String = ""
                    Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                        If dtcari.Rows.Count > 0 Then
                            pt = dtcari.Rows(0)(0)
                        End If
                    End Using
                    Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon Divisi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Baru)
                    ProsJurnalPT.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ADiskonTambah), "TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")", AddDisc))
                    ProsJurnalPT.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AUCFUntukPT), Setup.GetNamaAkun(Setup.GetAkun(AUCFUntukPT)) & " " & TxtNamaDivisi.Text & "(" & Bagian & ")", AddDisc))
                    ProsJurnalPT.Submit()
                End If
            End If


            SQLServer.EndTransaction()
            Batal()
        End Using
    End Sub
End Class

Public MustInherit Class EditProsesJurnal
    Inherits FrmProsesJurnal

    Private Sub GetData() Handles _Toolbar1_Button2.ItemClick, TxtIDTransaksi.EditValueChanged
        If Jenis = JenisEnum.Pembelian Then
            LoadData.GetData("SELECT NO_PROSES, TGL, ID_DSR, NO_DSR,URUTAN_PROSES_JURNAL FROM AR_PROSES_JURNAL WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdDSR, TxtNoDSR, TxtUrutan})
            SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_DSR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang})

            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA,  A.ID_SUPPLIER, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        ElseIf Jenis = JenisEnum.Retur_Penjualan Then
            LoadData.GetData("SELECT NO_PROSES, TGL, ID_DSR, NO_DSR,URUTAN_PROSES_JURNAL FROM AR_PROSES_JURNAL WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdDSR, TxtNoDSR, TxtUrutan})
            SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PENJUALAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran})

            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)

        ElseIf Jenis = JenisEnum.Retur_Pembelian Then
            LoadData.GetData("SELECT NO_PROSES, TGL, ID_DSR, NO_DSR,URUTAN_PROSES_JURNAL FROM AR_PROSES_JURNAL WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdDSR, TxtNoDSR, TxtUrutan})
            SetData("SELECT NO_LAP, TGL_PENGAKUAN, DIVISI, GUDANG FROM AR_LAP_RETUR_PEMBELIAN WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran})

            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.ID_CUSTOMER, B.NAMA,A.NO_TTB, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        Else

            LoadData.GetData("SELECT NO_PROSES, TGL, ID_DSR, NO_DSR,URUTAN_PROSES_JURNAL FROM AR_PROSES_JURNAL WHERE ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'")
            LoadData.SetData({TxtNoTransaksi, TglTransaksi, TxtIdDSR, TxtNoDSR, TxtUrutan})
            SetData("SELECT NO_DSR, TGL_PENGAKUAN, DIVISI, GUDANG, PEMBAYARAN FROM AR_DSR WHERE ID_TRANSAKSI='" & TxtIdDSR.Text & "'", {TxtNoDSR, TglPengakuan, TxtDivisi, TxtKodeGudang, RDPembayaran})

            LoadData.GetData("SELECT A.URUTAN, A.ID_NOTA, A.NO_NOTA, A.NO_DO, A.ID_CUSTOMER, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & TxtIdDSR.Text & "' and isnull(a.batal,0) = 0 ORDER BY A.URUTAN")
            LoadData.SetDataDetail(dt, False)
        End If

    End Sub

    Private Sub SimpanEdit() Handles _Toolbar1_Button1.ItemClick
        If TglTransaksi.EditValue <> TglPengakuan.EditValue Then
            MsgBox("Tgl transaksi yang anda masukkan harus sama dengan tanggal pengakuan", vbInformation, "Informasi")

            Exit Sub
        End If
        If Empty({TglTransaksi, TxtNoTransaksi, TxtDivisi, TxtUrutan}) Then Exit Sub

        If dt.Rows.Count = 0 Then
            MsgBox("Data Detail masih kosong!!!", MsgBoxStyle.Information, "Peringatan")
            Exit Sub
        End If

        If QuestionEdit() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header()
            If SQLServer.UpdateHeader("TGL, ID_DSR, NO_DSR,URUTAN_PROSES_JURNAL ,[MDUSER] ,[MDTIME]", {TglTransaksi, TxtIdDSR, TxtNoDSR, TxtUrutan, ToSyntax(UserID), ToSyntax("CURRENT_TIMESTAMP")}, "AR_PROSES_JURNAL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub

            Dim DIVISI As String = TxtDivisi.Text
            Dim Setup As New SetupAkun
            Dim Bagian As String = ""
            'Cek Supermarket/Distributor
            Using cekDt As DataTable = SelectCon.execute("SELECT BAGIAN FROM NOTA WITH(NOLOCK) WHERE ID_TRANSAKSI='" & dt.Rows(0).Item("Id Nota") & "'")
                If cekDt.Rows.Count > 0 Then
                    If cekDt.Rows(0).Item(0).ToString.Contains("Supermarket") Then
                        Bagian = "SP"
                    Else
                        Bagian = "DST"
                    End If
                End If
            End Using
            If Jenis = JenisEnum.Pembelian Then
                Using cekDt As DataTable = SelectCon.execute("SELECT BAGIAN FROM PEMBELIAN WITH(NOLOCK) WHERE ID_TRANSAKSI='" & dt.Rows(0).Item("Id Nota") & "'")
                    If cekDt.Rows.Count > 0 Then
                        If cekDt.Rows(0).Item(0).ToString.Contains("Supermarket") Then
                            Bagian = "SP"
                        Else
                            Bagian = "DST"
                        End If
                    End If
                End Using
                Dim jumlahnota As Double = 0
                Dim diskon As Double = 0
                Dim totalklaim As Double = 0
                Dim jumlahterima As Double = 0
                Dim notatambahanklaim = ""
                Dim notatambahandiskon = ""
                Dim listnota = ""
                Dim ekspedisiklaim As String = ""
                For Each dr As DataRow In dt.Rows
                    Dim nonotajual As String = ""
                    Using dtjual = SelectCon.execute("select NO_NOTA_PENJUALAN from PEMBELIAN where ID_TRANSAKSI = '" & dr.Item("Id Nota") & "' ")
                        If dtjual.Rows.Count > 0 Then
                            nonotajual = dtjual.Rows(0)(0)
                        End If
                    End Using
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(nonotajual, 6))
                    If dr.Item("Claim Bersih") > 0 Then
                        notatambahanklaim &= IIf(notatambahanklaim = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                        Using dtcari = SelectCon.execute("select b.NAMA from CLAIM a join EKSPEDISI b on a.KODE_EKSPEDISI = b.KODE where a.ID_NOTA = '" & dr.Item("Id Nota") & "'")
                            If dtcari.Rows.Count > 0 Then
                                ekspedisiklaim &= IIf(ekspedisiklaim = "", "", ", ") & dtcari.Rows(0)(0)
                            End If
                        End Using
                    End If
                    If dr.Item("Diskon") > 0 Then
                        notatambahandiskon &= IIf(notatambahandiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    jumlahnota += dr.Item("Nilai Nota / SJ")
                    diskon += dr.Item("Diskon")
                    totalklaim += dr.Item("Claim Bersih")
                    jumlahterima += dr.Item("Nilai Terima")
                Next
                Dim apersediaanpw = Akun.PERSEDIAAN_PWPB
                Dim adiskonpw = Akun.CADANGAN_PWPB
                Dim apersediaanpt = Akun.PERSEDIAAN_PUPB
                Dim adiskonpt = Akun.CADANGAN_PUPB
                Dim aklaim = Akun.KLAIM_EKSPEDISI
                Using dtcekpt = SelectCon.execute("select c.NAMA from LINK_PT_SBU A join LINK_SBU_DIVISI B ON A.KODE_SBU = b.KODE_SBU join pt c on a.kode_pt = c.kode where b.KODE_DIVISI ='" & TxtDivisi.Text & "'")
                    If dtcekpt.Rows.Count > 0 Then
                        If dtcekpt.Rows(0)(0) = "PT. MASPION" Then
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)

                            Dim AHDIPW = "DIVISI_PEMBELIAN_PERWAKILAN_" & DIVISI
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanpw), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") untuk " & TxtNamaGudang.Text, jumlahterima))
                            If totalklaim > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(aklaim), Setup.GetNamaAkun(Setup.GetAkun(aklaim)) & " " & ekspedisiklaim & " " & TxtNamaDivisi.Text & "(" & Bagian & ") " & notatambahanklaim, totalklaim))
                            End If

                            If diskon > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonpw), "DISC PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")", diskon))
                            End If
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHDIPW), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & listnota & ")", jumlahnota))

                            'ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHDIPW), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")" & vbTab & "(" & InisialPerusahaan & ")", jumlahnota))

                            ProsJurnal.Submit()
                        Else
                            Dim pt As String = ""
                            Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr_PEMBELIAN d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                                If dtcari.Rows.Count > 0 Then
                                    pt = dtcari.Rows(0)(0)
                                End If
                            End Using
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)

                            Dim AHDAPT = "DIVISI_PEMBELIAN_PUSAT_PERWAKILAN_" & DIVISI
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanpt), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")", jumlahterima))
                            If totalklaim > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(aklaim), Setup.GetNamaAkun(Setup.GetAkun(aklaim)) & " " & ekspedisiklaim & " " & TxtNamaDivisi.Text & "(" & Bagian & ") " & notatambahanklaim, totalklaim))
                            End If

                            If diskon > 0 Then
                                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonpt), "DISC PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")", diskon))
                            End If
                            ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AHDAPT), "PEMBELIAN " & TxtNamaDivisi.Text & "(" & Bagian & ")" & vbTab & "(" & InisialPerusahaan & ")", jumlahnota))

                            ProsJurnal.Submit()
                        End If
                    End If
                End Using

            ElseIf jenis = jenisenum.Retur_Penjualan Then
                Dim jumlahbruto As Double = 0
                Dim jumlahdiskon As Double = 0
                Dim jumlahnetto As Double = 0
                For Each dr As DataRow In dt.Rows
                    jumlahbruto += dr.Item("Nilai Bruto")
                    jumlahdiskon += dr.Item("Nilai Discount")
                    jumlahnetto += dr.Item("Nilai Netto")
                Next
                Dim apiutangdagangrj = Akun.PIUTANG_DAGANG_RJ
                Dim apersediaanrj = Akun.PERSEDIAAN_RETUR_JUAL
                Dim adiskonrj = Akun.CADANGAN_RETUR_JUAL
                Dim urutanlpbl As String = ""
                Using dturutan = SelectCon.execute("select URUTAN_LAP from AR_LAP_RETUR_PENJUALAN where ID_TRANSAKSI = '" & TxtIdDSR.Text & "'")
                    If dturutan.Rows.Count > 0 Then
                        urutanlpbl = dturutan.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanrj), "LAP. PENERIMAAN BRG LANGGANAN NO. " & urutanlpbl, jumlahbruto))
                For Each dr As DataRow In dt.Rows
                    Dim noretur As String = ""
                    noretur = Strings.Right(dr("Nota"), 6)
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(apiutangdagangrj), dr("Nama") & "(" & TxtNamaDivisi.Text & " " & noretur & ")", dr("Nilai Netto")))
                Next
                If jumlahdiskon <> 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(adiskonrj), "TOTAL CAD. DISC. " & "(" & "LPBL NO. " & urutanlpbl & ")", jumlahdiskon))
                End If
                ProsJurnal.Submit()

            ElseIf jenis = JenisEnum.Retur_Pembelian Then
                Dim jumlahbruto As Double = 0
                Dim jumlahdiskon As Double = 0
                Dim jumlahnetto As Double = 0
                Dim listnota = ""
                For Each dr As DataRow In dt.Rows
                    ' If dr.Item("Diskon") > 0 Then
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    ' End If
                    jumlahbruto += dr.Item("Nilai Bruto")
                    jumlahdiskon += dr.Item("Nilai Discount")
                    jumlahnetto += dr.Item("Nilai Netto")
                Next
                Dim apiutangreturbeliucf = Akun.PIUTANG_RETUR_BELI_UCF
                Dim apersediaanreturbelipw = Akun.PERSEDIAAN_RETUR_BELI_PW
                Dim acadangandiskonrb = Akun.CADANGAN_RETUR_BELI
                Dim apiutangreturbelipusat = Akun.PIUTANG_RETUR_BELI_PUSAT
                Dim ahutangreturbelipw = Akun.HUTANG_RETUR_BELI_PW
                Dim apersediaanreturbelipusat = Akun.PERSEDIAAN_RETUR_BELI_PUSAT
                Dim ahutangreturbeliucf = Akun.HUTANG_RETUR_BELI_UCF
                Dim urutanlpbh As String = ""
                Using dturutan = SelectCon.execute("select URUTAN_LAP from AR_LAP_RETUR_PEMBELIAN where ID_TRANSAKSI = '" & TxtIdDSR.Text & "'")
                    If dturutan.Rows.Count > 0 Then
                        urutanlpbh = dturutan.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangreturbeliucf), "UCF " & "(" & "SJ. NO." & listnota & ") ", jumlahnetto))
                If jumlahdiskon <> 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(acadangandiskonrb), "TOTAL CAD. DISC. " & "(" & "LPBH NO. " & urutanlpbh & ")", jumlahdiskon))
                End If
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(apersediaanreturbelipw), "LAP PENGELUARAN BRG HARIAN " & "NO. " & urutanlpbh, jumlahbruto))
                ProsJurnal.Submit()

                Dim prosesjurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                prosesjurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apiutangreturbelipusat), "PNDI B.M KANTOR PUSAT SBY LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalucf.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahutangreturbelipw), "HNDI B.M PERW. JKT LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalucf.Submit()

                Dim prosesjurnalpusat As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "03", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                For Each dr2 As DataRow In dt.Rows
                    Dim noretur As String = ""
                    noretur = Strings.Right(dr2("Nota"), 6)
                    prosesjurnalpusat.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(apersediaanreturbelipusat), "PERSED KP SBY " & "(" & "SJ. NO. " & noretur & " LPBH NO. " & urutanlpbh & ")", dr2("Nilai Netto")))
                Next
                prosesjurnalpusat.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(ahutangreturbeliucf), "UCF LPBH NO. " & urutanlpbh, jumlahnetto))
                prosesjurnalpusat.Submit()
            Else
                Dim NotaTambahanDiskon = ""
                Dim notacashdiskon = ""
                Dim Netto As Double = 0
                Dim CashDisc As Double = 0
                Dim StdDisc As Double = 0
                Dim AddDisc As Double = 0
                Dim listnota As String = ""
                For Each dr As DataRow In dt.Rows
                    listnota &= IIf(listnota = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))

                    If dr.Item("Add. Disc") > 0 Then
                        NotaTambahanDiskon &= IIf(NotaTambahanDiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    If dr.Item("Cash Disc") > 0 Then
                        notacashdiskon &= IIf(notacashdiskon = "", "", ", ") & CInt(Strings.Right(dr.Item("Nota"), 6))
                    End If
                    Netto += dr.Item("Netto")
                    CashDisc += dr.Item("Cash Disc")
                    StdDisc += dr.Item("Std. Disc")
                    AddDisc += dr.Item("Add. Disc")
                Next

                '' JURNAL TRANSAKSI ''
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                Dim APiutang = Akun.PIUTANG_PERWAKILAN
                Dim ACash = Akun.CASH_PERWAKILAN
                Dim ACadangan = Akun.CADANGAN_PERWAKILAN
                Dim AUCF = Akun.UCF_PERWAKILAN
                Dim APersediaan = Akun.PERSEDIAAN_PERWAKILAN
                If Jenis = JenisEnum.Pusat Then
                    Using dtCek As DataTable = SelectCon.execute("SELECT DO.PEMBAYARAN, A.BAGIAN FROM NOTA A WITH(NOLOCK) JOIN DELIVERY_ORDER DO WITH(NOLOCK) ON A.ID_DO=DO.ID_TRANSAKSI WHERE A.NO_NOTA='" & dt.Rows(0).Item("Nota") & "' AND A.NO_DO='" & dt.Rows(0).Item("DO") & "'")
                        If dtCek.Rows(0).Item(0) = "Kontan" Then
                            APiutang = Akun.PIUTANG_PUSKON
                            ACash = Akun.CASH_PUSKON
                            ACadangan = Akun.CADANGAN_PUSKON
                            AUCF = Akun.UCF_PUSKON
                            APersediaan = Akun.PERSEDIAAN_PUSKON
                        End If
                        If dtCek.Rows(0).Item(0) = "Kredit" Then
                            APiutang = Akun.PIUTANG_PUSKRE
                            ACash = Akun.CASH_PUSKRE
                            ACadangan = Akun.CADANGAN_PUSKRE
                            AUCF = Akun.UCF_PUSKRE
                            APersediaan = Akun.PERSEDIAAN_PUSKRE
                        End If
                    End Using
                End If

                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APiutang), "PENJUALAN " & TxtNamaDivisi.Text & "(" & Bagian & ") untuk " & TxtNamaGudang.Text, Netto))
                If StdDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ACadangan), "DISC PENJUALAN " & TxtNamaDivisi.Text & "(" & Bagian & ") " & "  untuk " & TxtNamaGudang.Text & "", StdDisc))
                End If
                If AddDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(AUCF), "MSP/TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")  untuk " & TxtNamaGudang.Text & "", AddDisc))
                End If
                If CashDisc > 0 Then
                    ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ACash), "CASH DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & notacashdiskon & ") untuk " & TxtNamaGudang.Text & "", CashDisc))
                End If
                Dim Persediaan As Double = Netto + CashDisc + StdDisc + AddDisc
                ProsJurnal.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(APersediaan), "LAP. PENJUALAN MASPION TGL " & Format(TglPengakuan.DateTime, "dd/MM/yyyy"), Persediaan))
                ProsJurnal.Submit()

                '' JURNAL ADD DISKON ''
                If AddDisc > 0 Then
                    Dim APTUntukUCF = "DIVISI_UCF_" & DIVISI
                    Dim APerwakilan = Akun.PERWAKILAN
                    Dim APTUntukUCFSP = Akun.DIVISI_UCF_SUPERMARKET
                    Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon UCF", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                    If Bagian = "SP" Then
                        ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APTUntukUCFSP), Setup.GetNamaAkun(Setup.GetAkun(APTUntukUCFSP)), AddDisc))
                    ElseIf Bagian = "DST" Then
                        ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(APTUntukUCF), Setup.GetNamaAkun(Setup.GetAkun(APTUntukUCF)), AddDisc))
                    End If
                    ProsJurnalUCF.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(APerwakilan), "KP/TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")", AddDisc))
                    ProsJurnalUCF.Submit()

                    Dim ADiskonTambah = "DISC_TAMBAH_" & Bagian
                    Dim AUCFUntukPT = "UCF_PT_" & DIVISI
                    Dim pt As String = ""
                    Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                        If dtcari.Rows.Count > 0 Then
                            pt = dtcari.Rows(0)(0)
                        End If
                    End Using
                    Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon Divisi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Edit)
                    ProsJurnalPT.AddJurnal(New DetailJurnal(PosisiJurnal.Debet, Setup.GetAkun(ADiskonTambah), "TAMB DISC " & TxtNamaDivisi.Text & "(" & Bagian & ") (" & NotaTambahanDiskon & ")", AddDisc))
                    'ProsJurnalPT.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AUCFUntukPT), Setup.GetNamaAkun(Setup.GetAkun(AUCFUntukPT)), AddDisc))
                    ProsJurnalPT.AddJurnal(New DetailJurnal(PosisiJurnal.Kredit, Setup.GetAkun(AUCFUntukPT), Setup.GetNamaAkun(Setup.GetAkun(AUCFUntukPT)) & " " & TxtNamaDivisi.Text & "(" & Bagian & ")", AddDisc))

                    ProsJurnalPT.Submit()
                End If
            End If


            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Hapus() Handles _Toolbar1_Button5.ItemClick
        If QuestionHapus() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.Delete("AR_PROSES_JURNAL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If Jenis = JenisEnum.Pembelian Then
                Using dtcekpt = SelectCon.execute("select c.NAMA from LINK_PT_SBU A join LINK_SBU_DIVISI B ON A.KODE_SBU = b.KODE_SBU join pt c on a.kode_pt = c.kode where b.KODE_DIVISI ='" & TxtDivisi.Text & "'")
                    If dtcekpt.Rows.Count > 0 Then
                        If dtcekpt.Rows(0)(0) = "PT. MASPION" Then
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                            ProsJurnal.Submit()
                        Else
                            Dim pt As String = ""
                            Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                                If dtcari.Rows.Count > 0 Then
                                    pt = dtcari.Rows(0)(0)
                                End If
                            End Using
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                            ProsJurnal.Submit()
                        End If
                    End If
                End Using



            ElseIf Jenis = JenisEnum.Retur_Penjualan Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()
            ElseIf Jenis = JenisEnum.Retur_Pembelian Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()
                Dim prosesjurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                prosesjurnalucf.Submit()
                Dim prosesjurnalpusat As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "03", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                prosesjurnalpusat.Submit()
            Else

                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnal.Submit()
                Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon UCF", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalUCF.Submit()
                Dim pt As String = ""
                Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                    If dtcari.Rows.Count > 0 Then
                        pt = dtcari.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon Divisi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                ProsJurnalPT.Submit()
            End If


            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub

    Private Sub Batal() Handles _Toolbar1_Button4.ItemClick
        If QuestionBatal() = False Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_PROSES_JURNAL", "ID_TRANSAKSI='" & TxtIDTransaksi.Text & "'") = False Then Exit Sub
            If Jenis = JenisEnum.Pembelian Then
                Using dtcekpt = SelectCon.execute("select c.NAMA from LINK_PT_SBU A join LINK_SBU_DIVISI B ON A.KODE_SBU = b.KODE_SBU join pt c on a.kode_pt = c.kode where b.KODE_DIVISI ='" & TxtDivisi.Text & "'")
                    If dtcekpt.Rows.Count > 0 Then
                        If dtcekpt.Rows(0)(0) = "PT. MASPION" Then
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                            ProsJurnal.Submit()
                        ElseIf Jenis = JenisEnum.Retur_Penjualan Then
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Hapus)
                            ProsJurnal.Submit()
                        Else
                            Dim pt As String = ""
                            Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                                If dtcari.Rows.Count > 0 Then
                                    pt = dtcari.Rows(0)(0)
                                End If
                            End Using
                            Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                            ProsJurnal.Submit()
                        End If
                    End If
                End Using

            ElseIf Jenis = JenisEnum.Retur_Penjualan Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()
            ElseIf Jenis = JenisEnum.Retur_Pembelian Then
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()
                Dim prosesjurnalucf As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                prosesjurnalucf.Submit()
                Dim prosesjurnalpusat As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "03", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                prosesjurnalpusat.Submit()
            Else
                Dim ProsJurnal As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Transaksi", "Perwakilan", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnal.Submit()
                Dim ProsJurnalUCF As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon UCF", "UCF", "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalUCF.Submit()
                Dim pt As String = ""
                Using dtcari = SelectCon.execute("select a.kode_pt from LINK_PT_SBU a join LINK_SBU_DIVISI b on a.KODE_SBU = b.KODE_SBU join ar_dsr d on d.divisi = b.kode_divisi where d.NO_DSR = '" & TxtNoDSR.Text & "'")
                    If dtcari.Rows.Count > 0 Then
                        pt = dtcari.Rows(0)(0)
                    End If
                End Using
                Dim ProsJurnalPT As New ProsesJurnal(ProsesJurnal.JenisJurnal.Jurnal_Memo, TglPengakuan.DateTime, "", TxtIdDSR.Text, "Jurnal Add. Diskon Divisi", pt, "", 999, TxtUrutan.Value, SQLServer, ProsesJurnal.StatusJurnal.Batal)
                ProsJurnalPT.Submit()
            End If

            SQLServer.EndTransaction()
            Me.Dispose()
        End Using
    End Sub
End Class

Public Class InputProsesJurnalPrw
    Inherits InputProsesJurnal

    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Proses Jurnal Perwakilan"
        Jenis = JenisEnum.Perwakilan
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
    End Sub
End Class

Public Class EditProsesJurnalPrw
    Inherits EditProsesJurnal

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Proses Jurnal Perwakilan"
        Jenis = JenisEnum.Perwakilan
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
End Class

Public Class inputprosesjurnalpb
    Inherits InputProsesJurnal
    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Proses Jurnal Pembelian"
        Jenis = JenisEnum.Pembelian
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False
        LayoutControlItem10.Text = "No. Lap. Pembelian"
        LayoutControlItem2.Text = "Tanggal Lap. Pembelian"

        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Nota / SJ", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Diskon", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Claim Bersih", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Terima", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Nota / SJ").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Nota / SJ"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Diskon").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Diskon"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Claim Bersih").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Claim Bersih"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Terima").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Terima"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub
End Class

Public Class EditProsesJurnalPb
    Inherits EditProsesJurnal

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        LayoutControlItem10.Text = "No. Lap. Pembelian"
        LayoutControlItem2.Text = "Tanggal Lap. Pembelian"

        Text = "Edit Proses Jurnal Pembelian"
        Jenis = JenisEnum.Pembelian
        Status_Edit = True
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        dt.Clear()
        dt.Columns.Clear()
        InitGrid.Clear()
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Nota / SJ", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Diskon", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Claim Bersih", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Terima", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Nota / SJ").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Nota / SJ"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Diskon").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Diskon"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Claim Bersih").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Claim Bersih"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Terima").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Terima"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
End Class
Public Class InputProsesJurnalPus
    Inherits InputProsesJurnal

    Private Sub InputValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Input Proses Jurnal Pusat"
        Jenis = JenisEnum.Pusat
        _Toolbar1_Button4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _Toolbar1_Button6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Status_Edit = False


    End Sub
End Class

Public Class EditProsesJurnalPus
    Inherits EditProsesJurnal

    Private Sub EditValidasiDSRPrw_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Edit Proses Jurnal Pusat"
        Jenis = JenisEnum.Pusat
        Status_Edit = True
        'HakForm("", "Retur", "Daily Sales Report", _Toolbar1_Button4, _Toolbar1_Button5, _Toolbar1_Button6)
        'TxtNoTransaksi.Properties.ReadOnly = True
        'TxtDivisi.Enabled = False
    End Sub
End Class

Public Class InputProsesJurnalReturJual
    Inherits InputProsesJurnal
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Proses Jurnal Laporan Retur Penjualan"
        Jenis = JenisEnum.Retur_Penjualan
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem10.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem2.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub


End Class
Public Class EditProsesJurnalReturJual
    Inherits EditProsesJurnal
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Proses Jurnal Laporan Retur Penjualan"
        Jenis = JenisEnum.Retur_Penjualan
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem10.Text = "No. Lap. Retur Penjualan"
        LayoutControlItem2.Text = "Tanggal Lap. Retur Penjualan"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Customer", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub
End Class

Public Class inputprosesjurnalreturbeli
    Inherits InputProsesJurnal
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Input Proses Jurnal Laporan Retur Pembelian"
        Jenis = JenisEnum.Retur_Pembelian
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem10.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem2.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub
End Class

Public Class editprosesjurnalreturbeli
    Inherits EditProsesJurnal
    Private Sub FrmValidasiDSRPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Edit Proses Jurnal Laporan Retur Pembelian"
        Jenis = JenisEnum.Retur_Pembelian
        TglTransaksi.DateTime = Format(Now.Date, "dd/MM/yyyy")
        GridView1.OptionsView.ColumnAutoWidth = False
        InitGrid.Clear()
        dt.Clear()
        dt.Columns.Clear()
        LayoutControlItem10.Text = "No. Lap. Retur Pembelian"
        LayoutControlItem2.Text = "Tanggal Lap. Retur Pembelian"
        InitGrid.AddColumnGrid("No.", TypeCode.Int32, 30, False)
        InitGrid.AddColumnGrid("Id Nota", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nota", TypeCode.String, 50, False)
        '    InitGrid.AddColumnGrid("No. Perwakilan", TypeCode.String, 50, True)
        InitGrid.AddColumnGrid("Id Supplier", TypeCode.String, 80, False,,,,, False)
        InitGrid.AddColumnGrid("Nama", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("No. TTB", TypeCode.String, 300, False)
        InitGrid.AddColumnGrid("Nilai Bruto", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Discount", TypeCode.Double, 50, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.AddColumnGrid("Nilai Netto", TypeCode.Double, 60, False, DevExpress.Utils.FormatType.Numeric, "n2")
        InitGrid.EndInit(TBDO, GridView1, dt)

        With GridView1.Columns.Item("Nilai Bruto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Bruto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Discount").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Discount"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
        With GridView1.Columns.Item("Nilai Netto").SummaryItem
            .DisplayFormat = "{0:n2}"
            .FieldName = "Nilai Netto"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With
    End Sub
End Class