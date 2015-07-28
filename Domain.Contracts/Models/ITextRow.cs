using System.Collections.Generic;

namespace Domain.Contracts.Models
{
    public interface ITextRow
    {
        void AddTextValue(string value);
        IEnumerable<string> Values { get; }
    }
}