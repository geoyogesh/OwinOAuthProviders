using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.PortalForArcGIS.Provider
{
    /// <summary>
    /// Default <see cref="IPortalForArcGISAuthenticationProvider"/> implementation.
    /// </summary>
    public class PortalForArcGISAuthenticationProvider : IPortalForArcGISAuthenticationProvider
    {
        /// <summary>
        /// Initializes a <see cref="PortalForArcGISAuthenticationProvider"/>
        /// </summary>
        public PortalForArcGISAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
        }

        /// <summary>
        /// Gets or sets the function that is invoked when the Authenticated method is invoked.
        /// </summary>
        public Func<PortalForArcGISAuthenticatedContext, Task> OnAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the function that is invoked when the ReturnEndpoint method is invoked.
        /// </summary>
        public Func<PortalForArcGISReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

        /// <summary>
        /// Invoked whenever Portal For ArcGIS succesfully authenticates a user
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task Authenticated(PortalForArcGISAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        /// <summary>
        /// Invoked prior to the <see cref="System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task ReturnEndpoint(PortalForArcGISReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }
    }
}
