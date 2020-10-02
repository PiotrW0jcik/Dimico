using System.ComponentModel.DataAnnotations;
using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Models.Plans
{
    public class CreatePlanRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
