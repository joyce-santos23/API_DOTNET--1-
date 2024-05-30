using Api.CrossCutting.DependencyInjection;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services);

// builder.Services.AddTransient<IUserService, UserService>();
// builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

// builder.Services.AddDbContext<MyContext>(
//     options => options.UseMySql(
//         "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root",
//         new MySqlServerVersion(ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root"))
//     )
// );

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

app.Run();