using Microsoft.EntityFrameworkCore;
using DatingApp.API.DataBase.Entities;

namespace DatingApp.API.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users{get; set;}
        
    }
}