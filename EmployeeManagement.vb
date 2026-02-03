Imports MySql.Data.MySqlClient

Public Class EmployeeManagement

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=employee_db")

    Private Sub EmployeeManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeData()
        DataGridView1.ReadOnly = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub LoadEmployeeData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
                SELECT e.EmployeeID, e.FullName, e.Gender, e.Phone, d.DepartmentName
                FROM employee e
                JOIN department d ON e.DepartmentID = d.DepartmentID"

            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.CurrentRow IsNot Nothing AndAlso DataGridView1.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim empID As String = DataGridView1.CurrentRow.Cells(0).Value.ToString()

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this employee?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Try
                    conn.Open()
                    Dim query As String = "DELETE FROM employee WHERE EmployeeID = @EmployeeID"
                    Dim cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", empID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Employee deleted successfully.")
                    LoadEmployeeData()
                Catch ex As Exception
                    MessageBox.Show("Delete failed: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Please select a valid employee row to delete.")
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim searchText As String = txtSearch.Text.Trim()

            Dim query As String = "
                SELECT e.EmployeeID, e.FullName, e.Gender, e.Phone, d.DepartmentName
                FROM employee e
                JOIN department d ON e.DepartmentID = d.DepartmentID
                WHERE e.FullName LIKE @search OR d.DepartmentName LIKE @search"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm2 As New AdminDashboard
        frm2.Show()
        Me.Hide()
    End Sub

End Class
