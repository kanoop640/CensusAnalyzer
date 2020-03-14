using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class Factory
    {
        public static ICSVBuilder CSVStatesObject()
        {
            return new CSVStates();
        }
    }
}
