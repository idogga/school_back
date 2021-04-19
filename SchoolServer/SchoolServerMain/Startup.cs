namespace SchoolServerMain
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using School.BL;
    using School.Database;
    using School.Sheduler;
    using School.Sheduler.Context;
    using SchoolServerMain.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shool API"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseHttpStatusCodeExceptionMiddleware();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddBLService();
            services.AddMappers();
            services.AddSwaggerGen(
                c =>
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Title = "School", Version = "v1"
                        }));

            var schoolConnection = Configuration.GetConnectionString("BaseSchoolPostgreSqlProvider");
            var schedulerConnection = Configuration.GetConnectionString("SchedulerPostgreSqlProvider");

            services.AddDbContext<SchoolContext>(
                options =>
                    options.UseNpgsql(schoolConnection).ConfigureWarnings(x => Debug.WriteLine($"Ошибка БД: {x}")));

            services.AddDbContext<SchedulerContext>(
                options =>
                    options.UseNpgsql(schedulerConnection).ConfigureWarnings(x => Debug.WriteLine($"Ошибка БД: {x}")));

            services.AddSchedulerServices();
        }
    }
}