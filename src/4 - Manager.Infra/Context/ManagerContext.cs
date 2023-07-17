using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Manager.Infra.Mappings;

namespace Manager.Infra.Context
{
  public class ManagerContext : DbContext
  {
    public ManagerContext(){}
    public ManagerContext(DbContextOptions<ManagerContext> options): base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-LJU8U6L\\SQLEXPRESS;Initial Catalog=USERMANAGERAPI;Integrated Security=True;TrustServerCertificate=True");
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Library> Librarys { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new UserMap());
      builder.ApplyConfiguration(new LibraryMap());
    }
  }
}