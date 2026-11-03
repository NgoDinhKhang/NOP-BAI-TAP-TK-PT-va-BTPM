using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_OrderBuilder
{
    public class Order
    {
        public string CustomerName { get; set; }
        public List<string> Items { get; set; } = new List<string>();
        public string CouponCode { get; set; }
        public double ShippingFee { get; set; }
        public string Note { get; set; }

        public void Display()
        {
            Console.WriteLine($"Khach hang: {CustomerName}");
            Console.WriteLine($"San pham: {string.Join(", ", Items)}");
            Console.WriteLine($"Ma giam gia: {CouponCode ?? "Khong"}");
            Console.WriteLine($"Phi ship: {ShippingFee:N0} VNĐ");
            Console.WriteLine($"Ghi chu: {Note ?? "Khong"}");
        }
    }

    public class OrderBuilder
    {
        private readonly Order _order = new Order();

        public OrderBuilder ForCustomer(string name) { _order.CustomerName = name; return this; }
        public OrderBuilder AddItem(string item, int qty, double price)
        {
            _order.Items.Add($"{item} (x{qty} - {price * qty:N0}d)");
            return this;
        }
        public OrderBuilder ApplyCoupon(string coupon) { _order.CouponCode = coupon; return this; }
        public OrderBuilder WithExpressShipping(double fee) { _order.ShippingFee = fee; return this; }
        public OrderBuilder AddNote(string note) { _order.Note = note; return this; }
        public Order Build() => _order;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 04: BUILDER ORDER ===");
            var order = new OrderBuilder()
                .ForCustomer("Nguyen Van A")
                .AddItem("Ao so mi Oxford", 2, 350000)
                .AddItem("Ca vat lua", 1, 150000)
                .ApplyCoupon("GIAM20K")
                .WithExpressShipping(30000)
                .AddNote("Giao gio hanh chinh")
                .Build();

            order.Display();
        }
    }
}
