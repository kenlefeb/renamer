using System;
using CommandLine;
using Console.Commands;
using Console.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console
{
    public class Program
    {
        public static int Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices(Services.Configure)
                .Build();
            var rename = host.Services.GetRequiredService<Commands.Rename.Command>();

            var result = CommandLine.Parser.Default.ParseArguments<Commands.Rename.Options>(args)
                .MapResult(
                    options => rename.Invoke(options),
                    errs => ErrorLevel.UnhandledException);

            return (int)result;
        }
    }
}
