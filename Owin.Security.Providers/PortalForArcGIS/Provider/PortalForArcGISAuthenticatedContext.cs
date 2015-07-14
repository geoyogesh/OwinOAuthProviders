using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.PortalForArcGIS.Provider
{
    /// <summary>
    /// Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.
    /// </summary>
    public class PortalForArcGISAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="PortalForArcGISAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The Portal For ArcGIS user</param>
        /// <param name="accessToken">Portal For ArcGIS Access token</param>
        public PortalForArcGISAuthenticatedContext(IOwinContext context, PortalForArcGISUser user, string accessToken)
            : base(context)
        {
            AccessToken = accessToken;

            Id = user.user.username;
            Name = user.user.fullName;
            Link = "https://www.arcgis.com/sharing/rest/community/users/" + Id;
            UserName = Id;
            Email = user.user.email;
        }

        /// <summary>
        /// Gets the Portal For ArcGIS access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the Portal For ArcGIS user ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the user's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the user's email
        /// </summary>
        public string Email { get; private set; }

        public string Link { get; private set; }

        /// <summary>
        /// Gets the Portal For ArcGIS username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }
    }
}
