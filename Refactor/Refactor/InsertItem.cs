using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactor
{
    public class InsertItem
    {
        public string Text { get; set; }
        public TextPosition Postion { get; set; }

        public InsertItem(int lineNumber, int columnNumber, string text)
        {
            Postion = new TextPosition(lineNumber, columnNumber);
            Text = text;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Postion.ToString(), Text);
        }
    }
}
