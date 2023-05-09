using PlantPal;
using PlantPal.Repositories;

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

builder.Services.AddSingleton<SensorDatasRepository>(new SensorDatasRepository());

bool useSql = true;
if (useSql)
{
    var optionsBuilder =
        new DbContextOptionsBuilder<SensorDataContext>();
    optionsBuilder.UseSqlServer(Secrets.ConnectionString);
    SensorDataContext context =
        new SensorDataContext(optionsBuilder.Options);
    builder.Services.AddSingleton<SensorDatasRepository>(
        new SensorDatasRepositoryDB(context));
}
else
{
    builder.Services.AddSingleton<IPokemonsRepository>
        (new PokemonsRepository());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
