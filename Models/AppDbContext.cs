using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace actividad7.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _config;
        public AppDbContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _config = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

    }
}
