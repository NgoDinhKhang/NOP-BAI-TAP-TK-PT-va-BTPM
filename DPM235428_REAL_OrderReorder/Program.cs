using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_OrderReorder
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderItem Clone() => new OrderItem { ProductName = this.ProductName, Quantity = this.Quantity };
    }

    public class Order : ICloneable
    {
        public string OrderId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public object Clone()
        {
            var cloned = (Order)this.MemberwiseClone();
            cloned.Items = this.Items.Select(i => i.Clone()).ToList();
            return cloned;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 05: PROTOTYPE RE-ORDER ===");
            var original = new Order
            {
                OrderId = "HD-1001",
                Items = new List<OrderItem> { new OrderItem { ProductName = "Sua hop Vinamilk", Quantity = 10 } }
            };

            var reorder = (Order)original.Clone();
            reorder.OrderId = "HD-1002";
            reorder.Items.Quantity = 50;

            Console.WriteLine($"Don goc ({original.OrderId}): {original.Items.ProductName} x{original.Items.Quantity}");
            Console.WriteLine($"Don Re-order ({reorder.OrderId}): {reorder.Items.ProductName} x{reorder.Items.Quantity}");
        }
    }
}
