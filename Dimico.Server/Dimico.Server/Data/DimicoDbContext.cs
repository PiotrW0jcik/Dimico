using Dimico.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dimico.Server.Data
{
    public class DimicoDbContext : IdentityDbContext<User>
    {
        public DimicoDbContext(DbContextOptions<DimicoDbContext> options)
            : base(options)
        {
        }
    }
}
