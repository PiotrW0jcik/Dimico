using System.Collections.Generic;
using System.Threading.Tasks;
using Dimico.Server.Features.Plans.Models;
using Dimico.Server.Infrastructure.Services;

namespace Dimico.Server.Features.Plans
{
    public interface IPlanService
    {
         Task<int> Create(string imageUrl, string description, string userId);

         Task<Result> Update(int id, string description, string userId);

         Task<Result> Delete(int id, string userId);

         Task<IEnumerable<PlanListingServiceModel>> ByUser(string userId);

         Task<PlanDetailsServiceModel> Details(int id);

    }
}
