<%@ Application Language="C#" %>

<script runat="server">
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        // Allow https pages in debugging
        if (Request.IsLocal)
        {
            if (Request.Url.Scheme == "http")
            {
                int localSslPort = 44360; // Your local IIS port for HTTPS

                var path = "https://" + Request.Url.Host + ":" + localSslPort + Request.Url.PathAndQuery;

                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", path);
            }
        }
        else
        {
            switch (Request.Url.Scheme)
            {
                case "https":
                    Response.AddHeader("Strict-Transport-Security", "max-age=31536000");
                    break;
                case "http":
                    var path = "https://" + Request.Url.Host + Request.Url.PathAndQuery;
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", path);
                    break;
            }
        }
    }

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
