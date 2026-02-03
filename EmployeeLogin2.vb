Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class EmployeeLogin2

    ' Hash password using SHA256
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim Username As String = txtUsername.Text.Trim()
            Dim Password As String = txtPassword.Text.Trim()

            ' Validate input
            If Username = "" OrElse Password = "" Then
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Hash the entered password
            Dim hashedPassword As String = HashPassword(Password)

            ' Connection string (replace with your actual password if needed)
            Dim connStr As String = "server=localhost;userid=root;password=;database=employee_db"

            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' Case-insensitive username comparison
                Dim query As String = "SELECT COUNT(*) FROM Registration WHERE LOWER(Username)=LOWER(@Username) AND Password=@Password"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", Username)
                    cmd.Parameters.AddWithValue("@Password", hashedPassword)

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count = 1 Then
                        MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        EmployeeDashboard.Show()
                    Else
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub EmployeeLogin2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    'for transparent background ot labels
    Panel1.BackColor = Color.FromArgb(120, 0, 0, 0)
    Label1.Parent = Panel1
    Label1.BackColor = Color.Transparent

    Label2.Parent = Panel1
    Label2.BackColor = Color.Transparent

    Label3.Parent = Panel1
    Label3.BackColor = Color.Transparent

    Label5.Parent = Panel1
    Label5.BackColor = Color.Transparent

    Label6.Parent = Panel1
    Label6.BackColor = Color.Transparent



End Sub

Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
        FrmRegisterEmployee.Show()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class