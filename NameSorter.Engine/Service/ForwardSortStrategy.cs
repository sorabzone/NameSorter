using NameSorter.Engine.Interface;
using System;

namespace NameSorter.Engine.Service
{
    public class ForwardSortStrategy : ISortStrategy
    {
        /// <summary>
        /// If there are multiple first names, it will sort them from left to right
        /// </summary>
        /// <param name="inputName"></param>
        /// <returns></returns>
        public string GetSearchStringFromName(string inputName)
        {
            var lastSpaceIndex = inputName.LastIndexOf(" ", StringComparison.Ordinal);
            var lastName = inputName.Substring(lastSpaceIndex, inputName.Length - lastSpaceIndex);
            var givenNames = inputName.Substring(0, lastSpaceIndex);
            return lastName + " " + givenNames;
        }
    }
}
