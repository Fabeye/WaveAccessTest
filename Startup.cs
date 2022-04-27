using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test.Data;
using Test.Data.Interfaces;
using Test.Data.Repository;

namespace Test
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        [Obsolete]
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
           
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IMovie, MoviesRepository>();
            services.AddTransient<IActor, ActorsRepository>();
            services.AddTransient<IAccount, AccountsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Movies}/{action=Index}/{id?}"); //ты почему не работаешь? -_-
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>(); //подключаем весь AppDBContent потом с помощью функций из DBObjects будет работать с БД                                                                                //добраться к нему извне сервиса, поэтому для верной реализации необходимо окружить его в дополнительный сервис(область), которая будет служить нашей цели 

                DBObjects.Initial(content); //т.е. каждый раз при запуске программы будет вызываться эта функция
            }

        }
    }
}
