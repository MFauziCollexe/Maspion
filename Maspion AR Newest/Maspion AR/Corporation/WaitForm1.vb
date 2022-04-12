Public Class WaitForm1
    Sub New
        InitializeComponent()
        Me.progressPanel1.AutoHeight = True
    End Sub

    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel1.Caption = caption
    End Sub
    
    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel1.Description = description
    End Sub    

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum WaitFormCommand
        SomeCommandId
    End Enum

    Private Sub WaitForm1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
    End Sub

    Private Counting As Integer = 10
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        If Counting >= 0 Then
            LabelControl1.Text = "Estimated Time " & Counting & "s"
            Counting = Counting - 1
        Else
            Counting = 10
        End If
    End Sub
End Class
