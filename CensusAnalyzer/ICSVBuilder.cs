using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    interface ICSVBuilder
    {
        public int OperationOnCSVFIle(string path, char delemitier, string header);
    }
}
