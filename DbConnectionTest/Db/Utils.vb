Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Db
  Friend Class Utils
    ''' <summary>
    ''' This connection string is used for EF6 Code First
    ''' operations initiated from the Package Manager
    ''' Console, e.g. Add-Migration, Update-Database, etc.
    ''' </summary>
    ''' <returns>A connection string.</returns>
    Friend Shared ReadOnly Property DesignTimeConnectionString() As String
      Get
        With New SqlConnectionStringBuilder
          .MultipleActiveResultSets = True
          .PersistSecurityInfo = False
          .IntegratedSecurity = False
          .InitialCatalog = DB_NAME
          .DataSource = Environment.MachineName
          .Password = ""
          .UserID = ""

          Return .ConnectionString
        End With
      End Get
    End Property



    ''' <summary>
    ''' This connection string is used for application runtime
    ''' operations, e.g. loading data for display on web pages.
    ''' </summary>
    ''' <returns>A connection string.</returns>
    Friend Shared ReadOnly Property RunTimeConnectionString() As String
      Get
        Return ConfigurationManager.ConnectionStrings(DB_NAME).ConnectionString
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
