var builder = WebApplication.CreateBuilder(args);

#region Add services to the DI container
// AddDataBase
builder.Services.AddDataBase(builder.Configuration.GetConnectionString("CS"));
// AddCors
builder.Services.AddCors(options => options.AddPolicy(name: "AppOrigins",
policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); }));
// Add Scoped AppServices
var appServices = typeof(Program).Assembly.GetTypes()
    .Where(s => s.Name.EndsWith("Service") && s.IsInterface == false).ToList();
foreach (var appService in appServices)
    builder.Services.Add(new ServiceDescriptor(appService, appService, ServiceLifetime.Scoped));

builder.Services.AddControllers().AddBadRequestServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

#region HTTP request pipeline
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.ExceptionHandler();
app.UseCors("AppOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion