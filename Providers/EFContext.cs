using Microsoft.EntityFrameworkCore;
using WarehouseServer.DTO;
using Microsoft.Extensions.Configuration;

namespace WarehouseServer.Providers
{
  public class EFContext : DbContext
  {
    private readonly IConfiguration configuration;

    public EFContext(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=WarehouseDB;Username=postgres;Password=postgres;Pooling=True;");
      optionsBuilder.UseNpgsql(configuration.GetConnectionString("NHibernateConnection"));
    }

    public DbSet<ClientDto> Clients { get; set; }
    public DbSet<GoodDto> Goods { get; set; }    
    public DbSet<ProviderDto> Providers { get; set; }
    public DbSet<RealizationDto> Realizations { get; set; } 
    public DbSet<ReceiptDto> Receipts { get; set; }
    public DbSet<UserDto> Users { get; set; }
    public DbSet<TableDto> Tables { get; set; }
  }
}