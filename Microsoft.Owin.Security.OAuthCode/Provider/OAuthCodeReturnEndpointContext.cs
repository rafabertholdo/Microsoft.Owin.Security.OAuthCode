using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Owin.Security.OAuthCode
{
    public class OAuthCodeReturnEndpointContext : ReturnEndpointContext
    {
        public OAuthCodeReturnEndpointContext(
            IOwinContext context,
            AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }
    }
}
