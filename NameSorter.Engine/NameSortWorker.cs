using NameSorter.Engine.Interface;
using NameSorter.Engine.Model;
using NameSorter.Engine.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NameSorter.Engine
{
    public class NameSortWorker
    {
        private readonly ISortStrategy _sortStrategy;

        /// <summary>
        /// Sort strategy and Output type is injected via constructor
        /// </summary>
        /// <param name="sortStrategy"></param>
        public NameSortWorker(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        /// <summary>
        /// Read names from text file and generates output.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<string> SortNames(string filename)
        {
            //Read names
            var names = ParseAndReadInput(filename);

            //Sort names
            return DoSorting(names);
        }

        /// <summary>
        /// Sort the list of names
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        private IEnumerable<string> DoSorting(List<Name> names)
        {
            return names
                .OrderBy(p => p.SearchString)
                .Select(p => p.FullName);
        }

        /// <summary>
        /// Read names from text file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private List<Name> ParseAndReadInput(string filename)
        {
            var names = new List<Name>();
            // Read file using StreamReader.Reads file line by line
            using (StreamReader file = new StreamReader(filename))
            {
                string fullName;

                while ((fullName = file.ReadLine()) != null)
                {
                    names.Add(new Name
                    {
                        FullName = fullName,
                        SearchString = _sortStrategy.GetSearchStringFromName(fullName)
                    });
                }
                file.Close();
            }
            return names;
        }
    }
}
