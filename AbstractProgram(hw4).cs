namespace GeographyAbstract
{
    internal class AbstractProgram
    {
        static void Main(string[] args)
        {
            River river = new River(48.45, 35.05, "Dnipro", "The largest river in Ukraine", 100, 2201);
            Mountain mountain = new Mountain(48.09, 24.30, "Goverla", "The highest peak of the Ukrainian Carpathians", 2061);

            Console.WriteLine("===RIVER===");
            river.Get_info();
            Console.WriteLine("===MOUNTAIN===");
            mountain.Get_info();

        }
    }
}
