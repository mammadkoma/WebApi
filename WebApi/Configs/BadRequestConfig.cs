namespace WebApi.Configs;

public static class BadRequestConfig
{
    // error 400 handling - remove extra fields in error model - remove if(ModelState.IsValid)
    public static IMvcBuilder AddBadRequestServices(this IMvcBuilder services)
    {
        services.ConfigureApiBehaviorOptions(options =>
        options.InvalidModelStateResponseFactory = actionContext =>
        {
            var modelState = actionContext.ModelState.Values;
            var allErrors = actionContext.ModelState.Values.SelectMany(v => v.Errors);
            return new BadRequestObjectResult(new
            {
                StatusCode = 400,
                Message = string.Join(" - ", allErrors.Select(e => e.ErrorMessage))
            });
        });

        return services;
    }
}