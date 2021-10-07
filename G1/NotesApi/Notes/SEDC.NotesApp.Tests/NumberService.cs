using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SEDC.NotesApp.Tests
{

    // NumberService class that contains methods for unit testing
    public class NumberService
    {
        public int? Sum(int num1, int num2)
        {
            int result = num1 + num2;
            if (num1 > 0 && num2 > 0 && result < 0) 
                return null;

            return result;
        }

        public bool IsFirstLarger(int num1, int num2)
        {
            return num1 > num2;
        }

        public string GetDigitName(int num)
        {
            List<string> names = new List<string>
            {
                "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
            };
            return names[num];
        }
    }


    // Tests for our NumberService class
    [TestClass]
    public class NumberTests
    {
        private readonly NumberService _numberService;

        public NumberTests()
        {
            _numberService = new NumberService();
        }

        [TestMethod]
        public void Sum_PositiveIntegers_ResultNumber()
        {
            // Arrange
            int num1 = 5;
            int num2 = 10;
            int? expectedResult = 15;

            // Act
            int? result = _numberService.Sum(num1, num2);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Sum_LargeNumberIntegers_Null()
        {
            // Arrange
            int num1 = 2111111111;
            int num2 = 2111111111;

            // Act
            int? result = _numberService.Sum(num1, num2);

            // Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void IsFirstLarger_FirstIsNotLarger_False()
        {
            // Arrange
            int num1 = 125;
            int num2 = 126;

            // Act
            bool result = _numberService.IsFirstLarger(num1, num2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsLarger_True()
        {
            // Arrange
            int num1 = 199;
            int num2 = 190;

            // Act
            bool result = _numberService.IsFirstLarger(num1, num2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetDigitName_SingleDigit_SingleDigitName()
        {
            // Arrange
            int num = 7;
            string exptected = "Seven";

            // Act
            string result = _numberService.GetDigitName(num);

            // Assert
            Assert.AreEqual(exptected, result);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetDigitName_DoubleDigit_Exception_Method1()
        {
            // Arrange 
            int num = 12;

            // Act / Assert
            _numberService.GetDigitName(num);
        }

        [TestMethod]
        public void GetDigitName_DoubleDigit_Exception_Method2()
        {
            // Arrange
            int num = 12;

            //Act / Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _numberService.GetDigitName(num));
        }
    }
}
