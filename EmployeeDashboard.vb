Public Class EmployeeDashboard
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim frm2 As New EmployeeRegister
        frm2.Show()
        Me.Hide()   ' hides login form

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to logout?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.Yes Then
            EmployeeLogin2.Show()
            Me.Close()
        End If
    End Sub
End Class