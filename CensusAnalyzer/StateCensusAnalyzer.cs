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
    public class StateCensusAnalyzer
    {
        public int LoadStateData()
        {
            var data = File.ReadAllLines(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv");
            return data.Length;
        }
    }
}
