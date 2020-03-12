using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public delegate int CSVBulderDelgate(ICSVBuilder obj, string path, char delimiter = ',', string header = "");

    public class CSVBuilder
    {
        public int GetCSVBuilder(ICSVBuilder obj, string path, char delimiter = ',', string header = "")
        {
            int result = obj.OperationOnCSVFIle(path, delimiter, header);
            return result;
        }
    }
}
