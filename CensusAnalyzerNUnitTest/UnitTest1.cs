using NUnit.Framework;
using CensusAnalyzer;
namespace CensusAnalyzerNUnitTest
{
    public class Tests
    {
        StateCensusAnalyzer stateData = new StateCensusAnalyzer();
        CSVStates csvdata = new CSVStates();
        string csvFilePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";
        string csvFileCopyPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData -Copy.csv";
        string csvWrongFileName = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusDat.csv";
        string cscWrongFileExtension = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csvee";

        /// <summary>
        /// Checks the item in CSV file.
        /// TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInCSVFileFromTwoClass()
        {
            Assert.AreEqual(csvdata.LoadCSVStateData(csvFilePath), stateData.LoadStateData(csvFilePath));
        }
        /// <summary>
        /// Wrongs the name of the file.
        /// TestCase-1.2
        /// </summary>
        [Test]
        public void WrongFileName()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => csvdata.LoadCSVStateData(csvWrongFileName));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        /// <summary>
        /// Wrong the file extension.
        /// TestCase-1.3
        /// </summary>
        [Test]
        public void WrongFileExtension()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(cscWrongFileExtension));
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
            var WrongDelemeter = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(csvFilePath, '.'));
            Assert.AreEqual("Wrong_Delimiter", WrongDelemeter.GetMessage);
        }
        /// <summary>
        /// When StateCensusData.csv file have no header
        /// TestCase - 1.5
        /// </summary>
        [Test]
        public void NoHeader()
        {
            var NoHead = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(csvFileCopyPath));
            Assert.AreEqual("NO_HEADER", NoHead.GetMessage);
        }
    }
}