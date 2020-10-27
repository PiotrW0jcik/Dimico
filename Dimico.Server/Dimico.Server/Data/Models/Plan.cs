using System.ComponentModel.DataAnnotations;

namespace Dimico.Server.Data.Models
{
    public class Plan
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
