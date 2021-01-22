using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class CheckPrinter
        {
            const string checkHeader = "Кассовый чек";
            const char hd = '-';
            const string verticalIndent = "\n";
            int checkWidth = 70;

            private List<string> check = new ()
            {
                checkHeader,
                verticalIndent
            };

            public CheckPrinter AppendLine(string line)
            {
                if (line.Length < checkWidth)
                {
                    check.Add(line);
                    return this;
                }

                StringBuilder sb = new();
                var startPosition = 0;
                var endPosition = checkWidth;
                var counts = line.Length/checkWidth;
                var times = line.Length%checkWidth > 0 ? ++counts : counts;
                for (var i = 0; i < times; i++)
                {
                    var cut = line[startPosition..endPosition].Trim();
                    if (i - 1 != times) sb.AppendLine(cut);
                    else sb.Append(cut);
                    startPosition = endPosition;
                    endPosition = endPosition + checkWidth > line.Length ? line.Length : endPosition + checkWidth;
                }
                
                check.Add(sb.ToString());

                return this;
            }


            #region Overrides of Object

            /// <inheritdoc />
            public override string ToString()
            {
                StringBuilder sb = new();
                check.ForEach(s => sb.AppendLine(s));

                return sb.ToString();
            }

            #endregion
        }
        
        public interface ICheckBlock{}

        public class LineBlock : ICheckBlock
        {
            private readonly string _line;

            public LineBlock(string line) => _line = line;

            #region Overrides of Object

            /// <inheritdoc />
            public override string ToString() => _line;

            #endregion
        }

        public class GridBlock : ICheckBlock
        {
            private int columns;
            private int maxWidth;

            private List<string[]> gridRows;
            public GridBlock(int columns, int maxWidth)
            {
                this.columns = columns;
                this.maxWidth = maxWidth;
            }

            public GridBlock AppendRow(string[] row)
            {
                if (row.Length != columns) throw new ArgumentException("Must be declared all columns");
                gridRows.Add(row);

                return this;
            }

            private int DetectMaxColumnWidth(string[] column)
            {

                return 0;
            }

            #region Overrides of Object

            /// <inheritdoc />
            public override string ToString()
            {
                StringBuilder sb = new();
                foreach (var row in gridRows)
                {
                    
                }

                return "";
            }

            #endregion
        }
}