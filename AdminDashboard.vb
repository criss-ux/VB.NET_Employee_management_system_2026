Public Class AdminDashboard
    Private Sub ViewEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EmployeeManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeManagementToolStripMenuItem.Click
        Dim frm2 As New EmployeeManagement
        frm2.Show()
        Me.Hide()   ' hides login form


    End Sub

    Private Sub AddDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to logout?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.Yes Then
            Adminlogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click

    End Sub

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub ManageDepartmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageDepartmentsToolStripMenuItem.Click
        Dim AdminDashboard As New AddDepartment
        AdminDashboard.Show()
        Me.Hide()
    End Sub


    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        Dim AdminDashboard As New BackUpDatabase   ' Employee login form
        AdminDashboard.Show()
        Me.Hide()
    End Sub
End Class
