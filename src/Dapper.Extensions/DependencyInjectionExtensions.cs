﻿using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDapper<TDbProvider>(this IServiceCollection services) where TDbProvider : IDapper
        {
            return services.AddScoped(typeof(IDapper), typeof(TDbProvider));
        }
    }
}