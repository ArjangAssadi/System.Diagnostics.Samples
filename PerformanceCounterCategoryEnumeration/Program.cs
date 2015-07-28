using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Domain.Contracts.Models;
using Domain.Models;
using Infrastructure.ModelConvertors;

namespace PerformanceCounterCategoryEnumeration
{
    class Program
    {
        static string delimeter = "|";
        static string delimiterreplacement = "-";

        static void Main(string[] args)
        {
            IEnumerable<PerformanceCounterCategory> pmcList = PerformanceCounterCategory.GetCategories().AsEnumerable();

            PCCM1Convertor pccm1Convertor = new PCCM1Convertor();
            IEnumerable<IPCCM1> categoryList = pccm1Convertor.Convert(pmcList);

            ITextTable tt = pccm1Convertor.Convert(categoryList);

            TextTableConvertor ttc = new TextTableConvertor();

            File.WriteAllLines(@"D:\PerformanceCounterCategories.txt", ttc.Delimeted(tt, delimeter, delimiterreplacement).ToArray());
        }
    }
}


