using System;
using Microsoft.Extensions.DependencyInjection;
using SevenWestMedia.Technical.ConsoleApp.Printer;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Services.User;
using SevenWestMedia.Technical.Infrastructure.DataSources;

namespace SevenWestMedia.Technical.ConsoleApp.DependencyResolution
{
    public class IoC
    {
        public IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDataSource, JsonUserDataSource>();
            services.AddScoped<IPrinter, Printer.Printer>();

            return services.BuildServiceProvider();
        }
    }
}