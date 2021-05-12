using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnotherAssembly
{
    public enum AnotherEnum
    {
        Val1,
        Val2
    };


    public class AnotherClass
    {
        private readonly int _anotherInt;
        public AnotherClass(int ii) => _anotherInt = ii;
        public int DoStuff(string ss) => ss.Length + _anotherInt;

        //public async Task<int> DoStuffAsync(string ss)
        //{
        //    await Task.Delay(100);
        //    return ss.Length + _anotherInt;
        //}
    }
}
