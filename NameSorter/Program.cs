using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Engine.Service;
using NameSorter.Engine;
using NameSorter.Logger;
using NameSorter.Engine.Interface;
using NameSorter.Engine.OutputService;

namespace NameSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //setup our DI
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<ISortStrategy>(s => new ForwardSortStrategy())
                    .AddSingleton<ConsoleOutputService>()
                    .AddSingleton<FileOutputService>()
                    .AddSingleton<NameSortWorker>()
                    .BuildServiceProvider();

                if (args.Length == 1)
                {
                    var worker = serviceProvider.GetService<NameSortWorker>();
                    var sortedNames = worker.SortNames(args[0]);

                    var fileOutput = serviceProvider.GetService<FileOutputService>();
                    var consoleOutput = serviceProvider.GetService<ConsoleOutputService>();

                    await Task.WhenAll(fileOutput.GenerateOutput(sortedNames), consoleOutput.GenerateOutput(sortedNames));
                }
                else
                {
                    CommonLogger.LogError("Please provide file name.");
                }
            }
            catch (Exception ex)
            {
                //NLog logger is configured to print error in Console, but we can write in file as well.
                //I write configuration to write log to a file, but commented it for now in NLog.config
                CommonLogger.LogError(ex);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
