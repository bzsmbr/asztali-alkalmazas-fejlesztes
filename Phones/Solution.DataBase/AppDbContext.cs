namespace Solution.DataBase;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<ManufacturerEntity> Manufacturers { get; set; }

	public DbSet<PhoneEntity> Phones { get; set; }

	public DbSet<TypeEntity> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
}
