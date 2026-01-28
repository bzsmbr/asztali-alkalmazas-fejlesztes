namespace Solution.Domain.Database;

public sealed class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
{
    public override DbSet<UserEntity> Users {  get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUser();
    }
}
