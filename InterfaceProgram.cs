namespace GeographyInterface
{
    internal class InterfaceProgram
    {
        static void Main(string[] args)
        {
            River river = new River(47.0, 31.98, "Southern Bug", "Flows through central Ukraine", 90,806);
            Mountain mountain = new Mountain(44.77, 34.4, "Roman-Kosh", "The highest peak of the Crimean Mountains", 1545); 

            Console.WriteLine("===RIVER===");
            river.GetInfo();
            Console.WriteLine("===MOUNTAIN===");
            mountain.GetInfo();
        }
    }
}

