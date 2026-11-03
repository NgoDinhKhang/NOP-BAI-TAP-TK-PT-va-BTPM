using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_LichSuThaoTacPos
{
    public interface ICommand { void Execute(); void Undo(); }

    public class OrderReceiver
    {
        public void AddItem(string item) => Console.WriteLine($"-> Da them {item} vao don hang.");
        public void RemoveItem(string item) => Console.WriteLine($"<- Da huy {item} khoi don hang.");
    }

    public class AddItemCommand : ICommand
    {
        private readonly OrderReceiver _receiver;
        private readonly string _item;
        public AddItemCommand(OrderReceiver receiver, string item) { _receiver = receiver; _item = item; }
        public void Execute() => _receiver.AddItem(_item);
        public void Undo() => _receiver.RemoveItem(_item);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 14: COMMAND POS UNDO ===");
            var receiver = new OrderReceiver();
            ICommand cmd1 = new AddItemCommand(receiver, "Ca phe Sua da");

            cmd1.Execute();
            Console.WriteLine("Nhan nut Undo...");
            cmd1.Undo();
        }
    }
}
