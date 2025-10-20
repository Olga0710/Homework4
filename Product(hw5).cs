using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiShop.Models
{
    abstract class Product
    {
        public decimal _price { get; set; }
        public string _country { get; set; }
        public string _name { get; set; }
        public DateTime _packageData { get; set; }
        public string _description { get; set; }
        public abstract string Get_info();

    }

    class FoodProduct : Product
    {
        public int _expirationDate { get; set; }
        public int _quantity { get; set; }
        public string _unitMeasure { get; set; }
        public override string Get_info()
        {
            return($"Food {_name} - {_quantity}, {_unitMeasure}, {_price} hrn; Shelf life {_expirationDate} days");
        }

    }

    class Books : Product
    {
        public int _pages { get; set; }
        public string _publisher { get; set; }
        public string _authors { get; set; }
        public override string Get_info()
        {
            return ($"Book {_name} - {_pages} pages, {_publisher}; Author(-s):  {_authors}");
        }
    }
}
