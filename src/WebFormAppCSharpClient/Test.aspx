<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            WebForm CSharp Client Test page..
            <hr />
            Api1 Data:<br /><br />
            <asp:Label ID="ApiData" runat="server"></asp:Label>
            <hr />
            Token:<br /><br />
            <asp:Label ID="Token" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
