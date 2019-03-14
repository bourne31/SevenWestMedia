using System;
using Microsoft.Extensions.DependencyInjection;
using SevenWestMedia.Technical.ConsoleApp.DependencyResolution;
using SevenWestMedia.Technical.ConsoleApp.Writer;

namespace SevenWestMedia.Technical.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = IoC.ConfigureServices();

            const int userId = 42;
            const int userAge = 23;
            var consoleWriter = serviceProvider.GetRequiredService<IConsoleWriter>();
            consoleWriter.Write(userId, userAge);

            Console.Read();
        }
    }
}