using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_FactoryMethod
{
    public interface IButton { void Render(); }
    public class WindowsButton : IButton { public void Render() => Console.WriteLine("Render Windows Button"); }
    public class MacButton : IButton { public void Render() => Console.WriteLine("Render Mac Button"); }

    public abstract class Dialog
    {
        public abstract IButton CreateButton();
        public void RenderWindow() { var btn = CreateButton(); btn.Render(); }
    }

    public class WindowsDialog : Dialog { public override IButton CreateButton() => new WindowsButton(); }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P02: FACTORY METHOD PATTERN ===");
            Dialog dialog = new WindowsDialog();
            dialog.RenderWindow();
        }
    }
}
