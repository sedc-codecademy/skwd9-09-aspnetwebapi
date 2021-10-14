using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class ValuesTest
    {
        private readonly ValuesService _valueService;

        public ValuesTest()
        {
            _valueService = new ValuesService();
        }

        [TestMethod]
        public void Sum_PositiveNumbers_ResultNumber() 
        {
            // Arrange
            int num1 = 5;
            int num2 = 10;
            int? expectedResult = 15;

            // Act
            var result = _valueService.Sum(num1, num2);

            // Assert ( Are Equal - Test will pass if values are equal )
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sum_LargPositiveNumbers_Null() 
        {
            // Arrange
            int num1 = 2111111111;
            int num2 = 2111111111;

            // Act
            var result = _valueService.Sum(num1, num2);

            // Assert ( IsNull - Test will pass if the result is null )
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsLarger_True() 
        {
            // Arrange
            int num1 = 255;
            int num2 = 10;


            // Act
            var result = _valueService.IsFirstLarger(num1, num2);

            // Assert ( IsTrue - Test will pass if the result is true )
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstLarger_SecondIsLarger_False()
        {
            // Arrange
            int num1 = 255;
            int num2 = 1110;

            // Act 
            var result = _valueService.IsFirstLarger(num1, num2);

            // Assert ( IsFalse - Test will pass if the result is true )
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetDigitName_SingleDigit_SingleDigitName() 
        {
            // Arrange
            int num = 5;
            string expectedResult = "Five";

            // Act
            var result = _valueService.GetDigitName(num);

            // Assert ( Are Equal - Test will pass if values are equal )
            Assert.AreEqual(expectedResult, result);
        }


        [ExpectedException(typeof(ArgumentOutOfRangeException))] // Assert
        [TestMethod]
        public void GetDigitName_DoubleDigit_ThrowsSystemException_Method1() 
        {
            // Arrange
            int num = 100;

            //Act 
            _valueService.GetDigitName(num);
        }

        [TestMethod]
        public void GetDigitName_DoubleDigit_ThrowsSystemException_Method2()
        {
            // Arrange
            int num = 100;

            // Act // Assert 
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _valueService.GetDigitName(num));
        }

    }
}
