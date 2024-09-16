using Microsoft.EntityFrameworkCore;

class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options): base (options)
    {}

    public DbSet<Employee> Employees {get;set;}
    public DbSet<Request> Requests {get;set;}
    public DbSet<Vacation> Vacations {get;set;}
}