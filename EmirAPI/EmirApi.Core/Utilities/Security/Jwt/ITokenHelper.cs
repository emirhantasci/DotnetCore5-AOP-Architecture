using System;
using System.Collections.Generic;
using System.Text;
using EmirApi.Core.Entities.Concrete;

namespace EmirApi.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
