using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Adapter
{
    public interface ITarget { void Request(); }
    public class Adaptee { public void SpecificRequest() => Console.WriteLine("Goi ham Dac thu tu Adaptee."); }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee = new Adaptee();
        public void Request() => _adaptee.SpecificRequest();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P06: ADAPTER PATTERN ===");
            ITarget target = new Adapter();
            target.Request();
        }
    }
}
