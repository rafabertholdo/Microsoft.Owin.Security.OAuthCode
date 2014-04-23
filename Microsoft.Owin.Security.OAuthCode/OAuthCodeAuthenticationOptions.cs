using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuthCode
{
    public class OAuthCodeAuthenticationOptions : AuthenticationOptions
    {
        public Uri AuthorizeEndpoint { get; set; }
        public Uri TokenEndpoint { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }        
        public string Issuer { get; set; }
        public IList<string> AllowedAudiences { get; set; }
        public string SymmetricSigningKey { get; set; }
        public IOAuthCodeAuthenticationProvider Provider { get; set; }
        /// <summary>
        /// Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user <see cref="System.Security.Claims.ClaimsIdentity"/>.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the a pinned certificate validator to use to validate the endpoints used
        /// in back channel communications belong to Facebook.
        /// </summary>
        /// <value>
        /// The pinned certificate validator.
        /// </value>
        /// <remarks>If this property is null then the default certificate checks are performed,
        /// validating the subject name and if the signing chain is a trusted party.</remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with Facebook.
        /// </summary>
        /// <value>
        /// The back channel timeout in milliseconds.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to communicate with Facebook.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value 
        /// can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }
                
        public OAuthCodeAuthenticationOptions()
            : this(OAuthCodeAuthenticationDefaults.AuthenticationType)
        {            
            CallbackPath = new PathString("/signin");
        }

        public OAuthCodeAuthenticationOptions(string authenticationType)
            : base(authenticationType)
        {
            AuthenticationMode = AuthenticationMode.Active;            
            CallbackPath = new PathString("/signin");            
            BackchannelTimeout = TimeSpan.FromMinutes(1);            
        }       
    }
}

