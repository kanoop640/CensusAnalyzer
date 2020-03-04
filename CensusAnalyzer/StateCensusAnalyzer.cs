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
                int count = 0;
                string[] str = File.ReadAllLines(path);
                IEnumerable<string> ele = str;
                foreach (string line in ele)
                {
                    count++;
                }
                return count;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyzerException("File_Name_Incorrect");
            }

        }
    }
}
