using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories;
using SaleTheaterTickets.Repositories.Interfaces;

namespace SaleTheaterTickets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Piece, PieceViewModel>();
                cfg.CreateMap<PieceViewModel, Piece>();
                cfg.CreateMap<Ticket, TicketViewModel>();
                cfg.CreateMap<TicketViewModel, Ticket>();
                //CreateMap<Contrato, ContratoDto>().ForMember(p => p.Descricao, x => x.Ignore());

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<SaleTheaterTicketsContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("SaleTheaterTicketsContext"), builder =>
            builder.MigrationsAssembly("SaleTheaterTickets")));

            //Definindo instancia da interfaces e suas referidas implementações
            services.AddTransient<IPieceRepository, PieceRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();

            //Adicionando o Fluent Validation ao pipeline
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
