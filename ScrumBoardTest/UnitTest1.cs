using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumBoardLib.model;

namespace ScrumBoardTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
         *  Set up UserStory class to be testet
         */
        private UserStory us = null;

        [TestInitialize]
        public void BeforeEachTestMethod()
        {
            us = new UserStory();

        }


        /*
         * Testing property Title - At least 4 chars
         */
        
        // acceptable values 3 chars and 10 char
        [TestMethod]
        [DataRow ("123")]
        [DataRow ("1234567890")]
        public void TestTitleAccept(String title)
        {
            // Arrange
            String expectedValue = title;

            // Act
            us.Title = title;
            String actualValue = us.Title;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        // Error values 2 chars  
        [TestMethod]
        [DataRow("12")]
        public void TestTitleNotAccept1(String title)
        {
            // Arrange - all in assert
            
            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.Title = title);

        }


        // Error values null and 10 spaces -> empty 
        [TestMethod]
        [DataRow(null)]
        [DataRow("          ")]
        public void TestTitleNotAccept2(String title)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => us.Title = title);

        }





        /*
         * Testing property Description - at least 10 chars
         */

        // acceptable values 10 chars and 15 chars
        [TestMethod]
        [DataRow("1234567890")]
        [DataRow("123456789012345")]
        public void TestDescriptionAccept(String desc)
        {
            // Arrange
            String expectedValue = desc;

            // Act
            us.Description = desc;
            String actualValue = us.Description;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        // Error values 9 chars  
        [TestMethod]
        [DataRow("123456789")]
        public void TestDewscriptionNotAccept1(String desc)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.Description = desc);

        }

        // Error values null and 10 spaces -> empty 
        [TestMethod]
        [DataRow(null)]
        [DataRow("          ")]
        public void TestDescriptionNotAccept2(String desc)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => us.Description = desc);

        }



        /*
         * Testing property StoryPoints - not negative 
         */

        // acceptable values 0 and 5
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        public void TestStoryPointAccept(int sp)
        {
            // Arrange
            int expectedValue = sp;

            // Act
            us.StoryPoints = sp;
            int actualValue = us.StoryPoints;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        // Error values -1 and -1000  
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-1000)]
        public void TestStoryPointNotAccept(int sp)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.StoryPoints = sp);

        }



        /*
         * Testing property BusinessValue - between 0-10
         */

        // acceptable values 0 and 5 and 10
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(10)]
        public void TestBusinessValueAccept(int bv)
        {
            // Arrange
            int expectedValue = bv;

            // Act
            us.BusinessValue = bv;
            int actualValue = us.BusinessValue;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        // Error values -1 and 11  
        [TestMethod]
        [DataRow(-1)]
        [DataRow(11)]
        public void TestBusinessValueNotAccept(int bv)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.BusinessValue = bv);

        }




        /*
         * Testing constructor all 4 properties
         */

        // Error Title  
        [TestMethod]
        public void TestConstructor1()
        {
            // Arrange - all in assert
            // Act - all in assert
            // Assert
            Assert.ThrowsException<ArgumentException>(() => us = new UserStory(1,"12", "1234567890"));
        }

        // Error Description
        [TestMethod]
        public void TestConstructor2()
        {
            // Arrange - all in assert
            // Act - all in assert
            // Assert
            Assert.ThrowsException<ArgumentException>(() => us = new UserStory(1,"12345", "123456789"));
        }


    }
}
