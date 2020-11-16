using Dimico.Server.Infrastructure.Services;
using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimico.Server.Features.Follows
{
    public class FollowService : IFollowService
    {
        private readonly DimicoDbContext data;

        public FollowService(DimicoDbContext data) => this.data = data;

        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed =await this.data
                .Follows
                .AnyAsync(u => u.UserId == userId && u.FollowerId == followerId);

            if (userAlreadyFollowed)
            {
                return "This user is already followed.";
            }

            var publicProfile = await this.data
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(p => !p.IsPrivate)
                .FirstOrDefaultAsync();

            this.data.Follows.Add(new Follow
            {
                UserId = userId,
                FollowerId = followerId,
                IsApproved = publicProfile
            });

            await this.data.SaveChangesAsync();
            return true;

        }
    }
}
