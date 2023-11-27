using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.BL;

namespace WebApplication1
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

            public void configureServices(IServiceCollection services )
            {
            services.AddControllersWithViews();
            services.AddDbContext<EmployeeDbcontext>(option => option.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddScoped<IEmployee, EmployeeBusiness>();
        }

        public void configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("hii");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Test}/{action=Index}/{id?}");


            });


        }
    }
}
