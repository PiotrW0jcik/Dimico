using Dimico.Server.Data.Models;
using Dimico.Server.Features.Plans.Models;
using Profile = AutoMapper.Profile;

namespace Dimico.Server.Infrastructure.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Plan, PlanListingServiceModel>();
            this.CreateMap<Plan, PlanDetailsServiceModel>()
                .ForMember(m=> m.UserName, cfg=> cfg.MapFrom(a => a.User.UserName));
        }
    }
}
