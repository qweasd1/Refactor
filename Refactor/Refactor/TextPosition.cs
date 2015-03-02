using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactor
{
    public struct TextPosition
    {
        public int LineNumber;
        public int ColumnNumber;

        public TextPosition(int lineNumber, int columnNumber)
        {
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", LineNumber, ColumnNumber);
        }
    }
}
