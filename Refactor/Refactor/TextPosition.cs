using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactor
{
    public class TextPosition
    {
        public TextPosition(int lineNumber, int columnNumber)
        {
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
        public int LineNumber { get; private set; }
        public int ColumnNumber { get; private set; }
    }
}
