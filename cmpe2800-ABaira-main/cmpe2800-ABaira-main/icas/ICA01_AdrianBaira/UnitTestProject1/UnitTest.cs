using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ICA01_AdrianBaira;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CategorizeTest()
        {

        }
        [TestMethod]
        public void TheOddsTest()
        {
            //Values
            List<int> ints = new List<int>() {0,1,2,3,4,5,6,7,8,9};
            List<int> output = new List<int>() {9,7,5,3,1};
            CollectionAssert.AreEqual(output, ints.TheOdds().ToList());

            //two values
            ints = new List<int>() { 0, 1};
            output = new List<int>() { 1 };
            CollectionAssert.AreEqual(output, ints.TheOdds().ToList());

            //Empty list
            ints = new List<int>();
            Assert.AreEqual(0,ints.TheOdds().ToList().Count);
        }

        [TestMethod]
        public void SinglesTest()
        {
            List<string> input = new List<string> { "John", "James", "Simon", "John"};
            List<string> output = new List<string> { "James", "Simon "};

            Assert.AreEqual(input.Singles(), output);
        }
        [TestMethod]
        public void RandoDicTest()
        {
            (int, int) ete = (1, 34);
        }
        [TestMethod]
        public void FirstDupTest()
        {
            //Duplicates
            List<string> input = new List<string> { "John", "James", "Simon", "John" };
            Assert.AreEqual("John", input.FirstDup());

            //Empty List
            input = new List<string>();
            Assert.AreEqual(null, input.FirstDup());

            //No duplicates
            input = new List<string> { "John", "James", "Simon" };
            Assert.AreEqual(null, input.FirstDup());

            //Multiple Duplicates
            input = new List<string> { "John", "James", "Simon", "Gary", "James", "Gary", "Gary"};
            Assert.AreEqual("James", input.FirstDup());


        }
        
    }
}
