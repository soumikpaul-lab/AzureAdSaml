using System.Configuration;
using Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Microsoft.IdentityModel.Logging;

namespace WebApp_Saml
{
    public partial class Startup
    {
        private static string _realm = ConfigurationManager.AppSettings["ida:Wtrealm"];
        private static string _adfsMetadata = ConfigurationManager.AppSettings["ida:ADFSMetadata"];

        public void ConfigureAuth(IAppBuilder app)
        {
            IdentityModelEventSource.ShowPII = true;
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    Wtrealm = _realm,
                    MetadataAddress = _adfsMetadata,
                    Wreply = "https://localhost:44311/"
                });
        }
    }
}