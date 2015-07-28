using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Domain.Contracts.Models;
using Domain.Models;
using Infrastructure.GenericConvertors;

namespace Infrastructure.ModelConvertors
{
    public class PCCM1Convertor
    {
        public IEnumerable<IPCCM1> Convert(IEnumerable<PerformanceCounterCategory> performanceCounterCategories)
        {
            IList<IPCCM1> result = new List<IPCCM1>();

            foreach (var performanceCounterCategory in performanceCounterCategories)
            {
                IPCCM1 pccm1 = new PCCM1();
                pccm1.Name = performanceCounterCategory.CategoryName;
                pccm1.Help = performanceCounterCategory.CategoryHelp;
                pccm1.Type = performanceCounterCategory.CategoryType;

                pccm1.MachineName = performanceCounterCategory.MachineName;
                pccm1.InstanceNames = performanceCounterCategory.GetInstanceNames().AsEnumerable();

                result.Add(pccm1);
            }
            return result;
        }

        public ITextTable Convert(IEnumerable<IPCCM1> pccm1List)
        {
            ITextTable vt = new TextTable();
            IList<ITextRow> rows = new List<ITextRow>();
            StringConvertor sc = new StringConvertor();

            ITextRow headerRow = new TextRow();
            headerRow.AddTextValue("Name");
            headerRow.AddTextValue("Help");
            headerRow.AddTextValue("Type");
            headerRow.AddTextValue("MachineName");
            headerRow.AddTextValue("InstanceNames");
            rows.Add(headerRow);

            foreach (var pmcc in pccm1List)
            {
                ITextRow row = new TextRow();
                row.AddTextValue(pmcc.Name);
                row.AddTextValue(pmcc.Help);
                row.AddTextValue(sc.EnumDescription(pmcc.Type));
                row.AddTextValue(pmcc.MachineName);
                row.AddTextValue(sc.Delimeted(pmcc.InstanceNames, ","));
                rows.Add(row);
            }
            vt.Rows = rows;
            return vt;
        }
    }
}