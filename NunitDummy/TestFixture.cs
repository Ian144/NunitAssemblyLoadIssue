using AnotherAssembly;
using NUnit.Framework;

 namespace NunitDummy
{
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void ShouldFail() => Assert.Fail();

        [Test] 
        public void ShouldPass()
        {
            MyClass.DoStuff();
            Assert.Pass();
        }

        [Test] 
        [Category("exclude")]
        public void ShouldBeExcluded() => Assert.Fail();
    }
}
