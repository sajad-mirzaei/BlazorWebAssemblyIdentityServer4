<%@ Page Language="C#" AutoEventWireup="false" CodeFile="LoginCallBack.aspx.cs" Inherits="CallBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="Assets/oidc-client/oidc-client.js"></script>
        <script>
            new Oidc.UserManager({ response_mode: "query" }).signinRedirectCallback().then(function () {
                window.location = "Login.aspx";
            }).catch(function (e) {
                console.error(e);
            });
        </script>
    </form>
</body>
</html>
