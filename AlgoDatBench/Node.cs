// ----------------------------------------------------------------------- 
// <copyright file="Node.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    using System;

    /// <summary>
    /// Class for nodes of the list.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Node value.</param>
        public Node(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        /// <value>Value of the node.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the value of the next node.
        /// </summary>
        /// <value>Value of the next node.</value>
        public Node Next { get; set; }

        /// <summary>
        /// Gets or sets the value of the previous node.
        /// </summary>
        /// <value>Value of the previous node.</value>
        public Node Previous { get; set; }
    }
}