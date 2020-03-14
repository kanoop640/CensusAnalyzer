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
            string csvStateCensusJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\StateCensusData.json";
            string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string csvStateCodeJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\StateCode.json";
            Console.WriteLine("Welcome to CensusAnalyzer");
            CSVStates csvStateCodeObject = new CSVStates();
            csvStateCodeObject.CSVStateCodeJsonDataLoad(csvStateCodePath, csvStateCodeJsonPath);
            csvStateCodeObject.CSVStateCodeJsonDataLoad(csvStateCensusPath, csvStateCensusJsonPath);
        }
    }
}
