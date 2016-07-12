// ----------------------------------------------------------------------- 
// <copyright file="OutputEventArgs.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class for the output.
    /// </summary>
    public class OutputEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputEventArgs"/> class.
        /// </summary>
        /// <param name="message">Message for output.</param>
        /// <param name="color">Console color.</param>
        public OutputEventArgs(string message, ConsoleColor color)
        {
            this.Message = message;
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the value of the color.
        /// </summary>
        /// <value>Console color.</value>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Gets or sets the output message.
        /// </summary>
        /// <value>Output message.</value>
        public string Message { get; set; }
    }
}
