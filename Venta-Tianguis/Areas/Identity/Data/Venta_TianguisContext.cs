using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Venta_Tianguis.Areas.Identity.Data;

namespace Venta_Tianguis.Data;

public class Venta_TianguisContext : IdentityDbContext<Venta_TianguisUser>
{
    public Venta_TianguisContext(DbContextOptions<Venta_TianguisContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
