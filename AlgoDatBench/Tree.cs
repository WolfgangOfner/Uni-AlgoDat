// ----------------------------------------------------------------------- 
// <copyright file="Tree.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    /// <summary>
    /// Tree class.
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tree"/> class.
        /// </summary>
        /// <param name="myList">List with numbers.</param>
        public Tree(MyList myList)
        {
            Node n = myList.RootNode;

            for (int i = 0; i < myList.Count; i++)
            {
                this.Insert(n.Value);
                n = n.Next;
            }
        }

        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        /// <value>Root node.</value>
        public TreeNode Root { get; set; }

        /// <summary>
        /// Insert a value into the tree.
        /// </summary>
        /// <param name="value">Value for insertion.</param>
        public void Insert(int value)
        {
            TreeNode newNode = new TreeNode();
            newNode.Value = value;

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                TreeNode current = this.Root;
                TreeNode parent;

                while (true)
                {
                    parent = current;

                    if (value < current.Value)
                    {
                        current = current.LeftChild;

                        if (current == null)
                        {
                            parent.LeftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.RightChild;

                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to output sorted tree.
        /// </summary>
        /// <param name="root">Root node.</param>
        /// <param name="output">Output string.</param>
        public void Sort(TreeNode root, MyList output)
        {
            if (root != null)
            {
                this.Sort(root.LeftChild, output);
                output.Append(root.Value);
                this.Sort(root.RightChild, output);
            }
        }
    }
}