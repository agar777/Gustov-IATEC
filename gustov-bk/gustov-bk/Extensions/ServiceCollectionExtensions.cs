public static class ServiceCollectionExtensions
{
    public static void AddGustovServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IRoleService, RolesService>();

    }
}
