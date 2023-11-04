using AppAPI.DataObject;
using Microsoft.EntityFrameworkCore;

namespace AppAPI
{
    public class PersonneContext : DbContext
    {
        public PersonneContext(DbContextOptions<PersonneContext> options) : base(options)
        {
        }
        public DbSet<Personne> Personne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../dbTEST.db");
        }

    }
}
