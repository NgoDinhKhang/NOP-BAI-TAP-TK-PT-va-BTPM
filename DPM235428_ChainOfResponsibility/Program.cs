using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler _next;
        public void SetNext(Handler next) => _next = next;
        public abstract void Handle(int request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void Handle(int request)
        {
            if (request < 10) Console.WriteLine($"Handler 1 xu ly request {request}");
            else _next?.Handle(request);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P13: CHAIN OF RESPONSIBILITY ===");
            Handler h1 = new ConcreteHandler1();
            h1.Handle(5);
        }
    }
}
