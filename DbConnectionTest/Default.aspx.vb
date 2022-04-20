Imports System
Imports System.Diagnostics.CodeAnalysis
Imports System.Linq
Imports System.Web.UI
Imports DbConnectionTest.Db

<SuppressMessage("Style", "IDE1006:Naming Styles", Justification:="<Pending>")>
Public Class _Default
  Inherits Page

  Protected Sub Page_Load(Sender As _Default, e As EventArgs) Handles Me.Load
    Dim sValue As String

    Try
      Using oDb As Context = Db.Context.Create
        Me.txtLog.Value = oDb.Customers.First.FullName
      End Using

    Catch ex As Exception
      sValue = $"Connection string: {Utils.DbConnectionString}
Can connect via ADO.NET: {Utils.CanConnect(Utils.DbConnectionString)}

Error when attempting to connect via EntityFramework:
{ex}"

      Me.txtLog.Value = sValue

    End Try
  End Sub
End Class
