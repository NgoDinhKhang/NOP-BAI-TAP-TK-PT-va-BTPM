using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_HoaDonDecorator
{
    public interface IOrder { double GetCost(); }

    public class BaseOrder : IOrder
    {
        public double GetCost() => 200000;
    }

    public abstract class OrderDecorator : IOrder
    {
        protected IOrder _order;
        public OrderDecorator(IOrder order) => _order = order;
        public virtual double GetCost() => _order.GetCost();
    }

    public class VatDecorator : OrderDecorator
    {
        public VatDecorator(IOrder order) : base(order) { }
        public override double GetCost() => base.GetCost() * 1.08;
    }

    public class ShippingDecorator : OrderDecorator
    {
        private readonly double _fee;
        public ShippingDecorator(IOrder order, double fee) : base(order) => _fee = fee;
        public override double GetCost() => base.GetCost() + _fee;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 09: DECORATOR HOA DON ===");
            IOrder order = new BaseOrder();
            order = new VatDecorator(order);
            order = new ShippingDecorator(order, 20000);

            Console.WriteLine($"Tong thanh toan (Goc + VAT 8% + Ship 20k): {order.GetCost():N0} VNĐ");
        }
    }
