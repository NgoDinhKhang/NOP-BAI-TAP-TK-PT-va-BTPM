using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_PaymentFactory
{
    public interface IPaymentProcessor { void Process(double amount); }

    public class CashPayment : IPaymentProcessor
    {
        public void Process(double amount) => Console.WriteLine($"Thanh toan tien mat: {amount:N0} VNĐ");
    }

    public class MoMoPayment : IPaymentProcessor
    {
        public void Process(double amount) => Console.WriteLine($"Thanh toan vi MoMo: {amount:N0} VNĐ");
    }

    public abstract class PaymentProcessorFactory
    {
        public abstract IPaymentProcessor CreateProcessor();
    }

    public class MoMoFactory : PaymentProcessorFactory
    {
        public override IPaymentProcessor CreateProcessor() => new MoMoPayment();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 02: FACTORY METHOD PAYMENT ===");
            PaymentProcessorFactory factory = new MoMoFactory();
            IPaymentProcessor payment = factory.CreateProcessor();
            payment.Process(250000);
        }
    }
}
