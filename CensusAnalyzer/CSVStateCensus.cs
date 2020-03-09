// <copyright file="StateCensusAnalyzer.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
namespace CensusAnalyzer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    public class CSVStateCensus : ICSVBuilder
    {
        public int OperationOnCSVFIle(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                if (Path.GetExtension(path) != ".csv")
                {
                    throw new CensusAnalyzerException("Wrong_File_Extension");
                }
                else if (!File.Exists(path))
                {
                    throw new CensusAnalyzerException("File_Name_Incorrect");
                }
                int count = 0;
                string[] str = File.ReadAllLines(path);
                foreach (string line in str)
                {
                    string[] csvLine = line.Split(delimiter);
                    if (csvLine.Length != 4 && csvLine.Length != 2)
                    {
                        throw new CensusAnalyzerException("Wrong_Delimiter");
                    }
                }
                if (str[0] != header)
                {
                    throw new CensusAnalyzerException("NO_HEADER");
                }
                IEnumerable<string> ele = str;
                foreach (string line in ele)
                {
                    count++;
                }
                return count;
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
    }
}
