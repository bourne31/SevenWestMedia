using System;
using Microsoft.Extensions.DependencyInjection;
using SevenWestMedia.Technical.ConsoleApp.Writer;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Services.User;
using SevenWestMedia.Technical.Infrastructure.DataProviders;
using SevenWestMedia.Technical.Infrastructure.Stream;

namespace SevenWestMedia.Technical.ConsoleApp.DependencyResolution
{
    public static class IoC
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IStreamWrapper, StreamWrapper>();
            services.AddScoped<IUserDataProvider, JsonUserDataProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IConsoleWriter, ConsoleWriter>();

            return services.BuildServiceProvider();
        }
    }
}