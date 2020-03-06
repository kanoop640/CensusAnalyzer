using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    public class StateCensusAnalyser
    {
        public int StateCensusAnalyserData()
        {
            var csvfiledata = File.ReadAllLines(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv");
            return csvfiledata.Length;
        }
    }
}
