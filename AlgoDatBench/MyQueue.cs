// ----------------------------------------------------------------------- 
// <copyright file="MyQueue.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class for entry point of the list.
    /// </summary>
    public class MyQueue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyQueue"/> class.
        /// </summary>
        public MyQueue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyQueue"/> class.
        /// </summary>
        /// <param name="value">Root node value.</param>
        public MyQueue(string value)
        {
            this.Append(value);
        }

        /// <summary>
        /// Gets or sets the value of the root node.
        /// </summary>
        /// <value>Root node.</value>
        public QueueNode RootNode { get; set; }

        /// <summary>
        /// Gets or sets the value of the count.
        /// </summary>
        /// <value>Count value.</value>
        public int Count { get; set; }

        /// <summary>
        /// Method appends a value at the end of the list.
        /// </summary>
        /// <param name="value">Value for appending.</param>
        public void Append(string value)
        {
            if (this.Count == 0)
            {
                this.RootNode = new QueueNode(value);
                this.Count++;
            }
            else if (this.Count == 10)
            {
                QueueNode node = this.RootNode;

                for (int i = 0; i < this.Count; i++)
                {
                    node.InstructionNumber++;

                    if (node.InstructionNumber > 9)
                    {
                        node.Value = value;
                        node.InstructionNumber = 0;
                    }

                    node = node.Next;
                }
            }
            else
            {
                this.RootNode.InstructionNumber++;
                this.RootNode.Append(value);
                this.Count++;
            }
        }

        /// <summary>
        /// Method for printing the history.
        /// </summary>
        /// <returns>Returns string for printing.</returns>
        public string Print()
        {
            string message = string.Empty;
            QueueNode node = this.RootNode;

            for (int i = 0; i < this.Count; i++)
            {
                message += node.InstructionNumber + ": " + node.Value + "\n";
                node = node.Next;
            }

            return message;
        }

        /// <summary>
        /// Method gets instruction from the history.
        /// </summary>
        /// <param name="instructionNumber">Number of the instruction.</param>
        /// <returns>Returns the instruction as a string.</returns>
        internal string GetInstruction(int instructionNumber)
        {
            string message = string.Empty;
            QueueNode node = this.RootNode;

            if (instructionNumber < 0 || instructionNumber > this.Count)
            {
                throw new Exception("Number must be between 0 and " + (this.Count - 1));
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (instructionNumber == node.InstructionNumber)
                    {
                        message = node.Value;
                        break;
                    }
                   
                    node = node.Next;
                }
            }

            return message;
        }
    }
}