using Domain.Database.AppDbContext;
using Domain.Respository;
using Microsoft.EntityFrameworkCore;
using Services.IRespository;
using System.Text;

namespace View
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<QuanLyBaiVietDbcontext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IWritingPhasesRespository, WritingPhasesRepo>();
            builder.Services.AddScoped<IRegistrationPeriodsRespository, RegistrationPeriodsRepo>();

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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Debug t?t c? các route ?ã ??ng ký
                endpoints.MapGet("/debug/routes", async context =>
                {
                    var endpointDataSource = context.RequestServices.GetRequiredService<EndpointDataSource>();
                    var sb = new StringBuilder();
                    foreach (var endpoint in endpointDataSource.Endpoints)
                    {
                        sb.AppendLine(endpoint.DisplayName);
                    }
                    await context.Response.WriteAsync(sb.ToString());
                });

                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
