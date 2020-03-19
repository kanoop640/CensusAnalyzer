using System;
using System.IO;
using Newtonsoft.Json;

namespace CensusAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string IndianJsonFilePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\IndianSateCensusData.json";
            string IndianJsonFileSortByPopulation = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortedIndianSateCensusDataByPapulation.json";
            string csvStateCensusPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";
            string csvStateCensusJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.json";
            string sortJsonCensusByState = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByState.json";
            string sortJsonCensusByPopulation = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByPopulation.json";
            string sortJsonCensusByPopulationDensity = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByArea.json";
            string sortJsonCensusByArea = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCensusDataByArea.json";
            string sortJsonCode = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\sortStateCode.json";
            string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
            string csvStateCodeJsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.json";
            string usDataPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\USCensusData.csv";
            string jUsData = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\USCensusData.csv";
            string usCSVFilePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\USCensusData.csv";
            string usCSVFileHeader = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
            Console.WriteLine("Welcome to CensusAnalyzer");
            Console.WriteLine("Ability to handle US State Census Data");
            CSVStates csvStateCodeObject = new CSVStates();
            USCSVFile usCSVFileObj = new USCSVFile();
            csvStateCodeObject.CSVToJsonDataLoad(csvStateCodePath, csvStateCodeJsonPath, sortJsonCode, "State Name");
            csvStateCodeObject.CSVToJsonDataLoadForNum(csvStateCensusPath, csvStateCensusJsonPath, sortJsonCensusByArea, "AreaInSqKm");
            usCSVFileObj.Operation_On_US_CSV_FIle(usCSVFilePath, ',', usCSVFileHeader);
        }
    }
}
