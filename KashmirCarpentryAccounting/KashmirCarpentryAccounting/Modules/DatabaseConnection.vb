Imports System.Data.SqlClient
Imports System.Configuration

Namespace KashmirCarpentryAccounting.Modules
    Public Module DatabaseConnection
        Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("KashmirCarpentryDB").ConnectionString

        Public Function GetConnection() As SqlConnection
            Return New SqlConnection(connectionString)
        End Function

        Public Function ExecuteQuery(query As String, parameters As SqlParameter()) As DataTable
            Dim dataTable As New DataTable()
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using
            Return dataTable
        End Function

        Public Function ExecuteNonQuery(query As String, parameters As SqlParameter()) As Integer
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    Return command.ExecuteNonQuery()
                End Using
            End Using
        End Function

        Public Function ExecuteScalar(query As String, parameters As SqlParameter()) As Object
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    Return command.ExecuteScalar()
                End Using
            End Using
        End Function
    End Module
End Namespace
