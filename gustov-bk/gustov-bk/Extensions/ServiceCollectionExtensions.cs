public static class ServiceCollectionExtensions
{
    public static void AddGustovServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IVacationRepository, VacationRepository>();

        services.AddScoped<IRoleService, RolesService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<IVacationService, VacationService>();
        
        services.AddScoped<IVacationValidator,VacationValidators>();

    }
}
