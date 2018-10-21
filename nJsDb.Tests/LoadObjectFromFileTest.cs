using nJsDb.LoadObjectFromFile;
using System;
using Xunit;

namespace nJsDb.Tests
{

    public class LoadObjectFromFileTest
    {
        [Serializable]
        public class Entity1
        {
            public int Int1 { get; set; }
            public string String1 { get; set; }

            public static Entity1 Create()
            {
                return new Entity1()
                {
                    Int1 = 1,
                    String1 = "1"
                };
            }
        }

        [Serializable]
        public class Entity2
        {
            public int Int1 { get; set; }
            public int Int2 { get; set; }
            public string String1 { get; set; }
        }

        [Fact]
        public void AddEntityInFile()
        {
            // Arrange
            var filePath = "./files/loadobjectfromfile/microdb.db";
            var engine = new EngineDb(filePath);
            var entity1 = Entity1.Create();
      
            // Action
            engine.AddEntity(entity1);


//            engine.GetAllPagesFromDisk();
        }

        [Fact]
        public void AddDifferentTypeDifferentSize()
        {
            // Arrange



        }
    }
}