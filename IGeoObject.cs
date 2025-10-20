using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographyInterface
{
    internal interface IGeoObject
    {
        double _x { get; set; }
        double _y { get; set; }
        string _name { get; set; }
        string _description { get; set; }

        void Get_info();
    }

    class River : IGeoObject
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public double _speed { get; set; }
        public double _length { get; set; }

        public River(double x, double y, string name, string description, double speed, double length)
        {
            _x = x;
            _y = y;
            _name = name;
            _description = description;
            _speed = speed;
            _length = length;
        }
        public void Get_info()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"X = {_x}, Y = {_y}");
            Console.WriteLine($"Description: {_description}");
            Console.WriteLine($"Flow speer: {_speed} sm/s");
            Console.WriteLine($"Length: {_length}");
        }

    }
    class Mountain: IGeoObject
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public double _highestPoint { get; set; }
        public Mountain (double x, double y, string name, string description, double highestPoint)
        {
            _x = x;
            _y = y;
            _name = name;
            _description = description;
            _highestPoint = highestPoint;
        }
        public void Get_info()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"X = {_x}, Y = {_y}");
            Console.WriteLine($"Description: {_description}");
            Console.WriteLine($"The hisghest point: {_highestPoint} sm/s");
          
        }

    }
}
