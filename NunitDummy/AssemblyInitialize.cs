using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using static System.IO.Directory;

namespace NunitDummy
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
            AnotherAssembly.MyClass.DoStuff();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            AnotherAssembly.MyClass.DoStuff();
        }
    }
}
