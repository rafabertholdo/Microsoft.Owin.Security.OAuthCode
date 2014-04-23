using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Microsoft.Owin.Security.OAuthCode
{
    public class OAuthCodeAuthenticatedContext : BaseContext
    {
         /// <summary>
        /// Initializes a <see cref="FacebookAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The JSON-serialized user</param>
        /// <param name="accessToken">Facebook Access token</param>
        /// <param name="expires">Seconds until expiration</param>
        public OAuthCodeAuthenticatedContext(IOwinContext context, string userName, string accessToken, string code, string expires)
            : base(context)
        {
            UserName = userName;
            AccessToken = accessToken;
            Code = code;

            int expiresValue;
            if (Int32.TryParse(expires, NumberStyles.Integer, CultureInfo.InvariantCulture, out expiresValue))
            {
                ExpiresIn = TimeSpan.FromSeconds(expiresValue);
            }

            
        }

        /// <summary>
        /// Gets the JSON-serialized user
        /// </summary>
        //public JObject User { get; private set; }
        public string UserName { get; set; }
        
        public string Code { get; set; }
        /// <summary>
        /// Gets the Facebook access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the Facebook access token expiration time
        /// </summary>
        public TimeSpan? ExpiresIn { get; set; }

        /// <summary>
        /// Gets the Facebook user ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the user's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Facebook email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}
