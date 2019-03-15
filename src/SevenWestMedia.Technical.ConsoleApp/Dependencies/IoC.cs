using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SevenWestMedia.Technical.ConsoleApp.Writer;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Services.User;
using SevenWestMedia.Technical.Infrastructure.DataProviders;
using SevenWestMedia.Technical.Infrastructure.Stream;

namespace SevenWestMedia.Technical.ConsoleApp.Dependencies
{
    public static class IoC
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddScoped<IStreamWrapper, StreamWrapper>()
                .AddScoped<IUserDataProvider, JsonUserDataProvider>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IConsoleWriter, ConsoleWriter>()
                .AddLogging(builder =>
                    {
                        builder.SetMinimumLevel(LogLevel.Trace);
                        builder.AddNLog(new NLogProviderOptions
                        {
                            CaptureMessageTemplates = true,
                            CaptureMessageProperties = true
                        });
                    }
                );


            return services.BuildServiceProvider();
        }
    }
}