// <copyright file="CSVStateCensus.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
namespace CensusAnalyzer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using CsvHelper;

    public class CSVStates
    {
        /// <summary>
        /// CSVs the data count.
        /// which return the number of data which it reads form 
        /// StateCensusData.csv file
        /// </summary>
        /// <returns></returns>
        public int LoadCSVStateData(string path)
        {
            int count = 0;
            var csvData = File.ReadAllLines(path);
            IEnumerable<string> IterateCsvFile = csvData;
            foreach (string line in IterateCsvFile)
            {
                count++;
            }
            return count;
        }
    }
}
