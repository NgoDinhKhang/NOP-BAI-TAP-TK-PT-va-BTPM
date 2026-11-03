using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_ChietKhauKhachHang
{
    public interface IDiscountStrategy { double CalculateDiscount(double amount); }

    public class VipDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.15;
    }

    public class CheckoutCalculator
    {
        private readonly IDiscountStrategy _strategy;
        public CheckoutCalculator(IDiscountStrategy strategy) => _strategy = strategy;
        public double GetFinalTotal(double amount) => amount - _strategy.CalculateDiscount(amount);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 21: STRATEGY DISCOUNT ===");
            var checkout = new CheckoutCalculator(new VipDiscountStrategy());
            double total = checkout.GetFinalTotal(1000000);
            Console.WriteLine($"Tong tien cho Khach VIP sau giam 15%: {total:N0} VNĐ");
        }
    }
}
