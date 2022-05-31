var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataBase(builder.Configuration.GetConnectionString("CS"));
builder.Services.RegisterAssemblyPublicNonGenericClasses()
  .Where(c => c.Name.EndsWith("Service"))
  .AsPublicImplementedInterfaces(ServiceLifetime.Scoped); // default is Transient
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.ExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();//