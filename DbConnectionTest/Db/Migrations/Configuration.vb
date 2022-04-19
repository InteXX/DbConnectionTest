Imports System.Collections.Generic
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports DbConnectionTest.Db.Models

Namespace Migrations
  Friend NotInheritable Class Configuration
    Inherits DbMigrationsConfiguration(Of Db.Context)

    Public Sub New()
      Me.AutomaticMigrationsEnabled = False
      Me.MigrationsDirectory = "Db\Migrations"
    End Sub



    Protected Overrides Sub Seed(Db As Db.Context)
      Dim oCustomers As List(Of Customer)
      Dim oInvoices As List(Of Invoice)

      If Not Db.Customers.Any Then
        oCustomers = New List(Of Customer) From {
          New Customer With {.FirstName = "Fred", .LastName = "Flintstone"},
          New Customer With {.FirstName = "Barney", .LastName = "Rubble"}
        }

        oInvoices = New List(Of Invoice) From {
          New Invoice With {.Description = "Item1", .Price = 1.23, .Qty = 2, .Total = .Price * .Qty, .Customer = oCustomers.First},
          New Invoice With {.Description = "Item2", .Price = 4.56, .Qty = 3, .Total = .Price * .Qty, .Customer = oCustomers.First},
          New Invoice With {.Description = "Item3", .Price = 7.89, .Qty = 4, .Total = .Price * .Qty, .Customer = oCustomers.Last}
        }

        Db.Customers.AddOrUpdate(Function(Customer) Customer.Id, oCustomers.ToArray)
        Db.Invoices.AddOrUpdate(Function(Invoice) Invoice.Id, oInvoices.ToArray)
      End If
    End Sub
  End Class
End Namespace
