using Microsoft.EntityFrameworkCore;

// Define la clase DbContext
public partial class GustovContext : DbContext
{
    // Constructor que recibe opciones de DbContext
    public GustovContext(DbContextOptions<GustovContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies {get;set;}
    public DbSet<Role> Roles {get;set;}
    public DbSet<User> Users {get;set;}
    public DbSet<Request> Requests {get;set;}
    public DbSet<Vacation> Vacations {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
