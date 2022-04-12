Module ModuleAR
    Enum Akun
        PIUTANG_PERWAKILAN = 1
        CASH_PERWAKILAN = 2
        CADANGAN_PERWAKILAN = 3
        UCF_PERWAKILAN = 4
        PERSEDIAAN_PERWAKILAN = 5
        PIUTANG_PUSKON = 6
        CASH_PUSKON = 7
        CADANGAN_PUSKON = 8
        UCF_PUSKON = 9
        PERSEDIAAN_PUSKON = 10
        PIUTANG_PUSKRE = 11
        CASH_PUSKRE = 12
        CADANGAN_PUSKRE = 13
        UCF_PUSKRE = 14
        PERSEDIAAN_PUSKRE = 15

        PERWAKILAN = 16
        DISC_TAMBAH_SP = 17
        DISC_TAMBAH_DST = 18
        DIVISI_UCF_SUPERMARKET = 19
        PERSEDIAAN_PWPB = 20
        CADANGAN_PWPB = 21
        PERSEDIAAN_PUPB = 22
        CADANGAN_PUPB = 23
        KLAIM_EKSPEDISI = 24
        PERSEDIAAN_RETUR_JUAL = 25
        PIUTANG_DAGANG_RJ = 26
        CADANGAN_RETUR_JUAL = 27

        PIUTANG_RETUR_BELI_UCF = 28
        PERSEDIAAN_RETUR_BELI_PW = 29
        CADANGAN_RETUR_BELI = 30
        PIUTANG_RETUR_BELI_PUSAT = 31
        HUTANG_RETUR_BELI_PW = 32
        PERSEDIAAN_RETUR_BELI_PUSAT = 33
        HUTANG_RETUR_BELI_UCF = 34

        HUTANG_PUSAT_PRB = 35
        HUTANG_UCF_PRB = 36
        PERSEDIAAN_PUSAT_PRB = 37
        PIUTANG_RETUR_PUSAT_PRB = 38
        PIUTANG_UCF_PRB = 39
        SELISIH_HARGA_PUSAT_PRB = 40
        SELISIH_HARGA_PW_PRB = 41

        HNDI_PW_KONTAN = 42
        HNDI_UCF_PW_KONTAN = 43
        PIUTANG_DAGANG_UT_PW_KONTAN_D = 44
        PIUTANG_DAGANG_UT_PW_KONTAN_K = 45
        PIUTANG_GIRO_PW_KONTAN = 46
        PNDI_PW_KONTAN = 47
        PNDI_UCF_PW_KONTAN = 48
        PNDI_UCF_SBU_KONTAN = 49
        UM_PW_KONTAN = 50
        KAS_MASUK_KONTAN = 51
        BANK_MASUK_KONTAN = 52
        BANK_MASUK_SBU_KONTAN = 53
        KAS_MASUK_SBU_KONTAN = 54
        PIUTANG_GIRO_SBU_KONTAN = 55
        PNDI_PW_SBU_KONTAN = 56
    End Enum
    Enum _Tipe
        KasMasuk = 1
        KasKeluar = 2
        BankMasuk = 3
        BankKeluar = 4
    End Enum
    Public paramreturcustomer As String = ""
    Public paramcndncustomer As String = ""
    Public paramptcustomer As String = ""
    Public divisibank As String = ""
    Public paramnotacustomer As String = ""
    Public paramnotadivisi As String = ""
    Public paramjenisnota As String = ""
    Public paramjenislaporanjurnal As String = ""
    Enum PosisiJurnal
        Debet = 1
        Kredit = 2
    End Enum

    ''' <summary>
    ''' Class Untuk Get Setup Akun
    ''' </summary>
    Public Class SetupAkun
        Private dt As New DataTable
        Sub New()
            dt = SelectCon.execute("SELECT * FROM AR_SETUP_AKUNTANSI")
        End Sub

        Public Function GetAkun(ByVal Nama As Akun) As String
            Dim Akun As String = ""
            If dt.Rows.Count > 0 Then
                Dim myDt As DataTable = dt.Select("NAMA='" & Nama.ToString & "'").CopyToDataTable
                If myDt.Rows.Count > 0 Then
                    Akun = myDt.Rows(0).Item(1)
                End If
            End If
            Return Akun
        End Function

        Public Function GetAkun(ByVal Nama As String) As String
            Dim Akun As String = ""
            If dt.Rows.Count > 0 Then
                Dim myDt As DataTable = dt.Select("NAMA='" & Nama & "'").CopyToDataTable
                If myDt.Rows.Count > 0 Then
                    Akun = myDt.Rows(0).Item(1)
                End If
            End If
            Return Akun
        End Function

        Public Function GetNamaAkun(ByVal Kode As String) As String
            Dim Nama As String = ""
            Using dtCari As DataTable = SelectCon.execute("SELECT NAMA_PERKIRAAN FROM AR_KODE_PERKIRAAN WHERE KODE_PERKIRAAN='" & Kode & "'")
                If dtCari.Rows.Count > 0 Then
                    Nama = dtCari.Rows(0).Item(0)
                End If
            End Using
            Return Nama
        End Function
    End Class

    Public Class DetailJurnal
        Property Posisi As PosisiJurnal
        Property Kode As String
        Property Keterangan As String
        Property Nilai As Double


        Sub New(_Posisi As PosisiJurnal, _Kode As String, _Keterangan As String, _Nilai As Double)
            Posisi = _Posisi
            Kode = _Kode
            Keterangan = _Keterangan
            Nilai = _Nilai
        End Sub
    End Class
    Public Class DetailKasBank
        Property kode As String
        Property keterangan As String
        Property nilai As Double
        Sub New(_kode As String, _Keterangan As String, _Nilai As Double)
            kode = _kode
            keterangan = _Keterangan
            nilai = _Nilai
        End Sub
    End Class

    ''' <summary>
    ''' Class Untuk Insert Jurnal
    ''' </summary>
    Public Class ProsesJurnal
        Private IdTransaksi As String
        Private NoTransaksi As String
        Private LinkKasBank As String
        Private noKasBank As String
        Private idkasBank As String
        Private LinkTranskasi As String
        Private Keterangan As String
        Private JenisJurnal2 As String
        Private urutanjurnal As Double
        Private Jenis As JenisJurnal
        Private kodeKB As String
        Private JenisKB As jeniskasbank
        Private Tanggal As Date
        Private SQLServer As SQLServerTransaction
        Private Status As StatusJurnal

        Enum JenisJurnal
            Jurnal_Kas = 1
            Jurnal_Memo = 2
            Jurnal_Penyesuaian = 3
        End Enum

        Enum StatusJurnal
            Baru = 1
            Edit = 2
            Batal = 3
            Hapus = 4
        End Enum
        Enum jeniskasbank
            Kas_Masuk = 1
            Kas_Keluar = 2
            Bank_Masuk = 3
            Bank_Keluar = 4
        End Enum

        Sub New(_Jenis As JenisJurnal, _Tgl As Date, _LinkKasBank As String,
                _LinkTransaksi As String, _Keterangan As String, _JenisJurnal As String, _KodeKB As String, _JenisKb As jeniskasbank, _UrutanJurnal As Double,
                ByRef _SQLServer As SQLServerTransaction, ByVal _Status As StatusJurnal)
            Jenis = _Jenis
            JenisKB = _JenisKb
            Tanggal = _Tgl
            LinkKasBank = _LinkKasBank
            LinkTranskasi = _LinkTransaksi
            Keterangan = _Keterangan
            JenisJurnal2 = _JenisJurnal
            urutanjurnal = _UrutanJurnal
            SQLServer = _SQLServer
            Status = _Status
            kodeKB = _KodeKB
        End Sub

        Private IsiJurnal As New List(Of DetailJurnal)
        Public Sub AddJurnal(Detail As DetailJurnal)
            IsiJurnal.Add(Detail)
        End Sub

        Private IsiKB As New List(Of DetailKasBank)
        Public Sub AddKasBank(Detail As DetailKasBank)
            IsiKB.Add(Detail)
        End Sub
        Protected Sub GenerateKB()
            Dim urut As Short
            Dim fmt As String = ""
            Dim nomor As String = ""
            Dim table As String = ""
            If JenisKB = _Tipe.KasMasuk Then
                fmt = "KM"
                nomor = "NO_KAS"
                table = "AR_KAS"
            ElseIf JenisKB = _Tipe.KasKeluar Then
                fmt = "KK"
                nomor = "NO_KAS"
                table = "AR_KAS"
            ElseIf JenisKB = _Tipe.BankMasuk Then
                fmt = "BM"
                nomor = "NO_BANK"
                table = "AR_BANK"
            ElseIf JenisKB = _Tipe.BankKeluar Then
                fmt = "BK"
                nomor = "NO_BANK"
                table = "AR_BANK"
            End If
            fmt = fmt & "/" & Format(Tanggal, "MMyy") & "/"

            Using dtGenerate = SelectCon.execute("SELECT " & Nomor & " FROM " & Table & " WHERE " & Nomor & " Like '" & fmt & "%' ORDER BY " & Nomor & " DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Microsoft.VisualBasic.Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                noKasBank = fmt & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_TRANSAKSI,'" & fmt.Substring(0, 1) & "','') AS BIGINT)),0) AS ID FROM " & Table)
                idkasBank = fmt.Substring(0, 1) & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End Sub
        Private Sub Generate()
            Dim urut As Short
            Dim fmt As String = ""
            If Jenis = JenisJurnal.Jurnal_Kas Then
                fmt = "JS"
            ElseIf Jenis = JenisJurnal.Jurnal_Memo Then
                fmt = "JM"
            ElseIf Jenis = JenisJurnal.Jurnal_Penyesuaian Then
                fmt = "JP"
            End If
            fmt = fmt & "/" & Format(Tanggal, "MMyy") & "/"

            Using dtGenerate = SelectCon.execute("SELECT NO_JURNAL FROM AR_JURNAL WITH(NOLOCK) WHERE NO_JURNAL Like '" & fmt & "%' ORDER BY NO_JURNAL DESC")
                If dtGenerate.Rows.Count = 0 Then
                    urut = 1
                Else
                    urut = Right(dtGenerate.Rows(0).Item(0), 6) + 1
                End If
                NoTransaksi = fmt & Format(urut, "000000")
            End Using

            Using dtGenerate = SelectCon.execute("SELECT ISNULL(MAX(CAST(REPLACE(ID_JURNAL,'JR','') AS BIGINT)),0) AS ID FROM AR_JURNAL WITH(NOLOCK)")
                IdTransaksi = "JR" & CInt(dtGenerate.Rows(0).Item(0)) + 1
            End Using
        End Sub

        Private Function Baru() As Boolean
            Generate()
            Dim table As String = ""
            Dim tabledetail As String = ""
            Dim kodeacc As String = ""
            Dim jeniskasbank As String = ""
            ' Dim jeniskb As String = ""
            If kodeKB <> "" Then
                GenerateKB()
                If jeniskb = _Tipe.KasMasuk Then
                    table = "AR_KAS"
                    tabledetail = "AR_KAS_DETAIL"
                    jeniskasbank = "KM"
                ElseIf jeniskb = _Tipe.KasKeluar Then
                    table = "AR_KAS"
                    tabledetail = "AR_KAS_DETAIL"
                    jeniskasbank = "KK"
                ElseIf jeniskb = _Tipe.BankMasuk Then
                    table = "AR_BANK"
                    tabledetail = "AR_BANK_DETAIL"
                    jeniskasbank = "BM"
                ElseIf jeniskb = _Tipe.BankKeluar Then
                    table = "AR_BANK"
                    tabledetail = "AR_BANK_DETAIL"
                    jeniskasbank = "BK"
                End If
            End If
            'Header
            If noKasBank Is Nothing Then
                noKasBank = ""
            End If

            If SQLServer.InsertHeader({IdTransaksi, NoTransaksi, Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), Jenis.ToString.Replace("_", " "), "", LinkTranskasi, noKasBank, Keterangan, "", periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0, JenisJurnal2, urutanjurnal}, "AR_JURNAL") = False Then Return False
            If kodeKB <> "" Then
                If SQLServer.InsertHeader({idkasBank, noKasBank, Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), kodeKB, "", LinkTranskasi, Keterangan, jeniskasbank, "", periode, UserID, ToSyntax("CURRENT_TIMESTAMP"), ToSyntax("NULL"), ToSyntax("NULL"), 0}, table) = False Then Return False
            End If

            'Detail
            If kodeKB <> "" Then
                Dim i2 As Integer = 1
                For Each detail As DetailKasBank In IsiKB
                    If SQLServer.InsertHeader({idkasBank, noKasBank, detail.kode, detail.keterangan, detail.nilai, i2}, tabledetail) = False Then Return False
                    i2 = i2 + 1
                Next
            End If


            Dim i As Integer = 1
            For Each Detail As DetailJurnal In IsiJurnal
                If SQLServer.InsertHeader({IdTransaksi, NoTransaksi, Detail.Kode, Detail.Keterangan, IIf(Detail.Posisi = PosisiJurnal.Debet, Detail.Nilai, 0), IIf(Detail.Posisi = PosisiJurnal.Kredit, Detail.Nilai, 0), i}, "AR_JURNAL_DETAIL") = False Then Return False
                i = i + 1
            Next
            Return True
        End Function

        Public Function Submit() As Boolean
            If noKasBank Is Nothing Then
                noKasBank = ""
            End If
            Dim table As String = ""
            Dim tabledetail As String = ""
            Dim kodeacc As String = ""
            ' Dim jeniskb As String = ""
            Dim kolomwhere As String = ""
            If JenisKB <> 999 Then
                If JenisKB = _Tipe.KasMasuk Then
                    table = "AR_KAS"
                    tabledetail = "AR_KAS_DETAIL"
                    kolomwhere = "NO_KAS"
                ElseIf JenisKB = _Tipe.KasKeluar Then
                    table = "AR_KAS"
                    tabledetail = "AR_KAS_DETAIL"
                    kolomwhere = "NO_KAS"
                ElseIf JenisKB = _Tipe.BankMasuk Then
                    table = "AR_BANK"
                    tabledetail = "AR_BANK_DETAIL"
                    kolomwhere = "NO_BANK"
                ElseIf JenisKB = _Tipe.BankKeluar Then
                    table = "AR_BANK"
                    tabledetail = "AR_BANK_DETAIL"
                    kolomwhere = "NO_BANK"
                End If
            End If

            If Status = StatusJurnal.Baru Then
                Baru()
            End If

            If Status = StatusJurnal.Edit Then

                Using dt As DataTable = SelectCon.execute("SELECT * FROM AR_JURNAL WITH(NOLOCK) WHERE LINK_TRANSAKSI='" & LinkTranskasi & "' AND KETERANGAN_INTERNAL='" & Keterangan & "'")
                    If dt.Rows.Count > 0 Then
                        Dim DataJurnal As DataRow = dt.Rows(0)
                        IdTransaksi = DataJurnal.Item("ID_JURNAL")
                        NoTransaksi = DataJurnal.Item("NO_JURNAL")
                        noKasBank = DataJurnal.Item("LINK_KASBANK")

                        'Header
                        If SQLServer.UpdateHeader("TGL, TGL_PENGAKUAN, TGL_VALUTA, KETERANGAN_INTERNAL,URUTAN_JURNAL ,MDUSER ,MDTIME", {Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), Keterangan, urutanjurnal, UserID, ToSyntax("CURRENT_TIMESTAMP")}, "AR_JURNAL", "ID_JURNAL='" & IdTransaksi & "'") = False Then Return False

                        'Detail
                        If SQLServer.Delete("AR_JURNAL_DETAIL", "ID_JURNAL='" & IdTransaksi & "'") = False Then Return False
                        Dim i As Integer = 1
                        For Each Detail As DetailJurnal In IsiJurnal
                            If SQLServer.InsertHeader({IdTransaksi, NoTransaksi, Detail.Kode, Detail.Keterangan, IIf(Detail.Posisi = PosisiJurnal.Debet, Detail.Nilai, 0), IIf(Detail.Posisi = PosisiJurnal.Kredit, Detail.Nilai, 0), i}, "AR_JURNAL_DETAIL") = False Then Return False
                            i = i + 1
                        Next
                        'kasbank
                        If noKasBank <> "" Then

                            Using dtcari = SelectCon.execute("select * from " & table & "with(nolock) where " & kolomwhere & " = '" & noKasBank & "'")
                                If dtcari.Rows.Count > 0 Then
                                    idkasBank = dtcari.Rows(0)(0)
                                    If SQLServer.UpdateHeader("TGL, TGL_PENGAKUAN, KETERANGAN_INTERNAL,KODE_PERKIRAAN ,MDUSER ,MDTIME", {Format(Tanggal, "yyyy-MM-dd"), Format(Tanggal, "yyyy-MM-dd"), Keterangan, kodeKB, UserID, ToSyntax("CURRENT_TIMESTAMP")}, table, "ID_TRANSAKSI='" & idkasBank & "'") = False Then Return False
                                    If SQLServer.Delete(tabledetail, "ID_TRANSAKSI='" & idkasBank & "'") = False Then Return False

                                    Dim i2 As Integer = 1
                                    For Each detail As DetailKasBank In IsiKB
                                        If SQLServer.InsertHeader({idkasBank, noKasBank, detail.kode, detail.keterangan, detail.nilai, i2}, tabledetail) = False Then Return False
                                        i2 = i2 + 1
                                    Next
                                End If
                            End Using
                        End If
                    Else
                        'Baru()
                        Return False
                    End If
                End Using
            End If

            If Status = StatusJurnal.Batal Then
                Using dt As DataTable = SelectCon.execute("SELECT A.*,isnull(ISNULL(B.ID_TRANSAKSI,C.ID_TRANSAKSI),'') IDKASBANK FROM AR_JURNAL A WITH(NOLOCK) left join AR_BANK B with(Nolock) on a.LINK_KASBANK = b.NO_BANK left join AR_KAS c with(nolock) on c.NO_KAS = a.LINK_KASBANK WHERE a.LINK_TRANSAKSI='" & LinkTranskasi & "' AND a.KETERANGAN_INTERNAL='" & Keterangan & "'")
                    If dt.Rows.Count > 0 Then
                        Dim DataJurnal As DataRow = dt.Rows(0)
                        IdTransaksi = DataJurnal.Item("ID_JURNAL")
                        idkasBank = DataJurnal.Item("IDKASBANK")
                        If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, "AR_JURNAL", "ID_JURNAL='" & IdTransaksi & "'") = False Then Return False
                        If idkasBank <> "" Then
                            If SQLServer.UpdateHeader("BATAL", {ToSyntax("1")}, table, "ID_TRANSAKSI='" & idkasBank & "'") = False Then Return False
                        End If
                    End If
                End Using
            End If

            If Status = StatusJurnal.Hapus Then
                Using dt As DataTable = SelectCon.execute("SELECT A.*,isnull(ISNULL(B.ID_TRANSAKSI,C.ID_TRANSAKSI),'') IDKASBANK FROM AR_JURNAL A WITH(NOLOCK) left join AR_BANK B with(Nolock) on a.LINK_KASBANK = b.NO_BANK left join AR_KAS c with(nolock) on c.NO_KAS = a.LINK_KASBANK WHERE a.LINK_TRANSAKSI='" & LinkTranskasi & "' AND a.KETERANGAN_INTERNAL='" & Keterangan & "'")
                    If dt.Rows.Count > 0 Then
                        Dim DataJurnal As DataRow = dt.Rows(0)
                        IdTransaksi = DataJurnal.Item("ID_JURNAL")
                        idkasBank = DataJurnal.Item("IDKASBANK")
                        If SQLServer.Delete("AR_JURNAL_DETAIL", "ID_JURNAL='" & IdTransaksi & "'") = False Then Return False
                        If SQLServer.Delete("AR_JURNAL", "ID_JURNAL='" & IdTransaksi & "'") = False Then Return False
                        'kasbank
                        If idkasBank <> "" Then
                            If SQLServer.Delete(tabledetail, "ID_TRANSAKSI='" & idkasBank & "'") = False Then Return False
                            If SQLServer.Delete(table, "ID_TRANSAKSI='" & idkasBank & "'") = False Then Return False
                        End If
                    End If
                End Using
            End If

            Return True
        End Function

    End Class

End Module
