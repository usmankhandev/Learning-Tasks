using Microsoft.EntityFrameworkCore;

namespace restApi.Models
{
    public class RestContext : DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<Rest> RestItems { get; set; }
        // public DbSet<Login> LoginUsers { get; set; }
        public DbSet<Register> RegisterUsers { get; set; }

    }
}