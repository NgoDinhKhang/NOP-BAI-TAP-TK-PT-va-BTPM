using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Visitor
{
    public interface IVisitor { void Visit(Element element); }
    public class Element
    {
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class ConcreteVisitor : IVisitor
    {
        public void Visit(Element element) => Console.WriteLine("Visitor thao tac tren Element");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P23: VISITOR PATTERN ===");
            Element element = new Element();
            element.Accept(new ConcreteVisitor());
        }
    }
}
