using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocketApi.AdelantoData;
using PocketApi.EmpleadoData;
using PocketApi.Models;
using PocketApi.PagoData;
using PocketApi.Tipo_EmpleadoData;

namespace PocketApi
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
            services.AddControllers();

            services.AddDbContextPool<PocketContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("PocketConnectionString")));

            services.AddScoped<IEmpleadoData, DbEmpleadoData>();
            services.AddScoped<IAdelantoData, DbAdelantoData>();
            services.AddScoped<IPagoData, DbPagoData>();
            services.AddScoped<ITipo_EmpleadoData, DbTipo_EmpleadoData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
