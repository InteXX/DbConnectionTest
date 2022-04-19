Namespace Db.Models
  Public Class Invoice
    Public Property Id As Integer
    Public Property CustomerId As Integer
    Public Property Description As String
    Public Property Price As Decimal
    Public Property Qty As Integer
    Public Property Total As Decimal
    Public Property Customer As Customer
  End Class
End Namespace
