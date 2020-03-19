using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    public class IndianData : IIndianCSVData

    {
        string csvStateCensusPath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCensusData.csv";
        string csvStateCodePath = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\StateCode.csv";
        string jIndiaCensusData = @"D:\Anoop_kumar\CensusAnalyzer\CensusAnalyzer\File\IndianSateCensusData.json";
        public List<Dictionary<string, object>> IndianCensusData()
        {
            List<Dictionary<string, object>> val = new List<Dictionary<string, object>>();
            var csvdata = File.ReadAllLines(csvStateCensusPath);
            var csvCode = File.ReadAllLines(csvStateCodePath);
            var dataHeader = csvdata[0].Split(',');
            var codeHeader = csvCode[0].Split(',');
            for (int i = 1; i < csvCode.Length; i++)
            {
                Dictionary<string, object> lo = new Dictionary<string, object>();
                var codedata = csvCode[i].Split(',');
                for (int j = 1; j < csvdata.Length; j++)
                {
                    var data = csvdata[j].Split(',');
                    if (codedata[1].ToString().Equals(data[0].ToString()))
                    {
                        for (int k = 0; k < codedata.Length; k++)
                        {
                            lo.Add(codeHeader[k], codedata[k]);
                            if (k > 0)
                            {
                                lo.Add(dataHeader[k], data[k]);
                            }
                        }
                        break;
                    }
                }
                for (int m = 0; m < codedata.Length; m++)
                {
                    if (m > 0)
                    {
                        lo.Add(dataHeader[m], "0");
                    }
                    try
                    {
                        lo.Add(codeHeader[m], codedata[m]);
                    }
                    catch (Exception)
                    {

                        break;
                    }
                }
                val.Add(lo);
            }
            var json = JsonConvert.SerializeObject(val);
            File.WriteAllText(jIndiaCensusData, json);
            return val;
        }
    }
}
