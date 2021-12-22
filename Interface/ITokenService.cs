using web_api.Entities;

namespace web_api.Interface
{
    public interface ITokenService
    {
        string CreateToken(appUser user);
    }
}