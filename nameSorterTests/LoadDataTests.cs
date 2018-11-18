using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NameSorter;

namespace nameSorterTests
{
    [TestClass]
    public class LoadDataTests
    {
        private readonly string[] vaildPaths = { "test.txt" };
        private readonly string invaildPath = "notFile.txt";

        [TestMethod]
        public void BaseTest()
        {
            string[] names = NameSorter.DataAccessor.LoadNameList(vaildPaths[0]);
            CollectionAssert.AreEqual(new string[0], names);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void InvaildPathTest()
        {
            string[] names = NameSorter.DataAccessor.LoadNameList(invaildPath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
           string[] names = NameSorter.DataAccessor.LoadNameList(null);
        }
    }
}
