using nJsDb.LoadObjectFromFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.Threads.Test
{
    class Program
    {
        private static readonly string _filePath = "./files/loadobjectfromfile/microdb.db";

        static void Main(string[] args)
        {
            // Arrange
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            var engine = new EngineDb(_filePath);


            Task task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    var car = Car.Create(i, "Audi");

                    // Act
                    engine.AddEntity(car);
                }
            });
            Task task2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    var car = Car.Create(i, "Renauld");

                    // Act
                    engine.AddEntity(car);
                }
            });

            Task.WaitAll(task1, task2);
            engine.SaveAll();
            Car[] results = new Car[2];
            results[0] = engine.Find<Car>(1);
            results[1] = engine.Find<Car>(2);
        }
    }
}
