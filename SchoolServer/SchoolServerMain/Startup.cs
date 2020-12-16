namespace SchoolServerMain
{
    using System;
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using School.BL;

    using Swashbuckle.AspNetCore.SwaggerGen;

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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Shool API"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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
                {
                    c.SwaggerDoc("v2", new OpenApiInfo { Title = "School", Version = "v2" });
                    c.DocumentFilter<YamlDocumentFilter>();
                });

        }

        private class YamlDocumentFilter : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                string file = AppDomain.CurrentDomain.BaseDirectory + "swagger.yaml";
                if (File.Exists(file))
                    File.Delete(file);

                    var serializer = new YamlDotNet.Serialization.Serializer();
                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, swaggerDoc);
                        var stream = new StreamWriter(file);
                        stream.WriteLine(writer.ToString());
                    }
                
            }
        }
    }
}