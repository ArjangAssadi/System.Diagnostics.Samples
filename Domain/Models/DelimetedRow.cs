using System.Collections.Generic;
using Domain.Contracts.Models;

namespace Domain.Models
{
    public class TextRow : ITextRow
    {   
        private IList<string> _values;

        /// <summary>
        /// Makes it easier to manage a delimeted line as an object
        /// </summary>
        /// <param name="delimeter">Delimeter Being Used for this delimeted text</param>
        /// <param name="notDelimeter">the string to replace the delimeter in the values</param>
        public TextRow()
        {   
            _values = new List<string>();
        }

        /// <summary>
        /// Add a value to the line
        /// </summary>
        /// <param name="value"></param>
        public void AddTextValue(string value)
        {
            _values.Add(value);
        }

        public IEnumerable<string> Values
        {
            get { return _values; }
        }
    }
}