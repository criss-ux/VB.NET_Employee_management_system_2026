Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class BackUpDatabase

    ' ✅ Connection string points to SQL Server EmployeeDB
    ' Replace YOUR_SERVER_NAME with your SQL Server instance (e.g., "localhost", "SQLEXPRESS", or "Criss-Johnson")
    Dim connString As String = "Server=localhost;Database=EmployeeDB;Integrated Security=True;"

    Private Sub BackUpDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: create backup folder if missing
        If Not Directory.Exists("C:\Backups") Then
            Directory.CreateDirectory("C:\Backups")
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        BackupDatabase()
    End Sub

    Private Sub BackupDatabase()
        Try
            ' Path to save backup file
            Dim backupFile As String = "C:\Backups\EmployeeDB_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".bak"

            Using conn As New SqlConnection(connString)
                conn.Open()

                ' ✅ SQL Server BACKUP DATABASE command
                Dim query As String = "BACKUP DATABASE EmployeeDB TO DISK = @backupFile WITH INIT, FORMAT, NAME = 'EmployeeDB-FullBackup'"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@backupFile", backupFile)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Backup completed successfully! File saved at: " & backupFile,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error running backup: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Dim frm2 As New AdminDashboard
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim frm2 As New AdminDashboard
        frm2.Show()
        Me.Hide()
    End Sub
End Class
