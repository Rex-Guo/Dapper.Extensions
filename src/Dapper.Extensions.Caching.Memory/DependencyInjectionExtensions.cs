﻿using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Extensions.Caching.Memory
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDapperCachingInMemory(this IServiceCollection service, MemoryConfiguration config)
        {
            service.AddSingleton<ICacheKeyBuilder, DefaultCacheKeyBuilder>();
            service.AddSingleton(new CacheConfiguration
            {
                Enable = config.Enable,
                Expire = config.Expire
            });
            service.AddMemoryCache();
            service.AddSingleton<ICacheProvider, MemoryCacheProvider>();
            return service;
        }

        public static IServiceCollection AddDapperCachingInMemory<TCacheKeyBuilder>(this IServiceCollection service, MemoryConfiguration config) where TCacheKeyBuilder : ICacheKeyBuilder
        {
            service.AddSingleton(typeof(ICacheKeyBuilder), typeof(TCacheKeyBuilder));
            service.AddSingleton(new CacheConfiguration
            {
                Enable = config.Enable,
                Expire = config.Expire
            });
            service.AddMemoryCache();
            service.AddSingleton<ICacheProvider, MemoryCacheProvider>();
            return service;
        }
    }
}
