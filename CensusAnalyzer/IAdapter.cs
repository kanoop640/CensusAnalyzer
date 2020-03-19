using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    interface IAdapter
    {
        public int Operation_On_US_CSV_FIle(string path, char delimiter, string header);
        public void CSV_To_Json_Data_Load(string csvSource, string jsonDestination);
        public int Sorting_For_CSVFile_For_String_Key(string Jsource, string Jdestination, string key);
        public int Sorting_For_CSVFile_For_Numeric_Key(string Jsource, string Jdestination, string key);
    }
}
