using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_AbstractFactory
{

    public interface IButton { void Paint(); }
    public interface ICheckbox { void Paint(); }

    public class WinButton : IButton { public void Paint() => Console.WriteLine("Win Button"); }
    public class WinCheckbox : ICheckbox { public void Paint() => Console.WriteLine("Win Checkbox"); }

    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    public class WinFactory : IGUIFactory
    {
        public IButton CreateButton() => new WinButton();
        public ICheckbox CreateCheckbox() => new WinCheckbox();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P03: ABSTRACT FACTORY PATTERN ===");
            IGUIFactory factory = new WinFactory();
            factory.CreateButton().Paint();
            factory.CreateCheckbox().Paint();
        }
    }
}
