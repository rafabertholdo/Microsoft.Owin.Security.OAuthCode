using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuthCode
{
    public static class OAuthCodeAuthenticationExtensions
    {
        public static IAppBuilder UseOAuthCodeAuthentication(this IAppBuilder app, OAuthCodeAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use<OAuthCodeAuthenticationMiddleware>(app, options);            

            return app;
        }

    }
}
