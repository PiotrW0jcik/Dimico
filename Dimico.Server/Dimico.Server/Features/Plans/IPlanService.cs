using System.Threading.Tasks;

namespace Dimico.Server.Features.Plans
{
    public interface IPlanService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        
    }
}
