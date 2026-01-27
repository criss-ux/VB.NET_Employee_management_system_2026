Imports MySql.Data.MySqlClient

Module DBConnection
    Public con As New MySqlConnection(
        "server=localhost;user id=root;password=;database=employee_management")

    Public Sub OpenCon()
        If con.State = ConnectionState.Closed Then con.Open()
    End Sub

    Public Sub CloseCon()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub
End Module
