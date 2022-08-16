namespace Tundra.Presentation.API.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tundra.Settings;
    using Tundra.Common.Constants;

    internal static class ApplicationSettingsExtensions
    {
        internal static IServiceCollection ConfigureApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TrelloSettings>(configuration.GetSection(Constants.TrelloSettings));
            return services;
        }
    }
}