﻿using System.ComponentModel.DataAnnotations;
using static Dimico.Server.Data.Validation.User;

namespace Dimico.Server.Data.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [MaxLength(MaxNameLenght)]
        public string Name { get; set; }

        public string MainPhotoUrl { get; set; }

        public string WebSite { get; set; }

        [MaxLength(MaxBiographyLenght)]
        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
