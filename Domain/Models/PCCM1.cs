using System.Collections.Generic;
using System.Diagnostics;
using Domain.Contracts.Models;

namespace Domain.Models
{
    /// <summary>
    /// Used to have one of the models for PerformanceCounterCategory
    /// </summary>
    public class PCCM1 : IPCCM1
    {
        public PCCM1()
        {
        }

        public string Name { get; set; }
        public string Help { get; set; }
        public PerformanceCounterCategoryType Type { get; set; }
        public string MachineName { get; set; }
        public IEnumerable<string> InstanceNames { get; set; }
    }
}