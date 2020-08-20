using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SPP6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The path to the Assembly (exe or dll):");
            var path = Console.ReadLine();

            if ((!File.Exists(path)) || (path == null))
            {
                Console.WriteLine($"The path {path} not exist.");

            }
            else
            {
                foreach (var dataType in Assembly.LoadFrom(path)
                                                             .GetTypes()
                                                             .Where(x => x.IsPublic)?.OrderBy(x => x.Namespace)
                                                                                     .ThenBy(x => x.Name))
                {
                    Console.WriteLine(dataType.FullName);
                }
            }
            Console.ReadLine();
        }
    }
}
//E:\5sem\lib\AForge.dll