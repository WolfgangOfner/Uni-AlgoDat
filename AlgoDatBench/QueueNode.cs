// ----------------------------------------------------------------------- 
// <copyright file="QueueNode.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    /// <summary>
    /// Class of the queue nodes.
    /// </summary>
    public class QueueNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNode"/> class.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public QueueNode(string value)
        {
            this.Value = value;
            this.InstructionNumber = 0;
        }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        /// <value>Value of the node.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the value of the next node.
        /// </summary>
        /// <value>Value of the next node.</value>
        public QueueNode Next { get; set; }

        /// <summary>
        /// Gets or sets the value of the instruction number.
        /// </summary>
        /// <value>Instruction number.</value>
        public int InstructionNumber { get; set; }

        /// <summary>
        /// Method appends a value at the end of the list.
        /// </summary>
        /// <param name="value">Value for appending.</param>
        public void Append(string value)
        {
            if (this.Next == null)
            {
                QueueNode node = new QueueNode(value);
                this.Next = node;
            }
            else
            {
                this.Next.InstructionNumber++;
                this.Next.Append(value);
            }
        }
    }
}
