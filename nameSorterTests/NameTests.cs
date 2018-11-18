using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NameSorter;

namespace nameSorterTests
{
    [TestClass]
    public class NameTests
    {
        /// <summary>
        /// Basic test case (vaild constructors)
        /// </summary>
        [TestMethod]
        public void BaseTest()
        {
            Name testName = new Name("test", new string[] { "tests" });
            testName = new Name("test", new string[] { "tests", "tests" });
            testName = new Name("test", new string[] { "tests","tests","tests" });
        }

        /// <summary>
        /// testing converting from string to name
        /// </summary>
        [TestMethod]
        public void ImportStringTest()
        {
            Name testName = new Name("given1 lastName");
            Assert.AreEqual(testName.GivenNames[0], "given1", "given1 incorrect");
            Assert.AreEqual(testName.LastName, "lastName", "Last Name incorrect");
        }

        /// <summary>
        /// extra testing converting from string to name
        /// </summary>
        [TestMethod]
        public void ImportStringTest2()
        {
            Name testName = new Name("given1 given2 given3 lastName");
            Assert.AreEqual(testName.GivenNames[0], "given1", "given1 incorrect");
            Assert.AreEqual(testName.GivenNames[1], "given2", "given2 incorrect");
            Assert.AreEqual(testName.GivenNames[2], "given3", "given3 incorrect");
            Assert.AreEqual(testName.LastName, "lastName", "Last Name incorrect");
        }


        /// <summary>
        /// test case for too many givenNames Provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenNameLenghtOver()
        {
            Name testName = new Name("test", new string[] { "tests", "test", "test", "test" });
        }

        /// <summary>
        /// test case for not enough givenNames Provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenNameLenghtUnder()
        {
            Name testName = new Name("test", new string[] { });
        }

        /// <summary>
        /// test case checking that correct LastName is returned
        /// </summary>
        [TestMethod]
        public void GetLastName()
        {
            string lastName = "lastName";
            Name testName = new Name(lastName, new string[] { "tests", "tests" });
            Assert.AreEqual(testName.LastName, lastName,"Last Name incorrect");
        }

        /// <summary>
        /// test case checking that correct GivenNames are returned
        /// </summary>
        [TestMethod]
        public void GetGivenNames()
        {
            string[] givenNames = { "given0", "given1", "given2" };
            Name testName = new Name("lastName", givenNames);
            CollectionAssert.AreEqual(testName.GivenNames, givenNames, "Given Names don't Match");
        }

        /// <summary>
        /// test case checking that changeLastName correctly updates nameLast
        /// </summary>
        [TestMethod]
        public void ChangeLastName()
        {
            string lastName = "lastName";
            string lastNameUpdated = "newlastName";
            Name testName = new Name(lastName, new string[] { "tests", "tests" });
            testName.ChangeLastName(lastNameUpdated);
            Assert.AreEqual(testName.LastName, lastNameUpdated, "Updated Last Name incorrect");
        }

        /// <summary>
        /// test case checking that changeGivenNames correctly updates givenNames
        /// </summary>
        [TestMethod]
        public void ChangeGivenName()
        {
            string[] givenNames = { "given0", "given1", "given2" };
            string[] givenNamesUpdated = { "change0", "Change1" };
            Name testName = new Name("lastName", givenNames);
            testName.ChangeGivenNames(givenNames);
            CollectionAssert.AreEqual(testName.GivenNames, givenNames, "Updated Given Names don't Match");
        }

        /// <summary>
        /// In order to sort names an Icompare is required, testing equall names
        /// </summary>
        [TestMethod]
        public void CompareEquallNames()
        {
            Name testName = new Name("test", new string[] { "tests", "tests" });
            Name otherTestName = new Name("test", new string[] { "tests", "tests" });
            Assert.IsTrue(testName.CompareTo(otherTestName) == 0 );
         
        } 

        /// <summary>
        /// In order to sort names an Icompare is required, testing not equall names
        /// </summary>
        [TestMethod]
        public void CompareNotEquallNames()
        {
            Name testName = new Name("test", new string[] { "tests", "tests" });
            Name otherTestName = new Name("newTest", new string[] { "tests", "tests" });
            Assert.IsTrue(testName.CompareTo(otherTestName) > 0,"Failed LastName");

            otherTestName = new Name("test", new string[] { "aName", "tests" });
            Assert.IsFalse(testName.CompareTo(otherTestName) < 0, "Failed GivenNames");

            otherTestName = new Name("test", new string[] { "tests", "tests", "test" });
            Assert.IsFalse(testName.CompareTo(otherTestName) > 0, "Failed GivenName lenght");
        }

        /// <summary>
        /// Testing Compare by sorting a list of values
        /// </summary>
        [TestMethod]
        public void SortList()
        {
            List<Name> nameList = new List<Name>();
            nameList.Add(new Name("Parson", new string[] { "Janet" }));
            nameList.Add(new Name("Alvarez", new string[] { "Marin" }));
            nameList.Add(new Name("Ritter", new string[] { "Frankie", "Conner" }));
            nameList.Add(new Name("Ritter", new string[] { "Frankie", "Alivn" }));
            nameList.Sort();

            Assert.AreEqual("Alvarez",nameList[0].LastName);
            Assert.AreEqual("Parson", nameList[1].LastName );
            Assert.AreEqual("Conner", nameList[3].GivenNames[1]);
        }

        /// <summary>
        /// Testing ToString functionality 
        /// </summary>
        [TestMethod]
        public void ToStringTest() {

            Name testName =  new Name("Ritter", new string[] { "Frankie", "Alivn" });
            Assert.AreEqual(testName.ToString(), "Frankie Alivn Ritter");
        }

    }
}
