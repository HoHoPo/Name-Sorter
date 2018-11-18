using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NameSorter;

namespace nameSorterTests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void BaseTest()
        {
            Name names = new Name("test", new string[] { "tests" });

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenNameLenghtOverTest()
        {
            Name names = new Name("test", new string[] { "tests", "test", "test", "test" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenNameLenghtUnderTest()
        {
            Name names = new Name("test", new string[] { });
        }
    }
}
