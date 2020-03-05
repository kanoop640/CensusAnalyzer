using NUnit.Framework;
using CensusAnalyzer;
namespace CensusAnalyzerNUnitTest
{
    public class Tests
    {
        StateCensusAnalyzer stateData = new StateCensusAnalyzer();
        CSVStateCensus csvdata = new CSVStateCensus();
        string path = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";

        /// <summary>
        /// Checks the item in CSV file.
        /// TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInCSVFileFromTwoClass()
        {
            Assert.AreEqual(30, stateData.LoadStateData(path));
        }
        /// <summary>
        /// Wrongs the name of the file.
        /// TestCase-1.2
        /// </summary>
        [Test]
        public void WrongFileName()
        {
            var NoFile = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusDat.csv"));
            Assert.AreEqual("File_Name_Incorrect", NoFile.GetMessage);
        }
        [Test]
        public void WrongFileExtension()
        {
            var NoExtension = Assert.Throws<CensusAnalyzerException>(() => stateData.LoadStateData(@"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData,csv"));
            Assert.AreEqual("Wrong_File_Extension", NoExtension.GetMessage);
        }
    }
}