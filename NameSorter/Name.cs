using System;

namespace NameSorter
{
    /// <summary>
    /// Containts a name, with a last name and 1 to 3 given names
    /// </summary>
    public class Name : IComparable<Name>
    {
        public string LastName { get; private set; }
        public string[] GivenNames { get; private set; }

        ///Controls number of accepted givenNames -- Be aware comments wont autoUpdate
        private readonly int minGivenNames = 1;
        private readonly int maxGivenNames = 3;

        /// <summary>
        /// Create a new name with last name and given names
        /// </summary>
        /// <param name="lastName">LastName to be used</param>
        /// <param name="givenNames">Given Names to be used, must be between 1 and 3 </param>
        public Name(string lastName, string[] givenNames)
        {
            this.ChangeGivenNames(givenNames);
            this.ChangeLastName(lastName);
        }

        /// <summary>
        /// Create a new Name based of a string
        /// </summary>
        /// <param name="fullName"> A string with space seperated parts, in order givenNames, LastName </param>
        public Name(string fullName)
        {
            string[] splitNames = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] possGivenNames = new string[splitNames.Length-1];

            Array.Copy(splitNames, possGivenNames, splitNames.Length - 1);

            this.ChangeGivenNames(possGivenNames);
            this.ChangeLastName(splitNames[splitNames.Length - 1]);
        }

        /// <summary>
        /// Change the LastName
        /// </summary>
        /// <param name="newLastName">The new last name to be assigned</param>
        public void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }

        /// <summary>
        /// Change the GivenName
        /// </summary>
        /// <param name="newGivenNames">The new given names to be assigned</param>
        public void ChangeGivenNames(string[] newGivenNames)
        {
            if (VaildGivenNames(newGivenNames))
            {
                GivenNames = newGivenNames;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("newGivenNames", "newGivenNames must be between " + minGivenNames + " and" + maxGivenNames);
            }
        }

        /// <summary>
        /// Tests if given Names are vaild
        ///     -Checks for correct number of names (between 1 and 3)
        /// </summary>
        /// <param name="GivenNames">the names to check</param>
        /// <returns>True if the names are accepted, false if the names are not acceptable</returns>
        private Boolean VaildGivenNames(string[] testNames)
        {
            if (testNames.Length < minGivenNames || testNames.Length > maxGivenNames)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compare two names to find if they are equal, or to find which is smaller
        /// </summary>
        /// <param name="other">the name to be compared to</param>
        /// <returns>Less than Zero: this precedes other in the sort order,
        ///Zero: both Names are in the same postion, 
        ///greater then Zero: this follows other in sort order </returns>
        public int CompareTo(Name other)
        {
            int result;
            result = LastName.CompareTo(other.LastName); //Last Names

            if (result != 0) return result;

            int leng = Math.Min(GivenNames.Length, other.GivenNames.Length); //GivenNames
            for (int g = 0; g < leng; g++)
            {
                result = GivenNames[g].CompareTo(other.GivenNames[g]);
                if (result != 0) return result;
            }

            result = GivenNames.Length.CompareTo(other.GivenNames.Length); //Unequall number of GivenNames
            if (result != 0) return result;

            return result; //Same (baseCase)
        }

        /// <summary>
        /// Returns the name in string format
        /// </summary>
        /// <returns>Given names followed by LastName</returns>
        public override string ToString()
        {
            string name = "";
            foreach (string given in GivenNames)
            {
                name += given +' ';
            }
            return name + LastName;
        }
    }
}
