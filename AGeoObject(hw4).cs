using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographyAbstract
{
    abstract class GeoObject
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public GeoObject(double x, double y, string name, string description)
        {
            _x = x;
            _y = y;
            _name = name;
            _description = description;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"X = {_x}, Y = {_y}");
            Console.WriteLine($"Description: {_description}");
        }
    }

    class River : GeoObject
    {
        public double _speed;
        public double _length;

        public River(double x, double y, string name, string description, double speed, double length): base(x,y,name,description)
        {
            _speed = speed;
            _length = length;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Flow speer: {_speed} sm/s");
            Console.WriteLine($"Length: {_length}");

        }
    }

    class Mountain : GeoObject
    {
        public double _highestPoint;

        public Mountain(double x, double y, string name, string description, double hihestPoint): base(x, y, name, description)
        {
            _highestPoint = hihestPoint; 
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"The highest point: {_highestPoint}");
        }

    }
}

