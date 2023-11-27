using Microsoft.AspNetCore;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateBuild(args).Build().Run();
        }
        public static IWebHostBuilder CreateBuild(string[] args) =>
             WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}