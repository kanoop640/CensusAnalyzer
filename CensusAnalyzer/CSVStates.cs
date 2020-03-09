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

    public delegate int CSVStateDelegate(string path, char delemeter = ',', string header = "SrNo,State,Name,TIN,StateCode");
    /// <summary>
    /// It is CSVState class which read StateCode.csv file.
    /// It inherit from interface ICSVBuilder
    /// </summary>
    /// <seealso cref="CensusAnalyzer.ICSVBuilder" />
    public class CSVStates : ICSVBuilder
    {
        /// <summary>
        /// Operations the on CSVF ile.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyzerException">
        /// Wrong_File_Extension
        /// or
        /// File_Name_Incorrect
        /// or
        /// Wrong_Delimiter
        /// or
        /// NO_HEADER
        /// </exception>
        public int OperationOnCSVFIle(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {

            try
            {
                if (Path.GetExtension(path) != ".csv")
                    throw new CensusAnalyzerException("Wrong_File_Extension");
                else if (!File.Exists(path))
                    throw new CensusAnalyzerException("File_Name_Incorrect");

            }
            catch (CensusAnalyzerException)
            {

                throw;
            }
            int count = 0;
            var csvData = File.ReadAllLines(path);
            foreach (string line in csvData)
            {
                string[] csvLine = line.Split(delimiter);
                if (csvLine.Length != 4 && csvLine.Length != 5)
                {
                    throw new CensusAnalyzerException("Wrong_Delimiter");
                }
            }
            if (!csvData[0].Equals(header))
            {
                throw new CensusAnalyzerException("NO_HEADER");
            }
            IEnumerable<string> IterateCsvFile = csvData;
            foreach (string line in IterateCsvFile)
            {
                count++;
            }
            return count;
        }
    }
}
