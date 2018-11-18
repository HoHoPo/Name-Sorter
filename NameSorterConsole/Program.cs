using NameSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterConsole
{
    class Program
    {
        private static readonly string openPath = "unsorted-names-list.txt";
        private static readonly string savePath = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(openPath);

            List<Name> names = new List<Name>();
            foreach (string fullName in input)
            {
                names.Add(new Name(fullName));
            }
            names.Sort();

            string sortedNames = string.Join<Name>(Environment.NewLine, names.ToArray());
            Console.Write(sortedNames);
            System.IO.File.WriteAllText(savePath, sortedNames);

            Console.ReadKey();
        }
    }
}
