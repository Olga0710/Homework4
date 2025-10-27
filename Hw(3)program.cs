namespace CurrencyConvert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the exchange rate for 1 EUR to UAH: ");
            decimal euroRate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the exchange rate for 1 USD to UAH: ");
            decimal dollarRate = decimal.Parse(Console.ReadLine());

            Converter converter = new Converter(euroRate, dollarRate);
            converter.Convert();
        }
    }
}
