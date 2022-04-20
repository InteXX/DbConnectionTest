Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Db
  Friend Class Utils
    Friend Shared ReadOnly Property DbConnectionString() As String
      Get
        If ConfigurationManager.ConnectionStrings Is Nothing Then
          With New SqlConnectionStringBuilder
            .MultipleActiveResultSets = True
            .PersistSecurityInfo = False
            .IntegratedSecurity = False
            .InitialCatalog = DB_NAME
            .DataSource = Environment.MachineName
            .Password = ""
            .UserID = ""

            DbConnectionString = .ConnectionString
          End With
        Else
          DbConnectionString = ConfigurationManager.ConnectionStrings(DB_NAME).ConnectionString
        End If
      End Get
    End Property



    Public Shared Function CanConnect(ConnectionString As String) As Boolean
      CanConnect = True

      Try
        ExecuteNonQuery("SELECT * FROM INFORMATION_SCHEMA.TABLES", ConnectionString)

      Catch ex As Exception
        CanConnect = False

      End Try
    End Function



    Friend Shared Function ExecuteNonQuery(CommandText As String, ConnectionString As String) As Integer
      Using oSqlCnn As New SqlConnection(ConnectionString)
        Using oSqlCmd As SqlCommand = oSqlCnn.CreateCommand
          oSqlCmd.CommandType = CommandType.Text
          oSqlCmd.CommandText = CommandText
          oSqlCnn.Open()

          Return oSqlCmd.ExecuteNonQuery
        End Using
      End Using
    End Function



    Friend Const DB_NAME As String = "DbConnectionTest"
  End Class
End Namespace
