using System;
using Microsoft.Extensions.DependencyInjection;
using SevenWestMedia.Technical.ConsoleApp.Dependencies;
using SevenWestMedia.Technical.ConsoleApp.Writer;

namespace SevenWestMedia.Technical.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = IoC.ConfigureServices();

            const int userIdFilter = 42;
            const int userAgeFilter = 23;
            var consoleWriter = serviceProvider.GetRequiredService<IConsoleWriter>();
            consoleWriter.Write(userIdFilter, userAgeFilter);

            Console.Read();
        }
    }
}