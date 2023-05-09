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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

bool useSql = true;
if (useSql)
{
    var optionsBuilder =
        new DbContextOptionsBuilder<SensorDataContext>();
    optionsBuilder.UseSqlServer("connectionId=PlantPalConnection");
    SensorDataContext context =
        new SensorDataContext(optionsBuilder.Options);
    builder.Services.AddSingleton<ISensorDatasRepository>(
        new SensorDatasRepositoryDB(context));
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
