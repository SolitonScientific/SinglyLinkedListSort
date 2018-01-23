using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SinglyLinkedListExample.Tests
{
    /// <summary>
    /// Unit Testing of Singly Linked Lists
    /// </summary>
    [TestClass()]
    public class SinglyLinkedListTests
    {
        SinglyLinkedList list = new SinglyLinkedList();

        /// <summary>
        /// Constructor
        /// </summary>
        public SinglyLinkedListTests()
        {
            InitialiseTestData();
        }

        /// <summary>
        /// Initialising Test Data
        /// </summary>
        private void InitialiseTestData()
        {
            // Initialise Data
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");
            list.Add("Eight");
        }

        /// <summary>
        /// Simple Counting Test
        /// </summary>
        [TestMethod()]
        public void SimpleCountTest()
        {
            Assert.AreEqual(list.Count(), 8);
        }

        /// <summary>
        /// CRUD Functionality Test
        /// </summary>
        [TestMethod()]
        public void FunctionalityTest()
        {
            // Initialisation test
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() > 0);

            // Counter Test
            int initCounter = 8;
            Assert.AreEqual(list.Count(), initCounter);

            // Finding test
            Assert.AreEqual(list.First(), "One");
            Assert.AreEqual(list.Last(), "Eight");
            Assert.AreEqual(list.Find("Six"), 6);
            Assert.AreEqual(list.Find("Eight"), 8);
            Assert.AreEqual(list.Find("One"), 1);

            // Deletion tests

            // Deleting a node (#7)
            string node7 = list.Get(7);
            list.Delete(7);
            Assert.AreEqual(list.Count(), initCounter - 1);
            Assert.AreEqual(list.Find(node7), -1);
            // Get Position 5 after Deletion
            Assert.AreEqual(list.GetNode(5).Content, "Five");

            // Deleting a node (#1)
            string node1 = list.Get(1);
            list.Delete(1);
            Assert.AreEqual(list.Count(), initCounter - 2);
            Assert.AreEqual(list.Find(node1), -1);
            // Get Position 5 after Deletion
            Assert.AreEqual(list.Get(5), "Six");

            // Printing test (just for debugging)
            string output = list.Print();
            Assert.IsNotNull(output);
        }

        // String Comparison Test for Sorting
        [TestMethod()]
        public void StringComparisonTest()
        {
            Assert.IsTrue(list.Less("Aus", "Usa"));
            Assert.IsTrue(list.Less("Aus", "Bol"));
            Assert.IsTrue(list.Less("UUU", "ZZZ"));

            Assert.IsFalse(list.Less("Zzz", "Aud"));
            Assert.IsFalse(list.Less("Four", "Five"));
        }

        /// <summary>
        /// Sorting Test
        /// </summary>
        [TestMethod()]
        public void SortingTest()
        {
            int initCounter = list.Count();

            // Get initial order
            var initialOrder = list.Print();

            // Fast Sort by Merging
            list.MergeSort(ref list.Head);

            // Get final order
            var finalOrder = list.Print();

            // Test
            Assert.AreEqual(list.Count(), initCounter);
            Assert.AreNotEqual(initialOrder, finalOrder);

            // Make sure the list is sorted properly
            Assert.AreEqual(list.First(), "Eight");
            Assert.AreEqual(list.Get(2),  "Five");
            Assert.AreEqual(list.Get(3),  "Four");
            Assert.AreEqual(list.Last(),  "Two");
        }
    }
}