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
            int num = 1;
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyzerException("Wrong_File_Extension");
            else if (!File.Exists(path))
                throw new CensusAnalyzerException("File_Name_Incorrect");
            var csvData = File.ReadAllLines(path);
            foreach (string line in csvData)
            {
                string[] csvLine = line.Split(delimiter);
                if (csvLine.Length != 4 && csvLine.Length != 2)
                {
                    throw new CensusAnalyzerException("Wrong_Delimiter");
                }
            }
            if (!csvData[0].Equals(header))
            {
                throw new CensusAnalyzerException("NO_HEADER");
            }
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = csvData[0].Split(',');
            for (int i = 1; i < csvData.Length; i++)
            {
                Dictionary<string, string> mapValue = new Dictionary<string, string>();
                var val = csvData[i].Split(',');
                mapValue.Add(key[0], val[0]);
                mapValue.Add(key[1], val[1]);
                mapValue.Add(key[2], val[2]);
                mapValue.Add(key[3], val[3]);
                map.Add(num, mapValue);
                num++;
            }
            return map.Count;
        }
        public void CSVStateCodeJsonDataLoad(string source, string destination, int key)
        {
            StateCensusAnalyser obj = new StateCensusAnalyser();
            obj.SortingForCSVFile(source, key);
            string csvData = File.ReadAllText(source);
            StringBuilder stringBuilder = new StringBuilder();
            using (var jsonDataValue = ChoCSVReader.LoadText(csvData).WithFirstLineHeader())
            {
                using (var data = new ChoJSONWriter(stringBuilder)) data.Write(jsonDataValue);
            }
            File.WriteAllText(destination, stringBuilder.ToString());
        }
    }
}
