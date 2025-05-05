using Microsoft.EntityFrameworkCore;

namespace ScrutorDemo;

public class ScrutorDb:DbContext
{
    public ScrutorDb(DbContextOptions<ScrutorDb> options) :base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
}
