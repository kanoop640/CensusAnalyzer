using System;
using System.IO;
using Newtonsoft.Json;

namespace CensusAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvStateCensusPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";
            string csvStateCensusJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.json";
            string sortJsonCensus = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusData.json";
            string sortJsonCode = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCode.json";
            string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string csvStateCodeJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.json";
            Console.WriteLine("Welcome to CensusAnalyzer");
            CSVStates csvStateCodeObject = new CSVStates();
            csvStateCodeObject.CSVStateCodeJsonDataLoad(csvStateCodePath, csvStateCodeJsonPath, sortJsonCode, "State Name");
            csvStateCodeObject.CSVStateCodeJsonDataLoad(csvStateCensusPath, csvStateCensusJsonPath, sortJsonCensus, "Population");
        }
    }
}
