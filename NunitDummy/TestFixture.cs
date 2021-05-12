using System;
using System.Collections.Generic;
using AnotherAssembly;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NunitDummy
{
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void TestPass() => Assert.Pass();

        [Test]
        public void TestFail() => Assert.Fail();


        public static async Task AStaticAsyncMethod( AnotherEnum ae)
        {
            Console.WriteLine(ae);
            await Task.Delay(100);
        }

        public static IEnumerable<AnotherEnum> AnEnumerableMethod( AnotherEnum ae)
        {
            yield return ae;
        }

    }
}