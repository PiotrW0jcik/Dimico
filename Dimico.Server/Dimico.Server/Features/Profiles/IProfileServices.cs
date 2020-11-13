using System.Threading.Tasks;
using Dimico.Server.Features.Profiles.Models;

namespace Dimico.Server.Features.Profiles
{
    public interface IProfileServices
    {
        Task<ProfileServiceModel> ByUser(string userId);
    }
}
