using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Strategy
{
    public interface IStrategy { void Execute(); }
    public class StrategyA : IStrategy { public void Execute() => Console.WriteLine("Chay Thuat toan A"); }

    public class Context
    {
        private IStrategy _strategy;
        public Context(IStrategy strategy) => _strategy = strategy;
        public void DoWork() => _strategy.Execute();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P21: STRATEGY PATTERN ===");
            Context ctx = new Context(new StrategyA());
            ctx.DoWork();
        }
    }
}
