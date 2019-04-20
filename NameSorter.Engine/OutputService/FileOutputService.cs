using NameSorter.Engine.Interface;
using NameSorter.Engine.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter.Engine.OutputService
{
    public class FileOutputService : IOutputStrategy
    {
        /// <summary>
        /// Write result in text file
        /// </summary>
        /// <param name="output"></param>
        public async Task GenerateOutput(IEnumerable<string> names)
        {
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            await System.IO.File.WriteAllLinesAsync("sorted-names-list.txt", names);
        }
    }
}
