Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class AddDepartment
    ' ✅ Connection string points to SQL Server EmployeeDB
    ' Replace YOUR_SERVER_NAME with your SQL Server instance (e.g., "localhost", "SQLEXPRESS", or "Criss-Johnson")
    Dim connString As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True;"

    Private Sub AddDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartments()
    End Sub

    ' ============================
    ' Add new department
    ' ============================
    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        If String.IsNullOrWhiteSpace(txtDepartmentName.Text) Then
            MessageBox.Show("Please enter a department name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()

                Dim query As String = "INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh department list
                LoadDepartments()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================
    ' Load departments into DataGridView
    ' ============================
    Private Sub LoadDepartments()
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT DepartmentID, DepartmentName FROM Department"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridViewDepartments.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message)
        End Try
    End Sub

    ' ============================
    ' Navigation back to Admin Dashboard
    ' ============================
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    ' ============================
    ' Edit existing department
    ' ============================
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridViewDepartments.CurrentRow Is Nothing OrElse String.IsNullOrWhiteSpace(txtDepartmentName.Text) Then
            MessageBox.Show("Please select a department and enter a new name.", "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Dim departmentID As Integer = Convert.ToInt32(DataGridViewDepartments.CurrentRow.Cells("DepartmentID").Value)
            Dim newName As String = txtDepartmentName.Text.Trim()
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "UPDATE Department SET DepartmentName=@DepartmentName WHERE DepartmentID=@DepartmentID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@DepartmentName", newName)
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Department updated successfully!", "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        LoadDepartments()
                        txtDepartmentName.Clear()
                    Else
                        MessageBox.Show("Update failed. Department not found.", "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating department: " & ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Dim frm2 As New AdminDashboard
        frm2.Show()
        Me.Hide()
    End Sub
End Class
