
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            
        }


        public DbSet<Entry> Entries {get; set;}
        public DbSet<Game> Games {get; set;}
        public DbSet<GameInitial> GameInitials {get; set;}
        public DbSet<Initial> Initials {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<User> Users {get; set;}
      
    }
}