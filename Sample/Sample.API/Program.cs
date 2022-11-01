using Sample.API;
using Sample.Application.Services.Users;
using Sample.DataAccess;
using Sample.DataAccess.Persistence;
using Sample.DataAccess.Repositories;
using Sample.DataAccess.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDataAccess(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AutomatedMigration.MigrateAsync(app.Services.CreateScope().ServiceProvider);
app.Run();
