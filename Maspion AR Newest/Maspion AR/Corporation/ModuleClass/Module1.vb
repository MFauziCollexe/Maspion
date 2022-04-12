Option Strict Off
Option Explicit On

Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Columns

Public Module Module1
#Region "Declare"
    Public con As New SQLServer
    Public SelectCon As New SelectSQLServer
    Public SQl As String
    Public GroupUser As String
    Public periode As String
    Public UserID As String
    Public UserName As String
    Public passwd As String
    Public GudangID As String
    Public HakUser As String
    Public HakGudang As String
    Public HakRubahHarga As String
    Public HakJabatan As String
    Public CekStok As Boolean
    Public GudangPenjualan As String
    Public DefaultSupplier As String
    Public DefaultCustomer As String
    Public SmartEngine As New SmartDll
    Public TxtServer As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Config.ini")
    Public NamaPrinter As String
    Public ResultOfSearch As String
    Public NamaPerusahaan As String
    Public InisialPerusahaan As String
    Public AlamatPerusahaan As String
    Public KotaPerusahaan As String
    Public TlpPerusahaan As String
    Public FaxPerusahaan As String
    Public dtHakAkses As DataTable

    Public Enum EBagian
        <Description("")> None = -1
        <Description("Pembelian Langganan")> Pembelian_Langganan = 0
        <Description("Pembelian Supermarket")> Pembelian_Supermarket = 1
        <Description("Langganan Pusat")> Langganan_Pusat = 2
        <Description("Langganan Perwakilan")> Langganan_Perwakilan = 3
        <Description("Supermarket Pusat")> Supermarket_Pusat = 4
        <Description("Supermarket Perwakilan")> Supermarket_Perwakilan = 5
        <Description("Lain Pusat")> Lain_Pusat = 6
        <Description("Lain Perwakilan")> Lain_Perwakilan = 7
    End Enum

    Public Enum EJenis As Integer
        <Description("Ada Barang")> Ada_Barang = 0
        <Description("Tanpa Barang")> Tanpa_Barang = 1
    End Enum
#End Region

    Public Authorize As Boolean = False
    Public Function AuthOTP(ByVal ID As String, ByVal Nomor As String, ByVal Form As String) As Boolean
        Try
            Using dt = SelectCon.execute("SELECT EMAIL_OTP, OTP_AKTIF FROM PERUSAHAAN")
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("OTP_AKTIF") = True Then
                        Using frm As New FrmEditOTP
                            frm.IdTransaksi = ID
                            frm.NoTransaksi = Nomor
                            frm.FormName = Form
                            frm.Recipients = dt.Rows(0).Item("EMAIL_OTP")
                            frm.ShowDialog()
                            Return Authorize
                        End Using
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    'Public LoadDataToGrid As New _LoadDataToGrid
    Public Class _LoadDataToGrid
        Implements IDisposable
        Private LstConfGrid As List(Of ConfGrid)
        Private dt As DataTable
        Sub New()
            LstConfGrid = New List(Of ConfGrid)
        End Sub
        Sub Dispose() Implements IDisposable.Dispose
            LstConfGrid.Clear()
            dt.Dispose()
        End Sub

        Public Sub BeginInit(ByVal Query As String)
            LstConfGrid.Clear()
            dt = SelectCon.execute(Query)
        End Sub
        Public Sub Init(ByVal Caption As String, ByVal Width As Integer, Optional ByVal FormatType As DevExpress.Utils.FormatType = DevExpress.Utils.FormatType.None, Optional ByVal FormatString As String = Nothing, Optional ByVal Visible As Boolean = True, Optional ByVal AllowFocus As Boolean = True)
            Dim conf As New ConfGrid
            conf.Caption = Caption
            conf.Width = Width
            conf.FormatType = FormatType
            conf.FormatString = FormatString
            conf.Visible = Visible
            conf.AllowFocus = AllowFocus
            LstConfGrid.Add(conf)
        End Sub
        Public Sub EndInit(ByRef GridControl As DevExpress.XtraGrid.GridControl, ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView)
            GridControl.DataSource = Nothing
            GridControl.DataSource = dt
            Dim i As Integer = 0
            For Each e As ConfGrid In LstConfGrid
                With Gridview.Columns(i)
                    .Caption = e.Caption
                    .Width = e.Width
                    .DisplayFormat.FormatType = e.FormatType
                    .DisplayFormat.FormatString = e.FormatString
                    .Visible = e.Visible
                    .OptionsColumn.AllowFocus = e.AllowFocus
                End With
                i += 1
            Next
        End Sub
    End Class
    Public Class ConfGrid
        Property Caption As String
        Property Width As Integer
        Property FormatType As DevExpress.Utils.FormatType
        Property FormatString As String
        Property Visible As Boolean
        Property AllowFocus As Boolean
    End Class


    Public Sub buka_db()
        con.Sconnect()
    End Sub

    Public Sub tutup_db()
        con.CloseConn()
    End Sub

    Public Function QuestionInput() As Boolean
        If MsgBox("Apakah anda ingin menyimpan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.Yes Then
            Return True
        End If
        Return False
    End Function
    Public Function QuestionEdit() As Boolean
        If MsgBox("Apakah anda ingin merubah data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.Yes Then
            Return True
        End If
        Return False
    End Function
    Public Function QuestionBatal() As Boolean
        If MsgBox("Apakah anda ingin membatalkan data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.Yes Then
            Return True
        End If
        Return False
    End Function
    Public Function QuestionHapus() As Boolean
        If MsgBox("Apakah anda ingin menghapus data ini ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pertanyaan") = MsgBoxResult.Yes Then
            Return True
        End If
        Return False
    End Function

    Public Function FindItemContaining(items As IEnumerable, target As String) As Object
        For Each item As Object In items
            If item.ToString().Contains(target) Then
                Return item
            End If
        Next
        Return Nothing
    End Function

    Public Function EnumDescription(ByVal EnumConstant As [Enum]) As String
        Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        If aattr.Length > 0 Then
            Return aattr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function

    Public Function CharKeypress(ByRef Control As Control, ByRef e As KeyPressEventArgs) As Boolean
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z"), Asc("0") To Asc("9")
                e.Handled = False
                e.KeyChar = ""
                e.KeyChar = Nothing
                Return True
            Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Delete
                Control.Text = ""
                Return False
            Case Else
                Return False
        End Select
    End Function

    Public Function CharKeypress(ByRef e As KeyPressEventArgs) As Boolean
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("A") To Asc("Z"), Asc("a") To Asc("z"), Asc("0") To Asc("9"), System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Delete
                e.Handled = False
                e.KeyChar = ""
                e.KeyChar = Nothing
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function CekData(ByVal Query As String) As Boolean
        Using dt As DataTable = SelectCon.execute(Query)
            If dt.Rows.Count > 0 Then
                MsgBox("Transaksi Sudah dalam Proses Selanjutnya." & vbCrLf & "Anda Tidak Dapat Mengubah Transaksi ini !!!", MsgBoxStyle.Information)
                Return True
            End If
        End Using
        Return False
    End Function

#Region "Log"
    Public Log As New _Log
    Public Class _Log
        Private koneksi As SQLServer
        Private COMPUTERNAME As String

        Public Sub New()
            koneksi = New SQLServer
            COMPUTERNAME = " On : " & Environment.MachineName & " IP : " & System.Net.Dns.GetHostByName(Environment.MachineName).AddressList(0).ToString()
            For Each NICs As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
                COMPUTERNAME = COMPUTERNAME & " MAC : " & NICs.GetPhysicalAddress.ToString & "(" & NICs.Description & ")"
            Next
        End Sub

        Public Sub Insert(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Insert')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Load(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Load')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Edit(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Edit')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Hapus(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Hapus')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Batal(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Batal')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Cetak(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Cetak')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub

        Public Sub Closing(ByVal MyForm As Control, ByVal IDTransaksi As String)
            koneksi.begin_exec()
            If koneksi.exec("INSERT INTO LOG_AKTIVITAS VALUES ('" & UserID & "',CURRENT_TIMESTAMP,'" & MyForm.Text & ";" & MyForm.Name & COMPUTERNAME & "','" & IDTransaksi & "','Closing')") = False Then
                koneksi.end_exec(False)
                Exit Sub
            End If
            koneksi.end_exec(True)
        End Sub
    End Class
#End Region

#Region "Load Data"
    Public Sub SetData(ByVal Query As String, ByRef Controls() As Control)
        Try
            Using dt = SelectCon.execute(Query)
                If dt.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For Each MyControl In Controls
                        If IsDBNull(dt.Rows(0).Item(i)) = False Then
                            Select Case TypeName(MyControl)
                                Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit"
                                    Try
                                        MyControl.Text = dt.Rows(0).Item(i)
                                    Catch
                                    End Try
                                Case "CalcEdit"
                                    Try
                                        DirectCast(MyControl, DevExpress.XtraEditors.CalcEdit).Value = dt.Rows(0).Item(i)
                                    Catch
                                    End Try
                                Case "ComboBoxEdit"
                                    Try
                                        If dt.Rows(0).Item(i) = "" Then
                                            DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1
                                        Else
                                            DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem = FindItemContaining(DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items, dt.Rows(0).Item(i))
                                        End If
                                    Catch
                                    End Try
                                Case "CheckEdit"
                                    Try
                                        DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = dt.Rows(0).Item(i)
                                    Catch
                                    End Try
                                Case "DateEdit"
                                    Try
                                        DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = Format(CDate(dt.Rows(0).Item(i)).Date, "dd/MM/yyyy")
                                        DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                                    Catch
                                    End Try
                                Case "RadioGroup"
                                    Try
                                        DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).EditValue = dt.Rows(0).Item(i)
                                    Catch
                                    End Try
                            End Select
                        End If
                        i = i + 1
                    Next
                Else
                    For Each MyControl In Controls
                        Select Case TypeName(MyControl)
                            Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit", "CalcEdit"
                                Try
                                    MyControl.Text = Nothing
                                Catch
                                End Try
                            Case "ComboBoxEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1
                                Catch
                                End Try
                            Case "CheckEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = False
                                Catch
                                End Try
                            Case "DateEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = Format(Now.Date, "dd/MM/yyyy")
                                    DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                                Catch
                                End Try
                            Case "RadioGroup"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).SelectedIndex = -1
                                Catch
                                End Try
                        End Select
                    Next
                End If
                Try
                    dt.Clear()
                Catch
                End Try
            End Using
        Catch
        End Try
    End Sub

    Public LoadData As New _LoadData
    Public Class _LoadData
        Implements IDisposable
        Dim dt As DataTable

        Public Sub New()
            dt = New DataTable
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                dt.Dispose()
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub

        Public Sub GetData(ByVal Query As String)
            Try
                dt = SelectCon.execute(Query)
            Catch
            End Try
        End Sub
        Public Sub SetData(ByRef MyControlList() As Control)
            Dim i As Integer = 0
            If dt.Rows.Count > 0 Then
                For Each MyControl In MyControlList
                    If IsDBNull(dt.Rows(0).Item(i)) = False Then
                        Select Case TypeName(MyControl)
                            Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit"
                                Try
                                    MyControl.Text = dt.Rows(0).Item(i)
                                Catch
                                End Try
                            Case "CalcEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.CalcEdit).Value = dt.Rows(0).Item(i)
                                Catch
                                End Try
                            Case "ComboBoxEdit"
                                Try
                                    If dt.Rows(0).Item(i) = "" Then
                                        DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1
                                    Else
                                        DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem = FindItemContaining(DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items, dt.Rows(0).Item(i))
                                    End If
                                Catch
                                End Try
                            Case "CheckEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = dt.Rows(0).Item(i)
                                Catch
                                End Try
                            Case "DateEdit"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = Format(CDate(dt.Rows(0).Item(i)).Date, "dd/MM/yyyy")
                                    DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                                Catch
                                End Try
                            Case "RadioGroup"
                                Try
                                    DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).EditValue = dt.Rows(0).Item(i)
                                Catch
                                End Try
                        End Select
                    End If
                    i = i + 1
                Next
            Else
                For Each MyControl In MyControlList
                    Select Case TypeName(MyControl)
                        Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit", "CalcEdit"
                            Try
                                MyControl.Text = Nothing
                            Catch
                            End Try
                        Case "ComboBoxEdit"
                            Try
                                DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1
                            Catch
                            End Try
                        Case "CheckEdit"
                            Try
                                DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = False
                            Catch
                            End Try
                        Case "DateEdit"
                            Try
                                DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = Nothing
                                DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                            Catch
                            End Try
                        Case "RadioGroup"
                            Try
                                DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).SelectedIndex = -1
                            Catch
                            End Try
                    End Select
                Next
            End If
            Try
                dt.Clear()
            Catch
            End Try
        End Sub
        Public Sub SetDataDetail(ByRef MyDataTable As DataTable, ByVal AddNewRow As Boolean)
            Try
                MyDataTable.Clear()
            Catch
            End Try
            Try
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        AddRow(MyDataTable)
                        For j = 0 To dt.Columns.Count - 1
                            MyDataTable.Rows(i).Item(j) = dt.Rows(i).Item(j)
                        Next
                    Next
                End If
            Catch
            End Try
            If AddNewRow Then AddRow(MyDataTable)
            Try
                dt.Clear()
            Catch
            End Try
        End Sub
    End Class
#End Region

    Public Sub SetDataTable(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Try
            Select Case e.Column.ColumnType.Name
                Case TypeCode.String.ToString
                    Gridview.GetFocusedDataRow(e.Column.FieldName) = CStr(e.Value)
                Case TypeCode.Decimal.ToString
                    Gridview.GetFocusedDataRow(e.Column.FieldName) = CDec(e.Value)
                Case TypeCode.Int32.ToString
                    Gridview.GetFocusedDataRow(e.Column.FieldName) = CInt(e.Value)
                Case TypeCode.Double.ToString
                    Gridview.GetFocusedDataRow()(e.Column.FieldName) = CDbl(Replace(e.Value, ".", ","))
                Case TypeCode.Boolean.ToString
                    Gridview.GetFocusedDataRow(e.Column.FieldName) = CBool(e.Value)
                Case Else
                    Gridview.GetFocusedDataRow(e.Column.FieldName) = e.Value
            End Select
        Catch
        End Try
    End Sub

    Public Sub Clean(ByRef MyForm As Control)
        For Each MyControl In MyForm.Controls
            Select Case TypeName(MyControl)
                Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit"
                    Try : MyControl.Text = Nothing : Catch
                    End Try
                Case "CalcEdit"
                    Try : DirectCast(MyControl, CalcEdit).Value = 0
                    Catch
                    End Try
                Case "ComboBoxEdit"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1 : Catch
                    End Try
                Case "CheckEdit"
                    Try : DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked = False : Catch
                    End Try
                Case "DateEdit"
                    Try
                        DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime = Format(Now.Date, "dd/MM/yyyy")
                        DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).Refresh()
                    Catch
                    End Try
                Case "RadioGroup"
                    Try
                        DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).SelectedIndex = -1
                    Catch
                    End Try
                Case "XtraScrollableControl", "SplitContainerControl", "GroupBox", "SplitGroupPanel", "LayoutControl"
                    Clean(DirectCast(MyControl, Control))
            End Select
            If TryCast(MyControl, Control).HasChildren Then
                Clean(MyControl)
            End If
        Next
    End Sub


#Region "==========================================Hak Akses======================================"
    Public Sub HakMenu(ByVal GroupMenu As String, ByVal Menu As String, ByVal ItemName As String, ByRef BtnBaru As Object, ByRef BtnEdit As Object(), ByRef BtnCetak As Object)
        Try
            Dim Hak As DataRow =
                dtHakAkses.Select("GROUP_HEADER='" & GroupMenu & "' AND HEADER='" & Menu & "' AND ITEM='" & ItemName & "' ")(0)
            If Hak.Item("LIHAT") Then
                If Hak.Item("BARU") = False Then
                    TryCast(BtnBaru, BarButtonItem).Visibility = BarItemVisibility.Never
                    TryCast(BtnBaru, BarButtonItem).Enabled = False
                End If
                If Hak.Item("EDIT") = False Then
                    For Each c As Object In BtnEdit
                        TryCast(c, BarButtonItem).Visibility = BarItemVisibility.Never
                        TryCast(c, BarButtonItem).Enabled = False
                    Next
                End If
                If Hak.Item("CETAK") = False Then
                    TryCast(BtnCetak, BarButtonItem).Visibility = BarItemVisibility.Never
                    TryCast(BtnCetak, BarButtonItem).Enabled = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Hak Akses Untuk " & Nama & " Pada User ini Belum di-Setting !!" & vbCrLf & _
            '       "Menu ini Akan ditampilkan.")
        End Try
    End Sub
    Public Sub HakForm(ByVal GroupMenu As String, ByVal Menu As String, ByVal ItemName As String, ByRef BtnBatal As Object, ByRef BtnHapus As Object, ByRef BtnCetak As Object)
        Try
            Dim Hak As DataRow =
                dtHakAkses.Select("GROUP_HEADER='" & GroupMenu & "' AND HEADER='" & Menu & "' AND ITEM='" & ItemName & "' ")(0)
            If Hak.Item("LIHAT") Then
                If Hak.Item("BATAL") = False Then
                    If TypeOf BtnBatal Is CheckEdit Then : TryCast(BtnBatal, CheckEdit).Enabled = False
                    ElseIf TypeOf BtnBatal Is BarButtonItem Then
                        TryCast(BtnBatal, BarButtonItem).Visibility = BarItemVisibility.Never
                        TryCast(BtnBatal, BarButtonItem).Enabled = False
                    End If
                End If
                If Hak.Item("HAPUS") = False Then
                    If TypeOf BtnHapus Is ToolStripButton Then
                        TryCast(BtnHapus, ToolStripButton).Visible = False
                        TryCast(BtnHapus, ToolStripButton).Enabled = False
                    ElseIf TypeOf BtnHapus Is BarButtonItem Then
                        TryCast(BtnHapus, BarButtonItem).Visibility = BarItemVisibility.Never
                        TryCast(BtnHapus, BarButtonItem).Enabled = False
                    End If
                ElseIf Hak.Item("CETAK") = False Then
                    If TypeOf BtnCetak Is ToolStripButton Then
                        TryCast(BtnCetak, ToolStripButton).Visible = False
                        TryCast(BtnCetak, ToolStripButton).Enabled = False
                    ElseIf TypeOf BtnCetak Is BarButtonItem Then
                        TryCast(BtnCetak, BarButtonItem).Visibility = BarItemVisibility.Never
                        TryCast(BtnCetak, BarButtonItem).Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("Hak Akses Untuk " & Nama & " Pada User ini Belum di-Setting !!" & vbCrLf & _
            '       "Menu ini Akan ditampilkan.")
        End Try
    End Sub
    Public Function GetAksesBaru(ByVal GroupMenu As String, ByVal Menu As String, ByVal ItemName As String) As Boolean
        Try
            Dim Hak As DataRow = dtHakAkses.Select("GROUP_HEADER='" & GroupMenu & "' AND HEADER='" & Menu & "' AND ITEM='" & ItemName & "' ")(0)
            Return Hak.Item("BARU")
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
#End Region

    Public Sub EnterNewRow(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByRef DataTable As DataTable, ByVal FocusedColumn As String, ByVal PrimaryColumn1 As String, Optional ByVal PrimaryColumn2 As String = Nothing, Optional ByVal SetFocusColumn As String = Nothing)
        If Gridview.FocusedRowHandle = Gridview.RowCount - 1 Then
            If Gridview.FocusedColumn.FieldName = FocusedColumn Then
                If Not IsDBNull(Gridview.GetFocusedRowCellValue(Gridview.Columns(PrimaryColumn1))) Then
                    If Len(Gridview.GetFocusedRowCellValue(Gridview.Columns(PrimaryColumn1))) > 0 Then
                        If PrimaryColumn2 <> Nothing Then
                            If Not IsDBNull(Gridview.GetFocusedRowCellValue(Gridview.Columns(PrimaryColumn1))) Then
                                If Len(Gridview.GetFocusedRowCellValue(Gridview.Columns(PrimaryColumn2))) > 0 Then
                                    AddRow(DataTable)
                                End If
                            End If
                        Else
                            AddRow(DataTable)
                        End If
                    End If
                    If SetFocusColumn <> Nothing Then Gridview.FocusedColumn = Gridview.Columns(SetFocusColumn)
                End If
            End If
        End If
    End Sub

    Public Sub AddRow(ByRef Data As DataTable)
        Dim dr As DataRow = Data.NewRow
        For i = 0 To Data.Columns.Count - 1
            Select Case Data.Columns(i).DataType
                Case System.Type.GetType("System.String")
                    dr(i) = ""
                Case System.Type.GetType("System.Decimal"), System.Type.GetType("System.Single")
                    dr(i) = 0
                Case System.Type.GetType("System.Int32")
                    dr(i) = Data.Rows.Count + 1
                Case System.Type.GetType("System.Double")
                    dr(i) = 0
                Case System.Type.GetType("System.Boolean")
                    dr(i) = False
                Case System.Type.GetType("System.DateTime")
                    dr(i) = Now.Date
                Case Else
                    dr(i) = Nothing
            End Select
        Next
        Data.Rows.Add(dr)
    End Sub

    Public Function Empty(ByRef Controls As Control()) As Boolean
        For Each Control In Controls
            Select Case TypeName(Control)
                Case "TextEdit", "ButtonEdit"
                    If Control.Text = "" Then
                        MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!")
                        Control.Focus()
                        AlertEmpty(Control)
                        Return True
                    End If
                Case "DateEdit"
                    If DirectCast(Control, DevExpress.XtraEditors.DateEdit).DateTime = Nothing Then
                        MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!")
                        Control.Focus()
                        AlertEmpty(Control)
                        Return True
                    End If
                Case "RadioGroup"
                    If DirectCast(Control, DevExpress.XtraEditors.RadioGroup).SelectedIndex = -1 Then
                        MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!")
                        Control.Focus()
                        AlertEmpty(Control)
                        Return True
                    End If
                Case Else
                    If Control.Text = "" Then
                        MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!")
                        Control.Focus()
                        AlertEmpty(Control)
                        Return True
                    End If
            End Select
        Next
        Return False
    End Function

    Sub AlertEmpty(ctl As Control)
        Dim count As Integer = 0
        Dim tmr As New Timer
        Dim OriColor As Color = ctl.BackColor
        tmr.Interval = 200
        AddHandler tmr.Tick,
            Sub(s As System.Object, ee As System.EventArgs)
                count += 1
                Select Case count
                    Case 1 : ctl.BackColor = Color.Yellow
                    Case 2 : ctl.BackColor = OriColor
                    Case 3 : ctl.BackColor = Color.Yellow
                    Case 4 : ctl.BackColor = OriColor
                    Case 5 : ctl.BackColor = Color.Yellow
                    Case 6 : ctl.BackColor = OriColor
                    Case 7 : ctl.BackColor = Color.Yellow
                    Case 8 : ctl.BackColor = OriColor
                        tmr.Dispose()
                End Select
            End Sub
        tmr.Start()
        ctl.Focus()
    End Sub

    Public Function Empty(ByRef Control As Control, ByVal CaptionCtl As Object)
        Dim caption As String = ""
        If CaptionCtl IsNot Nothing Then caption = CaptionCtl.Text
        Select Case TypeName(Control)
            Case "TexEdit", "ButtonEdit"
                If Control.Text = "" Then
                    MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!" & vbCrLf &
                           "Data : " & caption, MsgBoxStyle.Information)
                    Control.Focus()
                    AlertEmpty(Control)
                    Return True
                Else
                    Return False
                End If
            Case "DateEdit"
                If DirectCast(Control, DevExpress.XtraEditors.DateEdit).DateTime = Nothing Then
                    MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!" & vbCrLf &
                           "Data : " & caption, MsgBoxStyle.Information)
                    Control.Focus()
                    AlertEmpty(Control)
                    Return True
                Else
                    Return False
                End If
            Case "RadioGroup"
                If DirectCast(Control, DevExpress.XtraEditors.RadioGroup).SelectedIndex = -1 Then
                    MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!" & vbCrLf &
                           "Data : " & caption, MsgBoxStyle.Information)
                    Control.Focus()
                    AlertEmpty(Control)
                    Return True
                End If
            Case Else
                If Control.Text = "" Then
                    MsgBox("Masih Ada Data yang Kosong, Silahkan Cek Kembali !!" & vbCrLf &
                           "Data : " & caption, MsgBoxStyle.Information)
                    Control.Focus()
                    AlertEmpty(Control)
                    Return True
                Else
                    Return False
                End If
        End Select
        Return False
    End Function
    Public Function Empty(ByRef Control As Control) As Boolean
        Return Empty(Control, Nothing)
    End Function

#Region "Set Manual Gridview"
    Public Sub InitDataTable(ByRef MyDataTable As DataTable, ByVal NameOfColumn0 As String, ByVal DataTypeOfColumn0 As System.TypeCode, Optional ByVal NameOfColumn1 As String = Nothing, Optional ByVal DataTypeOfColumn1 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn2 As String = Nothing, Optional ByVal DataTypeOfColumn2 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn3 As String = Nothing, Optional ByVal DataTypeOfColumn3 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn4 As String = Nothing, Optional ByVal DataTypeOfColumn4 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn5 As String = Nothing, Optional ByVal DataTypeOfColumn5 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn6 As String = Nothing, Optional ByVal DataTypeOfColumn6 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn7 As String = Nothing, Optional ByVal DataTypeOfColumn7 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn8 As String = Nothing, Optional ByVal DataTypeOfColumn8 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn9 As String = Nothing, Optional ByVal DataTypeOfColumn9 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn10 As String = Nothing, Optional ByVal DataTypeOfColumn10 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn11 As String = Nothing, Optional ByVal DataTypeOfColumn11 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn12 As String = Nothing, Optional ByVal DataTypeOfColumn12 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn13 As String = Nothing, Optional ByVal DataTypeOfColumn13 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn14 As String = Nothing, Optional ByVal DataTypeOfColumn14 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn15 As String = Nothing, Optional ByVal DataTypeOfColumn15 As System.TypeCode = TypeCode.DBNull, Optional ByVal NameOfColumn16 As String = Nothing, Optional ByVal DataTypeOfColumn16 As System.TypeCode = TypeCode.DBNull)
        MyDataTable = New DataTable
        MyDataTable.BeginInit()
        If NameOfColumn0 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn0, System.Type.GetType("System." & DataTypeOfColumn0.ToString))
        If NameOfColumn1 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn1, System.Type.GetType("System." & DataTypeOfColumn1.ToString))
        If NameOfColumn2 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn2, System.Type.GetType("System." & DataTypeOfColumn2.ToString))
        If NameOfColumn3 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn3, System.Type.GetType("System." & DataTypeOfColumn3.ToString))
        If NameOfColumn4 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn4, System.Type.GetType("System." & DataTypeOfColumn4.ToString))
        If NameOfColumn5 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn5, System.Type.GetType("System." & DataTypeOfColumn5.ToString))
        If NameOfColumn6 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn6, System.Type.GetType("System." & DataTypeOfColumn6.ToString))
        If NameOfColumn7 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn7, System.Type.GetType("System." & DataTypeOfColumn7.ToString))
        If NameOfColumn8 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn8, System.Type.GetType("System." & DataTypeOfColumn8.ToString))
        If NameOfColumn9 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn9, System.Type.GetType("System." & DataTypeOfColumn9.ToString))
        If NameOfColumn10 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn10, System.Type.GetType("System." & DataTypeOfColumn10.ToString))
        If NameOfColumn11 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn11, System.Type.GetType("System." & DataTypeOfColumn11.ToString))
        If NameOfColumn12 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn12, System.Type.GetType("System." & DataTypeOfColumn12.ToString))
        If NameOfColumn13 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn13, System.Type.GetType("System." & DataTypeOfColumn13.ToString))
        If NameOfColumn14 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn14, System.Type.GetType("System." & DataTypeOfColumn14.ToString))
        If NameOfColumn15 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn15, System.Type.GetType("System." & DataTypeOfColumn15.ToString))
        If NameOfColumn16 IsNot Nothing Then AddColumn(MyDataTable, NameOfColumn16, System.Type.GetType("System." & DataTypeOfColumn16.ToString))
        MyDataTable.EndInit()
    End Sub

    Public Sub InitGridData(ByRef GridControl As DevExpress.XtraGrid.GridControl, ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Data As DataTable)
        GridControl.DataSource = Data
        GridControl.DefaultView.PopulateColumns()
        Gridview.OptionsNavigation.EnterMoveNextColumn = True
        Gridview.OptionsNavigation.AutoFocusNewRow = True
        Gridview.BestFitColumns()
    End Sub

    Public Sub SetGridviewColumn(ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Column As String, Optional ByVal Width As Integer = 100, Optional ByVal AllowFocus As Boolean = True, Optional ByVal FormatType As DevExpress.Utils.FormatType = DevExpress.Utils.FormatType.None, Optional ByVal FormatString As String = Nothing, Optional ByVal AllowSort As DevExpress.Utils.DefaultBoolean = DevExpress.Utils.DefaultBoolean.False)
        Gridview.Columns(Column).Width = Width
        Gridview.Columns(Column).OptionsColumn.AllowFocus = AllowFocus
        Gridview.Columns(Column).DisplayFormat.FormatType = FormatType
        Gridview.Columns(Column).DisplayFormat.FormatString = FormatString
        Gridview.Columns(Column).OptionsColumn.AllowSort = AllowSort
    End Sub
#End Region
    '===================Begin Function Add Column Into DataTable================================
    Public Sub AddColumn(ByRef data As DataTable, ByVal name As String, ByVal type As System.Type, Optional ByVal ro As Boolean = False)
        Dim col As DataColumn
        col = New DataColumn(name, type)
        col.Caption = name
        col.ReadOnly = ro
        data.Columns.Add(col)
    End Sub

#Region "Set Automatic Gridview"
    Public InitGrid As New InitDataGridview
    Public InitGrid2 As New InitDataGridview
    Public Class InitDataGridview
        Private LstPropertyDrid As List(Of Property_Gridview)
        Sub New()
            LstPropertyDrid = New List(Of Property_Gridview)
        End Sub
        Sub Clear()
            LstPropertyDrid.Clear()
        End Sub
        Public Sub AddColumnGrid(ByVal ColumnName As String, ByVal DataType As System.TypeCode, Optional ByVal Width As Integer = 100, Optional ByVal AllowFocus As Boolean = True, Optional ByVal FormatType As DevExpress.Utils.FormatType = DevExpress.Utils.FormatType.None, Optional ByVal FormatString As String = Nothing, Optional ByVal AllowSort As DevExpress.Utils.DefaultBoolean = DevExpress.Utils.DefaultBoolean.False, Optional ByVal Editor As Object = Nothing, Optional ByVal Visible As Boolean = True)
            Dim MyPropertyGrid As New Property_Gridview
            With MyPropertyGrid
                .ColumnName = ColumnName
                .DataType = DataType
                .Width = Width
                .AllowFocus = AllowFocus
                .FormatType = FormatType
                .FormatString = FormatString
                .AllowSort = AllowSort
                .Editor = Editor
                .Visible = Visible
            End With
            LstPropertyDrid.Add(MyPropertyGrid)
        End Sub

        Public Sub EndInit(ByRef GridControl As DevExpress.XtraGrid.GridControl, ByRef Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Data As DataTable)
            Data.BeginInit()
            For Each Prt As Property_Gridview In LstPropertyDrid
                AddColumn(Data, Prt.ColumnName, System.Type.GetType("System." & Prt.DataType.ToString))
            Next
            Data.EndInit()
            GridControl.DataSource = Data
            GridControl.DefaultView.PopulateColumns()
            Gridview.OptionsNavigation.EnterMoveNextColumn = True
            Gridview.OptionsNavigation.AutoFocusNewRow = True
            Gridview.OptionsView.ColumnAutoWidth = True
            Gridview.BestFitColumns()
            For Each Prt As Property_Gridview In LstPropertyDrid
                Gridview.Columns(Prt.ColumnName).Width = Prt.Width
                Gridview.Columns(Prt.ColumnName).OptionsColumn.AllowFocus = Prt.AllowFocus
                Gridview.Columns(Prt.ColumnName).DisplayFormat.FormatType = Prt.FormatType
                If Prt.FormatString IsNot Nothing Then Gridview.Columns(Prt.ColumnName).DisplayFormat.FormatString = Prt.FormatString
                Gridview.Columns(Prt.ColumnName).OptionsColumn.AllowSort = Prt.AllowSort
                If Prt.Editor IsNot Nothing Then Gridview.Columns(Prt.ColumnName).ColumnEdit = Prt.Editor
                Gridview.Columns(Prt.ColumnName).Visible = Prt.Visible
            Next
            LstPropertyDrid.Clear()
            Gridview.BestFitColumns()
            For Each col As GridColumn In Gridview.Columns
                col.BestFit()
            Next
        End Sub
    End Class

#Region "HelperGrid"
    Public Class Property_Gridview
        Property ColumnName As String
        Property DataType As System.TypeCode
        Property Width As Integer
        Property AllowFocus As Boolean
        Property FormatType As DevExpress.Utils.FormatType
        Property FormatString As String
        Property AllowSort As DevExpress.Utils.DefaultBoolean
        Property Editor As Object
        Property Visible As Boolean
    End Class
#End Region
#End Region

    '=====================Begin Function SmartSearch (Searching Like Google)================================
    Public Function SmartSearch(ByVal KeyWord As String, ByVal FieldOnDatabase As String) As String
        Dim Word() As String
        Word = Split(KeyWord, " ")
        Dim Field As String = " " & FieldOnDatabase & " "
        For i = Word.GetLowerBound(0) To Word.GetUpperBound(0)
            Field = Field & "LIKE '%" & Word(i) & "%'"
            If i < Word.GetUpperBound(0) Then
                Field = Field & " AND " & FieldOnDatabase & " "
            End If
        Next
        Return Field
    End Function
    '=====================End Function SmartSearch (Searching Like Google)================================

    '=====================Begin Function Search (Searching Form)==========================================
    Public Function Search(ByVal Key As FrmPencarian.KeyPencarian, Optional ByVal KeyWord As String = Nothing, Optional ByVal SetButton1 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal SetButton2 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal SetButton3 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal Kode As String = Nothing, Optional ByVal Supplier As String = Nothing, Optional ByVal Gudang As String = Nothing, Optional ByVal Customer As String = Nothing, Optional ByVal Numb As Double = Nothing, Optional ByVal Tanggal As DateTime = Nothing, Optional ByVal Bagian As EBagian = EBagian.None, Optional ByVal Divisi As String = Nothing) As String
        Try
            Using FrmSearch As New FrmPencarian
                FrmSearch.SetButton(FrmSearch.Button1, SetButton1)
                FrmSearch.SetButton(FrmSearch.Button2, SetButton2)
                FrmSearch.SetButton(FrmSearch.Button3, SetButton3)
                FrmSearch.ParamKode = Kode
                FrmSearch.ParamSupplier = Supplier
                FrmSearch.ParamGudang = Gudang
                FrmSearch.ParamCustomer = Customer
                FrmSearch.ParamNumber = Numb
                FrmSearch.ParamDate = Tanggal
                FrmSearch.Bagian = Bagian
                FrmSearch.ParamDivisi = Divisi
                FrmSearch.Key = Key
                FrmSearch.TxtCari.Text = Replace(KeyWord, "'", "`")
                FrmSearch.ShowDialog()
            End Using
            Return ResultOfSearch
        Catch ex As Exception
            MsgBox(Err.Description)
            Return ""
        End Try
    End Function

    Public Function Search2(ByVal Key As FrmPencarian.KeyPencarian, Optional ByVal KeyWord As String = Nothing, Optional ByVal SetButton1 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal SetButton2 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal SetButton3 As FrmPencarian.TypeButton = FrmPencarian.TypeButton.None, Optional ByVal Kode As String = Nothing, Optional ByVal Supplier As String = Nothing, Optional ByVal Gudang As String = Nothing, Optional ByVal Customer As String = Nothing, Optional ByVal Numb As Double = Nothing, Optional ByVal Tanggal As DateTime = Nothing, Optional ByVal Bagian As EBagian = EBagian.None, Optional ByVal Divisi As String = Nothing) As String
        Try
            Using FrmSearch As New FrmPencarian2
                FrmSearch.SetButton(FrmSearch.Button1, SetButton1)
                FrmSearch.SetButton(FrmSearch.Button2, SetButton2)
                FrmSearch.SetButton(FrmSearch.Button3, SetButton3)
                FrmSearch.ParamKode = Kode
                FrmSearch.ParamSupplier = Supplier
                FrmSearch.ParamGudang = Gudang
                FrmSearch.ParamCustomer = Customer
                FrmSearch.ParamNumber = Numb
                FrmSearch.ParamDate = Tanggal
                FrmSearch.Bagian = Bagian
                FrmSearch.ParamDivisi = Divisi
                FrmSearch.Key = Key
                FrmSearch.TxtCari.Text = Replace(KeyWord, "'", "`")
                FrmSearch.ShowDialog()
            End Using
            Return ResultOfSearch
        Catch ex As Exception
            MsgBox(Err.Description)
            Return ""
        End Try
    End Function


    Public Function SearchTransaction(ByVal Key As FrmPencarianTransaksi.KeyPencarian, Optional ByVal KeyWord As String = Nothing, Optional ByVal Kode As String = Nothing, Optional ByVal Supplier As String = Nothing, Optional ByVal Gudang As String = Nothing, Optional ByVal Customer As String = Nothing, Optional ByVal Numb As Double = Nothing, Optional ByVal Tanggal As DateTime = Nothing, Optional ByVal Bagian As EBagian = EBagian.None) As String
        Try
            Using FrmSearch As New FrmPencarianTransaksi
                FrmSearch.ParamKode = Kode
                FrmSearch.ParamSupplier = Supplier
                FrmSearch.ParamGudang = Gudang
                FrmSearch.ParamCustomer = Customer
                FrmSearch.ParamNumber = Numb
                FrmSearch.ParamDate = Tanggal
                FrmSearch.Key = Key
                FrmSearch.Bagian = Bagian
                FrmSearch.TxtCari.Text = Replace(KeyWord, "'", "`")
                FrmSearch.ShowDialog()
            End Using
            Return ResultOfSearch
        Catch ex As Exception
            MsgBox(Err.Description)
            Return Nothing
        End Try
    End Function
    '=====================End Function Search (Searching Form)==========================================

    Public Sub ShowDevexpressReport(ByVal key As ReportPreview.KeyReport, Optional ByVal NoTransaksi As String = Nothing, Optional ByVal TglAwal As Date = Nothing, Optional ByVal TglAkhir As Date = Nothing, Optional ByVal KodeItem As String = Nothing, Optional ByVal KodeGudang As String = Nothing, Optional ByVal GrupItem As String = Nothing, Optional ByVal Keterangan As String = Nothing, Optional ByVal Filter As String = Nothing, Optional ByVal MultiNo As List(Of String) = Nothing)
        Using frm As New ReportPreview
            frm.Key = key
            frm.NoTransaksi = NoTransaksi
            frm.TglAwal = TglAwal
            frm.TglAkhir = TglAkhir
            frm.KodeItem = KodeItem
            frm.Gudang = KodeGudang
            frm.GrupItem = GrupItem
            frm.Keterangan = Keterangan
            frm.Filter = Filter
            frm.MultiNo = MultiNo
            frm.ShowDialog()
        End Using
    End Sub

    <System.Runtime.InteropServices.ProgId("Smart_NET.Smart")>
    Public Class SmartDll
        Public Function encrypt(ByVal wd As String) As String
            Dim Temp As String
            Dim i As Short

            wd = wd & "cfghaijk"
            Temp = ""
            For i = 1 To Len(wd)
                Temp = Temp & Chr(Asc(Mid(wd, i, 1)) + 2)
            Next
            encrypt = Temp
        End Function

        Public Function decrypt(ByVal wd As String) As String
            Dim Temp As String
            Dim i As Short
            Dim n As Integer

            n = Len(wd) - 8
            wd = Left(wd, n)

            Temp = ""
            For i = 1 To Len(wd)
                Temp = Temp & Chr(Asc(Mid(wd, i, 1)) - 2)
            Next
            decrypt = Temp
        End Function

        Public Function decphp(ByVal wd As String) As String
            Dim Temp As String
            Dim i As Short
            Dim n As Integer

            n = Len(wd) - 8
            wd = Left(wd, n)

            Temp = ""
            For i = 1 To Len(wd)
                Select Case Mid(wd, i, 1)
                    Case "a" To "z", "A" To "Z", "0" To "9"
                        Temp = Temp & Chr(Asc(Mid(wd, i, 1)) - 2)
                    Case "{"
                        Temp = Temp & "y"
                    Case Else
                        Temp = Temp & Mid(wd, i, 1)
                End Select
            Next
            Temp = Replace(Temp, "\""", """")
            decphp = Temp
        End Function

        Public Function encphp(ByVal wd As String) As String
            Dim Temp As String
            Dim i As Short
            wd = Replace(wd, "<?", "")
            wd = Replace(wd, "?>", "")
            wd = wd & "cfghaijk"
            Temp = ""
            For i = 1 To Len(wd)
                Select Case Mid(wd, i, 1)
                    Case "a" To "z", "A" To "Z", "0" To "9"
                        Temp = Temp & Chr(Asc(Mid(wd, i, 1)) + 2)
                    Case Else
                        Temp = Temp & Mid(wd, i, 1)
                End Select
            Next
            encphp = Temp
        End Function
    End Class

    Public Function RoundDown(ByVal number As Decimal, ByVal digit As Integer) As Decimal
        Dim Pembagi As String = "1"
        For i = 1 To digit
            Pembagi = Pembagi & "0"
        Next
        Dim PembagiDigit As Integer = CInt(Pembagi)
        Return (Math.Truncate(number * PembagiDigit) / PembagiDigit)
    End Function

    Public Function Terbilang(ByVal x As Double) As String
        Dim tampung As Double
        Dim teks As String
        Dim bagian As String
        Dim i As Integer
        Dim tanda As Boolean

        Dim letak(5)
        letak(1) = "Ribu "
        letak(2) = "Juta "
        letak(3) = "Milyar "
        letak(4) = "Trilyun "

        If (x < 0) Then
            TERBILANG = ""
            Exit Function
        End If

        If (x = 0) Then
            TERBILANG = "Nol"
            Exit Function
        End If

        If (x < 2000) Then
            tanda = True
        End If
        teks = ""

        If (x >= 1.0E+15) Then
            TERBILANG = "Nilai Terlalu Besar"
            Exit Function
        End If

        For i = 4 To 1 Step -1
            tampung = Int(x / (10 ^ (3 * i)))
            If (tampung > 0) Then
                bagian = ratusan(tampung, tanda)
                teks = teks & bagian & letak(i)
            End If
            x = x - tampung * (10 ^ (3 * i))
        Next

        teks = teks & ratusan(x, False)
        TERBILANG = teks & "Rupiah"
    End Function

    Function ratusan(ByVal y As Double, ByVal flag As Boolean) As String
        On Error Resume Next
        Dim tmp As Double
        Dim bilang As String
        Dim bag As String
        Dim j As Integer

        Dim angka(9)
        angka(1) = "Se"
        angka(2) = "Dua "
        angka(3) = "Tiga "
        angka(4) = "Empat "
        angka(5) = "Lima "
        angka(6) = "Enam "
        angka(7) = "Tujuh "
        angka(8) = "Delapan "
        angka(9) = "Sembilan "

        Dim posisi(2)
        posisi(1) = "Puluh "
        posisi(2) = "Ratus "

        bilang = ""
        For j = 2 To 1 Step -1
            tmp = Int(y / (10 ^ j))
            If (tmp > 0) Then
                bag = angka(tmp)
                If (j = 1 And tmp = 1) Then
                    y = y - tmp * 10 ^ j
                    If (y >= 1) Then
                        posisi(j) = "belas "
                    Else
                        angka(y) = "Se"
                    End If
                    bilang = bilang & angka(y) & posisi(j)
                    ratusan = bilang
                    Exit Function
                Else
                    bilang = bilang & bag & posisi(j)
                End If
            End If
            y = y - tmp * 10 ^ j
        Next

        If (flag = False) Then
            angka(1) = "Satu "
        End If
        bilang = bilang & angka(y)
        ratusan = bilang
    End Function
End Module
