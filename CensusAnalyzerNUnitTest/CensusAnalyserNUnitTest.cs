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
        /// The CSV builder Class Object
        /// </summary>
        CSVBuilder csvBuilder = new CSVBuilder();

        /// <summary>
        /// The CSV code delgate Object
        /// </summary>
        CSVBulderDelgate csvCodeDelgate = new CSVBulderDelgate(new CSVBuilder().GetCSVBuilder);
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
        /// The json state census path
        /// </summary>
        string jsonStateCensusPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\StateCensusData.json";
        /// <summary>
        /// The state codejson path
        /// </summary>
        string stateCodejsonPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\StateCode.json";
        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase1 TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInStateCensusAnalyzerClass()
        {
            Assert.AreEqual(csvStateCensus.CSVFileData(csvStateCensusData), csvBuilder.GetCSVBuilder(Factory.StateCensusObject(), csvStateCensusData, ',', "State,Population,AreaInSqKm,DensityPerSqKm"));
        }
        /// <summary>
        /// Wrongs the file name in CSVstatecensus Class and StateCensus.csv file.
        /// UseCase1 TestCase 1.2
        /// </summary>
        [Test]
        public void WrongFileNameInCSVStateCensus()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => csvBuilder.GetCSVBuilder(Factory.StateCensusObject(), @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusata.csv"));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension in CSVStateCensus  class.
        /// UseCase 1 TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtensionInCSVStateCensus()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => csvBuilder.GetCSVBuilder(Factory.StateCensusObject(), @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csvuu"));
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
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => csvBuilder.GetCSVBuilder(Factory.StateCensusObject(), csvStateCensusData, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        ///UseCase1 TestCase - 1.5
        /// </summary>
        [Test]
        public void NoHeaderInCSVStateCensus()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => csvBuilder.GetCSVBuilder(Factory.StateCensusObject(), csvStateCensusData, ',', "AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
        /// <summary>
        /// Checks the item in CSV file.
        /// UseCase2 TestCase-2.1
        /// </summary>
        [Test]
        public void CheckItemInCSVStaeFromStateCodeFile()
        {
            Assert.AreEqual(csvStateCensus.CSVFileData(csvStateCodeFile), csvCodeDelgate(Factory.CSVStateCode(), csvStateCodeFile, ',', "SrNo,State Name,TIN,StateCode"));
        }
        /// <summary>
        /// Wrongs the name of the file.
        /// UseCase2 TestCase-2.2
        /// </summary>
        [Test]
        public void WrongFileNameInCSVStatesClass()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => csvCodeDelgate(Factory.CSVStateCode(), csvStateCodeWrongFileName));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension.
        /// UseCase2 TestCase-2.3
        /// </summary>
        [Test]
        public void WrongFileExtensionInCSVStatesClass()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => csvCodeDelgate(Factory.CSVStateCode(), cscStateCodeWrongFileExtension));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
        /// <summary>
        /// When we read data form StateCensusData.csv and find that it's delemeter is not correct than
        /// throw exception from StateCensusAnalyzer
        /// UseCase2 TestCase-2.4 
        /// </summary>
        [Test]
        public void DelimiterErrorInCSVStatesClassAndStateCodeFile()
        {
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => csvCodeDelgate(Factory.CSVStateCode(), csvStateCodeFile, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        /// UseCase2 TestCase - 2.5
        /// </summary>
        [Test]
        public void NoHeaderInCSVStatesClassAndStateCodeFile()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => csvCodeDelgate(Factory.CSVStateCode(), csvStateCodeFile, ',', "AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
        /// <summary>
        /// Check  first value check from state census data form StateCensus.json
        /// UseCase 3 TestCase 3.1
        /// </summary>
        [Test]
        public void JsonFirstValueCheckFromStateCensusData()
        {
            Assert.AreEqual("Andhra Pradesh", csvStateCensus.RetriveJsonFileFirstElementOnKey(jsonStateCensusPath, "State"));
        }
        /// <summary>
        /// Check  last value check from state census data form StateCensus.json
        /// UseCase 3 TestCase 3.2
        /// </summary>
        [Test]
        public void JsonLastValueCheckFromStateCensusData()
        {
            Assert.AreEqual("West Bengal", csvStateCensus.RetriveLastElementOnKey(jsonStateCensusPath, "State"));
        }
        /// <summary>
        /// Jsons the first value check from json state code.
        /// UseCase 4 TestCase 4.1
        /// </summary>
        [Test]
        public void JsonFirstValueCheckFromStateCode()
        {
            Assert.AreEqual("AN", csvStateCensus.RetriveJsonFileFirstElementOnKey(stateCodejsonPath, "StateCode"));
        }
        /// <summary>
        /// Jsons the last value check from json state code.
        /// UseCase 4 TestCase 4.2
        /// </summary>
        [Test]
        public void JsonLastValueCheckFromStateCode()
        {
            Assert.AreEqual("WB", csvStateCensus.RetriveLastElementOnKey(stateCodejsonPath, "StateCode"));
        }
    }
}