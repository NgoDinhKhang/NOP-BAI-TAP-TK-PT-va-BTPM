using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Interpreter
{
    public interface IExpression { bool Interpret(string context); }
    public class TerminalExpression : IExpression
    {
        private string _data;
        public TerminalExpression(string data) => _data = data;
        public bool Interpret(string context) => context.Contains(_data);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P15: INTERPRETER PATTERN ===");
            IExpression exp = new TerminalExpression("C#");
            Console.WriteLine($"Ket qua dich: {exp.Interpret("Lap trinh C#")}");
        }
    }
}
