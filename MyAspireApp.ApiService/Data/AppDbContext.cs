using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Entities;

namespace MyAspireApp.ApiService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DbSet<Winner> Winners { get; set; }
}