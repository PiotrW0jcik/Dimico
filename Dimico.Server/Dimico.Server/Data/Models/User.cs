using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dimico.Server.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Plan> Plans { get; } = new HashSet<Plan>();

    }
}
