using System;

namespace SinglyLinkedListExample
{
    /// <summary>
    /// Singly Linked List
    /// </summary>
    public class SinglyLinkedList
    {
        #region Properties and Constructor
        // Private Properties
        /// <summary>
        /// current node 
        /// </summary>
        private Node current;

        // Public properties
        /// <summary>
        /// Head Node
        /// </summary>
        public Node Head;

        /// <summary>
        /// Maximum Capacity of the list
        /// </summary>
        public int  Capacity { get; private set; }

        /// <summary>
        /// Sorting Algorithms
        /// </summary>
        public enum SortingAlgo { MergeSort };

        /// <summary>
        /// Constructor
        /// </summary>
        public SinglyLinkedList()
        {
            Capacity = 0;
            Head = null;
        }
        #endregion

        #region List Navigation and Counting
        /// <summary>
        /// Number of linked items in a list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int count = 0;
            // Because Capacity cannot be used for Counting, we need to itergate through items
            Node tempNode = Head;
            while (tempNode != null)
            {
                count++;
                tempNode = tempNode.Next;
            }
            return count;
        }

        /// <summary>
        /// First Node Value
        /// </summary>
        /// <returns></returns>
        public string First()
        {
            var node = GetNode(1);
            return node != null ? node.Content : null;
        }

        /// <summary>
        /// Last Node Value
        /// </summary>
        /// <returns></returns>
        public string Last()
        {
            var node = GetNode(Capacity);
            return node != null ? node.Content : null;
        }

        /// <summary>
        /// Get Node at Location
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Node GetNode(int position)
        {
            Node tempNode = Head;
            Node retNode = null;
            int count = 0;

            while (tempNode != null)
            {
                if (count == position - 1)
                {
                    retNode = tempNode;
                    break;
                }
                count++;
                tempNode = tempNode.Next;
            }

            return retNode;
        }
        
        /// <summary>
        /// Get Value at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public string Get(int position)
        {
            Node node = GetNode(position);
            return node != null ? node.Content : null;
        }
        #endregion

        #region Add Content
        public void Add(string content)
        {
            Capacity++;
            var node = new Node() { Content = content };
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                current.Next = node;
            }
            current = node;
        }
        #endregion

        #region Delete List
        /// <summary>
        /// Delete List at particular position
        /// </summary>
        /// <param name="position"></param>
        public void Delete(int position)
        {
            Node previousNode = null;
            Node currentNode = Head;

            int count = 1;
            while (currentNode != null)
            {
                while (count <= Capacity)
                {
                    if (count == position)
                    {
                        if (previousNode == null)
                        {
                            Head = currentNode.Next;
                            current = null;
                        }
                        else
                        {
                            previousNode.Next = currentNode.Next;
                            currentNode = null;                            
                        }
                    }
                    else
                    {
                        previousNode = currentNode;
                    }

                    if (currentNode != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    count++;
                }
            }
        }
        #endregion

        #region Search and Printing
        /// <summary>
        /// Find Node Index by Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Find(string value)
        {
            Node node = Head;
            int index = -1;
            int count = 0;

            while (node != null)
            {
                count++;
                if (node.Content.Equals(value))
                {
                    index = count;
                    break;
                }
                node = node.Next;
            }

            return index;
        }

        /// <summary>
        /// Print List
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            String retString = String.Empty;
            Node   tempNode  = Head;
            int count = 0;
            while (tempNode != null)
            {
                retString += String.Format("[{0}]:{1} ", (++count).ToString(), tempNode.Content);
                tempNode = tempNode.Next;
            }
            return retString;
        }
        #endregion

        #region Sorting
        /// <summary>
        /// Sorting the list using
        /// </summary>
        public void Sort(SortingAlgo algo = SortingAlgo.MergeSort)
        {
            // This allows multiple Sorting Agorithms
            if (algo == SortingAlgo.MergeSort)
                MergeSort(ref this.Head);
        }

        /// <summary>
        /// Merge Sort Method implementing Split and Concour algorithm
        /// </summary>
        /// <param name="headRef"></param>
        public void MergeSort(ref Node headRef)
        {
            Node a = null, b = null;
            Head = headRef;
            if (Head == null || Head.Next == null)
            {
                return;
            }

            // Split list in half
            ListSplit(ref a, ref b);

            // Recursive Sorting of each part
            MergeSort(ref a);
            MergeSort(ref b);

            // Merge Split List into one
            headRef = SortedMerge(a, b);
        }

        /// <summary>
        /// Split List into two parts
        /// </summary>
        /// <param name="frontRef">Front part of a split</param>
        /// <param name="backRef">Back part of a split</param>
        public void ListSplit(ref Node frontRef, ref Node backRef)
        {
            Node fast = null, slow = null;
            if (Head == null || Head.Next == null)
            {
                frontRef = Head;
                backRef = null;
            }
            else
            {
                slow = Head;
                fast = Head.Next;

                // Advance fast by two nodes, and slow by one node to get the split
                while (fast != null)
                {
                    fast = fast.Next;
                    if (fast != null) 
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }
                }

                frontRef = Head;
                backRef = slow.Next;
                slow.Next = null;
            }
        }

        /// <summary>
        /// Merge of two list nodes
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Node SortedMerge(Node a, Node b)
        {
            if (a == null)
                return b;
            else if (b == null)
                return a;

            Node result;
            if (Less(a.Content, b.Content))
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }

            return result;
        }

        /// <summary>
        /// Compare strings in alphibetical order
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool Less(string a, string b)
        {
            bool retValue = false;
            // Check whether string a less than b
            if (a == b)
                retValue = true;
            else if (string.Compare(a, b) < 0)
                retValue = true;
            return retValue;
        }
        #endregion
    }
}
