using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
