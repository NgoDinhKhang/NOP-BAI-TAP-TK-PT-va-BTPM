using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_XetDuyetGiamGia
{
    public abstract class DiscountHandler
    {
        protected DiscountHandler _next;
        public void SetNext(DiscountHandler next) => _next = next;
        public abstract void ApproveDiscount(double percent);
    }

    public class CashierHandler : DiscountHandler
    {
        public override void ApproveDiscount(double percent)
        {
            if (percent <= 5) Console.WriteLine($"Thu ngan: Duyet giam gia {percent}%");
            else _next?.ApproveDiscount(percent);
        }
    }

    public class ManagerHandler : DiscountHandler
    {
        public override void ApproveDiscount(double percent)
        {
            if (percent <= 20) Console.WriteLine($"Quan ly cua hang: Duyet giam gia {percent}%");
            else Console.WriteLine($"Can xin y kien Giam doc cho muc giam {percent}%");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 13: CHAIN OF RESPONSIBILITY DISCOUNT ===");
            var cashier = new CashierHandler();
            var manager = new ManagerHandler();
            cashier.SetNext(manager);

            cashier.ApproveDiscount(3);
            cashier.ApproveDiscount(15);
        }
    }
}
