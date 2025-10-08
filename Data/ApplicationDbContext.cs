using Microsoft.EntityFrameworkCore;
using MiMvcApp.Models;

namespace MiMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public static void Seed(ApplicationDbContext db)
        {
            if (!db.Users.Any())
            {
                var admin = new User { Username = "admin" };
                admin.SetPassword("Admin123!");
                db.Users.Add(admin);
            }
            if (!db.Items.Any())
            {
                db.Items.AddRange(new Item { Name = "Item A", Description = "Desc A" },
                                  new Item { Name = "Item B", Description = "Desc B" });
            }
            db.SaveChanges();
        }
    }
}
