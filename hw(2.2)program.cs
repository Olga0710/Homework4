namespace WorkerTeam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            Console.WriteLine("How much  teams do you want to create?");
            int team_count = int.Parse(Console.ReadLine());

            for (int i = 0; i < team_count; i++)
            {
                Console.WriteLine($"Enter name of the team #{i + 1}: ");
                string teamName = Console.ReadLine(); 

                Team team = new Team(teamName);

                Console.Write($"How many employees are in the {teamName} team? ");
                int num_workers = int.Parse(Console.ReadLine()); 

                for (int j = 0; j < num_workers; j++)
                {
                    Console.WriteLine($"Enter name of the worker #{j + 1}: ");
                    string nameWorker = Console.ReadLine();
                    Console.Write("Choose 1 if he/she is developer and 2 if he/she is manager: ");
                    int type = int.Parse(Console.ReadLine());

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

                    worker.Fill_work_day();
                    team.Addworker(worker);

                }
                teams.Add(team);

            }
            Console.WriteLine("\nDetailed information about teams\n");
            foreach (var team in teams)
            {
                team.Print_detailed_info();
            }
            Console.WriteLine("\nThe workday is finished\n");
            Console.ReadKey();
        }
    }
}
