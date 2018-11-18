using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /// <summary>
    /// Containts a name, with a last name and up to 3 given names
    /// </summary>
    public class Name
    {
        readonly string lastName;
        readonly string[] givenNames;

        public Name(string lastName, string[] givenNames)
        {
            this.lastName = lastName;
            this.givenNames = givenNames;

        }
    }
}
