using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin.Security.Providers.PortalForArcGIS.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.PortalForArcGIS
{
    public class PortalForArcGISAuthenticationOptions : AuthenticationOptions
    {
        public class PortalForArcGISAuthenticationEndpoints
        {
            /// <summary>
            /// Endpoint which is used to redirect users to request Portal For ArcGIS access
            /// </summary>
            /// <remarks>
            /// Defaults to https://www.arcgis.com/sharing/oauth2/authorize
            /// </remarks>
            public string AuthorizationEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to exchange code for access token
            /// </summary>
            /// <remarks>
            /// Defaults to https://www.arcgis.com/sharing/oauth2/token
            /// </remarks>
            public string TokenEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to obtain user information after authentication
            /// </summary>
            /// <remarks>
            /// Defaults to https://www.arcgis.com/sharing/rest/accounts/self
            /// </remarks>
            public string UserInfoEndpoint { get; set; }
        }

        private string AuthorizationEndPoint = "/sharing/oauth2/authorize";
        private const string TokenEndpoint = "/sharing/oauth2/token";
        private const string UserInfoEndpoint = "/sharing/rest/accounts/self";

        /// <summary>
        ///     Gets or sets the a pinned certificate validator to use to validate the endpoints used
        ///     in back channel communications belong to Portal For ArcGIS.
        /// </summary>
        /// <value>
        ///     The pinned certificate validator.
        /// </value>
        /// <remarks>
        ///     If this property is null then the default certificate checks are performed,
        ///     validating the subject name and if the signing chain is a trusted party.
        /// </remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        ///     The HttpMessageHandler used to communicate with Portal For ArcGIS.
        ///     This cannot be set at the same time as BackchannelCertificateValidator unless the value
        ///     can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        ///     Gets or sets timeout value in milliseconds for back channel communications with Portal For ArcGIS.
        /// </summary>
        /// <value>
        ///     The back channel timeout in milliseconds.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        ///     The request path within the application's base path where the user-agent will be returned.
        ///     The middleware will process this request when it arrives.
        ///     Default value is "/signin-PortalForArcGIS".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        ///     Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        ///     Gets or sets the Portal For ArcGIS supplied Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the Portal For ArcGIS supplied Client Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets the sets of OAuth endpoints used to authenticate against Portal For ArcGIS.  Overriding these endpoints allows you to use Portal For ArcGIS Enterprise for
        /// authentication. 
        /// </summary>
        public PortalForArcGISAuthenticationEndpoints Endpoints { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPortalForArcGISAuthenticationProvider" /> used in the authentication events
        /// </summary>
        public IPortalForArcGISAuthenticationProvider Provider { get; set; }

        /// <summary>
        /// A list of permissions to request.
        /// </summary>
        public IList<string> Scope { get; private set; }

        /// <summary>
        ///     Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user
        ///     <see cref="System.Security.Claims.ClaimsIdentity" />.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        ///     Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        /// <summary>
        /// Initializes a new <see cref="ArcGISOnlineAuthenticationOptions" />
        /// </summary>
        /// <param name="portalUrl">URL String for Portal such as https://<orgname>.arcgis.com </param>
        public PortalForArcGISAuthenticationOptions(string portalUrl)
            : base("Portal For ArcGIS")
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-portal-for-arcgis");
            AuthenticationMode = AuthenticationMode.Passive;
            Scope = new List<string>
            {
                "code"
            };
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            Endpoints = new PortalForArcGISAuthenticationEndpoints
            {
                AuthorizationEndpoint = portalUrl+ AuthorizationEndPoint,
                TokenEndpoint = portalUrl +  TokenEndpoint,
                UserInfoEndpoint = portalUrl + UserInfoEndpoint
            };
        }
    }
}
