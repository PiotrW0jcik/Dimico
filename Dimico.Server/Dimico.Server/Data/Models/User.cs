using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dimico.Server.Data.Base;
using Microsoft.AspNetCore.Identity;

namespace Dimico.Server.Data.Models
{
    public class User : IdentityUser,IEntity 
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<Plan> Plans { get; } = new HashSet<Plan>();

    }
}
