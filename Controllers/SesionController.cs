using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;

namespace ENOHSA_PAEC.Controllers
{
    [Authorize]
    public class SesionController : ApiController
    {
        // GET api/sesion/
        public string Get()
        {
            return User.Identity.Name;
        }

        // DELETE: api/ejemplo/
        public void Delete()
        {
            string url = "http://tst.autenticar.gob.ar/auth/realms/" + WebConfigurationManager.AppSettings["Authority"] +
                         "/protocol/openid-connect/logout?redirect_uri=http://server/app/close-session";
            System.Uri uri = new System.Uri(url);
            Redirect(uri);
        }
    }
}
