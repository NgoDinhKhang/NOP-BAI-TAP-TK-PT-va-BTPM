using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_ThongBaoDonHang
{
    public interface IOrderObserver { void OnOrderCompleted(string orderCode); }

    public class EmailCustomerNotifier : IOrderObserver
    {
        public void OnOrderCompleted(string orderCode) => Console.WriteLine($"[Email]: Gui hoa don {orderCode} cho khach hang.");
    }

    public class InventoryNotifier : IOrderObserver
    {
        public void OnOrderCompleted(string orderCode) => Console.WriteLine($"[Kho]: Cap nhat giam ton kho cho {orderCode}.");
    }

    public class OrderSubject
    {
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();
        public void Attach(IOrderObserver obs) => _observers.Add(obs);
        public void CompleteOrder(string code)
        {
            Console.WriteLine($"=== DON HANG {code} THANH CONG ===");
            foreach (var obs in _observers) obs.OnOrderCompleted(code);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 19: OBSERVER ORDER NOTIFICATION ===");
            var subject = new OrderSubject();
            subject.Attach(new EmailCustomerNotifier());
            subject.Attach(new InventoryNotifier());

            subject.CompleteOrder("HD-9999");
        }
    }
}
