using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_BaoCaoThongKePos
{
    public interface IVisitor { void Visit(RetailOrder order); }

    public class RetailOrder
    {
        public double Amount { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class TaxReportVisitor : IVisitor
    {
        public void Visit(RetailOrder order)
        {
            Console.WriteLine($"Thong ke thue VAT (8%): {order.Amount * 0.08:N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 23: VISITOR POS REPORT ===");
            var order = new RetailOrder { Amount = 500000 };
            IVisitor taxReport = new TaxReportVisitor();

            order.Accept(taxReport);
        }
    }
}
