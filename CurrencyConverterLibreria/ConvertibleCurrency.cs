using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterLibreria;

namespace CurrencyConverterLibreria
{
    public abstract class BaseCurrency
    {
        public abstract decimal InUS
        {
            get;
        }
    }

    public class USCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 1; }
        }

        public override string ToString()
        {
            return "US$";
        }
    }

    public class UKCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 0.5M; }
        }

        public override string ToString()
        {
            return "UK£";
        }
    }

    public class AUSCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 2; }
        }

        public override string ToString()
        {
            return "AU$";
        }
    }

    public class ConvertibleCurrency
    {
        private decimal amount;
        private BaseCurrency currency;

        public static decimal CurrencyConvert(decimal amount, BaseCurrency fromCur,
                  BaseCurrency toCur)
        {
            decimal converted = 0.0M;
            ConvertibleCurrency currency = new ConvertibleCurrency(fromCur, amount);
            converted = currency.ConvertTo(toCur);
            return converted;
        }

        public ConvertibleCurrency(BaseCurrency type, decimal val)
        {
            currency = type;
            amount = val;
        }

        public decimal ConvertTo(BaseCurrency type)
        {
            decimal converted = ConvertToUS();
            converted = ConvertFromUS(type, converted);
            return converted;
        }

        private decimal ConvertToUS()
        {
            decimal converted = 0.0M;
            converted = amount / currency.InUS;
            return converted;
        }

        private decimal ConvertFromUS(BaseCurrency type, decimal USAmount)
        {
            decimal converted = 0.0M;
            converted = USAmount * type.InUS;
            return converted;
        }
    }
}
