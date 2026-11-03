using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_State
{
    public interface IState { void Handle(); }
    public class ConcreteStateA : IState { public void Handle() => Console.WriteLine("Xu ly theo Trang thai A"); }

    public class Context
    {
        public IState State { get; set; }
        public void Request() => State.Handle();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P20: STATE PATTERN ===");
            Context ctx = new Context { State = new ConcreteStateA() };
            ctx.Request();
        }
    }
}
