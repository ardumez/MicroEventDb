using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nJsDb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ctx = new JsDbContext();

            var getValues = ctx.Select(x => x);
        }
    }

    internal class JsDbContext
    {
        public JsDbContext()
        {
        }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
