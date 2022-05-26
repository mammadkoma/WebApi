namespace WebApi.Configs;

public static class UnauthorizedConfig
{
    public static void UnauthorizedHandler(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            await next();

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized) // 401
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = 401,
                    Message = "توکن معتبر نیست"
                });
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden) // 403
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = 403,
                    Message = "شما دسترسی ندارید"
                });
            }
        });
    }
}