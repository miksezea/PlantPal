using Microsoft.EntityFrameworkCore;
using PlantPal.Repositories;
using PlantPal.Contexts;

const string policyName = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});
 
builder.Services.AddControllers();
//Test
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = String.Empty;
bool useSql = true;
if (useSql)
{
    connection = Environment.GetEnvironmentVariable("PlantPalDbConnection");
    var optionsBuilder =
        new DbContextOptionsBuilder<SensorDataDbContext>();
    SensorDataDbContext context =
        new SensorDataDbContext(optionsBuilder.Options);
    builder.Services.AddSingleton<ISensorDatasRepository>(
        new SensorDatasRepositoryDB(context));
    builder.Services.AddDbContext<SensorDataDbContext>(options =>
        options.UseSqlServer(connection));
}
else
{
    builder.Services.AddSingleton<ISensorDatasRepository>(new SensorDatasRepository());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
