namespace WorkerTeam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int team_count;

            Console.WriteLine("How much teams do you want to create?");
            while (!int.TryParse(Console.ReadLine(), out team_count) || team_count<=0)
            {
                Console.WriteLine("Please enter a number > 0");
            }

            for (int i = 0; i < team_count; i++)
            {
                Console.WriteLine($"Enter name of the team #{i + 1}: ");
                string teamName = Console.ReadLine();

                if (int.TryParse(teamName, out _))
                { 
                    Console.WriteLine("Team name cannot be a number!");
                    i--;
                    continue;
                }

                Team team = new Team(teamName);
                int num_workers;

                Console.WriteLine($"How many employees are in the {teamName} team? ");

                while (!int.TryParse(Console.ReadLine(), out num_workers) || num_workers <= 0) 
                {
                    Console.WriteLine("Please enter a number > 0 again");
                }

                for (int j = 0; j < num_workers; j++)
                {
                    Console.WriteLine($"Enter name of the worker #{j + 1}: ");
                    string nameWorker = Console.ReadLine();

                    if (int.TryParse(nameWorker, out _))
                    {
                        Console.WriteLine("Name of worker cannot be a number!");
                        j--;
                        continue;
                    }
                    
                    int type;
                    Console.Write("Choose 1 if he/she is developer and 2 if he/she is manager: ");

                    while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2))
                    {
                        Console.WriteLine("Enter 1 or 2!");
                    }

                    Worker worker;

                    if (type == 1)
                    {
                        worker = new Developer(nameWorker);
                    }
                    else if (type == 2)
                    {
                        worker = new Manager(nameWorker);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data");
                        continue;
                    }

                    worker.FillWorkDay();
                    team.Addworker(worker);

                }
                teams.Add(team);

            }
            Console.WriteLine("\nDetailed information about teams\n");
            foreach (var team in teams)
            {
                team.PrintDetailedInfo();
            }
            Console.WriteLine("\nThe workday is finished\n");
            Console.ReadKey();
        }
    }
}
