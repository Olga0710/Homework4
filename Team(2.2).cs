using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerTeam
{
    public class Team
    {
        public string _teamName { get; set; }
        private List<Worker> workers;
        public Team(string name)
        {
            _teamName = name;
            workers = new List<Worker>();
        }

        public void Addworker(Worker worker)
        {
            workers.Add(worker);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name of team: {_teamName}");
            Console.WriteLine("Workers: ");
            foreach (var worker in workers)
            {
                Console.WriteLine(worker._name);
            }
        }

        public void PrintDetailedInfo()
        {
            Console.WriteLine($"Name of team: {_teamName}");
            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker._name} - {worker._position} - {worker._workday}");
            }

        }

    }
}
