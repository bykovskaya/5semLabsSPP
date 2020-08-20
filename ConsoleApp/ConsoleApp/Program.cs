using System;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 15, 3, 20, 15, 9, 81, 16, 25, 14, 6, 2, 64, 58 };
            BinaryTree tree = new BinaryTree(array);

            foreach (int x in array)
                Console.Write(x + " ");
            Console.WriteLine();
            tree.Show();
            tree.Search(17);
            tree.Add(10);
            tree.Search(10);
            tree.Show();
            Console.Read();
        }
    }
    
}
