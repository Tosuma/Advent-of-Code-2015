using System;
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
            string expected = "Test file for unit test";
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/Day1Test/Day2TestFile.txt";
            IDay task = _factory.MakeDay("Day2");
            task.SetFilePath(filePath);

            // Act
            // Access to private method
            string result = (string)typeof(Day1)
                .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { });

            // Assert
            Assert.AreEqual(expected, result);
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
                    typeof(Day1)
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
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/Day1Test/NoFileHere.txt";
            IDay task = _factory.MakeDay("Day2");
            task.SetFilePath(filePath);

            // Act and Assert
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                try
                {
                    typeof(Day1)
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
    }
}
