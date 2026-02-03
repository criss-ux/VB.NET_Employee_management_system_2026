Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class FrmRegisterEmployee
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

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim frm2 As New EmployeeLogin2
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm2 As New Form1
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim EmployeeID As String = txtEmployeeID.Text.Trim()
        Dim FullName As String = txtFullname.Text.Trim()
        Dim Username As String = txtUsername.Text.Trim()
        Dim Email As String = txtEmail.Text.Trim()
        Dim Password As String = txtPassword.Text.Trim()
        Dim ConfirmPassword As String = txtComfirmpassword.Text.Trim()
        Dim Gender As String = ""

        ' Check for empty fields
        If EmployeeID = "" OrElse FullName = "" OrElse Username = "" OrElse Email = "" OrElse Password = "" OrElse ConfirmPassword = "" Then
            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check gender selection
        If cmbGender.SelectedIndex <> -1 Then
            Gender = cmbGender.SelectedItem.ToString()
        Else
            MessageBox.Show("Please select gender.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check password match
        If Password <> ConfirmPassword Then
            MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Hash the password before saving
        Dim hashedPassword As String = HashPassword(Password)

        ' Save to database
        Try
            Dim connStr As String = "server=localhost;userid=root;password=;database=employee_db"
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' Check if username already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM Registration WHERE Username=@Username"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Username", Username)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Username already exists. Please choose another.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                ' Insert new employee
                Dim query As String = "INSERT INTO Registration (EmployeeID, FullName, Username, Email, Password, Gender) 
                                       VALUES (@EmployeeID, @FullName, @Username, @Email, @Password, @Gender)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID)
                    cmd.Parameters.AddWithValue("@Fullname", FullName)
                    cmd.Parameters.AddWithValue("@Username", Username)
                    cmd.Parameters.AddWithValue("@Email", Email)
                    cmd.Parameters.AddWithValue("@Password", hashedPassword)
                    cmd.Parameters.AddWithValue("@Gender", Gender)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' ✅ Success message + redirect to login
            MessageBox.Show("Registration successful! Redirecting to login...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim loginForm As New EmployeeLogin2   ' Employee login form
            loginForm.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
