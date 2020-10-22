using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PlanListingResponseModel>> ByUser(string userId)
            => await this.data
                .Plans
                .Where(c => c.UserId == userId)
                .Select(c => new PlanListingResponseModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

    }
}
