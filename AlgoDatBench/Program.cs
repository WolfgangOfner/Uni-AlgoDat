// ----------------------------------------------------------------------- 
// <copyright file="Program.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Command line.</param>
        public static void Main(string[] args)
        {
            Console.WindowWidth = 140;
                        
            AlgoDatBench algoDatBench = new AlgoDatBench();
            OutputHandler outputHandler = new OutputHandler();
            InputHandler inputHandler = new InputHandler();

            algoDatBench.OutputEvent += outputHandler.OnOutput;
            algoDatBench.InputEvent += inputHandler.OnInput;

            algoDatBench.Start();

            Environment.Exit(0);
        }
    }
}