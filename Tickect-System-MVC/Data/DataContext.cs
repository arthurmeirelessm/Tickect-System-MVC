using Microsoft.EntityFrameworkCore;
using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Data
{
    public class DataContext : DbContext
    {
       public DataContext (DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<UserModel> Users { get; set; }
    }
}
