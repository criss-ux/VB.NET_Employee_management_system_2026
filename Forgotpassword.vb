Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class Forgotpassword

    ' Hash password with SHA256
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

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnResert.Click
        Try
            Dim Username As String = txtUsername.Text.Trim() ' read-only, auto-filled
            Dim OldPassword As String = txtOldpassword.Text.Trim()
            Dim NewPassword As String = txtNewPassword.Text.Trim()
            Dim ConfirmPassword As String = txtConfirmPassword.Text.Trim()

            ErrorProvider1.Clear()

            ' Validation
            If OldPassword = "" Then
                ErrorProvider1.SetError(txtOldpassword, "Old password is required.")
                Exit Sub
            End If
            If NewPassword = "" Then
                ErrorProvider1.SetError(txtNewPassword, "New password is required.")
                Exit Sub
            End If
            If ConfirmPassword = "" OrElse NewPassword <> ConfirmPassword Then
                ErrorProvider1.SetError(txtConfirmPassword, "Passwords do not match.")
                Exit Sub
            End If

            Dim oldHashed As String = HashPassword(OldPassword)
            Dim newHashed As String = HashPassword(NewPassword)

            Dim connStr As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True;"
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Verify old password
                Dim checkQuery As String = "SELECT COUNT(*) FROM EmployeeRegistration WHERE Username=@Username AND PasswordHash=@PasswordHash"
                Using checkCmd As New SqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Username", Username)
                    checkCmd.Parameters.AddWithValue("@PasswordHash", oldHashed)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count = 0 Then
                        ErrorProvider1.SetError(txtOldpassword, "Old password is incorrect.")
                        Exit Sub
                    End If
                End Using

                ' Update new password
                Dim updateQuery As String = "UPDATE EmployeeRegistration SET PasswordHash=@NewPassword WHERE Username=@Username"
                Using updateCmd As New SqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@NewPassword", newHashed)
                    updateCmd.Parameters.AddWithValue("@Username", Username)
                    updateCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Password reset successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dim dash As New LoginForm
            dash.Show()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim dash As New LoginForm
        dash.Show()
        Me.Hide()
    End Sub
End Class
