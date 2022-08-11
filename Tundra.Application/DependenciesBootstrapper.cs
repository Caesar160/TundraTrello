﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Tundra.Application
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
