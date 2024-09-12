public static class ServiceCollectionExtensions
{
    public static void AddGustovServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        services.AddScoped<IRoleService, RolesService>();
        services.AddScoped<ICompanyService, CompanyService>();

    }
}
