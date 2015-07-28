using System.Collections;
using System.Collections.Generic;
using Domain.Contracts.Models;

namespace Domain.Models
{   
    public class TextTable : ITextTable
    {
        public TextTable()
        {
            Rows = new List<ITextRow>();
        }

        public IEnumerable<ITextRow> Rows { get; set; }
    }
}
