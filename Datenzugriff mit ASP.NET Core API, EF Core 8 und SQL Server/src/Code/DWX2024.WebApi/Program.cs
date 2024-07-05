using DWX2024.AppLogic;
using DWX2024.AppLogic.EntityFramework;
using DWX2024.Infrastructure.Interfaces;
using DWX2024.WebApi.Code.ApiKey;
using DWX2024.WebApi.Code.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region API key
IConfigurationSection apiKeyConfigurationSection = builder.Configuration.GetSection("ApiKey");
builder.Services.Configure<ApiKeySettings>(apiKeyConfigurationSection);

ApiKeySettings apiKeySettings = new();
apiKeyConfigurationSection.Bind(apiKeySettings);
#endregion

builder.Services.AddControllers(o=>
{
    if (apiKeySettings.ProtectWithApiKey)
        o.Filters.Add(new ApiKeyFilter(apiKeySettings));

    o.Filters.Add(new UserExceptionHandler());
    o.Filters.Add(new ArgumentOutOfRangeExceptionHandler());
    o.Filters.Add(new TaskCanceledExceptionHandler());
});
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


#region Nlog
string nlogConfigFileName = Path.Combine(AppContext.BaseDirectory, "nlog.config");
if (File.Exists(nlogConfigFileName))
{
    builder.Services.AddLogging(b =>
    {
        b.AddNLog(nlogConfigFileName);
        builder.WebHost.UseNLog();
        builder.Host.UseNLog();
    });
}
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
