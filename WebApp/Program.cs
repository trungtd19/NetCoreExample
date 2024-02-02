using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseSqlServer(AppSettings.ConnectionString,
        sqlOptions => sqlOptions.CommandTimeout(120));
});

builder.Services.AddScoped<Func<DemoContext>>((provider) => () => provider.GetService<DemoContext>());
builder.Services.AddScoped<DbFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWorkService, WorkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
