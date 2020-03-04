using NUnit.Framework;
using CensusAnalyzer;
namespace CensusAnalyzerNUnitTest
{
    public class Tests
    {
        StateCensusAnalyzer stateData = new StateCensusAnalyzer();
        CSVStateCensus csvdata = new CSVStateCensus();

        /// <summary>
        /// Checks the item in CSV file.
        /// TestCase-1.1
        /// </summary>
        [Test]
        public void CheckItemInCSVFileFromTwoClass()
        {
            Assert.AreEqual(csvdata.LoadCSVStateData(), stateData.LoadStateData());
        }
    }
}