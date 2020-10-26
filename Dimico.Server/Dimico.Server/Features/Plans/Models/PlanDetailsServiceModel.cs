using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dimico.Server.Features.Plans.Models
{
    public class PlanDetailsServiceModel : PlanListingServiceModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
