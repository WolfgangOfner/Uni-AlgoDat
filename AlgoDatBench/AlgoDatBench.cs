// ----------------------------------------------------------------------- 
// <copyright file="AlgoDatBench.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class for the program.
    /// </summary>
    public class AlgoDatBench
    {
        /// <summary>
        /// Contains user input.
        /// </summary>
        private InputEventArgs inputEventArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlgoDatBench"/> class.
        /// </summary>
        public AlgoDatBench()
        {
            this.inputEventArgs = new InputEventArgs();
        }

        /// <summary>
        /// EventHandler for output.
        /// </summary>
        public event EventHandler<OutputEventArgs> OutputEvent;

        /// <summary>
        /// EventHandler for input.
        /// </summary>
        public event EventHandler<InputEventArgs> InputEvent;

        /// <summary>
        /// Method for the main menu.
        /// </summary>
        public void Start()
        {
            bool running = true;
            int myListContainerCounter = 0;
            MyList[] myListContainer = new MyList[10000];
            MyQueue historyQueue = new MyQueue();

            this.OnOutput("Welcome to Wolfgangs AlgoDatBench.", ConsoleColor.Yellow);
            this.OnOutput("----------------------------------", ConsoleColor.Yellow);

            do
            {
                bool nameAlreadyInUse = false;
                bool error = false;
                int[] values = null;
                bool found = false;
                int index = 0;
                string printVariableValues = string.Empty;
                Stopwatch stopwatch = new Stopwatch();
                string history = string.Empty;

                if (this.inputEventArgs.Input == string.Empty)
                {
                    this.OnOutput("\nPlease enter your instruction. For all instructions enter help", ConsoleColor.Yellow);
                    this.OnInput(this.inputEventArgs);
                }

                string[] splitUserInput = this.inputEventArgs.Input.Split(' ');

                switch (splitUserInput[0].ToLower())
                {
                    case "create":
                        stopwatch.Start();

                        nameAlreadyInUse = this.CheckName(splitUserInput[1], ref index, myListContainer, myListContainerCounter);

                        if (nameAlreadyInUse)
                        {
                            this.OnOutput("Error: Name already in used!", ConsoleColor.Red);
                        }
                        else
                        {
                            error = false;

                            if (splitUserInput.Length < 2)
                            {
                                this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                            }
                            else if (splitUserInput.Length == 2)
                            {
                                myListContainer[myListContainerCounter] = new MyList(splitUserInput[1]);
                                myListContainerCounter++;
                            }
                            else if (splitUserInput.Length == 3)
                            {
                                try
                                {
                                    myListContainer[myListContainerCounter] = new MyList(splitUserInput[1], Convert.ToInt32(splitUserInput[2]));
                                    myListContainerCounter++;
                                }
                                catch (Exception)
                                {
                                    this.OnOutput("Error: Value must be an interger!", ConsoleColor.Red);
                                    error = true;
                                }
                            }
                            else if (splitUserInput.Length == 4 && splitUserInput[2].ToLower().Equals("r"))
                            {
                                try
                                {
                                    values = new int[Convert.ToInt32(splitUserInput[3])];
                                }
                                catch (Exception)
                                {
                                    this.OnOutput("Error: Amount must be a positive integer!", ConsoleColor.Red);
                                    error = true;
                                }

                                if (!error)
                                {
                                    Random r = new Random();

                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        values[i] = r.Next(0, values.Length);
                                    }

                                    myListContainer[myListContainerCounter] = new MyList(splitUserInput[1], values);
                                    myListContainerCounter++;
                                }
                            }
                            else
                            {
                                {
                                    values = new int[splitUserInput.Length - 2];

                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        try
                                        {
                                            values[i] = Convert.ToInt32(splitUserInput[i + 2]);
                                        }
                                        catch (Exception)
                                        {
                                            this.OnOutput("Error: Value must be an interger!", ConsoleColor.Red);
                                            error = true;
                                            break;
                                        }
                                    }
                                }

                                if (!error)
                                {
                                    myListContainer[myListContainerCounter] = new MyList(splitUserInput[1], values);
                                    myListContainerCounter++;
                                }
                            }

                            if (!error)
                            {
                                this.OnOutput("\nVariable created!", ConsoleColor.Green);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "delete":
                        stopwatch.Start();

                        found = false;

                        if (splitUserInput.Length != 2)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else
                        {
                            for (int i = 0; i < myListContainerCounter; i++)
                            {
                                if (found)
                                {
                                    myListContainer[i] = myListContainer[i + 1];
                                }
                                else
                                {
                                    if (myListContainer[i].Name.Equals(splitUserInput[1].ToLower()))
                                    {
                                        myListContainer[i] = myListContainer[i + 1];
                                        found = true;
                                    }
                                }
                            }

                            if (found)
                            {
                                myListContainerCounter--;
                                this.OnOutput("Variable deleted!", ConsoleColor.Green);
                            }
                            else
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "exit":
                        running = false;
                        break;

                    case "help":
                        stopwatch.Start();

                        this.ShowAllInstruction();

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "print":
                        stopwatch.Start();

                        if (splitUserInput.Length > 2)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else if (splitUserInput.Length == 1)
                        {
                            if (myListContainerCounter == 0)
                            {
                                this.OnOutput("\nThere are " + myListContainerCounter + " variables declared", ConsoleColor.Red);
                            }
                            else
                            {
                                this.OnOutput("\nThere are " + myListContainerCounter + " variables declared", ConsoleColor.Cyan);
                            }

                            for (int i = 0; i < myListContainerCounter; i++)
                            {
                                printVariableValues = myListContainer[i].PrintAllVariable(myListContainer[i]);

                                if (i % 2 == 0)
                                {
                                    this.OnOutput(myListContainer[i].Name + " --> " + myListContainer[i].Count + " values: " + printVariableValues, ConsoleColor.Yellow);
                                }
                                else
                                {
                                    this.OnOutput(myListContainer[i].Name + " --> " + myListContainer[i].Count + " values: " + printVariableValues, ConsoleColor.Cyan);
                                }
                            }
                        }
                        else
                        {
                            nameAlreadyInUse = this.CheckName(splitUserInput[1], ref index, myListContainer, myListContainerCounter);

                            if (nameAlreadyInUse)
                            {
                                printVariableValues = myListContainer[index].PrintOneVariable(myListContainer[index]);

                                this.OnOutput("\n" + myListContainer[index].Name + " --> " + myListContainer[index].Count + " values: " + printVariableValues, ConsoleColor.Cyan);
                            }
                            else
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "append":
                        stopwatch.Start();

                        if (splitUserInput.Length < 3)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else if (myListContainerCounter == myListContainer.Length)
                        {
                            this.OnOutput("Error: Can't store more variables. You have to delete an existing one before adding a new one!", ConsoleColor.Red);
                        }
                        else
                        {
                            for (int i = 0; i < myListContainerCounter; i++)
                            {
                                nameAlreadyInUse = this.CheckName(splitUserInput[1].ToLower(), ref index, myListContainer, myListContainerCounter);

                                if (nameAlreadyInUse)
                                {
                                    break;
                                }
                            }

                            if (!nameAlreadyInUse)
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                            else
                            {
                                if (splitUserInput.Length == 3)
                                {
                                    try
                                    {
                                        myListContainer[index].Append(Convert.ToInt32(splitUserInput[2]));
                                    }
                                    catch (Exception)
                                    {
                                        this.OnOutput("Error: Value must be an interger!", ConsoleColor.Red);
                                        error = true;
                                    }
                                }
                                else if (splitUserInput.Length == 4 && splitUserInput[2].ToLower().Equals("r"))
                                {
                                    try
                                    {
                                        values = new int[Convert.ToInt32(splitUserInput[3])];
                                    }
                                    catch (Exception)
                                    {
                                        this.OnOutput("Error: Amount must be an interger!", ConsoleColor.Red);
                                        error = true;
                                    }

                                    Random r = new Random();

                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        myListContainer[index].Append(r.Next(0, values.Length));
                                    }
                                }
                                else
                                {
                                    for (int j = 2; j < splitUserInput.Length; j++)
                                    {
                                        try
                                        {
                                            myListContainer[index].Append(Convert.ToInt32(splitUserInput[j]));
                                        }
                                        catch (Exception)
                                        {
                                            this.OnOutput("Error: Value must be an interger!", ConsoleColor.Red);
                                            error = true;
                                            break;
                                        }
                                    }
                                }

                                if (!error)
                                {
                                    this.OnOutput("Value appended!", ConsoleColor.Green);
                                }
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "insertat":
                        stopwatch.Start();

                        if (splitUserInput.Length < 4)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else
                        {
                            for (int i = 0; i < myListContainerCounter; i++)
                            {
                                nameAlreadyInUse = this.CheckName(splitUserInput[1].ToLower(), ref index, myListContainer, myListContainerCounter);

                                if (nameAlreadyInUse)
                                {
                                    break;
                                }
                            }

                            if (!nameAlreadyInUse)
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                            else
                            {
                                if (splitUserInput.Length == 4)
                                {
                                    try
                                    {
                                        myListContainer[index].InsertAt(Convert.ToInt32(splitUserInput[3]), Convert.ToInt32(splitUserInput[2]));
                                    }
                                    catch (Exception ex)
                                    {
                                        this.OnOutput("Error: " + ex.Message, ConsoleColor.Red);
                                        error = true;
                                    }
                                }
                                else if (splitUserInput.Length == 5 && splitUserInput[3].ToLower().Equals("r"))
                                {
                                    try
                                    {
                                        values = new int[Convert.ToInt32(splitUserInput[4])];
                                    }
                                    catch (Exception)
                                    {
                                        this.OnOutput("Error: Amount must be an interger!", ConsoleColor.Red);
                                        error = true;
                                    }

                                    Random r = new Random();

                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        try
                                        {
                                            myListContainer[index].InsertAt(r.Next(0, values.Length), Convert.ToInt32(splitUserInput[2]));
                                        }
                                        catch (Exception ex)
                                        {
                                            this.OnOutput("Error: " + ex.Message, ConsoleColor.Red);
                                            error = true;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int j = 2; j < splitUserInput.Length; j++)
                                    {
                                        try
                                        {
                                            myListContainer[index].InsertAt(Convert.ToInt32(splitUserInput[j]), Convert.ToInt32(splitUserInput[2]));
                                        }
                                        catch (Exception)
                                        {
                                            this.OnOutput("Error: Value must be an interger!", ConsoleColor.Red);
                                            error = true;
                                            break;
                                        }
                                    }
                                }

                                if (!error)
                                {
                                    this.OnOutput("Value inserted!", ConsoleColor.Green);
                                }
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "removeat":
                        stopwatch.Start();

                        if (splitUserInput.Length != 3)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else
                        {
                            nameAlreadyInUse = this.CheckName(splitUserInput[1], ref index, myListContainer, myListContainerCounter);

                            if (!nameAlreadyInUse)
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                                error = true;
                            }
                            else
                            {
                                try
                                {
                                    myListContainer[index].RemoveAt(Convert.ToInt32(splitUserInput[2]));
                                }
                                catch (Exception ex)
                                {
                                    this.OnOutput("Error: " + ex.Message, ConsoleColor.Red);
                                    error = true;
                                }
                            }

                            if (!error)
                            {
                                this.OnOutput("Value removed!", ConsoleColor.Green);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "reverse":
                        stopwatch.Start();

                        if (splitUserInput.Length != 2)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else
                        {
                            nameAlreadyInUse = this.CheckName(splitUserInput[1], ref index, myListContainer, myListContainerCounter);

                            if (nameAlreadyInUse)
                            {
                                myListContainer[index] = myListContainer[index].Reverse(myListContainer[index]);

                                this.OnOutput("Variable reversed", ConsoleColor.Green);
                            }
                            else
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "sort":
                        stopwatch.Start();

                        if (splitUserInput.Length != 3)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else
                        {
                            nameAlreadyInUse = this.CheckName(splitUserInput[2], ref index, myListContainer, myListContainerCounter);

                            if (!nameAlreadyInUse)
                            {
                                this.OnOutput("Error: Name not found!", ConsoleColor.Red);
                            }
                            else
                            {
                                switch (splitUserInput[1].ToLower())
                                {
                                    case "tree":
                                        myListContainer[index] = Algorithm.TreeSort(myListContainer[index]);
                                        this.OnOutput("\nList sorted with the tree sort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "bubble":
                                        Algorithm.BubbleSort(myListContainer[index]);
                                        this.OnOutput("\nList sorted with the bubble sort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "insertion":
                                        Algorithm.InsertionSort(myListContainer[index]);
                                        this.OnOutput("\nList sorted with the insertion sort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "merge":
                                        Algorithm.MergeSort(myListContainer[index], 0, myListContainer[index].Count - 1);
                                        this.OnOutput("\nList sorted with the merge sort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "quick":
                                        Algorithm.QuickSort(myListContainer[index], 0, myListContainer[index].Count - 1);
                                        this.OnOutput("\nList sorted with the quicksort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "selection":
                                        Algorithm.SelectionSort(myListContainer[index]);
                                        this.OnOutput("\nList sorted with the selection sort algorithm.", ConsoleColor.Green);

                                        break;

                                    case "shell":
                                        Algorithm.ShellSort(myListContainer[index]);
                                        this.OnOutput("\nList sorted with the shell sort algorithm.", ConsoleColor.Green);

                                        break;
                                    default:
                                        this.OnOutput("\nUnknow sorting algorithm entered.", ConsoleColor.Red);
                                        break;
                                }
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "copy":
                        stopwatch.Start();

                        if (splitUserInput.Length != 3)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else if (myListContainerCounter == myListContainer.Length)
                        {
                            this.OnOutput("Error: Can't store more variables. You have to delete an existing one before adding a new one!", ConsoleColor.Red);
                        }
                        else
                        {
                            nameAlreadyInUse = CheckName(splitUserInput[2], ref index, myListContainer, myListContainerCounter);

                            if (!nameAlreadyInUse)
                            {
                                nameAlreadyInUse = CheckName(splitUserInput[1], ref index, myListContainer, myListContainerCounter);

                                if (!nameAlreadyInUse)
                                {
                                    this.OnOutput("Error: " + splitUserInput[1] + " not found!", ConsoleColor.Red);
                                    error = true;
                                }
                                else
                                {
                                    myListContainer[myListContainerCounter] = new MyList(splitUserInput[2]);

                                    myListContainer[myListContainerCounter].Copy(myListContainer[index], myListContainer[myListContainerCounter]);
                                    myListContainerCounter++;
                                }
                            }
                            else
                            {
                                this.OnOutput("Error: " + splitUserInput[2] + " already used!", ConsoleColor.Red);
                                error = true;
                            }

                            if (!error)
                            {
                                this.OnOutput("\nVariable copied!", ConsoleColor.Green);
                            }
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "history":
                        stopwatch.Start();

                        this.OnOutput(historyQueue.Print(), ConsoleColor.Cyan);

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    case "!":
                        stopwatch.Start();

                        if (splitUserInput.Length > 2)
                        {
                            this.OnOutput("Error: Wrong input!", ConsoleColor.Red);
                        }
                        else if (splitUserInput.Length == 1)
                        {
                            try
                            {
                                history = historyQueue.GetInstruction(0);
                            }
                            catch (Exception ex)
                            {
                                this.OnOutput("Error: " + ex.Message, ConsoleColor.Red);
                                error = true;
                            }
                        }
                        else
                        {
                            try
                            {
                                history = historyQueue.GetInstruction(Convert.ToInt32(splitUserInput[1]));
                            }
                            catch (Exception ex)
                            {
                                this.OnOutput("Error: " + ex.Message, ConsoleColor.Red);
                                error = true;
                            }
                        }

                        if (!error)
                        {
                            this.inputEventArgs.Input = history;
                        }

                        stopwatch.Stop();
                        this.PrintTimeTaken(stopwatch.Elapsed);

                        break;

                    default:
                        this.OnOutput("\nUnknow instruction entered.", ConsoleColor.Red);
                        break;
                }

                // only add input to history if its not history or !
                if (!splitUserInput[0].ToLower().Equals("history") && !splitUserInput[0].Equals("!"))
                {
                    this.AddToHistory(this.inputEventArgs.Input, historyQueue);
                }

                // delete inputargs if input was ! to repeat the last instruction
                if (!splitUserInput[0].Equals("!"))
                {
                    this.inputEventArgs.Input = string.Empty;
                }
            }
            while (running);
        }

        /// <summary>
        /// Raises output event.
        /// </summary>
        /// <param name="message">Message for output.</param>
        /// <param name="color">Console color.</param>
        protected virtual void OnOutput(string message, ConsoleColor color = ConsoleColor.White)
        {
            if (this.OutputEvent != null)
            {
                this.OutputEvent(this, new OutputEventArgs(message, color));
            }
        }

        /// <summary>
        /// Raises input event.
        /// </summary>
        /// <param name="inputEventArgs">Will contain user input.</param>
        protected virtual void OnInput(InputEventArgs inputEventArgs)
        {
            if (this.InputEvent != null)
            {
                this.InputEvent(this, inputEventArgs);
            }
        }

        /// <summary>
        /// Check if variable name is already used.
        /// </summary>
        /// <param name="name">Check name.</param>
        /// <param name="index">Index where name was found.</param>
        /// <param name="myListContainer">List for searching.</param>
        /// <param name="myListContainerCounter">Length of the list.</param>
        /// <returns>Returns whether the name was found or not.</returns>
        private bool CheckName(string name, ref int index, MyList[] myListContainer, int myListContainerCounter)
        {
            bool found = false;

            for (int i = 0; i < myListContainerCounter; i++)
            {
                if (myListContainer[i].Name.Equals(name.ToLower()))
                {
                    index = i;
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Method prints all available instructions.
        /// </summary>
        private void ShowAllInstruction()
        {
            this.OnOutput("\nCreate  --> Create variable name [number | list of numbers seperated by space | r amount]: e.g. Create a r 5\n", ConsoleColor.Cyan);
            this.OnOutput("Delete    --> Delete a variable: e.g. Delete a\n", ConsoleColor.Magenta);
            this.OnOutput("Exit      --> End the application\n", ConsoleColor.Cyan);
            this.OnOutput("Help      --> Prints all available instructions.\n", ConsoleColor.Magenta);
            this.OnOutput("Print     --> Prints all or a specific variable print [name]: e.g. Print a\n", ConsoleColor.Cyan);
            this.OnOutput("Append    --> Appends values to a variable, Append name number | list of numbers seperated by space | r amount]: e.g. Append a r 5\n", ConsoleColor.Magenta);
            this.OnOutput("InsertAt  --> Inserts values at an index, InsertAt name index number | list of numbers seperated by space | r amount]: e.g. InsertAt a r 5\n", ConsoleColor.Cyan);
            this.OnOutput("RemoveAt  --> Removes a value at an index, RemoveAt name index, e.g. Remove a 3\n", ConsoleColor.Magenta);
            this.OnOutput("Reverse   --> Revereses the values of a variable, Reverse name, e.g. Reverse a\n", ConsoleColor.Cyan);
            this.OnOutput("Sort      --> Sorts a variable with an algorithm, Sort alogirthm name, e.g. Sort bubble a", ConsoleColor.Magenta);
            this.OnOutput("              Available algorithm: tree, bubble, insertion, merge, quick, selection, shell\n", ConsoleColor.Cyan);
            this.OnOutput("History   --> Prints up to the last 10 instructions\n", ConsoleColor.Magenta);
            this.OnOutput("!         --> Executes the last instruction, or with ! number the instruction with the number of the history\n", ConsoleColor.Cyan);
        }

        /// <summary>
        /// Method prints time taken for operation if > 100 milliseconds.
        /// </summary>
        /// <param name="timeTaken">Time taken for operation.</param>
        private void PrintTimeTaken(TimeSpan timeTaken)
        {
            if (timeTaken.TotalMinutes > 1)
            {
                this.OnOutput("Operation took: " + timeTaken.Minutes + ":" + (Math.Round(timeTaken.TotalSeconds) % 60) + " min\n", ConsoleColor.DarkGray);
            }
            else if (timeTaken.TotalSeconds > 1)
            {
                this.OnOutput("Operation took: " + Math.Round(timeTaken.TotalSeconds) + ":" + Math.Round(timeTaken.TotalMilliseconds) + " sec\n", ConsoleColor.DarkGray);
            }
            else if (timeTaken.TotalMilliseconds > 100)
            {
                this.OnOutput("Operation took: " + Math.Round(timeTaken.TotalMilliseconds) + " ms\n", ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        /// Method to add input to the history.
        /// </summary>
        /// <param name="input">User input.</param>
        /// <param name="historyQueue">List for adding input.</param>
        private void AddToHistory(string input, MyQueue historyQueue)
        {
            historyQueue.Append(input);
        }
    }
}