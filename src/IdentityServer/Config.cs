// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
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

                    AllowedCorsOrigins = { "https://localhost:5015" },
                    RedirectUris = { "https://localhost:5015/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5015/authentication/logout-callback" },

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

                    AllowedCorsOrigins = { "https://localhost:5017" },
                    RedirectUris = { "https://localhost:5017/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5017/authentication/logout-callback" },

                    AllowedScopes = {"openid", "profile", "api1", "api2" },
                },

                // WebForm JavaScript Client
                new Client
                {
                    ClientId = "WebFormAppJavaScriptClient",
                    ClientName = "WebForm Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://localhost:44360/Login.aspx?callback=1" },
                    PostLogoutRedirectUris = { "https://localhost:44360/Login.aspx" },
                    AllowedCorsOrigins =     { "https://localhost:44360" },

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

                    RedirectUris =           { "https://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "https://localhost:5003" },

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