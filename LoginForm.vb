Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginForm
    ' Return hex string instead of raw bytes
    Private Function ComputeHash(password As String) As String
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
        If txtUsername.Text = "" OrElse txtPassword.Text = "" Then
            MessageBox.Show("Enter both username and password!", "Employee Management")
            Return
        End If

        Dim connString As String = "Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True"
        Using conn As New SqlConnection(connString)
            Try
                conn.Open()
                ' Now we SELECT Role instead of COUNT(*)
                Dim query As String = "SELECT Role FROM EmployeeRegistration WHERE Username=@username AND PasswordHash=@passwordHash"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@passwordHash", ComputeHash(txtPassword.Text))

                    Dim roleObj As Object = cmd.ExecuteScalar()
                    If roleObj IsNot Nothing Then
                        Dim role As String = roleObj.ToString()

                        If role = "Admin" Then
                            Dim frmAdmin As New AdminDashboard
                            frmAdmin.Show()
                            Me.Hide()
                        ElseIf role = "Employee" Then
                            Dim frmEmp As New Dashboard1
                            frmEmp.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Unknown role assigned!", "Employee Management")
                        End If
                    Else
                        MessageBox.Show("Invalid credentials!", "Employee Management")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Employee Management")
            End Try
        End Using
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(120, 0, 0, 0)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim frm2 As New EmployeeRegisterform
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim frm2 As New Forgotpassword
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim frm2 As New Form1
        frm2.Show()
        Me.Hide()
    End Sub
End Class
