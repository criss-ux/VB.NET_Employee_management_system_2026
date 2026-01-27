Public Class Adminlogin
    Private Sub Adminlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(120, 0, 0, 0)
        Label1.Parent = Panel1
        Label1.BackColor = Color.Transparent

        Label2.Parent = Panel1
        Label2.BackColor = Color.Transparent

        Label1.Parent = Panel1
        Label1.BackColor = Color.Transparent

        Label3.Parent = Panel1
        Label3.BackColor = Color.Transparent

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Then
            MessageBox.Show("Enter username!", "Employee Management")

        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Enter password!", "Employee Management")

        ElseIf txtUsername.Text = "admin" AndAlso txtPassword.Text = "akili" Then
            Dim frm2 As New AdminDashboard
            frm2.Show()
            Me.Hide()   ' hides login form

        Else
            MessageBox.Show("Invalid credentials!", "Employee Management")
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Form1.Show()

    End Sub
End Class