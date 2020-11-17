using System.Threading.Tasks;
using Dimico.Server.Infrastructure.Services;

namespace Dimico.Server.Features.Follows
{
    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);

        Task<bool> IsFollower(string userId, string followerId);
    }
}
