using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_CheckoutFacade
{
    public class InventoryService
    {
        public bool ReserveStock(string item) { Console.WriteLine($"[Kho]: Da giu hang {item}"); return true; }
    }

    public class PaymentService
    {
        public bool Charge(double amount) { Console.WriteLine($"[Thanh toan]: Da tru {amount:N0}d"); return true; }
    }

    public class CheckoutFacade
    {
        private readonly InventoryService _inv = new InventoryService();
        private readonly PaymentService _pay = new PaymentService();

        public bool PlaceOrder(string item, double amount)
        {
            Console.WriteLine("--- FACADE: CHECKOUT 1-CHAM ---");
            if (!_inv.ReserveStock(item)) return false;
            if (!_pay.Charge(amount)) return false;
            Console.WriteLine("=== DAT HANG THANH CONG ===");
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 10: FACADE CHECKOUT ===");
            var facade = new CheckoutFacade();
            facade.PlaceOrder("Laptop Dell XPS", 32000000);
        }
    }
}
