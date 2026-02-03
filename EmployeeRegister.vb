Imports MySql.Data.MySqlClient

Public Class EmployeeRegister
    Dim connString As String = "server=localhost;userid=root;password=;database=employee_db"

    Public Property CurrentEmployeeID As Integer

    ' ============================
    ' Load only the logged-in employee into DataGridView and form
    ' ============================
    Private Sub LoadEmployee()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "
                    SELECT e.EmployeeID, e.FullName, e.Gender, e.Phone, e.Email, d.DepartmentName
                    FROM employee e
                    JOIN department d ON e.DepartmentID = d.DepartmentID
                    WHERE e.EmployeeID = @EmployeeID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@EmployeeID", CurrentEmployeeID)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgvEmployees.DataSource = Nothing
                dgvEmployees.DataSource = table
                dgvEmployees.Refresh()

                If dgvEmployees.Columns.Contains("EmployeeID") Then
                    dgvEmployees.Columns("EmployeeID").Visible = False
                End If

                ' ✅ Auto-fill form from first row
                If table.Rows.Count > 0 Then
                    Dim row As DataRow = table.Rows(0)
                    txtEmployeeID.Text = row("EmployeeID").ToString()
                    txtFullname.Text = row("FullName").ToString()
                    cmbGender.Text = row("Gender").ToString()
                    txtPhone.Text = row("Phone").ToString()
                    txtEmail.Text = row("Email").ToString()
                    cmbDepartment.Text = row("DepartmentName").ToString()
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
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT DepartmentID, DepartmentName FROM Department"
                Dim cmd As New MySqlCommand(query, conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                Dim dt As New DataTable()
                dt.Load(reader)

                cmbDepartment.DataSource = dt
                cmbDepartment.DisplayMember = "DepartmentName"
                cmbDepartment.ValueMember = "DepartmentID"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message)
        End Try
    End Sub

    ' ============================
    ' Save new employee
    ' ============================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "INSERT INTO Employee (FullName, Gender, Email, Phone, DepartmentID) 
                                       VALUES (@FullName, @Gender, @Email, @Phone, @DepartmentID);
                                       SELECT LAST_INSERT_ID();"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(cmbDepartment.SelectedValue))

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

    ' ============================
    ' Edit existing employee
    ' ============================
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "UPDATE Employee 
                                       SET FullName=@FullName, Gender=@Gender, Email=@Email, Phone=@Phone, DepartmentID=@DepartmentID 
                                       WHERE EmployeeID=@EmployeeID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", CurrentEmployeeID)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(cmbDepartment.SelectedValue))

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

    ' ============================
    ' Form Load
    ' ============================
    Private Sub EmployeeRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartmentsForEmployee()
        LoadEmployee()
        txtEmployeeID.ReadOnly = True
    End Sub

    ' ============================
    ' Navigation
    ' ============================
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm2 As New EmployeeDashboard
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class
