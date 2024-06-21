
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class Form1
    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New Form2()
        viewForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        Dim createForm As New Form3()
        createForm.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateSubmission.PerformClick()
        End If
    End Sub

End Class


Public Class ApiHelper
    Private Shared ReadOnly client As HttpClient = New HttpClient()

    Public Shared Async Function PostSubmission(name As String, email As String, phone As String, githubLink As String, stopwatchTime As String) As Task(Of HttpResponseMessage)
        Dim url As String = "http://localhost:3000/submit"
        Dim submission As New With {
            Key .name = name,
            Key .email = email,
            Key .phone = phone,
            Key .github_link = githubLink,
            Key .stopwatch_time = stopwatchTime
        }
        Dim json = JsonConvert.SerializeObject(submission)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Return Await client.PostAsync(url, content)
    End Function

    Public Shared Async Function GetSubmission(index As Integer) As Task(Of HttpResponseMessage)
        Dim url As String = $"http://localhost:3000/read?index={index}"
        Return Await client.GetAsync(url)
    End Function
End Class

