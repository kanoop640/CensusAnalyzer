// <copyright file="Tests.cs" company="Bridgelabz">
//   Copyright � 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
namespace CensusAnalyzerNUnitTest
{
    using NUnit.Framework;
    using CensusAnalyzer;

    public class CensusAnalyserNUnitTest
    {
        /// <summary>
        /// The CSVState delegate
        /// </summary>
        CSVStateDelegate csvStateDelegate = Factory.CSVStatesObject();
        /// <summary>
        /// stateData is object of CSVStateCensus class
        /// </summary>
        CSVStateCensus stateData = Factory.StateCensusObject();
        /// <summary>
        /// The csvStateCensus is the object of StateCensusAnalyser class
        /// which return the number of records in StateCensusData.csv file
        /// </summary>
        StateCensusAnalyser csvStateCensus = new StateCensusAnalyser();
        /// <summary>
        /// csvStateCodeFile is the path of StateCode.csv file
        /// </summary>
        string csvStateCodeFile = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
        /// <summary>
        /// csvStateCodeWrongFileName is the path of StateCode.csv file but file name is incorrect
        /// </summary>
        string csvStateCodeWrongFileName = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCod.csv";
        /// <summary>
        ///  csvStateCodeWrongFileName is the path of StateCode.csv file but file extension  is incorrect
        /// </summary>
        string cscStateCodeWrongFileExtension = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csvee";
        /// <summary>
        /// csvStateCensusData is the path of StateCensusData.csv file path
        /// </summary>
        string csvStateCensusData = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";


        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase1 TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInStateCensusAnalyzerClass()
        {
            Assert.AreEqual(csvStateCensus.CSVFileData(csvStateCensusData), stateData.OperationOnCSVFIle(csvStateCensusData));
        }
        /// <summary>
        /// Wrongs the file name in CSVstatecensus Class and StateCensus.csv file.
        /// UseCase1 TestCase 1.2
        /// </summary>
        [Test]
        public void WrongFileNameInCSVStateCensus()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => stateData.OperationOnCSVFIle(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusata.csv"));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension in CSVStateCensus  class.
        /// UseCase 1 TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtensionInCSVStateCensus()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => stateData.OperationOnCSVFIle(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csvuu"));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
        /// <summary>
        /// When we read data form StateCensusData.csv and find that it's delemeter is not correct than
        /// throw exception from StateCensusAnalyzer
        /// UseCase1 TestCase-1.4 
        /// </summary>
        [Test]
        public void DelimiterErrorInCSVStateCensus()
        {
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => stateData.OperationOnCSVFIle(csvStateCensusData, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        ///UseCase1 TestCase - 1.5
        /// </summary>
        [Test]
        public void NoHeaderInCSVStateCensus()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => stateData.OperationOnCSVFIle(csvStateCensusData, ',', "AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase2 TestCase-2.1
        /// </summary>
        [Test]
        public void CheckItemInCSVStaeFromStateCodeFile()
        {
            Assert.AreEqual(csvStateCensus.CSVFileData(csvStateCodeFile), csvStateDelegate(csvStateCodeFile));
        }
        /// <summary>
        /// Wrongs the name of the file.
        /// UseCase2 TestCase-1.2
        /// </summary>
        [Test]
        public void WrongFileNameInCSVStatesClass()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => csvStateDelegate(csvStateCodeWrongFileName));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension.
        /// UseCase2 TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtensionInCSVStatesClass()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => csvStateDelegate(cscStateCodeWrongFileExtension));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
        /// <summary>
        /// When we read data form StateCensusData.csv and find that it's delemeter is not correct than
        /// throw exception from StateCensusAnalyzer
        /// UseCase2 TestCase-1.4 
        /// </summary>
        [Test]
        public void DelimiterErrorInCSVStatesClassAndStateCodeFile()
        {
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => csvStateDelegate(csvStateCodeFile, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        /// UseCase2 TestCase - 1.5
        /// </summary>
        [Test]
        public void NoHeaderInCSVStatesClassAndStateCodeFile()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => csvStateDelegate(csvStateCodeFile, ',', "AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
    }
}