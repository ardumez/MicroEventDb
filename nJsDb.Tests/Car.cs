using System;

namespace nJsDb.Tests
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
