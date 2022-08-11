namespace Tundra.Presentation.API.Extensions.ServiceCollectionExtensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tundra.Settings;

    internal static class ApplicationSettingsExtensions
    {
        internal static IServiceCollection ConfigureApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TrelloSettings>(configuration.GetSection("TrelloSettings"));
            return services;
        }
    }
}
