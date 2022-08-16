using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tundra.Application.Interfaces;
using Tundra.Presentation.API.Extensions;
using Tundra.Trello.Services;
using Tundra.Application;
using Tundra.Application.Mappings;
using FluentValidation;
using Tundra.Application.Models;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;
using System.Reflection;

namespace TrelloAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.ConfigureApplicationSettings(this.Configuration);
            services.AddHttpClient<IBoardsService, BoardsService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrelloAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrelloAPI v1"));
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
