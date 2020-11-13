using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Features.Profiles.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimico.Server.Features.Profiles
{
    public class ProfileServices : IProfileServices
    {
        private readonly DimicoDbContext data;

        public ProfileServices(DimicoDbContext data) => this.data = data;

        public async Task<ProfileServiceModel> ByUser(string userId)
            => await this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileServiceModel
                {
                    Name = u.Profile.Name,
                    MainPhotoUrl = u.Profile.MainPhotoUrl,
                    WebSite = u.Profile.WebSite,
                    Biography = u.Profile.Biography,
                    Gender =  u.Profile.Gender,
                    IsPrivate = u.Profile.IsPrivate

                })
                .FirstOrDefaultAsync();
    }
}
