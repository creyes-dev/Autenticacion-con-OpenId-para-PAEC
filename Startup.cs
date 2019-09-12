using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Keycloak;
using System;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(ENOHSA_PAEC.Startup))]

namespace ENOHSA_PAEC
{
    public class Startup
    {
        // Inicialización del tipo de autenticación que será utilizada por defecto
        const string persistentAuthType = CookieAuthenticationDefaults.AuthenticationType;
        
        // Configurar el middleware de autenticación de OWIN por medio de cookies
        public void Configuration(IAppBuilder app)
        {
            // Configurar la autenticación por medio de cookies para que sea persistente, esto quiere decir 
            // que se va a mantener la sesión del usuario sin cerrarse mientras se envían los requests 
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = persistentAuthType
            });

            app.SetDefaultSignInAsAuthenticationType(persistentAuthType);

            // La autenticación se efectúa por medio de Keycloak, se debe configurar 
            // las opciones de autenticación con la que se conectará al servicio Keycloack
            app.UseKeycloakAuthentication(new KeycloakAuthenticationOptions
            {
                Realm = WebConfigurationManager.AppSettings["RealmId"],
                ClientId = WebConfigurationManager.AppSettings["ClientId"],
                ClientSecret = WebConfigurationManager.AppSettings["ClientSecret"],
                KeycloakUrl = WebConfigurationManager.AppSettings["Authority"],
                AuthenticationType = persistentAuthType,
                SignInAsAuthenticationType = persistentAuthType,
                AllowUnsignedTokens = false,
                DisableIssuerSigningKeyValidation = false,
                DisableIssuerValidation = false,
                DisableAudienceValidation = false,
                TokenClockSkew = TimeSpan.FromSeconds(2)
            });
            
        }
    }
}
