using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class TokenValidationFilter : IAsyncActionFilter
{
    private readonly IJwtService jwtService;

    public TokenValidationFilter(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var tokenHeader))
        {
            var token = tokenHeader.ToString().Replace("Bearer ", "");
            var principal = jwtService.ValidateToken(token);
            if (principal != null)
            {
                context.HttpContext.User = principal;
                await next();
                return;
            }
        }

        context.Result = new UnauthorizedResult();
    }
}
