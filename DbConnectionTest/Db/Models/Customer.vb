Imports System.Collections.Generic

Namespace Db.Models
  Public Class Customer
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Orders As New List(Of Invoice)
  End Class
End Namespace
