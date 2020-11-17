using System.Threading.Tasks;
using Dimico.Server.Data.Models;
using Dimico.Server.Features.Profiles.Models;
using Dimico.Server.Infrastructure.Services;

namespace Dimico.Server.Features.Profiles
{
    public interface IProfileServices
    {
        Task<ProfileServiceModel> ByUser(string userId, bool allInformation=false);

        Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string name, 
            string mainPhotoUrl, 
            string webSite, 
            string biography, 
            Gender gender, 
            bool isPrivate);

        Task<bool> IsPublic(string userId);
    }
}
