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
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountToBasement_InputWithOtherChars()
        {
            // Arrange
            int expected = 23;
            string testString = "((a( s))(1323((asd) sa))()(fdg()))(ga())) (())((()";
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountToBasement_EmptyInput()
        {
            // Arrange
            int expected = 0;
            string testString = "";
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
