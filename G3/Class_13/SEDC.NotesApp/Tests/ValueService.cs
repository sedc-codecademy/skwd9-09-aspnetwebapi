using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ValueService
    {
        public int Sum(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        public bool IsFirstLarger(int num1, int num2)
        {
            return num1 > num2;
        }

        public string GetDigitName(int num)
        {
            List<string> numInString = new List<string>()
            {
                "Zero",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine"
            };
            return numInString[num];
        }
    }

    [TestClass]
    public class ValuesTests
    {
        private readonly ValueService _valueService;
        public ValuesTests()
        {
            _valueService = new ValueService();
        }

        [TestMethod]
        public void Sum_PositiveIntegers_ResultNumber()
        {
            //Arrange
            int num1 = 7;
            int num2 = 10;
            int expectedResult = 17;

            // Act
            int result = _valueService.Sum(num1, num2);

            // Assert (Are Equal - Test will pass if values are equal)
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void IsFirstLarger_PositiveIntegers_True()
        {
            //Arrange
            int num1 = 100;
            int num2 = 99;

            //Act
            bool result = _valueService.IsFirstLarger(num1, num2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsNotLarger_False()
        {
            // Arrange
            int num1 = 100;
            int num2 = 101;

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

            // act

            string result = _valueService.GetDigitName(num);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetDigitName_DoubleDigit_Exception()
        {
            int num = 20;
            // Act/Assert
            _valueService.GetDigitName(num);
        }
    }
}
