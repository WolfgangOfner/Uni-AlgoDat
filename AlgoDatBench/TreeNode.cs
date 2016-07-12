// ----------------------------------------------------------------------- 
// <copyright file="TreeNode.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    /// <summary>
    /// Class for tree node.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        /// <value>Value of the node.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the left side node.
        /// </summary>
        /// <value>Left side.</value>
        public TreeNode LeftChild { get; set; }

        /// <summary>
        /// Gets or sets the right side node.
        /// </summary>
        /// <value>Right side.</value>
        public TreeNode RightChild { get; set; }
    }
}
