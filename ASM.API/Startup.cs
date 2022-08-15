using ASM.API.MapConfig;
using ASM.API.Model;
using ASM.SHARE;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ASM.API
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
            services.AddOptions();

            // services.AddDbContextPool<ShopContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Connect"), b => b.MigrationsAssembly("ASM.API")));
            services.AddDbContextPool<ShopContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Connect"), b => b.MigrationsAssembly("ASM.API")));


            services.AddCors(options => options.AddPolicy(
                    "_mypolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                )
                 );

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASM.API", Version = "v1" });
            });

            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IProduct, ProductRepository>();

            services.Configure<DropBoxApiConfig>(Configuration.GetSection("DropBoxApiConfigs"));
            services.AddScoped<ICategory, CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASM.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("_mypolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
