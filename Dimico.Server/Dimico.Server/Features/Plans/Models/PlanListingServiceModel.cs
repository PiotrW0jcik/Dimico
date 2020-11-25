using Dimico.Server.Data.Models;

namespace Dimico.Server.Features.Plans.Models
{
    public class PlanListingServiceModel
    {

        public int Id { get; set; }

        public PlanType Type { get; set; }

        public string ImageUrl { get; set; }
    }
}
