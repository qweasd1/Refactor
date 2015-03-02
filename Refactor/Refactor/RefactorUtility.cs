using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Refactor
{
    //TODO_High: when we insert text, if the insert point out of range of the current range, we should complete it.
    //TODO: complete all the exceptions
    public class RefactorUtility
    {

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
                
                string rowDelimiter = null;
                int rowDelimiterLength;

                if (IsWindows)
                {
                    //TODO: Windows Row delimiter
                    rowDelimiter = "\r\n";
                    rowDelimiterLength = 2;
                }
                else
                {
                    //TODO: Linux Row delimiter
                    rowDelimiter = "\n";
                    rowDelimiterLength = 1;
                }

                var originLines = Regex.Split(originText, rowDelimiter);
                var eachLineLengths = originLines.Select(x => x.Length + rowDelimiterLength).ToArray();
                checkIfInsertPositionOutofRange(insertItems, eachLineLengths);

                var insertList = insertItems.Select((x) =>
                {
                    int fullRowCount = x.Postion.LineNumber;
                    int insertIndex = eachLineLengths.Take(fullRowCount - 1).Sum() + x.Postion.ColumnNumber - 1;
                    return new { insertIndex, x.Text };
                }).OrderBy(x=>x.insertIndex).ToArray();

                //head
                string head = originText.Substring(0, insertList[0].insertIndex);
                result.Append(head);

                //body
                for (int i = 0; i < insertList.Length - 1; i++)
                {
                   result.Append(insertList[i].Text);
                   result.Append(originText.Substring(insertList[i].insertIndex, insertList[i + 1].insertIndex - insertList[i].insertIndex));
                }

                //tail
                var tail = insertList.Last();
                result.Append(tail.Text);
                result.Append(originText.Substring(tail.insertIndex));
                
            }
            else
            {
                //one line
                checkIfInsertPositionOutofRange(insertItems,originText.Length);
                
                var insertList = insertItems.Select(x=>new{Index = x.Postion.ColumnNumber - 1, Text = x.Text}).OrderBy(x=>x.Index).ToArray();

                //head
                result.Append(originText.Substring(0,insertList[0].Index));
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

            return result.ToString();
        }

        /// <summary>
        /// Insert only one item
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        public static string InsertOneItem(string originText, InsertItem insertItem)
        {
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
                    rowDelimiterLength = 2;
                }
                else
                {
                    rowDelimiter = "\n";
                    rowDelimiterLength = 1;
                }

                var eachLineLengths = Regex.Split(originText, rowDelimiter).Select(x => x.Length + rowDelimiterLength).ToArray();
                if (insertItem.Postion.LineNumber >= 1 && insertItem.Postion.LineNumber <=eachLineLengths.Length)
                {
                    if (insertItem.Postion.ColumnNumber >= 1 && insertItem.Postion.ColumnNumber <= eachLineLengths[insertItem.Postion.LineNumber - 1])
                    {
                        var insertIndex = eachLineLengths.Take(insertItem.Postion.LineNumber - 1).Sum() + insertItem.Postion.ColumnNumber - 1;
                        newText = originText.Insert(insertIndex, insertItem.Text);
                        return newText;
                    }
                }
                throw new InvalidOperationException("out of range");
            }
            else
            {
                //TODO: now no check whether the position is out of range
                newText = originText.Insert(insertItem.Postion.ColumnNumber - 1, insertItem.Text);
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

        private static void checkIfInsertPositionOutofRange(InsertItem[] insertItems, int[] eachLineLengths)
        {         

            var outOfRangeInsertItems =  insertItems.Where((x) =>
            {
                if ((x.Postion.LineNumber >= 1 && x.Postion.LineNumber <= eachLineLengths.Length))
                {
                    if (x.Postion.ColumnNumber >= 1 && x.Postion.ColumnNumber <= eachLineLengths[x.Postion.LineNumber - 1])
                    {
                        return false;
                    }
                }

                return true;
            }).ToArray();

            if (outOfRangeInsertItems.Length > 0)
            {
                throw new InvalidOperationException("these insert positions are outof range: " + outOfRangeInsertItems.Select(x => x.Postion.ToString()).Aggregate((head, next) => head + ", " + next));
            }
        }

        private static void checkIfInsertPositionOutofRange(InsertItem[] insertItems, int originalLineLength)
        {
            var outOfRangeInsertItems = insertItems.Where((x)=>{
                return (x.Postion.LineNumber > 1 || ( x.Postion.ColumnNumber >=1 && x.Postion.ColumnNumber <= originalLineLength));
            }).ToArray();

            if (outOfRangeInsertItems.Length > 0)
            {
                throw new InvalidOperationException("these insert positions are outof range: " + outOfRangeInsertItems.Select(x => x.Postion.ToString()).Aggregate((head, next) => head + ", " + next));
            }
        }
    }
}
