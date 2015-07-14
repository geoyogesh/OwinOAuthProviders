using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.PortalForArcGIS
{
    public static class PortalForArcGISAuthenticationExtensions
    {
        public static IAppBuilder UsePortalForArcGISAuthentication(this IAppBuilder app,
            PortalForArcGISAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            if (options == null)
                throw new ArgumentNullException("options");

            app.Use(typeof(PortalForArcGISAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UsePortalForArcGISAuthentication(this IAppBuilder app, string clientId, string clientSecret,string portalurl)
        {
            return app.UsePortalForArcGISAuthentication(new PortalForArcGISAuthenticationOptions(portalurl)
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}
