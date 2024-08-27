using Backend.Infra.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Database.Db;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
