// <copyright file="StateCensusAnalyser.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
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
            return csvfiledata.Length;
        }
        public void SortingForCSVFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var data = lines.Skip(1);
            var sorted = data.Select(line => new { SortKey = line.Split(',')[0], Line = line }).OrderBy(x => x.SortKey).Select(x => x.Line);
            File.WriteAllLines(path, lines.Take(1).Concat(sorted));
        }
    }
}
