using NameSorter.Engine.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter.Engine.Interface
{
    public interface IOutputStrategy
    {
        Task GenerateOutput(IEnumerable<string> names);
    }
}
