using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Dimico.Server.Features.Profiles.Models;
using Dimico.Server.Infrastructure.Services;
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
                    Gender =  u.Profile.Gender.ToString(),
                    IsPrivate = u.Profile.IsPrivate

                })
                .FirstOrDefaultAsync();

        public async Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string name, 
            string mainPhotoUrl, 
            string webSite,
            string biography, 
            Gender gender, 
            bool isPrivate)
        {
            var user = await this.data
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(p => p.Id == userId);
            
            if (user == null)
            {
                return "User does not exist.";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }

            var result = await this.ChangeEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            result = await this.ChangeUserName(user, userId, userName);
            if (result.Failure)
            {
                return result;
            }

            this.ChangeProfile(
                user.Profile,
                name,
                mainPhotoUrl,
                webSite,
                biography,
                gender,
                isPrivate);


            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeEmail(User user,string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExist = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExist)
                {
                    return "The provided e-mail is already taken.";
                }

                user.Email = email;
            }

            return true;
        }

        private async Task<Result> ChangeUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExist = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);
                if (userNameExist)
                {
                    return "The provided user name is already taken.";
                }

                user.UserName = userName;
            }

            return true;
        }

        private void ChangeProfile(
            Profile profile,
            string name,
            string mainPhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate)
        {

            if (profile.Name != name)
            {
                profile.Name = name;
            }

            if (profile.MainPhotoUrl != mainPhotoUrl)
            {
                profile.MainPhotoUrl = mainPhotoUrl;
            }

            if (profile.WebSite != webSite)
            {
                profile.WebSite = webSite;
            }


            if (profile.Biography != biography)
            {
                profile.Biography = biography;
            }


            if (profile.Gender != gender)
            {
                profile.Gender = gender;
            }


            if (profile.IsPrivate != isPrivate)
            {
                profile.IsPrivate = isPrivate;
            }

        }
    }
}
