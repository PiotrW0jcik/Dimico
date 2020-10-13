namespace Dimico.Server.Features.Identity
{
    public interface IIdentityServices
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
