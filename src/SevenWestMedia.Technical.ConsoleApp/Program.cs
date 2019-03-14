using Microsoft.Extensions.DependencyInjection;
using SevenWestMedia.Technical.ConsoleApp.DependencyResolution;
using SevenWestMedia.Technical.ConsoleApp.Printer;

namespace SevenWestMedia.Technical.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = IoC.ConfigureServices();

            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.Print();
        }
    }
}