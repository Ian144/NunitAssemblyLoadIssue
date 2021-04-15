 using System;
 using NUnit.Framework;

 namespace NunitDummy
{
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void Test1() => Assert.Fail();

        [Test] 
        public void Test2() => Assert.Pass();
    }
}
