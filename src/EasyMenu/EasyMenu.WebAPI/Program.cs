using EasyMenu.Core.Model;
using EasyMenu.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 32));
// Add services to the container.
builder.Services.AddDbContext<EasyMenuContext>(optionsBuilder => 
    optionsBuilder.UseMySql(EasyMenuContext.ConnectionString, mySqlVersion));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = LoggerFactory.Create(_ => { })
    .CreateLogger("App Startup");
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabaseUponAppStart<EasyMenuContext>(EasyMenuContext.SectionName, logger);

app.Run();