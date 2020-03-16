// <copyright file="StateCensusAnalyser.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyzer
{
    public class StateCensusAnalyser
    {
        public int CSVFileData(string path)
        {
            var csvfiledata = File.ReadAllLines(path);
            return csvfiledata.Length - 1;
        }
        public int SortingForCSVFile(string Jsource, string Jdestination, string key)
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
        public int SortingForCSVFileForNum(string Jsource, string Jdestination, string key)
        {
            int count = 0;
            var so = File.ReadAllText(Jsource);
            JArray va = JArray.Parse(so);
            for (int i = 0; i < va.Count - 1; i++)
            {
                for (int j = i + 1; j < va.Count; j++)
                {
                    if ((int)va[i][key] < (int)va[j][key])
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
        public string RetriveJsonFileFirstElementOnKey(string path, string key)
        {
            var jobj = File.ReadAllText(path);
            var fileData = JArray.Parse(jobj);
            return fileData[0][key].ToString();

        }
        public string RetriveLastElementOnKey(string path, string key)
        {
            var jobj = File.ReadAllText(path);
            var fileData = JArray.Parse(jobj);
            return fileData[fileData.Count - 1][key].ToString();
        }
    }
}
