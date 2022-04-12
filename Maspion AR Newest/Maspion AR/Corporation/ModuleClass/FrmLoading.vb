Public Class FrmLoading

    Dim _ProsesData As Integer
    Dim _DataKeseluruhan As Integer
    Dim _ProsesDataSub As Integer
    Dim _DataKeseluruhanSub As Integer
    Dim Status As Integer = 0

    Property SubDataKeseluruhan() As Integer
        Get
            Return _DataKeseluruhanSub
        End Get
        Set(ByVal Value As Integer)
            _DataKeseluruhanSub = Value
            ProgressBar2.Maximum = Value
            If ProgressBar2.Maximum = 0 Then
                ProgressBar2.Visible = False
            Else
                ProgressBar2.Visible = True
            End If
        End Set
    End Property

    Property SubProses() As Integer
        Get
            Return _ProsesDataSub
        End Get
        Set(ByVal Value As Integer)
            On Error Resume Next
            _ProsesDataSub = Value
            ProgressBar2.Value = Value
        End Set
    End Property

    Property DataKeseluruhan() As Integer
        Get
            Return _DataKeseluruhan
        End Get
        Set(ByVal Value As Integer)
            _DataKeseluruhan = Value
            ProgressBar1.Maximum = Value
        End Set
    End Property

    Property Proses() As Integer
        Get
            Return _ProsesData
        End Get
        Set(ByVal Value As Integer)
            On Error Resume Next
            _ProsesData = Value
            ProgressBar1.Value = Value
            LabelProses.Text = "Memroses " & Value & " dari " & _DataKeseluruhan & " data."
            'If Value = _DataKeseluruhan Then Me.Dispose()
        End Set
    End Property

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Application.DoEvents()
        Status = Status + 1
        If Status <= 4 Then
            If Status = 1 Then
                Label1.Text = "Mohon menunggu, sedang memroses data"
                LabelProses.Text = "Memroses " & _ProsesData & " dari " & _DataKeseluruhan & " data"
            ElseIf Status = 2 Then
                Label1.Text = "Mohon menunggu, sedang memroses data."
                LabelProses.Text = "Memroses " & _ProsesData & " dari " & _DataKeseluruhan & " data."
            ElseIf Status = 3 Then
                Label1.Text = "Mohon menunggu, sedang memroses data.."
                LabelProses.Text = "Memroses " & _ProsesData & " dari " & _DataKeseluruhan & " data.."
            ElseIf Status = 4 Then
                Label1.Text = "Mohon menunggu, sedang memroses data..."
                LabelProses.Text = "Memroses " & _ProsesData & " dari " & _DataKeseluruhan & " data..."
            End If
        Else
            Status = 1
            Label1.Text = "Mohon menunggu, sedang memroses data"
            LabelProses.Text = "Memroses " & _ProsesData & " dari " & _DataKeseluruhan & " data"
        End If
    End Sub

    Private Sub FrmLoading_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
    End Sub
End Class