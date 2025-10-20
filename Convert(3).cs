using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvert
{
    internal class Convert
    {
        private decimal usdToUahRate;
        private decimal eurToUahRate;

        public Convert(decimal usdRate, decimal eurRate)
        {
            this.usdToUahRate = usdRate;
            this.eurToUahRate = eurRate;
        }

        public decimal uahTousd(decimal uahAmount)
        {
           return uahAmount / usdToUahRate;
        }

        public decimal uahToeur(decimal uahAmount)
        {
            return uahAmount / eurToUahRate;
        }
        public decimal usdTouah(decimal usdAmount)
        {
            return usdAmount * usdToUahRate;
        }
        public decimal eurTouah(decimal eurAmount)
        {
            return eurAmount * eurToUahRate;
        }
    }
}
