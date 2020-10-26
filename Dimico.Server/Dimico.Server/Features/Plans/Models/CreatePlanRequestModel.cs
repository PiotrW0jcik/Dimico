using System.ComponentModel.DataAnnotations;
using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Features.Plans.Models
{
    public class CreatePlanRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

    }
}
