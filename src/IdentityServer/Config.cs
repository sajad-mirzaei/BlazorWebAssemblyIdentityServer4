// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static Dictionary<string, string> Origins = new()
        {
            { "idp", "https://server-devops:7000" },
            { "api1", "https://server-devops:7011" },
            { "api2", "https://server-devops:7012" },
            { "api3", "https://server-devops:7013" },
            { "WebAssemblyClient1", "https://server-devops:7021" },
            { "WebAssemblyClient2", "https://server-devops:7022" },
            { "NetCoreJavaScriptClient", "https://server-devops:7023" },
            { "WebFormAppJavaScriptClient", "https://server-devops:44360" },
            { "WebFormCSharpClient", "https://server-devops:44350" }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                /*new ApiResource("WebApi1_Resource1", "سرویس هواشناسی")
                {
                    Scopes = { "WebApi1_Scope1.read", "WebApi1_Scope1.write", "manage" }
                }*/
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "سرویس هواشناسی 1"),
                new ApiScope("api2", "سرویس هواشناسی 2"),
                new ApiScope("api3", "سرویس کمک هواشناسی 3")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Blazor WebAssembly Client 1
                new Client
                {
                    ClientId = "WebAssemblyClient1",
                    ClientName = "Blazor Webassembly App Client 1",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowedCorsOrigins = { Origins["WebAssemblyClient1"] },
                    RedirectUris = { Origins["WebAssemblyClient1"] + "/authentication/login-callback" },
                    PostLogoutRedirectUris = { Origins["WebAssemblyClient1"] + "/authentication/logout-callback" },

                    AllowedScopes = {"openid", "profile", "api1", "api2" },
                },

                // Blazor WebAssembly Client 2
                new Client
                {
                    ClientId = "WebAssemblyClient2",
                    ClientName = "Blazor Webassembly App Client 2",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowedCorsOrigins = { Origins["WebAssemblyClient2"] },
                    RedirectUris = { Origins["WebAssemblyClient2"] + "/authentication/login-callback" },
                    PostLogoutRedirectUris = { Origins["WebAssemblyClient2"] + "/authentication/logout-callback" },

                    AllowedScopes = {"openid", "profile", "api1", "api2" },
                },

                // WebForm JavaScript Client
                new Client
                {
                    ClientId = "WebFormAppJavaScriptClient",
                    ClientName = "WebForm Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { Origins["WebFormAppJavaScriptClient"] + "/Login.aspx?callback=1" },
                    PostLogoutRedirectUris = { Origins["WebFormAppJavaScriptClient"] + "/Login.aspx" },
                    AllowedCorsOrigins =     { Origins["WebFormAppJavaScriptClient"] },

                    AllowedScopes = { "openid", "profile", "api1", "api2" }
                },

                // WebForm CSharp Client
                new Client
                {
                    ClientId = "WebFormAppCSharpClient",
                    ClientName = "WebForm Client",
                    ClientSecrets = new List<Secret>{ new Secret("123456".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "openid", "profile", "api1", "api2" }
                },

                // .NetCore JavaScript Client
                new Client
                {
                    ClientId = "NetCoreJavaScriptClient",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { Origins["NetCoreJavaScriptClient"] + "/callback.html" },
                    PostLogoutRedirectUris = { Origins["NetCoreJavaScriptClient"] + "/index.html" },
                    AllowedCorsOrigins =     { Origins["NetCoreJavaScriptClient"] },

                    AllowedScopes = { "openid", "profile", "api1", "api2" }
                },
                
                // Api2 Client connect to Api3
                new Client
                {
                    ClientId = "api2.client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api3" }
                }
            };
    }
}