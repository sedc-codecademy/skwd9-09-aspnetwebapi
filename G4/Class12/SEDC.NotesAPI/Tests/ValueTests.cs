using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class ValueTests
    {
        private readonly ValueService _valueService;
        public ValueTests()
        {
            _valueService = new ValueService();
        }

        [TestMethod]
        public void Sum_PositiveIntegers_ResultNumber()
        {
            // Arrange
            int num1 = 5;
            int num2 = 10;
            int? expectedResult = 15;

            // Act
            int? result = _valueService.Sum(num1, num2);

            // Assert (Are equal - Test will pass if values are equal!)
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Sum_LargeNumberIntegers_Null()
        {
            // Arrange
            int num1 = 2147483646;
            int num2 = 999999999;

            // Act
            int? result = _valueService.Sum(num1, num2);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsLarger_True()
        {
            // Arrange
            int num1 = 100;
            int num2 = 2;

            // Act
            bool result = _valueService.IsFirstLarger(num1, num2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsNotLarger_False()
        {
            // Arrange
            int num1 = 2;
            int num2 = 200;

            // Act
            bool result = _valueService.IsFirstLarger(num1, num2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetDigitName_SingleDigit_SingleDigitName()
        {
            // Arrange
            int num = 7;
            string expectedResult = "Seven";

            // Act
            string result = _valueService.GetDigitName(num);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        // Expecting Exceptions

        // Expecting with attribute
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetDigitName_MultipleDigit_Exception()
        {
            // Arrange
            int num = 75;

            // Act
            string result = _valueService.GetDigitName(num);

            // Assert
            // Will pas if the method throws ArgumentOutOfRangeException
        }

        // Expecting with Assert
        [TestMethod]
        public void GetDigitName_MultipleDigit_Exception2()
        {
            // Arrange
            int num = -752;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _valueService.GetDigitName(num));
        }
    }
}
