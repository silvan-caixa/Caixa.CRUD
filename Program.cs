using Caixa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Caixai.Web2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CaixaDbContext>(option =>
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var dpPath = Path.Combine(localAppData, "Caixa2.db");

                option.UseSqlite($"Data Source={dpPath}").EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
            });

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

            app.UseStatusCodePagesWithReExecute("/Erros/Status/{0}");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Turmas}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
