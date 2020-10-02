using System.ComponentModel.DataAnnotations;

using static Dimico.Server.Data.Validation.Plan;

namespace Dimico.Server.Data.Models
{
    public class Plan
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
