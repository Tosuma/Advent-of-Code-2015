﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tasks;

namespace DayTests
{
    [TestClass]
    public class Day2Test
    {
        DayFactory _factory = new DayFactory();
        [TestMethod]
        public void OpenFile_Success()
        {
            // Arrange
            string[] expected = {"20x3x11", "15x27x5", "6x29x7", "30x15x9", "19x29x21"};
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/DayTests/Test Files/Day2TestFile.txt";
            IDay task = _factory.MakeDay("Day2");
            task.SetFilePath(filePath);

            
            // Act
            // Access to private method
            string[] result = (string[])typeof(Day2)
                .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { });

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OpenFile_FailureGivenEmptyString()
        {
            // Arrange
            string filePath = "";
            IDay task = _factory.MakeDay("Day2");
            task.SetFilePath(filePath);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                try
                {
                    typeof(Day2)
                        .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { });
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is ArgumentException)
                    {
                        throw ex.InnerException;
                    }
                    throw;
                }
            });

        }

        [TestMethod]
        public void OpenFile_FailureGivenFile()
        {
            // Arrange
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/DayTests/Test Files/NoFileHere.txt";
            IDay task = _factory.MakeDay("Day2");
            task.SetFilePath(filePath);

            // Act and Assert
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                try
                {
                    typeof(Day2)
                        .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { });
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is FileNotFoundException)
                    {
                        throw ex.InnerException;
                    }
                    throw;
                }
            });
        }

        [TestMethod]
        public void ExtractInfo_Success()
        {
            // Arrange
            (int Length, int Width, int Height) expected = (20, 3, 11);
            string testString = "20x3x11";
            IDay task = _factory.MakeDay("Day2");


            // Act
            // Access to private method
            (int Length, int Width, int Height) result = ((int Length, int Width, int Height))typeof(Day2)
                .GetMethod("ExtractInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString  });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtractInfo_InputWithOtherChars()
        {
            // Arrange
            string testString = "()20xs3x(11sf";
            IDay task = _factory.MakeDay("Day2");

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                try
                {
                    typeof(Day2)
                        .GetMethod("ExtractInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { testString });
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is FileNotFoundException)
                    {
                        throw ex.InnerException;
                    }
                    throw;
                }
            });
        }

        [TestMethod]
        public void ExtractInfo_EmptyInput()
        {
            // Arrange
            string testString = "";
            IDay task = _factory.MakeDay("Day2");

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                try
                {
                    typeof(Day2)
                        .GetMethod("ExtractInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { testString });
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is FileNotFoundException)
                    {
                        throw ex.InnerException;
                    }
                    throw;
                }
            });
        }

        [TestMethod]
        public void CalculateSurface_Success()
        {
            // Arrange
            (int Length, int Width, int Height) measurement = (2, 3, 4);
            int expected = 52;
            IDay task = _factory.MakeDay("Day2");

            // Act
            // Access to private method
            int result = (int)typeof(Day2)
                .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { measurement });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindSmallestArea_Success()
        {
            // Arrange
            (int Length, int Width, int Height) measurement = (2, 3, 4);
            int expected = 6;
            IDay task = _factory.MakeDay("Day2");

            // Act
            // Access to private method
            int result = (int)typeof(Day2)
                .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { measurement });

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
