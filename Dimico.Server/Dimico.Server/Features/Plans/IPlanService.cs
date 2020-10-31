using System.Collections.Generic;
using System.Threading.Tasks;
using Dimico.Server.Features.Plans.Models;

namespace Dimico.Server.Features.Plans
{
    public interface IPlanService
    {
        public Task<int> Create(string imageUrl, string description, string userId);


        public Task<bool> Update(int id, string description, string userId);

        public Task<IEnumerable<PlanListingServiceModel>> ByUser(string userId);

        public Task<PlanDetailsServiceModel> Details(int id);
    }
}
