using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Refactor
{
    //TODO_High: when we insert text, if the insert point out of range of the current range, we should complete it.
    //TODO: complete all the exceptions
    //TODO: check when position is: LineNumber < 1 or ColumnNumber < 1
    //TODO: complete test, especially encounter [*]\r[*]\n[*]
    //TODO: complete test2 : expand scenario
    public class RefactorUtility
    {
        const string SPACE = " ";
        public static string RowDelimiter = "\r\n";

        public static string BulkInsert(string originText, InsertItem[] insertItems)
        {
            string newText = string.Empty;

            if (insertItems == null || insertItems.Length == 0)
            {
                newText = originText;
            }
            else
            {
                if (insertItems.Length == 1)
                {
                    newText = InsertOneItem(originText, insertItems[0]);
                }
                else
                {
                    newText = InsertMoreThanOneItem(originText, insertItems);
                }
            }

            return newText;
        }

        /// <summary>
        /// Caution: this method must input as least 2 insertItems
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="insertItems"></param>
        /// <param name="outRowDelimiter"></param>
        /// <returns></returns>
        public static string InsertMoreThanOneItem(string originText, InsertItem[] insertItems)
        {
            if (insertItems == null || insertItems.Length < 2)
            {
                throw new ArgumentException("insertItems should have at least 2 item", "insertItems");
            }

            StringBuilder result = new StringBuilder();

            checkIfInsertPositionSame(insertItems);
                        
            bool IsMultiLine = originText.Contains("\n");
            bool IsWindows = originText.Contains("\r");
            if (IsMultiLine)
            {

                insertMultilines(originText, insertItems, result, IsWindows);
                
            }
            else
            {
                //one line
                var expandedOriginText = ExpandInsertPositionRange(insertItems,originText,RowDelimiter);
                var expandedEachLines = Regex.Split(expandedOriginText, RowDelimiter);

                if (expandedEachLines.Length > 1)
                {
                    insertMultilines(expandedOriginText, insertItems, result, true);
                }
                else
                {
                    insertOneLine(originText, insertItems, result);
                }
                
            }

            return result.ToString();
        }

        private static void insertOneLine(string originText, InsertItem[] insertItems, StringBuilder result)
        {
            var insertList = insertItems.Select(x => new { Index = x.Postion.ColumnNumber - 1, Text = x.Text }).OrderBy(x => x.Index).ToArray();

            //head
            result.Append(originText.Substring(0, insertList[0].Index));
            //body
            for (int i = 0; i < insertList.Length - 1; i++)
            {
                result.Append(insertList[i].Text);
                result.Append(originText.Substring(insertList[i].Index, insertList[i + 1].Index - insertList[i].Index));
            }
            //tail
            var lastiItem = insertList.Last();
            result.Append(lastiItem.Text);
            result.Append(originText.Substring(lastiItem.Index));
        }

        private static void insertMultilines(string originText, InsertItem[] insertItems, StringBuilder result, bool IsWindows)
        {
            string rowDelimiter = null;
            int rowDelimiterLength;

            if (IsWindows)
            {
                //TODO: Windows Row delimiter
                rowDelimiter = "\r\n";
                rowDelimiterLength = 1;
            }
            else
            {
                //TODO: Linux Row delimiter
                rowDelimiter = "\n";
                rowDelimiterLength = 1;
            }

            var originLines = Regex.Split(originText, rowDelimiter);

            var expandOriginText = ExpandInsertPositionRange(insertItems, originLines, rowDelimiter);
            var expandedEachLines = Regex.Split(expandOriginText, rowDelimiter);
            var expandedEachLineLengths = expandedEachLines.Select(x => x.Length + 1).ToArray();

            var insertList = insertItems.Select((x) =>
            {
                int fullRowCount = x.Postion.LineNumber;
                int insertIndex = expandedEachLineLengths.Select(y=>IsWindows ? y+1: y).Take(fullRowCount - 1).Sum() + x.Postion.ColumnNumber - 1;
                return new { insertIndex, x.Text };
            }).OrderBy(x => x.insertIndex).ToArray();

            //head
            string head = expandOriginText.Substring(0, insertList[0].insertIndex);
            result.Append(head);

            //body
            for (int i = 0; i < insertList.Length - 1; i++)
            {
                result.Append(insertList[i].Text);
                result.Append(expandOriginText.Substring(insertList[i].insertIndex, insertList[i + 1].insertIndex - insertList[i].insertIndex));
            }

            //tail
            var tail = insertList.Last();
            result.Append(tail.Text);
            result.Append(expandOriginText.Substring(tail.insertIndex));
        }

        /// <summary>
        /// Insert only one item
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        public static string InsertOneItem(string originText, InsertItem insertItem)
        {
            StringBuilder resultBuilder = new StringBuilder(originText);
            string newText = string.Empty;
            bool IsMultiLine = originText.Contains("\n");
            bool IsWindows = originText.Contains("\r");

            string rowDelimiter = null;
            int rowDelimiterLength = 0;
            if (IsMultiLine)
            {
                if (IsWindows)
                {
                    rowDelimiter = "\r\n";
                    rowDelimiterLength = 1;
                }
                else
                {
                    rowDelimiter = "\n";
                    rowDelimiterLength = 1;
                }

                var eachLines = Regex.Split(originText, rowDelimiter).ToList();
                var newLineNumber = insertItem.Postion.LineNumber - eachLines.Count;
                if (newLineNumber > 0)
                {
                    eachLines.Add(string.Empty);
                }

                var newColumnNumber = insertItem.Postion.ColumnNumber - eachLines[insertItem.Postion.LineNumber - 1].Length - 1;
                if (newColumnNumber > 0)
                {
                    var expandedLine = eachLines[insertItem.Postion.LineNumber-1] + (Enumerable.Range(0, newColumnNumber).Select(x => SPACE).Aggregate((x, y) => x + y));
                    eachLines.RemoveAt(insertItem.Postion.LineNumber - 1);
                    eachLines.Insert(insertItem.Postion.LineNumber - 1, expandedLine);
                }

                var eachLineLengths = eachLines.Select(x => x.Length + 1).ToArray();
                var expandText = string.Join(rowDelimiter, eachLines);
                var insertIndex = eachLineLengths.Select(x=>IsWindows ? x+1: x).Take(insertItem.Postion.LineNumber - 1).Sum() + insertItem.Postion.ColumnNumber - 1;
                newText = expandText.Insert(insertIndex, insertItem.Text);
                return newText;
            }
            else
            {
                //TODO: now no check whether the position is out of range

                var newAddedColumn = insertItem.Postion.ColumnNumber - originText.Length - 1;
                string expandText = originText;
                if (newAddedColumn > 0)
                {
                    expandText += string.Join(string.Empty, Enumerable.Range(0, newAddedColumn).Select(x => SPACE));
                }

                newText = expandText.Insert(insertItem.Postion.ColumnNumber - 1, insertItem.Text);
            }
            return newText;
        }
        
        private static void checkIfInsertPositionSame(InsertItem[] insertItems)
        {
            var duplicateValues = insertItems.ToLookup(x => x.Postion).Where(x => x.Count() > 1);
           
            if (duplicateValues.Count() > 0)
            {
                string  duplicatePositionMessage = duplicateValues.Select(x => x.Key.ToString()).Aggregate((head, next) => head + ", " + next);
                throw new InvalidOperationException("there are position which is duplicate: " + duplicatePositionMessage);
            }
        }

        public static string ExpandInsertPositionRange(InsertItem[] insertItems, string[] eachLines,string rowDelimieter)
        {
            var eachLines_expandRow = new List<string>(eachLines);
            var originMaxLine = eachLines.Length;
            var insertMaxLine = insertItems.Select(x=>x.Postion.LineNumber).Max();
            if (insertMaxLine > originMaxLine)
            {
                 var newRowCount = insertMaxLine - originMaxLine;
                 for (int i = 0; i < newRowCount; i++)
                 {
                     eachLines_expandRow.Add(string.Empty);
                 }
            }

            var MaxColumnInsertForEachLines = (from i in insertItems
                                               group i by i.Postion.LineNumber
                                                   into lgroup
                                                   let lineNumber = lgroup.Key
                                                   let MaxColumn = lgroup.Max(x => x.Postion.ColumnNumber)
                                                   select new { LineNumber = lineNumber, maxColumn = MaxColumn }).ToDictionary(x => x.LineNumber, x => x.maxColumn);
            var expandTextBuilder = new StringBuilder();
            for (int i = 0; i < eachLines_expandRow.Count; i++)
            {
                expandTextBuilder.Append(eachLines_expandRow[i]);
                if (MaxColumnInsertForEachLines.ContainsKey(i + 1))
                {
                    int columnNeeded = (MaxColumnInsertForEachLines[i + 1] - eachLines_expandRow[i].Length - 1);
                    if (columnNeeded > 0)
                    {
                        var spaces = Enumerable.Range(0, columnNeeded).Select(x => SPACE).Aggregate((x, y) => x + y);
                        expandTextBuilder.Append(spaces);
                    }
                }
                if (i != eachLines_expandRow.Count - 1)
                {
                    expandTextBuilder.Append(rowDelimieter);
                }                
            }

            return expandTextBuilder.ToString();
            //var outOfRangeInsertItems =  insertItems.Where((x) =>
            //{
            //    if ((x.Postion.LineNumber >= 1 && x.Postion.LineNumber <= eachLineLengths.Length))
            //    {
            //        if (x.Postion.ColumnNumber >= 1 && x.Postion.ColumnNumber <= eachLineLengths[x.Postion.LineNumber - 1])
            //        {
            //            return false;
            //        }
            //    }

            //    return true;
            //}).ToArray();

            //if (outOfRangeInsertItems.Length > 0)
            //{
            //    throw new InvalidOperationException("these insert positions are outof range: " + outOfRangeInsertItems.Select(x => x.Postion.ToString()).Aggregate((head, next) => head + ", " + next));
            //}
        }

        private static string ExpandInsertPositionRange(InsertItem[] insertItems, string originalLine, string rowDelimieter)
        {
            return ExpandInsertPositionRange(insertItems, new string[] { originalLine }, rowDelimieter);
            //var outOfRangeInsertItems = insertItems.Where((x)=>{
            //    return (x.Postion.LineNumber > 1 || ( x.Postion.ColumnNumber >=1 && x.Postion.ColumnNumber <= originalLineLength));
            //}).ToArray();

            //if (outOfRangeInsertItems.Length > 0)
            //{
            //    throw new InvalidOperationException("these insert positions are outof range: " + outOfRangeInsertItems.Select(x => x.Postion.ToString()).Aggregate((head, next) => head + ", " + next));
            //}
        }
    }
}
