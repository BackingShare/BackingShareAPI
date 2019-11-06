using Backing_Share___API.Helpers;
using Backing_Share___API.Models;
using Backing_Share___API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backing_Share___API
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddTransient<IUsersHelper, UsersHelper>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IProjectsHelper, ProjectsHelper>();
            services.AddTransient<IProjectsRepository, ProjectsRepository>();
            services.AddTransient<IAudioHelper, AudioHelper>();
            services.AddTransient<IAudioRepository, AudioRepository>();
            //Fetching Connection string from APPSETTINGS.JSON  
            var ConnectionString = Configuration.GetConnectionString("Backing_ShareContext");
            var ArmazenamentoConnectionString = Configuration.GetConnectionString("StorageConnectionString");

            //Entity Framework  
            services.AddDbContext<BackingShareContext>(options => options.UseSqlServer(ConnectionString));


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
