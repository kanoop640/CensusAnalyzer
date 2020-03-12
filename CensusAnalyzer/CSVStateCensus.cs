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
        public int OperationOnCSVFIle(string path, char delimiter, string header)
        {
            List<string> lists = new List<string>();
            if (Path.GetExtension(path) != ".csv")
            {
                throw new CensusAnalyzerException("Wrong_File_Extension");
            }
            else if (!File.Exists(path))
            {
                throw new CensusAnalyzerException("File_Name_Incorrect");
            }
            string[] str = File.ReadAllLines(path);
            foreach (string line in str)
            {
                lists.Add(line);
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

            return lists.Count;
        }
    }
}
