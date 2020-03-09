using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class Factory
    {
        public static CSVStateCensus StateCensusObject()
        {
            return new CSVStateCensus();
        }
        public static CSVStateDelegate CSVStatesObject()
        {
            return CSVStates.Delegate();
        }
    }
}
