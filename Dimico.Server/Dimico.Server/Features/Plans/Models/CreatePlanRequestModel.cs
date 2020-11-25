using System.ComponentModel.DataAnnotations;
using Dimico.Server.Data.Models;
using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Features.Plans.Models
{
    public class CreatePlanRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public PlanType Type { get; set; }

    }
}
