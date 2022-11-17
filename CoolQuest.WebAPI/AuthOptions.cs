using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoolQuest.WebAPI
{
    public class AuthOptions
    {
        public const string ISSUER = "MyCoolQuestServer"; // издатель токена
        public const string AUDIENCE = "MyCoolQuestClient"; // потребитель токена
        const string KEY = "myCoolQuestTeam6!";   // ключ для шифрации
        public const int LIFETIME = 10080;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}
