using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tasks.Days;

namespace DayTests
{
    [TestClass]
    public class Day2Test
    {
        DayFactory _factory = new DayFactory();

        [TestMethod]
        public void ExtractInfo_Success()
        {
            // Arrange
            (int Length, int Width, int Height) expected = (20, 3, 11);
            string testString = "20x3x11";
            Day task = _factory.MakeDay("Day2");


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
            Day task = _factory.MakeDay("Day2");

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
                    if (ex.InnerException is ArgumentException)
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
            Day task = _factory.MakeDay("Day2");

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
                    if (ex.InnerException is ArgumentException)
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
            (int Length, int Width, int Height) measurement = (Length: 2, Width: 3, Height: 4);
            int expected = 52;
            Day task = _factory.MakeDay("Day2");

            // Act
            // Access to private method
            int result = (int)typeof(Day2)
                .GetMethod("CalculateSurface", BindingFlags.NonPublic | BindingFlags.Instance)
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
            Day task = _factory.MakeDay("Day2");

            // Act
            // Access to private method
            int result = (int)typeof(Day2)
                .GetMethod("FindSmallestArea", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { measurement });

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
