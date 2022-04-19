Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.ModelConfiguration
Imports DbConnectionTest.Db.Models

Namespace Db.Configurations
  Public Class InvoiceConfiguration
    Inherits EntityTypeConfiguration(Of Invoice)

    Public Sub New()
      Me.Property(Function(Order) Order.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
      Me.Property(Function(Order) Order.Description).IsRequired.HasMaxLength(100)
      Me.Property(Function(Order) Order.Price).IsRequired.HasColumnType("MONEY")
      Me.Property(Function(Order) Order.Qty).IsRequired()
      Me.Property(Function(Order) Order.Total).IsRequired.HasColumnType("MONEY")
    End Sub
  End Class
End Namespace
