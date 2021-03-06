using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EmirApi.Core.Entities.Concrete;
using EmirApi.Core.Extensions;
using EmirApi.Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmirApi.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private string accessTokenExpiration;
        private DateTime _accessTokenExpiration;
        public static string fullKey = "H13DufUTANeX6Ykkyn1C8g74cijyXNWHGQEZCQOlxx4MOl7V";
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            accessTokenExpiration = Configuration.GetSection("AccessTokenExpiration").Value.ToString();

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            TokenOptions tokenOptions = new TokenOptions();

            tokenOptions.Audience = "www.emirhn.com.tr";
            tokenOptions.Issuer = "www.emirhn.com.tr";
            tokenOptions.AccessTokenExpiration = Convert.ToInt32(accessTokenExpiration);
            tokenOptions.SecurityKey = fullKey;
            _accessTokenExpiration = DateTime.Now.AddMinutes(Convert.ToInt64(accessTokenExpiration));
            var securityKey = SecurityKeyHelper.CreateSecurityKey(fullKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
