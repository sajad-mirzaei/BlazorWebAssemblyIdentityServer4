<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
</head>
<body>
    WebForm JavaScript Client Login page..

        <hr />


    <button id="login">Login</button>
    <button id="api">Call API</button>
    <button id="logout">Logout</button>

    <pre id="results"></pre>

    <script src="Assets/oidc-client/oidc-client.js"></script>
    <script src="Assets/oidc-client/app.js"></script>

    <script>
        var callback = new URL(location.href).searchParams.get("callback");
        if (callback) {
            new Oidc.UserManager({ response_mode: "query" }).signinRedirectCallback().then(function () {
                window.location = "Login.aspx";
            }).catch(function (e) {
                console.error(e);
            });
        }
    </script>
</body>
</html>
