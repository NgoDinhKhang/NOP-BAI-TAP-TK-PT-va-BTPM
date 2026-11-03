using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_QuyTrinhBanHang
{
    public abstract class SalesProcessTemplate
    {
        public void ProcessOrder()
        {
            SelectProduct();
            CalculateTotal();
            PrintInvoice();
        }

        protected void SelectProduct() => Console.WriteLine("1. Quet ma vach chon san pham.");
        protected abstract void CalculateTotal();
        protected void PrintInvoice() => Console.WriteLine("3. In va giao hoa don cho khach.");
    }

    public class PosRetailProcess : SalesProcessTemplate
    {
        protected override void CalculateTotal() => Console.WriteLine("2. Tinh tien mat tai quay POS.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 22: TEMPLATE METHOD SALES PROCESS ===");
            SalesProcessTemplate process = new PosRetailProcess();
            process.ProcessOrder();
        }
    }
}
