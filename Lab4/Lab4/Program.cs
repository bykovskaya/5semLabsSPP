using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter source directory : ");
            string sourceDir = Console.ReadLine();
            Console.WriteLine("Enter destination directory : ");
            string destDir = Console.ReadLine();
            try
            {
                List<string> files = new List<string>();
                GetFiles(sourceDir, files);
                Task[] tasks = new Task[files.Count];
                int i = 0;
                foreach(string file in files)
                { 
                    tasks[i++] = Task.Factory.StartNew(() => CopyFiles(sourceDir, destDir, file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static void CopyFiles(string sourceDir, string destDir, string file)
        {
            string newPath = file.Replace(sourceDir, destDir);
            try
            {
                FileInfo fInf = new FileInfo(file);
                string dirInf = fInf.DirectoryName;
                dirInf = dirInf.Replace(sourceDir, destDir);
                if (!Directory.Exists(dirInf))
                    Directory.CreateDirectory(dirInf);
                fInf.CopyTo(newPath, true);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: SUCCESS: {file}");
            }
            catch
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: ERROR: can't copy file {file}");
            }
        }

        static void GetFiles(string sourceDir, List<string> files)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(sourceDir);
                foreach (string s in dirs)
                {
                    GetFiles(s, files);
                }
                string[] file = Directory.GetFiles(sourceDir);
                foreach (string s in file)
                {
                    files.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No such directory");
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
