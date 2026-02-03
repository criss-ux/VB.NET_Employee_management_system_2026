<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeManagement))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColumnEmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDepartmentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnEmployeeID, Me.ColumnFullName, Me.ColumnGender, Me.ColumnPhone, Me.ColumnDepartmentName})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 241)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1150, 465)
        Me.DataGridView1.TabIndex = 79
        '
        'ColumnEmployeeID
        '
        Me.ColumnEmployeeID.DataPropertyName = "EmployeeID"
        Me.ColumnEmployeeID.HeaderText = "EmployeeID"
        Me.ColumnEmployeeID.MinimumWidth = 8
        Me.ColumnEmployeeID.Name = "ColumnEmployeeID"
        Me.ColumnEmployeeID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnEmployeeID.Width = 150
        '
        'ColumnFullName
        '
        Me.ColumnFullName.DataPropertyName = "FullName"
        Me.ColumnFullName.HeaderText = "Fullname"
        Me.ColumnFullName.MinimumWidth = 8
        Me.ColumnFullName.Name = "ColumnFullName"
        Me.ColumnFullName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnFullName.Width = 150
        '
        'ColumnGender
        '
        Me.ColumnGender.DataPropertyName = "Gender"
        Me.ColumnGender.HeaderText = "Gender"
        Me.ColumnGender.MinimumWidth = 8
        Me.ColumnGender.Name = "ColumnGender"
        Me.ColumnGender.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnGender.Width = 150
        '
        'ColumnPhone
        '
        Me.ColumnPhone.DataPropertyName = "Phone"
        Me.ColumnPhone.HeaderText = "Phone"
        Me.ColumnPhone.MinimumWidth = 8
        Me.ColumnPhone.Name = "ColumnPhone"
        Me.ColumnPhone.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnPhone.Width = 150
        '
        'ColumnDepartmentName
        '
        Me.ColumnDepartmentName.DataPropertyName = "DepartmentName"
        Me.ColumnDepartmentName.HeaderText = "DepartmentName"
        Me.ColumnDepartmentName.MinimumWidth = 8
        Me.ColumnDepartmentName.Name = "ColumnDepartmentName"
        Me.ColumnDepartmentName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnDepartmentName.Width = 150
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(29, 139)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(381, 37)
        Me.txtSearch.TabIndex = 78
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 32)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Search"
        '
        'MySqlCommand1
        '
        Me.MySqlCommand1.CacheAge = 0
        Me.MySqlCommand1.Connection = Nothing
        Me.MySqlCommand1.EnableCaching = False
        Me.MySqlCommand1.Transaction = Nothing
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(789, 139)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(117, 59)
        Me.btnDelete.TabIndex = 75
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Blue
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(493, 139)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(115, 59)
        Me.btnSearch.TabIndex = 73
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(477, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 32)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Manage Employee"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1176, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(57, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(319, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(553, 45)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "EMPLOYEE MANAGEMENT SYSTEM"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Font = New System.Drawing.Font("Ebrima", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(-5, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1408, 87)
        Me.Panel1.TabIndex = 72
        '
        'EmployeeManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 698)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EmployeeManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EmployeeManagement1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ColumnEmployeeID As DataGridViewTextBoxColumn
    Friend WithEvents ColumnFullName As DataGridViewTextBoxColumn
    Friend WithEvents ColumnGender As DataGridViewTextBoxColumn
    Friend WithEvents ColumnPhone As DataGridViewTextBoxColumn
    Friend WithEvents ColumnDepartmentName As DataGridViewTextBoxColumn
End Class
