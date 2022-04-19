Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.ModelConfiguration
Imports DbConnectionTest.Db.Models

Namespace Db.Configurations
  Public Class CustomerConfiguration
    Inherits EntityTypeConfiguration(Of Customer)

    Public Sub New()
      Me.Property(Function(Customer) Customer.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
      Me.Property(Function(Customer) Customer.FirstName).IsRequired.HasMaxLength(25)
      Me.Property(Function(Customer) Customer.LastName).IsRequired.HasMaxLength(25)
    End Sub
  End Class
End Namespace
