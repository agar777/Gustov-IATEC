public static class ServiceCollectionExtensions
{
    public static void AddGustovServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRoleService, RolesService>();
        // services.AddScoped<IUserService, UserService>();

    }
}
