using System.ComponentModel.DataAnnotations;
using Dimico.Server.Data.Base;
using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Data.Models
{
    public class Plan : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public PlanType Type { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
