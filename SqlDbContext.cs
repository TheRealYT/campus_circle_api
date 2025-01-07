using campus_circle_api.Model;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api;

public class SqlDbContext : DbContext
{
    // the class Chat has to define columns and tables
    public DbSet<Chat> Chats { get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
        // ensures the table exists for the first time
        Database.EnsureCreated();
    }
}