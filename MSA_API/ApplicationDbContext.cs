using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<LoginModel> LoginUser { get; set; }
    public DbSet<AnimalModel> Animals { get; set; }
    public DbSet<PetShopModel> PetShops { get; set; }
    public DbSet<CityModel> Cities { get; set; }
}