using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.Global
{
    public class JwtAuthManager
    {
        public static string Authenticate(string user_name, string password)
        {
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JwtSetting.JWT_TOKEN_VALIDITY_MINS);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = Encoding.ASCII.GetBytes(JwtSetting.JWT_SECURITY_KEY);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", user_name),
                    new Claim("password", password),
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(token), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string tokenkey = jwtSecurityTokenHandler.WriteToken(securityToken);
            return tokenkey;
        }
    }
}
