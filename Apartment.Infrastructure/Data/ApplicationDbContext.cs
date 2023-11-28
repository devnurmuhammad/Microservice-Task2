using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Apartment.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        try
        {
            var DatabaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (DatabaseCreator != null)
            {
                if (!DatabaseCreator.CanConnect())
                    DatabaseCreator.Create();
                if (DatabaseCreator.HasTables())
                    DatabaseCreator.CreateTables();
            }
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<House> Houses { get; set; }
}
