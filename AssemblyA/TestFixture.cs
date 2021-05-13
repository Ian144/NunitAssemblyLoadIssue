using System.Collections.Generic;
using System.Threading.Tasks;
using AssemblyB;
using NUnit.Framework;

namespace AssemblyA
{
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void TestPass() => Assert.Pass();

        [Test]
        public void TestFail() => Assert.Fail();

        // AStaticAsyncMethod causes the compiler to create a statemachine that refers to
        // a type, MyEnum, defined in AssemblyB, the project reference for which in AssemblyA
        // has copyLocal set to false. As AssemblyB will not have the appropriate entries in 
        // AssemblyA.deps.json, even though it AssemblyB exists in the same directory as
        // AssemblyA, it will not be loadable without correct handling in the AssemblyResolve event.
        public static async Task AStaticAsyncMethod( MyEnum ae )
        {
            await Task.Delay(100);
        }

        //public static IEnumerable<MyEnum> AnEnumerableMethod( MyEnum ae )
        //{
        //    yield return ae;
        //}
    }
}