Imports System.Data.Entity.Migrations

Namespace Migrations
  Partial Public Class _001
    Inherits DbMigration

    Public Overrides Sub Up()
      Me.CreateTable(
        "dbo.Customers",
        Function(c) New With
        {
          .Id = c.Int(nullable:=False, identity:=True),
          .FirstName = c.String(nullable:=False, maxLength:=25, defaultValue:=String.Empty),
          .LastName = c.String(nullable:=False, maxLength:=25, defaultValue:=String.Empty)
        }) _
        .PrimaryKey(Function(t) t.Id)

      Me.CreateTable(
        "dbo.Invoices",
        Function(c) New With
        {
          .Id = c.Int(nullable:=False, identity:=True),
          .CustomerId = c.Int(nullable:=False),
          .Description = c.String(nullable:=False, maxLength:=100, defaultValue:=String.Empty),
          .Price = c.Decimal(nullable:=False, storeType:="money", defaultValue:=0),
          .Qty = c.Int(nullable:=False, defaultValue:=0),
          .Total = c.Decimal(nullable:=False, storeType:="money", defaultValue:=0)
        }) _
        .PrimaryKey(Function(t) t.Id) _
        .ForeignKey("dbo.Customers", Function(t) t.CustomerId, cascadeDelete:=True) _
        .Index(Function(t) t.CustomerId)
    End Sub



    Public Overrides Sub Down()
      Me.DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers")
      Me.DropIndex("dbo.Invoices", New String() {"CustomerId"})
      Me.DropTable("dbo.Invoices")
      Me.DropTable("dbo.Customers")
    End Sub
  End Class
End Namespace
