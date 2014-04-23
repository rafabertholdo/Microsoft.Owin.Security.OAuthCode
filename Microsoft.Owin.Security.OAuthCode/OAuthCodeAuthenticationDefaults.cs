using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuthCode
{
    public class OAuthCodeAuthenticationDefaults
    {
        public const string AuthenticationType = "OAuthCode";
                
        public const string CookiePrefix = "OAuthCode.";

        public const string CookieName = ".AspNet.Correlation.OAuthCode";        
    }
}
