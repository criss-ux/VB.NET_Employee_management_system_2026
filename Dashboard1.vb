Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Dashboard1
    ' Example: reusable SQL Server connection string
    ' Use Integrated Security for Windows Authentication
    ' Or specify User Id and Password for SQL Authentication
    Private connStr As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True;"

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnHome.Click

    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        Dim frm2 As New EmployeeDetails
        frm2.Show()
        Me.Hide()   ' hides dashboard
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            LoginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Dashboard1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Example: test SQL Server connection on load
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                ' Optional: show a quick confirmation
                Console.WriteLine("Connected to SQL Server successfully!")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error connecting to SQL Server: " & ex.Message)
        End Try
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Dashboard As New Resert
        Dashboard.Show()
        Me.Hide()
    End Sub
End Class
