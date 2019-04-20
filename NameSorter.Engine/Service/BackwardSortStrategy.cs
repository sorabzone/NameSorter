using NameSorter.Engine.Interface;
using System;
using System.Linq;

namespace NameSorter.Engine.Service
{
    public class BackwardSortStrategy : ISortStrategy
    {
        /// <summary>
        /// If there are multiple first names, it will sort them from right to left
        /// </summary>
        /// <param name="inputName"></param>
        /// <returns></returns>
        public string GetSearchStringFromName(string inputName)
        {
            var splitNames = inputName.Split(" ");
            return string.Join(" ", splitNames.Reverse());
        }
    }
}
