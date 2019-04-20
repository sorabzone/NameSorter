using NameSorter.Engine.Interface;
using NameSorter.Engine.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter.Engine.OutputService
{
    public class ConsoleOutputService : IOutputStrategy
    {
        /// <summary>
        /// Prints output in console
        /// </summary>
        /// <param name="names"></param>
        public async Task GenerateOutput(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
