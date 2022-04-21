using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmirApi.Core.Aspects.Autofac.Logging.AD
{
  public  class ActiveDirectoryHelpers
    {
        public static string GetCurrentActiveDirectoryUserName()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            return windowsIdentity.Name.Split('\\').Last();
        }
    }
}
