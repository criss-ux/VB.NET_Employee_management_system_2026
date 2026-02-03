Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.IO

Public Class BackUpDatabase

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
            Dim backupFile As String = "C:\Backups\employee_db_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"

            ' Path to mysqldump.exe (adjust if installed elsewhere)
            Dim mysqldumpPath As String = "C:\xampp\mysql\bin\mysqldump.exe"

            ' ✅ No password used
            Dim arguments As String = "-u root employee_db --result-file=""" & backupFile & """ --routines --events --triggers"

            ' Configure process
            Dim psi As New ProcessStartInfo()
            psi.FileName = mysqldumpPath
            psi.Arguments = arguments
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True

            ' Start process
            Dim process As Process = Process.Start(psi)
            process.WaitForExit()

            ' Check for errors
            Dim errorOutput As String = process.StandardError.ReadToEnd()
            If String.IsNullOrEmpty(errorOutput) Then
                MessageBox.Show("Backup completed successfully! File saved at: " & backupFile,
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Backup failed: " & errorOutput,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error running backup: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm2 As New AdminDashboard
        frm2.Show()
        Me.Hide()
    End Sub
End Class
