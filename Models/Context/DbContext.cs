using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using taskify.Models;

public class AppContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{

    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }
    public DbSet<Todo> Todo { get; set; }
}


