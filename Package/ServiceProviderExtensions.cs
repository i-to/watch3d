using System;

namespace Watch3D.Package
{
    static class ServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider provider)
            where TService : class =>
            (TService)provider.GetService(typeof(TService));

        public static TService GetService<TService, TQuery>(this IServiceProvider provider)
            where TService : class =>
            (TService)provider.GetService(typeof(TQuery));

        public static TService TryGetService<TService, TQuery>(this IServiceProvider provider)
            where TService : class =>
            provider.GetService(typeof(TQuery)) as TService;
    }
}
