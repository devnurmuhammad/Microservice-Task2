using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apartment.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<House> Houses { get; set; }
    }
}
