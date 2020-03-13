using System;
using System.IO;
using Newtonsoft.Json;

namespace CensusAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CensusAnalyzer");
            CSVStateCensus csvStateCensusObject = new CSVStateCensus();
            csvStateCensusObject.CSVStateCensusJsonDataLoad();
        }
    }
}
