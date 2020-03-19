using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    class USCSVFile : IAdapter, IIndianCSVData, ICSVBuilder
    {
        IIndianCSVData data;
        ICSVBuilder build;
        public USCSVFile(IIndianCSVData data)
        {
            this.data = data;
        }
        public USCSVFile(ICSVBuilder builder)
        {
            this.build = builder;
        }
        public USCSVFile()
        {
        }


        public int Operation_On_US_CSV_FIle(string path, char delimiter, string header)
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
                if (csvLine.Length != 9)
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
        public void CSV_To_Json_Data_Load(string csvSource, string jsonDestination)
        {
            string csvData = File.ReadAllText(csvSource);
            StringBuilder stringBuilder = new StringBuilder();
            using (var jsonDataValue = ChoCSVReader.LoadText(csvData).WithFirstLineHeader())
            {
                using (var data = new ChoJSONWriter(stringBuilder)) data.Write(jsonDataValue);
            }
            File.WriteAllText(jsonDestination, stringBuilder.ToString());
        }

        public int Sorting_For_CSVFile_For_String_Key(string Jsource, string Jdestination, string key)
        {
            int count = 0;
            var so = File.ReadAllText(Jsource);
            JArray va = JArray.Parse(so);
            for (int i = 0; i < va.Count - 1; i++)
            {
                for (int j = i + 1; j < va.Count; j++)
                {
                    if (va[i][key].ToString().CompareTo(va[j][key].ToString()) > 0)
                    {
                        var temp = va[i];
                        va[i] = va[j];
                        va[j] = temp;
                        count++;
                    }
                }
            }
            File.WriteAllText(Jdestination, JsonConvert.SerializeObject(va, Formatting.Indented));
            return count;
        }
        public int Sorting_For_CSVFile_For_Numeric_Key(string Jsource, string Jdestination, string key)
        {
            int count = 0;
            var so = File.ReadAllText(Jsource);
            JArray va = JArray.Parse(so);
            for (int i = 0; i < va.Count; i++)
            {
                for (int j = 0; j < va.Count; j++)
                {
                    if ((int)va[i][key] > (int)va[j][key])
                    {
                        var temp = va[i];
                        va[i] = va[j];
                        va[j] = temp;
                        count++;
                    }
                }
            }
            File.WriteAllText(Jdestination, JsonConvert.SerializeObject(va, Formatting.Indented));
            return count;
        }

        public List<Dictionary<string, object>> IndianCensusData()
        {
            return data.IndianCensusData();
        }

        public int OperationOnCSVFIle(string path, char delemitier, string header)
        {
            return this.build.OperationOnCSVFIle(path, delemitier, header);
        }

        public void IndianCsvFile()
        {
            build.IndianCsvFile();
        }
    }
}
