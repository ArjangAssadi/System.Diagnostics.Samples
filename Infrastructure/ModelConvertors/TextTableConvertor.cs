using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Models;

namespace Infrastructure.ModelConvertors
{
    public class TextTableConvertor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textTable"></param>
        /// <param name="delimeter">delimeter to be used</param>
        /// <param name="delimiterreplacement">Replaces the delimeter in the values</param>
        /// <returns></returns>
        public IEnumerable<string> Delimeted(ITextTable textTable, string delimeter, string delimiterreplacement)
        {
            IList<string> result = new List<string>();

            foreach (ITextRow row in textTable.Rows)
            {
                string line = String.Empty;

                foreach (string value in row.Values)
                {
                    line += value.Replace(delimeter, delimiterreplacement) + delimeter;
                }

                result.Add(line);
            }

            return result;
        }

    }
}
