using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecureVault.Domain.Exceptions;
using SecureVault.Domain.Ports;
using SecureVault.Domain.UseCases;
using SecureVault.Persistence;

namespace SecureVault.Web
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
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Startup>(optional: true);

            RegisterDependencies(services);

            var settings = new Settings();
            
            config.Build().Bind(settings);

            services.AddDbContext<SecureVaultContext>(builder =>
                builder.UseSqlServer(
                    Configuration["ConnectionString:SecureVaultDB"],
                    optionsBuilder => optionsBuilder.MigrationsAssembly("SecureVault.Persistence"))
            );
            services.AddControllersWithViews();
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IAddBankUseCase, AddBankUseCase>();
            services.AddTransient<ISecureVaultDataStore, SecureVaultDataStore>();
            services.AddTransient<IGetBanksUseCase, GetBanksUseCase>();
            services.AddTransient<IGetBankByIdUseCase, GetBankByIdUseCase>();
            services.AddTransient<IUpdateBankUseCase, UpdateBankUseCase>();
            services.AddTransient<IDeleteBankUseCase, DeleteBankUseCase>();
            services.AddTransient<IGetCardTypesUseCase, GetCardTypesUseCase>();
            services.AddTransient<IAddCardUseCase, AddCardUseCase>();
            services.AddTransient<IGetCardsUseCase, GetCardsUseCase>();
            services.AddTransient<IGetCardByIdUseCase, GetCardByIdUseCase>();
            services.AddTransient<IUpdateCardUseCase, UpdateCardUseCase>();
            services.AddTransient<IDeleteCardUseCase, DeleteCardUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
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
                    pattern: "{controller=Bank}/{action=Index}/{id?}");
            });
        }
    }
}
