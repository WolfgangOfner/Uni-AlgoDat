// ----------------------------------------------------------------------- 
// <copyright file="InputEventArgs.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    /// <summary>
    /// Class to pass user input to the program.
    /// </summary>
    public class InputEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputEventArgs"/> class.
        /// </summary>
        public InputEventArgs()
        {
            this.Input = string.Empty;
        }

        /// <summary>
        /// Gets or sets the value of the user input.
        /// </summary>
        /// <value>User input.</value>
        public string Input { get; set; }
    }
}