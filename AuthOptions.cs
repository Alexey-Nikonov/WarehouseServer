using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WarehouseServer
{
  public static class AuthOptions
  {
    public const string ISSUER = "WarehouseServer";
    public const string AUDIENCE = "WarehouseView";
    public const int LIFETIME = 60; // min
    const string PRIVATE_KEY = "qwerty_secret_key_123456789";

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PRIVATE_KEY));
    }
  }
}
