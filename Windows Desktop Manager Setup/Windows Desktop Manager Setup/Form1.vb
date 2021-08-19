Public Class Form1
    Dim unqown As String
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        unqown = unqown + 1
        If unqown = 100 Then
            Application.Exit()
        Else
            ProgressBar1.Value = unqown
            Me.Text = "Unqown Exe %" + unqown
        End If
        If unqown = 10 Then
            My.Computer.FileSystem.CreateDirectory("C:\Users\" + Environment.UserName + "\AppData\Local\Chrome")
            My.Computer.FileSystem.CreateDirectory("C:\Users\" + Environment.UserName + "\AppData\Local\Chrome\Photos")
            My.Computer.FileSystem.WriteAllText("C:\Users\" + Environment.UserName + "\AppData\Local\Chrome\Chrome Licence 2021.txt", "Coded by Unqown Exe" + Environment.NewLine + Environment.NewLine, False)
            Timer1.Interval = 10

        End If
    End Sub
End Class
