Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs)
        Dim frm2 As New EmployeeLogin2
        frm2.Show()
        Me.Hide()   ' hides login form
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent

        Label2.Parent = PictureBox1
        Label2.BackColor = Color.Transparent
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim frm2 As New EmployeeLogin2
        frm2.Show()
        Me.Hide()   ' hides login form


    End Sub

    Private Sub btnLoginAsAdmin_Click(sender As Object, e As EventArgs) Handles btnLoginAsAdmin.Click
        Dim frm2 As New Adminlogin
        frm2.Show()
        Me.Hide()   ' hides login form


    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
