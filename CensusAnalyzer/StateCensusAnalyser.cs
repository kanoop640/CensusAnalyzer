// <copyright file="StateCensusAnalyser.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
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
        public int StateCodeData()
        {
            var csvFileData = File.ReadAllLines(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv");
            return csvFileData.Length;
        }
    }
}
