using ceng382_project3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ceng382_project3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDos { get; set; }

        public virtual DbSet<Servants> Servants { get; set; }

        public virtual DbSet<UserRating> UserRatings { get; set; }

        public virtual DbSet<Appointments> Appointments { get; set; }

    }
}
