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
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            string time = DateTime.Now.Millisecond.ToString();

            app.Run(async context => {
                await context.Response.WriteAsync(time + " " + "Welcome to OWIN Application");
            });            
        }
    }
}
