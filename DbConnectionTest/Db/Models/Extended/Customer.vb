Namespace Db.Models
  Partial Public Class Customer
    Public ReadOnly Property FullName As String
      Get
        Return $"{Me.FirstName} {Me.LastName}"
      End Get
    End Property
  End Class
End Namespace
