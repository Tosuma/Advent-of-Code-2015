using System.Reflection;
using Tasks;

namespace DayTests
{
    [TestClass]
    public class Day1Test
    {
        DayFactory _factory = new DayFactory();
        [TestMethod]
        public void OpenFile_Success()
        {
            // Arrange
            string expected = "Test file for unit test";
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/DayTests/Test Files/Day1TestFile.txt";
            IDay task = _factory.MakeDay("Day1");
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
            IDay task = _factory.MakeDay("Day1");
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
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/DayTests/Test Files/NoFileHere.txt";
            IDay task = _factory.MakeDay("Day1");
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

        [TestMethod]
        public void CountFloor_Success()
        {
            // Arrange
            int expected = 5;
            string testString = "(((())))()()(()(()(()(()(()";
            IDay task = _factory.MakeDay("Day1");

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
            IDay task = _factory.MakeDay("Day1");

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
            IDay task = _factory.MakeDay("Day1");

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
            IDay task = _factory.MakeDay("Day1");

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
            IDay task = _factory.MakeDay("Day1");

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
            IDay task = _factory.MakeDay("Day1");

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