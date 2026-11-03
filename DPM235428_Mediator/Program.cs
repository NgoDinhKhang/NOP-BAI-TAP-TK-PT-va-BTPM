using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Mediator
{
    public interface IMediator { void Notify(string sender, string ev); }
    public class ConcreteMediator : IMediator
    {
        public void Notify(string sender, string ev) => Console.WriteLine($"Mediator nhan duoc {ev} tu {sender}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P17: MEDIATOR PATTERN ===");
            IMediator mediator = new ConcreteMediator();
            mediator.Notify("ComponentA", "ClickEvent");
        }
    }
}
