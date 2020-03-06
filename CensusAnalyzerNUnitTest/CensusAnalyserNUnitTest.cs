// <copyright file="Tests.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
namespace CensusAnalyzerNUnitTest
{
    using NUnit.Framework;
    using CensusAnalyzer;
    public class CensusAnalyserNUnitTest
    {
        CSVStateDelegate csvDelegate = new CSVStateDelegate(CSVStates.LoadCSVStateData);
        CSVStateCensus stateData = new CSVStateCensus();
        StateCensusAnalyser csvStateCensus = new StateCensusAnalyser();
        string csvStateCodeFile = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
        string csvStateCodeWrongFileName = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCod.csv";
        string cscStateCodeWrongFileExtension = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csvee";
        string csvStateCensusData = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";


        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase1 TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInStateCensusAnalyzerClass()
        {
            Assert.AreEqual(csvStateCensus.StateCensusAnalyserData(), stateData.LoadStateData(csvStateCensusData));
        }
        /// <summary>
        /// Wrongs the file name in CSVstatecensus Class and StateCensus.csv file.
        /// UseCase1 TestCase 1.2
        /// </summary>
        [Test]
        public void WrongFileNameInCSVStateCensus()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusata.csv"));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension in CSVStateCensus  class.
        /// UseCase 1 TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtensionInCSVStateCensus()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csvuu"));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase2 TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInCSVFileFromTwoClass()
        {
            Assert.AreEqual(38, csvDelegate(csvStateCodeFile));
        }
        /// <summary>
        /// Wrongs the name of the file.
        /// TestCase-1.2
        /// </summary>
        [Test]
        public void WrongFileName()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => csvDelegate(csvStateCodeWrongFileName));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension.
        /// TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtension()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => csvDelegate(cscStateCodeWrongFileExtension));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
        /// <summary>
        /// When we read data form StateCensusData.csv and find that it's delemeter is not correct than
        /// throw exception from StateCensusAnalyzer
        /// TestCase-1.4 
        /// </summary>
        [Test]
        public void DelimiterError()
        {
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => csvDelegate(csvStateCodeFile, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        /// TestCase - 1.5
        /// </summary>
        [Test]
        public void NoHeader()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => csvDelegate(csvStateCodeFile, ',', "AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
    }
}