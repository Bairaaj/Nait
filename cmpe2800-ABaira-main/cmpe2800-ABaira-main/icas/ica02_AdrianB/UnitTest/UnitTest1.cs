using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ica02_AdrianB;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
namespace UnitTest
{
    [TestClass]
    public class Grid
    {
        public Random _rng = new Random();
        [TestMethod]
        public void GridTest()
        {
            GridExt grid = null;
            //Test 1 - Negative value for grids
            Assert.ThrowsException<ArgumentException>(() =>
                grid = new GridExt((-3, -3))
            );
        }
        [TestMethod]
        public void GridOfZero()
        {
            GridExt grid = null;
            //Test 2 - have 0 values for grid
            Assert.ThrowsException<ArgumentException>(() =>
               grid = new GridExt((0, 0))
            );
        }
        [TestMethod]
        public void GridCursorOutOfBounds()
        {
            GridExt grid = null;
            //Test 3 - Set cursor out of bounds
            Assert.ThrowsException<ArgumentException>(() =>
            {
                grid = new GridExt((3, 3));
                grid.setCursor((5, 6));
            });
        }
        [TestMethod]
        public void GridCursorNegative()
        {
            GridExt grid = null;
            //Test 4 - set cursor to negative position
            Assert.ThrowsException<ArgumentException>(() =>
            {
                grid = new GridExt((3, 3));
                grid.setCursor((-5, -5));
            });
        }
        [TestMethod]
        public void GridOfOne()
        {
            //Test 5 - have a grid of 1 -> 2x2 
            /*  
             *  0   0
             *  0   0
             */
            GridExt gridtwo = new GridExt((1, 1));
            foreach ((int x, int y) z in gridtwo)
            {
                if (z.x != -1 || z.y != -1)
                    Trace.WriteLine($"({z.x}, {z.y})");
            }
        }
    }
    [TestClass]
    public class Shuffle
    {
        public Random _rng = new Random();
        [TestMethod]
        public void Shuffles()
        {
            //Test 1 - Shuffle random chars from a collection
            List<char> chars = new List<char>();
            for (int i = 0; i < 20; i++)
                chars.Add((char)_rng.Next('A', 'Z' + 1));

            foreach (char c in chars)
                Trace.Write($"{c},");

            Trace.WriteLine("");
            List<char> shuffled = new List<char>(chars);
            foreach (char c in shuffled.Shuffle())
                Trace.Write($"{c},");

            Assert.IsTrue(shuffled.SequenceEqual(chars));
        }
        [TestMethod]
        public void ShuffleEmpty()
        {
            //Test 2 - Empty list
            List<char> chars = new List<char>();
            Assert.ThrowsException<Exception>(() =>
            {
                Trace.WriteLine($"{chars.Shuffle().Count()}");
                Trace.WriteLine($"Threw Exception with trying to shuffle with 0 elements in list");
            });
        }
        [TestMethod]
        public void Shuffle_One()
        {
            //Test 3 - One element list
            List<char> chars = new List<char>();
            for (int i = 0; i < 1; i++)
                chars.Add((char)_rng.Next('A', 'Z' + 1));

            foreach (char c in chars)
                Trace.WriteLine(c);
            Trace.WriteLine("");
            chars.Clear();
            Assert.ThrowsException<Exception>(() =>
            {
                Trace.WriteLine($"{chars.Shuffle().Count()}");
                Trace.WriteLine($"Threw Exception with trying to shuffle with 0 elements in list");
            });
        }
    }
    [TestClass]
    public class Selection
    {
        public Random _rng = new Random();
        [TestMethod]
        public void SelectionTest()
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < 10000; i++)
                ints.Add(_rng.Next(1000));


            foreach (int i in ints.Selection(50))
                Trace.WriteLine($"{i}");

        }
        [TestMethod]
        public void Selection10_of_onlyDups()
        {
            List<int> ints = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            foreach (int i in ints.Selection(130))
                Trace.WriteLine($"{i}");

        }
        [TestMethod]
        public void Selection_EmptyList()
        {
            List<int> ints = new List<int>();
            foreach (int i in ints.Selection(2))
                Trace.WriteLine($"{i}");
        }
        [TestMethod]
        public void Selection_Negative()
        {
            List<int> ints = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            foreach (int i in ints.Selection(-130))
                Trace.WriteLine($"{i}");

        }

    }
    [TestClass]
    public class Sample
    {
        public Random _rng = new Random();
        [TestMethod]
        public void Sample10()
        {
            //Creating a big list for testing code
            List<int> listofint = new List<int>();
            for(int i = 0; i < 1000; i++)
                listofint.Add(_rng.Next(2000));

            //Test 1 - Grabing 10 random elements from a list
            Trace.WriteLine("Grab 10 elements from a list");
            foreach (int x in listofint.Sample().Take(10))
                Trace.WriteLine($"{x}");

        }
        [TestMethod]
        public void Sample_10_Values_From_Empty_List()
        {
            //Creating a big list for testing code
            List<int> listofint = new List<int>();
            for (int i = 0; i < 1000; i++)
                listofint.Add(_rng.Next(2000));

            //Test 2 - Grab 10 elements from a list that has nothing
            listofint.Clear();
            List<int> t = new List<int>();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                foreach (int x in listofint.Sample().Take(10))
                    t.Add(x);
            });
        }
        [TestMethod]
        public void Sample_Take_10_From_List_Of_One()
        {
            //Creating a big list for testing code
            List<int> listofint = new List<int>();
            for (int i = 0; i < 1000; i++)
                listofint.Add(_rng.Next(2000));

            //Test 3 - Grab 10 element from a list of 1
            Trace.WriteLine("Grab 10 elements from a list of 1");
            listofint.Clear();
            listofint.Add(34);
            foreach (int x in listofint.Sample().Take(10))
                Trace.WriteLine($"{x}");
        }
    }
}
