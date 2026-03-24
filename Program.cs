using Microsoft.EntityFrameworkCore;
using Amrod_E_Commerce.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("defaultConnection")
        //sqlOptions => sqlOptions.EnableRetryOnFailure(
        //    maxRetryCount: 5,          
        //    maxRetryDelay: TimeSpan.FromSeconds(10), 
        //    errorNumbersToAdd: null     
        //)
    )
);

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

app.MapControllers();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
