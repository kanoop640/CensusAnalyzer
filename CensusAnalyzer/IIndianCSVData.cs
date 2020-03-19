using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    interface IIndianCSVData
    {
        public List<Dictionary<string, object>> IndianCensusData();
    }
}
