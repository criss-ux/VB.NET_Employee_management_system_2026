Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text

Public Class EmployeeRegisterform
    ' Connection string (update YOUR_SERVER_NAME to your SQL Server instance)
    Private connectionString As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True"

    ' ErrorProvider for warnings
    Private ep As New ErrorProvider()

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Clear previous warnings
        ep.Clear()

        ' Validate inputs
        If Not ValidateInputs() Then Exit Sub

        ' Save to database
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Hash password before saving
                Dim hashedPassword As String = HashPassword(txtPassword.Text.Trim())

                Dim query As String = "INSERT INTO EmployeeRegistration (Fullname, Username, Gender, PasswordHash) 
                                       VALUES (@Fullname, @Username, @Gender, @PasswordHash)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@Gender", CmbGender.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After successful registration, show Login form
            Dim loginForm As New LoginForm
            loginForm.Show() ' Close the registration form
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        Dim isValid As Boolean = True

        ' Fullname validation: must be letters only
        If String.IsNullOrWhiteSpace(txtFullname.Text) Then
            ep.SetError(txtFullname, "Fullname is required.")
            isValid = False
        ElseIf Not Regex.IsMatch(txtFullname.Text, "^[A-Za-z\s]+$") Then
            ep.SetError(txtFullname, "Fullname must contain only letters.")
            isValid = False
        End If

        ' Username validation: must be letters only
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ep.SetError(txtUsername, "Username is required.")
            isValid = False
        ElseIf Not Regex.IsMatch(txtUsername.Text, "^[A-Za-z]+$") Then
            ep.SetError(txtUsername, "Username must contain only letters.")
            isValid = False
        End If

        ' Gender validation
        If CmbGender.SelectedIndex = -1 Then
            ep.SetError(CmbGender, "Please select a gender.")
            isValid = False
        End If

        ' Password validation: strong password required
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ep.SetError(txtPassword, "Password is required.")
            isValid = False
        ElseIf Not IsStrongPassword(txtPassword.Text) Then
            ep.SetError(txtPassword, "Password must be at least 8 characters, include uppercase, lowercase, digit, and special character.")
            isValid = False
        End If

        ' Confirm password validation
        If txtConfirmPassword.Text <> txtPassword.Text Then
            ep.SetError(txtConfirmPassword, "Passwords do not match.")
            isValid = False
        End If

        Return isValid
    End Function

    ' 🔹 Strong password check
    Private Function IsStrongPassword(password As String) As Boolean
        Dim hasUpper As Boolean = Regex.IsMatch(password, "[A-Z]")
        Dim hasLower As Boolean = Regex.IsMatch(password, "[a-z]")
        Dim hasDigit As Boolean = Regex.IsMatch(password, "[0-9]")
        Dim hasSpecial As Boolean = Regex.IsMatch(password, "[^A-Za-z0-9]")

        Return password.Length >= 8 AndAlso hasUpper AndAlso hasLower AndAlso hasDigit AndAlso hasSpecial
    End Function

    ' 🔹 Secure password hashing with SHA256
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim EmployeeRegister As New LoginForm
        EmployeeRegister.Show()
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim EmployeeRegister As New LoginForm
        EmployeeRegister.Show()
        Me.Close()
    End Sub
End Class
