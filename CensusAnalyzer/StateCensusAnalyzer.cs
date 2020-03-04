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
        public int LoadStateData(string path)
        {
            try
            {
                var data = File.ReadAllLines(path);
                return data.Length;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyzerException("File_Name_Incorrect");
            }
        }
    }
}
