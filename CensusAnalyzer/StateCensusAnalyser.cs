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
        public int CSVFileData(string path)
        {
            var csvfiledata = File.ReadAllLines(path);
            return csvfiledata.Length;
        }
    }
}
