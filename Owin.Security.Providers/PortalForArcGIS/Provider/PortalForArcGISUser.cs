using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.PortalForArcGIS.Provider
{
    public class PortalForArcGISUser
    {
        public User user { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
