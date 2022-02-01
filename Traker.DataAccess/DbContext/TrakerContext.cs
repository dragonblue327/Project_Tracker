using Microsoft.EntityFrameworkCore;
using Business.Models;
namespace Business.Models

{
    public class TrakerContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Task> TaskStatus { get; set; }
        public DbSet<Project> ProjectStatus { get; set; }


        //here my connection string 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"data source=DESKTOP-1F6JFL0\SQLEXPRESS; initial catalog=Traker; integrated security=SSPI;");
        }


    }
}
