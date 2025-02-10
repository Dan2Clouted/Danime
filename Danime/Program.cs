using Danime.Models;
using Danime.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source= Danime.db";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<AnimeService>();
builder.Services.AddHttpClient<MangaService>();
builder.Services.AddDbContext<DanimeContext>(options => options.UseSqlite(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
