using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using PlayNirvanaTechExam.Database;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Extensions;
using PlayNirvanaTechExam.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureIdentity();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureCors();
builder.Services.ConfigureIisIntegration();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RepositoryContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DbInitializer.Initialize(context, userManager, roleManager);
}


app.Run();