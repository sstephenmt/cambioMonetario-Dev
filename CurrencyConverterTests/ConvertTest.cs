using System;
using CurrencyConverterForms;
using CurrencyConverterLibreria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTests
{

    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void ConversionBreadth()
        {
            decimal result;
            decimal amount;
            BaseCurrency fromCur;
            BaseCurrency toCur;

            amount = 100.0M;
            fromCur = new PENCurrency();
            toCur = new PENCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, ".....");
                       
        }


    }
}
