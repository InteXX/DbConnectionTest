<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DbConnectionTest._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Db Connection Test</title>
  <style>
    #txtLog {
      vertical-align: top;
      white-space: pre;
      height:500px;
      width:1000px;
    }
  </style>
</head>
<body>
  <form id="frmForm" runat="server">
    <div>
    </div>
    <textarea id="txtLog" runat="server" />
  </form>
</body>
</html>
