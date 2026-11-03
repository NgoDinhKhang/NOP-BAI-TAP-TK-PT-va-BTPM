using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Composite
{
    public interface IComponent { void Operation(); }
    public class Leaf : IComponent { public void Operation() => Console.WriteLine("Thao tac tren La"); }

    public class Composite : IComponent
    {
        private List<IComponent> _children = new List<IComponent>();
        public void Add(IComponent c) => _children.Add(c);
        public void Operation() { foreach (var item in _children) item.Operation(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P08: COMPOSITE PATTERN ===");
            Composite root = new Composite();
            root.Add(new Leaf());
            root.Operation();
        }
    }
}
