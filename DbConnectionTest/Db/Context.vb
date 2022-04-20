Imports System.Data.Common
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Reflection
Imports DbConnectionTest.Db.Models

Namespace Db
  Public Class Context
    Inherits DbContext

    Public Sub New()
      MyBase.New(Utils.DbConnectionString)
    End Sub



    Private Sub New(Connection As DbConnection)
      MyBase.New(Connection, True)

      Database.SetInitializer(New CreateDatabaseIfNotExists(Of Context))
      Database.SetInitializer(New MigrateDatabaseToLatestVersion(Of Context, Migrations.Configuration))

      Me.Database.Initialize(False)
    End Sub



    Public Shared Function Create() As Context
      Return New Context(New SqlConnection(Utils.DbConnectionString))
    End Function



    Protected Overrides Sub OnModelCreating(Builder As DbModelBuilder)
      Builder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly)
      MyBase.OnModelCreating(Builder)
    End Sub



    Protected Overrides Sub Dispose(Disposing As Boolean)
      MyBase.Dispose(Disposing)
    End Sub



    Public Overridable Property Customers As DbSet(Of Customer)
    Public Overridable Property Invoices As DbSet(Of Invoice)
  End Class
End Namespace
