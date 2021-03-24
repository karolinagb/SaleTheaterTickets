using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SaleTheaterTickets.Extension;

namespace SaleTheaterTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            //criamos o método de extensão CreateAdminRole
            CreateHostBuilder(args)
               .Build()
               .CreateAdminRole()
               .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
