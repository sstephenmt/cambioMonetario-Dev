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
            return "USD";
        }
    }

    public class PENCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 3.62M; }
        }

        public override string ToString()
        {
            return "PEN";
        }
    }

    public class EURCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 0.85M; }
        }

        public override string ToString()
        {
            return "EUR";
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
