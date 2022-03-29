using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var client = new RestClient("https://localhost:5001/connect/token")
        {
            Timeout = -1
        };
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("client_id", "WebFormAppCSharpClient");
        request.AddParameter("client_secret", "123456");
        request.AddParameter("grant_type", "client_credentials");
        IRestResponse response = client.Execute(request);
        var x = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        if (x != null && x["access_token"] != null)
        {
            var client2 = new RestClient("https://localhost:6001/identity")
            {
                Timeout = -1
            };
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("Authorization", "Bearer " + x["access_token"]);
            IRestResponse response2 = client2.Execute(request2);
            ApiData.Text = response2.Content;
            Token.Text = x["access_token"];
        }
    }
}