using NameSorter;
using System;
using System.Collections.Generic;

namespace NameSorterConsole
{
    /// <summary>
    /// Program to Sort a list of names, output to screen and print to a file
    /// </summary>
    class Program
    {
        private static readonly string savePath = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            //Input
            if (args.Length == 0 || !System.IO.File.Exists(args[0]))
            {
                Console.WriteLine("Invaild File Provided, Please Try Again");
                return;
            }
            string[] input = System.IO.File.ReadAllLines(args[0]);

            //Sorting
            List<Name> names = new List<Name>();
            foreach (string fullName in input)
            {
                try
                {
                    names.Add(new Name(fullName));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Reading Name: " + fullName);
                }
            }
            names.Sort();

            //OutPut
            string sortedNames = string.Join<Name>(Environment.NewLine, names.ToArray());
            Console.WriteLine();
            Console.Write(sortedNames);
            System.IO.File.WriteAllText(savePath, sortedNames);

            Console.ReadKey();
        }
    }
}
