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
            string sortJsonCensusByState = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByState.json";
            string sortJsonCensusByPopulation = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByPopulation.json";
            string sortJsonCensusByPopulationDensity = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByArea.json";
            string sortJsonCensusByArea = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByArea.json";
            string sortJsonCode = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCode.json";
            string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string csvStateCodeJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.json";
            Console.WriteLine("Welcome to CensusAnalyzer");
            CSVStates csvStateCodeObject = new CSVStates();
            csvStateCodeObject.CSVStateCodeJsonDataLoad(csvStateCodePath, csvStateCodeJsonPath, sortJsonCode, "State Name");
            csvStateCodeObject.CSVStateCodeJsonDataLoadForNum(csvStateCensusPath, csvStateCensusJsonPath, sortJsonCensusByArea, "AreaInSqKm");
        }
    }
}
