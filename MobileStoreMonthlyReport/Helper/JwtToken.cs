using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreMonthlyReport.Helper
{
    public class JwtToken
    {
        private const string SECRET_KEY = "j98lKTS1ATdfdFChA346g29NorA2HA07xSK0A7EP0ZE2IVi7Sw5mDLP2fSbIS6ai5W4937PjaSHCyr8lP3cnNUa6FODuGcjEKB8LsnCQTkNO59jjAE3cyUL0LGSdvM2MLuj6hGmH5jePRQk29upGzzdO9zbjCrlyTLUw3BnkIJoi2ZfRudb62KddDr4OhQioh9kNkXmUc9AH5cmNvZLHebROXZsBQQtILXBwJxwklUsgn0oKcQ2DW3PU40SRdkzC";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
        
        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var Expiry = DateTime.UtcNow.AddDays(100);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new JwtPayload
            {
                { "sub", "testsubject"},
                { "exp", ts },
                { "iss", "https://localhost:44370/"},
                { "aud", "https://localhost:44370/" }
            };
            var secToken = new JwtSecurityToken(header, payload);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(secToken);
            return tokenString;
        }
    }
}
