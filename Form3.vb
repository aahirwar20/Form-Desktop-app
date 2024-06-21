Public Class Form3
    Private stopwatch As New Stopwatch()
    Private timer As New Timer()

    Public Sub New()
        InitializeComponent()
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Interval = 1000 ' 1 second
    End Sub

    Private Sub ToggleStopwatch(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhoneNum.Text
        Dim githubLink As String = txtGitHubLink.Text
        Dim stopwatchTime As String = txtStopwatchTime.Text

        Dim response = Await ApiHelper.PostSubmission(name, email, phone, githubLink, stopwatchTime)
        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submission saved successfully!")
            Me.Close()
            Dim mainForm As New Form1()
            mainForm.Show()
        Else
            MessageBox.Show("Error saving submission!")
        End If
    End Sub

    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            ToggleStopwatch(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSave_Click(sender, e)
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtStopwatchTime_Click(sender As Object, e As EventArgs) Handles txtStopwatchTime.Click

    End Sub
End Class
