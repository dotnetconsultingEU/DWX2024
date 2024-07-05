using DWX2024.AppLogic;
using DWX2024.AppLogic.EntityFramework;
using DWX2024.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAppLogic, LogicV1>();

#region EF Core
builder.Services.AddDbContextPool<dncUserDatabaseContext>(o =>
{
    string conString = builder.Configuration.GetConnectionString("Main")!;
    o.UseSqlServer(conString);
    o.EnableSensitiveDataLogging(true);
    o.LogTo(Console.WriteLine, LogLevel.Information);
});
#endregion

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
