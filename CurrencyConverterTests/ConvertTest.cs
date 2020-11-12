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
            fromCur = new USCurrency();
            toCur = new USCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "US to US should be no change");

            fromCur = new UKCurrency();
            toCur = new UKCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "UK to UK should be no change");

            fromCur = new AUSCurrency();
            toCur = new AUSCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "AUS to AUS should be no change");

            decimal expected;
            fromCur = new USCurrency();
            toCur = new AUSCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount * 2;
            Assert.AreEqual(expected, result, "US to AUS is incorrect");

            fromCur = new UKCurrency();
            toCur = new AUSCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount / 0.5M * 2;
            Assert.AreEqual(expected, result,
            "UK to AUS is incorrect");
        }

        [TestMethod]
        public void ConvertTo()
        {
            ConvertibleCurrency currency;
            decimal result;
            decimal expected;

            currency = new ConvertibleCurrency(new USCurrency(), 100.0M);
            result = currency.ConvertTo(new USCurrency());
            Assert.AreEqual(100.0M, result, "US to US should be no change");

            currency = new ConvertibleCurrency(new AUSCurrency(), 100.0M);
            result = currency.ConvertTo(new UKCurrency());
            expected = 100.0M / 2 * 0.5M;
            Assert.AreEqual(expected, result, "AUS to UK incorrect result");
        }

    }
}
