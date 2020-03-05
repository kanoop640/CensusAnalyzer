// <copyright file="CensusAnalyzerException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Anoop kumar"/>
// -----------------------------------------------------------------
namespace CensusAnalyzer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CensusAnalyzerException : Exception
    {
        string message;
        public CensusAnalyzerException(string msg)
        {
            this.message = msg;
        }
        /// <summary>
        /// Gets the get message.
        /// </summary>
        /// <value>
        /// The get message.
        /// </value>
        public string GetMessage { get => message; }
    }
}
