using nJsDb.LoadObjectFromFile;
using nJsDb.Tests.Helpers;
using Xunit;

namespace nJsDb.Tests
{
    public class LoadObjectFromFileTest
    {
        private readonly string _filePath = "./files/loadobjectfromfile/microdb.db";

        /// <summary>
        /// First version there are one object by page
        /// </summary>
        [Fact]
        public void AddEntityInFile()
        {
            // Arrange
            FileHelper.DeleteFile(_filePath);
            var engine = new EngineDb(_filePath);
            var firstCar = Car.Create(2007, "Renault");
      
            // Act
            engine.AddEntity(firstCar);
            var entity1Result = engine.Find<Car>(1);

            // Assert
            Assert.NotNull(entity1Result);
        }

        [Fact]
        public void AddTwoEntityInFile()
        {
            // Arrange
            FileHelper.DeleteFile(_filePath);
            var engine = new EngineDb(_filePath);
            var firstCar = Car.Create(2007, "Renault");
            var secondCar = Car.Create(2018, "Audi");

            // Act
            engine.AddEntity(firstCar);
            engine.AddEntity(secondCar);

            Car[] results = new Car[2];
            results[0] = engine.Find<Car>(1);
            results[1] = engine.Find<Car>(2);

            // Assert
            Assert.NotNull(results[0]);
            Assert.Equal("Renault", results[0].Brand);
            Assert.NotNull(results[1]);
            Assert.Equal("Audi", results[1].Brand);
        }
    }
}