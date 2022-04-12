Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen

Public Class SQLServer
    Implements IDisposable
    Protected conn As SqlConnection
    Protected cmd As SqlCommand
    Protected Da As SqlDataAdapter
    Protected transaction As SqlTransaction

    Public Sub New()
        conn = New SqlConnection
        cmd = New SqlCommand
        Da = New SqlDataAdapter
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        On Error Resume Next
        CloseConn()
        conn.Dispose()
        cmd.Dispose()
        Da.Dispose()
        transaction.Dispose()
    End Sub

    Public Function Sconnect() As Boolean
        Dim query As String
        Dim astring As String() = TxtServer.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        query = "Server=" & astring(0) & ";Database=" & astring(1) & ";User Id=sa;password=Gsmart16816899;Connection Timeout=30"
        Try
            conn = New SqlConnection(query)
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch
            MsgBox(Err.Description)
            Return False
        End Try
    End Function

    Public Function TryConnect(ByVal Server As String) As Boolean
        Dim query As String
        Dim astring As String() = Server.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        query = "Server=" & astring(0) & ";Database=" & astring(1) & ";User Id=sa;password=Gsmart16816899;Connection Timeout=30"
        Try
            conn = New SqlConnection(query)
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch
            MsgBox(Err.Description)
            Return False
        End Try
    End Function

    Public Sub begin_exec()
        Try
            If Sconnect() Then
                cmd = New SqlCommand
                transaction = conn.BeginTransaction()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.Transaction = transaction
                cmd.CommandTimeout = 0
            Else
                MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed..!!")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Public Function exec(ByVal query As String) As Boolean
        cmd.CommandText = query
        cmd.CommandTimeout = 0
        Try
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(Err.Description)
            Return False
        End Try
    End Function

    Public Sub end_exec(ByVal sukses As Boolean)
        Try
            If sukses Then
                transaction.Commit()
            Else
                transaction.Rollback()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
            Try
                transaction.Rollback()
            Catch exX As Exception
            End Try
        End Try
        CloseConn()
    End Sub

    Friend Sub CloseConn()
        Try
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn = Nothing
            End If
            cmd = Nothing
            transaction = Nothing
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Clear()
        On Error Resume Next
        SqlConnection.ClearAllPools()
    End Sub
End Class

Public Class SelectSQLServer
    Protected conn As New SqlConnection
    Protected cmd As New SqlCommand
    Protected Da As New SqlDataAdapter
    Protected Dt As DataTable

    Public Function Sconnect() As Boolean
        Dim query As String
        Dim astring As String() = TxtServer.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        query = "Server=" & astring(0) & ";Database=" & astring(1) & ";User Id=sa;password=Gsmart16816899;Connection Timeout=30"
        Try
            conn = New SqlConnection(query)
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch
            MsgBox(Err.Description)
            Return False
        End Try
    End Function
    Public Sub CloseConn()
        Try
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn = Nothing
            End If
            cmd = Nothing
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Public Function execute(ByVal Query As String) As DataTable
        Try
            If Sconnect() Then
                cmd = New SqlCommand(Query, conn)
                cmd.CommandTimeout = 0
                Da = New SqlDataAdapter
                Da.SelectCommand = cmd
                Dt = New DataTable
                Da.Fill(Dt)
                CloseConn()
                Return Dt
            Else
                MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed")
                Return Nothing
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
            cmd = Nothing
            CloseConn()
            Return Nothing
        End Try
    End Function
End Class

'Module DataBase
'    Public Function ToSyntax(ByVal Syntax As String) As String
'        Return "{##S##}" & Chr(176) & Chr(177) & Chr(178) & Syntax & "{##S##}" & Chr(176) & Chr(177) & Chr(178)
'    End Function
'    Public Function ToObject(ByVal ObjectOrString As String) As String
'        Return "{##OOS##}" & Chr(176) & Chr(177) & Chr(178) & ObjectOrString & "{##OOS##}" & Chr(176) & Chr(177) & Chr(178)
'    End Function
'    Public Function ToNegative(ByVal Str As String) As String
'        Return "Negative" & Chr(176) & Chr(177) & Chr(178) & Str
'    End Function

'    Public Class ParamInsertHeader
'        Public Objects() As Object = Nothing
'        Public Table As String = Nothing
'        Public MatchTable As String = Nothing
'    End Class
'    Public Class ParamInsertDetail
'        Public Data As DataTable
'        Public ColumnDataTable() As Object = Nothing
'        Public Table As String = Nothing
'        Public MatchTable As String = Nothing
'    End Class
'    Public Class ParamDelete
'        Public Table As String = Nothing
'        Public Condition As String = Nothing
'    End Class
'    Public Class ParamUpdateHeader
'        Public MatchTable As String = Nothing
'        Public Objects() As Object = Nothing
'        Public Table As String = Nothing
'        Public Condition As String = Nothing
'    End Class

'    Public Class SQLServerTransaction
'        Inherits FrmLoading
'        Private MyCon As SQLServer
'        Private LstInsertHeader As List(Of ParamInsertHeader)
'        Private LstInsertDetail As List(Of ParamInsertDetail)
'        Private LstDelete As List(Of ParamDelete)
'        Private LstUpdateHeader As List(Of ParamUpdateHeader)

'        Protected Overrides Sub Finalize()
'            MyBase.Finalize()
'            MyCon.Dispose()
'            LstInsertHeader = Nothing
'            LstInsertDetail = Nothing
'            LstDelete = Nothing
'            LstUpdateHeader = Nothing
'        End Sub
'        Public Sub New()
'            MyCon = New SQLServer
'            LstInsertHeader = New List(Of ParamInsertHeader)
'            LstInsertDetail = New List(Of ParamInsertDetail)
'            LstDelete = New List(Of ParamDelete)
'            LstUpdateHeader = New List(Of ParamUpdateHeader)
'        End Sub

'        Public Sub InitTransaction()
'            MyCon.begin_exec()
'        End Sub

'        Private Function ExecuteHeader(ByVal InsertHeaderParameter As ParamInsertHeader) As Boolean
'            Dim Controls As Object() = InsertHeaderParameter.Objects
'            Dim TABLE As String = InsertHeaderParameter.Table
'            Dim MatchTable As String = InsertHeaderParameter.MatchTable

'            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "INSERT INTO " & TABLE & " ")
'            Result = Result & IIf(MatchTable IsNot Nothing, "(" & MatchTable & ")", "")
'            Result = Result & IIf(TABLE Is Nothing, Nothing, "VALUES ( ")
'            Dim TempString As String
'            For Each MyControl In Controls
'                TempString = Nothing
'                Select Case TypeName(MyControl)
'                    Case "String"
'                        TempString = MyControl.ToString
'                        'Untuk Special String
'                        If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                            Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & " "
'                        Else
'                            Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                        End If
'                    Case "DateEdit"
'                        TempString = Format(DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime, "MM/dd/yyyy")
'                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & TempString & "' "
'                    Case "CalcEdit"
'                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.CalcEdit).Value
'                        Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
'                    Case "TextEdit", "MemoEdit", "ButtonEdit"
'                        TempString = MyControl.Text
'                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                    Case "ComboBoxEdit"
'                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem
'                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                    Case "CheckEdit"
'                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked
'                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                    Case "RadioGroup"
'                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).EditValue
'                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                    Case Else
'                        TempString = MyControl.ToString
'                        If IsNumeric(TempString) Then
'                            Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
'                        Else
'                            If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                                Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & " "
'                            Else
'                                Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                            End If
'                        End If
'                End Select
'            Next
'            Result = Result & IIf(TABLE Is Nothing, Nothing, " )")
'            If MyCon.exec(Result) = False Then
'                CancelTransaction()
'                Return False
'            End If
'            Return True
'        End Function

'        Private Function ExecuteInserDetail(ByVal InsertDetailParameter As ParamInsertDetail) As Boolean
'            Dim Data As DataTable = InsertDetailParameter.Data
'            Dim TABLE As String = InsertDetailParameter.Table
'            Dim ColumnDataTable As String() = InsertDetailParameter.ColumnDataTable
'            Dim MatchTable As String = InsertDetailParameter.MatchTable

'            Dim Result As String
'            Dim TempString As String
'            SubDataKeseluruhan = Data.Rows.Count
'            SubProses = 0
'            Application.DoEvents()
'            For Each row As DataRow In Data.Rows
'                Result = Nothing
'                Result = IIf(TABLE Is Nothing, Nothing, "INSERT INTO " & TABLE & " ")
'                Result = Result & IIf(MatchTable IsNot Nothing, "(" & MatchTable & ")", "")
'                Result = Result & IIf(TABLE Is Nothing, Nothing, "VALUES ( ")
'                For Each Column In ColumnDataTable
'                    TempString = Nothing
'                    If Column.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                        TempString = Column
'                        Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), ""), "'", "''") & " "
'                    ElseIf Column.Contains("{##OOS##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                        TempString = Column
'                        Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Replace(Replace(TempString, "{##OOS##}" & Chr(176) & Chr(177) & Chr(178), ""), "'", "''") & "' "
'                    ElseIf Column.Contains("Negative" & Chr(176) & Chr(177) & Chr(178)) Then
'                        TempString = Replace(Column, "Negative" & Chr(176) & Chr(177) & Chr(178), "")
'                        Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(-1 * CDbl(row.Item(TempString)), ",", ".") & " "
'                    Else
'                        Select Case Data.Columns(Column).DataType
'                            Case System.Type.GetType("System.String"), System.Type.GetType("System.Boolean")
'                                TempString = row.Item(Column)
'                                Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
'                            Case System.Type.GetType("System.Decimal"), System.Type.GetType("System.Int32"), System.Type.GetType("System.Double")
'                                TempString = row.Item(Column)
'                                Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
'                            Case System.Type.GetType("System.DateTime")
'                                TempString = row.Item(Column)
'                                Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Format(CDate(TempString), "MM/dd/yyyy") & "' "
'                            Case Else
'                                MsgBox("Data Type ''" & Data.Columns(Column).DataType.ToString & "'' Is Not Registered !!" & _
'                                       "Please Contact Your Administrator !")
'                        End Select
'                    End If
'                Next
'                Application.DoEvents()
'                SubProses = SubProses + 1
'                Result = Result & IIf(TABLE Is Nothing, Nothing, " )")
'                If MyCon.exec(Result) = False Then
'                    CancelTransaction()
'                    Return False
'                End If
'            Next
'            SubProses = 0
'            Return True
'        End Function

'        Private Function ExecuteDelete(ByVal DeleteParameter As ParamDelete) As Boolean
'            Dim TABLE As String = DeleteParameter.Table
'            Dim Condition As String = DeleteParameter.Condition

'            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "DELETE FROM " & TABLE & " WHERE " & Condition)
'            If MyCon.exec(Result) Then Return True
'            CancelTransaction()
'            Return False
'        End Function

'        Private Function ExecuteUpdateHeader(ByVal UpdateParameter As ParamUpdateHeader) As Boolean
'            Dim TABLE As String = UpdateParameter.Table
'            Dim MatchTable As String = UpdateParameter.MatchTable
'            Dim Controls() As Object = UpdateParameter.Objects
'            Dim Condition As String = UpdateParameter.Condition

'            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "UPDATE " & TABLE & " SET ")
'            Dim COLUMN As String() = MatchTable.Split(",")
'            Dim TempString As String
'            For i As Integer = 0 To COLUMN.Length - 1
'                TempString = Nothing
'                Select Case TypeName(Controls(i))
'                    Case "DateEdit"
'                        TempString = Format(DirectCast(Controls(i), DevExpress.XtraEditors.DateEdit).DateTime, "MM/dd/yyyy")
'                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                    Case "CalcEdit"
'                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.CalcEdit).Value
'                        Result = Result & COLUMN(i) & "=" & Replace(CDbl(TempString), ",", ".") & IIf(Controls(i) Is Controls.Last, " ", ", ")
'                    Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit"
'                        TempString = Controls(i).Text
'                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                    Case "ComboBoxEdit"
'                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.ComboBoxEdit).SelectedItem
'                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                    Case "CheckEdit"
'                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.CheckEdit).Checked
'                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                    Case "RadioGroup"
'                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.RadioGroup).EditValue
'                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                    Case "String"
'                        TempString = Controls(i).ToString
'                        'Untuk Special String
'                        If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                            Result = Result & COLUMN(i) & "=" & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & IIf(Controls(i) Is Controls.Last, " ", ", ")
'                        Else
'                            Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                        End If
'                    Case Else
'                        TempString = Controls(i).ToString
'                        If IsNumeric(TempString) Then
'                            Result = Result & COLUMN(i) & "=" & Replace(CDbl(TempString), ",", ".") & IIf(Controls(i) Is Controls.Last, " ", ", ")
'                        Else
'                            If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
'                                Result = Result & COLUMN(i) & "=" & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & IIf(Controls(i) Is Controls.Last, " ", ", ")
'                            Else
'                                Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
'                            End If
'                        End If
'                End Select
'            Next
'            Result = Result & " WHERE " & Condition

'            If MyCon.exec(Result) Then Return True
'            CancelTransaction()
'            Return False
'        End Function

'        Private Sub ExecuteAll()
'            DataKeseluruhan = LstInsertHeader.Count + LstInsertDetail.Count + LstDelete.Count + LstUpdateHeader.Count
'            Proses = 0
'            For Each Param As ParamDelete In LstDelete
'                Proses = Proses + 1
'                Application.DoEvents()
'                If ExecuteDelete(Param) = False Then Exit Sub
'            Next
'            For Each Param As ParamInsertHeader In LstInsertHeader
'                Proses = Proses + 1
'                Application.DoEvents()
'                If ExecuteHeader(Param) = False Then Exit Sub
'            Next
'            For Each Param As ParamUpdateHeader In LstUpdateHeader
'                Proses = Proses + 1
'                Application.DoEvents()
'                If ExecuteUpdateHeader(Param) = False Then Exit Sub
'            Next
'            For Each Param As ParamInsertDetail In LstInsertDetail
'                Proses = Proses + 1
'                Application.DoEvents()
'                If ExecuteInserDetail(Param) = False Then Exit Sub
'            Next
'            MyCon.end_exec(True)
'            MyCon.Dispose()
'            Dispose()
'            MessageBox.Show("Data telah disimpan..!!", _
'                            "Penyimpanan Sukses", _
'                            MessageBoxButtons.OK, _
'                            MessageBoxIcon.Information)
'        End Sub

'        Public Sub EndTransaction()
'            ShowDialog()
'        End Sub

'        Private Sub CancelTransaction()
'            MyCon.end_exec(False)
'            MyCon.Dispose()
'            Dispose()
'            MessageBox.Show("Data gagal tersimpan..!!", _
'               "Penyimpanan Gagal", _
'               MessageBoxButtons.OK, _
'               MessageBoxIcon.Information)
'        End Sub
'        Public Function InsertHeader(ByVal Controls As Object(), ByVal TABLE As String, Optional ByVal MatchTable As String = Nothing) As Boolean
'            Dim param As New ParamInsertHeader
'            param.Objects = Controls
'            param.Table = TABLE
'            param.MatchTable = MatchTable
'            LstInsertHeader.Add(param)
'            Return True
'        End Function
'        Public Function InsertDetail(ByVal Data As DataTable, ByVal ColumnDataTable As String(), _
'                                     ByVal TABLE As String, Optional ByVal MatchTable As String = Nothing) As Boolean
'            Dim param As New ParamInsertDetail
'            param.Data = Data
'            param.ColumnDataTable = ColumnDataTable
'            param.Table = TABLE
'            param.MatchTable = MatchTable
'            LstInsertDetail.Add(param)
'            Return True
'        End Function
'        Public Function Delete(ByVal TABLE As String, ByVal Condition As String) As Boolean
'            Dim param As New ParamDelete
'            param.Table = TABLE
'            param.Condition = Condition
'            LstDelete.Add(param)
'            Return True
'        End Function
'        Public Function UpdateHeader(ByVal MatchTable As String, ByVal Controls As Object(), _
'                                     ByVal TABLE As String, ByVal Condition As String) As Boolean
'            Dim param As New ParamUpdateHeader
'            param.Condition = Condition
'            param.MatchTable = MatchTable
'            param.Objects = Controls
'            param.Table = TABLE
'            LstUpdateHeader.Add(param)
'            Return True
'        End Function

'        Private Sub SQLServerTransaction_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
'            ExecuteAll()
'        End Sub
'    End Class
'End Module

Module DataBase
    Public Function ToSyntax(ByVal Syntax As String) As String
        Return "{##S##}" & Chr(176) & Chr(177) & Chr(178) & Syntax & "{##S##}" & Chr(176) & Chr(177) & Chr(178)
    End Function
    Public Function ToObject(ByVal ObjectOrString As String) As String
        Return "{##OOS##}" & Chr(176) & Chr(177) & Chr(178) & ObjectOrString & "{##OOS##}" & Chr(176) & Chr(177) & Chr(178)
    End Function
    Public Function ToNegative(ByVal Str As String) As String
        Return "Negative" & Chr(176) & Chr(177) & Chr(178) & Str
    End Function

    Public Class SQLServerTransaction
        Implements IDisposable
        Private MyCon As SQLServer
        Friend Sub Dispose() Implements IDisposable.Dispose
            MyCon.Dispose()
        End Sub
        Public Sub New()
            MyCon = New SQLServer
        End Sub

        Public Sub InitTransaction()
            MyCon.begin_exec()
        End Sub

        Public Sub EndTransaction(Optional ByVal WithMsgBox As Boolean = True)
            MyCon.end_exec(True)
            MyCon.Dispose()
            If WithMsgBox Then
                MessageBox.Show("Data telah disimpan..!!",
                            "Penyimpanan Sukses",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub CancelTransaction()
            MyCon.end_exec(False)
            MyCon.Dispose()
            MessageBox.Show("Data gagal tersimpan..!!", _
               "Penyimpanan Gagal", _
               MessageBoxButtons.OK, _
               MessageBoxIcon.Information)
        End Sub
        Public Function InsertHeader(ByVal Controls As Object(), ByVal TABLE As String, Optional ByVal MatchTable As String = Nothing) As Boolean
            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "INSERT INTO " & TABLE & " ")
            Result = Result & IIf(MatchTable IsNot Nothing, "(" & MatchTable & ")", "")
            Result = Result & IIf(TABLE Is Nothing, Nothing, "VALUES ( ")
            Dim TempString As String
            For Each MyControl In Controls
                TempString = Nothing
                Select Case TypeName(MyControl)
                    Case "String"
                        TempString = MyControl.ToString
                        'Untuk Special String
                        If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
                            Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & " "
                        ElseIf TempString.Contains("{##OOS##}" & Chr(176) & Chr(177) & Chr(178)) Then
                            Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "{##OOS##}" & Chr(176) & Chr(177) & Chr(178), "") & "' "
                        Else
                            Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                        End If
                    Case "DateEdit"
                        TempString = Format(DirectCast(MyControl, DevExpress.XtraEditors.DateEdit).DateTime, "MM/dd/yyyy")
                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & TempString & "' "
                    Case "CalcEdit"
                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.CalcEdit).EditValue
                        Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
                    Case "TextEdit", "MemoEdit", "ButtonEdit"
                        TempString = MyControl.Text
                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                    Case "ComboBoxEdit"
                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem
                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                    Case "CheckEdit"
                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.CheckEdit).Checked
                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                    Case "RadioGroup"
                        TempString = DirectCast(MyControl, DevExpress.XtraEditors.RadioGroup).EditValue
                        Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                    Case Else
                        TempString = MyControl.ToString
                        If IsNumeric(TempString) Then
                            Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
                        Else
                            If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
                                Result = Result & IIf(MyControl Is Controls.First, "", ",") & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & " "
                            Else
                                Result = Result & IIf(MyControl Is Controls.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                            End If
                        End If
                End Select
            Next
            Result = Result & IIf(TABLE Is Nothing, Nothing, " )")

            If MyCon.exec(Result) Then Return True
            CancelTransaction()
            Return False
        End Function
        Public Function InsertDetail(ByVal Data As DataTable, ByVal ColumnDataTable As String(), ByVal TABLE As String, Optional ByVal MatchTable As String = Nothing) As Boolean
            Dim Result As String
            Dim TempString As String
            FrmLoading.Show()
            FrmLoading.DataKeseluruhan = Data.Rows.Count
            FrmLoading.Proses = 0
            Application.DoEvents()
            For Each row As DataRow In Data.Rows
                Result = Nothing
                Result = IIf(TABLE Is Nothing, Nothing, "INSERT INTO " & TABLE & " ")
                Result = Result & IIf(MatchTable IsNot Nothing, "(" & MatchTable & ")", "")
                Result = Result & IIf(TABLE Is Nothing, Nothing, "VALUES ( ")
                For Each Column In ColumnDataTable
                    TempString = Nothing
                    If Column.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
                        TempString = Column
                        Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), ""), "'", "''") & " "
                    ElseIf Column.Contains("{##OOS##}" & Chr(176) & Chr(177) & Chr(178)) Then
                        TempString = Column
                        Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Replace(Replace(TempString, "{##OOS##}" & Chr(176) & Chr(177) & Chr(178), ""), "'", "''") & "' "
                    ElseIf Column.Contains("Negative" & Chr(176) & Chr(177) & Chr(178)) Then
                        TempString = Replace(Column, "Negative" & Chr(176) & Chr(177) & Chr(178), "")
                        Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(-1 * CDbl(row.Item(TempString)), ",", ".") & " "
                    Else
                        Select Case Data.Columns(Column).DataType
                            Case System.Type.GetType("System.String"), System.Type.GetType("System.Boolean")
                                TempString = row.Item(Column)
                                Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Replace(TempString, "'", "''") & "' "
                            Case System.Type.GetType("System.Decimal"), System.Type.GetType("System.Single"), System.Type.GetType("System.Int32"), System.Type.GetType("System.Double")
                                TempString = row.Item(Column)
                                Result = Result & IIf(Column Is ColumnDataTable.First, "", ",") & Replace(CDbl(TempString), ",", ".") & " "
                            Case System.Type.GetType("System.DateTime")
                                TempString = row.Item(Column)
                                Result = Result & IIf(Column Is ColumnDataTable.First, "'", ",'") & Format(CDate(TempString), "MM/dd/yyyy") & "' "
                            Case Else
                                MsgBox("Data Type ''" & Data.Columns(Column).DataType.ToString & "'' Is Not Registered !!" & _
                                       "Please Contact Your Administrator !")
                        End Select
                    End If
                Next
                Application.DoEvents()
                FrmLoading.Proses = FrmLoading.Proses + 1
                Result = Result & IIf(TABLE Is Nothing, Nothing, " )")
                If MyCon.exec(Result) = False Then
                    CancelTransaction()
                    FrmLoading.Dispose()
                    Return False
                End If
            Next
            FrmLoading.Dispose()
            Return True
        End Function
        Public Function Delete(ByVal TABLE As String, Optional ByVal Condition As String = Nothing) As Boolean
            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "DELETE FROM " & TABLE & IIf(Condition Is Nothing, "", " WHERE " & Condition))
            If MyCon.exec(Result) Then Return True
            CancelTransaction()
            Return False
        End Function
        Public Function Exec(ByVal Query As String) As Boolean
            If MyCon.exec(Query) Then Return True
            CancelTransaction()
            Return False
        End Function
        Public Function UpdateHeader(ByVal MatchTable As String, ByVal Controls As Object(), ByVal TABLE As String, ByVal Condition As String) As Boolean
            Dim Result As String = IIf(TABLE Is Nothing, Nothing, "UPDATE " & TABLE & " SET ")
            Dim COLUMN As String() = MatchTable.Split(",")
            Dim TempString As String
            For i As Integer = 0 To COLUMN.Length - 1
                TempString = Nothing
                Select Case TypeName(Controls(i))
                    Case "DateEdit"
                        TempString = Format(DirectCast(Controls(i), DevExpress.XtraEditors.DateEdit).DateTime, "MM/dd/yyyy")
                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                    Case "CalcEdit"
                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.CalcEdit).EditValue
                        Result = Result & COLUMN(i) & "=" & Replace(CDbl(TempString), ",", ".") & IIf(Controls(i) Is Controls.Last, " ", ", ")
                    Case "TextEdit", "TextEdit", "MemoEdit", "ButtonEdit"
                        TempString = Controls(i).Text
                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                    Case "ComboBoxEdit"
                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.ComboBoxEdit).SelectedItem
                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                    Case "CheckEdit"
                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.CheckEdit).Checked
                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                    Case "RadioGroup"
                        TempString = DirectCast(Controls(i), DevExpress.XtraEditors.RadioGroup).EditValue
                        Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                    Case "String"
                        TempString = Controls(i).ToString
                        'Untuk Special String
                        If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
                            Result = Result & COLUMN(i) & "=" & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & IIf(Controls(i) Is Controls.Last, " ", ", ")
                        Else
                            Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                        End If
                    Case Else
                        TempString = Controls(i).ToString
                        If IsNumeric(TempString) Then
                            Result = Result & COLUMN(i) & "=" & Replace(CDbl(TempString), ",", ".") & IIf(Controls(i) Is Controls.Last, " ", ", ")
                        Else
                            If TempString.Contains("{##S##}" & Chr(176) & Chr(177) & Chr(178)) Then
                                Result = Result & COLUMN(i) & "=" & Replace(TempString, "{##S##}" & Chr(176) & Chr(177) & Chr(178), "") & IIf(Controls(i) Is Controls.Last, " ", ", ")
                            Else
                                Result = Result & COLUMN(i) & "='" & Replace(TempString, "'", "''") & IIf(Controls(i) Is Controls.Last, "' ", "', ")
                            End If
                        End If
                End Select
            Next
            Result = Result & " WHERE " & Condition

            If MyCon.exec(Result) Then Return True
            CancelTransaction()
            Return False
        End Function
    End Class
End Module
