using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories;
using SaleTheaterTickets.Repositories.Interfaces;
using System.Collections.Generic;
using System.Globalization;

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

            services
                .AddIdentity<IdentityUser, IdentityRole>() //Adiciona o sistema Identiy padrão para os tipos de perfis especificados
                .AddEntityFrameworkStores<SaleTheaterTicketsContext>() //Adiciona uma implementação do EntityFramework que armazena as informações de identidade
                .AddDefaultTokenProviders(); //Inclui os tokens para troca de senha e envio de e-mail

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Piece, PieceViewModel>();
                cfg.CreateMap<PieceViewModel, Piece>();
                cfg.CreateMap<Ticket, TicketViewModel>();
                cfg.CreateMap<TicketViewModel, Ticket>()
                    .ForSourceMember(x => x.Seats, x => x.DoNotValidate()) //ignorando propriedade do source
                    .ForSourceMember(x => x.Pieces, x => x.DoNotValidate());
                //CreateMap<Contrato, ContratoDto>().ForMember(p => p.Descricao, x => x.Ignore());
                cfg.CreateMap<GeneratedTicketViewModel, GeneratedTicket>();
                cfg.CreateMap<GeneratedTicket, GeneratedTicketViewModel>();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<SaleTheaterTicketsContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("SaleTheaterTicketsContext"), builder =>
            builder.MigrationsAssembly("SaleTheaterTickets")));

            //Definindo instancia da interfaces e suas referidas implementações
            services.AddTransient<IPieceRepository, PieceRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IGeneratedTicketRepository, GeneratedTicketRepository>();

            //Adicionando o Fluent Validation ao pipeline
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { "pt-BR"};
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);


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

            app.UseAuthentication(); //Midleware que adiciona a autenticação ao pipeline da solicitação
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
