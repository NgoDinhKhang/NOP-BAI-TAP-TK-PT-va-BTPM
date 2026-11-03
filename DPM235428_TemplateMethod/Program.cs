using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_TemplateMethod
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Step1();
            Step2();
        }
        protected abstract void Step1();
        protected void Step2() => Console.WriteLine("Buoc 2 co dinh.");
    }

    public class ConcreteClass : AbstractClass
    {
        protected override void Step1() => Console.WriteLine("Buoc 1 tuy chinh tai lop con.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P22: TEMPLATE METHOD PATTERN ===");
            AbstractClass app = new ConcreteClass();
            app.TemplateMethod();
        }
    }
}
