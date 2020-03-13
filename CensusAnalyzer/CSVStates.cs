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
    using ChoETL;

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
        public int OperationOnCSVFIle(string path, char delimiter, string header)
        {
            List<string> lists = new List<string>();
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyzerException("Wrong_File_Extension");
            else if (!File.Exists(path))
                throw new CensusAnalyzerException("File_Name_Incorrect");
            var csvData = File.ReadAllLines(path);
            foreach (string line in csvData)
            {
                lists.Add(line);
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

            return lists.Count;
        }
        public void CSVStateCodeJsonDataLoad()
        {
            string path = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string csvData = File.ReadAllText(path);
            StringBuilder stringBuilder = new StringBuilder();
            using (var jsonDataValue = ChoCSVReader.LoadText(csvData).WithFirstLineHeader())
            {
                using (var data = new ChoJSONWriter(stringBuilder)) data.Write(jsonDataValue);
            }
            File.WriteAllText(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\StateCode.json", stringBuilder.ToString());
        }
    }
}
