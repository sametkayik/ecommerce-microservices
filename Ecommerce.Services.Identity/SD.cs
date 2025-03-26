using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Ecommerce.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> {
                new ApiScope("DefineX", "DefineX Server"),
                new ApiScope(name: "read",   displayName: "Veri Okuyabilir."),
                new ApiScope(name: "write",  displayName: "Veri Yazabiliri"),
                new ApiScope(name: "delete", displayName: "Veri Silebilir")
        };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "read", "write","profile"}
                },
                new Client
                {
                    ClientId="DefineX",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RedirectUris={ "https://localhost:44378/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:44378/signout-callback-oidc" },
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "DefineX"
                    }
                },
            };
    }
}
