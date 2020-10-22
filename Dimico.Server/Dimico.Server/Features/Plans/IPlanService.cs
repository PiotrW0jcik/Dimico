using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dimico.Server.Features.Plans
{
    public interface IPlanService
    {
        public Task<int> Create(string imageUrl, string description, string userId);

        public Task<IEnumerable<PlanListingResponseModel>> ByUser(string userId);

    }
}
