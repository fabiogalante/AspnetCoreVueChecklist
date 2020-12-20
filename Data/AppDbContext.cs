using AspnetCoreVueChecklist.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreVueChecklist.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChecklistItem> ChecklistItems { get; set; }
    }
}
