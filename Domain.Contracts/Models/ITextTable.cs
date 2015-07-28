using System.Collections.Generic;

namespace Domain.Contracts.Models
{
    public interface ITextTable
    {
        IEnumerable<ITextRow> Rows { get; set; }
    }
}