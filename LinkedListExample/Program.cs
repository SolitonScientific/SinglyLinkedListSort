using System;

namespace SinglyLinkedListExample
{
    /// <summary>
    /// Test Console Application for a List
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation
            var list = new SinglyLinkedList();

            list.Add("AA");
            list.Add("BB");
            list.Add("CC");
            list.Add("DD");
            list.Add("EE");
            list.Add("FF");
            list.Add("GG");
            list.Add("HH");

            // Navigation and Search
            Console.WriteLine(list.Print());

            Console.WriteLine();
            Console.WriteLine("First: " + list.First());

            Console.WriteLine();
            Console.WriteLine("Last: "  + list.Last());

            Console.WriteLine();
            Console.WriteLine("Find(FF): " + list.Find("FF"));

            Console.WriteLine();
            Console.WriteLine("Find(HH): " + list.Find("HH"));

            Console.WriteLine();
            Console.WriteLine("Find(AA): " + list.Find("AA"));

            // Deletion
            Console.WriteLine();
            Console.WriteLine("Deleting node 7");

            list.Delete(7);

            Console.WriteLine();
            Console.WriteLine(list.Print());

            Console.WriteLine();
            Console.WriteLine("Position 5: " + list.GetNode(5).Content);

            Console.WriteLine();
            Console.WriteLine("Deleting node 1");

            list.Delete(1);

            Console.WriteLine();
            Console.WriteLine("Position 5: " + list.Get(5));

            // Printing
            Console.WriteLine();
            Console.WriteLine(list.Print());

            Console.ReadLine();
        }
    }
}
