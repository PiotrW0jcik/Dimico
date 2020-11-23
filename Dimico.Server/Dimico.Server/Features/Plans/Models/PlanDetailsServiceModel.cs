namespace Dimico.Server.Features.Plans.Models
{
    public class PlanDetailsServiceModel : PlanListingServiceModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
