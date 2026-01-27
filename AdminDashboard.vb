Public Class AdminDashboard
    Private Sub ViewEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EmployeeManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeManagementToolStripMenuItem.Click
        Dim frm2 As New EmployeeManagement
        frm2.Show()
        Me.Hide()   ' hides login form


    End Sub

    Private Sub AddDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDepartmentToolStripMenuItem.Click

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
End Class
