using Microsoft.EntityFrameworkCore;
using bookapi_minimal.Models;
using bookapi_minimal.Services;
using Microsoft.Extensions.Options;
using bookapi_minimal.Configurations;


namespace bookapi_minimal.AppContext
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
       // private const String DefaultSchema = "BookStore";

        public DbSet<BookModel> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.HasDefaultSchema("BookStore");
            modelBuilder.ApplyConfiguration(new BookTypeConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
          
        }
        

    }
}