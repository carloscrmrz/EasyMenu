using EasyMenu.Portal.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();


app.UseHttpsRedirection();

var origins = builder.Configuration.GetSection("Client").GetValue<string>("Path");
app.UseCors(p => p
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins(origins));
app.UseAuthorization();

app.MapControllers();

app.Run();