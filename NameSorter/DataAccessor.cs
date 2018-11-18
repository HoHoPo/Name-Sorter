using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /// <summary>
    /// Controlls data importing for the Name lists
    /// </summary>
    public static class DataAccessor
    {
        /// <summary>
        /// Imports a name list from a file
        /// </summary>
        /// <param name="path">The path the names will be loaded from</param>
        /// <returns></returns>
        public static string[] LoadNameList(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;

        }
    }
}
