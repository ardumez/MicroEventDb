using MicroEventDb.LoadObjectFromFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nJsDb.Tests.Engine
{
    public class ByteHelperTest
    {
        [Fact]
        public void WhenSplitTest()
        {
            // Arrange
            var testData = new byte[] { 0x20, 0x20, 0x20, 0x21, 0x21, 0x21, 0x22 };

            // Action
            var result = ByteHelper.Split(testData, 3);

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
