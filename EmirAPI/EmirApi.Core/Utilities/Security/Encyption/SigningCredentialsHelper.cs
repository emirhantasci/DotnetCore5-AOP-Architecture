using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using EmirApi.Core.Utilities.Messages;

namespace EmirApi.Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return  new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }

       
    }
}
