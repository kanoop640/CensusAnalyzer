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
            return Factory.Delegate();
        }
        public static CSVStateDelegate Delegate()
        {
            CSVStates cSVStates = new CSVStates();
            return new CSVStateDelegate(cSVStates.OperationOnCSVFIle);
        }
    }
}
