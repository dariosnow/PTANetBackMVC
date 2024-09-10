using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Context
{
    //Mapping DataBase
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<BalanceServiceProviders> BalanceServiceProviders { get; set; }
    }
}
