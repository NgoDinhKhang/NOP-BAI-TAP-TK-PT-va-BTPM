using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Command
{
    public interface ICommand { void Execute(); }
    public class Receiver { public void Action() => Console.WriteLine("Receiver thuc hien hanh dong."); }

    public class ConcreteCommand : ICommand
    {
        private Receiver _receiver;
        public ConcreteCommand(Receiver receiver) => _receiver = receiver;
        public void Execute() => _receiver.Action();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P14: COMMAND PATTERN ===");
            ICommand cmd = new ConcreteCommand(new Receiver());
            cmd.Execute();
        }
    }
}
