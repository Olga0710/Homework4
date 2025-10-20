using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographyAbstract
{
    abstract class AGeoObject
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public AGeoObject(double x, double y, string name, string description)
        {
            _x = x;
            _y = y;
            _name = name;
            _description = description;
        }
        public virtual void Get_info()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"X = {_x}, Y = {_y}");
            Console.WriteLine($"Description: {_description}");
        }
    }

    class River : AGeoObject
    {
        public double _speed;
        public double _length;

        public River(double x, double y, string name, string description, double speed, double length): base(x,y,name,description)
        {
            _speed = speed;
            _length = length;
        }

        public override void Get_info()
        {
            base.Get_info();
            Console.WriteLine($"Flow speer: {_speed} sm/s");
            Console.WriteLine($"Length: {_length}");

        }
    }

    class Mountain : AGeoObject
    {
        public double _highestPoint;

        public Mountain(double x, double y, string name, string description, double hihestPoint): base(x, y, name, description)
        {
            _highestPoint = hihestPoint; 
        }

        public override void Get_info()
        {
            base.Get_info();
            Console.WriteLine($"The highest point: {_highestPoint}");
        }

    }
}
