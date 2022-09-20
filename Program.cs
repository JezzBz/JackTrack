using JackTrack.Entities.DataBase;
using JackTrack.Extensions;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionString"]);
});
builder.Services.AddCors();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();



builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Configure default dev users
if (app.Environment.IsDevelopment())
{
	await app.Services.AnsureUserSeedConfigured();
}
//Configure default roles
await app.Services.AnsureRoleSeedConfigured();

app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("https://localhost:44484"));

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;


app.Run();
