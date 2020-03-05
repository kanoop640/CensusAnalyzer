﻿// <copyright file="CSVStateCensus.cs" company="Bridgelabz">
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
        public int LoadCSVStateData(string path, char delimiter = ',')
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
                if (csvLine.Length != 4 && csvLine.Length != 2)
                {
                    throw new CensusAnalyzerException("Wrong_Delimiter");
                }
            }
            if (csvData[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
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
