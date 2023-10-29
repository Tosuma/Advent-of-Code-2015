using Day_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day1Test
{
    [TestClass]
    public class UnitTestTask2
    {
        [TestMethod]
        public void CountToBasement_Success()
        {
            // Arrange
            int expected = 23;
            string testString = "((())((()))()(()))(()))(())((()";
            Day1 task = new Day1("No need for the path");
            
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Day1)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountToBasement_InputWithOtherChars()
        {
            // Arrange
            int expected = 23;
            string testString = "((a( s))(1323((asd) sa))()(fdg()))(ga())) (())((()";
            Day1 task = new Day1("No need for the path");

            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Day1)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountToBasement_EmptyInput()
        {
            // Arrange
            int expected = 0;
            string testString = "";
            Day1 task = new Day1("No need for the path");

            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Day1)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
