using System.Collections.Generic;
using System.Diagnostics;

namespace Domain.Contracts.Models
{
    public interface IPCCM1
    {
        string Help { get; set; }
        IEnumerable<string> InstanceNames { get; set; }
        string MachineName { get; set; }
        string Name { get; set; }
        PerformanceCounterCategoryType Type { get; set; }
    }
}