using Microsoft.EntityFrameworkCore;
using WebMVCCore70.Models;

namespace WebMVCCore70
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Injecton de service de connexion vers la base de données
            builder.Services.AddDbContext<BusinessDbContext>(
                options=>options.UseSqlServer("Data Source=PC2023\\PC2023;Initial Catalog=BusinessDB;Integrated Security=True;" +
            "TrustServerCertificate=True"));
           
            
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
        }
    }
}