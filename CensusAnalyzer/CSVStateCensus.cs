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
    public class CSVStateCensus
    {
        /// <summary>
        /// CSVs the data count.
        /// which return the number of data which it reads form 
        /// StateCensusData.csv file
        /// </summary>
        /// <returns></returns>
        public int LoadCSVStateData()
        {
            string[] str = File.ReadAllLines(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv");
            return str.Length;

        }
    }
}
