using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public interface ICSVBuilder
    {
        public int OperationOnCSVFIle(string path, char delemitier, string header);
        public void IndianCsvFile();

    }
}
