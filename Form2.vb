Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Public Class Form2
    Private currentIndex As Integer = 0

    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        ' Load initial submission
        Await LoadSubmission(currentIndex)
    End Sub
    Private Async Function LoadSubmission(index As Integer) As Task
        Dim response = Await ApiHelper.GetSubmission(index)
        If response.IsSuccessStatusCode Then
            Dim jsonResponse = Await response.Content.ReadAsStringAsync()
            Dim submission = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonResponse)
            txtName.Text = submission("name")
            txtEmail.Text = submission("email")
            txtPhoneNum.Text = submission("phone")
            txtGitHubLink.Text = submission("github_link")
            txtStopwatchTime.Text = submission("stopwatch_time")
        Else
            MessageBox.Show("Error retrieving submission!")
        End If
    End Function

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentIndex += 1
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        currentIndex -= 1
        Await LoadSubmission(currentIndex)
    End Sub
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext_Click(sender, e)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
