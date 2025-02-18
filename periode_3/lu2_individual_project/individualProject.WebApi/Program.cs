var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Gets SQL connection string from the user secrets
var sqlConnectionString = builder.Configuration["SqlConnectionString"];

if (string.IsNullOrWhiteSpace(sqlConnectionString))
    throw new InvalidProgramException("Configuration variable SqlConnectionString not found");

//builder.Services.AddTransient<IEnvironmentRepository, SqlEnvironmentRepository>(o => new SqlEnvironmentRepository(sqlConnectionString));
//builder.Services.AddTransient<IObjectRepository, SqlObjectRepository>(o => new SqlObjectRepository(sqlConnectionString));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapGet("/", () => "Hello World! The API is up");

// Configure the HTTP request pipeline.S
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
