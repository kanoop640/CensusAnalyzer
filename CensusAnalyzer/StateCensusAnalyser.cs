// <copyright file="StateCensusAnalyser.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
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
        public void SortingForCSVFile(string path, int key)
        {
            string[] lines = File.ReadAllLines(path);
            var data = lines.Skip(1);
            var sorted = data.Select(line => new { SortKey = line.Split(',')[key], Line = line }).OrderBy(x => x.SortKey).Select(x => x.Line);
            File.WriteAllLines(path, lines.Take(1).Concat(sorted));
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
