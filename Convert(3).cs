using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvert
{
    internal class Converter
    {
        private decimal usdToUahRate;
        private decimal eurToUahRate;

        public Converter(decimal usdRate, decimal eurRate)
        {
            this.usdToUahRate = usdRate;
            this.eurToUahRate = eurRate;
        }

        private void ConvertFromDollar()
        {
            Console.WriteLine("How many dollars do you want to convert?");
            decimal totalDollars;
            while (!decimal.TryParse(Console.ReadLine(), out totalDollars) || totalDollars<=0)
            {
                Console.WriteLine("Please enter a number > 0");
            }
            decimal convertedDollars = totalDollars * usdToUahRate;
            Console.WriteLine($"{totalDollars:F2} USD = {convertedDollars:F2} UAH");
        }
        private void ConvertFromEuro()
        {
            Console.WriteLine("How many euros do you want to convert?");
            decimal totalEuros;
            while (!decimal.TryParse(Console.ReadLine(), out totalEuros) || totalEuros <= 0)
            {
                Console.WriteLine("Please enter a number > 0");
            }
            decimal convertedEuros = totalEuros * usdToUahRate;
            Console.WriteLine($"{totalEuros:F2} EUR = {convertedEuros:F2} UAH");
        }

        private void ConvertFromHryvnia()
        {
            Console.WriteLine("How many hryvnias do you want to convert?");
            decimal totalHryvnia;
            while (!decimal.TryParse(Console.ReadLine(), out totalHryvnia) || totalHryvnia <= 0)
            {
                Console.WriteLine("Please enter a number > 0");
            }
            Console.Write("What currency do you want to get (Euro/Dollar)? ");
            string currency = Console.ReadLine();

            if (currency == "Euro" || currency == "euro")
            {
                decimal convertedHryvnias = totalHryvnia / eurToUahRate;
                Console.WriteLine($"{totalHryvnia:F2} UAH = {convertedHryvnias:F2} EUR");
            }
            else if (currency == "Dollar" || currency == "dollar")
            {
                decimal convertedHryvnias = totalHryvnia / usdToUahRate;
                Console.WriteLine($"{totalHryvnia:F2} UAH = {convertedHryvnias:F2} USD");
            }
            else
            {
                Console.WriteLine("Unknown currency type!");
            }

        }
         public void Convert()
        {
            Console.Write("What currency do you have (Hryvnia/Dollar/Euro)? ");
            string type = Console.ReadLine();

            if (type =="Hryvnia"||type =="hryvnia")
            {
                ConvertFromHryvnia();
            }
            else if (type == "Dollar" || type == "dollar")
            {
                ConvertFromDollar();
            }
            else if (type == "Euro" || type == "euro")
            {
                ConvertFromEuro();
            }
            else
            {
                Console.WriteLine("Unknown currency type!");
            }
        }
    }
}
