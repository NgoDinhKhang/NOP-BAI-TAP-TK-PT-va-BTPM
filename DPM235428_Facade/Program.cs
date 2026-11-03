using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Facade
{
    public class SubsystemA { public void OperationA() => Console.WriteLine("Subsystem A"); }
    public class SubsystemB { public void OperationB() => Console.WriteLine("Subsystem B"); }

    public class Facade
    {
        private SubsystemA _a = new SubsystemA();
        private SubsystemB _b = new SubsystemB();
        public void Operation() { _a.OperationA(); _b.OperationB(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P10: FACADE PATTERN ===");
            Facade facade = new Facade();
            facade.Operation();
        }
    }
}
