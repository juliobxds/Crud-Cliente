using AutoMapper;
using Crud_Cliente.App.Dtos;
using Crud_Cliente.BancoDeDados;
using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.BancoDeDados.Repositorios;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Dtos;
using Crud_Clientes.Negocio.Interfaces;
using Crud_Clientes.Negocio.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Crud_Cliente.App {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews();
            services.AddScoped<IRepositorio<Cliente>, ClienteRepositorio>();
            services.AddScoped<IRepositorio<Endereco>, EnderecoRepositorio>();
            services.AddScoped<IService<ClienteDto>, ClienteServico>();
            services.AddScoped<IService<EnderecoDto>, EnderecoServico>();

            services.AddDbContext<Contexto>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
