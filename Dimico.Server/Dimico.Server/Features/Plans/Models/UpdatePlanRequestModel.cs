using System.ComponentModel.DataAnnotations;

using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Features.Plans.Models
{
    public class UpdatePlanRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

    }
}
