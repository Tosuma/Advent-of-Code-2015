using Day_1;
using System.Reflection;

namespace Day1Test
{
    [TestClass]
    public class UnitTestTask1
    {
        [TestMethod]
        public void OpenFile_Success()
        {
            // Arrange
            string expected = "Test file for unit test";
            string filePath = "C:/Coding-Git/Advent-of-Code-2015/Day1Test/testFile.txt";
            // Act
            // Access to private method
            string result = (string) typeof(Day_1.Task)
                .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { filePath });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OpenFile_FailureGivenEmptyString()
        {
            // Arrange
            String filePath = "";
            Day_1.Task task = new Day_1.Task();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                try
                {
                    typeof(Day_1.Task)
                        .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { filePath });
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
            String filePath = "C:/Coding-Git/Advent-of-Code-2015/Day1Test/NoFileHere.txt";
            Day_1.Task task = new Day_1.Task();

            // Act and Assert
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                try
                {
                    typeof(Day_1.Task)
                        .GetMethod("OpenFile", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(task, new object[] { filePath });
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
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountFloor_InputWithOtherChars()
        {
            // Arrange
            int expected = 5;
            string testString = "(((1 ()as)))(  g)()(f3g()(()(s(4)(()(()";
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountFloor_EmptyInput()
        {
            // Arrange
            int expected = 0;
            string testString = "";
            // Act
            // Access to private method
            int result = (int)typeof(Day_1.Task)
                .GetMethod("CountFloor", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new Day_1.Task(), new object[] { testString });

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}