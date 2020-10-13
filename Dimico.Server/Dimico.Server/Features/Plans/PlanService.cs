using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;

namespace Dimico.Server.Features.Plans
{
    public class PlanService : IPlanService
    {
        private readonly DimicoDbContext data;

        public PlanService(DimicoDbContext data) => this.data = data;

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var plan = new Plan
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };
            this.data.Add(plan);
            await this.data.SaveChangesAsync();

            return plan.Id;
        }
    }
}
