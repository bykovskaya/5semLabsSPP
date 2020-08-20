using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node tree = new Node(null, 35);
            int[] numbers = { 15, 9, 81, 16, 25, 14, 6, 2, 64, 58 };

            foreach (int num in numbers)
            {
                tree.Add(num);
            }

            Console.WriteLine("Симметричный обход:");
            foreach (Node node in tree)
            {
                Console.Write(node.data + " ");
            }

            tree.Add(12);
            Console.WriteLine();

            Console.WriteLine("Симметричный обход:");
            foreach (Node node in tree)
            {
                Console.Write(node.data + " ");
            }
        }
    }
}
