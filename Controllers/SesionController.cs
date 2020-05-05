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
        public IEnumerable<System.Security.Claims.Claim> Get()
        {
            IEnumerable<System.Security.Claims.Claim> claims = null;

            var identity = (System.Security.Claims.ClaimsIdentity)User.Identity;
            claims = identity.Claims;

            return claims;
        }

        // DELETE: api/ejemplo/
        public void Delete()
        {
            string url = "http://tst.autenticar.gob.ar/auth/realms/" + WebConfigurationManager.AppSettings["Authority"] +
                         "/protocol/openid-connect/logout";
            System.Uri uri = new System.Uri(url);
            Redirect(uri);
        }
    }
}
