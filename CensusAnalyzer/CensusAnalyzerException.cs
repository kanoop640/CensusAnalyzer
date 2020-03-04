using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class CensusAnalyzerException : Exception
    {
        string message;
        public CensusAnalyzerException(string msg)
        {
            this.message = msg;
        }

        public string GetMessage { get => message; }
    }
}
