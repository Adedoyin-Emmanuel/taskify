using Microsoft.EntityFrameworkCore;
using taskify.Models;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Todo> Todo { get; set; }
    public DbSet<Auth> Auth { get; set; }
}