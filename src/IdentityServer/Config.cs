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
            { "idp", "https://server-devops:7000/Idp" },
            { "api1", "https://server-devops:7000/Api1" },
            { "api2", "https://server-devops:7000/Api2" },
            { "api3", "https://server-devops:7000/Api3" },
            { "WebAssemblyClient1", "https://server-devops:7000/Wasm1" }
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
                    RedirectUris = { "https://server-devops:7000/Wasm1/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://server-devops:7000/Wasm1/authentication/logout-callback" },
           
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes = {"openid", "profile", "api1", "api2" },
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