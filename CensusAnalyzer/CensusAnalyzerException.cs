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
    /// <summary>
    /// Custome Exception class which inherit the exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CensusAnalyzerException : Exception
    {
        private readonly string message;
        ///----------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyzerException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// -----------------------------------------------------------------
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
        public string GetMessage { get => this.message; }
    }
}
