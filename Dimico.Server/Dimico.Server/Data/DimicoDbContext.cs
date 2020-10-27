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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Plan>()
                .HasOne(c => c.User)
                .WithMany(u => u.Plans)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
