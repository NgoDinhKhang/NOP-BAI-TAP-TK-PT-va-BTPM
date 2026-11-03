using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Memento
{
    public class Memento
    {
        public string State { get; }
        public Memento(string state) => State = state;
    }

    public class Originator
    {
        public string State { get; set; }
        public Memento Save() => new Memento(State);
        public void Restore(Memento m) => State = m.State;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P18: MEMENTO PATTERN ===");
            var originator = new Originator { State = "State #1" };
            var backup = originator.Save();
            originator.State = "State #2";
            originator.Restore(backup);
            Console.WriteLine($"Khoi phục trang thai: {originator.State}");
        }
    }
}
