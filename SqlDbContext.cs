using campus_circle_api.Model;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api;

public class SqlDbContext : DbContext
{
    // these classes must define columns and tables
    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
        // TODO: remove me
        // delete all data to re-create it, otherwise new tables won't auto created
        // Database.EnsureDeleted();

        // ensures the table exists for the first time
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(builder => { builder.Property(e => e.username).HasMaxLength(10); });
    }
}