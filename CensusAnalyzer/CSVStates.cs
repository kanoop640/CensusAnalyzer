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
        StateCensusAnalyser obj = new StateCensusAnalyser();
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
        public void CSVToJson_Data_Load_And_Sort_String_key(string csvSource, string jsonDestination, string sortJson, string key)
        {
            string csvData = File.ReadAllText(csvSource);
            StringBuilder stringBuilder = new StringBuilder();
            using (var jsonDataValue = ChoCSVReader.LoadText(csvData).WithFirstLineHeader())
            {
                using (var data = new ChoJSONWriter(stringBuilder)) data.Write(jsonDataValue);
            }
            File.WriteAllText(jsonDestination, stringBuilder.ToString());
            obj.SortingForCSVFile(jsonDestination, sortJson, key);
        }
        public void CSVToJson_Data_Load_And_Sort_By_Numeric_key(string csvSource, string jsonDestination, string sortJson, string key)
        {
            string csvData = File.ReadAllText(csvSource);
            StringBuilder stringBuilder = new StringBuilder();
            using (var jsonDataValue = ChoCSVReader.LoadText(csvData).WithFirstLineHeader())
            {
                using (var data = new ChoJSONWriter(stringBuilder)) data.Write(jsonDataValue);
            }
            File.WriteAllText(jsonDestination, stringBuilder.ToString());
            obj.SortingForCSVFileForNum(jsonDestination, sortJson, key);
        }
        int count = 0;
        List<string> la = new List<string>();
        /// <summary>
        /// Tests this instance.
        /// It calls the merge function.
        /// </summary>
        public void IndianCsvFile()
        {
            string csvStateCensusPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";
            string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string IndianCSVFile = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\IndianCensusData.csv";
            string indianCSVDataFileHeader = "SrNo,State Name,TIN,StateCode,Population,AreaInSqKm,DensityPerSqKm";
            la.Add(indianCSVDataFileHeader);
            string[] codeData = File.ReadAllLines(csvStateCodePath);
            string[] censusData = File.ReadAllLines(csvStateCensusPath);
            for (int i = 1; i < codeData.Length; i++)
            {
                count = 0;
                string[] lines_code = codeData[i].Split(',');

                for (int j = 1; j < censusData.Length; j++)
                {
                    string[] lines_census = censusData[j].Split(',');

                    merge(codeData[i], censusData[j], lines_code, lines_census);
                }

                if (count == 0)
                {
                    // It adds new State that is not common
                    // in both csv file;
                    string sa = String.Concat(codeData[i] + ",0,0,0,0");
                    la.Add(sa);

                }
            }
            File.WriteAllLines(IndianCSVFile, la);
        }
        /// <summary>
        /// It will merge the two csv file
        /// with state name
        /// Merges the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="census">The census.</param>
        /// <param name="lines_code">The lines code.</param>
        /// <param name="lines_census">The lines census.</param>
        public void merge(string _code, string _census, string[] lines_code, string[] lines_census)
        {
            string sf;
            if (lines_code[1] == lines_census[0])
            {
                int a = _census.IndexOf(",");
                sf = _census.Substring(a);
                string s = String.Concat(_code, sf);
                la.Add(s);
                count = 1;
            }

        }
    }
}
