namespace WebApi.Configs;

public static class ExceptionConfig
{
    public static void ExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = 500,
                        Message = CheckException(contextFeature.Error)
                    });
                }
            });
        });
    }

    private static string CheckException(Exception ex)
    {
        if (ex.InnerException.Message.Contains("UNIQUE KEY constraint 'IX_User'"))
            return "این یوزرنیم قبلا ثبت شده است.";

        if (ex.InnerException is not null)
            return ex.Message + " - InnerException : " + ex.InnerException.Message;

        return ex.Message;
    }
}