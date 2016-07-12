// ----------------------------------------------------------------------- 
// <copyright file="InputHandler.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class subscribed to input event.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        /// Method raised on user input.
        /// </summary>
        /// <param name="source">Object sender.</param>
        /// <param name="inputEventArgs">EventArgs will contain user input.</param>
        public void OnInput(object source, InputEventArgs inputEventArgs)
        {
            inputEventArgs.Input = Console.ReadLine();
        }
    }
}