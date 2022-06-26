var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddDataBase
builder.Services.AddDataBase(builder.Configuration.GetConnectionString("CS"));
// AddCors
builder.Services.AddCors(options => options.AddPolicy(name: "AppOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));
// AddScoped
//builder.Services.AddScoped(typeof(UserService));
builder.Services.RegisterAssemblyPublicNonGenericClasses()
  .Where(c => c.Name.EndsWith("Service"))
  .AsPublicImplementedInterfaces(ServiceLifetime.Scoped); // default is Transient

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.ExceptionHandler();
app.UseCors("AppOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();