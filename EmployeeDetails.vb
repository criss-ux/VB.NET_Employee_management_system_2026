Imports System.Data.SqlClient
Public Class EmployeeDetails
    ' Adjust connection string to your SQL Server setup
    Dim connString As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True;"

    Public Property CurrentEmployeeID As Integer

    ' ============================
    ' Load only the logged-in employee into DataGridView and form
    ' ============================
    Private Sub LoadEmployee()
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "
                    SELECT e.EmployeeID, e.FullName, e.Gender, e.Phone, e.Email, d.DepartmentName
                    FROM Employees e
                    JOIN Department d ON e.DepartmentID = d.DepartmentID
                    WHERE e.EmployeeID = @EmployeeID"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@EmployeeID", CurrentEmployeeID)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgvEmployees.DataSource = Nothing
                dgvEmployees.DataSource = table
                dgvEmployees.Refresh()

                ' Hide EmployeeID column
                If dgvEmployees.Columns.Contains("EmployeeID") Then
                    dgvEmployees.Columns("EmployeeID").Visible = False
                End If

                ' Hide Department column if present
                If dgvEmployees.Columns.Contains("Department") Then
                    dgvEmployees.Columns("Department").Visible = False
                End If

                ' ✅ Auto-fill form from first row
                If table.Rows.Count > 0 Then
                    Dim row As DataRow = table.Rows(0)
                    txtEmployeeID.Text = row("EmployeeID").ToString()
                    txtFullname.Text = row("FullName").ToString()
                    CmbGender.Text = row("Gender").ToString()
                    txtPhone.Text = row("Phone").ToString()
                    txtEmail.Text = row("Email").ToString()
                    ' Department ComboBox will not auto-select here
                    CmbDepartment.Text = row("DepartmentName").ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    ' ============================
    ' Load departments into ComboBox
    ' ============================
    Private Sub LoadDepartmentsForEmployee()
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT DepartmentID, DepartmentName FROM Department"
                Dim cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                Dim dt As New DataTable()
                dt.Load(reader)

                CmbDepartment.DataSource = dt
                CmbDepartment.DisplayMember = "DepartmentName"
                CmbDepartment.ValueMember = "DepartmentID"

                ' ✅ Do not auto-select any department
                CmbDepartment.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message)
        End Try
    End Sub

    Private Sub EmployeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartmentsForEmployee()
        LoadEmployee()
        txtEmployeeID.ReadOnly = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "INSERT INTO Employees (FullName, Gender, Email, Phone, DepartmentID) 
                                       VALUES (@FullName, @Gender, @Email, @Phone, @DepartmentID);
                                       SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Gender", CmbGender.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbDepartment.SelectedValue))

                    Dim newID As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    CurrentEmployeeID = newID
                End Using
            End Using

            MessageBox.Show("Employee saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadEmployee()
        Catch ex As Exception
            MessageBox.Show("Error saving: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "UPDATE Employees 
                                       SET FullName=@FullName, Gender=@Gender, Email=@Email, Phone=@Phone, DepartmentID=@DepartmentID 
                                       WHERE EmployeeID=@EmployeeID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", CurrentEmployeeID)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Gender", CmbGender.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbDepartment.SelectedValue))

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Employee updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadEmployee()
                    Else
                        MessageBox.Show("Update failed. EmployeeID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating: " & ex.Message)
        End Try
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Dim EmployeeDetails As New Dashboard1
        EmployeeDetails.Show()
        Me.Hide()
    End Sub
End Class
