// ----------------------------------------------------------------------- 
// <copyright file="myList.cs" company="FHWN"> 
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
    public class MyList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyList"/> class.
        /// </summary>
        /// <param name="name">Name of the list.</param>
        public MyList(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyList"/> class.
        /// </summary>
        /// <param name="name">Name of the list.</param>
        /// <param name="value">Root node value.</param>
        public MyList(string name, params int[] value)
        {
            foreach (var item in value)
            {
                this.Append(item);
            }

            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the value of the root node.
        /// </summary>
        /// <value>Root node.</value>
        public Node RootNode { get; set; }

        /// <summary>
        /// Gets or sets the value of the count.
        /// </summary>
        /// <value>Count value.</value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the name of the list.
        /// </summary>
        /// <value>Name of the list.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last node in the list.
        /// </summary>
        /// <value>The last node in the list.</value>
        public Node LastNode { get; set; }

        /// <summary>
        /// Method appends a value at the end of the list.
        /// </summary>
        /// <param name="value">Value for appending.</param>
        public void Append(int value)
        {
            if (this.Count == 0)
            {
                this.RootNode = new Node(value);
                this.Count++;
            }
            else if (this.Count == 1)
            {
                this.LastNode = new Node(value);
                this.LastNode.Previous = this.RootNode;
                this.RootNode.Next = this.LastNode;
                this.RootNode.Previous = this.LastNode;
                this.Count++;
            }
            else
            {
                Node n = new Node(value);
                this.LastNode.Next = n;
                this.RootNode.Previous = n;
                n.Previous = this.LastNode;
                this.LastNode = n;
                this.Count++;
            }
        }

        /// <summary>
        /// Method to insert a value at a specific index.
        /// </summary>
        /// <param name="value">Value for adding.</param>
        /// <param name="index">Index where to add.</param>
        public void InsertAt(int value, int index)
        {            
            if (index > this.Count)
            {
                throw new Exception("Index must not be greater than the amount of values in the list!");
            }
            else if (index == 0 && this.Count == 0)
            {
                this.RootNode = new Node(value);
                this.Count++;
            }
            else if (index == this.Count)
            {
                this.Append(value);
            }
            else if (index > 0)
            {
                // -1 because of root Node
                Node oldNode = this.GetNode(index - 1);
                Node n = new Node(value);                
                n.Next = oldNode.Next;
                oldNode.Next = n;
                n.Previous = oldNode;
                n.Next.Previous = n;
                this.Count++;
            }
            else if (index == 0)
            {
                Node n = new Node(value);
                n.Next = this.RootNode;
                this.RootNode.Previous = n;
                this.RootNode = n;
                this.Count++;
            }
            else
            {
                throw new Exception("Index must be at least 0!");
            }
        }

        /// <summary>
        /// Method to remove a value at a specific index.
        /// </summary>
        /// <param name="index">Index where to remove.</param>
        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                throw new Exception("No values in the list!");
            }
            else if (index >= this.Count)
            {
                throw new Exception("Index must be at least one less than the amount of values in the list!");
            }
            else if (index == this.Count - 1 && index != 0)
            {
                // delete last element
                Node n = this.LastNode.Previous;
                n.Next = null;
                this.LastNode = n;
                this.Count--;
            }
            else if (index > 0)
            {
                Node deleteNode = this.GetNode(index);
                Node n = deleteNode.Previous;
                deleteNode.Next.Previous = n;
                n.Next = deleteNode.Next;
                this.Count--;
            }
            else if (index == 0)
            {
                // delete root node
                if (this.Count == 1)
                {
                    this.RootNode = null;                   
                }
                else if (this.Count == 2)
                {
                    this.RootNode = this.LastNode;
                    this.RootNode.Previous = null;
                    this.LastNode = null;
                }
                else
                {
                    this.RootNode = this.RootNode.Next;
                    this.RootNode.Previous = this.LastNode;
                }

                this.Count--;
            }
            else
            {
                throw new Exception("Index must be at least 0!");
            }
        }

        /// <summary>
        /// Method reverses list.
        /// </summary>
        /// <param name="myList">List which will be reversed.</param>
        /// <returns>Reversed list.</returns>
        public MyList Reverse(MyList myList)
        {
            MyList reverse = new MyList(myList.Name);

            if (myList.Count > 2)
            {
                Node test = this.RootNode.Previous;

                for (int i = 0; i < myList.Count; i++)
                {
                    reverse.Append(test.Value);
                    test = test.Previous;
                }
            }
            else if (myList.Count == 1)            
            {
                reverse.Append(myList.RootNode.Value);
            }

            return reverse;
        }

        /// <summary>
        /// Method prints values of list.
        /// </summary>
        /// <param name="myList">List for printing.</param>
        /// <returns>String for output.</returns>
        public string PrintAllVariable(MyList myList)
        {
            string listContent = "[";

            Node node = myList.RootNode;

            if (myList.Count < 11)
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    listContent += node.Value;

                    if (i != myList.Count - 1)
                    {
                        node = node.Next;
                        listContent += ", ";
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    listContent += node.Value + ", ";

                    node = node.Next;
                }

                listContent += "..., ";

                node = myList.RootNode;

                for (int i = 0; i < 5; i++)
                {
                    node = node.Previous;
                }

                for (int i = 0; i < 5; i++)
                {
                    listContent += node.Value;

                    if (i != 4)
                    {
                        node = node.Next;
                        listContent += ", ";
                    }
                }
            }

            listContent += "]";

            return listContent;
        }

        /// <summary>
        /// Method for getting a specific node of the list.
        /// </summary>
        /// <param name="index">Index value.</param>
        /// <returns>Wanted node.</returns>
        public Node GetNode(int index)
        {
            if (index >= this.Count)
            {
                return null;
            }

            Node node = this.RootNode;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        /// <summary>
        /// Method prints values of list.
        /// </summary>
        /// <param name="myList">List for printing.</param>
        /// <returns>String for output.</returns>
        public string PrintOneVariable(MyList myList)
        {
            string listContent = "[";

            Node node = myList.RootNode;
            
                for (int i = 0; i < myList.Count; i++)
                {
                    listContent += node.Value;

                    if (i != myList.Count - 1)
                    {
                        node = node.Next;
                        listContent += ", ";
                    }
                }

            listContent += "]";

            return listContent;
        }

        /// <summary>
        /// Method copies lists.
        /// </summary>
        /// <param name="source">Source list.</param>
        /// <param name="destination">Destination list.</param>
        internal void Copy(MyList source, MyList destination)
        {
            Node node = source.RootNode;

            for (int i = 0; i < source.Count; i++)
            {
                destination.Append(node.Value);

                if (i != source.Count - 1)
                {
                    node = node.Next;
                }
            }
        }
    }
}