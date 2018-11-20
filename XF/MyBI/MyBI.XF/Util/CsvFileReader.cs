using System;
using System.IO;

namespace MyBI
{
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream) : base(stream) { }

        public CsvFileReader(string filename) : base(filename) { }

        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;
            int index = 0;
            int rowCount = 0;
            while (index < row.LineText.Length)
            {
                string value;
                if (row.LineText[index] == '"')
                {
                    index++;
                    int start = index;
                    while (index < row.LineText.Length)
                    {
                        if (row.LineText[index] == '"')
                        {
                            index++;
                            if (index >= row.LineText.Length || row.LineText[index] != '"')
                            {
                                index--;
                                break;
                            }
                        }
                        index++;
                    }
                    value = row.LineText.Substring(start, index - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    int start = index;
                    while (index < row.LineText.Length && row.LineText[index] != ',')
                        index++;
                    value = row.LineText.Substring(start, index - start);
                }
                if (rowCount < row.Count)
                    row[rowCount] = value;
                else
                    row.Add(value);
                rowCount++;
                while (index < row.LineText.Length && row.LineText[index] != ',')
                    index++;
                if (index < row.LineText.Length)
                    index++;
            }
            while (row.Count > rowCount)
                row.RemoveAt(rowCount);
            return (row.Count > 0);
        }
    }
}
