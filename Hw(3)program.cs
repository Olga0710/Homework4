namespace CurrencyConvert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal usdRate = 41.95m;
            decimal eurRate = 49.1m;

            Convert convert = new Convert(usdRate, eurRate);

            Console.WriteLine("How many UAH do you want to convert?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amountUAH))
            {
                Console.WriteLine("Incorrect format of number");
                return;
            }
            decimal convertedUSD = convert.uahTousd(amountUAH);
            decimal convertedEUR = convert.uahToeur(amountUAH);
            Console.WriteLine($"{amountUAH:F2} UAH = {convertedUSD:F2} USD");
            Console.WriteLine($"{amountUAH:F2} UAH = {convertedEUR:F2} EUR");

            Console.WriteLine("How many USD do you want to convert?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amountUSD))
            {
                Console.WriteLine("Incorrect format of number");
                return;
            }
            decimal convertedUAH1 = convert.usdTouah(amountUSD);
            Console.WriteLine($"{amountUSD:F2} USD = {convertedUAH1:F2} UAH");

            Console.WriteLine("How many EUR do you want to convert?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amountEUR))
            {
                Console.WriteLine("Incorrect format of number");
                return;
            }
            decimal convertedUAH2 = convert.usdTouah(amountEUR);
            Console.WriteLine($"{amountEUR:F2} EUR = {convertedUAH2:F2} UAH");

        }
    }
}
