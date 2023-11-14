using System.Reflection;
using Tasks;

namespace DayTests
{
    [TestClass]
    public class Day1Test
    {
        DayFactory _factory = new DayFactory();
        
        [TestMethod]
        public void CountFloor_Success()
        {
            // Arrange
            int expected = 5;
            string testString = "(((())))()()(()(()(()(()(()";
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountFloor_InputWithOtherChars()
        {
            // Arrange
            int expected = 5;
            string testString = "(((1 ()as)))(  g)()(f3g()(()(s(4)(()(()";
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountFloor_EmptyInput()
        {
            // Arrange
            int expected = 0;
            string testString = "";
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountToBasement_Success()
        {
            // Arrange
            int expected = 23;
            string testString = "((())((()))()(()))(()))(())((()";
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
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
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
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
            Day task = _factory.MakeDay("Day1");

            // Act
            // Access to private method
            int result = (int)typeof(Day1)
                .GetMethod("CountToBasement", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(task, new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}