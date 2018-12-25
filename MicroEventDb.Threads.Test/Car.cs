using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.Threads.Test
{
    [Serializable]
    public class Car
    {
        public int Year { get; set; }
        public string Brand { get; set; }

        public static Car Create(int year, string brand)
        {
            return new Car()
            {
                Year = year,
                Brand = brand
            };
        }
    }
}
