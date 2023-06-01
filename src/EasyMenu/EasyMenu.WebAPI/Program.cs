using EasyMenu.Core.Model;
using EasyMenu.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

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

var origins = builder.Configuration.GetSection("Client").GetValue<string>("Path");
app.UseCors(p => p
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins(origins));
app.UseAuthorization();

app.MapControllers();

app.MigrateDatabaseUponAppStart<EasyMenuContext>(EasyMenuContext.SectionName, logger);

app.Run();