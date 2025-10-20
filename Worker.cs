using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerTeam
{
    public abstract class Worker
    {
        public string _name { get; set; }
        public string _position { get; set; }
        public string _workday { get; set; }
        public Worker(string name)
        {
            _name = name;
        }
        public void Call()
        {
            _workday += "Call, ";
        }
        public void Write_code()
        {
            _workday += "Write code, ";
        }
        public void Relax()
        {
            _workday += "Relax, ";
        }
        public abstract void Fill_work_day();

    }
    class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            _position = "Developer";
        }
        public override void Fill_work_day()
        {            
            Write_code();
            Call();
            Relax();
            Write_code();
        }
    }

    class Manager : Worker
    {
        public Manager(string name) : base(name)
        {
            _position = "Manager";
        }

        private Random random = new Random();

        public override void Fill_work_day()
        {
            int calls1 = random.Next(1, 11);
            for (int i = 0; i < calls1; i++)
            {
                Call();
            }
            Relax();
            int calls2 = random.Next(1, 6);
            for (int i = 0; i < calls2; i++)
            {
                Call();
            }
        }

    }

}

