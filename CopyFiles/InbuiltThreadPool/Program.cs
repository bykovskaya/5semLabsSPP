using System;
using System.IO;
using System.Threading;

namespace CopyFiles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Source path:");
            var source = Console.ReadLine();
            Console.WriteLine("Destination path:");
            var dest = Console.ReadLine();
            CopyDirectoriesWithFiles(source, dest);
            Console.ReadLine();
        }

        private static void CopyDirectoriesWithFiles(string source, string dest)
        {
            if (!Directory.Exists(source))
            {
                Console.WriteLine($"Directory \"{source}\" not exists");
                return;
            }

            var (isError, message) = CopyDirectories(source, dest);
            if (isError)
            {
                Console.WriteLine($"Copy directories finished with error; Error - {message}");
                return;
            }

            (isError, message) = CopyFiles(source, dest);
            if (isError)
            {
                Console.WriteLine($"Copy files finished with error; Error - {message}");
            }
        }

        private static (bool, string) CopyDirectories(string source, string dest)
        {
            foreach (var dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                try
                {
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        Directory.CreateDirectory(dirPath.Replace(source, dest));
                        Console.WriteLine($"Created directory {Thread.CurrentThread.ManagedThreadId}");
                    });
                }
                catch (Exception e)
                {
                    return (true, e.Message);
                }
            }

            return (false, null);
        }

        private static (bool, string) CopyFiles(string source, string dest)
        {
            foreach (var newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        File.Copy(newPath, newPath.Replace(source, dest), true);
                        Console.WriteLine($"Created file {Thread.CurrentThread.ManagedThreadId}");
                    });
                }
                catch (Exception e)
                {
                    return (true, e.Message);
                }
            }

            return (false, null);
        }
    }
}