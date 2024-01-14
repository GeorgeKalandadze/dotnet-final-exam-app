using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_magazine
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public string VinCode { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
