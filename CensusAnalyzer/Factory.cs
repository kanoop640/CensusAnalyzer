using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class Factory
    {
        public static ICSVBuilder StateCensusObject()
        {
            return new CSVStateCensus();
        }
        public static ICSVBuilder CSVStateCode()
        {
            return new CSVStates();
        }
    }
}
