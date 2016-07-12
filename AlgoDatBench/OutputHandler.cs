// ----------------------------------------------------------------------- 
// <copyright file="OutputHandler.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class for output.
    /// </summary>
    public class OutputHandler
    {
        /// <summary>
        /// Method prints to the console.
        /// </summary>
        /// <param name="source">Object source.</param>
        /// <param name="outputEventArgs">Contains name and color.</param>
        public void OnOutput(object source, OutputEventArgs outputEventArgs)
        {
            Console.ForegroundColor = outputEventArgs.Color;
            Console.WriteLine(outputEventArgs.Message);
            Console.ResetColor();
        }
    }
}