using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_TrangThaiDonHang
{
    public interface IOrderState { void HandleState(OrderContext context); }

    public class NewOrderState : IOrderState
    {
        public void HandleState(OrderContext context)
        {
            Console.WriteLine("Don hang moi tao -> Chuyen sang trang thai: Da Thanh Toan.");
            context.State = new PaidOrderState();
        }
    }

    public class PaidOrderState : IOrderState
    {
        public void HandleState(OrderContext context)
        {
            Console.WriteLine("Don hang da thanh toan -> San sang ban giao Shipper.");
        }
    }

    public class OrderContext
    {
        public IOrderState State { get; set; } = new NewOrderState();
        public void NextState() => State.HandleState(this);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 20: STATE ORDER PROCESS ===");
            var order = new OrderContext();
            order.NextState();
            order.NextState();
        }
    }
}
