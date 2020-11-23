using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Dimico.Server.Features.Plans.Models;
using Dimico.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Dimico.Server.Features.Plans
{
    public class PlanService : IPlanService
    {
        private readonly DimicoDbContext data;
        private readonly IMapper mapper;

        public PlanService(DimicoDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

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

        public async Task<Result> Update(int id, string description, string userId)
        {
            var plan = await this.GetByIdAndByUserId(id, userId);

            if (plan == null)
            {
                return "This user cannot edit this plan.";
            }

            plan.Description = description;

            await this.data.SaveChangesAsync();

            return true;

        }

        public async Task<Result> Delete(int id, string userId)
        {
            var plan = await this.GetByIdAndByUserId(id, userId);

            if (plan == null)
            {
                return "This user cannot delete this plan.";
            }

            this.data.Plans.Remove(plan);

            await this.data.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<PlanListingServiceModel>> ByUser(string userId)
            => await this.data
                .Plans
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedOn)
                .ProjectTo<PlanListingServiceModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<PlanDetailsServiceModel> Details(int id)
            => await this.data
                .Plans
                .Where(c => c.Id == id)
                .ProjectTo<PlanDetailsServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task<Plan> GetByIdAndByUserId(int id, string userId)
            => await this.data
                .Plans
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();

    }
}
