using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceCounterCategoryEnumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounterCategory[] performanceCounterCategories = PerformanceCounterCategory.GetCategories();
            List<string> categories = new List<string>();

            categories.Add("Name|Help|Type|MachineName|InstanceNames");
            foreach (var performanceCounterCategory in performanceCounterCategories)
            {
                string[] instanceNames = performanceCounterCategory.GetInstanceNames();
                string instanceNamesCSV = "";

                if (instanceNames.Length > 0)
                {
                    instanceNamesCSV = instanceNames.Aggregate((m, n) => m + "," + n);
                }


                categories.Add(
                    String.Format("{0}|{1}|{2}|{3}|{4}",
                    performanceCounterCategory.CategoryName.Replace("|", "-"),
                    performanceCounterCategory.CategoryHelp.Replace("|", "-"),
                    performanceCounterCategory.CategoryType.GetEnumDescription().Replace("|", "-"),
                    performanceCounterCategory.MachineName.Replace("|", "-"),
                    instanceNamesCSV.Replace("|", "-"))
                    );


            }

            System.IO.File.WriteAllLines(@"D:\PerformanceCounterCategories.txt", categories.ToArray());
        }
    }
}
